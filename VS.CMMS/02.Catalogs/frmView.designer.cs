namespace VS.CMMS
{
    partial class frmView
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
            this.grdChung = new DevExpress.XtraGrid.GridControl();
            this.grvChung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtTim = new DevExpress.XtraEditors.SearchControl();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnIN = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.optActive = new DevExpress.XtraEditors.RadioGroup();
            this.datNamTK = new DevExpress.XtraEditors.DateEdit();
            this.cboID_DT_BH = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.datTNgay = new DevExpress.XtraEditors.DateEdit();
            this.datDNgay = new DevExpress.XtraEditors.DateEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lbl = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblKhachHang = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblNamTK = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblTNgay = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblDNgay = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datNamTK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datNamTK.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboID_DT_BH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKhachHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNamTK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // grdChung
            // 
            this.grdChung.Location = new System.Drawing.Point(12, 98);
            this.grdChung.MainView = this.grvChung;
            this.grdChung.Name = "grdChung";
            this.grdChung.Size = new System.Drawing.Size(747, 304);
            this.grdChung.TabIndex = 2;
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
            this.grvChung.DoubleClick += new System.EventHandler(this.grvChung_DoubleClick);
            // 
            // txtTim
            // 
            this.txtTim.Client = this.grdChung;
            this.txtTim.Location = new System.Drawing.Point(12, 418);
            this.txtTim.Name = "txtTim";
            this.txtTim.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton(),
            new DevExpress.XtraEditors.Repository.MRUButton()});
            this.txtTim.Properties.Client = this.grdChung;
            this.txtTim.Properties.FindDelay = 100;
            this.txtTim.Properties.ShowMRUButton = true;
            this.txtTim.Size = new System.Drawing.Size(121, 20);
            this.txtTim.StyleController = this.dataLayoutControl1;
            this.txtTim.TabIndex = 1;
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.txtTim);
            this.dataLayoutControl1.Controls.Add(this.grdChung);
            this.dataLayoutControl1.Controls.Add(this.btnThem);
            this.dataLayoutControl1.Controls.Add(this.btnXoa);
            this.dataLayoutControl1.Controls.Add(this.btnIN);
            this.dataLayoutControl1.Controls.Add(this.btnThoat);
            this.dataLayoutControl1.Controls.Add(this.optActive);
            this.dataLayoutControl1.Controls.Add(this.datNamTK);
            this.dataLayoutControl1.Controls.Add(this.cboID_DT_BH);
            this.dataLayoutControl1.Controls.Add(this.datTNgay);
            this.dataLayoutControl1.Controls.Add(this.datDNgay);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1270, 307, 650, 400);
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(771, 450);
            this.dataLayoutControl1.TabIndex = 1;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // btnThem
            // 
            this.btnThem.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True;
            this.btnThem.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
            this.btnThem.Location = new System.Drawing.Point(315, 406);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(108, 32);
            this.btnThem.StyleController = this.dataLayoutControl1;
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "btnThem";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(427, 406);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(108, 32);
            this.btnXoa.StyleController = this.dataLayoutControl1;
            this.btnXoa.TabIndex = 0;
            this.btnXoa.Text = "btnXoa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnIN
            // 
            this.btnIN.Location = new System.Drawing.Point(539, 406);
            this.btnIN.Name = "btnIN";
            this.btnIN.Size = new System.Drawing.Size(108, 32);
            this.btnIN.StyleController = this.dataLayoutControl1;
            this.btnIN.TabIndex = 0;
            this.btnIN.Text = "btnIN";
            this.btnIN.Click += new System.EventHandler(this.btnIN_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(651, 406);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(108, 32);
            this.btnThoat.StyleController = this.dataLayoutControl1;
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
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
            new DevExpress.XtraEditors.Controls.RadioGroupItem("optActive", "optActive", true, "", "optActive"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("optNoActive", "optNoActive", true, null, "optNoActive")});
            this.optActive.Size = new System.Drawing.Size(747, 34);
            this.optActive.StyleController = this.dataLayoutControl1;
            this.optActive.TabIndex = 4;
            // 
            // datNamTK
            // 
            this.datNamTK.EditValue = null;
            this.datNamTK.Location = new System.Drawing.Point(463, 50);
            this.datNamTK.Name = "datNamTK";
            this.datNamTK.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datNamTK.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datNamTK.Properties.DisplayFormat.FormatString = "yyyy";
            this.datNamTK.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datNamTK.Properties.EditFormat.FormatString = "yyyy";
            this.datNamTK.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datNamTK.Properties.Mask.EditMask = "yyyy";
            this.datNamTK.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.datNamTK.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearsGroupView;
            this.datNamTK.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView;
            this.datNamTK.Size = new System.Drawing.Size(296, 20);
            this.datNamTK.StyleController = this.dataLayoutControl1;
            this.datNamTK.TabIndex = 6;
            // 
            // cboID_DT_BH
            // 
            this.cboID_DT_BH.Location = new System.Drawing.Point(88, 50);
            this.cboID_DT_BH.Name = "cboID_DT_BH";
            this.cboID_DT_BH.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboID_DT_BH.Properties.NullText = "";
            this.cboID_DT_BH.Properties.PopupSizeable = false;
            this.cboID_DT_BH.Properties.PopupView = this.searchLookUpEdit1View;
            this.cboID_DT_BH.Size = new System.Drawing.Size(295, 20);
            this.cboID_DT_BH.StyleController = this.dataLayoutControl1;
            this.cboID_DT_BH.TabIndex = 5;
            
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // datTNgay
            // 
            this.datTNgay.EditValue = null;
            this.datTNgay.Location = new System.Drawing.Point(88, 74);
            this.datTNgay.Name = "datTNgay";
            this.datTNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datTNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datTNgay.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.datTNgay.Size = new System.Drawing.Size(295, 20);
            this.datTNgay.StyleController = this.dataLayoutControl1;
            this.datTNgay.TabIndex = 7;
            // 
            // datDNgay
            // 
            this.datDNgay.EditValue = null;
            this.datDNgay.Location = new System.Drawing.Point(463, 74);
            this.datDNgay.Name = "datDNgay";
            this.datDNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datDNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datDNgay.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.datDNgay.Size = new System.Drawing.Size(296, 20);
            this.datDNgay.StyleController = this.dataLayoutControl1;
            this.datDNgay.TabIndex = 8;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.lbl,
            this.lblNamTK,
            this.lblTNgay,
            this.lblDNgay,
            this.emptySpaceItem1,
            this.lblKhachHang});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(771, 450);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdChung;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 86);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(751, 308);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnThoat;
            this.layoutControlItem2.Location = new System.Drawing.Point(639, 394);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(112, 36);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(112, 36);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(112, 36);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnIN;
            this.layoutControlItem3.Location = new System.Drawing.Point(527, 394);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(112, 36);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(112, 36);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(112, 36);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnXoa;
            this.layoutControlItem4.Location = new System.Drawing.Point(415, 394);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(112, 36);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(112, 36);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(112, 36);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnThem;
            this.layoutControlItem5.Location = new System.Drawing.Point(303, 394);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(112, 36);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(112, 36);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(112, 36);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.ContentVertAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.layoutControlItem6.Control = this.txtTim;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 394);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(224, 0);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(1, 1);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(125, 36);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // lbl
            // 
            this.lbl.Control = this.optActive;
            this.lbl.Location = new System.Drawing.Point(0, 0);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(751, 38);
            this.lbl.TextSize = new System.Drawing.Size(0, 0);
            this.lbl.TextVisible = false;
            this.lbl.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // lblKhachHang
            // 
            this.lblKhachHang.Control = this.cboID_DT_BH;
            this.lblKhachHang.Location = new System.Drawing.Point(0, 38);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(375, 24);
            this.lblKhachHang.TextSize = new System.Drawing.Size(64, 13);
            this.lblKhachHang.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // lblNamTK
            // 
            this.lblNamTK.Control = this.datNamTK;
            this.lblNamTK.Location = new System.Drawing.Point(375, 38);
            this.lblNamTK.Name = "lblNamTK";
            this.lblNamTK.Size = new System.Drawing.Size(376, 24);
            this.lblNamTK.TextSize = new System.Drawing.Size(64, 13);
            this.lblNamTK.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // lblTNgay
            // 
            this.lblTNgay.Control = this.datTNgay;
            this.lblTNgay.Location = new System.Drawing.Point(0, 62);
            this.lblTNgay.Name = "lblTNgay";
            this.lblTNgay.Size = new System.Drawing.Size(375, 24);
            this.lblTNgay.TextSize = new System.Drawing.Size(64, 13);
            this.lblTNgay.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // lblDNgay
            // 
            this.lblDNgay.Control = this.datDNgay;
            this.lblDNgay.Location = new System.Drawing.Point(375, 62);
            this.lblDNgay.Name = "lblDNgay";
            this.lblDNgay.Size = new System.Drawing.Size(376, 24);
            this.lblDNgay.TextSize = new System.Drawing.Size(64, 13);
            this.lblDNgay.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(125, 394);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(1, 1);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(178, 36);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmView
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(771, 450);
            this.Controls.Add(this.dataLayoutControl1);
            this.KeyPreview = true;
            this.Name = "frmView";
            this.Text = "frmView";
            this.Load += new System.EventHandler(this.frmView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.optActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datNamTK.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datNamTK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboID_DT_BH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKhachHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNamTK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SearchControl txtTim;
        private DevExpress.XtraEditors.SimpleButton btnIN;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraGrid.GridControl grdChung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvChung;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.RadioGroup optActive;
        private DevExpress.XtraLayout.LayoutControlItem lbl;
        private DevExpress.XtraEditors.DateEdit datNamTK;
        private DevExpress.XtraLayout.LayoutControlItem lblKhachHang;
        private DevExpress.XtraLayout.LayoutControlItem lblNamTK;
        private DevExpress.XtraEditors.SearchLookUpEdit cboID_DT_BH;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.DateEdit datTNgay;
        private DevExpress.XtraEditors.DateEdit datDNgay;
        private DevExpress.XtraLayout.LayoutControlItem lblTNgay;
        private DevExpress.XtraLayout.LayoutControlItem lblDNgay;
    }
}

