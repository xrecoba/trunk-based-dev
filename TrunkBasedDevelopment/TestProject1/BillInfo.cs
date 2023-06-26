namespace TestProject1;

public class BillInfo
{
    public BillInfo(Basket basket, int basePrice, int deliveryPrice, int discount, int totalPrice)
    {
        Lines = basket.Articles.Select(a => new BillLine(a.Name, a.Price, a.Quantity, discount));
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
        public BillLine(string article, int price, int quantity, int discount)
        {
            Article = article;
            Price = price;
            Quantity = quantity;
            Discount = discount;
        }

        public string Article { get; }

        public int Price { get; }
        public int Quantity { get; }

        public int Discount { get; }
    }

}