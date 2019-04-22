namespace DevProfile.Domain.Model
{
    public class Skill
    {
        public int Id { get; set; }
        public int IdTechnology { get; set; }
        public int IdStack { get; set; }
        public int IdDeveloper { get; set; }
        public Technology Technology { get; set; }
        public Stack Stack { get; set; }
        public Developer Developer { get; set; }
    }
}
