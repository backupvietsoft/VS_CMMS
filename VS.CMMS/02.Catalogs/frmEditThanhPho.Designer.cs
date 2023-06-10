namespace VS.CMMS
{
    partial class FrmEditThanhPho
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.dxValidationProvider11 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.txtTEN_PT = new DevExpress.XtraEditors.TextEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtGHI_CHU = new DevExpress.XtraEditors.MemoEdit();
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.txtTEN_PT_A = new DevExpress.XtraEditors.TextEdit();
            this.txtTEN_TP_H = new DevExpress.XtraEditors.TextEdit();
            this.cboID_QG = new DevExpress.XtraEditors.LookUpEdit();
            this.buttonEdit1 = new DevExpress.XtraEditors.ButtonEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lblTEN_PT = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblTEN_PT_A = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblTEN_TP_H = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lblID_QG = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblGHI_CHU = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_PT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGHI_CHU.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_PT_A.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_TP_H.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboID_QG.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTEN_PT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTEN_PT_A)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTEN_TP_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblID_QG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGHI_CHU)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTEN_PT
            // 
            this.txtTEN_PT.Location = new System.Drawing.Point(117, 36);
            this.txtTEN_PT.Name = "txtTEN_PT";
            this.txtTEN_PT.Size = new System.Drawing.Size(715, 20);
            this.txtTEN_PT.StyleController = this.layoutControl1;
            this.txtTEN_PT.TabIndex = 4;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "This value is not valid";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider11.SetValidationRule(this.txtTEN_PT, conditionValidationRule2);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtGHI_CHU);
            this.layoutControl1.Controls.Add(this.btnGhi);
            this.layoutControl1.Controls.Add(this.btnThoat);
            this.layoutControl1.Controls.Add(this.txtTEN_PT);
            this.layoutControl1.Controls.Add(this.txtTEN_PT_A);
            this.layoutControl1.Controls.Add(this.txtTEN_TP_H);
            this.layoutControl1.Controls.Add(this.cboID_QG);
            this.layoutControl1.Controls.Add(this.buttonEdit1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(812, 96, 812, 500);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(844, 434);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtGHI_CHU
            // 
            this.txtGHI_CHU.EditValue = "";
            this.txtGHI_CHU.Location = new System.Drawing.Point(117, 108);
            this.txtGHI_CHU.Name = "txtGHI_CHU";
            this.txtGHI_CHU.Size = new System.Drawing.Size(715, 54);
            this.txtGHI_CHU.StyleController = this.layoutControl1;
            this.txtGHI_CHU.TabIndex = 5;
            // 
            // btnGhi
            // 
            this.btnGhi.Location = new System.Drawing.Point(608, 388);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(110, 34);
            this.btnGhi.StyleController = this.layoutControl1;
            this.btnGhi.TabIndex = 10;
            this.btnGhi.Text = "btnGhi";
            this.btnGhi.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(722, 388);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(110, 34);
            this.btnThoat.StyleController = this.layoutControl1;
            this.btnThoat.TabIndex = 9;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // txtTEN_PT_A
            // 
            this.txtTEN_PT_A.Location = new System.Drawing.Point(117, 60);
            this.txtTEN_PT_A.Name = "txtTEN_PT_A";
            this.txtTEN_PT_A.Size = new System.Drawing.Size(715, 20);
            this.txtTEN_PT_A.StyleController = this.layoutControl1;
            this.txtTEN_PT_A.TabIndex = 6;
            // 
            // txtTEN_TP_H
            // 
            this.txtTEN_TP_H.Location = new System.Drawing.Point(117, 84);
            this.txtTEN_TP_H.Name = "txtTEN_TP_H";
            this.txtTEN_TP_H.Size = new System.Drawing.Size(715, 20);
            this.txtTEN_TP_H.StyleController = this.layoutControl1;
            this.txtTEN_TP_H.TabIndex = 7;
            // 
            // cboID_QG
            // 
            this.cboID_QG.Location = new System.Drawing.Point(117, 12);
            this.cboID_QG.Name = "cboID_QG";
            this.cboID_QG.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboID_QG.Properties.NullText = "";
            this.cboID_QG.Size = new System.Drawing.Size(715, 20);
            this.cboID_QG.StyleController = this.layoutControl1;
            this.cboID_QG.TabIndex = 11;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            this.dxValidationProvider11.SetValidationRule(this.cboID_QG, conditionValidationRule1);
            // 
            // buttonEdit1
            // 
            this.buttonEdit1.Location = new System.Drawing.Point(117, 364);
            this.buttonEdit1.Name = "buttonEdit1";
            this.buttonEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit1.Size = new System.Drawing.Size(715, 20);
            this.buttonEdit1.StyleController = this.layoutControl1;
            this.buttonEdit1.TabIndex = 13;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lblTEN_PT,
            this.lblTEN_PT_A,
            this.lblTEN_TP_H,
            this.emptySpaceItem2,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.emptySpaceItem1,
            this.lblID_QG,
            this.layoutControlItem2,
            this.lblGHI_CHU});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(844, 434);
            this.Root.TextVisible = false;
            // 
            // lblTEN_PT
            // 
            this.lblTEN_PT.Control = this.txtTEN_PT;
            this.lblTEN_PT.Location = new System.Drawing.Point(0, 24);
            this.lblTEN_PT.Name = "lblTEN_PT";
            this.lblTEN_PT.Size = new System.Drawing.Size(824, 24);
            this.lblTEN_PT.TextSize = new System.Drawing.Size(93, 13);
            // 
            // lblTEN_PT_A
            // 
            this.lblTEN_PT_A.Control = this.txtTEN_PT_A;
            this.lblTEN_PT_A.Location = new System.Drawing.Point(0, 48);
            this.lblTEN_PT_A.Name = "lblTEN_PT_A";
            this.lblTEN_PT_A.Size = new System.Drawing.Size(824, 24);
            this.lblTEN_PT_A.TextSize = new System.Drawing.Size(93, 13);
            // 
            // lblTEN_TP_H
            // 
            this.lblTEN_TP_H.Control = this.txtTEN_TP_H;
            this.lblTEN_TP_H.Location = new System.Drawing.Point(0, 72);
            this.lblTEN_TP_H.Name = "lblTEN_TP_H";
            this.lblTEN_TP_H.Size = new System.Drawing.Size(824, 24);
            this.lblTEN_TP_H.TextSize = new System.Drawing.Size(93, 13);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 154);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(824, 198);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnThoat;
            this.layoutControlItem6.Location = new System.Drawing.Point(710, 376);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(114, 38);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(114, 38);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(114, 38);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnGhi;
            this.layoutControlItem7.Location = new System.Drawing.Point(596, 376);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(114, 38);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(114, 38);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(114, 38);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 376);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(596, 38);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lblID_QG
            // 
            this.lblID_QG.Control = this.cboID_QG;
            this.lblID_QG.Location = new System.Drawing.Point(0, 0);
            this.lblID_QG.Name = "lblID_QG";
            this.lblID_QG.Size = new System.Drawing.Size(824, 24);
            this.lblID_QG.TextSize = new System.Drawing.Size(93, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.buttonEdit1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 352);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(824, 24);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(93, 13);
            this.layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // lblGHI_CHU
            // 
            this.lblGHI_CHU.Control = this.txtGHI_CHU;
            this.lblGHI_CHU.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblGHI_CHU.CustomizationFormText = "Ghi Chú";
            this.lblGHI_CHU.Location = new System.Drawing.Point(0, 96);
            this.lblGHI_CHU.Name = "lblGHI_CHU";
            this.lblGHI_CHU.Size = new System.Drawing.Size(824, 58);
            this.lblGHI_CHU.TextSize = new System.Drawing.Size(93, 13);
            // 
            // FrmEditThanhPho
            // 
            this.ClientSize = new System.Drawing.Size(844, 434);
            this.Controls.Add(this.layoutControl1);
            this.Name = "FrmEditThanhPho";
            this.Text = "FrmEditThanhPho";
            this.Load += new System.EventHandler(this.FrmEditThanhPho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_PT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtGHI_CHU.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_PT_A.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_TP_H.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboID_QG.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTEN_PT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTEN_PT_A)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTEN_TP_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblID_QG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGHI_CHU)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider11;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtTEN_PT;
        private DevExpress.XtraEditors.TextEdit txtTEN_PT_A;
        private DevExpress.XtraEditors.TextEdit txtTEN_TP_H;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem lblTEN_PT;
        private DevExpress.XtraLayout.LayoutControlItem lblTEN_PT_A;
        private DevExpress.XtraLayout.LayoutControlItem lblTEN_TP_H;
        private DevExpress.XtraEditors.SimpleButton btnGhi;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.LookUpEdit cboID_QG;
        private DevExpress.XtraLayout.LayoutControlItem lblID_QG;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.MemoEdit txtGHI_CHU;
        private DevExpress.XtraLayout.LayoutControlItem lblGHI_CHU;
    }
}