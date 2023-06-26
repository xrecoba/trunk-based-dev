using System;
using System.Diagnostics;
using System.Text;

namespace TestProject1
{
    [UsesVerify]
    public class DeliveryCostTests
    {

        [Fact]
        public Task DenmarkIsFreeIfPriceHigherThan50()
        {
            var priceCalculator = new PriceCalculator();
            var basket = new Basket(new Article("Expensive article", 500));

            var billInfo = priceCalculator.GetPriceOf(basket, "Denmark");

            string printedBillInfo = BillPrinter.Print(billInfo);

            return Verify(printedBillInfo);
        }

        [Fact]
        public Task DenmarkIs10IfPriceLowerOrEqualThan50()
        {
            var priceCalculator = new PriceCalculator();
            var basket = new Basket(new Article("Cheap article", 49));

            var billInfo = priceCalculator.GetPriceOf(basket, "Denmark");

            string printedBillInfo = BillPrinter.Print(billInfo);

            return Verify(printedBillInfo);
        }

        [Fact]
        public Task SwedenDeliveryCostIs5NoMatterWhat()
        {
            var priceCalculator = new PriceCalculator();
            var basket = new Basket(new Article("Cheap toy", 19),
                new Article("Another cheap toy", 15));
            
            var billInfo = priceCalculator.GetPriceOf(basket, "Sweden");

            string printedBillInfo = BillPrinter.Print(billInfo);

            return Verify(printedBillInfo);
        }
    }

    public class BillPrinter
    {
        public string Print(BillInfo billInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Lines:");
            foreach (var line in billInfo.Lines)
            {
                sb.AppendLine($"\t{line.Article} - {line.Price}$");
            }
            sb.AppendLine($"Base price: {billInfo.BasePrice}$");
            sb.AppendLine($"Delivery cost: {billInfo.DeliveryPrice}$");
            sb.AppendLine();
            sb.AppendLine($"Total: {billInfo.TotalPrice}$");

            return sb.ToString();
        }
    }

}