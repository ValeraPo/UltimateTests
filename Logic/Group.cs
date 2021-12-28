using System.Collections.Generic;
using Logic.Interfaces;

namespace Logic
{
    public class Group : IGroup
    {
        public long ID { get; set; }
        public List<string> Tegs { get; set; }
        public string Name { get; set; }
    }
}