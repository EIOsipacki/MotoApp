using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoApp.Data.Entities;

public class Manufacturer:  EntityBase
{
    public string Name { get; set; }

    public string Country { get; set; }

    public int Year { get; set; }

}
