namespace NetArchHackaton.Shared.Domain
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updated { get; set; }
    }
}
