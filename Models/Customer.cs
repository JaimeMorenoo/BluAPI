using System.ComponentModel.DataAnnotations;

namespace swag.Models {

    public class Customer {

        [Key]
        public int customer_id {get; set;}
        public string email {get; set;}
        public string instagram {get; set;}
                
    }
}