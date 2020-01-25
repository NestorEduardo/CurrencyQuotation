using System;

namespace CurrencyQuotation.Core.Models
{
    public class Quotation
    {
        public DateTime Updated { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
        public double Value { get; set; }
        public double Quantity { get; set; }
        public double Amount { get; set; }
    }
}


