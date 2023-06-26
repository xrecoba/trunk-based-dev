namespace TestProject1
{


    public class UnitTest1
    {
        [Fact]
        public void DenmarkIsFreeIfPriceHigherThan50()
        {
            var priceCalculator = new PriceCalculator();
            var basket = new Basket(new Article("Expensive stuff", 500));
            var price = priceCalculator.PriceFor(basket, "Denmark");
            Assert.Equal(0, price);
        }

        [Fact]
        public void DenmarkIs10IfPriceLowerOrEqualThan50()
        {
            var priceCalculator = new PriceCalculator();
            var basket = new Basket(new Article("Cheap toy", 49));
            var price = priceCalculator.PriceFor(basket, "Denmark");
            Assert.Equal(10, price);
        }

        [Fact]
        public void SwedenIs5NoMatterWhat()
        {
            var priceCalculator = new PriceCalculator();
            var basket = new Basket(new Article("Cheap toy", 49));
            var price = priceCalculator.PriceFor(basket, "Sweden");
            Assert.Equal(5, price);
        }
    }

    public class PriceCalculator
    {
        public int PriceFor(Basket basket, string country)
        {
            if (country == "Sweden")
                return 5;

            if (basket.TotaPrice < 50)
            {
                return 10;
            }
            return 0;
        }
    }

    public class Basket
    {
        private readonly List<Article> _articles;

        public Basket(Article article)
        {
            _articles = new()
            {
                article
            };

        }

        public int TotaPrice
        {
            get => _articles.Sum(a => a.Price);
        }

        public void Add(Article article)
        {
            _articles.Add(article);
        }
    }

    public class Article
    {
        private readonly string _name;
        private readonly int _price;

        public Article(string name, int price)
        {
            _name = name;
            _price = price;
        }

        public int Price => _price;

        public string Name => _name;
    }
}