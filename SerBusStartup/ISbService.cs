using System.Collections.Generic;

namespace SerBusStartup
{
    public interface ISbService
    {
        public void AddMessages(string msgInput);
        public int GetMessages();

        //public List<string> SbMessages { get; set; }
        //public void AddMessages();
    }
}