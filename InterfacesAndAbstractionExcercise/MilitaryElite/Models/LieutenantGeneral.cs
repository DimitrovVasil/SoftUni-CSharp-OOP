using MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            Privates = new List<ISoldier>();
        }

        public List<ISoldier> Privates { get; set; }

        public override string ToString()
        {
            StringBuilder privatesResult = new StringBuilder();
            privatesResult.AppendLine("Privates:");

            foreach (var eachPrivate in Privates)
            {
                privatesResult.AppendLine($"  {eachPrivate.ToString()}");
            }

            string final = $"{base.ToString()}{Environment.NewLine}{privatesResult.ToString().TrimEnd()}";

            return final;
        }
    }
}
