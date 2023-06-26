namespace TestProject1;

public class PriceCalculator
{

    public BillInfo GetPriceOf(Basket basket, string country)
    {
        var basePriceFor = BasePriceFor(basket);
        var deliveryPriceFor = DeliveryPriceFor(basePriceFor, country);
        return new BillInfo(basket,
            basePriceFor,
            deliveryPriceFor,
            basePriceFor + deliveryPriceFor);
    }

    public int BasePriceFor(Basket basket)
    {
        return basket.Articles.Sum(a => a.Price * a.Quantity);
    }

    private int DeliveryPriceFor(int price, string country)
    {
        if (country == "Sweden")
            return 5;

        if (price < 50)
        {
            return 10;
        }

        return 0;
    }
}