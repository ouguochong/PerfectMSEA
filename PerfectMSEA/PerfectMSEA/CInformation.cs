using PipeManagerSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMSEA
{
    class CInformation
    {
        // 0x01 -> 0x19
        const uint PEOPLE_COUNT = 0x01;
        const uint MOB_COUNT = 0x02;

        CPipeClient client;
        PipeClient.PipeMessage reply;

        public CInformation()
        {
            client = new CPipeClient();
            reply = client.GetReply();
        }

        public int GetPeopleCount()
        {
            try
            {
                client.GetClient().SendData(PEOPLE_COUNT, BitConverter.GetBytes(CPipeClient.DataNULL), sizeof(int), ref reply);
                return BitConverter.ToInt32(reply.Data, 0);
            }
            catch
            {
                return -1;
            }
        }

        public int GetMobCount()
        {
            try
            {
                client.GetClient().SendData(MOB_COUNT, BitConverter.GetBytes(CPipeClient.DataNULL), sizeof(int), ref reply);
                return BitConverter.ToInt32(reply.Data, 0);
            }
            catch
            {
                return -1;
            }
        }
    }
}
