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
        var baseResult = 0;
        if (basket.Articles.Any(a => a.IsFragile))
        {
            baseResult = 10;
        }

        if (country == "Sweden")
            return baseResult + 5;

        if (basket.TotalPrice < 50)
        {
            return baseResult + 10;
        }

        return baseResult;
    }
}