using SQLiteUnity;

namespace Assets.Scripts.Database
{
    public class Entity : IEntity
    {
        [PrimaryKey, AutoIncrement]
        public virtual int Id { get; set; }
    }
}