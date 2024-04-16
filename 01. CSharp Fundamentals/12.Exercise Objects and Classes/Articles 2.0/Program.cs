

namespace Articles
{
    class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }



        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            {
                int numberOfArticles = int.Parse(Console.ReadLine());
                List<Article> articlesCollection = new List<Article>();


                for (int i = 1; i <= numberOfArticles; i++)
                {
                    List<string> article = Console
                        .ReadLine()
                        .Split(", ")
                        .ToList();
                    string title = article[0];
                    string content = article[1];
                    string author = article[2];
                    Article newArticle = new Article(title, content, author);
                    articlesCollection.Add(newArticle);
                    if (i == numberOfArticles)
                    {
                        foreach (Article currArticle in articlesCollection)
                        {
                            Console.WriteLine($"{currArticle.ToString()}");
                        }

                    }

                }

            }

        }

    }
}