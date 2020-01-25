using CurrencyQuotation.Core.Models.Abstract;

namespace CurrencyQuotation.Core.Models
{
    public class QuotationRootObject : IQuotation
    {
        public Quotation Result { get; set; }
        public string Status { get; set; }
    }
}
