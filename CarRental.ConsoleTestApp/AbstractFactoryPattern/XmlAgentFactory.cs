using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.ConsoleTestApp.AbstractFactoryPattern
{
   public  class XmlAgentFactory : IAgentFactory
    {
      public  IAgentA CreateAgentA()
        {
            return new AgentA_Xml();
        }

      public  IAgentB CreateAgentB()
        {
            return new AgentB_Xml();
        }
    }
}
