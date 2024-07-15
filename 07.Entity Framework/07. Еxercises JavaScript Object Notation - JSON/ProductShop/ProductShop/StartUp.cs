using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.Models;
using ProductShop.Utilities;

public class StartUp
{
    public static void Main()
    {
        using var context = new ProductShopContext();
        //01
        //var input = File.ReadAllText("../../../Datasets/users.json");
        //Console.WriteLine(ImportUsers(context, input));

        //02
        //var input = File.ReadAllText("../../../Datasets/products.json");
        //Console.WriteLine(ImportProducts(context, input));

        //03
        //var input = File.ReadAllText("../../../Datasets/categories.json");
        //Console.WriteLine(ImportCategories(context, input));

        //04
        //var input = File.ReadAllText("../../../Datasets/categories-products.json");
        //Console.WriteLine(ImportCategoryProducts(context, input));

        //05

        //Console.WriteLine(GetProductsInRange(context));

        //06

        //Console.WriteLine(GetSoldProducts(context));

        //07

        //Console.WriteLine(GetCategoriesByProductsCount(context));

        //08

        Console.WriteLine(GetUsersWithProducts(context));

    }

    //01
    public static string ImportUsers(ProductShopContext context, string inputJson)
    {
        var users = JsonConvert.DeserializeObject<List<User>>(inputJson);
        context.Users.AddRange(users);
        context.SaveChanges();

        return $"Successfully imported {users.Count}";
    }

    //02

    public static string ImportProducts(ProductShopContext context, string inputJson)
    {
        var products = JsonParser.ParseJson<List<Product>>(inputJson, true);

        context.Products.AddRange(products);
        context.SaveChanges();

        return $"Successfully imported {products.Count}";
    }

    //03

    public static string ImportCategories(ProductShopContext context, string inputJson)
    {
        var categories = JsonParser.ParseJson<List<Category>>(inputJson)
            .Where(c => c.Name != null).ToList();
        context.Categories.AddRange(categories);
        context.SaveChanges();
        return $"Successfully imported {categories.Count}";
    }

    //04

    public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
    {
        var categoryProducts = JsonParser.ParseJson<List<CategoryProduct>>(inputJson, true);
        context.CategoriesProducts.AddRange(categoryProducts);
        context.SaveChanges();
        return $"Successfully imported {categoryProducts.Count}";
    }

    //05

    public static string GetProductsInRange(ProductShopContext context)
    {
        var products = context.Products
            .Where(p => p.Price >= 500 && p.Price<=1000)
            .Select(p => new ProductsInRangeDTO()
            {
                Name = p.Name,
                Price = p.Price,
                Seller = $"{p.Seller.FirstName} {p.Seller.LastName}",
            })
            .OrderBy(p => p.Price)
            .ToList();

        var result = JsonParser.GetJson(products);

        return result;
    }

    //06

    public static string GetSoldProducts(ProductShopContext context)
    {
        var users = context.Users
            .Where(u => u.ProductsSold.Any(b => b.Buyer != null))
            .Select(u => new
            {
                firstName = u.FirstName,
                lastName = u.LastName,
                soldProducts = u.ProductsSold
                    .Select(p => new
                    {
                        name = p.Name,
                        price = p.Price,
                        buyerFirstName = p.Buyer.FirstName,
                        buyerLastName = p.Buyer.LastName,

                    }),
            })
            .OrderBy(u => u.lastName)
            .ThenBy(u => u.firstName)
            .ToList();
        var result = JsonConvert.SerializeObject(users, Formatting.Indented);
        return result;

    }

    //07
    public static string GetCategoriesByProductsCount(ProductShopContext context)
    {
        var categories = context.Categories
            .OrderByDescending(c => c.CategoryProducts.Count)
            .Select(c => new CategoriesDTO()
            {
                CategoryName = c.Name,
                ProductsCount = c.CategoryProducts.Count,
                AveragePrice = $"{c.CategoryProducts.Average(p => p.Product.Price):f2}",
                TotalRevenue = $"{c.CategoryProducts.Sum(p => p.Product.Price):f2}",
            }).ToList();

        var result = JsonParser.GetJson(categories);

        return result;
    }

    //08

    public static string GetUsersWithProducts(ProductShopContext context)
    {
        var users = context.Users
            .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
            .OrderByDescending(u => u.ProductsSold.Where(b=> b.Buyer!= null).Count())
            .Select(u => new
            {
                u.FirstName,
                u.LastName,
                u.Age,
                SoldProducts = new
                {
                    Count = u.ProductsSold.Where(p => p.Buyer!= null).Count(),
                    Products = u.ProductsSold
                        .Where(p => p.Buyer != null)
                        .Select(p => new
                        {
                            Name = p.Name,
                            Price = p.Price,
                        }),

                }
                    
            })
            .ToList();

        var usersInfo = new
        {
            UsersCount = users.Count,
            users,
        };

        var result = JsonParser.GetJson(usersInfo, true);
        return result;

    }




}
