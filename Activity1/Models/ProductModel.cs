using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Activity1.Models
{
    public class ProductModel
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

        public DateTime? CreatedOn { get; set; }
        public byte[] DataFiles { get; set; }
        public string FileType { get; set; }
        public string Names { get; set; }
    }
}
