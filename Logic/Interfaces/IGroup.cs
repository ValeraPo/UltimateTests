using System.Collections.Generic;

namespace Logic.Interfaces
{
    public interface IGroup
    {
        public long ID { get; set; }
        public List<string> Tegs { get; set; }
        public string Name { get; set; }
    }
}