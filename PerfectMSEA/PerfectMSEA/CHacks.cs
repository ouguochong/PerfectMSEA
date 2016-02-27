using PipeManagerSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMSEA
{
    class CHacks
    {
        // CPU Hacks: 0x100 -> 0x199
        const uint NO_BACKGROUND = 0x100;
        const uint NO_DAMAGE_TEXT = 0x110;

        // Char Hacks: 0x200 -> 0x299
        const uint STANCE_HACK = 0x200;
        const uint ITEM_FILTER = 0x210;
        const uint PERFECT_LOOT = 0x220;
        const uint UNLIMITED_ATTACK = 0x230;

        // Mob Hacks: 0x300 -> 0x399
        const uint MOB_FREEZE = 0x300;
        const uint MOB_DISARM = 0x310;
        const uint MOB_ITEM_VAC = 0x320;
        const uint MOB_VAC = 0x330;
        const uint MOB_VAC_TYPE = 0x331;

        // Misc. Hacks: 0x400 -> 499
        const uint SKILL_INJECTION = 0x400;
        const uint SKILL_INJECTION_SPEED = 0x401;

        CPipeClient client;
        PipeClient.PipeMessage reply;

        public CHacks()
        {
            client = new CPipeClient();
            reply = client.GetReply();
        }

        /// <summary>
        /// CPU-Related Hacks
        /// </summary>
        public void NoBackground(bool toggle)
        {
            if (toggle)
            {
                try { client.GetClient().SendData(NO_BACKGROUND, BitConverter.GetBytes(CPipeClient.DataEnable), sizeof(int), ref reply); } catch { }
            }
            else
            {
                try { client.GetClient().SendData(NO_BACKGROUND, BitConverter.GetBytes(CPipeClient.DataDisable), sizeof(int), ref reply); } catch { }
            }
        }

        public void NoDamageText(bool toggle)
        {
            if (toggle)
            {
                try { client.GetClient().SendData(NO_DAMAGE_TEXT, BitConverter.GetBytes(CPipeClient.DataEnable), sizeof(int), ref reply); } catch { }
            }
            else
            {
                try { client.GetClient().SendData(NO_DAMAGE_TEXT, BitConverter.GetBytes(CPipeClient.DataDisable), sizeof(int), ref reply); } catch { }
            }
        }

        /// <summary>
        /// Character-Related Hacks
        /// </summary>
        public void StanceHack(bool toggle)
        {
            if (toggle)
            {
                try { client.GetClient().SendData(STANCE_HACK, BitConverter.GetBytes(CPipeClient.DataEnable), sizeof(int), ref reply); } catch { }
            }
            else
            {
                try { client.GetClient().SendData(STANCE_HACK, BitConverter.GetBytes(CPipeClient.DataDisable), sizeof(int), ref reply); } catch { }
            }
        }

        public void ItemFilter(bool toggle)
        {
            if (toggle)
            {
                try { client.GetClient().SendData(ITEM_FILTER, BitConverter.GetBytes(CPipeClient.DataEnable), sizeof(int), ref reply); } catch { }
            }
            else
            {
                try { client.GetClient().SendData(ITEM_FILTER, BitConverter.GetBytes(CPipeClient.DataDisable), sizeof(int), ref reply); } catch { }
            }
        }

        public void PerfectLoot(bool toggle)
        {
            if (toggle)
            {
                try { client.GetClient().SendData(PERFECT_LOOT, BitConverter.GetBytes(CPipeClient.DataEnable), sizeof(int), ref reply); } catch { }
            }
            else
            {
                try { client.GetClient().SendData(PERFECT_LOOT, BitConverter.GetBytes(CPipeClient.DataDisable), sizeof(int), ref reply); } catch { }
            }
        }

        public void UnlimitedAttack(bool toggle)
        {
            if (toggle)
            {
                try { client.GetClient().SendData(UNLIMITED_ATTACK, BitConverter.GetBytes(CPipeClient.DataEnable), sizeof(int), ref reply); } catch { }
            }
            else
            {
                try { client.GetClient().SendData(UNLIMITED_ATTACK, BitConverter.GetBytes(CPipeClient.DataDisable), sizeof(int), ref reply); } catch { }
            }
        }

        /// <summary>
        /// Monster-Related Hacks
        /// </summary>
        public void MobFreeze(bool toggle)
        {
            if (toggle)
            {
                try { client.GetClient().SendData(MOB_FREEZE, BitConverter.GetBytes(CPipeClient.DataEnable), sizeof(int), ref reply); } catch { }
            }
            else
            {
                try { client.GetClient().SendData(MOB_FREEZE, BitConverter.GetBytes(CPipeClient.DataDisable), sizeof(int), ref reply); } catch { }
            }
        }

        public void MobDisarm(bool toggle)
        {
            if (toggle)
            {
                try { client.GetClient().SendData(MOB_DISARM, BitConverter.GetBytes(CPipeClient.DataEnable), sizeof(int), ref reply); } catch { }
            }
            else
            {
                try { client.GetClient().SendData(MOB_DISARM, BitConverter.GetBytes(CPipeClient.DataDisable), sizeof(int), ref reply); } catch { }
            }
        }

        public void MobItemVac(bool toggle)
        {
            if (toggle)
            {
                try { client.GetClient().SendData(MOB_ITEM_VAC, BitConverter.GetBytes(CPipeClient.DataEnable), sizeof(int), ref reply); } catch { }
            }
            else
            {
                try { client.GetClient().SendData(MOB_ITEM_VAC, BitConverter.GetBytes(CPipeClient.DataDisable), sizeof(int), ref reply); } catch { }
            }
        }

        public void MobVac(bool toggle)
        {
            if (toggle)
            {
                try { client.GetClient().SendData(MOB_VAC, BitConverter.GetBytes(CPipeClient.DataEnable), sizeof(int), ref reply); } catch { }
            }
            else
            {
                try { client.GetClient().SendData(MOB_VAC, BitConverter.GetBytes(CPipeClient.DataDisable), sizeof(int), ref reply); } catch { }
            }
        }

        public void MobVac_SetType(int type)
        {
            if (type == 0)
                try { client.GetClient().SendData(MOB_VAC_TYPE, BitConverter.GetBytes(CPipeClient.DataNULL), sizeof(int), ref reply); } catch { }
            else if (type == 1)
                try { client.GetClient().SendData(MOB_VAC_TYPE, BitConverter.GetBytes(CPipeClient.DataNULL + 2), sizeof(int), ref reply); } catch { }
        }

        /// <summary>
        /// Misc. Hacks
        /// </summary>
        public void SkillInjection(int option)
        {
            if (option == 1)
            {
                try { client.GetClient().SendData(SKILL_INJECTION, BitConverter.GetBytes(CPipeClient.DataEnable), sizeof(int), ref reply); } catch { }
            }
            else if (option == 2)
            {
                try { client.GetClient().SendData(SKILL_INJECTION, BitConverter.GetBytes(CPipeClient.DataEnable+1), sizeof(int), ref reply); } catch { }
            }
            else
            {
                try { client.GetClient().SendData(SKILL_INJECTION, BitConverter.GetBytes(CPipeClient.DataDisable), sizeof(int), ref reply); } catch { }
            }
        }

        public void SkillInjection_SetSpeed(int speed)
        {
            try { client.GetClient().SendData(SKILL_INJECTION_SPEED, BitConverter.GetBytes(CPipeClient.DataNULL+1+speed), sizeof(int), ref reply); } catch { }
        }

    }
}
