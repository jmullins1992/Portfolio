using Ninject.Modules;
using SWCLMS.Data;
using SWCLMS.Data.Mocks;
using SWCLMS.Data.SQL;
using SWCLMS.Models.Interfaces;

namespace SWCLMS.BLL
{
    public class MockNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILmsUserRepository>().To<MockLmsUserRepository>();
            Bind<ISubjectRepository>().To<MockSubjectRepository>();
            Bind<IAssignmentRepository>().To<MockAssignmentRepository>();
            Bind<ICourseRepository>().To<MockCourseRepository>();
            Bind<IGradeLevelRepository>().To<MockGradeLevelRepository>();

        }
    }

    public class SqlNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILmsUserRepository>().To<SqlLmsUserRepository>();
            Bind<ISubjectRepository>().To<SqlSubjectRepository>();
            //TODO fix this
            Bind<ICourseRepository>().To<SqlCourseRepository>();
            Bind<IAssignmentRepository>().To<SqlAssignmentRepository>();
            Bind<IGradeLevelRepository>().To<MockGradeLevelRepository>();     
        }
    }

    public class DependencyLoader
    {
        public static NinjectModule LoadModule()
        {
            if(Settings.GetMode() == "SQL")
                return new SqlNinjectModule();

            return new MockNinjectModule();
        }
    }

}
