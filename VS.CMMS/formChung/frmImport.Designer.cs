﻿namespace VS.CMMS
{
    partial class frmImport
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
            this.btnThucHien = new DevExpress.XtraEditors.SimpleButton();
            this.searchControl1 = new DevExpress.XtraEditors.SearchControl();
            this.grdChung = new DevExpress.XtraGrid.GridControl();
            this.grvChung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.prbIN = new DevExpress.XtraEditors.ProgressBarControl();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.txtPath = new DevExpress.XtraEditors.ButtonEdit();
            this.cboSheet = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblPath = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblSheet = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciThucHien = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prbIN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSheet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSheet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciThucHien)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.btnThucHien);
            this.dataLayoutControl1.Controls.Add(this.searchControl1);
            this.dataLayoutControl1.Controls.Add(this.prbIN);
            this.dataLayoutControl1.Controls.Add(this.grdChung);
            this.dataLayoutControl1.Controls.Add(this.btnThoat);
            this.dataLayoutControl1.Controls.Add(this.btnXoa);
            this.dataLayoutControl1.Controls.Add(this.txtPath);
            this.dataLayoutControl1.Controls.Add(this.cboSheet);
            this.dataLayoutControl1.Controls.Add(this.btnExport);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(292, 6, 1467, 938);
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(1154, 710);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // btnThucHien
            // 
            this.btnThucHien.Location = new System.Drawing.Point(810, 666);
            this.btnThucHien.Name = "btnThucHien";
            this.btnThucHien.Size = new System.Drawing.Size(108, 32);
            this.btnThucHien.StyleController = this.dataLayoutControl1;
            this.btnThucHien.TabIndex = 12;
            this.btnThucHien.Text = "btnThucHien";
            this.btnThucHien.Click += new System.EventHandler(this.btnThucHien_Click);
            // 
            // searchControl1
            // 
            this.searchControl1.Client = this.grdChung;
            this.searchControl1.Location = new System.Drawing.Point(12, 672);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl1.Properties.Client = this.grdChung;
            this.searchControl1.Properties.FindDelay = 500;
            this.searchControl1.Size = new System.Drawing.Size(220, 26);
            this.searchControl1.StyleController = this.dataLayoutControl1;
            this.searchControl1.TabIndex = 10;
            // 
            // grdChung
            // 
            this.grdChung.Location = new System.Drawing.Point(12, 42);
            this.grdChung.MainView = this.grvChung;
            this.grdChung.Name = "grdChung";
            this.grdChung.Size = new System.Drawing.Size(1130, 598);
            this.grdChung.TabIndex = 1;
            this.grdChung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvChung});
            // 
            // grvChung
            // 
            this.grvChung.ColumnPanelRowHeight = 0;
            this.grvChung.DetailHeight = 142;
            this.grvChung.FixedLineWidth = 1;
            this.grvChung.FooterPanelHeight = 0;
            this.grvChung.GridControl = this.grdChung;
            this.grvChung.GroupRowHeight = 0;
            this.grvChung.LevelIndent = 0;
            this.grvChung.Name = "grvChung";
            this.grvChung.OptionsSelection.MultiSelect = true;
            this.grvChung.OptionsView.ShowGroupPanel = false;
            this.grvChung.PreviewIndent = 0;
            this.grvChung.RowHeight = 0;
            this.grvChung.ViewCaptionHeight = 0;
            // 
            // prbIN
            // 
            this.prbIN.Location = new System.Drawing.Point(12, 644);
            this.prbIN.Name = "prbIN";
            this.prbIN.Size = new System.Drawing.Size(1130, 18);
            this.prbIN.StyleController = this.dataLayoutControl1;
            this.prbIN.TabIndex = 8;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(1034, 666);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(108, 32);
            this.btnThoat.StyleController = this.dataLayoutControl1;
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(922, 666);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(108, 32);
            this.btnXoa.StyleController = this.dataLayoutControl1;
            this.btnXoa.TabIndex = 5;
            this.btnXoa.Text = "btnXoa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // txtPath
            // 
            this.txtPath.EditValue = "";
            this.txtPath.Location = new System.Drawing.Point(80, 12);
            this.txtPath.Name = "txtPath";
            this.txtPath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtPath.Size = new System.Drawing.Size(700, 26);
            this.txtPath.StyleController = this.dataLayoutControl1;
            this.txtPath.TabIndex = 6;
            // 
            // cboSheet
            // 
            this.cboSheet.Location = new System.Drawing.Point(852, 12);
            this.cboSheet.Name = "cboSheet";
            this.cboSheet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSheet.Size = new System.Drawing.Size(290, 26);
            this.cboSheet.StyleController = this.dataLayoutControl1;
            this.cboSheet.TabIndex = 7;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(698, 666);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(108, 32);
            this.btnExport.StyleController = this.dataLayoutControl1;
            this.btnExport.TabIndex = 11;
            this.btnExport.Text = "btnExport";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.lblPath,
            this.lblSheet,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.emptySpaceItem1,
            this.layoutControlItem7,
            this.layoutControlItem6,
            this.lciThucHien});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1154, 710);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdChung;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 30);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1134, 602);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnThoat;
            this.layoutControlItem2.Location = new System.Drawing.Point(1022, 654);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(112, 36);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(112, 36);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(112, 36);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // lblPath
            // 
            this.lblPath.Control = this.txtPath;
            this.lblPath.Location = new System.Drawing.Point(0, 0);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(772, 30);
            this.lblPath.TextSize = new System.Drawing.Size(56, 19);
            // 
            // lblSheet
            // 
            this.lblSheet.Control = this.cboSheet;
            this.lblSheet.Location = new System.Drawing.Point(772, 0);
            this.lblSheet.Name = "lblSheet";
            this.lblSheet.Size = new System.Drawing.Size(362, 30);
            this.lblSheet.TextSize = new System.Drawing.Size(56, 19);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.prbIN;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 632);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(1134, 22);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnXoa;
            this.layoutControlItem5.Location = new System.Drawing.Point(910, 654);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(112, 36);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(112, 36);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(112, 36);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(224, 654);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(50, 25);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(462, 36);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.ContentVertAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.layoutControlItem7.Control = this.searchControl1;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 654);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(224, 0);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(224, 1);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(224, 36);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnExport;
            this.layoutControlItem6.Location = new System.Drawing.Point(686, 654);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(112, 36);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(112, 36);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(112, 36);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // lciThucHien
            // 
            this.lciThucHien.Control = this.btnThucHien;
            this.lciThucHien.Location = new System.Drawing.Point(798, 654);
            this.lciThucHien.MaxSize = new System.Drawing.Size(112, 36);
            this.lciThucHien.MinSize = new System.Drawing.Size(112, 36);
            this.lciThucHien.Name = "lciThucHien";
            this.lciThucHien.Size = new System.Drawing.Size(112, 36);
            this.lciThucHien.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciThucHien.TextSize = new System.Drawing.Size(0, 0);
            this.lciThucHien.TextVisible = false;
            // 
            // frmImport
            // 
            this.ClientSize = new System.Drawing.Size(1154, 710);
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "frmImport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmHangHoaImport";
            this.Load += new System.EventHandler(this.frmImport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prbIN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSheet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSheet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciThucHien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGrid.GridControl grdChung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvChung;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.ButtonEdit txtPath;
        private DevExpress.XtraLayout.LayoutControlItem lblPath;
        private DevExpress.XtraLayout.LayoutControlItem lblSheet;
        private DevExpress.XtraEditors.ComboBoxEdit cboSheet;
        private DevExpress.XtraEditors.ProgressBarControl prbIN;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.SearchControl searchControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.SimpleButton btnThucHien;
        private DevExpress.XtraLayout.LayoutControlItem lciThucHien;
    }
}