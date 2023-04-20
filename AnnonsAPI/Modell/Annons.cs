using System.ComponentModel.DataAnnotations;

namespace AnnonsAPI.Modell
{
    public class Annons
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductType { get; set; } = string.Empty;
        public decimal? Price { get; set; }
        public DateTime CreatedDateTime { get; set; }

    }
}
