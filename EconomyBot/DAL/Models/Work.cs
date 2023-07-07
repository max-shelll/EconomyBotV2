namespace EconomyBot.DAL.Models
{
    public class Work
    {
        public Guid id = Guid.NewGuid();
        public string name { get; set; }
        public long salary { get; set; }
        public long workTime { get; set; }
    }
}
