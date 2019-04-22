using System.Collections.Generic;

namespace DevProfile.Domain.Model
{
    public class Developer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Skill> Skills { get; set; }
    }
}
