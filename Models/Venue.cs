using System.ComponentModel.DataAnnotations;

namespace swag.Models {

    public class Venue {

        [Key]
        public int venue_id {get; set;}
        public string name {get; set;}
        
         
    }
}