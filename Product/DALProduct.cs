namespace DataAccessLayer
{
    /// <summary>
    /// Data access layer product
    /// </summary>
    public class DALProduct
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Group
        /// </summary>
        public string Group { get; set; }

        /// <su.
        /// mmary>
        /// Parameterless constructor
        /// </summary>
        public DALProduct() { }

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Name"></param>
        /// <param name="Price"></param>
        /// <param name="Group"></param>
        public DALProduct(int ID, string Name, double Price, string Group)
        {
            this.ID = ID;
            this.Name = Name;
            this.Price = Price;
            this.Group = Group;
        }
    }

}