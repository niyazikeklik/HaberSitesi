using System.ComponentModel.DataAnnotations;

namespace HaberSitesi.Models
{
    public class Hesap
    {
        [Key]
        public string UserID { get; set; }
        public string Mail { get; set; }
        public string Pass { get; set; }
    
    }
}
