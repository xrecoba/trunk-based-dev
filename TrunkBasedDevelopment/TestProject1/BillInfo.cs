namespace TestProject1;

public class BillInfo
{
    public BillInfo(Basket basket, int basePrice, int deliveryPrice, int totalPrice)
    {
        Lines = basket.Articles.Select(a => new BillLine(a.Name, a.Price));
        BasePrice = basePrice;
        DeliveryPrice = deliveryPrice;
        TotalPrice = totalPrice;
    }

    public IEnumerable<BillLine> Lines { get; }

    public int BasePrice { get; }
    public int DeliveryPrice { get; }
    public int TotalPrice { get; }

    public class BillLine
    {
        public BillLine(string article, int price)
        {
            Article = article;
            Price = price;
        }

        public string Article { get; }

        public int Price { get; }
    }

}