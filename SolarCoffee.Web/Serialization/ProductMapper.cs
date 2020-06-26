using SolarCoffee.Data.Models;
using SolarCoffee.Web.ViewModels;

namespace SolarCoffee.Web.Serialization
{
    public class ProductMapper
    {
        /// <summary>
        /// Maps a Product data model to a ProductModel view model
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static ProductModel SerializeProductModel(Product product)
        {
            return new ProductModel
            {
                Id = product.Id,
                CreatedOn = product.CreatedOn,
                UpdatedOn = product.CreatedOn,
                Price = product.Price,
                Name = product.Name,
                Description = product.Description,
                IsTaxable = product.IsTaxable,
                IsArchived = product.IsArchived
            };
        }

        /// <summary>
        /// Maps a Product view model to a ProductModel data model
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static Product SerializeProductModel(ProductModel productModel)
        {
            return new Product
            {
                Id = productModel.Id,
                CreatedOn = productModel.CreatedOn,
                UpdatedOn = productModel.CreatedOn,
                Price = productModel.Price,
                Name = productModel.Name,
                Description = productModel.Description,
                IsTaxable = productModel.IsTaxable,
                IsArchived = productModel.IsArchived
            };
        }
    }
}
 