﻿using Treadmill.Api;
using Treadmill.Hosting;
using Treadmill.Infrastructure;

namespace Treadmill.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new DomainConfiguration 
            { 
                GpioClientRemoteUrl = "http://zerow2:8001" ,
                ListenUri = "http://localhost:8002/"
            };

            new SelfHost(new ApiCompositionRoot(config))
                .Run(config.ListenUri);
        }
    }
}
