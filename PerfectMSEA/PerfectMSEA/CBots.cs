using PipeManagerSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMSEA
{
    class CBots
    {
        // 0x50 -> 0x99
        const uint AUTO_LOOT = 0x50;

        CPipeClient client;
        PipeClient.PipeMessage reply;

        public CBots()
        {
            client = new CPipeClient();
            reply = client.GetReply();
        }

        public void AutoLoot(bool toggle)
        {
            if (toggle)
            {
                try { client.GetClient().SendData(AUTO_LOOT, BitConverter.GetBytes(CPipeClient.DataEnable), sizeof(int), ref reply); } catch { }
            }
            else
            {
                try { client.GetClient().SendData(AUTO_LOOT, BitConverter.GetBytes(CPipeClient.DataDisable), sizeof(int), ref reply); } catch { }
            }
        }
    }
}
