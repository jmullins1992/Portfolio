using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCLMS.Data.SQL;
using SWCLMS.Models.Responses;

namespace SWCLMS.BLL
{
    public class LogoManager
    {
        private SqlLogoRepository _repo = new SqlLogoRepository();

        public DataResponse<string> GetLogo()
        {
            var response = new DataResponse<string>();

            try
            {
                response.Data = "~/Uploads/" + _repo.GetLogo();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false; 
            }

            return response;
        }

        public Response SetLogo(string filepath)
        {
            var response = new Response();

            try
            {
                _repo.SetLogo(filepath);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }
    }
}
