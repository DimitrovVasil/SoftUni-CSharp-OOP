using MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, Corp corp)
            : base(id, firstName, lastName, salary, corp)
        {
            Missions = new List<IMission>();
        }

        public ICollection<IMission> Missions { get; set; }

        public override string ToString()
        {
            StringBuilder missionsResult = new StringBuilder();
            missionsResult.AppendLine("Missions:");

            foreach (var mission in Missions)
            {
                missionsResult.AppendLine($"  {mission.ToString()}");
            }

            string result = missionsResult.ToString().TrimEnd();
            string final = $"{base.ToString()}{Environment.NewLine}Corps: {Corp}{Environment.NewLine}{result}";
            return final;
        }
    }
}
