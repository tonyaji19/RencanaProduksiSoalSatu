namespace RencanaProduksiSoalSatu.Models
{
    public class ProductionPlan
    {
        public int Monday { get; set; }
        public int Tuesday { get; set; }
        public int Wednesday { get; set; }
        public int Thursday { get; set; }
        public int Friday { get; set; }

        public bool ProduksiTerhitung { get; set; }
    }
}
