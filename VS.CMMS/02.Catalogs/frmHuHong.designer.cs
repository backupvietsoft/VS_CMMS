namespace VS.CMMS
{
    partial class frmHuHong
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
            this.grvChung1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdChung = new DevExpress.XtraGrid.GridControl();
            this.grvChung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.rdgHuHong = new DevExpress.XtraEditors.RadioGroup();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciThem = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtTim = new DevExpress.XtraEditors.SearchControl();
            this.grdChung1 = new DevExpress.XtraGrid.GridControl();
            this.grvChung2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdgHuHong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciThem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChung1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // grvChung1
            // 
            this.grvChung1.GridControl = this.grdChung;
            this.grvChung1.Name = "grvChung1";
            // 
            // grdChung
            // 
            this.grdChung.Location = new System.Drawing.Point(12, 50);
            this.grdChung.MainView = this.grvChung;
            this.grdChung.Name = "grdChung";
            this.grdChung.Size = new System.Drawing.Size(949, 466);
            this.grdChung.TabIndex = 8;
            this.grdChung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvChung,
            this.grvChung1});
            // 
            // grvChung
            // 
            this.grvChung.DetailHeight = 861;
            this.grvChung.FixedLineWidth = 4;
            this.grvChung.GridControl = this.grdChung;
            this.grvChung.Name = "grvChung";
            this.grvChung.OptionsView.ShowGroupPanel = false;
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.rdgHuHong);
            this.dataLayoutControl1.Controls.Add(this.grdChung);
            this.dataLayoutControl1.Controls.Add(this.btnThoat);
            this.dataLayoutControl1.Controls.Add(this.btnThem);
            this.dataLayoutControl1.Controls.Add(this.txtTim);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(973, 566);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // rdgHuHong
            // 
            this.rdgHuHong.Location = new System.Drawing.Point(12, 12);
            this.rdgHuHong.MaximumSize = new System.Drawing.Size(949, 34);
            this.rdgHuHong.Name = "rdgHuHong";
            this.rdgHuHong.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "optALL", true, null, "optALL"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "optDanhMucHuHong", true, null, "optDanhMucHuHong"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "optNguyenNhanHuHong", true, null, "optNguyenNhanHuHong")});
            this.rdgHuHong.Size = new System.Drawing.Size(949, 34);
            this.rdgHuHong.StyleController = this.dataLayoutControl1;
            this.rdgHuHong.TabIndex = 14;
            this.rdgHuHong.SelectedIndexChanged += new System.EventHandler(this.rdgHuHong_SelectedIndexChanged);
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
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(737, 520);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(110, 34);
            this.btnThem.StyleController = this.dataLayoutControl1;
            this.btnThem.TabIndex = 15;
            this.btnThem.Text = "btnThem";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.emptySpaceItem2,
            this.layoutControlItem2,
            this.lciThem,
            this.layoutControlItem6});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(973, 566);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.grdChung;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 38);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(953, 470);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
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
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(224, 508);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(501, 38);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.rdgHuHong;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(953, 38);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // lciThem
            // 
            this.lciThem.Control = this.btnThem;
            this.lciThem.Location = new System.Drawing.Point(725, 508);
            this.lciThem.MaxSize = new System.Drawing.Size(114, 38);
            this.lciThem.MinSize = new System.Drawing.Size(114, 38);
            this.lciThem.Name = "lciThem";
            this.lciThem.Size = new System.Drawing.Size(114, 38);
            this.lciThem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciThem.TextSize = new System.Drawing.Size(0, 0);
            this.lciThem.TextVisible = false;
            // 
            // txtTim
            // 
            this.txtTim.Client = this.grdChung1;
            this.txtTim.Location = new System.Drawing.Point(12, 534);
            this.txtTim.Name = "txtTim";
            this.txtTim.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton(),
            new DevExpress.XtraEditors.Repository.MRUButton()});
            this.txtTim.Properties.Client = this.grdChung1;
            this.txtTim.Properties.FindDelay = 100;
            this.txtTim.Properties.ShowMRUButton = true;
            this.txtTim.Size = new System.Drawing.Size(220, 20);
            this.txtTim.StyleController = this.dataLayoutControl1;
            this.txtTim.TabIndex = 1;
            // 
            // grdChung1
            // 
            this.grdChung1.Location = new System.Drawing.Point(12, 12);
            this.grdChung1.MainView = this.grvChung2;
            this.grdChung1.Name = "grdChung1";
            this.grdChung1.Size = new System.Drawing.Size(949, 504);
            this.grdChung1.TabIndex = 8;
            this.grdChung1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvChung2});
            // 
            // grvChung2
            // 
            this.grvChung2.DetailHeight = 861;
            this.grvChung2.FixedLineWidth = 4;
            this.grvChung2.GridControl = this.grdChung1;
            this.grvChung2.Name = "grvChung2";
            this.grvChung2.OptionsSelection.CheckBoxSelectorField = "CHON";
            this.grvChung2.OptionsSelection.MultiSelect = true;
            this.grvChung2.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.grvChung2.OptionsView.ShowGroupPanel = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem6.ContentVertAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.layoutControlItem6.Control = this.txtTim;
            this.layoutControlItem6.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 508);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(224, 0);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(1, 1);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(224, 38);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // frmHuHong
            // 
            this.ClientSize = new System.Drawing.Size(973, 566);
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "frmHuHong";
            this.Text = "frmHuHong";
            this.Load += new System.EventHandler(this.frmHuHong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grvChung1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdgHuHong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciThem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChung1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGrid.GridControl grdChung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvChung;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraGrid.Views.Grid.GridView grvChung1;
        private DevExpress.XtraEditors.RadioGroup rdgHuHong;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraLayout.LayoutControlItem lciThem;
        private DevExpress.XtraEditors.SearchControl txtTim;
        private DevExpress.XtraGrid.GridControl grdChung1;
        private DevExpress.XtraGrid.Views.Grid.GridView grvChung2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
    }
}