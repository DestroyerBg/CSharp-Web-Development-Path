using System.Text;
using BookShop.Models.Enums;

namespace BookShop
{
    using BookShop.Models;
    using Data;
    using Initializer;
    using static System.Reflection.Metadata.BlobBuilder;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);
            //Console.WriteLine(GetBooksReleasedBefore(db, "12-04-1992"));

            string output = GetMostRecentBooks(db);
            Console.WriteLine(output);
        }

        //02

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var result = Enum.Parse<AgeRestriction>(command,true);
            var books = context.Books.Where(b => b.AgeRestriction == result)
                .Select(b => b.Title)
                .ToArray()
                .OrderBy(b => b);

            return string.Join(Environment.NewLine, books);
        }
        //03

        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                    .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                    .Select(b => new {b.Title, b.BookId})
                    .OrderBy(b => b.BookId)
                    .ToArray();

            return string.Join(Environment.NewLine, books.Select(b => b.Title));

        }
        //04

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new { b.Title, b.Price })
                .OrderByDescending(b => b.Price)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //05

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books.Where(b => b.ReleaseDate.Value.Year < year 
                                                 || b.ReleaseDate.Value.Year > year)
                .Select(b => new {b.Title, b.BookId})
                .OrderBy(b => b.BookId)
                .ToArray();

            return string.Join(Environment.NewLine, books.Select(b => b.Title));
        }

        //06

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var books = context.Books.Where(b => b.BookCategories
                    .Any(c => categories.Contains(c.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        //07

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime currDate = DateTime.ParseExact(date, "dd-MM-yyyy", null);

            var books = context.Books
                .Where(b => b.ReleaseDate < currDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(book => $"{book.Title} - {book.EditionType.ToString()} - ${book.Price:f2}")
                .ToArray();

            return string.Join(Environment.NewLine, books);

        }

        //08

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors.Where(a => a.FirstName.EndsWith(input))
                .Select(a => $"{a.FirstName} {a.LastName}")
                .ToArray()
                .OrderBy(a => a);

            return string.Join(Environment.NewLine, authors);
        }

        //09

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b)
            .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        //10

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(b => new { b.BookId, b.Title, AuthorName = $"{b.Author.FirstName} {b.Author.LastName}"})
                .OrderBy(b => b.BookId)
                .ToArray();

            return string.Join(Environment.NewLine, books.Select(b => $"{b.Title} ({b.AuthorName})"));
        }

        //11

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var booksCount = context.Books.Where(b => b.Title.Length > lengthCheck).ToList().Count;

            return booksCount;
        }

        //12

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(a => new
                {
                    AuthorName = $"{a.FirstName} {a.LastName}",
                    Copies = a.Books.Sum(c => c.Copies)
                })
                .ToArray()
                .OrderByDescending(a => a.Copies);

            return string.Join(Environment.NewLine, authors.Select(a => $"{a.AuthorName} - {a.Copies}"));
        }

        //13

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    Profit = c.CategoryBooks.Sum(b => b.Book.Copies * b.Book.Price)
                })
                .OrderByDescending(b => b.Profit)
                .ThenBy(b => b.CategoryName)
            .ToArray();

            return string.Join(Environment.NewLine, categories.Select(c => $"{c.CategoryName} ${c.Profit:f2}"));
        }

        //14

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    Books = c.CategoryBooks
                        .Select(b => new
                        {
                            BookTitle = b.Book.Title,
                            ReleaseDate = b.Book.ReleaseDate,
                        })
                        .OrderByDescending(b => b.ReleaseDate)
                        .Take(3)
                        .ToArray()
                })
                .OrderBy(c => c.CategoryName)
                .ToArray();

            var sb =  new StringBuilder();

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.CategoryName}");

                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.BookTitle} ({book.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //15
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books.Where(b => b.ReleaseDate.Value.Year < 2010).ToList();
            
            books.ForEach(b => b.Price+=5);

            context.SaveChanges();
        }

        //16

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books.Where(b => b.Copies < 4200).ToList();

            context.RemoveRange(books);

            context.SaveChanges();

            return books.Count;
        }
    }
}


