using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Models
{
    public class TradeListItem
    {
        public int TradeId { get; set; }
        public string Ticker { get; set; }

        [Display(Name="Entry")]
        public decimal TradeEntryPrice { get; set; }

        [Display(Name ="Exit")]
        public decimal TradeExitPrice { get; set; }

        [Display(Name ="Price")]
        public decimal CurrentPrice { get; set; }

        [Display(Name = "Open Profit")]
        public decimal OpenProfit { get; set; }

        [Display(Name ="Closed Profit")]
        public decimal ClosedProfit { get; set; }

        [Display(Name ="Entry")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime TradeEntryDate { get; set; }

        [Display(Name ="Exit")]
        public DateTime? TradeExitDate { get; set; }

        [Display(Name ="Days")]
        public int NumberOfDaysInTrade { get; set; }

        [Display(Name ="Daily Profit")]
        public decimal ProfitPerDay { get; set; }

        [Display(Name ="ROC")]
        public decimal ReturnOnCapital { get; set; }
    }
}
