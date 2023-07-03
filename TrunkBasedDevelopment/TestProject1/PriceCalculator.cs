namespace TestProject1;

public class PriceCalculator
{
    public BillInfo GetPriceOf(Basket basket, string country)
    {
        var basePriceFor = BasePriceFor(basket);
        var deliveryPriceFor = DeliveryPriceFor(basket, country);
        return new BillInfo(basket,
            basePriceFor,
            deliveryPriceFor,
            basePriceFor + deliveryPriceFor);
    }

    public int BasePriceFor(Basket basket)
    {
        return basket.Articles.Sum(a => a.Price);
    }

    private int DeliveryPriceFor(Basket basket, string country)
    {
        if (country == "Sweden")
            return 5;

        if (basket.TotalPrice < 50)
        {
            return 10;
        }

        if (basket.Articles.Any(a => a.IsFragile))
        {
            return 10;
        }

        return 0;
    }
}