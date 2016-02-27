using PipeManagerSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMSEA
{
    class CPipeClient
    {
        PipeClient client;
        PipeClient.PipeMessage reply;

        public const int DataNULL = -1;
        public const int DataDisable = 0;
        public const int DataEnable = 1;

        public CPipeClient()
        {
            client = new PipeClient();
            reply = new PipeClient.PipeMessage();
            client.Name = "PerfectMSEA";
        }

        public PipeClient GetClient()
        {
            return client;
        }

        public PipeClient.PipeMessage GetReply()
        {
            return reply;
        }
    }
}
