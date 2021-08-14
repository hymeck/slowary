namespace Slowary.Domain.Entities
{
    // todo: add constraint for key?
    public interface IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}