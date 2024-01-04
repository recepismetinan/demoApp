using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.UnitOfWorks;
using Entity.DTO.Products;
using Entity.Entities;
using Microsoft.AspNetCore.Http;
using Service.Services.Abstractions;

namespace Service.Services.Concretes
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task AddProduct(AddProductDTO addProductDTO)
        {
            var product = mapper.Map<Product>(addProductDTO);
            await unitOfWork.GetRepository<Product>().AddAsync(product);
            await unitOfWork.SaveAsync();
        }

        public async Task<List<ListProductsDTO>> GetDeletedProducts()
        {
            var products = await unitOfWork.GetRepository<Product>()
                .GetAll(x=> x.IsDeleted, x => x.ProductCategory, x=>x.IntermediateProducts);
            var map = mapper.Map<List<ListProductsDTO>>(products);
            return map;
        }

        public async Task<List<ListProductsDTO>> GetProducts()
        {
            var products = await unitOfWork.GetRepository<Product>()
                .GetAll(x=> !x.IsDeleted, x => x.ProductCategory, x=>x.IntermediateProducts);
            var map = mapper.Map<List<ListProductsDTO>>(products);
            return map;
        }

        public async Task SafeDeleteProduct(int id)
        {
            var product = await unitOfWork.GetRepository<Product>().GetByIdAsync(id);
            product.IsDeleted = true;
            product.DeletedDate = DateTime.UtcNow;
            await unitOfWork.GetRepository<Product>().UpdateAsync(product);
            await unitOfWork.SaveAsync();
        }

        public async Task UndoDeleteProduct(int id)
        {
            var product = await unitOfWork.GetRepository<Product>().GetByIdAsync(id);
            product.IsDeleted = false;
            product.DeletedDate = null;
            await unitOfWork.GetRepository<Product>().UpdateAsync(product);
            await unitOfWork.SaveAsync();
        }

        public async Task UpdateProduct(UpdateProductDTO updateProductDTO)
        {
            var productRepository = unitOfWork.GetRepository<Product>();
            var product = await productRepository.GetByIdAsync(updateProductDTO.Id, 
                x => !x.IsDeleted, x => x.ProductCategory, x => x.IntermediateProducts);
            if (product != null)
            {
                product.Name = updateProductDTO.Name;
                product.Note = updateProductDTO.Note;
                product.StockCount = updateProductDTO.StockCount;
                if (product.ProductCategory != null)
                {
                    product.ProductCategory.Name = updateProductDTO.ProductCategory.Name;
                    product.ProductCategory.TechnicalDetail = updateProductDTO.ProductCategory.TechnicalDetail;
                }
                foreach (var intermediateProductDTO in updateProductDTO.IntermediateProducts)
                {
                    var existingIntermediateProduct = product.IntermediateProducts
                        .FirstOrDefault(ip => ip.Id == intermediateProductDTO.Id);

                    if (existingIntermediateProduct != null)
                    {
                        existingIntermediateProduct.Name = intermediateProductDTO.Name;
                        existingIntermediateProduct.Detail = intermediateProductDTO.Detail;
                        existingIntermediateProduct.Quantity = intermediateProductDTO.Quantity;
                        existingIntermediateProduct.IntermediateProductType = intermediateProductDTO.IntermediateProductType;
                    }
                }
                await unitOfWork.SaveAsync();
            }
        }
    }
}