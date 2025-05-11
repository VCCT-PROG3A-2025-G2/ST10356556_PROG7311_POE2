namespace Agri_Energy_Connect.Models
{

    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public DateTime ProductionDate { get; set; }
        public int FarmerId { get; set; }
    }
}

