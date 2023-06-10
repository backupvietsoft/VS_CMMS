namespace VS.CMMS
{
    partial class frmCongViecBT
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
            this.btnIn = new DevExpress.XtraEditors.SimpleButton();
            this.grdChung = new DevExpress.XtraGrid.GridControl();
            this.grvChung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.cboID_NM = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cboID_LCV = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtSearch = new DevExpress.XtraEditors.SearchControl();
            this.grdChung1 = new DevExpress.XtraGrid.GridControl();
            this.grvChung1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblID_NM = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblID_LCV = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciSearch = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridLookUpEdit1 = new DevExpress.XtraEditors.GridLookUpEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboID_NM.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboID_LCV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChung1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblID_NM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblID_LCV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.gridLookUpEdit1);
            this.dataLayoutControl1.Controls.Add(this.btnIn);
            this.dataLayoutControl1.Controls.Add(this.grdChung);
            this.dataLayoutControl1.Controls.Add(this.btnThoat);
            this.dataLayoutControl1.Controls.Add(this.btnThem);
            this.dataLayoutControl1.Controls.Add(this.btnXoa);
            this.dataLayoutControl1.Controls.Add(this.cboID_NM);
            this.dataLayoutControl1.Controls.Add(this.cboID_LCV);
            this.dataLayoutControl1.Controls.Add(this.txtSearch);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(973, 566);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(737, 496);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(110, 34);
            this.btnIn.StyleController = this.dataLayoutControl1;
            this.btnIn.TabIndex = 14;
            this.btnIn.Text = "btnIn";
            // 
            // grdChung
            // 
            this.grdChung.Location = new System.Drawing.Point(12, 36);
            this.grdChung.MainView = this.grvChung;
            this.grdChung.Name = "grdChung";
            this.grdChung.Size = new System.Drawing.Size(949, 456);
            this.grdChung.TabIndex = 13;
            this.grdChung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvChung});
            // 
            // grvChung
            // 
            this.grvChung.GridControl = this.grdChung;
            this.grvChung.Name = "grvChung";
            this.grvChung.OptionsView.ShowGroupPanel = false;
            this.grvChung.DoubleClick += new System.EventHandler(this.grvChung_DoubleClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(851, 496);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(110, 34);
            this.btnThoat.StyleController = this.dataLayoutControl1;
            this.btnThoat.TabIndex = 12;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(509, 496);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(110, 34);
            this.btnThem.StyleController = this.dataLayoutControl1;
            this.btnThem.TabIndex = 9;
            this.btnThem.Text = "btnThem";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(623, 496);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(110, 34);
            this.btnXoa.StyleController = this.dataLayoutControl1;
            this.btnXoa.TabIndex = 14;
            this.btnXoa.Text = "btnXoa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // cboID_NM
            // 
            this.cboID_NM.Location = new System.Drawing.Point(117, 12);
            this.cboID_NM.Name = "cboID_NM";
            this.cboID_NM.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboID_NM.Properties.NullText = "";
            this.cboID_NM.Properties.PopupView = this.searchLookUpEdit1View;
            this.cboID_NM.Size = new System.Drawing.Size(161, 20);
            this.cboID_NM.StyleController = this.dataLayoutControl1;
            this.cboID_NM.TabIndex = 15;
            this.cboID_NM.EditValueChanged += new System.EventHandler(this.cboID_NM_EditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // cboID_LCV
            // 
            this.cboID_LCV.Location = new System.Drawing.Point(387, 12);
            this.cboID_LCV.Name = "cboID_LCV";
            this.cboID_LCV.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboID_LCV.Properties.NullText = "";
            this.cboID_LCV.Properties.PopupSizeable = false;
            this.cboID_LCV.Properties.PopupView = this.gridView1;
            this.cboID_LCV.Size = new System.Drawing.Size(574, 20);
            this.cboID_LCV.StyleController = this.dataLayoutControl1;
            this.cboID_LCV.TabIndex = 15;
            this.cboID_LCV.EditValueChanged += new System.EventHandler(this.cboID_LCV_EditValueChanged);
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Client = this.grdChung1;
            this.txtSearch.Location = new System.Drawing.Point(12, 496);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.txtSearch.Properties.Client = this.grdChung1;
            this.txtSearch.Size = new System.Drawing.Size(220, 20);
            this.txtSearch.StyleController = this.dataLayoutControl1;
            this.txtSearch.TabIndex = 28;
            // 
            // grdChung1
            // 
            this.grdChung1.Location = new System.Drawing.Point(12, 324);
            this.grdChung1.MainView = this.grvChung1;
            this.grdChung1.Name = "grdChung1";
            this.grdChung1.Size = new System.Drawing.Size(949, 192);
            this.grdChung1.TabIndex = 8;
            this.grdChung1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvChung1});
            // 
            // grvChung1
            // 
            this.grvChung1.DetailHeight = 861;
            this.grvChung1.FixedLineWidth = 4;
            this.grvChung1.GridControl = this.grdChung1;
            this.grvChung1.Name = "grvChung1";
            this.grvChung1.OptionsView.ShowGroupPanel = false;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem9,
            this.emptySpaceItem3,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem12,
            this.lblID_NM,
            this.lblID_LCV,
            this.lciSearch,
            this.layoutControlItem4});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(973, 566);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.btnThoat;
            this.layoutControlItem9.Location = new System.Drawing.Point(839, 484);
            this.layoutControlItem9.MaxSize = new System.Drawing.Size(114, 38);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(114, 38);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(114, 38);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(224, 484);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(273, 38);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdChung;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(953, 460);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnIn;
            this.layoutControlItem2.Location = new System.Drawing.Point(725, 484);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(114, 38);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(114, 38);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(114, 38);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnXoa;
            this.layoutControlItem3.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem3.Location = new System.Drawing.Point(611, 484);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(114, 38);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(114, 38);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(114, 38);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "layoutControlItem2";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.btnThem;
            this.layoutControlItem12.Location = new System.Drawing.Point(497, 484);
            this.layoutControlItem12.MaxSize = new System.Drawing.Size(114, 38);
            this.layoutControlItem12.MinSize = new System.Drawing.Size(114, 38);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(114, 38);
            this.layoutControlItem12.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem12.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem12.TextVisible = false;
            // 
            // lblID_NM
            // 
            this.lblID_NM.Control = this.cboID_NM;
            this.lblID_NM.Location = new System.Drawing.Point(0, 0);
            this.lblID_NM.Name = "lblID_NM";
            this.lblID_NM.Size = new System.Drawing.Size(270, 24);
            this.lblID_NM.TextSize = new System.Drawing.Size(93, 13);
            // 
            // lblID_LCV
            // 
            this.lblID_LCV.Control = this.cboID_LCV;
            this.lblID_LCV.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblID_LCV.CustomizationFormText = "layoutControlItem4";
            this.lblID_LCV.Location = new System.Drawing.Point(270, 0);
            this.lblID_LCV.Name = "lblID_LCV";
            this.lblID_LCV.Size = new System.Drawing.Size(683, 24);
            this.lblID_LCV.TextSize = new System.Drawing.Size(93, 13);
            // 
            // lciSearch
            // 
            this.lciSearch.ContentVertAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.lciSearch.Control = this.txtSearch;
            this.lciSearch.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lciSearch.CustomizationFormText = "lciSearch";
            this.lciSearch.Location = new System.Drawing.Point(0, 484);
            this.lciSearch.MaxSize = new System.Drawing.Size(224, 0);
            this.lciSearch.MinSize = new System.Drawing.Size(224, 1);
            this.lciSearch.Name = "lciSearch";
            this.lciSearch.Size = new System.Drawing.Size(224, 38);
            this.lciSearch.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciSearch.TextSize = new System.Drawing.Size(0, 0);
            this.lciSearch.TextVisible = false;
            // 
            // gridLookUpEdit1
            // 
            this.gridLookUpEdit1.Location = new System.Drawing.Point(117, 534);
            this.gridLookUpEdit1.Name = "gridLookUpEdit1";
            this.gridLookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpEdit1.Properties.PopupView = this.gridLookUpEdit1View;
            this.gridLookUpEdit1.Size = new System.Drawing.Size(844, 20);
            this.gridLookUpEdit1.StyleController = this.dataLayoutControl1;
            this.gridLookUpEdit1.TabIndex = 29;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.gridLookUpEdit1;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 522);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(953, 24);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(93, 13);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // frmCongViecBT
            // 
            this.ClientSize = new System.Drawing.Size(973, 566);
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "frmCongViecBT";
            this.Text = "frmCongViecBT";
            this.Load += new System.EventHandler(this.frmCongViecBT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboID_NM.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboID_LCV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChung1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblID_NM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblID_LCV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraGrid.GridControl grdChung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvChung;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton btnIn;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem lblID_NM;
        private DevExpress.XtraLayout.LayoutControlItem lblID_LCV;
        private DevExpress.XtraEditors.SearchLookUpEdit cboID_NM;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.SearchLookUpEdit cboID_LCV;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl grdChung1;
        private DevExpress.XtraGrid.Views.Grid.GridView grvChung1;
        private DevExpress.XtraEditors.SearchControl txtSearch;
        private DevExpress.XtraLayout.LayoutControlItem lciSearch;
        private DevExpress.XtraEditors.GridLookUpEdit gridLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}