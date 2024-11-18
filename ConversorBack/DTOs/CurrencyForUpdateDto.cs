using System.ComponentModel.DataAnnotations;

namespace ConversorBack.DTOs
{
    public class CurrencyForUpdateDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; } = "$";
        public double ConvertibilityIndex { get; set; }
    }
}
