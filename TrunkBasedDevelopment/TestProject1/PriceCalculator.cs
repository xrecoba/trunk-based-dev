namespace TestProject1;

public class PriceCalculator
{

    public BillInfo GetPriceOf(Basket basket, string country)
    {
        var basePriceFor = BasePriceFor(basket);
        var deliveryPriceFor = DeliveryPriceFor(basket, country);
        bool hasFragilitySurcharge = HasFacilitySurcharge(basket);
        return new BillInfo(basket,
            basePriceFor,
            deliveryPriceFor,
            hasFragilitySurcharge,
            basePriceFor + deliveryPriceFor);
    }

    public int BasePriceFor(Basket basket)
    {
        return basket.Articles.Sum(a => a.Price);
    }

    private int DeliveryPriceFor(Basket basket, string country)
    {
        var fragilityCharge = HasFacilitySurcharge(basket) ? 10 : 0;

        if (country == "Sweden")
            return 5 + fragilityCharge;

        if (basket.TotaPrice < 50)
        {
            return 10 + fragilityCharge;
        }

        return 0 + fragilityCharge;
    }

    private static bool HasFacilitySurcharge(Basket basket)
    {
        return basket.Articles.Any(a => a.IsFragile);
    }
}