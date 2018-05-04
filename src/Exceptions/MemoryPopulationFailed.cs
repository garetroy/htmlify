using System;
namespace htmlify.src.Exceptions
{
    public class MemoryPopulationFailed : Exception
    {
        public MemoryPopulationFailed()
        {
        }
        
        public MemoryPopulationFailed(string message)
            :base(message)
        {
        }
        
        public MemoryPopulationFailed(string message, Exception inner)
            :base(message, inner)
        {
        }
    }
}
