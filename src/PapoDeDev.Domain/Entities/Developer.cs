namespace PapoDeDev.Domain.Entities
{
    public sealed class Developer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Company { get; set; }
    }
}
