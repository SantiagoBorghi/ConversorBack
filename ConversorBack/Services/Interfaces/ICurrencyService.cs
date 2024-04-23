using ConversorBack.DTOs;
using ConversorDeMonedaBackEnd2.Entities;

namespace ConversorBack.Services.Interfaces
{
    public interface ICurrencyService
    {
        void CreateCurrency(CurrencyForCreationDto dto);
        void UpdateCurrency(int currencyId, CurrencyForCreationDto dto);
        void DeleteCurrency(int currencyId);
        double Convert(double amount, ConvertDto dto);
    }
}
