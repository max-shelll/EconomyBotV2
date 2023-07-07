using EconomyBot.DAL.Models;
using MongoDB.Driver;

namespace EconomyBot.DAL.Repositories
{
    public class UserRepository
    {
        private const string ConnectionString = Config.ConnectionString;
        private const string DatabaseName = Config.DatabaseName;
        private const string UserCollection = "users";

        private IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabaseName);
            return db.GetCollection<T>(collection);
        }

        public Task<User> GetUserById(ulong id)
        {
            var userCollection = ConnectToMongo<User>(UserCollection);
            var users = userCollection.Find(user => true).ToList();
            var result = users.FirstOrDefault(u => u.id == id);

            return Task.FromResult(result);
        }

        public Task<List<User>> GetUsers()
        {
            var userCollection = ConnectToMongo<User>(UserCollection);
            var users = userCollection.Find(user => true).ToList();

            return Task.FromResult(users);
        }

        public Task CreateUser(User user)
        {
            var usersCollection = ConnectToMongo<User>(UserCollection);

            return usersCollection.InsertOneAsync(user);
        }

        public async Task UpdateUser(ulong id, User user)
        {
            var userCollection = ConnectToMongo<User>(UserCollection);
            var currentUser = GetUserById(id).Result;

            await userCollection.ReplaceOneAsync(user => user.id == id, user);
        }

        public Task DeleteUser(ulong id)
        {
            var userCollection = ConnectToMongo<User>(UserCollection);
            var currentUser = GetUserById(id).Result;

            return userCollection.DeleteOneAsync(u => u.id == currentUser.id);
        }
    }
}
