namespace VS.CMMS
{
    partial class frmKho
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
            this.treKho = new DevExpress.XtraTreeList.TreeList();
            this.btnLK_DN_DX = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnThemKho = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciThemKho = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lciLK_DN_DX = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciKHo = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treKho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciThemKho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLK_DN_DX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciKHo)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.treKho);
            this.dataLayoutControl1.Controls.Add(this.btnLK_DN_DX);
            this.dataLayoutControl1.Controls.Add(this.btnThoat);
            this.dataLayoutControl1.Controls.Add(this.btnThemKho);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(973, 566);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // treKho
            // 
            this.treKho.Location = new System.Drawing.Point(12, 12);
            this.treKho.Name = "treKho";
            this.treKho.Size = new System.Drawing.Size(949, 504);
            this.treKho.TabIndex = 15;
            // 
            // btnLK_DN_DX
            // 
            this.btnLK_DN_DX.Location = new System.Drawing.Point(12, 520);
            this.btnLK_DN_DX.Name = "btnLK_DN_DX";
            this.btnLK_DN_DX.Size = new System.Drawing.Size(110, 34);
            this.btnLK_DN_DX.StyleController = this.dataLayoutControl1;
            this.btnLK_DN_DX.TabIndex = 14;
            this.btnLK_DN_DX.Text = "btnLK_DN_DX";
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(851, 520);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(110, 34);
            this.btnThoat.StyleController = this.dataLayoutControl1;
            this.btnThoat.TabIndex = 12;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnThemKho
            // 
            this.btnThemKho.Location = new System.Drawing.Point(737, 520);
            this.btnThemKho.Name = "btnThemKho";
            this.btnThemKho.Size = new System.Drawing.Size(110, 34);
            this.btnThemKho.StyleController = this.dataLayoutControl1;
            this.btnThemKho.TabIndex = 11;
            this.btnThemKho.Text = "btnThemKho";
            this.btnThemKho.Click += new System.EventHandler(this.btnThemKho_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem9,
            this.lciThemKho,
            this.emptySpaceItem2,
            this.lciLK_DN_DX,
            this.lciKHo});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(973, 566);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.btnThoat;
            this.layoutControlItem9.Location = new System.Drawing.Point(839, 508);
            this.layoutControlItem9.MaxSize = new System.Drawing.Size(114, 38);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(114, 38);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(114, 38);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // lciThemKho
            // 
            this.lciThemKho.Control = this.btnThemKho;
            this.lciThemKho.Location = new System.Drawing.Point(725, 508);
            this.lciThemKho.MaxSize = new System.Drawing.Size(114, 38);
            this.lciThemKho.MinSize = new System.Drawing.Size(114, 38);
            this.lciThemKho.Name = "lciThemKho";
            this.lciThemKho.Size = new System.Drawing.Size(114, 38);
            this.lciThemKho.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciThemKho.TextSize = new System.Drawing.Size(0, 0);
            this.lciThemKho.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(114, 508);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(611, 38);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lciLK_DN_DX
            // 
            this.lciLK_DN_DX.Control = this.btnLK_DN_DX;
            this.lciLK_DN_DX.Location = new System.Drawing.Point(0, 508);
            this.lciLK_DN_DX.MaxSize = new System.Drawing.Size(114, 38);
            this.lciLK_DN_DX.MinSize = new System.Drawing.Size(114, 38);
            this.lciLK_DN_DX.Name = "lciLK_DN_DX";
            this.lciLK_DN_DX.Size = new System.Drawing.Size(114, 38);
            this.lciLK_DN_DX.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciLK_DN_DX.TextSize = new System.Drawing.Size(0, 0);
            this.lciLK_DN_DX.TextVisible = false;
            this.lciLK_DN_DX.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // lciKHo
            // 
            this.lciKHo.Control = this.treKho;
            this.lciKHo.Location = new System.Drawing.Point(0, 0);
            this.lciKHo.Name = "lciKHo";
            this.lciKHo.Size = new System.Drawing.Size(953, 508);
            this.lciKHo.TextSize = new System.Drawing.Size(0, 0);
            this.lciKHo.TextVisible = false;
            // 
            // frmKho
            // 
            this.ClientSize = new System.Drawing.Size(973, 566);
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "frmKho";
            this.Text = "frmKho";
            this.Load += new System.EventHandler(this.frmKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treKho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciThemKho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLK_DN_DX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciKHo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnThemKho;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem lciThemKho;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.SimpleButton btnLK_DN_DX;
        private DevExpress.XtraLayout.LayoutControlItem lciLK_DN_DX;
        private DevExpress.XtraTreeList.TreeList treKho;
        private DevExpress.XtraLayout.LayoutControlItem lciKHo;
    }
}