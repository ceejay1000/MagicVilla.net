﻿namespace MagicVilla_WebApi.Logging
{
    public class LoggingImpl : ILogging
    {
        public void Log(string message, string type)
        {
            if (type == "error")
            {
                Console.WriteLine("ERROR - " + message);
            } else
            {
                Console.WriteLine(message);
            }
        }
    }
}
