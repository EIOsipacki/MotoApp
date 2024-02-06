
namespace MotoApp.Entities
{
    public abstract class EntityBase: IEntity
    {
        public int Id { get; set; }
        //public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
