using MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private Corp corp;

        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, Corp corp) 
            : base(id, firstName, lastName, salary)
        {
            Corp = corp;
        }

        public Corp Corp
        {
            get => this.corp;

            set 
            {
                if (!Enum.IsDefined(typeof(Corp), value))
                {
                    throw new ArgumentException("Wrong corp");
                }

                corp = value;         
            } 
        }
           
           
    }
}
