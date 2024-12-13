using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebUygulamaProje1.Models
{
    public class KitapTuru
    {
        [Key]//Id Primary key olur 
        public int Id { get; set; }


        [Required(ErrorMessage ="Kitap Tür Adı boş bırakılamaz!")]//Ad değişkeni not null olarak ayarlandı
        [MaxLength(25)]//Girilebilecek maks karakter sınırı
        [DisplayName("Kitap Türü Adı:")]//Ad Labeli kullanıldığında bu gözükür
        public string Ad { get; set; }
    }
}
