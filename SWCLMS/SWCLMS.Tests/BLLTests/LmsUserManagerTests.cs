using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using NUnit.Framework;
using SWCLMS.BLL;
using SWCLMS.Models.Tables;
using SWCLMS.Tests.Base;

namespace SWCLMS.Tests.BLLTests
{
    public class LmsUserManagerTests : SqlDbResetter
    {
        private IKernel _ninjectKernel;
        private LmsUserManager _lmsUserManager;

        [TestFixtureSetUp]
        public void SetUpNinject()
        {
            _ninjectKernel = new StandardKernel();

            _ninjectKernel.Load(DependencyLoader.LoadModule());

            _lmsUserManager = _ninjectKernel.Get<LmsUserManager>();
        }

        [Test]
        public void CreateInvalidUserIsRejected()
        {
            var newUser = new LmsUser()
            {
                Email = null,
                FirstName = "Uh oh, stuff is missing here!"                
            };

            var response = _lmsUserManager.CreateUser(newUser);

            Assert.IsFalse(response.Success);
            Console.WriteLine(response.Message);
        }

        [Test]
        public void CreateValidUserIsSuccess()
        {
            var newUser = new LmsUser()
            {
                Email = "gg@gmail.com",
                FirstName = "Gerald",
                LastName = "Success"
            };

            var response = _lmsUserManager.CreateUser(newUser);

            Assert.IsTrue(response.Success);
            Assert.IsNotNull(response.Data);
            Console.WriteLine(response.Data);
        }

    }
}
