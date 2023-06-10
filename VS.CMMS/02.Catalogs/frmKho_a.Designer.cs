namespace VS.CMMS
{
    partial class frmKho_a
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
            this.grdChung = new DevExpress.XtraGrid.GridControl();
            this.grvChung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnThemKho = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciThemKho = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciThemKho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.grdChung);
            this.dataLayoutControl1.Controls.Add(this.btnThoat);
            this.dataLayoutControl1.Controls.Add(this.btnThemKho);
            this.dataLayoutControl1.Controls.Add(this.btnXoa);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(973, 566);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // grdChung
            // 
            this.grdChung.Location = new System.Drawing.Point(12, 12);
            this.grdChung.MainView = this.grvChung;
            this.grdChung.Name = "grdChung";
            this.grdChung.Size = new System.Drawing.Size(949, 503);
            this.grdChung.TabIndex = 3;
            this.grdChung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvChung});
            // 
            // grvChung
            // 
            this.grvChung.DetailHeight = 861;
            this.grvChung.FixedLineWidth = 4;
            this.grvChung.GridControl = this.grdChung;
            this.grvChung.Name = "grvChung";
            this.grvChung.OptionsView.RowAutoHeight = true;
            this.grvChung.OptionsView.ShowGroupPanel = false;
            this.grvChung.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.grvChung_PopupMenuShowing);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(851, 519);
            this.btnThoat.MaximumSize = new System.Drawing.Size(112, 36);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(110, 35);
            this.btnThoat.StyleController = this.dataLayoutControl1;
            this.btnThoat.TabIndex = 12;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnThemKho
            // 
            this.btnThemKho.Location = new System.Drawing.Point(735, 519);
            this.btnThemKho.MaximumSize = new System.Drawing.Size(112, 36);
            this.btnThemKho.Name = "btnThemKho";
            this.btnThemKho.Size = new System.Drawing.Size(112, 35);
            this.btnThemKho.StyleController = this.dataLayoutControl1;
            this.btnThemKho.TabIndex = 11;
            this.btnThemKho.Text = "btnThemKho";
            this.btnThemKho.Click += new System.EventHandler(this.btnThemKho_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(621, 519);
            this.btnXoa.MaximumSize = new System.Drawing.Size(112, 36);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(110, 35);
            this.btnXoa.StyleController = this.dataLayoutControl1;
            this.btnXoa.TabIndex = 13;
            this.btnXoa.Text = "btnXoa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem9,
            this.lciThemKho,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(973, 566);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.btnThoat;
            this.layoutControlItem9.Location = new System.Drawing.Point(839, 507);
            this.layoutControlItem9.MaxSize = new System.Drawing.Size(114, 39);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(114, 39);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(114, 39);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // lciThemKho
            // 
            this.lciThemKho.Control = this.btnThemKho;
            this.lciThemKho.Location = new System.Drawing.Point(723, 507);
            this.lciThemKho.MaxSize = new System.Drawing.Size(116, 39);
            this.lciThemKho.MinSize = new System.Drawing.Size(116, 39);
            this.lciThemKho.Name = "lciThemKho";
            this.lciThemKho.Size = new System.Drawing.Size(116, 39);
            this.lciThemKho.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciThemKho.TextSize = new System.Drawing.Size(0, 0);
            this.lciThemKho.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdChung;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(953, 507);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnXoa;
            this.layoutControlItem2.Location = new System.Drawing.Point(609, 507);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(114, 39);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(114, 39);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(114, 39);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 507);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(609, 39);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmKho_a
            // 
            this.ClientSize = new System.Drawing.Size(973, 566);
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "frmKho_a";
            this.Text = "frmKho";
            this.Load += new System.EventHandler(this.frmKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciThemKho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnThemKho;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem lciThemKho;
        private DevExpress.XtraGrid.GridControl grdChung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvChung;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}