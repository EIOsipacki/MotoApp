

namespace MotoApp.Components.CarReader.Models;


//Model Year,Division,Carline,Eng Displ,# Cyl,City FE,Hwy FE,Comb FE
public class Car 
{   
    public int Year { get; set; }

    public string Manufacturer { get; set; }

    public string Name { get; set; }

    public double Displacement { get; set; }

    public int Cylinders { get; set; }

    public int City { get; set; }

    public int Highway { get; set; }

    public int Combined { get; set; }
}
