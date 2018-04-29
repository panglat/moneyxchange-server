using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyXChangeServer.Model
{
    public class CurrencyRate
    {
        [Key, ForeignKey("BaseCurrencyId")]
        public int BaseCurrencyId { get; set; }
        public virtual Currency BaseCurrency { get; set; }

        [Key, ForeignKey("ToCurrencyId")]
        public int ToCurrencyId { get; set; }
        public virtual Currency ToCurrency { get; set; }

        [RegularExpression(@"^\$?\d+(\.(\d{4}))?$")]
        public float ExchangeRate { get; set; }
    }
}
