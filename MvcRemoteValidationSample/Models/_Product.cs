using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace MvcRemoteValidationSample.Models {

    [MetadataType(typeof(Product.MetaData))]
    public partial class Product {

        private class MetaData {

            [Remote(
                "doesProductNameExistUnderCategory", 
                "Northwind", 
                AdditionalFields = "Category_ID",
                ErrorMessage = "Product name already exists under the chosen category. Please enter a different product name.",
                HttpMethod = "POST"
            )]
            [Required]
            public string Product_Name { get; set; }
            
            [Required]
            public int? Supplier_ID { get; set; }

            [Required]
            public int? Category_ID { get; set; }

        }

    }
}