using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.DTO.Products;

namespace Service.Services.Abstractions
{
    public interface IProductService
    {
        Task<List<ListProductsDTO>> GetProducts();
        Task<List<ListProductsDTO>> GetDeletedProducts();
        Task AddProduct(AddProductDTO addProductDTO);
        Task UpdateProduct(UpdateProductDTO updateProductDTO);
        Task SafeDeleteProduct(int id);
        Task UndoDeleteProduct(int id);
    }
}