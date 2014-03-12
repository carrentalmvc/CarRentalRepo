using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.ConsoleTestApp.AbstractFactoryPattern
{
  public  interface IAgentFactory
    {
      IAgentA CreateAgentA();

      IAgentB CreateAgentB();

    }

  public interface IAgentA { }

  public interface IAgentB { }
}
