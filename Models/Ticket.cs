using System.ComponentModel.DataAnnotations;

namespace swag.Models {

    public class Ticket {

        [Key]
        public int ticket_id {get; set;}
        public int customer_id {get; set;}
        public int event_id {get; set;}
        public int venue_id {get; set;}
        public string issued_date {get; set;}
        public string due_date {get; set;}
        public int price {get; set;}
        public int qty {get; set;}
        public int discount {get; set;}
        
        
         
    }
}