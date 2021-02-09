using StockTracker.Data;
using StockTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Services
{
    public class TradeService
    {
        private readonly Guid _userId;

        public TradeService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTrade(TradeCreate model)
        {
            var entity =
                new Trade()
                {
                    OwnerId = _userId,
                    Ticker = model.Ticker,
                    TradeEntryPrice = model.TradeEntryPrice,
                    CurrentPrice = model.CurrentPrice,
                    TradeEntryDate = model.TradeEntryDate,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Trades.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TradeListItem> GetTrades()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Trades
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new TradeListItem
                                {
                                    TradeId = e.TradeId,
                                    Ticker = e.Ticker,
                                    TradeEntryPrice = e.TradeEntryPrice,
                                    TradeExitPrice = e.TradeExitPrice,
                                    CurrentPrice = e.CurrentPrice,
                                    OpenProfit = e.OpenProfit,
                                    ClosedProfit = e.ClosedProfit,
                                    TradeEntryDate = e.TradeEntryDate,
                                    TradeExitDate = e.TradeExitDate,
                                    NumberOfDaysInTrade = e.NumberOfDaysInTrade,
                                    ProfitPerDay = e.ProfitPerDay,
                                    ReturnOnCapital = e.ProfitPerDay
                                }
                        );

                return query.ToArray();
            }
        }

        public TradeDetail GetTradeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Trades
                        .Single(e => e.TradeId == id && e.OwnerId == _userId);
                return
                    new TradeDetail
                    {
                        TradeId = entity.TradeId,
                        Ticker = entity.Ticker,
                        TradeEntryPrice = entity.TradeEntryPrice,
                        TradeExitPrice = entity.TradeExitPrice,
                        CurrentPrice = entity.CurrentPrice,
                        OpenProfit = entity.OpenProfit,
                        ClosedProfit = entity.ClosedProfit,
                        TradeEntryDate = entity.TradeEntryDate,
                        TradeExitDate = entity.TradeExitDate,
                        NumberOfDaysInTrade = entity.NumberOfDaysInTrade,
                        ProfitPerDay = entity.ProfitPerDay,
                        ReturnOnCapital = entity.ProfitPerDay

                    };
            }

        }
    }
}
