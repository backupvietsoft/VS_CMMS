namespace VS.CMMS
{
    partial class frmEditHangSanXuat
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.textEdit11 = new DevExpress.XtraEditors.TextEdit();
            this.txtTEN_HSX = new DevExpress.XtraEditors.TextEdit();
            this.cboID_QG = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblTEN_HSX = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblID_QG = new DevExpress.XtraLayout.LayoutControlItem();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit11.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_HSX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboID_QG.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTEN_HSX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblID_QG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.btnThoat);
            this.dataLayoutControl1.Controls.Add(this.btnGhi);
            this.dataLayoutControl1.Controls.Add(this.textEdit11);
            this.dataLayoutControl1.Controls.Add(this.txtTEN_HSX);
            this.dataLayoutControl1.Controls.Add(this.cboID_QG);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(844, 434);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(722, 388);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(110, 34);
            this.btnThoat.StyleController = this.dataLayoutControl1;
            this.btnThoat.TabIndex = 9;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.Location = new System.Drawing.Point(608, 388);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(110, 34);
            this.btnGhi.StyleController = this.dataLayoutControl1;
            this.btnGhi.TabIndex = 11;
            this.btnGhi.Text = "btnGhi";
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // textEdit11
            // 
            this.textEdit11.Location = new System.Drawing.Point(117, 364);
            this.textEdit11.Name = "textEdit11";
            this.textEdit11.Size = new System.Drawing.Size(715, 20);
            this.textEdit11.StyleController = this.dataLayoutControl1;
            this.textEdit11.TabIndex = 15;
            // 
            // txtTEN_HSX
            // 
            this.txtTEN_HSX.Location = new System.Drawing.Point(117, 12);
            this.txtTEN_HSX.Name = "txtTEN_HSX";
            this.txtTEN_HSX.Size = new System.Drawing.Size(715, 20);
            this.txtTEN_HSX.StyleController = this.dataLayoutControl1;
            this.txtTEN_HSX.TabIndex = 16;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.txtTEN_HSX, conditionValidationRule1);
            // 
            // cboID_QG
            // 
            this.cboID_QG.Location = new System.Drawing.Point(117, 36);
            this.cboID_QG.Name = "cboID_QG";
            this.cboID_QG.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboID_QG.Properties.NullText = "";
            this.cboID_QG.Properties.PopupView = this.searchLookUpEdit1View;
            this.cboID_QG.Size = new System.Drawing.Size(715, 20);
            this.cboID_QG.StyleController = this.dataLayoutControl1;
            this.cboID_QG.TabIndex = 17;
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
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem2,
            this.lblTEN_HSX,
            this.lblID_QG});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(844, 434);
            this.Root.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 48);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(824, 304);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 376);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(596, 38);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnThoat;
            this.layoutControlItem1.Location = new System.Drawing.Point(710, 376);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(114, 38);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(114, 38);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(114, 38);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnGhi;
            this.layoutControlItem3.Location = new System.Drawing.Point(596, 376);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(114, 38);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(114, 38);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(114, 38);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.textEdit11;
            this.layoutControlItem2.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 352);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(824, 24);
            this.layoutControlItem2.Text = "layoutControlItem1";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(93, 13);
            this.layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // lblTEN_HSX
            // 
            this.lblTEN_HSX.Control = this.txtTEN_HSX;
            this.lblTEN_HSX.Location = new System.Drawing.Point(0, 0);
            this.lblTEN_HSX.Name = "lblTEN_HSX";
            this.lblTEN_HSX.Size = new System.Drawing.Size(824, 24);
            this.lblTEN_HSX.TextSize = new System.Drawing.Size(93, 13);
            // 
            // lblID_QG
            // 
            this.lblID_QG.Control = this.cboID_QG;
            this.lblID_QG.Location = new System.Drawing.Point(0, 24);
            this.lblID_QG.Name = "lblID_QG";
            this.lblID_QG.Size = new System.Drawing.Size(824, 24);
            this.lblID_QG.TextSize = new System.Drawing.Size(93, 13);
            // 
            // frmEditHangSanXuat
            // 
            this.ClientSize = new System.Drawing.Size(844, 434);
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "frmEditHangSanXuat";
            this.Text = "frmEditHangSanXuat";
            this.Load += new System.EventHandler(this.frmEditHangSanXuat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit11.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_HSX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboID_QG.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTEN_HSX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblID_QG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton btnGhi;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.TextEdit textEdit11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.TextEdit txtTEN_HSX;
        private DevExpress.XtraLayout.LayoutControlItem lblTEN_HSX;
        private DevExpress.XtraLayout.LayoutControlItem lblID_QG;
        private DevExpress.XtraEditors.SearchLookUpEdit cboID_QG;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
    }
}