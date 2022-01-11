using System.ComponentModel.DataAnnotations;


namespace HaberSitesi.Models.ViewModels
{
    //Kullanıcının girdiği login verilerini tutmak için kullandığımız model sınıfı,
    public class LoginModel
    {
        [Required] // Boş geçilemez demek.
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        public string ReturnUrl { get; set; } = "/"; //Default olarak / değerini veriyoruz.
    }
}
