namespace EconomyBot.DAL.Models
{
    public class User
    {
        public ulong id { get; set; }
        public long money { get; set; }
        public List<Role> roles { get; set; }
        public Work work { get; set; }
    }
}
