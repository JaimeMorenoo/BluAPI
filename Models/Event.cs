using System.ComponentModel.DataAnnotations;

namespace swag.Models {

    public class Event {

        [Key]
        public int event_id {get; set;}
        public string name {get; set;}
        public string date {get; set;}
        
        
         
    }
}