using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Configuration;
using Dapper;
using SWCLMS.Models.Interfaces;
using SWCLMS.Models.Requests;
using SWCLMS.Models.Tables;

namespace SWCLMS.Data.SQL
{
    public class SqlLmsUserRepository : ILmsUserRepository
    {
        public List<LmsUser> GetUnassignedUsers()
        {
            List<LmsUser> users = new List<LmsUser>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("spGetAllUnassignedUsers", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var user = new LmsUser();
                        user.UserId = (int)dr["UserId"];
                        user.AspId = dr["AspId"].ToString();                            

                        //if (dr["AspId"] != DBNull.Value)
                        //{
                        //    user.AspId = dr["AspId"].ToString();                            
                        //}
                        user.FirstName = dr["FirstName"].ToString();
                        user.LastName = dr["LastName"].ToString();
                        user.Email = dr["Email"].ToString();
                        user.SuggestedRole = dr["SuggestedRole"].ToString();

                        if (dr["GradeLevelId"] != DBNull.Value)
                            user.GradeLevelId = (byte) dr["GradeLevelId"];

                        users.Add(user);
                    }
                }
            }
            return users;
        }

        public List<LmsUser> GetStudentsByParentId(int id)
        {
            using (SqlConnection cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@GuardianId", id);

                var students = cn.Query<LmsUser>("spGetStudentsByGuardianId", p, commandType: CommandType.StoredProcedure).ToList();

                return students;
            }
        }

        public List<LmsUser> SearchUsers(SearchRequest request)
        {
            using (SqlConnection cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var p = new DynamicParameters();

                if (!String.IsNullOrEmpty(request.FirstName))
                {
                    p.Add("@FirstName", request.FirstName);
                }
                if (!String.IsNullOrEmpty(request.LastName))
                {
                    p.Add("@LastName", request.LastName);
                }
                if (!String.IsNullOrEmpty(request.Email))
                {
                    p.Add("@Email", request.Email);
                }
                if (!String.IsNullOrEmpty(request.RoleName))
                {
                    p.Add("@RoleName", request.RoleName);
                }

                var users = cn.Query<LmsUser>("spUserSearch", p, commandType: CommandType.StoredProcedure).OrderBy(u=>u.LastName).ThenBy(u=>u.FirstName).ThenBy(u=>u.Email).ToList();

                return users;
            }
        }

        public LmsUser GetLmsUserById(int id)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@UserId", id);

                return
                    cn.Query<LmsUser>("spGetUserDetailsById", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }



        public List<string> GetUserRolesById(int id)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@UserId", id);

                return
                    cn.Query<string>("spGetUserRolesById", p, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public void EditUser(EditUserRequest editUser)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@UserId", editUser.LmsUser.UserId);
                p.Add("@IsStudent", editUser.IsStudent ? 1 : 0);
                p.Add("@IsParent", editUser.IsParent ? 1 : 0);
                p.Add("@IsTeacher", editUser.IsTeacher ? 1 : 0);
                p.Add("@IsAdmin", editUser.IsAdmin ? 1 : 0);
                
                cn.Execute("spUpdateUserRoles", p, commandType: CommandType.StoredProcedure);

                var p2 = new DynamicParameters();
                p2.Add("@UserId", editUser.LmsUser.UserId);
                p2.Add("@LastName", editUser.LmsUser.LastName);
                p2.Add("@FirstName", editUser.LmsUser.FirstName);
                p2.Add("@Email", editUser.LmsUser.Email);
                p2.Add("@SuggestedRole", editUser.LmsUser.SuggestedRole);
                p2.Add("@GradeLevelId", editUser.LmsUser.GradeLevelId);

                cn.Execute("spUpdateUserDetails", p2, commandType: CommandType.StoredProcedure);

            }
        }




        public int CreateUser(LmsUser user)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@AspId", user.AspId);
                p.Add("@LastName", user.LastName);
                p.Add("@FirstName", user.FirstName);
                p.Add("@Email", user.Email);
                p.Add("@SuggestedRole", user.SuggestedRole);
                p.Add("@GradeLevelId", user.GradeLevelId);
                p.Add("@UserId", direction: ParameterDirection.Output, dbType: DbType.Int32);

                cn.Execute("spAddUser", p, commandType: CommandType.StoredProcedure);

                return p.Get<int>("@UserId");

            }
        }


        public LmsUser GetUserByAspId(string aspId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@AspId", aspId);

                return
                    cn.Query<LmsUser>("spGetLmsUserByAspId", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }


        public void UpdateParentRelationships(int parentId, List<int> childIdList)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                cn.Open();
                using (var transaction = cn.BeginTransaction())
                {
                    cn.Execute("spRemoveGuardianRelationships", new{GuardianId = parentId},commandType: CommandType.StoredProcedure,
                        transaction: transaction);

                    foreach (var childId in childIdList)
                    {
                        var p = new DynamicParameters();
                        p.Add("@GuardianId", parentId);
                        p.Add("@StudentId", childId);

                        cn.Execute("spAddStudentGuardian", p, transaction: transaction, commandType: CommandType.StoredProcedure);
                    }

                    transaction.Commit();
                }
            }
        }
    }
}
