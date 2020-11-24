using EasterRaces.Models.Drivers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : Repository<IDriver>
    {
        public DriverRepository() : base()
        {
        }

        public override IDriver GetByName(string name)
        {
            return Models.FirstOrDefault(c => c.Name == name);
        }
    }
}
