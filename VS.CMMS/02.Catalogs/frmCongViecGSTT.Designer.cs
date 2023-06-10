namespace VS.CMMS
{
    partial class frmCongViecGSTT
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
            this.optActive = new DevExpress.XtraEditors.RadioGroup();
            this.grdChung = new DevExpress.XtraGrid.GridControl();
            this.grvChung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnIn = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.cboID_BP_GSTT = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblID_BP_GSTT = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboID_BP_GSTT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblID_BP_GSTT)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.optActive);
            this.dataLayoutControl1.Controls.Add(this.grdChung);
            this.dataLayoutControl1.Controls.Add(this.btnThoat);
            this.dataLayoutControl1.Controls.Add(this.btnIn);
            this.dataLayoutControl1.Controls.Add(this.btnXoa);
            this.dataLayoutControl1.Controls.Add(this.btnThem);
            this.dataLayoutControl1.Controls.Add(this.cboID_BP_GSTT);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(973, 566);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // optActive
            // 
            this.optActive.EditValue = "optActive";
            this.optActive.Location = new System.Drawing.Point(12, 12);
            this.optActive.Name = "optActive";
            this.optActive.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.optActive.Properties.Appearance.Options.UseBackColor = true;
            this.optActive.Properties.Columns = 3;
            this.optActive.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("optALL", "optALL", true, null, "optALL"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("optDinhTinh", "optDinhTinh", true, "", "optDinhTinh"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("optDinhLuong", "optDinhLuong", true, null, "optDinhLuong")});
            this.optActive.Size = new System.Drawing.Size(472, 34);
            this.optActive.StyleController = this.dataLayoutControl1;
            this.optActive.TabIndex = 5;
            this.optActive.SelectedIndexChanged += new System.EventHandler(this.optActive_SelectedIndexChanged);
            // 
            // grdChung
            // 
            this.grdChung.Location = new System.Drawing.Point(12, 50);
            this.grdChung.MainView = this.grvChung;
            this.grdChung.Name = "grdChung";
            this.grdChung.Size = new System.Drawing.Size(949, 466);
            this.grdChung.TabIndex = 8;
            this.grdChung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvChung});
            this.grdChung.DoubleClick += new System.EventHandler(this.grdChung_DoubleClick);
            // 
            // grvChung
            // 
            this.grvChung.DetailHeight = 861;
            this.grvChung.FixedLineWidth = 4;
            this.grvChung.GridControl = this.grdChung;
            this.grvChung.Name = "grvChung";
            this.grvChung.OptionsView.ShowGroupPanel = false;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(851, 520);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(110, 34);
            this.btnThoat.StyleController = this.dataLayoutControl1;
            this.btnThoat.TabIndex = 12;
            this.btnThoat.Text = "btnThoat";
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(737, 520);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(110, 34);
            this.btnIn.StyleController = this.dataLayoutControl1;
            this.btnIn.TabIndex = 11;
            this.btnIn.Text = "btnIn";
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(623, 520);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(110, 34);
            this.btnXoa.StyleController = this.dataLayoutControl1;
            this.btnXoa.TabIndex = 10;
            this.btnXoa.Text = "btnXoa";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(509, 520);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(110, 34);
            this.btnThem.StyleController = this.dataLayoutControl1;
            this.btnThem.TabIndex = 9;
            this.btnThem.Text = "btnThem";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // cboID_BP_GSTT
            // 
            this.cboID_BP_GSTT.Location = new System.Drawing.Point(570, 19);
            this.cboID_BP_GSTT.Name = "cboID_BP_GSTT";
            this.cboID_BP_GSTT.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboID_BP_GSTT.Properties.NullText = "";
            this.cboID_BP_GSTT.Properties.PopupView = this.searchLookUpEdit1View;
            this.cboID_BP_GSTT.Size = new System.Drawing.Size(391, 20);
            this.cboID_BP_GSTT.StyleController = this.dataLayoutControl1;
            this.cboID_BP_GSTT.TabIndex = 13;
            this.cboID_BP_GSTT.EditValueChanged += new System.EventHandler(this.cboID_BP_GSTT_EditValueChanged);
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
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.layoutControlItem10,
            this.layoutControlItem11,
            this.layoutControlItem12,
            this.emptySpaceItem2,
            this.layoutControlItem1,
            this.lblID_BP_GSTT});
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
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.btnIn;
            this.layoutControlItem10.Location = new System.Drawing.Point(725, 508);
            this.layoutControlItem10.MaxSize = new System.Drawing.Size(114, 38);
            this.layoutControlItem10.MinSize = new System.Drawing.Size(114, 38);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(114, 38);
            this.layoutControlItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextVisible = false;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.btnXoa;
            this.layoutControlItem11.Location = new System.Drawing.Point(611, 508);
            this.layoutControlItem11.MaxSize = new System.Drawing.Size(114, 38);
            this.layoutControlItem11.MinSize = new System.Drawing.Size(114, 38);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(114, 38);
            this.layoutControlItem11.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem11.TextVisible = false;
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.btnThem;
            this.layoutControlItem12.Location = new System.Drawing.Point(497, 508);
            this.layoutControlItem12.MaxSize = new System.Drawing.Size(114, 38);
            this.layoutControlItem12.MinSize = new System.Drawing.Size(114, 38);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(114, 38);
            this.layoutControlItem12.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem12.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem12.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 508);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(497, 38);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.optActive;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(476, 38);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // lblID_BP_GSTT
            // 
            this.lblID_BP_GSTT.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblID_BP_GSTT.Control = this.cboID_BP_GSTT;
            this.lblID_BP_GSTT.Location = new System.Drawing.Point(476, 0);
            this.lblID_BP_GSTT.Name = "lblID_BP_GSTT";
            this.lblID_BP_GSTT.Size = new System.Drawing.Size(477, 38);
            this.lblID_BP_GSTT.TextSize = new System.Drawing.Size(70, 13);
            // 
            // frmCongViecGSTT
            // 
            this.ClientSize = new System.Drawing.Size(973, 566);
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "frmCongViecGSTT";
            this.Text = "frmChung";
            this.Load += new System.EventHandler(this.frmCongViecGSTT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.optActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboID_BP_GSTT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblID_BP_GSTT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGrid.GridControl grdChung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvChung;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnIn;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.RadioGroup optActive;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem lblID_BP_GSTT;
        private DevExpress.XtraEditors.SearchLookUpEdit cboID_BP_GSTT;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
    }
}