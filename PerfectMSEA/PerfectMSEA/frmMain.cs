using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PipeManagerSharp;
using System.Diagnostics;
using System.IO;

namespace PerfectMSEA
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        // perform server-client heartbeat
        bool mapleStarted = false;
        bool mapleStartCheck = false;
        bool mapleEndCheck = false;
        Process[] pMapleStory;

        CFunctions func;
        CInformation info;
        CBots bots;
        CHacks hacks;

        private void frmMain_Load(object sender, EventArgs e)
        {
            func = new CFunctions();
            if (!func.CheckGHStatus())
            {
                MessageBox.Show("GH server is disabled.");
                Application.Exit();
                Environment.Exit(0);
            }

            info = new CInformation();
            bots = new CBots();
            hacks = new CHacks();

            txtMapleDirectory.Text = Properties.Settings.Default.MaplePath;

            cboMobVacType.SelectedIndex = 0;
        }

        private void txtMapleDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK)
            {
                txtMapleDirectory.Text = fbd.SelectedPath;
            }
        }

        private void txtMapleDirectory_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.MaplePath = txtMapleDirectory.Text;
            Properties.Settings.Default.Save();

            string mapleDir = Properties.Settings.Default.MaplePath;
            if (txtMapleDirectory.Text.Length > 0 && Directory.Exists(mapleDir) && File.Exists(mapleDir + "\\MapleStory.exe"))
            {
                btnStartMaple.Enabled = true;
            }
            else
            {
                btnStartMaple.Enabled = false;
            }
        }

        private void btnStartMaple_Click(object sender, EventArgs e)
        {
            string mapleDir = Properties.Settings.Default.MaplePath;
            if (txtMapleDirectory.Text.Length > 0 && Directory.Exists(mapleDir) && File.Exists(mapleDir + "\\MapleStory.exe"))
            {
                if (!File.Exists(mapleDir + "\\PCOM.dll") || !File.Exists(mapleDir + "\\PCOM.proxy"))
                {
                    func.DownloadOriginalPCOM(mapleDir);
                    func.DownloadHackedPCOM(mapleDir);
                }
                mapleStartCheck = true;
                mapleEndCheck = true;
                mapleStarted = true;
                Process.Start(mapleDir + "\\MapleStory.exe");
            }
            else
            {
                MessageBox.Show("Make sure PCOM.proxy and PCOM.dll exists!");
            }
        }

        private void btnRestoreMaple_Click(object sender, EventArgs e)
        {
            string mapleDir = Properties.Settings.Default.MaplePath;
            if (txtMapleDirectory.Text.Length > 0 && Directory.Exists(mapleDir) && File.Exists(mapleDir + "\\MapleStory.exe") && File.Exists(mapleDir + "\\PCOM.dll") && File.Exists(mapleDir + "\\PCOM.proxy"))
            {
                try
                {
                    File.Delete(mapleDir + "\\PCOM.dll");
                    File.Delete(mapleDir + "\\PCOM.proxy");
                    func.DownloadOriginalPCOM(mapleDir);
                    File.Move(mapleDir + "\\PCOM.proxy", mapleDir + "\\PCOM.dll");
                    MessageBox.Show("Default MapleStory restored!");
                }
                catch
                {
                    MessageBox.Show("Restore process failed!");
                }
            }
            else
            {
                MessageBox.Show("MapleStory might already be the original version!");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Environment.Exit(0);
        }

        private void tmrManager_Tick(object sender, EventArgs e)
        {
            pMapleStory = Process.GetProcessesByName("MapleStory");
            if (pMapleStory.Length > 0)
            {
                if (!mapleStarted)
                {
                    mapleStartCheck = true;
                    mapleEndCheck = true;
                    mapleStarted = true;
                }

                if (mapleStartCheck)
                {
                    chkAutoLoot.Enabled = true;
                    chkNoBackground.Enabled = true;
                    chkNoDamageText.Enabled = true;
                    chkStanceHack.Enabled = true;
                    chkItemFilter.Enabled = true;
                    chkPerfectLoot.Enabled = true;
                    chkUnlimitedAttack.Enabled = true;
                    chkMobFreeze.Enabled = true;
                    chkMobDisarm.Enabled = true;
                    chkMobItemVac.Enabled = true;
                    chkMobVac.Enabled = true;
                    chkFullMapAttack.Enabled = true;
                    chkBossAttack.Enabled = true;

                    txtMapleDirectory.Enabled = false;
                    btnStartMaple.Enabled = false;
                    btnRestoreMaple.Enabled = false;

                    tmrInformation.Enabled = true;

                    mapleStartCheck = false;
                }
            }
            else
            {
                if (mapleEndCheck)
                {
                    chkAutoLoot.Enabled = false;
                    chkNoBackground.Enabled = false;
                    chkNoDamageText.Enabled = false;
                    chkStanceHack.Enabled = false;
                    chkItemFilter.Enabled = false;
                    chkPerfectLoot.Enabled = false;
                    chkUnlimitedAttack.Enabled = false;
                    chkMobFreeze.Enabled = false;
                    chkMobDisarm.Enabled = false;
                    chkMobItemVac.Enabled = false;
                    chkMobVac.Enabled = false;
                    chkFullMapAttack.Enabled = false;
                    chkBossAttack.Enabled = false;

                    chkAutoLoot.CheckedChanged -= chkAutoLoot_CheckedChanged;
                    chkAutoLoot.Checked = false;
                    chkAutoLoot.CheckedChanged += chkAutoLoot_CheckedChanged;
                    chkNoBackground.CheckedChanged -= chkNoBackground_CheckedChanged;
                    chkNoBackground.Checked = false;
                    chkNoBackground.CheckedChanged += chkNoBackground_CheckedChanged;
                    chkNoDamageText.CheckedChanged -= chkNoDamageText_CheckedChanged;
                    chkNoDamageText.Checked = false;
                    chkNoDamageText.CheckedChanged += chkNoDamageText_CheckedChanged;
                    chkStanceHack.CheckedChanged -= chkStanceHack_CheckedChanged;
                    chkStanceHack.Checked = false;
                    chkStanceHack.CheckedChanged += chkStanceHack_CheckedChanged;
                    chkItemFilter.CheckedChanged -= chkItemFilter_CheckedChanged;
                    chkItemFilter.Checked = false;
                    chkItemFilter.CheckedChanged += chkItemFilter_CheckedChanged;
                    chkPerfectLoot.CheckedChanged -= chkPerfectLoot_CheckedChanged;
                    chkPerfectLoot.Checked = false;
                    chkPerfectLoot.CheckedChanged += chkPerfectLoot_CheckedChanged;
                    chkUnlimitedAttack.CheckedChanged -= chkUnlimitedAttack_CheckedChanged;
                    chkUnlimitedAttack.Checked = false;
                    chkUnlimitedAttack.CheckedChanged += chkUnlimitedAttack_CheckedChanged;
                    chkMobFreeze.CheckedChanged -= chkMobFreeze_CheckedChanged;
                    chkMobFreeze.Checked = false;
                    chkMobFreeze.CheckedChanged += chkMobFreeze_CheckedChanged;
                    chkMobDisarm.CheckedChanged -= chkMobDisarm_CheckedChanged;
                    chkMobDisarm.Checked = false;
                    chkMobDisarm.CheckedChanged += chkMobDisarm_CheckedChanged;
                    chkMobItemVac.CheckedChanged -= chkMobItemVac_CheckedChanged;
                    chkMobItemVac.Checked = false;
                    chkMobItemVac.CheckedChanged += chkMobItemVac_CheckedChanged;
                    chkMobVac.CheckedChanged -= chkMobVac_CheckedChanged;
                    chkMobVac.Checked = false;
                    chkMobVac.CheckedChanged += chkMobVac_CheckedChanged;
                    chkFullMapAttack.CheckedChanged -= chkFullMapAttack_CheckedChanged;
                    chkFullMapAttack.Checked = false;
                    chkFullMapAttack.CheckedChanged += chkFullMapAttack_CheckedChanged;
                    chkBossAttack.CheckedChanged -= chkBossAttack_CheckedChanged;
                    chkBossAttack.Checked = false;
                    chkBossAttack.CheckedChanged += chkBossAttack_CheckedChanged;

                    txtMapleDirectory.Enabled = true;
                    btnStartMaple.Enabled = true;
                    btnRestoreMaple.Enabled = true;

                    tmrInformation.Enabled = false;

                    mapleStarted = false;
                    mapleEndCheck = false;
                }
            }
        }

        private void tmrInformation_Tick(object sender, EventArgs e)
        {
            if (mapleStarted && mapleEndCheck)
            {
                lblPeopleCount.Text = "People Count: " + info.GetPeopleCount().ToString();
                lblMobCount.Text = "Mob Count: " + info.GetMobCount().ToString();
            }
        }

        ///
        /// 

        /// <summary>
        /// Bots
        /// </summary>
        private void chkAutoLoot_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoLoot.Checked)
            {
                bots.AutoLoot(true);
            }
            else
            {
                bots.AutoLoot(false);
            }
        }

        /// <summary>
        /// CPU-Related Hacks
        /// </summary>
        private void chkNoBackground_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNoBackground.Checked)
            {
                hacks.NoBackground(true);
            }
            else
            {
                hacks.NoBackground(false);
            }
        }

        private void chkNoDamageText_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNoDamageText.Checked)
            {
                hacks.NoDamageText(true);
            }
            else
            {
                hacks.NoDamageText(false);
            }
        }

        /// <summary>
        /// Character-Related Hacks
        /// </summary>
        private void chkStanceHack_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStanceHack.Checked)
            {
                hacks.StanceHack(true);
            }
            else
            {
                hacks.StanceHack(false);
            }
        }

        private void chkItemFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (chkItemFilter.Checked)
            {
                hacks.ItemFilter(true);
            }
            else
            {
                hacks.ItemFilter(false);
            }
        }

        private void chkPerfectLoot_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPerfectLoot.Checked)
            {
                hacks.PerfectLoot(true);
            }
            else
            {
                hacks.PerfectLoot(false);
            }
        }

        private void chkUnlimitedAttack_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUnlimitedAttack.Checked)
            {
                hacks.UnlimitedAttack(true);
            }
            else
            {
                hacks.UnlimitedAttack(false);
            }
        }

        /// <summary>
        /// Monster-Related Hacks
        /// </summary>
        private void chkMobFreeze_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMobFreeze.Checked)
            {
                hacks.MobFreeze(true);
            }
            else
            {
                hacks.MobFreeze(false);
            }
            chkMobVac.Enabled = !chkMobFreeze.Checked;
        }

        private void chkMobDisarm_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMobDisarm.Checked)
            {
                hacks.MobDisarm(true);
            }
            else
            {
                hacks.MobDisarm(false);
            }
        }

        private void chkMobItemVac_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMobItemVac.Checked)
            {
                hacks.MobItemVac(true);
            }
            else
            {
                hacks.MobItemVac(false);
            }
        }

        private void chkMobVac_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMobVac.Checked)
            {
                hacks.MobVac(true);
            }
            else
            {
                hacks.MobVac(false);
            }
            chkMobFreeze.Enabled = !chkMobVac.Checked;
        }

        private void cboMobVacType_SelectedIndexChanged(object sender, EventArgs e)
        {
            hacks.MobVac_SetType(cboMobVacType.SelectedIndex);
        }

        /// <summary>
        /// Misc. Hacks
        /// </summary>
        private void chkFullMapAttack_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFullMapAttack.Checked)
            {
                hacks.SkillInjection(1);
            }
            else
            {
                hacks.SkillInjection(0);
            }
            chkBossAttack.Enabled = !chkFullMapAttack.Checked;
            chkMobVac.Enabled = !chkFullMapAttack.Checked;
        }

        private void chkBossAttack_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBossAttack.Checked)
            {
                hacks.SkillInjection(2);
            }
            else
            {
                hacks.SkillInjection(0);
            }
            chkFullMapAttack.Enabled = !chkBossAttack.Checked;
            trbSkillInjectionSpeed.Enabled = !chkBossAttack.Checked;
        }

        private void trbFullMapAttackSpeed_Scroll(object sender, EventArgs e)
        {
            hacks.SkillInjection_SetSpeed(trbSkillInjectionSpeed.Value);
        }
    }
}
