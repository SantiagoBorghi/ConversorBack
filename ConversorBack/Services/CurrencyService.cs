using ConversorBack.Data;
using ConversorBack.DTOs;
using ConversorBack.Entities;

namespace ConversorBack.Services
{
    public class CurrencyService
    {
        private readonly ConversorDeMonedaContext _context;
        public CurrencyService(ConversorDeMonedaContext context)
        {
            _context = context;
        }
        public void CreateCurrency(CurrencyForCreationDto dto)
        {
            Currency newCurrency = new Currency()
            {
                Code = dto.Code,
                Name = dto.Name,
                Symbol = dto.Symbol,
                IC = dto.ic
            };
            _context.Currencys.Add(newCurrency);
            _context.SaveChanges();
        }

        public void UpdateCurrency(CurrencyForUpdateDto dto)
        {
            var existingCurrency = _context.Currencys.Find(dto.Id);

            if (existingCurrency == null)
            {
                throw new Exception("Currency not found");
            }

            existingCurrency.Code = dto.Code;
            existingCurrency.Name = dto.Name;
            existingCurrency.Symbol = dto.Symbol;
            existingCurrency.IC = dto.ConvertibilityIndex;

            _context.SaveChanges();
        }

        public void DeleteCurrency(int currencyId)
        {
            var currencyToDelete = _context.Currencys.Find(currencyId);

            _context.Currencys.Remove(currencyToDelete);
            _context.SaveChanges();
        }

        public double Convert(ConvertDto dto)
        {
            double result = dto.amount * dto.ICfromConvert / dto.ICtoConvert;
            return result;
        }

        public Currency GetCurrency(int currencyID)
        {
            var currency = _context.Currencys.Find(currencyID);
            return currency;
        }
        public List<Currency> GetAllCurrencies()
        {
            return _context.Currencys.ToList();
        }


    }
}
