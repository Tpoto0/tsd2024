using System;
using System.Collections.Generic;
using System.Linq;
using GoldSavings.App.Model;

namespace GoldSavings.App.Services
{
    public class GoldAnalysisService
    {
        private readonly List<GoldPrice> _goldPrices;

        public GoldAnalysisService(List<GoldPrice> goldPrices)
        {
            _goldPrices = goldPrices;
        }
        public double GetAveragePrice()
        {
            return _goldPrices.Average(p => p.Price);
        }

        public List<double> Get3BestPrices()
        {
            var orderByBest = 
                (from goldPrice in _goldPrices
                orderby goldPrice.Price descending
                select goldPrice.Price)
                .Take(3)
                .ToList();
            return orderByBest;

        }
        public List<double> Get3WorstPrices()
        {
            var orderByWorst = 
                (from goldPrice in _goldPrices
                orderby goldPrice.Price ascending
                select goldPrice.Price)
                .Take(3)
                .ToList();
            return orderByWorst;

        }
    }
}
