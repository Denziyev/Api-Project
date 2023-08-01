namespace WebApplication1.Core.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreadetAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
