
namespace Request.Domain.SeedWork
{
    /// <summary>
    /// Permite definir comportamiento entre las entidades. Asi como atributos.
    /// </summary>
    public abstract class Entity
    {
        int _id;

        public virtual int Id
        {
            get
            {
                return _id;
            }
            protected set
            {
                _id = value;
            }
        }
    }
}
