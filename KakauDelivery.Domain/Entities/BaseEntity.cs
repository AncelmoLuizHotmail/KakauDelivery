namespace KakauDelivery.Domain.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            DataCreate = DateTime.Now;
            DataUpdate = null;
            IsDeleted = false;
        }

        public int Id { get; private set; }
        public DateTime DataCreate { get; private set; }
        public DateTime? DataUpdate { get; private set; }
        public bool IsDeleted { get; private set; }

        public void SetAsDeleted()
        {
            IsDeleted = true;
        }
    }
}
