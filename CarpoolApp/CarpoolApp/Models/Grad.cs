namespace CarpoolApp.Models
{
    public class Grad
    {
        public int GradID { get; set; }
        public string Naziv { get; set; }
        public string PostanskiBroj { get; set; }

        public int DrzavaID { get; set; }
        public Drzava Drzava { get; set; }
    }
}