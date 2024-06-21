using System.ComponentModel.DataAnnotations;

namespace swag.Models {

    public class Customer {

        [Key]
        public int userID {get; set;}
        public string name {get; set;}
        public string lastName {get; set;}
        public string dob {get; set;}
        public string email {get; set;}
        public string phone {get; set;}
        
        
         
    }
}