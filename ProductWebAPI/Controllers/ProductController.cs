using BusinessLayer;
using ProductClient;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

/// <summary>
/// Web API controllers
/// </summary>
namespace WebApplication.Controllers
{
    /// <summary>
    /// Product Controller
    /// </summary>
    public class ProductController : ApiController
    {
        /// <summary>
        /// ProductsRepository field
        /// </summary>
        private ProductsRepository BL;

        /// <summary>
        /// Parameterless constructor
        /// </summary>
        public ProductController()
        {
            BL = new ProductsRepository();
        }

        /// <summary>
        /// Get all the products from DB
        /// </summary>
        /// <returns></returns>
        public List<BLProduct> Get()
        {
            return BL.GetAll();
        }

        /// <summary>
        /// Get product by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BLProduct Get(int id)
        {
            return BL.Get(id);
        }

        /// <summary>
        /// Insert new Product
        /// </summary>
        /// <param name="value"></param>
        public void Post(Product value)
        {
            BL.Insert(new BLProduct(value.ID,value.Name, value.Price, value.Group));
        }

        /// <summary>
        /// Update existing product
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="newName"></param>
        /// <param name="newPrice"></param>
        /// <param name="newGroup"></param>
        public void Put(int ID, string newName, double newPrice, string newGroup)
        {
            BL.Update(ID, newName, newPrice, newGroup);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="blProd"></param>
        public void Delete(Product blProd)
        {
            BL.Delete(new BLProduct(blProd.ID, blProd.Name, blProd.Price, blProd.Group));
        }
    }
}
