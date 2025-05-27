using SQLite;

namespace appProvaA1Barco.DTO
{
    public class Barco
    {
        [PrimaryKey, AutoIncrement, Unique, NotNull]
        public int BarID { get; set; }
        [MaxLength(1500)]
        public string? BarNome { get; set; }
        [MaxLength(6)]
        public double BarPeso { get; set; }
    }
}
