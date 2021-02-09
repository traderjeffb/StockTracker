using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Models
{
    public class TradeCreate
    {
        [Required]
        public string Ticker { get; set; }

        [Display(Name = "Entry Price")]
        public decimal TradeEntryPrice { get; set; }

        [Display(Name = "Current Price")]
        public decimal CurrentPrice { get; set; }

        [Display(Name = "Entry Date")]
        public DateTime TradeEntryDate { get; set; }

    }
}


