using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace CrazyMusiciansApi.Models
{
    public class Musicians
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, MinimumLength =3, ErrorMessage="Name need to be between 3 and 100 character.")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Profession is invalid.")]
        [RegularExpression("^(Ünlü Çalgı Çalar|Popüler Melodi Yazarı|Çılgın Akorist|Sürpriz Nota Üreticisi|Ritim Canavarı|Armoni Ustası|Perde Uygulayıcı|Rezonans Uzmanı|Tonlama Meraklısı|Akor Sihirbazı)$", ErrorMessage = "Invalid entered.")] //Alternative options.
        public string Profession { get; set; } = "";

        [Required(ErrorMessage ="Please enter a fun feature.")]
        public string FunFeature { get; set; } = "";


    }
}
