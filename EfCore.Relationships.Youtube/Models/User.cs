namespace EfCore.Relationships.Youtube.Models
{
    public sealed class User
    {
        public User() { 
        Id = Guid.NewGuid();

        }
        public Guid Id { get; set; }
        public string FirstName { get; set; } /*= string.Empty;*/ = default!;  //default kullanırsa 
        public string LastName { get; set; } /*= string.Empty;*/ = default!;
        public string FullName =>string.Join(",", FirstName,LastName);
        public Guid UserInformationId { get; set; }

    }

    public sealed class UserInformation
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string IdentityNumber { get; set; } = default!;
        public string FullAddress { get; set; } = default!;

    }
}
