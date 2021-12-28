namespace Logic.Interfaces
{
    public interface IUser
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string Hash { get; set; }
        public long ID { get; set; }
        public string Email { get; set; }

    }
}