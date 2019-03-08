namespace MiniPayroll
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userRegisterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empSelaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empAttentdaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empAttentdanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selaryProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empSelaryToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.empAtttendaceReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paySlipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registiorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empAttenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateWiseReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userToolStripMenuItem,
            this.employeeToolStripMenuItem,
            this.reportToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.dateWiseReportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1028, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userRegisterToolStripMenuItem,
            this.changePasswordToolStripMenuItem});
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.userToolStripMenuItem.Text = "User";
            // 
            // userRegisterToolStripMenuItem
            // 
            this.userRegisterToolStripMenuItem.Name = "userRegisterToolStripMenuItem";
            this.userRegisterToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.userRegisterToolStripMenuItem.Text = "User Register";
            this.userRegisterToolStripMenuItem.Click += new System.EventHandler(this.userRegisterToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.changePasswordToolStripMenuItem.Text = "ChangePassword";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // employeeToolStripMenuItem
            // 
            this.employeeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addEmployeeToolStripMenuItem,
            this.empSelaryToolStripMenuItem,
            this.empAttentdaceToolStripMenuItem,
            this.empAttentdanceToolStripMenuItem,
            this.selaryProcessToolStripMenuItem});
            this.employeeToolStripMenuItem.Name = "employeeToolStripMenuItem";
            this.employeeToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.employeeToolStripMenuItem.Text = "Employee";
            // 
            // addEmployeeToolStripMenuItem
            // 
            this.addEmployeeToolStripMenuItem.Name = "addEmployeeToolStripMenuItem";
            this.addEmployeeToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.addEmployeeToolStripMenuItem.Text = "Add Employee";
            this.addEmployeeToolStripMenuItem.Click += new System.EventHandler(this.addEmployeeToolStripMenuItem_Click);
            // 
            // empSelaryToolStripMenuItem
            // 
            this.empSelaryToolStripMenuItem.Name = "empSelaryToolStripMenuItem";
            this.empSelaryToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.empSelaryToolStripMenuItem.Text = "EmpSelary";
            this.empSelaryToolStripMenuItem.Click += new System.EventHandler(this.empSelaryToolStripMenuItem_Click);
            // 
            // empAttentdaceToolStripMenuItem
            // 
            this.empAttentdaceToolStripMenuItem.Name = "empAttentdaceToolStripMenuItem";
            this.empAttentdaceToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.empAttentdaceToolStripMenuItem.Text = "EmpAttentdace";
            this.empAttentdaceToolStripMenuItem.Click += new System.EventHandler(this.empAttentdaceToolStripMenuItem_Click);
            // 
            // empAttentdanceToolStripMenuItem
            // 
            this.empAttentdanceToolStripMenuItem.Name = "empAttentdanceToolStripMenuItem";
            this.empAttentdanceToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.empAttentdanceToolStripMenuItem.Text = "EmpAttentdance View";
            this.empAttentdanceToolStripMenuItem.Click += new System.EventHandler(this.empAttentdanceToolStripMenuItem_Click);
            // 
            // selaryProcessToolStripMenuItem
            // 
            this.selaryProcessToolStripMenuItem.Name = "selaryProcessToolStripMenuItem";
            this.selaryProcessToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.selaryProcessToolStripMenuItem.Text = "Selary Process";
            this.selaryProcessToolStripMenuItem.Click += new System.EventHandler(this.selaryProcessToolStripMenuItem_Click);
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userReportToolStripMenuItem,
            this.empSelaryToolStripMenuItem1,
            this.empAtttendaceReportToolStripMenuItem,
            this.paySlipToolStripMenuItem,
            this.employeeReportToolStripMenuItem});
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.reportToolStripMenuItem.Text = "Report";
            // 
            // userReportToolStripMenuItem
            // 
            this.userReportToolStripMenuItem.Name = "userReportToolStripMenuItem";
            this.userReportToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.userReportToolStripMenuItem.Text = "UserReport";
            this.userReportToolStripMenuItem.Click += new System.EventHandler(this.userReportToolStripMenuItem_Click);
            // 
            // empSelaryToolStripMenuItem1
            // 
            this.empSelaryToolStripMenuItem1.Name = "empSelaryToolStripMenuItem1";
            this.empSelaryToolStripMenuItem1.Size = new System.Drawing.Size(194, 22);
            this.empSelaryToolStripMenuItem1.Text = "EmpSelary";
            this.empSelaryToolStripMenuItem1.Click += new System.EventHandler(this.empSelaryToolStripMenuItem1_Click);
            // 
            // empAtttendaceReportToolStripMenuItem
            // 
            this.empAtttendaceReportToolStripMenuItem.Name = "empAtttendaceReportToolStripMenuItem";
            this.empAtttendaceReportToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.empAtttendaceReportToolStripMenuItem.Text = "EmpAtttendace Report";
            this.empAtttendaceReportToolStripMenuItem.Click += new System.EventHandler(this.empAtttendaceReportToolStripMenuItem_Click);
            // 
            // paySlipToolStripMenuItem
            // 
            this.paySlipToolStripMenuItem.Name = "paySlipToolStripMenuItem";
            this.paySlipToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.paySlipToolStripMenuItem.Text = "PaySlip";
            this.paySlipToolStripMenuItem.Click += new System.EventHandler(this.paySlipToolStripMenuItem_Click);
            // 
            // employeeReportToolStripMenuItem
            // 
            this.employeeReportToolStripMenuItem.Name = "employeeReportToolStripMenuItem";
            this.employeeReportToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.employeeReportToolStripMenuItem.Text = "Employee Report";
            this.employeeReportToolStripMenuItem.Click += new System.EventHandler(this.employeeReportToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registiorToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // registiorToolStripMenuItem
            // 
            this.registiorToolStripMenuItem.Name = "registiorToolStripMenuItem";
            this.registiorToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.registiorToolStripMenuItem.Text = "Registior";
            this.registiorToolStripMenuItem.Click += new System.EventHandler(this.registiorToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.empAttenceToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // empAttenceToolStripMenuItem
            // 
            this.empAttenceToolStripMenuItem.Name = "empAttenceToolStripMenuItem";
            this.empAttenceToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.empAttenceToolStripMenuItem.Text = "EmpAttence";
            this.empAttenceToolStripMenuItem.Click += new System.EventHandler(this.empAttenceToolStripMenuItem_Click);
            // 
            // dateWiseReportToolStripMenuItem
            // 
            this.dateWiseReportToolStripMenuItem.Name = "dateWiseReportToolStripMenuItem";
            this.dateWiseReportToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.dateWiseReportToolStripMenuItem.Text = "Date wise Report";
            this.dateWiseReportToolStripMenuItem.Click += new System.EventHandler(this.dateWiseReportToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 491);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1028, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Login As:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Gainsboro;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(85, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Gainsboro;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(810, 32);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 0, 250, 0);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "label3";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Gainsboro;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(810, 67);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 0, 250, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Login As:";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 513);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "PayRoll ManageMent System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userRegisterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addEmployeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem empSelaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem empAttentdaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem empAttentdanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selaryProcessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem empSelaryToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem empAtttendaceReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paySlipToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registiorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem empAttenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dateWiseReportToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer1;
    }
}