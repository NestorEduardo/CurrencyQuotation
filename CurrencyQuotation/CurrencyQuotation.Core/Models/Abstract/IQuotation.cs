using System;

namespace CurrencyQuotation.Core.Models.Abstract
{
    public interface IQuotation
    {
        public Quotation Result { get; set; }
        public string Status { get; set; }
    }
}


