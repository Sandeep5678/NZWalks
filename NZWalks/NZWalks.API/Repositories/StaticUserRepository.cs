
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{

    public class StaticUserRepository : IUserRepository
    {
        private List<User> users = new List<User>()
        {
            new User()
            {
                FirstName = "Read Only", LastName = "User", EmailAddress = "readonly@User.com",
                Id = Guid.NewGuid(), UserName = "readonly@User.com", Password = "readonly@User",
                Roles = new List<string> { "reader" }
            },
            new User()
            {
                FirstName = "Read Write", LastName = "User", EmailAddress = "readwrite@User.com",
                Id = Guid.NewGuid(), UserName = "readwrite@User.com", Password = "readwrite@User",
                Roles = new List<string> { "reader", "writer" }
            }
        };
        public async Task<bool> AutenticateAsync(string username, string password)
        {
            var user = users.Find(x => x.UserName.Equals(username, StringComparison.InvariantCultureIgnoreCase) && x.Password == password);
            if (user != null)
            {
                return true;
            }
            return false;
        }
    }
}
