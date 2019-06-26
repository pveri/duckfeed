using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ducks.Tests
{
    [TestClass]
    public class TestDucks
    {
        private static string[] UserNames = {"test1@test.com" };
        private static Guid[] UserId = {new Guid("bff7eb1b-7008-486d-9ab3-896d388412dd") };
        private Ducks.Application.Models.DuckManager _manager;
        private Ducks.Data.Context.DuckContext _db;
        public TestDucks()
        {
            _db = new Data.Context.DuckContext();
            _manager = new Application.Models.DuckManager(_db);
        }
        [TestMethod]
        public void TestAddUser()
        {
            for (var i = 0; i < UserNames.Length; i++)
            {
                var user = new Ducks.Data.User() { Email = UserNames[i] };
                _manager.AddDuckFeeder(UserId[i], UserNames[i]);
            }
            var dbUser = _db.Users.Find(UserId[0]);
            Assert.IsTrue(dbUser.Email == UserNames[0]);
        
        }
    }
}
