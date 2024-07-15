using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Diagnostics;
using System.Globalization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using var context = new CarDealerContext();

            //09
            //string inputJson = File.ReadAllText("../../../Datasets/suppliers.json");
            //Console.WriteLine(ImportSuppliers(context,inputJson));

            //10
            //string inputJson = File.ReadAllText("../../../Datasets/parts.json");
            //Console.WriteLine(ImportParts(context, inputJson));

            //11
            //string inputJson = File.ReadAllText("../../../Datasets/cars.json");
            //Console.WriteLine(ImportCars(context, inputJson));

            //12
            //string inputJson = File.ReadAllText("../../../Datasets/customers.json");
            //Console.WriteLine(ImportCustomers(context, inputJson));

            //13
            //string inputJson = File.ReadAllText("../../../Datasets/sales.json");
            //Console.WriteLine(ImportSales(context, inputJson));


            //14

            //Console.WriteLine(GetOrderedCustomers(context));

            //15

            //Console.WriteLine(GetCarsFromMakeToyota(context));

            //16

            //Console.WriteLine(GetLocalSuppliers(context));

            //17

            //Console.WriteLine(GetCarsWithTheirListOfParts(context));

            //18

            //Console.WriteLine(GetTotalSalesByCustomer(context));

            //19

            Console.WriteLine(GetSalesWithAppliedDiscount(context));

        }

        //09
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        //10
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson);
            var supplierIds = context.Suppliers.Select(s => s.Id).ToList();
            var filteredParts = parts.Where(p => supplierIds.Contains(p.SupplierId)).ToList();

            context.Parts.AddRange(filteredParts);
            context.SaveChanges();

            return $"Successfully imported {filteredParts.Count}.";
        }

        //11

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carDTOs = JsonConvert.DeserializeObject<List<CarImportDTO>>(inputJson);
            var partIds = context.Parts.Select(p => p.Id);
            var partsCars = new List<PartCar>();
            var cars = new List<Car>();

            foreach (var carImportDto in carDTOs)
            {
                var car = new Car()
                {
                    Make = carImportDto.Make,
                    Model = carImportDto.Model,
                    TraveledDistance = carImportDto.TraveledDistance,
                };

                foreach (var part in carImportDto.PartsId.Distinct())
                {
                    if (partIds.Contains(part))
                    {
                        var partCar = new PartCar()
                        {
                            Car = car,
                            PartId = part,
                        };
                        partsCars.Add(partCar);
                    }
                }
                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.PartsCars.AddRange(partsCars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        //12 

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        //13

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        //14

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    c.IsYoungDriver
                })
                .ToList();

            var result = JsonConvert.SerializeObject(customers, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
            });

            return result;
        }

        //15

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars.Where(c => c.Make == "Toyota")
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TraveledDistance
                }).OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance);

            var result = JsonConvert.SerializeObject(cars, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
            });

            return result;
        }

        //16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers.Where(s => s.IsImporter == false)
                .Select(s => new SuppliersDTO()
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count,
                })
                .ToList();

            var result = JsonConvert.SerializeObject(suppliers, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
            });

            return result;
        }

        //17

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TraveledDistance
                    },
                    parts = c.PartsCars
                        .Select(pc => new
                        {
                            Name = pc.Part.Name,
                            Price = $"{Math.Round(pc.Part.Price,2):f2}",
                        }).ToArray()
                }).ToList();

            var result =  JsonConvert.SerializeObject(cars, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            });

            return result;
        }

        //18

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customersSales = context.Customers.Where(c => c.Sales.Count > 0)
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    sales = c.Sales.SelectMany(s => s.Car.PartsCars.Select(x => x.Part.Price))
                }).OrderByDescending(c => c.boughtCars)
                .ToList();

            var customers = customersSales.Select(c => new
            {
                c.fullName,
                c.boughtCars,
                spentMoney = c.sales.Sum(),
            })
                .OrderByDescending(s => s.spentMoney)
                .ThenByDescending(s => s.boughtCars);
            var result = JsonConvert.SerializeObject(customers, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
            });

            return result;
        }

        //19

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Take(10)
                .Select(s => new
                {   
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance,
                    },
                    customerName = s.Customer.Name,
                    discount = $"{s.Discount:f2}",
                    price = $"{s.Car.PartsCars.Sum(c => c.Part.Price):F2}",
                    priceWithDiscount = $"{s.Car.PartsCars.Sum(pc => pc.Part.Price) * (1 - s.Discount/100):F2}"
                });
                

            var result = JsonConvert.SerializeObject(sales, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            });

            return result;
        }
    }
}