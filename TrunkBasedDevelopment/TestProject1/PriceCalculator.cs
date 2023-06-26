namespace TestProject1;

public class PriceCalculator
{

    public BillInfo GetPriceOf(Basket basket, string country)
    {
        var basePriceFor = BasePriceFor(basket);
        var deliveryPriceFor = DeliveryPriceFor(basePriceFor, country);
        var totalBeforeDiscount = basePriceFor + deliveryPriceFor;
        var discount = discountFor(totalBeforeDiscount);
        var total = totalBeforeDiscount - discount;
        return new BillInfo(basket,
            basePriceFor,
            deliveryPriceFor,
            discount,
            total);
    }

    private int discountFor(int total)
    {
        if (total > 100)
        {
            return (int)(total * 0.1);
        }

        return 0;
    }

    public int BasePriceFor(Basket basket)
    {
        return basket.Articles.Sum(a => a.Price);
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