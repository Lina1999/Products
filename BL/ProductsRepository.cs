using DataAccessLayer;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class ProductsRepository
    {
        /// <summary>
        /// DAL instance
        /// </summary>
        private DAL dal;

        /// <summary>
        /// Parameterless constructor
        /// </summary>
        public ProductsRepository()
        {
            dal = new DAL();
        }

        /// <summary>
        /// converting DAL product to BL product
        /// </summary>
        /// <param name="dalProd"></param>
        /// <returns></returns>
        private BLProduct Convert(DALProduct dalProd)
        {
            return new BLProduct(dalProd.ID, dalProd.Name, dalProd.Price, dalProd.Group);
        }

        /// <summary>
        /// converting BL product to DAL product
        /// </summary>
        /// <param name="blProd"></param>
        /// <returns></returns>
        private DALProduct Convert(BLProduct blProd)
        {
            return new DALProduct(blProd.ID, blProd.Name, blProd.Price, blProd.Group);
        }

        public List<BLProduct> GetAll()
        {
            var ans = new List<BLProduct>();
            foreach (var item in dal.Products)
            {
                var blProd = Convert(item);
                ans.Add(blProd);
            }
            return ans;
        }

        /// <summary>
        /// Getting product by ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public BLProduct Get(int ID)
        {
            var dalProd = dal.Get(ID);
            return Convert(dalProd);
        }

        /// <summary>
        /// Inserting product
        /// </summary>
        /// <param name="blProd"></param>
        public void Insert(BLProduct blProd)
        {
            var dalProd = Convert(blProd);
            dal.Insert(dalProd);
        }


        /// <summary>
        /// Deleting product
        /// </summary>
        /// <param name="blProd"></param>
        public void Delete(BLProduct blProd)
        {
            var dalProd = Convert(blProd);
            dal.Delete(dalProd);
        }

        /// <summary>
        /// Updating product
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="newName"></param>
        /// <param name="newPrice"></param>
        /// <param name="newGroup"></param>
        public void Update(int ID, string newName, double newPrice, string newGroup)
        {
            dal.Update(ID, newName, newPrice, newGroup);
        }
    }

}

