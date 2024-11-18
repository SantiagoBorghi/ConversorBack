namespace ConversorBack.DTOs
{
    public class CurrencyForCreationDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; } = "$";
        public double ic { get; set; }
    }
}
