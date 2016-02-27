namespace PerfectMSEA
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.chkFullMapAttack = new System.Windows.Forms.CheckBox();
            this.chkMobItemVac = new System.Windows.Forms.CheckBox();
            this.chkStanceHack = new System.Windows.Forms.CheckBox();
            this.chkBossAttack = new System.Windows.Forms.CheckBox();
            this.chkItemFilter = new System.Windows.Forms.CheckBox();
            this.trbSkillInjectionSpeed = new System.Windows.Forms.TrackBar();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblPeopleCount = new System.Windows.Forms.Label();
            this.lblMobCount = new System.Windows.Forms.Label();
            this.groupInformation = new System.Windows.Forms.GroupBox();
            this.groupSkillInjection = new System.Windows.Forms.GroupBox();
            this.lblSkillInjectionSpeed = new System.Windows.Forms.Label();
            this.groupCPUHacks = new System.Windows.Forms.GroupBox();
            this.chkNoDamageText = new System.Windows.Forms.CheckBox();
            this.chkNoBackground = new System.Windows.Forms.CheckBox();
            this.groupMobHacks = new System.Windows.Forms.GroupBox();
            this.cboMobVacType = new System.Windows.Forms.ComboBox();
            this.chkMobVac = new System.Windows.Forms.CheckBox();
            this.chkMobDisarm = new System.Windows.Forms.CheckBox();
            this.chkMobFreeze = new System.Windows.Forms.CheckBox();
            this.groupCharHacks = new System.Windows.Forms.GroupBox();
            this.chkUnlimitedAttack = new System.Windows.Forms.CheckBox();
            this.chkPerfectLoot = new System.Windows.Forms.CheckBox();
            this.tmrManager = new System.Windows.Forms.Timer(this.components);
            this.tmrInformation = new System.Windows.Forms.Timer(this.components);
            this.btnStartMaple = new System.Windows.Forms.Button();
            this.txtMapleDirectory = new System.Windows.Forms.TextBox();
            this.lblMapleDirectory = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAutoLoot = new System.Windows.Forms.CheckBox();
            this.btnRestoreMaple = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trbSkillInjectionSpeed)).BeginInit();
            this.groupInformation.SuspendLayout();
            this.groupSkillInjection.SuspendLayout();
            this.groupCPUHacks.SuspendLayout();
            this.groupMobHacks.SuspendLayout();
            this.groupCharHacks.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkFullMapAttack
            // 
            this.chkFullMapAttack.AutoSize = true;
            this.chkFullMapAttack.Enabled = false;
            this.chkFullMapAttack.Location = new System.Drawing.Point(17, 28);
            this.chkFullMapAttack.Name = "chkFullMapAttack";
            this.chkFullMapAttack.Size = new System.Drawing.Size(100, 17);
            this.chkFullMapAttack.TabIndex = 0;
            this.chkFullMapAttack.Text = "Full Map Attack";
            this.chkFullMapAttack.UseVisualStyleBackColor = true;
            this.chkFullMapAttack.CheckedChanged += new System.EventHandler(this.chkFullMapAttack_CheckedChanged);
            // 
            // chkMobItemVac
            // 
            this.chkMobItemVac.AutoSize = true;
            this.chkMobItemVac.Enabled = false;
            this.chkMobItemVac.Location = new System.Drawing.Point(10, 69);
            this.chkMobItemVac.Name = "chkMobItemVac";
            this.chkMobItemVac.Size = new System.Drawing.Size(92, 17);
            this.chkMobItemVac.TabIndex = 2;
            this.chkMobItemVac.Text = "Mob Item Vac";
            this.chkMobItemVac.UseVisualStyleBackColor = true;
            this.chkMobItemVac.CheckedChanged += new System.EventHandler(this.chkMobItemVac_CheckedChanged);
            // 
            // chkStanceHack
            // 
            this.chkStanceHack.AutoSize = true;
            this.chkStanceHack.Enabled = false;
            this.chkStanceHack.Location = new System.Drawing.Point(9, 19);
            this.chkStanceHack.Name = "chkStanceHack";
            this.chkStanceHack.Size = new System.Drawing.Size(89, 17);
            this.chkStanceHack.TabIndex = 5;
            this.chkStanceHack.Text = "Stance Hack";
            this.chkStanceHack.UseVisualStyleBackColor = true;
            this.chkStanceHack.CheckedChanged += new System.EventHandler(this.chkStanceHack_CheckedChanged);
            // 
            // chkBossAttack
            // 
            this.chkBossAttack.AutoSize = true;
            this.chkBossAttack.Enabled = false;
            this.chkBossAttack.Location = new System.Drawing.Point(17, 51);
            this.chkBossAttack.Name = "chkBossAttack";
            this.chkBossAttack.Size = new System.Drawing.Size(83, 17);
            this.chkBossAttack.TabIndex = 3;
            this.chkBossAttack.Text = "Boss Attack";
            this.chkBossAttack.UseVisualStyleBackColor = true;
            this.chkBossAttack.CheckedChanged += new System.EventHandler(this.chkBossAttack_CheckedChanged);
            // 
            // chkItemFilter
            // 
            this.chkItemFilter.AutoSize = true;
            this.chkItemFilter.Enabled = false;
            this.chkItemFilter.Location = new System.Drawing.Point(9, 41);
            this.chkItemFilter.Name = "chkItemFilter";
            this.chkItemFilter.Size = new System.Drawing.Size(71, 17);
            this.chkItemFilter.TabIndex = 6;
            this.chkItemFilter.Text = "Item Filter";
            this.chkItemFilter.UseVisualStyleBackColor = true;
            this.chkItemFilter.CheckedChanged += new System.EventHandler(this.chkItemFilter_CheckedChanged);
            // 
            // trbSkillInjectionSpeed
            // 
            this.trbSkillInjectionSpeed.Location = new System.Drawing.Point(6, 86);
            this.trbSkillInjectionSpeed.Maximum = 4;
            this.trbSkillInjectionSpeed.Name = "trbSkillInjectionSpeed";
            this.trbSkillInjectionSpeed.Size = new System.Drawing.Size(122, 45);
            this.trbSkillInjectionSpeed.TabIndex = 7;
            this.trbSkillInjectionSpeed.Value = 1;
            this.trbSkillInjectionSpeed.Scroll += new System.EventHandler(this.trbFullMapAttackSpeed_Scroll);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(238, 356);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(43, 23);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblPeopleCount
            // 
            this.lblPeopleCount.AutoSize = true;
            this.lblPeopleCount.Location = new System.Drawing.Point(14, 26);
            this.lblPeopleCount.Name = "lblPeopleCount";
            this.lblPeopleCount.Size = new System.Drawing.Size(86, 13);
            this.lblPeopleCount.TabIndex = 9;
            this.lblPeopleCount.Text = "People Count: -1";
            // 
            // lblMobCount
            // 
            this.lblMobCount.AutoSize = true;
            this.lblMobCount.Location = new System.Drawing.Point(14, 52);
            this.lblMobCount.Name = "lblMobCount";
            this.lblMobCount.Size = new System.Drawing.Size(74, 13);
            this.lblMobCount.TabIndex = 10;
            this.lblMobCount.Text = "Mob Count: -1";
            // 
            // groupInformation
            // 
            this.groupInformation.Controls.Add(this.lblPeopleCount);
            this.groupInformation.Controls.Add(this.lblMobCount);
            this.groupInformation.Location = new System.Drawing.Point(12, 12);
            this.groupInformation.Name = "groupInformation";
            this.groupInformation.Size = new System.Drawing.Size(134, 84);
            this.groupInformation.TabIndex = 11;
            this.groupInformation.TabStop = false;
            this.groupInformation.Text = "Information";
            // 
            // groupSkillInjection
            // 
            this.groupSkillInjection.Controls.Add(this.lblSkillInjectionSpeed);
            this.groupSkillInjection.Controls.Add(this.chkFullMapAttack);
            this.groupSkillInjection.Controls.Add(this.chkBossAttack);
            this.groupSkillInjection.Controls.Add(this.trbSkillInjectionSpeed);
            this.groupSkillInjection.Location = new System.Drawing.Point(12, 149);
            this.groupSkillInjection.Name = "groupSkillInjection";
            this.groupSkillInjection.Size = new System.Drawing.Size(134, 159);
            this.groupSkillInjection.TabIndex = 12;
            this.groupSkillInjection.TabStop = false;
            this.groupSkillInjection.Text = "Skill Injection";
            // 
            // lblSkillInjectionSpeed
            // 
            this.lblSkillInjectionSpeed.AutoSize = true;
            this.lblSkillInjectionSpeed.Location = new System.Drawing.Point(6, 118);
            this.lblSkillInjectionSpeed.Name = "lblSkillInjectionSpeed";
            this.lblSkillInjectionSpeed.Size = new System.Drawing.Size(122, 13);
            this.lblSkillInjectionSpeed.TabIndex = 8;
            this.lblSkillInjectionSpeed.Text = "Fast                        Slow";
            // 
            // groupCPUHacks
            // 
            this.groupCPUHacks.Controls.Add(this.chkNoDamageText);
            this.groupCPUHacks.Controls.Add(this.chkNoBackground);
            this.groupCPUHacks.Location = new System.Drawing.Point(152, 12);
            this.groupCPUHacks.Name = "groupCPUHacks";
            this.groupCPUHacks.Size = new System.Drawing.Size(126, 65);
            this.groupCPUHacks.TabIndex = 13;
            this.groupCPUHacks.TabStop = false;
            this.groupCPUHacks.Text = "CPU-Related";
            // 
            // chkNoDamageText
            // 
            this.chkNoDamageText.AutoSize = true;
            this.chkNoDamageText.Enabled = false;
            this.chkNoDamageText.Location = new System.Drawing.Point(6, 42);
            this.chkNoDamageText.Name = "chkNoDamageText";
            this.chkNoDamageText.Size = new System.Drawing.Size(107, 17);
            this.chkNoDamageText.TabIndex = 1;
            this.chkNoDamageText.Text = "No Damage Text";
            this.chkNoDamageText.UseVisualStyleBackColor = true;
            this.chkNoDamageText.CheckedChanged += new System.EventHandler(this.chkNoDamageText_CheckedChanged);
            // 
            // chkNoBackground
            // 
            this.chkNoBackground.AutoSize = true;
            this.chkNoBackground.Enabled = false;
            this.chkNoBackground.Location = new System.Drawing.Point(6, 19);
            this.chkNoBackground.Name = "chkNoBackground";
            this.chkNoBackground.Size = new System.Drawing.Size(101, 17);
            this.chkNoBackground.TabIndex = 0;
            this.chkNoBackground.Text = "No Background";
            this.chkNoBackground.UseVisualStyleBackColor = true;
            this.chkNoBackground.CheckedChanged += new System.EventHandler(this.chkNoBackground_CheckedChanged);
            // 
            // groupMobHacks
            // 
            this.groupMobHacks.Controls.Add(this.cboMobVacType);
            this.groupMobHacks.Controls.Add(this.chkMobVac);
            this.groupMobHacks.Controls.Add(this.chkMobDisarm);
            this.groupMobHacks.Controls.Add(this.chkMobFreeze);
            this.groupMobHacks.Controls.Add(this.chkMobItemVac);
            this.groupMobHacks.Location = new System.Drawing.Point(152, 186);
            this.groupMobHacks.Name = "groupMobHacks";
            this.groupMobHacks.Size = new System.Drawing.Size(127, 122);
            this.groupMobHacks.TabIndex = 14;
            this.groupMobHacks.TabStop = false;
            this.groupMobHacks.Text = "Mob-Related Hacks";
            // 
            // cboMobVacType
            // 
            this.cboMobVacType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMobVacType.FormattingEnabled = true;
            this.cboMobVacType.Items.AddRange(new object[] {
            "Left",
            "Right"});
            this.cboMobVacType.Location = new System.Drawing.Point(75, 88);
            this.cboMobVacType.Name = "cboMobVacType";
            this.cboMobVacType.Size = new System.Drawing.Size(46, 21);
            this.cboMobVacType.TabIndex = 10;
            this.cboMobVacType.SelectedIndexChanged += new System.EventHandler(this.cboMobVacType_SelectedIndexChanged);
            // 
            // chkMobVac
            // 
            this.chkMobVac.AutoSize = true;
            this.chkMobVac.Enabled = false;
            this.chkMobVac.Location = new System.Drawing.Point(10, 92);
            this.chkMobVac.Name = "chkMobVac";
            this.chkMobVac.Size = new System.Drawing.Size(69, 17);
            this.chkMobVac.TabIndex = 9;
            this.chkMobVac.Text = "Mob Vac";
            this.chkMobVac.UseVisualStyleBackColor = true;
            this.chkMobVac.CheckedChanged += new System.EventHandler(this.chkMobVac_CheckedChanged);
            // 
            // chkMobDisarm
            // 
            this.chkMobDisarm.AutoSize = true;
            this.chkMobDisarm.Enabled = false;
            this.chkMobDisarm.Location = new System.Drawing.Point(10, 46);
            this.chkMobDisarm.Name = "chkMobDisarm";
            this.chkMobDisarm.Size = new System.Drawing.Size(82, 17);
            this.chkMobDisarm.TabIndex = 8;
            this.chkMobDisarm.Text = "Mob Disarm";
            this.chkMobDisarm.UseVisualStyleBackColor = true;
            this.chkMobDisarm.CheckedChanged += new System.EventHandler(this.chkMobDisarm_CheckedChanged);
            // 
            // chkMobFreeze
            // 
            this.chkMobFreeze.AutoSize = true;
            this.chkMobFreeze.Enabled = false;
            this.chkMobFreeze.Location = new System.Drawing.Point(10, 23);
            this.chkMobFreeze.Name = "chkMobFreeze";
            this.chkMobFreeze.Size = new System.Drawing.Size(82, 17);
            this.chkMobFreeze.TabIndex = 7;
            this.chkMobFreeze.Text = "Mob Freeze";
            this.chkMobFreeze.UseVisualStyleBackColor = true;
            this.chkMobFreeze.CheckedChanged += new System.EventHandler(this.chkMobFreeze_CheckedChanged);
            // 
            // groupCharHacks
            // 
            this.groupCharHacks.Controls.Add(this.chkUnlimitedAttack);
            this.groupCharHacks.Controls.Add(this.chkPerfectLoot);
            this.groupCharHacks.Controls.Add(this.chkStanceHack);
            this.groupCharHacks.Controls.Add(this.chkItemFilter);
            this.groupCharHacks.Location = new System.Drawing.Point(152, 77);
            this.groupCharHacks.Name = "groupCharHacks";
            this.groupCharHacks.Size = new System.Drawing.Size(126, 110);
            this.groupCharHacks.TabIndex = 15;
            this.groupCharHacks.TabStop = false;
            this.groupCharHacks.Text = "Character-Related";
            // 
            // chkUnlimitedAttack
            // 
            this.chkUnlimitedAttack.AutoSize = true;
            this.chkUnlimitedAttack.Enabled = false;
            this.chkUnlimitedAttack.Location = new System.Drawing.Point(9, 85);
            this.chkUnlimitedAttack.Name = "chkUnlimitedAttack";
            this.chkUnlimitedAttack.Size = new System.Drawing.Size(103, 17);
            this.chkUnlimitedAttack.TabIndex = 8;
            this.chkUnlimitedAttack.Text = "Unlimited Attack";
            this.chkUnlimitedAttack.UseVisualStyleBackColor = true;
            this.chkUnlimitedAttack.CheckedChanged += new System.EventHandler(this.chkUnlimitedAttack_CheckedChanged);
            // 
            // chkPerfectLoot
            // 
            this.chkPerfectLoot.AutoSize = true;
            this.chkPerfectLoot.Enabled = false;
            this.chkPerfectLoot.Location = new System.Drawing.Point(9, 62);
            this.chkPerfectLoot.Name = "chkPerfectLoot";
            this.chkPerfectLoot.Size = new System.Drawing.Size(84, 17);
            this.chkPerfectLoot.TabIndex = 7;
            this.chkPerfectLoot.Text = "Perfect Loot";
            this.chkPerfectLoot.UseVisualStyleBackColor = true;
            this.chkPerfectLoot.CheckedChanged += new System.EventHandler(this.chkPerfectLoot_CheckedChanged);
            // 
            // tmrManager
            // 
            this.tmrManager.Enabled = true;
            this.tmrManager.Interval = 1000;
            this.tmrManager.Tick += new System.EventHandler(this.tmrManager_Tick);
            // 
            // tmrInformation
            // 
            this.tmrInformation.Interval = 200;
            this.tmrInformation.Tick += new System.EventHandler(this.tmrInformation_Tick);
            // 
            // btnStartMaple
            // 
            this.btnStartMaple.Enabled = false;
            this.btnStartMaple.Location = new System.Drawing.Point(14, 356);
            this.btnStartMaple.Name = "btnStartMaple";
            this.btnStartMaple.Size = new System.Drawing.Size(100, 23);
            this.btnStartMaple.TabIndex = 16;
            this.btnStartMaple.Text = "Start MapleStory";
            this.btnStartMaple.UseVisualStyleBackColor = true;
            this.btnStartMaple.Click += new System.EventHandler(this.btnStartMaple_Click);
            // 
            // txtMapleDirectory
            // 
            this.txtMapleDirectory.Location = new System.Drawing.Point(14, 330);
            this.txtMapleDirectory.Name = "txtMapleDirectory";
            this.txtMapleDirectory.Size = new System.Drawing.Size(266, 20);
            this.txtMapleDirectory.TabIndex = 19;
            this.txtMapleDirectory.Click += new System.EventHandler(this.txtMapleDirectory_Click);
            this.txtMapleDirectory.TextChanged += new System.EventHandler(this.txtMapleDirectory_TextChanged);
            // 
            // lblMapleDirectory
            // 
            this.lblMapleDirectory.AutoSize = true;
            this.lblMapleDirectory.Location = new System.Drawing.Point(86, 314);
            this.lblMapleDirectory.Name = "lblMapleDirectory";
            this.lblMapleDirectory.Size = new System.Drawing.Size(132, 13);
            this.lblMapleDirectory.TabIndex = 18;
            this.lblMapleDirectory.Text = "MapleStorySEA Directory: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAutoLoot);
            this.groupBox1.Location = new System.Drawing.Point(12, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(134, 41);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bot Functions";
            // 
            // chkAutoLoot
            // 
            this.chkAutoLoot.AutoSize = true;
            this.chkAutoLoot.Enabled = false;
            this.chkAutoLoot.Location = new System.Drawing.Point(17, 20);
            this.chkAutoLoot.Name = "chkAutoLoot";
            this.chkAutoLoot.Size = new System.Drawing.Size(72, 17);
            this.chkAutoLoot.TabIndex = 0;
            this.chkAutoLoot.Text = "Auto Loot";
            this.chkAutoLoot.UseVisualStyleBackColor = true;
            this.chkAutoLoot.CheckedChanged += new System.EventHandler(this.chkAutoLoot_CheckedChanged);
            // 
            // btnRestoreMaple
            // 
            this.btnRestoreMaple.Location = new System.Drawing.Point(120, 356);
            this.btnRestoreMaple.Name = "btnRestoreMaple";
            this.btnRestoreMaple.Size = new System.Drawing.Size(112, 23);
            this.btnRestoreMaple.TabIndex = 21;
            this.btnRestoreMaple.Text = "Restore MapleStory";
            this.btnRestoreMaple.UseVisualStyleBackColor = true;
            this.btnRestoreMaple.Click += new System.EventHandler(this.btnRestoreMaple_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 388);
            this.ControlBox = false;
            this.Controls.Add(this.btnRestoreMaple);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblMapleDirectory);
            this.Controls.Add(this.groupCharHacks);
            this.Controls.Add(this.txtMapleDirectory);
            this.Controls.Add(this.btnStartMaple);
            this.Controls.Add(this.groupMobHacks);
            this.Controls.Add(this.groupCPUHacks);
            this.Controls.Add(this.groupSkillInjection);
            this.Controls.Add(this.groupInformation);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PerfectMSEA";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trbSkillInjectionSpeed)).EndInit();
            this.groupInformation.ResumeLayout(false);
            this.groupInformation.PerformLayout();
            this.groupSkillInjection.ResumeLayout(false);
            this.groupSkillInjection.PerformLayout();
            this.groupCPUHacks.ResumeLayout(false);
            this.groupCPUHacks.PerformLayout();
            this.groupMobHacks.ResumeLayout(false);
            this.groupMobHacks.PerformLayout();
            this.groupCharHacks.ResumeLayout(false);
            this.groupCharHacks.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkFullMapAttack;
        private System.Windows.Forms.CheckBox chkMobItemVac;
        private System.Windows.Forms.CheckBox chkStanceHack;
        private System.Windows.Forms.CheckBox chkBossAttack;
        private System.Windows.Forms.CheckBox chkItemFilter;
        private System.Windows.Forms.TrackBar trbSkillInjectionSpeed;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblPeopleCount;
        private System.Windows.Forms.Label lblMobCount;
        private System.Windows.Forms.GroupBox groupInformation;
        private System.Windows.Forms.GroupBox groupSkillInjection;
        private System.Windows.Forms.Label lblSkillInjectionSpeed;
        private System.Windows.Forms.GroupBox groupCPUHacks;
        private System.Windows.Forms.CheckBox chkNoDamageText;
        private System.Windows.Forms.CheckBox chkNoBackground;
        private System.Windows.Forms.GroupBox groupMobHacks;
        private System.Windows.Forms.CheckBox chkMobDisarm;
        private System.Windows.Forms.CheckBox chkMobFreeze;
        private System.Windows.Forms.GroupBox groupCharHacks;
        private System.Windows.Forms.CheckBox chkPerfectLoot;
        private System.Windows.Forms.Timer tmrManager;
        private System.Windows.Forms.Timer tmrInformation;
        private System.Windows.Forms.Button btnStartMaple;
        private System.Windows.Forms.TextBox txtMapleDirectory;
        private System.Windows.Forms.Label lblMapleDirectory;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkAutoLoot;
        private System.Windows.Forms.Button btnRestoreMaple;
        private System.Windows.Forms.CheckBox chkMobVac;
        private System.Windows.Forms.ComboBox cboMobVacType;
        private System.Windows.Forms.CheckBox chkUnlimitedAttack;
    }
}

