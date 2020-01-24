using System.Runtime.Serialization;

namespace CurrencyQuotation.Core.Models
{
    public class Quotation
    {
        public string Amount { get; set; }

        public decimal Price { get; set; }
    }
}


