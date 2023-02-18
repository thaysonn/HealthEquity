using Domain.Common;

namespace Domain.Entities;
public class Car : BaseEntity
{ 
    public Car() { }
    public Car(string make, string model, int year, int doors, string color, decimal price)
    {
        Make = make;
        Model = model;
        Year = year;
        Doors = doors;
        Color = color;
        Price = price;
    }

    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public int Doors { get; set; }
    public string Color { get; set; }
    public decimal Price { get; set; }
}
