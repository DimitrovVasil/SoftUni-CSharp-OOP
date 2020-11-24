using EasterRaces.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : Repository<ICar>
    {
        public CarRepository() : base()
        {
        }

        public override ICar GetByName(string name)
        {
            return  Models.FirstOrDefault(c => c.Model == name);
        }
    }
}
