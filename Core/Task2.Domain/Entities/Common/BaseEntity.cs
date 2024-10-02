namespace Task2.Domain.Entities.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public DateTime? DeletedDate { get; set; }

        public string? CreatedBy { get; set; }

        public string? UpdatedBy { get; set; }

        public string? DeletedBy { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
            CreatedBy = null;
            UpdatedBy = null;
            DeletedBy = null;
            DeletedDate = null;
        }

        public BaseEntity(Guid id, DateTime createdDate, DateTime updatedDate, DateTime? deletedDate, string? createdBy, string? updatedBy, string? deletedBy)
        {
            Id = id;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
            DeletedDate = deletedDate;
            CreatedBy = createdBy;
            UpdatedBy = updatedBy;
            DeletedBy = deletedBy;
        }
    }
}
