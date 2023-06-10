namespace VS.CMMS
{
    partial class FrmEditQuocGia
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.txtMA_QG = new DevExpress.XtraEditors.TextEdit();
            this.txtTEN_QG_A = new DevExpress.XtraEditors.TextEdit();
            this.txtTEN_QG = new DevExpress.XtraEditors.TextEdit();
            this.txtTEN_QG_H = new DevExpress.XtraEditors.TextEdit();
            this.txtGHI_CHU = new DevExpress.XtraEditors.MemoEdit();
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.btnKhongGhi = new DevExpress.XtraEditors.SimpleButton();
            this.chkMAC_DINH = new DevExpress.XtraEditors.CheckEdit();
            this.buttonEdit11 = new DevExpress.XtraEditors.ButtonEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lblTEN_QG_H = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblMA_QG = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblTEN_QG = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblTEN_QG_A = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblGHI_CHU = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblMacDinh = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMA_QG.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_QG_A.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_QG.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_QG_H.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGHI_CHU.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMAC_DINH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit11.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTEN_QG_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMA_QG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTEN_QG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTEN_QG_A)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGHI_CHU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMacDinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.txtMA_QG);
            this.dataLayoutControl1.Controls.Add(this.txtTEN_QG_A);
            this.dataLayoutControl1.Controls.Add(this.txtTEN_QG);
            this.dataLayoutControl1.Controls.Add(this.txtTEN_QG_H);
            this.dataLayoutControl1.Controls.Add(this.txtGHI_CHU);
            this.dataLayoutControl1.Controls.Add(this.btnGhi);
            this.dataLayoutControl1.Controls.Add(this.btnKhongGhi);
            this.dataLayoutControl1.Controls.Add(this.chkMAC_DINH);
            this.dataLayoutControl1.Controls.Add(this.buttonEdit11);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(340, 14, 650, 400);
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(844, 434);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // txtMA_QG
            // 
            this.txtMA_QG.Location = new System.Drawing.Point(117, 12);
            this.txtMA_QG.Name = "txtMA_QG";
            this.txtMA_QG.Size = new System.Drawing.Size(588, 20);
            this.txtMA_QG.StyleController = this.dataLayoutControl1;
            this.txtMA_QG.TabIndex = 4;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            this.dxValidationProvider1.SetValidationRule(this.txtMA_QG, conditionValidationRule1);
            // 
            // txtTEN_QG_A
            // 
            this.txtTEN_QG_A.Location = new System.Drawing.Point(117, 60);
            this.txtTEN_QG_A.Name = "txtTEN_QG_A";
            this.txtTEN_QG_A.Size = new System.Drawing.Size(715, 20);
            this.txtTEN_QG_A.StyleController = this.dataLayoutControl1;
            this.txtTEN_QG_A.TabIndex = 4;
            // 
            // txtTEN_QG
            // 
            this.txtTEN_QG.Location = new System.Drawing.Point(117, 36);
            this.txtTEN_QG.Name = "txtTEN_QG";
            this.txtTEN_QG.Size = new System.Drawing.Size(715, 20);
            this.txtTEN_QG.StyleController = this.dataLayoutControl1;
            this.txtTEN_QG.TabIndex = 4;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "This value is not valid";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.txtTEN_QG, conditionValidationRule2);
            // 
            // txtTEN_QG_H
            // 
            this.txtTEN_QG_H.Location = new System.Drawing.Point(117, 84);
            this.txtTEN_QG_H.Name = "txtTEN_QG_H";
            this.txtTEN_QG_H.Size = new System.Drawing.Size(715, 20);
            this.txtTEN_QG_H.StyleController = this.dataLayoutControl1;
            this.txtTEN_QG_H.TabIndex = 4;
            // 
            // txtGHI_CHU
            // 
            this.txtGHI_CHU.EditValue = "";
            this.txtGHI_CHU.Location = new System.Drawing.Point(117, 108);
            this.txtGHI_CHU.Name = "txtGHI_CHU";
            this.txtGHI_CHU.Size = new System.Drawing.Size(715, 42);
            this.txtGHI_CHU.StyleController = this.dataLayoutControl1;
            this.txtGHI_CHU.TabIndex = 5;
            // 
            // btnGhi
            // 
            this.btnGhi.Location = new System.Drawing.Point(608, 388);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(110, 34);
            this.btnGhi.StyleController = this.dataLayoutControl1;
            this.btnGhi.TabIndex = 6;
            this.btnGhi.Text = "Lưu";
            this.btnGhi.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnKhongGhi
            // 
            this.btnKhongGhi.Location = new System.Drawing.Point(722, 388);
            this.btnKhongGhi.Name = "btnKhongGhi";
            this.btnKhongGhi.Size = new System.Drawing.Size(110, 34);
            this.btnKhongGhi.StyleController = this.dataLayoutControl1;
            this.btnKhongGhi.TabIndex = 6;
            this.btnKhongGhi.Text = "Thoát";
            this.btnKhongGhi.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // chkMAC_DINH
            // 
            this.chkMAC_DINH.Location = new System.Drawing.Point(709, 12);
            this.chkMAC_DINH.Name = "chkMAC_DINH";
            this.chkMAC_DINH.Properties.Caption = "chkMAC_DINH";
            this.chkMAC_DINH.Size = new System.Drawing.Size(123, 20);
            this.chkMAC_DINH.StyleController = this.dataLayoutControl1;
            this.chkMAC_DINH.TabIndex = 7;
            // 
            // buttonEdit11
            // 
            this.buttonEdit11.Location = new System.Drawing.Point(117, 364);
            this.buttonEdit11.Name = "buttonEdit11";
            this.buttonEdit11.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit11.Size = new System.Drawing.Size(715, 20);
            this.buttonEdit11.StyleController = this.dataLayoutControl1;
            this.buttonEdit11.TabIndex = 13;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lblTEN_QG_H,
            this.lblMA_QG,
            this.lblTEN_QG,
            this.lblTEN_QG_A,
            this.lblGHI_CHU,
            this.emptySpaceItem2,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.lblMacDinh,
            this.layoutControlItem4});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(844, 434);
            this.Root.TextVisible = false;
            // 
            // lblTEN_QG_H
            // 
            this.lblTEN_QG_H.Control = this.txtTEN_QG_H;
            this.lblTEN_QG_H.Location = new System.Drawing.Point(0, 72);
            this.lblTEN_QG_H.Name = "lblTEN_QG_H";
            this.lblTEN_QG_H.Size = new System.Drawing.Size(824, 24);
            this.lblTEN_QG_H.TextSize = new System.Drawing.Size(93, 13);
            // 
            // lblMA_QG
            // 
            this.lblMA_QG.Control = this.txtMA_QG;
            this.lblMA_QG.Location = new System.Drawing.Point(0, 0);
            this.lblMA_QG.Name = "lblMA_QG";
            this.lblMA_QG.Size = new System.Drawing.Size(697, 24);
            this.lblMA_QG.TextSize = new System.Drawing.Size(93, 13);
            // 
            // lblTEN_QG
            // 
            this.lblTEN_QG.Control = this.txtTEN_QG;
            this.lblTEN_QG.Location = new System.Drawing.Point(0, 24);
            this.lblTEN_QG.Name = "lblTEN_QG";
            this.lblTEN_QG.Size = new System.Drawing.Size(824, 24);
            this.lblTEN_QG.TextSize = new System.Drawing.Size(93, 13);
            // 
            // lblTEN_QG_A
            // 
            this.lblTEN_QG_A.Control = this.txtTEN_QG_A;
            this.lblTEN_QG_A.Location = new System.Drawing.Point(0, 48);
            this.lblTEN_QG_A.Name = "lblTEN_QG_A";
            this.lblTEN_QG_A.Size = new System.Drawing.Size(824, 24);
            this.lblTEN_QG_A.TextSize = new System.Drawing.Size(93, 13);
            // 
            // lblGHI_CHU
            // 
            this.lblGHI_CHU.Control = this.txtGHI_CHU;
            this.lblGHI_CHU.Location = new System.Drawing.Point(0, 96);
            this.lblGHI_CHU.Name = "lblGHI_CHU";
            this.lblGHI_CHU.Size = new System.Drawing.Size(824, 46);
            this.lblGHI_CHU.TextSize = new System.Drawing.Size(93, 13);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 142);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(824, 210);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 376);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(1, 1);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(596, 38);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnKhongGhi;
            this.layoutControlItem2.Location = new System.Drawing.Point(710, 376);
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
            // lblMacDinh
            // 
            this.lblMacDinh.Control = this.chkMAC_DINH;
            this.lblMacDinh.Location = new System.Drawing.Point(697, 0);
            this.lblMacDinh.Name = "lblMacDinh";
            this.lblMacDinh.Size = new System.Drawing.Size(127, 24);
            this.lblMacDinh.TextSize = new System.Drawing.Size(0, 0);
            this.lblMacDinh.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.buttonEdit11;
            this.layoutControlItem4.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 352);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(824, 24);
            this.layoutControlItem4.Text = "layoutControlItem2";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(93, 13);
            this.layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // FrmEditQuocGia
            // 
            this.ClientSize = new System.Drawing.Size(844, 434);
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "FrmEditQuocGia";
            this.Text = "FrmEditQuocGia";
            this.Load += new System.EventHandler(this.FrmEditQuocGia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtMA_QG.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_QG_A.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_QG.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_QG_H.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGHI_CHU.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMAC_DINH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit11.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTEN_QG_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMA_QG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTEN_QG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTEN_QG_A)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGHI_CHU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMacDinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit txtMA_QG;
        private DevExpress.XtraEditors.TextEdit txtTEN_QG_H;
        private DevExpress.XtraLayout.LayoutControlItem lblTEN_QG_H;
        private DevExpress.XtraLayout.LayoutControlItem lblMA_QG;
        private DevExpress.XtraEditors.TextEdit txtTEN_QG_A;
        private DevExpress.XtraEditors.TextEdit txtTEN_QG;
        private DevExpress.XtraLayout.LayoutControlItem lblTEN_QG;
        private DevExpress.XtraLayout.LayoutControlItem lblTEN_QG_A;
        private DevExpress.XtraEditors.MemoEdit txtGHI_CHU;
        private DevExpress.XtraLayout.LayoutControlItem lblGHI_CHU;
        private DevExpress.XtraEditors.SimpleButton btnGhi;
        private DevExpress.XtraEditors.SimpleButton btnKhongGhi;
        private DevExpress.XtraEditors.CheckEdit chkMAC_DINH;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem lblMacDinh;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}