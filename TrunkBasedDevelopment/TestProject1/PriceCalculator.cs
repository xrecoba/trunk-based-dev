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
        var fragilityCharge = basket.Articles.Any(a => a.IsFragile) ? 10 : 0;

        if (country == "Sweden")
            return 5 + fragilityCharge;

        if (basket.TotaPrice < 50)
        {
            return 10 + fragilityCharge;
        }

        return 0 + fragilityCharge;
    }
}