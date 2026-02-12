using System;
class Vehicle {
    public virtual void Drive() {
        Console.WriteLine("Driving a vehicle");
    }
}
class Car : Vehicle {
    public override void Drive() {
        Console.WriteLine("Driving a car");
    }
}
class Truck : Vehicle {
    public override void Drive() {
        Console.WriteLine("Driving a truck");
    }
}
class Program {
    static void Main() {
        Vehicle v1 = new Car();
        v1.Drive();

        Vehicle v2 = new Truck();
        v2.Drive();
    }
}