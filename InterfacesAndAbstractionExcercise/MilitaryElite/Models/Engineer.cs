using MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, Corp corp)
            : base(id, firstName, lastName, salary, corp)
        {
            Repairs = new List<IRepair>();
        }
        public ICollection<IRepair> Repairs { get; set; }

        public override string ToString()
        {
            StringBuilder repairsResult = new StringBuilder();
            repairsResult.AppendLine("Repairs:");

            foreach (var repair in Repairs)
            {
                repairsResult.AppendLine($"  {repair.ToString()}");
            }

            string result = repairsResult.ToString().TrimEnd();

            string final = $"{base.ToString()}{Environment.NewLine}Corps: {Corp}{Environment.NewLine}{result}";
            return final;
        }
    }
}
