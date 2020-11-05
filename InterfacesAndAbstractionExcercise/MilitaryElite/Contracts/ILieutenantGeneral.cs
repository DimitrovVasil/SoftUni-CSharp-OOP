using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Contracts
{
    public interface ILieutenantGeneral : IPrivate
    {
       public List<ISoldier> Privates { get; set; }
    }
}
