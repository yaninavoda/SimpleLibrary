namespace SimpleLibrary
{
    public class BaseEntity : IEntity
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
