﻿namespace Logic
{
    public interface IUser
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string Hash { get; set; }
        public string ID { get; set; }

    }
}