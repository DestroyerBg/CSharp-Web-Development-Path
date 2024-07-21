using System.Text;
using System.Xml;
using System.Xml.Serialization;
using FlexiParser;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            using var context = new ProductShopContext();

            //01
            //var inputXml = File.ReadAllText("../../../Datasets/users.xml");
            //Console.WriteLine(ImportUsers(context,inputXml));


            //02
            //var inputXml = File.ReadAllText("../../../Datasets/products.xml");
            //Console.WriteLine(ImportProducts(context,inputXml));

            //03
            //var inputXml = File.ReadAllText("../../../Datasets/categories.xml");
            //Console.WriteLine(ImportCategories(context, inputXml));

            //04
            //var inputXml = File.ReadAllText("../../../Datasets/categories-products.xml");
            //Console.WriteLine(ImportCategoryProducts(context, inputXml));

            //05

            Console.WriteLine(GetProductsInRange(context));

            //06

            //Console.WriteLine(GetSoldProducts(context));

            //07

            //Console.WriteLine(GetCategoriesByProductsCount(context));

            //08

            //Console.WriteLine(GetUsersWithProducts(context));


        }

        //01
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var usersDTO = XmlParser.DeserializeXML<ImportUserDTO[]>(inputXml, "Users");

            var users = usersDTO
                .Select(u => new User()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                }).ToList();

            context.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        //02

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var productsDTO = XmlParser.DeserializeXML<ImportProductsDTO[]>(inputXml, "Products");
            var products = productsDTO
                .Select(p => new Product()
                {
                    Name = p.Name,
                    Price = p.Price,
                    SellerId = p.SellerId,
                    BuyerId = p.BuyerId == 0 ? null : p.BuyerId,
                }).ToList();

            context.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        //03

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var categoriesDTO = XmlParser.DeserializeXML<ImportCategoriesDTO[]>(inputXml, "Categories");

            var categories = categoriesDTO
                .Select(c => new Category()
                {
                    Name = c.Name,
                }).Where(c => c.Name != null)
                .ToList();

            context.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        //04

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var categoriesProductDTOs =
                XmlParser.DeserializeXML<ImportCategoriesProductsDTO[]>(inputXml, "CategoryProducts");
            var categoriesIds = context.Categories.Select(c => c.Id).ToList();
            var productsIds = context.Products.Select(p => p.Id).ToList();
            var categoriesProducts = categoriesProductDTOs
                .Select(cp => new CategoryProduct()
                {
                    CategoryId = cp.CategoryId,
                    ProductId = cp.ProductId
                }).Where(cp => categoriesIds.Contains(cp.CategoryId) && productsIds.Contains(cp.ProductId))
                .ToList();

            context.CategoryProducts.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count}";
        }

        //05

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .Select(p => new ExportRangeProductsDTO()
                {
                    Name = p.Name,
                    Price =p.Price,
                    Buyer = $"{p.Buyer.FirstName} {p.Buyer.LastName}",
                }).ToArray();

            return XmlParser.SerializeToXml(products, "Products");


        }

        //06

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Count > 0)
                .OrderBy(p => p.LastName)
                .ThenBy(p => p.FirstName)
                .Take(5)
                .Select(u => new ExportUsersWithAtLeastOneItemDTO()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                        .Select(p => new ExportProductsDTO()
                        {
                            Name = p.Name,
                            Price = p.Price
                        }).ToArray()
                })
                .ToArray();

            return XmlParser.SerializeToXml(users, "Users");
        }

        //07

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new ExportCategoriesDTO()
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(p => p.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(p => p.Product.Price),
                }).OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            return XmlParser.SerializeToXml(categories, "Categories");

        }

        //08

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = new ExportUsersProductsDTO()
            {
                Count = context.Users.Where(b => b.ProductsSold.Any(b => b.Buyer != null)).Count(),
                Users = context.Users.Where(b => b.ProductsSold.Any(b => b.Buyer != null))
                    .OrderByDescending(u => u.ProductsSold.Count(p => p.Buyer != null))
                    .Take(10)
                    .Select(p => new ExportUsersInformationDTO()
                    {
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        Age = p.Age,
                        SoldProducts = new ExportSoldProductsArrayDTO()
                        {
                            Count = p.ProductsSold.Count(p => p.Buyer != null),
                            Products = p.ProductsSold.Where(b => b.Buyer != null)
                                .Select(sp => new ExportSoldProducts()
                                {
                                    Name = sp.Name,
                                    Price = sp.Price,
                                })
                                .OrderByDescending(product => product.Price)
                                .ToArray()
                        }

                    })
                    .ToArray()
            };



            return XmlParser.SerializeToXml(users, "Users", true);
        }

    }


}