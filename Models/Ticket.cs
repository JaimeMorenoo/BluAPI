namespace swag.Models {

    public class Ticket {

        public int ticketID {get; set;}
        public int customerID {get; set;}
        public int eventID {get; set;}
        public int venueID {get; set;}
        public string issued_date {get; set;}
        public string due_date {get; set;}
        public int price {get; set;}
        public int qty {get; set;}
        public int discount {get; set;}
        
        
         
    }
}