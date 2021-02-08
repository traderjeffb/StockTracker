using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Data
{
    public class Trade
    {
        [Key]
        public int TradeId { get; set; }
        [Required]
        public string Ticker { get; set; }
        [Required]
        public decimal TradeEntryPrice { get; set; }
        public decimal TradeExitPrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal OpenProfit { get; set; }
        public decimal ClosedProfit { get; set; }
        public DateTime TradeEntryDate { get; set; }
        public DateTime TradeExitDate { get; set; }
        public int NumberOfDaysInTrade { get; set; }
        public decimal ProfitPerDay { get; set; }
        public decimal ReturnOnCapital { get; set; }
    }
}
