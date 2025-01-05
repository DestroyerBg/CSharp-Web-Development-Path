using AutoMapper;
using DeskMarket.Data;
using DeskMarket.Data.Models;
using DeskMarket.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DeskMarket.Services
{
    public class ProductService
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext context;

        public ProductService(IMapper mapper, ApplicationDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public AddProductViewModel CreateBlankAddProductViewModel(IdentityUser user)
        {
            AddProductViewModel model = new AddProductViewModel();
            model.SellerId = user.Id;
            return model;
        }


        public async Task<bool> AddProductToDatabase(AddProductViewModel model)
        {
            Product product = mapper.Map<AddProductViewModel, Product>(model);

            await context.Products.AddAsync(product);

            await context.SaveChangesAsync();

            return true;
        }

        public async Task<ICollection<AllProductsViewModel>> LoadProductsAsync()
        {
            ICollection<AllProductsViewModel> productModels =
                await context.Products
                    .Include(s => s.Seller)
                    .Include(s => s.ProductsClients)
                    .Where(p => p.IsDeleted == false)
                    .Select(p => mapper.Map<Product, AllProductsViewModel>(p))
                    .ToListAsync();
            
            return productModels;
        }


        public async Task<ProductDetailsViewModel> LoadDetailsForProductAsync(int id)
        {
            Product? product = await context.Products
                .Include(p => p.Category)
                .Include(p => p.Seller)
                .Include(p => p.ProductsClients)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return null;
            }

            ProductDetailsViewModel model = mapper.Map<Product, ProductDetailsViewModel>(product);

            return model;
        }

        public async Task<EditProductViewModel> CreateEditModel(int id, IdentityUser user)
        {
            Product? product = await context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return null;
            }

            if (product.SellerId != user.Id)
            {
                return null;
            }

            EditProductViewModel model = mapper.Map<Product, EditProductViewModel>(product);

            return model;
        }

        public async Task<bool> EditProduct(EditProductViewModel model)
        {
            Product? product = await context.Products
                .Include(p => p.Category)
                .Include(p => p.Seller)
                .FirstOrDefaultAsync(p => p.Id == model.Id);

            if (product == null)
            {
                return false;
            }

            mapper.Map(model, product);

            await context.SaveChangesAsync();

            return true;
        }

        public async Task<DeleteProductViewModel> CreateDeleteProductModel(int id, IdentityUser user)
        {
            Product? product = await context.Products
                .Include(p => p.Category)
                .Include(p => p.Seller)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return null;
            }

            if (product.SellerId != user.Id)
            {
                return null;
            }

            DeleteProductViewModel model = mapper.Map<Product, DeleteProductViewModel>(product);

            return model;
        }

        public async Task<bool> DeleteProductFromDatabase(DeleteProductViewModel model)
        {
            Product? product = await context.Products
                .Include(p => p.Category)
                .Include(p => p.Seller)
                .FirstOrDefaultAsync(p => p.Id == model.Id);

            if (product == null)
            {
                return false;
            }

            List<ProductClient> productClients = await context.ProductClients
                .Where(p => p.ClientId == model.SellerId && p.ProductId == model.Id)
                .ToListAsync();

            product.IsDeleted = true;

            await context.SaveChangesAsync();
            context.ProductClients.RemoveRange(productClients);

            return true;
        }

        public async Task<ICollection<ProductCartViewModel>> GetUserCart(IdentityUser user)
        {
            ICollection<ProductCartViewModel> models =
                await context.Products
                    .Include(c => c.ProductsClients)
                    .Where(c => c.ProductsClients.Any(pc => pc.ClientId == user.Id))
                    .Where(c => c.IsDeleted == false)
                    .Select(p => mapper.Map<Product, ProductCartViewModel>(p))
                    .ToListAsync();

            return models;
        }

        public async Task<bool> AddProductToUserCart(IdentityUser user, int id)
        {
            Product? product = await 
                context.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return false;
            }

            bool isAlreadyAdded = await
                context.ProductClients.AnyAsync(pc => pc.ClientId == user.Id && pc.ProductId == product.Id);

            if (isAlreadyAdded)
            {
                return false;
            }

            ProductClient productClient = new ProductClient()
            {
                ClientId = user.Id,
                ProductId = product.Id
            };

            await context.ProductClients.AddAsync(productClient);

            await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RemoveFromCart(IdentityUser user, int id)
        {
            ProductClient? productClient = await
                context.ProductClients
                    .FirstOrDefaultAsync(pc => pc.ClientId == user.Id && pc.ProductId == id);

            if (productClient == null)
            {
                return false;
            }

            context.ProductClients.Remove(productClient);

            await context.SaveChangesAsync();

            return true;
        }
        

    }
}
