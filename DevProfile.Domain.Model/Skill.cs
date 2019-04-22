namespace DevProfile.Domain.Model
{
    public class Skill
    {
        public int Id { get; set; }
        public int TechnologyId { get; set; }
        public int StackId { get; set; }
        public int DeveloperId { get; set; }
        public Technology Technology { get; set; }
        public Stack Stack { get; set; }
        public Developer Developer { get; set; }
    }
}
