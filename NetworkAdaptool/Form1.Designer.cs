namespace NetworkAdaptool
{
    partial class Form1
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.MenuBar = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEnable = new System.Windows.Forms.Button();
            this.btnDisable = new System.Windows.Forms.Button();
            this.btnRelease = new System.Windows.Forms.Button();
            this.btnRenew = new System.Windows.Forms.Button();
            this.btnRefreshAdapterList = new System.Windows.Forms.Button();
            this.btnDisableEnable = new System.Windows.Forms.Button();
            this.btnReleaseRenew = new System.Windows.Forms.Button();
            this.btnReleaseRenewAll = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxIPAddr = new System.Windows.Forms.TextBox();
            this.tbxSubnetMask = new System.Windows.Forms.TextBox();
            this.tbxDefaultGateway = new System.Windows.Forms.TextBox();
            this.rbtnStaticIP = new System.Windows.Forms.RadioButton();
            this.rbtnDHCP = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxDNS1 = new System.Windows.Forms.TextBox();
            this.tbxDNS2 = new System.Windows.Forms.TextBox();
            this.rbtnStaticDNS = new System.Windows.Forms.RadioButton();
            this.rbtnAutoDNS = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbxAdapterStatus = new System.Windows.Forms.TextBox();
            this.tbxAdapterType = new System.Windows.Forms.TextBox();
            this.tbxAdapterName = new System.Windows.Forms.TextBox();
            this.tbxNetConnectionID = new System.Windows.Forms.TextBox();
            this.tbxIsPhysical = new System.Windows.Forms.TextBox();
            this.tbxAdapterMACAddr = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbxLog = new System.Windows.Forms.TextBox();
            this.MenuBar.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 27);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(238, 316);
            this.listBox1.TabIndex = 0;
            // 
            // MenuBar
            // 
            this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.MenuBar.Location = new System.Drawing.Point(0, 0);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.Size = new System.Drawing.Size(1008, 24);
            this.MenuBar.TabIndex = 1;
            this.MenuBar.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profileManagerToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // profileManagerToolStripMenuItem
            // 
            this.profileManagerToolStripMenuItem.Name = "profileManagerToolStripMenuItem";
            this.profileManagerToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.profileManagerToolStripMenuItem.Text = "Profile Manager";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Location = new System.Drawing.Point(257, 146);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(492, 223);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IPV4 Settings";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbxAdapterMACAddr);
            this.groupBox2.Controls.Add(this.tbxIsPhysical);
            this.groupBox2.Controls.Add(this.tbxNetConnectionID);
            this.groupBox2.Controls.Add(this.tbxAdapterName);
            this.groupBox2.Controls.Add(this.tbxAdapterType);
            this.groupBox2.Controls.Add(this.tbxAdapterStatus);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(257, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(625, 112);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Adapter Information";
            // 
            // btnEnable
            // 
            this.btnEnable.Location = new System.Drawing.Point(889, 27);
            this.btnEnable.Name = "btnEnable";
            this.btnEnable.Size = new System.Drawing.Size(108, 23);
            this.btnEnable.TabIndex = 4;
            this.btnEnable.Text = "Enable Adapter";
            this.btnEnable.UseVisualStyleBackColor = true;
            // 
            // btnDisable
            // 
            this.btnDisable.Location = new System.Drawing.Point(889, 56);
            this.btnDisable.Name = "btnDisable";
            this.btnDisable.Size = new System.Drawing.Size(108, 23);
            this.btnDisable.TabIndex = 5;
            this.btnDisable.Text = "Disable Adapter";
            this.btnDisable.UseVisualStyleBackColor = true;
            // 
            // btnRelease
            // 
            this.btnRelease.Location = new System.Drawing.Point(758, 146);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(125, 23);
            this.btnRelease.TabIndex = 6;
            this.btnRelease.Text = "DHCP Release";
            this.btnRelease.UseVisualStyleBackColor = true;
            // 
            // btnRenew
            // 
            this.btnRenew.Location = new System.Drawing.Point(889, 146);
            this.btnRenew.Name = "btnRenew";
            this.btnRenew.Size = new System.Drawing.Size(108, 23);
            this.btnRenew.TabIndex = 7;
            this.btnRenew.Text = "DHCP Renew";
            this.btnRenew.UseVisualStyleBackColor = true;
            // 
            // btnRefreshAdapterList
            // 
            this.btnRefreshAdapterList.Location = new System.Drawing.Point(13, 346);
            this.btnRefreshAdapterList.Name = "btnRefreshAdapterList";
            this.btnRefreshAdapterList.Size = new System.Drawing.Size(237, 23);
            this.btnRefreshAdapterList.TabIndex = 8;
            this.btnRefreshAdapterList.Text = "Refresh Adapter List";
            this.btnRefreshAdapterList.UseVisualStyleBackColor = true;
            // 
            // btnDisableEnable
            // 
            this.btnDisableEnable.Location = new System.Drawing.Point(889, 85);
            this.btnDisableEnable.Name = "btnDisableEnable";
            this.btnDisableEnable.Size = new System.Drawing.Size(108, 23);
            this.btnDisableEnable.TabIndex = 9;
            this.btnDisableEnable.Text = "Restart Adapter";
            this.btnDisableEnable.UseVisualStyleBackColor = true;
            // 
            // btnReleaseRenew
            // 
            this.btnReleaseRenew.Location = new System.Drawing.Point(758, 175);
            this.btnReleaseRenew.Name = "btnReleaseRenew";
            this.btnReleaseRenew.Size = new System.Drawing.Size(124, 23);
            this.btnReleaseRenew.TabIndex = 10;
            this.btnReleaseRenew.Text = "Release Renew";
            this.btnReleaseRenew.UseVisualStyleBackColor = true;
            // 
            // btnReleaseRenewAll
            // 
            this.btnReleaseRenewAll.Location = new System.Drawing.Point(758, 204);
            this.btnReleaseRenewAll.Name = "btnReleaseRenewAll";
            this.btnReleaseRenewAll.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnReleaseRenewAll.Size = new System.Drawing.Size(124, 23);
            this.btnReleaseRenewAll.TabIndex = 11;
            this.btnReleaseRenewAll.Text = "Release Renew All";
            this.btnReleaseRenewAll.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbtnDHCP);
            this.groupBox3.Controls.Add(this.rbtnStaticIP);
            this.groupBox3.Controls.Add(this.tbxDefaultGateway);
            this.groupBox3.Controls.Add(this.tbxSubnetMask);
            this.groupBox3.Controls.Add(this.tbxIPAddr);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(7, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(473, 106);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "IP Settings";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbtnAutoDNS);
            this.groupBox4.Controls.Add(this.rbtnStaticDNS);
            this.groupBox4.Controls.Add(this.tbxDNS2);
            this.groupBox4.Controls.Add(this.tbxDNS1);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(7, 132);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(473, 79);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "DNS Settings";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Address (x.x.x.x)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Subnet Mask (x.x.x.x)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Default Gateway (x.x.x.x)";
            // 
            // tbxIPAddr
            // 
            this.tbxIPAddr.Location = new System.Drawing.Point(138, 20);
            this.tbxIPAddr.Name = "tbxIPAddr";
            this.tbxIPAddr.Size = new System.Drawing.Size(200, 20);
            this.tbxIPAddr.TabIndex = 3;
            // 
            // tbxSubnetMask
            // 
            this.tbxSubnetMask.Location = new System.Drawing.Point(138, 47);
            this.tbxSubnetMask.Name = "tbxSubnetMask";
            this.tbxSubnetMask.Size = new System.Drawing.Size(200, 20);
            this.tbxSubnetMask.TabIndex = 4;
            // 
            // tbxDefaultGateway
            // 
            this.tbxDefaultGateway.Location = new System.Drawing.Point(139, 73);
            this.tbxDefaultGateway.Name = "tbxDefaultGateway";
            this.tbxDefaultGateway.Size = new System.Drawing.Size(199, 20);
            this.tbxDefaultGateway.TabIndex = 5;
            // 
            // rbtnStaticIP
            // 
            this.rbtnStaticIP.AutoSize = true;
            this.rbtnStaticIP.Location = new System.Drawing.Point(344, 21);
            this.rbtnStaticIP.Name = "rbtnStaticIP";
            this.rbtnStaticIP.Size = new System.Drawing.Size(65, 17);
            this.rbtnStaticIP.TabIndex = 6;
            this.rbtnStaticIP.TabStop = true;
            this.rbtnStaticIP.Text = "Static IP";
            this.rbtnStaticIP.UseVisualStyleBackColor = true;
            // 
            // rbtnDHCP
            // 
            this.rbtnDHCP.AutoSize = true;
            this.rbtnDHCP.Location = new System.Drawing.Point(344, 44);
            this.rbtnDHCP.Name = "rbtnDHCP";
            this.rbtnDHCP.Size = new System.Drawing.Size(124, 17);
            this.rbtnDHCP.TabIndex = 7;
            this.rbtnDHCP.TabStop = true;
            this.rbtnDHCP.Text = "Automatic IP (DHCP)";
            this.rbtnDHCP.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Preferred DNS Server (x.x.x.x)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Alternate DNS Server (x.x.x.x)";
            // 
            // tbxDNS1
            // 
            this.tbxDNS1.Location = new System.Drawing.Point(167, 19);
            this.tbxDNS1.Name = "tbxDNS1";
            this.tbxDNS1.Size = new System.Drawing.Size(171, 20);
            this.tbxDNS1.TabIndex = 2;
            // 
            // tbxDNS2
            // 
            this.tbxDNS2.Location = new System.Drawing.Point(167, 46);
            this.tbxDNS2.Name = "tbxDNS2";
            this.tbxDNS2.Size = new System.Drawing.Size(171, 20);
            this.tbxDNS2.TabIndex = 3;
            // 
            // rbtnStaticDNS
            // 
            this.rbtnStaticDNS.AutoSize = true;
            this.rbtnStaticDNS.Location = new System.Drawing.Point(344, 19);
            this.rbtnStaticDNS.Name = "rbtnStaticDNS";
            this.rbtnStaticDNS.Size = new System.Drawing.Size(78, 17);
            this.rbtnStaticDNS.TabIndex = 4;
            this.rbtnStaticDNS.TabStop = true;
            this.rbtnStaticDNS.Text = "Static DNS";
            this.rbtnStaticDNS.UseVisualStyleBackColor = true;
            // 
            // rbtnAutoDNS
            // 
            this.rbtnAutoDNS.AutoSize = true;
            this.rbtnAutoDNS.Location = new System.Drawing.Point(344, 46);
            this.rbtnAutoDNS.Name = "rbtnAutoDNS";
            this.rbtnAutoDNS.Size = new System.Drawing.Size(98, 17);
            this.rbtnAutoDNS.TabIndex = 5;
            this.rbtnAutoDNS.TabStop = true;
            this.rbtnAutoDNS.Text = "Automatic DNS";
            this.rbtnAutoDNS.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Type";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Status";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(274, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "MAC Address";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(274, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "NetConnection ID";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(274, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Physical Adapter";
            // 
            // tbxAdapterStatus
            // 
            this.tbxAdapterStatus.Location = new System.Drawing.Point(50, 71);
            this.tbxAdapterStatus.Name = "tbxAdapterStatus";
            this.tbxAdapterStatus.ReadOnly = true;
            this.tbxAdapterStatus.Size = new System.Drawing.Size(209, 20);
            this.tbxAdapterStatus.TabIndex = 6;
            // 
            // tbxAdapterType
            // 
            this.tbxAdapterType.Location = new System.Drawing.Point(50, 45);
            this.tbxAdapterType.Name = "tbxAdapterType";
            this.tbxAdapterType.ReadOnly = true;
            this.tbxAdapterType.Size = new System.Drawing.Size(209, 20);
            this.tbxAdapterType.TabIndex = 7;
            // 
            // tbxAdapterName
            // 
            this.tbxAdapterName.Location = new System.Drawing.Point(50, 19);
            this.tbxAdapterName.Name = "tbxAdapterName";
            this.tbxAdapterName.ReadOnly = true;
            this.tbxAdapterName.Size = new System.Drawing.Size(209, 20);
            this.tbxAdapterName.TabIndex = 8;
            // 
            // tbxNetConnectionID
            // 
            this.tbxNetConnectionID.Location = new System.Drawing.Point(372, 71);
            this.tbxNetConnectionID.Name = "tbxNetConnectionID";
            this.tbxNetConnectionID.ReadOnly = true;
            this.tbxNetConnectionID.Size = new System.Drawing.Size(247, 20);
            this.tbxNetConnectionID.TabIndex = 9;
            // 
            // tbxIsPhysical
            // 
            this.tbxIsPhysical.Location = new System.Drawing.Point(372, 45);
            this.tbxIsPhysical.Name = "tbxIsPhysical";
            this.tbxIsPhysical.ReadOnly = true;
            this.tbxIsPhysical.Size = new System.Drawing.Size(247, 20);
            this.tbxIsPhysical.TabIndex = 10;
            // 
            // tbxAdapterMACAddr
            // 
            this.tbxAdapterMACAddr.Location = new System.Drawing.Point(372, 18);
            this.tbxAdapterMACAddr.Name = "tbxAdapterMACAddr";
            this.tbxAdapterMACAddr.ReadOnly = true;
            this.tbxAdapterMACAddr.Size = new System.Drawing.Size(247, 20);
            this.tbxAdapterMACAddr.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(755, 230);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(25, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Log";
            // 
            // tbxLog
            // 
            this.tbxLog.Location = new System.Drawing.Point(755, 251);
            this.tbxLog.MaxLength = 999999999;
            this.tbxLog.Multiline = true;
            this.tbxLog.Name = "tbxLog";
            this.tbxLog.Size = new System.Drawing.Size(241, 118);
            this.tbxLog.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 381);
            this.Controls.Add(this.tbxLog);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnReleaseRenewAll);
            this.Controls.Add(this.btnReleaseRenew);
            this.Controls.Add(this.btnDisableEnable);
            this.Controls.Add(this.btnRefreshAdapterList);
            this.Controls.Add(this.btnRenew);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.btnDisable);
            this.Controls.Add(this.btnEnable);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.MenuBar);
            this.MainMenuStrip = this.MenuBar;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.MenuStrip MenuBar;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profileManagerToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnEnable;
        private System.Windows.Forms.Button btnDisable;
        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.Button btnRenew;
        private System.Windows.Forms.Button btnRefreshAdapterList;
        private System.Windows.Forms.Button btnDisableEnable;
        private System.Windows.Forms.Button btnReleaseRenew;
        private System.Windows.Forms.Button btnReleaseRenewAll;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbtnDHCP;
        private System.Windows.Forms.RadioButton rbtnStaticIP;
        private System.Windows.Forms.TextBox tbxDefaultGateway;
        private System.Windows.Forms.TextBox tbxSubnetMask;
        private System.Windows.Forms.TextBox tbxIPAddr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtnAutoDNS;
        private System.Windows.Forms.RadioButton rbtnStaticDNS;
        private System.Windows.Forms.TextBox tbxDNS2;
        private System.Windows.Forms.TextBox tbxDNS1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxAdapterMACAddr;
        private System.Windows.Forms.TextBox tbxIsPhysical;
        private System.Windows.Forms.TextBox tbxNetConnectionID;
        private System.Windows.Forms.TextBox tbxAdapterName;
        private System.Windows.Forms.TextBox tbxAdapterType;
        private System.Windows.Forms.TextBox tbxAdapterStatus;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbxLog;
    }
}

