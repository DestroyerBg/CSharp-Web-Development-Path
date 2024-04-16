

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

        public  void Edit(string newContent)
        {
            Content= newContent;
        }
       public void ChangeAuthor(string changeAuthor)
        {
            Author= changeAuthor;
        }
       public void Rename(string rename)
        {
            Title= rename;
        }

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
                List<string> article = Console
                    .ReadLine()
                    .Split(", ")
                    .ToList();
                string title = article[0];
                string content = article[1];
                string author = article[2];
                int numberOfCommands = int.Parse(Console.ReadLine());
                Article articles = new Article(title, content, author);
                for (int i = 1; i <= numberOfCommands; i++)
                {
                    string input = Console.ReadLine();
                    string[] arguments = input.Split(": ").ToArray();
                    string activity = arguments[0];
                    if (activity == "Edit")
                    {
                        string newContent = arguments[1];
                        articles.Edit(newContent);
                    }
                    else if (activity == "ChangeAuthor")
                    {
                        string changeAuthor = arguments[1];
                        articles.ChangeAuthor(changeAuthor);
                    }
                    else if (activity== "Rename")
                    {
                        string rename = arguments[1];
                        articles.Rename(rename);
                    }
                }

                Console.WriteLine(articles.ToString());
            }

        }

    }
}