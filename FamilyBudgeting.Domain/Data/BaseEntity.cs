namespace FamilyBudgeting.Domain.Data
{
    public class BaseEntity
    {
        public int Id { get; init; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
    }
}
