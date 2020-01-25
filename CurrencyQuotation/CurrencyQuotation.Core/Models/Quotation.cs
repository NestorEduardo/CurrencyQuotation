using CurrencyQuotation.Core.Models.Abstract;
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
        public static Quotation Map(IQuotation quotation)
        {
            return new Quotation
            {
                Amount = quotation.Result.Amount,
                Quantity = quotation.Result.Quantity,
                Source = quotation.Result.Source,
                Target = quotation.Result.Target,
                Updated = quotation.Result.Updated,
                Value = quotation.Result.Value
            };
        }
    }
}
