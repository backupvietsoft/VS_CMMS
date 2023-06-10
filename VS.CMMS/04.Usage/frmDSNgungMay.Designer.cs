namespace VS.ERP
{
    partial class frmDSNgungMay
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
            this.grdDSNgungMay = new DevExpress.XtraGrid.GridControl();
            this.grvDSNgungMay = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.datTNgay = new DevExpress.XtraEditors.DateEdit();
            this.datDNgay = new DevExpress.XtraEditors.DateEdit();
            this.cboDiaDiem = new DevExpress.XtraEditors.TreeListLookUpEdit();
            this.treeListLookUpEdit1TreeList = new DevExpress.XtraTreeList.TreeList();
            this.cboLoaiMay = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lblTuNgay = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblDenNgay = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblDiaDiem = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblLoaiMay = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDSNgungMay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDSNgungMay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDiaDiem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit1TreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiMay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTuNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDenNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDiaDiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLoaiMay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.grdDSNgungMay);
            this.dataLayoutControl1.Controls.Add(this.btnThoat);
            this.dataLayoutControl1.Controls.Add(this.datTNgay);
            this.dataLayoutControl1.Controls.Add(this.datDNgay);
            this.dataLayoutControl1.Controls.Add(this.cboDiaDiem);
            this.dataLayoutControl1.Controls.Add(this.cboLoaiMay);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(1264, 662);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // grdDSNgungMay
            // 
            this.grdDSNgungMay.Location = new System.Drawing.Point(12, 72);
            this.grdDSNgungMay.MainView = this.grvDSNgungMay;
            this.grdDSNgungMay.Name = "grdDSNgungMay";
            this.grdDSNgungMay.Size = new System.Drawing.Size(1240, 540);
            this.grdDSNgungMay.TabIndex = 8;
            this.grdDSNgungMay.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDSNgungMay});
            // 
            // grvDSNgungMay
            // 
            this.grvDSNgungMay.DetailHeight = 861;
            this.grvDSNgungMay.FixedLineWidth = 4;
            this.grvDSNgungMay.GridControl = this.grdDSNgungMay;
            this.grvDSNgungMay.Name = "grvDSNgungMay";
            this.grvDSNgungMay.OptionsView.ShowGroupPanel = false;
            this.grvDSNgungMay.DoubleClick += new System.EventHandler(this.grvDSNgungMay_DoubleClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(1142, 616);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(110, 34);
            this.btnThoat.StyleController = this.dataLayoutControl1;
            this.btnThoat.TabIndex = 12;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // datTNgay
            // 
            this.datTNgay.EditValue = null;
            this.datTNgay.Location = new System.Drawing.Point(105, 12);
            this.datTNgay.Name = "datTNgay";
            this.datTNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datTNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datTNgay.Properties.CalendarTimeProperties.EditFormat.FormatString = "d";
            this.datTNgay.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datTNgay.Properties.CalendarTimeProperties.MaskSettings.Set("mask", "d");
            this.datTNgay.Properties.DisplayFormat.FormatString = "";
            this.datTNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datTNgay.Properties.MaskSettings.Set("mask", "d");
            this.datTNgay.Properties.UseMaskAsDisplayFormat = true;
            this.datTNgay.Size = new System.Drawing.Size(524, 26);
            this.datTNgay.StyleController = this.dataLayoutControl1;
            this.datTNgay.TabIndex = 1;
            this.datTNgay.EditValueChanged += new System.EventHandler(this.datTNgay_EditValueChanged);
            // 
            // datDNgay
            // 
            this.datDNgay.EditValue = null;
            this.datDNgay.Location = new System.Drawing.Point(726, 12);
            this.datDNgay.Name = "datDNgay";
            this.datDNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datDNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datDNgay.Properties.CalendarTimeProperties.EditFormat.FormatString = "d";
            this.datDNgay.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datDNgay.Properties.CalendarTimeProperties.MaskSettings.Set("mask", "d");
            this.datDNgay.Properties.MaskSettings.Set("mask", "d");
            this.datDNgay.Properties.UseMaskAsDisplayFormat = true;
            this.datDNgay.Size = new System.Drawing.Size(526, 26);
            this.datDNgay.StyleController = this.dataLayoutControl1;
            this.datDNgay.TabIndex = 2;
            this.datDNgay.EditValueChanged += new System.EventHandler(this.datTNgay_EditValueChanged);
            // 
            // cboDiaDiem
            // 
            this.cboDiaDiem.Location = new System.Drawing.Point(105, 42);
            this.cboDiaDiem.Name = "cboDiaDiem";
            this.cboDiaDiem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDiaDiem.Properties.NullText = "";
            this.cboDiaDiem.Properties.TreeList = this.treeListLookUpEdit1TreeList;
            this.cboDiaDiem.Size = new System.Drawing.Size(524, 26);
            this.cboDiaDiem.StyleController = this.dataLayoutControl1;
            this.cboDiaDiem.TabIndex = 3;
            this.cboDiaDiem.EditValueChanged += new System.EventHandler(this.datTNgay_EditValueChanged);
            // 
            // treeListLookUpEdit1TreeList
            // 
            this.treeListLookUpEdit1TreeList.Location = new System.Drawing.Point(0, 0);
            this.treeListLookUpEdit1TreeList.Name = "treeListLookUpEdit1TreeList";
            this.treeListLookUpEdit1TreeList.OptionsView.ShowIndentAsRowStyle = true;
            this.treeListLookUpEdit1TreeList.Size = new System.Drawing.Size(400, 200);
            this.treeListLookUpEdit1TreeList.TabIndex = 0;
            // 
            // cboLoaiMay
            // 
            this.cboLoaiMay.Location = new System.Drawing.Point(726, 42);
            this.cboLoaiMay.Name = "cboLoaiMay";
            this.cboLoaiMay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLoaiMay.Properties.NullText = "";
            this.cboLoaiMay.Properties.PopupView = this.searchLookUpEdit1View;
            this.cboLoaiMay.Size = new System.Drawing.Size(526, 26);
            this.cboLoaiMay.StyleController = this.dataLayoutControl1;
            this.cboLoaiMay.TabIndex = 4;
            this.cboLoaiMay.EditValueChanged += new System.EventHandler(this.datTNgay_EditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lblTuNgay,
            this.lblDenNgay,
            this.lblDiaDiem,
            this.lblLoaiMay,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.emptySpaceItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1264, 662);
            this.Root.TextVisible = false;
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.Control = this.datTNgay;
            this.lblTuNgay.Location = new System.Drawing.Point(0, 0);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(621, 30);
            this.lblTuNgay.TextSize = new System.Drawing.Size(81, 19);
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.Control = this.datDNgay;
            this.lblDenNgay.Location = new System.Drawing.Point(621, 0);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(623, 30);
            this.lblDenNgay.TextSize = new System.Drawing.Size(81, 19);
            // 
            // lblDiaDiem
            // 
            this.lblDiaDiem.Control = this.cboDiaDiem;
            this.lblDiaDiem.Location = new System.Drawing.Point(0, 30);
            this.lblDiaDiem.Name = "lblDiaDiem";
            this.lblDiaDiem.Size = new System.Drawing.Size(621, 30);
            this.lblDiaDiem.TextSize = new System.Drawing.Size(81, 19);
            // 
            // lblLoaiMay
            // 
            this.lblLoaiMay.Control = this.cboLoaiMay;
            this.lblLoaiMay.Location = new System.Drawing.Point(621, 30);
            this.lblLoaiMay.Name = "lblLoaiMay";
            this.lblLoaiMay.Size = new System.Drawing.Size(623, 30);
            this.lblLoaiMay.TextSize = new System.Drawing.Size(81, 19);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.grdDSNgungMay;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 60);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(1244, 544);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.btnThoat;
            this.layoutControlItem9.Location = new System.Drawing.Point(1130, 604);
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
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 604);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(1130, 38);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmDSNgungMay
            // 
            this.ClientSize = new System.Drawing.Size(1264, 662);
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "frmDSNgungMay";
            this.Text = "frmDSNgungMay";
            this.Load += new System.EventHandler(this.frmDSNgungMay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDSNgungMay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDSNgungMay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDiaDiem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit1TreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiMay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTuNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDenNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDiaDiem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLoaiMay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem lblTuNgay;
        private DevExpress.XtraLayout.LayoutControlItem lblDiaDiem;
        private DevExpress.XtraLayout.LayoutControlItem lblDenNgay;
        private DevExpress.XtraLayout.LayoutControlItem lblLoaiMay;
        private DevExpress.XtraGrid.GridControl grdDSNgungMay;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDSNgungMay;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.DateEdit datTNgay;
        private DevExpress.XtraEditors.DateEdit datDNgay;
        private DevExpress.XtraEditors.TreeListLookUpEdit cboDiaDiem;
        private DevExpress.XtraTreeList.TreeList treeListLookUpEdit1TreeList;
        private DevExpress.XtraEditors.SearchLookUpEdit cboLoaiMay;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
    }
}