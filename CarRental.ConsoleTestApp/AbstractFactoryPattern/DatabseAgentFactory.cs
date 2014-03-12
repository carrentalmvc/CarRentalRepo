namespace CarRental.ConsoleTestApp.AbstractFactoryPattern
{
    public class DatabseAgentFactory : IAgentFactory
    {
        public IAgentA CreateAgentA()
        {
            return new AgentA_Databse();
        }

        public IAgentB CreateAgentB()
        {
            return new AgentB_Databse();
        }
    }
}