using EconomyBot.DAL.Models;
using MongoDB.Driver;

namespace EconomyBot.DAL.Repositories
{
    public class WorkRepository
    {
        private const string ConnectionString = Config.ConnectionString;
        private const string DatabaseName = Config.DatabaseName;
        private const string WorkCollection = "works";

        private IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabaseName);
            return db.GetCollection<T>(collection);
        }

        public Task<Work> GetWorkByName(string name)
        {
            var workCollection = ConnectToMongo<Work>(WorkCollection);
            var works = workCollection.Find(work => true).ToList();
            var result = works.FirstOrDefault(w => w.name == name);

            return Task.FromResult(result);
        }

        public Task<List<Work>> GetWorks()
        {
            var workCollection = ConnectToMongo<Work>(WorkCollection);
            var works = workCollection.Find(work => true).ToList();

            return Task.FromResult(works);
        }

        public Task CreateWork(Work work)
        {
            var workCollection = ConnectToMongo<Work>(WorkCollection);

            return workCollection.InsertOneAsync(work);
        }

        public Task UpdateWork(string name, Work work)
        {
            var workCollection = ConnectToMongo<Work>(WorkCollection);
            var currentWork = GetWorkByName(name).Result;

            return workCollection.ReplaceOneAsync(work => work.name == currentWork.name, work);
        }

        public Task DeleteWork(string name)
        {
            var workCollection = ConnectToMongo<Work>(WorkCollection);
            var currentWork = GetWorkByName(name).Result;

            return workCollection.DeleteOneAsync(w => w.name == currentWork.name);
        }
    }
}
