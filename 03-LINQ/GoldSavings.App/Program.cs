using GoldSavings.App.Model;
using GoldSavings.App.Client;
using GoldSavings.App.Services;
namespace GoldSavings.App;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, Gold Investor!");

        // Step 1: Get gold prices
        GoldDataService dataService = new GoldDataService();
        DateTime startDate = new DateTime(2024,01,01); //new DateTime(2024,09,18);
        DateTime endDate = new DateTime(2024,12,31);
        List<GoldPrice> goldPrices = dataService.GetGoldPrices(startDate, endDate).GetAwaiter().GetResult();

        if (goldPrices.Count == 0)
        {
            Console.WriteLine("No data found. Exiting.");
            return;
        }

        Console.WriteLine($"Retrieved {goldPrices.Count} records. Ready for analysis.");

        // Step 2: Perform analysis
        GoldAnalysisService analysisService = new GoldAnalysisService(goldPrices);
        var avgPrice = analysisService.GetAveragePrice();
        var BestPrices = analysisService.Get3BestPrices();
        var WorstPrices = analysisService.Get3WorstPrices();

        // Step 3: Print results
        GoldResultPrinter.PrintSingleValue(Math.Round(avgPrice, 2), "Average Gold Price Last Half Year");

        foreach (var Prices in BestPrices){
            GoldResultPrinter.PrintSingleValue(Math.Round(Prices, 2), "price");

        }
        foreach (var Prices in WorstPrices){
            GoldResultPrinter.PrintSingleValue(Math.Round(Prices, 2), "price");

        }

        Console.WriteLine("New step : 2b");

        // Step 1: Get gold prices
        DateTime startDate2 = new DateTime(2020,01,01);
        DateTime endDate2 = DateTime.Now;
        List<GoldPrice> goldPrices2 = dataService.GetGoldPrices(startDate2, endDate2).GetAwaiter().GetResult();

        if (goldPrices2.Count == 0)
        {
            Console.WriteLine("No data found. Exiting.");
            return;
        }

        Console.WriteLine($"Retrieved {goldPrices2.Count} records. Ready for analysis.");

        // Step 2: Perform analysis
        GoldAnalysisService analysisService2 = new GoldAnalysisService(goldPrices2);
        var LowestValue = WorstPrices[0];

        // Step 3: Print results
        GoldResultPrinter.PrintSingleValue(Math.Round(LowestValue, 2), "price at lowest");



        Console.WriteLine("\nGold Analyis Queries with LINQ Completed.");

    }
}
