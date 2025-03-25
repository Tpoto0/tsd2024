using GoldSavings.App.Model;
using GoldSavings.App.Client;
using GoldSavings.App.Services;
using System.Xml.Linq;
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

        Console.WriteLine("\nNew step : 2b");

        // Step 1: Get gold prices
        DateTime startDate2 = new DateTime(2020,01,01);
        DateTime endDate2 = new DateTime(2020,04,01);
        List<GoldPrice> goldPrices2 = dataService.GetGoldPrices(startDate2, endDate2).GetAwaiter().GetResult();

        if (goldPrices2.Count == 0)
        {
            Console.WriteLine("No data found. Exiting.");
            return;
        }

        Console.WriteLine($"Retrieved {goldPrices2.Count} records. Ready for analysis.");

        // Step 2: Perform analysis
        GoldAnalysisService analysisService2 = new GoldAnalysisService(goldPrices2);
        var LowestValue = analysisService2.Get3WorstPrices()[0];

        // Step 3: Print results
        GoldResultPrinter.PrintSingleValue(Math.Round(LowestValue, 2), "price at lowest");

        double IncreasePourcent = 0;

        foreach (var goldPriceToday in goldPrices2)
        {
            IncreasePourcent = analysisService2.IncreaseCalculator(LowestValue, goldPriceToday.Price);
            if (IncreasePourcent >= 5)
            {
                Console.WriteLine("The "+ goldPriceToday.Date +", potential gain : " + Math.Round(IncreasePourcent, 2) +  "%");
            }
        }

        Console.WriteLine("\nNew step : 2c");

        // Step 1: Get gold prices
        DateTime startDate2019 = new DateTime(2019,01,01);
        DateTime endDate2019 = new DateTime(2019,12,31);
        DateTime startDate2020 = new DateTime(2020,01,01);
        DateTime endDate2020 = new DateTime(2020,12,31);
        DateTime startDate2021 = new DateTime(2021,01,01);
        DateTime endDate2021 = new DateTime(2021,12,31);
        DateTime startDate2022 = new DateTime(2022,01,01);
        DateTime endDate2022 = new DateTime(2022,12,31);
        List<GoldPrice> goldPrices2019 = dataService.GetGoldPrices(startDate2019, endDate2019).GetAwaiter().GetResult();
        List<GoldPrice> goldPrices2020 = dataService.GetGoldPrices(startDate2020, endDate2020).GetAwaiter().GetResult();
        List<GoldPrice> goldPrices2021 = dataService.GetGoldPrices(startDate2021, endDate2021).GetAwaiter().GetResult();
        List<GoldPrice> goldPrices2022 = dataService.GetGoldPrices(startDate2022, endDate2022).GetAwaiter().GetResult();

        List<GoldPrice> goldPrices2019to2022 = goldPrices2019
        .Concat(goldPrices2020)
        .Concat(goldPrices2021)
        .Concat(goldPrices2022)
        .ToList();

        if (goldPrices2019to2022.Count == 0)
        {
            Console.WriteLine("No data found. Exiting.");
            return;
        }

        Console.WriteLine($"Retrieved {goldPrices2019to2022.Count} records. Ready for analysis.");

        // Step 2: Perform analysis
        GoldAnalysisService analysisService2c = new GoldAnalysisService(goldPrices2019to2022);
        var BestPrices2c = analysisService2c.Get13BestPrices();

        // Step 3: Print results
        for (int i=0; i<3; i++){
            GoldResultPrinter.PrintSingleValue(Math.Round(BestPrices2c[10+i], 2), "price of 3 bests of the 2nd top 10");
        }

        Console.WriteLine("\nNew step : 2d");

        // Step 1: Get gold prices
        DateTime startDate2023 = new DateTime(2023,01,01);
        DateTime endDate2023 = new DateTime(2023,12,31);
        DateTime startDate2024 = new DateTime(2024,01,01);
        DateTime endDate2024 = new DateTime(2024,12,31);
        List<GoldPrice> goldPrices2023 = dataService.GetGoldPrices(startDate2023, endDate2023).GetAwaiter().GetResult();
        List<GoldPrice> goldPrices2024 = dataService.GetGoldPrices(startDate2024, endDate2024).GetAwaiter().GetResult();

        int goldPrices2020_2023_2024 = goldPrices2020.Count + goldPrices2023.Count + goldPrices2024.Count;

        if (goldPrices2020_2023_2024 == 0)
        {
            Console.WriteLine("No data found. Exiting.");
            return;
        }

        Console.WriteLine($"Retrieved {goldPrices2020_2023_2024} records. Ready for analysis.");

        // Step 2: Perform analysis
        GoldAnalysisService analysisService2020 = new GoldAnalysisService(goldPrices2020);
        GoldAnalysisService analysisService2023 = new GoldAnalysisService(goldPrices2023);
        GoldAnalysisService analysisService2024 = new GoldAnalysisService(goldPrices2024);
        var avgPrice2020 = analysisService2020.GetAveragePrice();
        var avgPrice2023 = analysisService2023.GetAveragePrice();
        var avgPrice2024 = analysisService2024.GetAveragePrice();

        // Step 3: Print results
        GoldResultPrinter.PrintSingleValue(Math.Round(avgPrice2020, 2), "Average gold prices of 2020");
        GoldResultPrinter.PrintSingleValue(Math.Round(avgPrice2023, 2), "Average gold prices of 2023");
        GoldResultPrinter.PrintSingleValue(Math.Round(avgPrice2024, 2), "Average gold prices of 2024");

         Console.WriteLine("\nNew step : 2e");

        // Step 1: Get gold prices
        List<GoldPrice> goldPrices2020to2024 = goldPrices2020
        .Concat(goldPrices2021)
        .Concat(goldPrices2022)
        .Concat(goldPrices2023)
        .Concat(goldPrices2024)
        .ToList();

        if (goldPrices2020to2024.Count == 0)
        {
            Console.WriteLine("No data found. Exiting.");
            return;
        }

        Console.WriteLine($"Retrieved {goldPrices2020to2024.Count} records. Ready for analysis.");

        // Step 2: Perform analysis
        GoldAnalysisService analysisService2e = new GoldAnalysisService(goldPrices2020to2024);
        var LowestValue2020_2024 = analysisService2e.Get3WorstPrices()[0];
        var HighestValue2020_2024 = analysisService2e.Get3BestPrices()[0];

        // Step 3: Print results
        GoldResultPrinter.PrintSingleValue(Math.Round(LowestValue2020_2024, 2), "Lowest gold prices between 2020 and 2024");
        GoldResultPrinter.PrintSingleValue(Math.Round(HighestValue2020_2024, 2), "Highest gold prices between 2020 and 2024");


        Console.WriteLine("\nGold Analyis Queries with LINQ Completed.");

        string filePath = "GoldAnalysisResults.xml";
        analysisService.SaveResultsToXml(filePath, BestPrices2c, WorstPrices);

        Console.WriteLine($"Results saved to {filePath}");

        XDocument xmlDocument = ReadResultsFromXml(filePath);
        Console.WriteLine(xmlDocument);

        // Modifications for question 5
    }

    public static XDocument ReadResultsFromXml(string filePath) => XDocument.Load(filePath);
}
