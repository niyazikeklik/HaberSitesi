using System.ComponentModel.DataAnnotations;

namespace HaberSitesi.Models
{
    //Kategorileri tutan enum (çok önemli değil)
    public enum Kategoriler
    {
        Ekonomi=0,
        Siyaset=1,
        Yaşam=2,
        Dünya=3,
        Teknoloji=4,
        Spor=5,
    }
    //Haber modeli.

    public class Haber
    {
        [Key]//HaberID sutununun primarykey olduğunu söylüyor.
        public int HaberID { get; set; }
        public string Baslik { get; set; }
        public string Detay { get; set; }
        public string FotoURL { get; set; }
        public Kategoriler Kategori { get; set; }
    }
}
