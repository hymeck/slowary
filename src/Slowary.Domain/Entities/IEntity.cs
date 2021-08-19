namespace Slowary.Domain.Entities
{
    // todo: add constraint for key?
    /// <summary>
    /// Describes a class that has a unique identifier.
    /// </summary>
    /// <typeparam name="TKey">ID type</typeparam>
    public interface IEntity<TKey>
    {
        /// <summary>
        /// Gets or sets id
        /// </summary>
        /// <typeparam name="TKey">ID type</typeparam>
        public TKey Id { get; set; }
    }
}