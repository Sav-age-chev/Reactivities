namespace Domain
{
    public class Activity
    {
        public Guid Id { get; set; }   // Entity framework will recognise this property to be the primary key due to the "Id" name

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public string City { get; set; }

        public string Venue { get; set; }
    }
}