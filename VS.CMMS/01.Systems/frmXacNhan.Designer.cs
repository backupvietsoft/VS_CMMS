namespace VS.CMMS
{
    partial class frmXacNhan
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
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.txtPASSWORD = new DevExpress.XtraEditors.TextEdit();
            this.txtUSER_NAME = new DevExpress.XtraEditors.TextEdit();
            this.btnXacNhan = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lblUSER_NAME = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblPASSWORD = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.textEdit11 = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPASSWORD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUSER_NAME.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUSER_NAME)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPASSWORD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit11.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.txtPASSWORD);
            this.dataLayoutControl1.Controls.Add(this.txtUSER_NAME);
            this.dataLayoutControl1.Controls.Add(this.btnXacNhan);
            this.dataLayoutControl1.Controls.Add(this.textEdit11);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(420, 152);
            this.dataLayoutControl1.TabIndex = 1;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // txtPASSWORD
            // 
            this.txtPASSWORD.Location = new System.Drawing.Point(117, 36);
            this.txtPASSWORD.Name = "txtPASSWORD";
            this.txtPASSWORD.Properties.UseSystemPasswordChar = true;
            this.txtPASSWORD.Size = new System.Drawing.Size(291, 20);
            this.txtPASSWORD.StyleController = this.dataLayoutControl1;
            this.txtPASSWORD.TabIndex = 7;
            // 
            // txtUSER_NAME
            // 
            this.txtUSER_NAME.Location = new System.Drawing.Point(117, 12);
            this.txtUSER_NAME.Name = "txtUSER_NAME";
            this.txtUSER_NAME.Size = new System.Drawing.Size(291, 20);
            this.txtUSER_NAME.StyleController = this.dataLayoutControl1;
            this.txtUSER_NAME.TabIndex = 5;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(304, 110);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(104, 30);
            this.btnXacNhan.StyleController = this.dataLayoutControl1;
            this.btnXacNhan.TabIndex = 13;
            this.btnXacNhan.Text = "btnXacNhan";
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lblUSER_NAME,
            this.lblPASSWORD,
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.layoutControlItem9,
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(420, 152);
            this.Root.TextVisible = false;
            // 
            // lblUSER_NAME
            // 
            this.lblUSER_NAME.Control = this.txtUSER_NAME;
            this.lblUSER_NAME.Location = new System.Drawing.Point(0, 0);
            this.lblUSER_NAME.Name = "lblUSER_NAME";
            this.lblUSER_NAME.Size = new System.Drawing.Size(400, 24);
            this.lblUSER_NAME.TextSize = new System.Drawing.Size(93, 13);
            // 
            // lblPASSWORD
            // 
            this.lblPASSWORD.Control = this.txtPASSWORD;
            this.lblPASSWORD.Location = new System.Drawing.Point(0, 24);
            this.lblPASSWORD.Name = "lblPASSWORD";
            this.lblPASSWORD.Size = new System.Drawing.Size(400, 24);
            this.lblPASSWORD.TextSize = new System.Drawing.Size(93, 13);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 48);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(400, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 98);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(292, 34);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.btnXacNhan;
            this.layoutControlItem9.Location = new System.Drawing.Point(292, 98);
            this.layoutControlItem9.MaxSize = new System.Drawing.Size(108, 34);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(1, 34);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(108, 34);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // textEdit11
            // 
            this.textEdit11.Location = new System.Drawing.Point(117, 86);
            this.textEdit11.Name = "textEdit11";
            this.textEdit11.Size = new System.Drawing.Size(291, 20);
            this.textEdit11.StyleController = this.dataLayoutControl1;
            this.textEdit11.TabIndex = 15;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.textEdit11;
            this.layoutControlItem1.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 74);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(400, 24);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(93, 13);
            this.layoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // frmXacNhan
            // 
            this.ClientSize = new System.Drawing.Size(420, 152);
            this.Controls.Add(this.dataLayoutControl1);
            this.KeyPreview = true;
            this.Name = "frmXacNhan";
            this.Text = "frmXacNhan";
            this.Load += new System.EventHandler(this.frmXacNhan_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmXacNhan_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPASSWORD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUSER_NAME.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUSER_NAME)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPASSWORD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit11.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.TextEdit txtUSER_NAME;
        private DevExpress.XtraEditors.SimpleButton btnXacNhan;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem lblUSER_NAME;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraEditors.TextEdit txtPASSWORD;
        private DevExpress.XtraLayout.LayoutControlItem lblPASSWORD;
        private DevExpress.XtraEditors.TextEdit textEdit11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}