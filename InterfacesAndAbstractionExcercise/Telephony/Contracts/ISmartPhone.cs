using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public interface ISmartPhone : IPhone
    {
        public string Browse(string url);
    }
}
