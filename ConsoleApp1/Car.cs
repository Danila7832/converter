using System;
namespace Converter
{
    public class Car
    {

        public String mark;
        public String model;
        public String color;
        public int doorCount;

        public Car()
        {
        }

        public Car(string mark, string model, string color, int doorCount)
        {
            this.mark = mark ?? throw new ArgumentNullException(nameof(mark));
            this.model = model ?? throw new ArgumentNullException(nameof(model));
            this.color = color ?? throw new ArgumentNullException(nameof(color));
            this.doorCount = doorCount;
        }

        public override string? ToString()
        {
            String car =this.mark + '\n' + this.model + '\n' + this.color + '\n' + this.doorCount;
            return car;
        }
    }
}