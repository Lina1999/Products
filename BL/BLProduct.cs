namespace BusinessLayer
{
    public class BLProduct
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
        /// Price
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Group
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// Parameterless constructor
        /// </summary>
        public BLProduct() { }

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Name"></param>
        /// <param name="Price"></param>
        /// <param name="Group"></param>
        public BLProduct(int ID, string Name, double Price, string Group)
        {
            this.ID = ID;
            this.Name = Name;
            this.Price = Price;
            this.Group = Group;
        }
    }
}
