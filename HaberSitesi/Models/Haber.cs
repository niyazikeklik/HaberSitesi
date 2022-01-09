using System.ComponentModel.DataAnnotations;

namespace HaberSitesi.Models
{
    public enum Kategoriler
    {
        Ekonomi=0,
        Siyaset=1,
        Yaşam=2,
        Dünya=3,
        Teknoloji=4,
        Spor=5,
    }
    public class Haber
    {
        [Key]
        public int HaberID { get; set; }
        public string Baslik { get; set; }
        public string Detay { get; set; }
        public string FotoURL { get; set; }
        public Kategoriler Kategori { get; set; }
    }
}
