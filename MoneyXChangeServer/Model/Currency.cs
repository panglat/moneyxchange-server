using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyXChangeServer.Model
{
    public class Currency
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Code is required")]
        [StringLength(3, ErrorMessage = "Code can't be longer than 3 characters")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name can't be longer than 50 characters")]
        public string Name { get; set; }

        [ForeignKey("BaseCurrencyId")]
        public ICollection<CurrencyRate> Rates { get; set; }
    }
}
