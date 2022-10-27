namespace web7.Models
{
    public class Motorbike
    {
        //primary key - auto increment
        public int Id { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }

        public int Year { get; set; }
    }
}
