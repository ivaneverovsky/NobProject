using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data
{
    public enum StatusNumerator
    {
        Confirmed,
        Awaits,
        Rejected
    }
    
   public class StatusChangedEvent
    { 
        public void StatusChanged(string num)
        { StatusNumerator stat = new StatusNumerator();
            stat = StatusNumerator.Confirmed;
            string show = stat.ToString();
          
        }
    }
}
