using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using FlexiParser;
using System.Xml.Serialization;
using CarDealer.DTOs.Export;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using System.IO;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using var context = new CarDealerContext();

            //09
            //var inputXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            //Console.WriteLine(ImportSuppliers(context,inputXml));


            //10
            //var inputXml = File.ReadAllText("../../../Datasets/parts.xml");
            //Console.WriteLine(ImportParts(context, inputXml));

            //11
            //var inputXml = File.ReadAllText("../../../Datasets/cars.xml");
            //Console.WriteLine(ImportCars(context, inputXml));

            //12
            //var inputXml = File.ReadAllText("../../../Datasets/customers.xml");
            //Console.WriteLine(ImportCustomers(context, inputXml));

            //13
            //var inputXml = File.ReadAllText("../../../Datasets/sales.xml");
            //Console.WriteLine(ImportSales(context, inputXml));

            //14

            //Console.WriteLine(GetCarsWithDistance(context));

            //15

            //Console.WriteLine(GetCarsFromMakeBmw(context));

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

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var suppliersDTOs = XmlParser.DeserializeXML<ImportSuppliersDTO[]>(inputXml, "Suppliers");

            var suppliers = suppliersDTOs
                .Select(s => new Supplier()
                {
                    Name = s.Name,
                    IsImporter = s.IsImporter,
                }).ToList();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        //10

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var partsDTOs = XmlParser.DeserializeXML<ImportPartsDTO[]>(inputXml, "Parts");
            var supplierIds = context.Suppliers.Select(s => s.Id);
            var parts = partsDTOs
                .Where(p => p.SupplierId != null && supplierIds.Contains(p.SupplierId))
                .Select(p => new Part()
                {
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    SupplierId = p.SupplierId,
                }).ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        //11 

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var carDTOs = XmlParser.DeserializeXML<ImportCarsDTO[]>(inputXml, "Cars").ToList();
            var cars = new List<Car>();
            var partIds = context.Parts.Select(p => p.Id).ToList();
            var partCars = new List<PartCar>();
            foreach (var carDTO in carDTOs)
            {
                var car = new Car()
                {
                    Make = carDTO.Make,
                    Model = carDTO.Model,
                    TraveledDistance = carDTO.TraveledDistance,
                };
                cars.Add(car);

                foreach (var partId in carDTO.Parts
                             .Where(p => partIds.Contains(p.Id))
                             .Select(p => p.Id)
                             .Distinct())
                {
                    var part = new PartCar()
                    {
                        Car = car,
                        PartId = partId,
                    };
                    partCars.Add(part);
                }
            }

            context.Cars.AddRange(cars);
            context.PartsCars.AddRange(partCars);
            context.SaveChanges();
            return $"Successfully imported {cars.Count}";
        }

        //12

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var customersDTO = XmlParser.DeserializeXML<ImportCustomersDTO[]>(inputXml, "Customers");

            var customers = customersDTO
                .Select(c => new Customer()
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver,
                })
                .ToList();

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        //13

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var salesDTO = XmlParser.DeserializeXML<ImportSalesDTO[]>(inputXml, "Sales");
            var carIds = context.Cars.Select(c => c.Id).ToList();
            var sales = new List<Sale>();
            foreach (var saleDTO in salesDTO)
            {
                if (!carIds.Contains(saleDTO.CarId))
                {
                    continue;
                }

                var sale = new Sale()
                {
                    CarId = saleDTO.CarId,
                    CustomerId = saleDTO.CustomerId,
                    Discount = saleDTO.Discount,
                };

                sales.Add(sale);
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        //14

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.TraveledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .Select(c => new ExportCarsWithDistanceDTO()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance,
                }).ToList();

            return XmlParser.SerializeToXml(cars, "cars");
        }

        //15

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .Select(c => new ExportBMWDTO()
                {
                    Id = c.Id,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance,
                }).ToList();

            return XmlParser.SerializeToXml(cars, "cars", true);
        }

        //16

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(c => c.IsImporter == false)
                .Select(c => new ExportSuppliersDTO()
                {
                    Id = c.Id,
                    Name = c.Name,
                    PartsCount = c.Parts.Count,
                }).ToList();

            return XmlParser.SerializeToXml(suppliers, "suppliers", true);
        }

        //17

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .OrderByDescending(c => c.TraveledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .Select(c => new ExportCarWithPartsDTO()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance,
                    Parts = c.PartsCars.Select(p => new ExportPartsDTO()
                        {
                            Name = p.Part.Name,
                            Price = p.Part.Price,
                        }).OrderByDescending(p => p.Price)
                        .ToArray()
                }).ToList();

            return XmlParser.SerializeToXml(cars, "cars");
        }

        //18

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var tempDTO = context.Customers
                .Where(c => c.Sales.Count > 0)
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    Sales = c.Sales.Select(s => new
                    {
                        Prices = c.IsYoungDriver == true
                            ? s.Car.PartsCars.Sum(cs => Math.Round((double)cs.Part.Price * 0.95,2))
                            : s.Car.PartsCars.Sum(cs => (double)cs.Part.Price)

                    })
                }).ToList();

            var customers = tempDTO
                .Select(c => new ExportCustomersWithAtLeastOneCarDTO()
                {
                    FullName = c.FullName,
                    BoughtCars = c.BoughtCars,
                    SpentMoney = c.Sales.Sum(s => s.Prices).ToString("f2")
                }).OrderByDescending(c => decimal.Parse(c.SpentMoney))
                .ToList();

            return XmlParser.SerializeToXml(customers,"customers");
        }

        //19

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new ExportSalesWithAppliedDiscountDTO()
                {
                    Car = new ExportCarInformationDTO()
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance,
                    },
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartsCars.Sum(p => p.Part.Price),
                    PriceWithDiscount = Math.Round((double)(s.Car.PartsCars.Sum(p => p.Part.Price) * (1 - (s.Discount / 100))), 4),
                }).ToList();


            return XmlParser.SerializeToXml(sales, "sales");
        }

    }

}

