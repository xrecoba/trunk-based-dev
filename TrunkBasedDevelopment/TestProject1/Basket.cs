namespace TestProject1;

public class Basket
{
    public Basket(params Article[] articles)
    {
        Articles = new();
        foreach (var article in articles)
        {
            Articles.Add(article);
        }
    }

    public int TotalPrice => Articles.Sum(a => a.Price);

    public List<Article> Articles { get; }
}

public class Article
{
    public Article(string name, int price)
    {
        Name = name;
        Price = price;
    }

    public int Price { get; }

    public string Name { get; }
}
