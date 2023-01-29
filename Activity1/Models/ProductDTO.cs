using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Activity1.Models
{
    public class ProductDTO
    {
        [DisplayName("Id Number")]
        public int Id { get; set; }

        [DisplayName("Product Name")]
        public string Name { get; set; }

        [DisplayName("Cost to Customer")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [DisplayName("What you paid for")]
        public string Description { get; set; }
        public String ShortDescription { get; set; }
        public string PriceString { get; set; }
        public Decimal Tax { get; set; }
      
      /*  public ProductDTO(int id, string name, decimal price, string description)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;

            PriceString = string.Format("{0:C}", price);
            ShortDescription = description.Length <= 25 ? description : description.Substring(25);
            Tax = price * 0.08M;
        } */
        public ProductDTO(ProductModel p)
        {
            Id =p.Id;
            Name = p.Name;
            Price = p.Price;
            Description = p.Description;

            PriceString = string.Format("{0:C}", p.Price);
            ShortDescription = p.Description.Length <= 25 ? p.Description : p.Description.Substring(25);
            Tax = p.Price * 0.08M;
        } 
    }
}
 
