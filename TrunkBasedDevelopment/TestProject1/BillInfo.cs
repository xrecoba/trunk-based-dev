namespace TestProject1;

public class BillInfo
{
    public BillInfo(Basket basket, int basePrice, int deliveryPrice, int discount, int totalPrice)
    {
        Lines = basket.Articles.Select(a => new BillLine(a.Name, a.Price, a.Quantity, discount, totalPrice));
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
        public BillLine(string article, int basePrice, int quantity, int discount, int totalPrice)
        {
            Article = article;
            BasePrice = basePrice;
            Quantity = quantity;
            Discount = discount;
            Price = totalPrice;
        }

        public string Article { get; }

        public int BasePrice { get; }
        public int Quantity { get; }

        public int Discount { get; }
        public int Price { get; set; }
    }

}