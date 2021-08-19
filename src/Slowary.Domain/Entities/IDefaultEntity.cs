namespace Slowary.Domain.Entities
{
    /// Describes a class that has a unique unsigned 64-bit integer identifier. 
    public interface IDefaultEntity : IEntity<ulong>
    {
    }
}