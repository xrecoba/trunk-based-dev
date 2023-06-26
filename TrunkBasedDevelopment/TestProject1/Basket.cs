namespace TestProject1;

public class Basket
{
    private readonly List<Article> _articles;

    public Basket(params Article[] articles)
    {
        _articles = new();
        foreach (var article in articles)
        {
            _articles.Add(article);
        }
    }

    public int TotaPrice
    {
        get => Articles.Sum(a => a.Price);
    }

    public List<Article> Articles => _articles;

    public void Add(Article article)
    {
        Articles.Add(article);
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
