using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Entities
{
    public class Money : EntityBase
    {
        private decimal? _amount;
        private Currency _currency;

        public decimal? Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
                HasChanges = true;
            }
        }
        public Currency Currency
        {
            get
            {
                return _currency;
            }
            set
            {
                _currency = value;
                HasChanges = true;
            }
        }

        public static Dictionary<KeyValuePair<Currency, Currency>, decimal> ConversionTable { get; } = new()
        {
            { new(Currency.EUR, Currency.USD), 1.19m },
            { new(Currency.UAH, Currency.USD), 0.036m },
            { new(Currency.RUR, Currency.USD), 0.013m },

            { new(Currency.USD, Currency.EUR), 0.84m },
            { new(Currency.UAH, Currency.EUR), 0.03m },
            { new(Currency.RUR, Currency.EUR), 0.011m },

            { new(Currency.USD, Currency.UAH), 27.75m },
            { new(Currency.EUR, Currency.UAH), 33.07m },
            { new(Currency.RUR, Currency.UAH), 0.37m },

            { new(Currency.USD, Currency.RUR), 74.35m },
            { new(Currency.EUR, Currency.RUR), 88.59m },
            { new(Currency.UAH, Currency.RUR), 2.68m }
        };

        public void ConvertTo(Currency thatCurrency)
        {
            if (this.Currency != thatCurrency)
            {
                KeyValuePair<Currency, Currency> pair = new(this.Currency, thatCurrency);
                decimal coef = ConversionTable.GetValueOrDefault(pair);
                this.Amount *= coef;
                this.Currency = thatCurrency;
            }
        }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
