using System.Data;

namespace Chabagan.Fisheries.Entities.Mapping.Visualization
{
    public class ProductStock
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Stock { get; set; }
        public decimal LpRate { get; set; }
        public string Category { get; set; }

        public ProductStock()
        {
                
        }

        public ProductStock(DataRow objectRow)
        {
            this.Id = Convert.ToInt64(objectRow["Id"].ToString());
            this.Stock = Convert.ToInt32(objectRow["Stock"].ToString());
            this.LpRate = Convert.ToDecimal(objectRow["LpRate"].ToString());
            this.Name = objectRow["Name"].ToString();
            this.Category = objectRow["Category"].ToString();
        }
    }
}
