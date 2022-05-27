using API.Entities;
using Bogus;
using Bogus.DataSets;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace API.TESTS.UserTest
{
    [CollectionDefinition(nameof(AppUserCollection))]
    public class AppUserCollection : ICollectionFixture<AppUser>
    { }

    public class AppUserFixture : IDisposable
    {
        public AppUser GenerateValidUser()
        {
            return GenerateUsers(1, true).FirstOrDefault();
        }

        public IEnumerable<AppUser> GetRandomAppUsers()
        {
            var users = new List<AppUser>();

            users.AddRange(GenerateUsers(5, true));
            users.AddRange(GenerateUsers(5, false));

            return users;
        }


        public IEnumerable<AppUser> GenerateUsers(int quantity, bool active)
        {
            var gender = new Faker().PickRandom<Name.Gender>();

            var users = new Faker<AppUser>("pt_BR");
            users.RuleFor(u => u.UserName, (f, u) => f.Name.FullName(gender));
            // add all properties here

            return users.Generate(quantity);
        }

        public void Dispose()
        {

        }
    }
}
