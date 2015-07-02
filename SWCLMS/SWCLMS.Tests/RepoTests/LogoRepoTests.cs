using NUnit.Framework;
using SWCLMS.Data.SQL;
using SWCLMS.Tests.Base;

namespace SWCLMS.Tests.RepoTests
{
    [TestFixture]
    public class LogoRepoTests : SqlDbResetter
    {
        private SqlLogoRepository _repo = new SqlLogoRepository();

        [Test]
        public void CanGetLogo()
        {
            var filepath = _repo.GetLogo();

            Assert.IsNotNull(filepath);
        }

        [Test]
        public void CanSetLogo()
        {
            _repo.SetLogo("stuff");

            var filepath = _repo.GetLogo();

            Assert.AreEqual(filepath, "stuff");
        }
    }
}
