namespace VS.CMMS
{
    partial class frmEditCa
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.btnKhongGhi = new DevExpress.XtraEditors.SimpleButton();
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lciKhongGhi = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciGhi = new DevExpress.XtraLayout.LayoutControlItem();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.txtTENCA_H = new DevExpress.XtraEditors.TextEdit();
            this.txtTENCA_A = new DevExpress.XtraEditors.TextEdit();
            this.txtTENCA = new DevExpress.XtraEditors.TextEdit();
            this.txtDEN_GIO = new DevExpress.XtraEditors.TimeEdit();
            this.chkCaDem = new DevExpress.XtraEditors.CheckEdit();
            this.txtTU_GIO = new DevExpress.XtraEditors.TimeEdit();
            this.lblTEN_CA = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblTEN_CA_A = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblTEN_CA_H = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblTU_GIO = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblDEN_GIO = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciKhongGhi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGhi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTENCA_H.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTENCA_A.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTENCA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDEN_GIO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCaDem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTU_GIO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTEN_CA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTEN_CA_A)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTEN_CA_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTU_GIO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDEN_GIO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.txtTENCA_H);
            this.dataLayoutControl1.Controls.Add(this.txtTENCA_A);
            this.dataLayoutControl1.Controls.Add(this.txtTENCA);
            this.dataLayoutControl1.Controls.Add(this.btnKhongGhi);
            this.dataLayoutControl1.Controls.Add(this.btnGhi);
            this.dataLayoutControl1.Controls.Add(this.txtDEN_GIO);
            this.dataLayoutControl1.Controls.Add(this.chkCaDem);
            this.dataLayoutControl1.Controls.Add(this.txtTU_GIO);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(683, 432);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // btnKhongGhi
            // 
            this.btnKhongGhi.Location = new System.Drawing.Point(842, 579);
            this.btnKhongGhi.Name = "btnKhongGhi";
            this.btnKhongGhi.Size = new System.Drawing.Size(110, 34);
            this.btnKhongGhi.StyleController = this.dataLayoutControl1;
            this.btnKhongGhi.TabIndex = 11;
            this.btnKhongGhi.Text = "btnKhongGhi";
            this.btnKhongGhi.Click += new System.EventHandler(this.btnKhongGhi_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.Location = new System.Drawing.Point(671, 579);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(110, 34);
            this.btnGhi.StyleController = this.dataLayoutControl1;
            this.btnGhi.TabIndex = 12;
            this.btnGhi.Text = "btnGhi";
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lblTEN_CA,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.lciKhongGhi,
            this.lciGhi,
            this.lblTEN_CA_A,
            this.lblTEN_CA_H,
            this.lblTU_GIO,
            this.lblDEN_GIO,
            this.layoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(683, 432);
            this.Root.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 153);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(663, 221);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 374);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(435, 38);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lciKhongGhi
            // 
            this.lciKhongGhi.Control = this.btnKhongGhi;
            this.lciKhongGhi.Location = new System.Drawing.Point(549, 374);
            this.lciKhongGhi.MaxSize = new System.Drawing.Size(114, 38);
            this.lciKhongGhi.MinSize = new System.Drawing.Size(114, 38);
            this.lciKhongGhi.Name = "lciKhongGhi";
            this.lciKhongGhi.Size = new System.Drawing.Size(114, 38);
            this.lciKhongGhi.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciKhongGhi.TextSize = new System.Drawing.Size(0, 0);
            this.lciKhongGhi.TextVisible = false;
            // 
            // lciGhi
            // 
            this.lciGhi.Control = this.btnGhi;
            this.lciGhi.Location = new System.Drawing.Point(435, 374);
            this.lciGhi.MaxSize = new System.Drawing.Size(114, 38);
            this.lciGhi.MinSize = new System.Drawing.Size(114, 38);
            this.lciGhi.Name = "lciGhi";
            this.lciGhi.Size = new System.Drawing.Size(114, 38);
            this.lciGhi.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciGhi.TextSize = new System.Drawing.Size(0, 0);
            this.lciGhi.TextVisible = false;
            // 
            // txtTENCA_H
            // 
            this.txtTENCA_H.Location = new System.Drawing.Point(121, 72);
            this.txtTENCA_H.Name = "txtTENCA_H";
            this.txtTENCA_H.Size = new System.Drawing.Size(825, 39);
            this.txtTENCA_H.StyleController = this.dataLayoutControl1;
            this.txtTENCA_H.TabIndex = 7;
            // 
            // txtTENCA_A
            // 
            this.txtTENCA_A.Location = new System.Drawing.Point(121, 42);
            this.txtTENCA_A.Name = "txtTENCA_A";
            this.txtTENCA_A.Size = new System.Drawing.Size(825, 39);
            this.txtTENCA_A.StyleController = this.dataLayoutControl1;
            this.txtTENCA_A.TabIndex = 6;
            // 
            // txtTENCA
            // 
            this.txtTENCA.Location = new System.Drawing.Point(121, 12);
            this.txtTENCA.Name = "txtTENCA";
            this.txtTENCA.Size = new System.Drawing.Size(825, 39);
            this.txtTENCA.StyleController = this.dataLayoutControl1;
            this.txtTENCA.TabIndex = 5;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            this.dxValidationProvider1.SetValidationRule(this.txtTENCA, conditionValidationRule1);
            // 
            // txtDEN_GIO
            // 
            this.txtDEN_GIO.EditValue = null;
            this.txtDEN_GIO.Location = new System.Drawing.Point(678, 153);
            this.txtDEN_GIO.Name = "txtDEN_GIO";
            this.txtDEN_GIO.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDEN_GIO.Properties.EditFormat.FormatString = "t";
            this.txtDEN_GIO.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.DateTimeMaskManager));
            this.txtDEN_GIO.Properties.MaskSettings.Set("mask", "t");
            this.txtDEN_GIO.Size = new System.Drawing.Size(219, 28);
            this.txtDEN_GIO.StyleController = this.dataLayoutControl1;
            this.txtDEN_GIO.TabIndex = 8;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "This value is not valid";
            this.dxValidationProvider1.SetValidationRule(this.txtDEN_GIO, conditionValidationRule2);
            // 
            // chkCaDem
            // 
            this.chkCaDem.Location = new System.Drawing.Point(12, 134);
            this.chkCaDem.Name = "chkCaDem";
            this.chkCaDem.Properties.Caption = "chkCaDem";
            this.chkCaDem.Size = new System.Drawing.Size(989, 41);
            this.chkCaDem.StyleController = this.dataLayoutControl1;
            this.chkCaDem.TabIndex = 15;
            // 
            // txtTU_GIO
            // 
            this.txtTU_GIO.EditValue = null;
            this.txtTU_GIO.Location = new System.Drawing.Point(121, 102);
            this.txtTU_GIO.Name = "txtTU_GIO";
            this.txtTU_GIO.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTU_GIO.Properties.DisplayFormat.FormatString = "t";
            this.txtTU_GIO.Properties.EditFormat.FormatString = "t";
            this.txtTU_GIO.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txtTU_GIO.Properties.MaskSettings.Set("mask", "t");
            this.txtTU_GIO.Properties.UseMaskAsDisplayFormat = true;
            this.txtTU_GIO.Size = new System.Drawing.Size(327, 42);
            this.txtTU_GIO.StyleController = this.dataLayoutControl1;
            this.txtTU_GIO.TabIndex = 10;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "This value is not valid";
            this.dxValidationProvider1.SetValidationRule(this.txtTU_GIO, conditionValidationRule3);
            // 
            // lblTEN_CA
            // 
            this.lblTEN_CA.Control = this.txtTENCA;
            this.lblTEN_CA.Location = new System.Drawing.Point(0, 0);
            this.lblTEN_CA.Name = "lblTEN_CA";
            this.lblTEN_CA.Size = new System.Drawing.Size(663, 30);
            this.lblTEN_CA.TextSize = new System.Drawing.Size(97, 19);
            // 
            // lblTEN_CA_A
            // 
            this.lblTEN_CA_A.Control = this.txtTENCA_A;
            this.lblTEN_CA_A.Location = new System.Drawing.Point(0, 30);
            this.lblTEN_CA_A.Name = "lblTEN_CA_A";
            this.lblTEN_CA_A.Size = new System.Drawing.Size(663, 30);
            this.lblTEN_CA_A.TextSize = new System.Drawing.Size(97, 19);
            // 
            // lblTEN_CA_H
            // 
            this.lblTEN_CA_H.Control = this.txtTENCA_H;
            this.lblTEN_CA_H.Location = new System.Drawing.Point(0, 60);
            this.lblTEN_CA_H.Name = "lblTEN_CA_H";
            this.lblTEN_CA_H.Size = new System.Drawing.Size(663, 30);
            this.lblTEN_CA_H.TextSize = new System.Drawing.Size(97, 19);
            // 
            // lblTU_GIO
            // 
            this.lblTU_GIO.Control = this.txtTU_GIO;
            this.lblTU_GIO.Location = new System.Drawing.Point(0, 90);
            this.lblTU_GIO.Name = "lblTU_GIO";
            this.lblTU_GIO.Size = new System.Drawing.Size(331, 32);
            this.lblTU_GIO.TextSize = new System.Drawing.Size(97, 19);
            // 
            // lblDEN_GIO
            // 
            this.lblDEN_GIO.Control = this.txtDEN_GIO;
            this.lblDEN_GIO.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblDEN_GIO.CustomizationFormText = "lblSTT_LM";
            this.lblDEN_GIO.Location = new System.Drawing.Point(331, 90);
            this.lblDEN_GIO.Name = "lblDEN_GIO";
            this.lblDEN_GIO.Size = new System.Drawing.Size(332, 32);
            this.lblDEN_GIO.TextSize = new System.Drawing.Size(97, 19);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.chkCaDem;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 122);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(663, 31);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // frmEditCa
            // 
            this.ClientSize = new System.Drawing.Size(455, 288);
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "frmEditCa";
            this.Text = "frmEditCa";
            this.Load += new System.EventHandler(this.frmEditCa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciKhongGhi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGhi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTENCA_H.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTENCA_A.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTENCA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDEN_GIO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCaDem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTU_GIO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTEN_CA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTEN_CA_A)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTEN_CA_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTU_GIO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDEN_GIO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit txtTENCA_H;
        private DevExpress.XtraEditors.TextEdit txtTENCA_A;
        private DevExpress.XtraEditors.TextEdit txtTENCA;
        private DevExpress.XtraLayout.LayoutControlItem lblTEN_CA;
        private DevExpress.XtraLayout.LayoutControlItem lblTEN_CA_A;
        private DevExpress.XtraLayout.LayoutControlItem lblTEN_CA_H;
        private DevExpress.XtraLayout.LayoutControlItem lblTU_GIO;
        private DevExpress.XtraEditors.SimpleButton btnKhongGhi;
        private DevExpress.XtraEditors.SimpleButton btnGhi;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem lciKhongGhi;
        private DevExpress.XtraLayout.LayoutControlItem lciGhi;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraLayout.LayoutControlItem lblDEN_GIO;
        private DevExpress.XtraEditors.TimeEdit txtDEN_GIO;
        private DevExpress.XtraEditors.CheckEdit chkCaDem;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.TimeEdit txtTU_GIO;
    }
}