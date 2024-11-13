using System.ComponentModel.DataAnnotations.Schema;

namespace EfCore.Relationships.Youtube.Models
{
    public sealed class UserInformation
    {
        public UserInformation()
        {
            Id = Guid.NewGuid();

        }

        public Guid Id { get; set; }    //User Tablosounda UserInformationId ye eşit dir

        //[ForeignKey("UserId")]
        //public Guid UserId { get; set; }
        public string IdentityNumber { get; set; } = default!;
        public string FullAddress { get; set; } = default!;

        //#region NavigationProperty
        //public  User? User { get; set; }
        //#endregion

    }
}
