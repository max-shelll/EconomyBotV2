using EconomyBot.DAL.Models;
using MongoDB.Driver;

namespace EconomyBot.DAL.Repositories
{
    public class RoleRepository
    {
        private const string ConnectionString = Config.ConnectionString;
        private const string DatabaseName = Config.DatabaseName;
        private const string RoleCollection = "roles";

        private IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabaseName);

            return db.GetCollection<T>(collection);
        }

        public Task<Role> GetRoleById(ulong id)
        {
            var roleCollection = ConnectToMongo<Role>(RoleCollection);
            var roles = roleCollection.Find(role => true).ToList();
            var result = roles.FirstOrDefault(u => u.id == id);

            return Task.FromResult(result);
        }

        public Task<List<Role>> GetRoles()
        {
            var roleCollection = ConnectToMongo<Role>(RoleCollection);
            var roles = roleCollection.Find(role => true).ToList();

            return Task.FromResult(roles);
        }

        public Task CreateRole(Role role)
        {
            var roleCollection = ConnectToMongo<Role>(RoleCollection);
            return roleCollection.InsertOneAsync(role);
        }

        public Task UpdateRole(ulong id, Role role)
        {
            var roleCollection = ConnectToMongo<Role>(RoleCollection);
            var currentRole = GetRoleById(id).Result;

            return roleCollection.ReplaceOneAsync(role => role.id == currentRole.id, role);
        }

        public Task DeleteRole(ulong id)
        {
            var roleCollection = ConnectToMongo<Role>(RoleCollection);
            var currentRole = GetRoleById(id).Result;

            return roleCollection.DeleteOneAsync(r => r.id == currentRole.id);
        }
    }
}
