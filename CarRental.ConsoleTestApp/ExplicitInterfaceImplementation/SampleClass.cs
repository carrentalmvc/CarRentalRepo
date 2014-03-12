using System;

namespace CarRental.ConsoleTestApp
{
    /// <summary>
    /// Explicit interface implementation is simply awesome
    /// </summary>
    public class SampleClass : IControl, ISurface
    {
        void IControl.Paint()
        {
            Console.WriteLine("This is the implementation for the IControl interface memebre....");
        }

        void ISurface.Paint()
        {
            Console.WriteLine("This is the implementation from the ISurface interface....");
        }
    }

    public interface IControl
    {
        void Paint();
    }

    public interface ISurface
    {
        void Paint();
    }
}