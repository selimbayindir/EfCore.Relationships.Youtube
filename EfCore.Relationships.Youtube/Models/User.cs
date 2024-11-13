using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        //[ForeignKey("UserInformationId")]
        public object Information => new 
        {
            InfoId = UserInformationId,
            IdentityNumber = UserInformation?.IdentityNumber,
            FullAddress = UserInformation.FullAddress,
        };
        [JsonIgnore]
        public Guid UserInformationId { get; set; }  //İLİŞKİ BU PROP ÜZERİNDEN SAĞLANIYOR
        #region Navigation Property
        [JsonIgnore]
        public UserInformation? UserInformation { get; set; }

        #endregion
        

    }
}
