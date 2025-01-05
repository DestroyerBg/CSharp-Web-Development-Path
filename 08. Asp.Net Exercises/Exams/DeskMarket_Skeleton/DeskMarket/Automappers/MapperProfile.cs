using System.Globalization;
using AutoMapper;
using DeskMarket.Constraints;
using DeskMarket.Data.Models;
using DeskMarket.Models;
using static DeskMarket.Constraints.ProductConstraints;
namespace DeskMarket.Automappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AddProductViewModel, Product>()
                .ForMember(dest => dest.AddedOn, src =>
                    src.MapFrom(s =>
                        DateTime.ParseExact(s.AddedOn, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None)));

            CreateMap<Product, AllProductsViewModel>()
                .ForMember(dest => dest.UserId, src =>
                    src.MapFrom(s => s.Seller.Id))
                .ForMember(dest => dest.HasBought, src => src.MapFrom(s => s.ProductsClients.Any()));

            CreateMap<Product, ProductDetailsViewModel>()
                .ForMember(dest => dest.UserId, src =>
                    src.MapFrom(s => s.Seller.Id))
                .ForMember(dest => dest.CategoryName, src =>
                    src.MapFrom(s => s.Category.Name))
                .ForMember(dest => dest.Seller, src => src.MapFrom(s => s.Seller.UserName))
                .ForMember(dest => dest.AddedOn, src =>
                    src.MapFrom(s => s.AddedOn.ToString(DateFormat, CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.HasBought, src => src.MapFrom(s => s.ProductsClients.Any()));

            CreateMap<Product, EditProductViewModel>()
                .ForMember(dest => dest.AddedOn, src =>
                    src.MapFrom(s => s.AddedOn.ToString(DateFormat, CultureInfo.InvariantCulture)));

            CreateMap<EditProductViewModel, Product>()
                .ForMember(dest => dest.AddedOn, src =>
                    src.MapFrom(s =>
                        DateTime.ParseExact(s.AddedOn, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None)));

            CreateMap<Product, DeleteProductViewModel>()
                .ForMember(dest => dest.Seller, src =>
                    src.MapFrom(s =>
                        s.Seller.UserName))
                .ForMember(dest => dest.SellerId, src =>
                    src.MapFrom(s =>
                        s.Seller.Id));

            CreateMap<Product, ProductCartViewModel>();

        }
    }
}
