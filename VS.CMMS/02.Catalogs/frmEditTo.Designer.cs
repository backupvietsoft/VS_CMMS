namespace VS.CMMS
{
    partial class frmEditTo
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
            this.cboID_PB = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtTEN_TO_H = new DevExpress.XtraEditors.TextEdit();
            this.txtTEN_TO_A = new DevExpress.XtraEditors.TextEdit();
            this.txtTEN_TO = new DevExpress.XtraEditors.TextEdit();
            this.btnKhongGhi = new DevExpress.XtraEditors.SimpleButton();
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.txtSTT = new DevExpress.XtraEditors.SpinEdit();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lblTEN_TO = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lciKhongGhi = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciGhi = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblTEN_TO_A = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblTEN_TO_H = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblID_PB = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblSTT = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboID_PB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_TO_H.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_TO_A.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_TO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSTT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTEN_TO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciKhongGhi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGhi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTEN_TO_A)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTEN_TO_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblID_PB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSTT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.cboID_PB);
            this.dataLayoutControl1.Controls.Add(this.txtTEN_TO_H);
            this.dataLayoutControl1.Controls.Add(this.txtTEN_TO_A);
            this.dataLayoutControl1.Controls.Add(this.txtTEN_TO);
            this.dataLayoutControl1.Controls.Add(this.btnKhongGhi);
            this.dataLayoutControl1.Controls.Add(this.btnGhi);
            this.dataLayoutControl1.Controls.Add(this.txtSTT);
            this.dataLayoutControl1.Controls.Add(this.textEdit1);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(684, 455);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // cboID_PB
            // 
            this.cboID_PB.EditValue = "";
            this.cboID_PB.Location = new System.Drawing.Point(117, 12);
            this.cboID_PB.Name = "cboID_PB";
            this.cboID_PB.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboID_PB.Properties.NullText = "";
            this.cboID_PB.Properties.PopupView = this.searchLookUpEdit1View;
            this.cboID_PB.Size = new System.Drawing.Size(227, 20);
            this.cboID_PB.StyleController = this.dataLayoutControl1;
            this.cboID_PB.TabIndex = 13;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.Greater;
            conditionValidationRule1.ErrorText = "This value is not valid";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            conditionValidationRule1.Value1 = -1;
            this.dxValidationProvider1.SetValidationRule(this.cboID_PB, conditionValidationRule1);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // txtTEN_TO_H
            // 
            this.txtTEN_TO_H.Location = new System.Drawing.Point(117, 84);
            this.txtTEN_TO_H.Name = "txtTEN_TO_H";
            this.txtTEN_TO_H.Size = new System.Drawing.Size(555, 20);
            this.txtTEN_TO_H.StyleController = this.dataLayoutControl1;
            this.txtTEN_TO_H.TabIndex = 7;
            // 
            // txtTEN_TO_A
            // 
            this.txtTEN_TO_A.Location = new System.Drawing.Point(117, 60);
            this.txtTEN_TO_A.Name = "txtTEN_TO_A";
            this.txtTEN_TO_A.Size = new System.Drawing.Size(555, 20);
            this.txtTEN_TO_A.StyleController = this.dataLayoutControl1;
            this.txtTEN_TO_A.TabIndex = 6;
            // 
            // txtTEN_TO
            // 
            this.txtTEN_TO.Location = new System.Drawing.Point(117, 36);
            this.txtTEN_TO.Name = "txtTEN_TO";
            this.txtTEN_TO.Size = new System.Drawing.Size(555, 20);
            this.txtTEN_TO.StyleController = this.dataLayoutControl1;
            this.txtTEN_TO.TabIndex = 5;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "This value is not valid";
            this.dxValidationProvider1.SetValidationRule(this.txtTEN_TO, conditionValidationRule2);
            // 
            // btnKhongGhi
            // 
            this.btnKhongGhi.Location = new System.Drawing.Point(562, 409);
            this.btnKhongGhi.Name = "btnKhongGhi";
            this.btnKhongGhi.Size = new System.Drawing.Size(110, 34);
            this.btnKhongGhi.StyleController = this.dataLayoutControl1;
            this.btnKhongGhi.TabIndex = 11;
            this.btnKhongGhi.Text = "btnKhongGhi";
            this.btnKhongGhi.Click += new System.EventHandler(this.btnKhongGhi_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.Location = new System.Drawing.Point(448, 409);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(110, 34);
            this.btnGhi.StyleController = this.dataLayoutControl1;
            this.btnGhi.TabIndex = 12;
            this.btnGhi.Text = "btnGhi";
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // txtSTT
            // 
            this.txtSTT.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSTT.Location = new System.Drawing.Point(453, 12);
            this.txtSTT.Name = "txtSTT";
            this.txtSTT.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtSTT.Properties.DisplayFormat.FormatString = "n0";
            this.txtSTT.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSTT.Properties.EditFormat.FormatString = "n0";
            this.txtSTT.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSTT.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txtSTT.Properties.MaskSettings.Set("mask", "n0");
            this.txtSTT.Size = new System.Drawing.Size(219, 20);
            this.txtSTT.StyleController = this.dataLayoutControl1;
            this.txtSTT.TabIndex = 8;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.GreaterOrEqual;
            conditionValidationRule3.ErrorText = "This value is not valid";
            conditionValidationRule3.Value1 = 0;
            this.dxValidationProvider1.SetValidationRule(this.txtSTT, conditionValidationRule3);
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(117, 385);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(555, 20);
            this.textEdit1.StyleController = this.dataLayoutControl1;
            this.textEdit1.TabIndex = 14;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lblTEN_TO,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.lciKhongGhi,
            this.lciGhi,
            this.lblTEN_TO_A,
            this.lblTEN_TO_H,
            this.lblID_PB,
            this.lblSTT,
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(684, 455);
            this.Root.TextVisible = false;
            // 
            // lblTEN_TO
            // 
            this.lblTEN_TO.Control = this.txtTEN_TO;
            this.lblTEN_TO.Location = new System.Drawing.Point(0, 24);
            this.lblTEN_TO.Name = "lblTEN_TO";
            this.lblTEN_TO.Size = new System.Drawing.Size(664, 24);
            this.lblTEN_TO.TextSize = new System.Drawing.Size(93, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 96);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(664, 277);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 397);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(436, 38);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lciKhongGhi
            // 
            this.lciKhongGhi.Control = this.btnKhongGhi;
            this.lciKhongGhi.Location = new System.Drawing.Point(550, 397);
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
            this.lciGhi.Location = new System.Drawing.Point(436, 397);
            this.lciGhi.MaxSize = new System.Drawing.Size(114, 38);
            this.lciGhi.MinSize = new System.Drawing.Size(114, 38);
            this.lciGhi.Name = "lciGhi";
            this.lciGhi.Size = new System.Drawing.Size(114, 38);
            this.lciGhi.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciGhi.TextSize = new System.Drawing.Size(0, 0);
            this.lciGhi.TextVisible = false;
            // 
            // lblTEN_TO_A
            // 
            this.lblTEN_TO_A.Control = this.txtTEN_TO_A;
            this.lblTEN_TO_A.Location = new System.Drawing.Point(0, 48);
            this.lblTEN_TO_A.Name = "lblTEN_TO_A";
            this.lblTEN_TO_A.Size = new System.Drawing.Size(664, 24);
            this.lblTEN_TO_A.TextSize = new System.Drawing.Size(93, 13);
            // 
            // lblTEN_TO_H
            // 
            this.lblTEN_TO_H.Control = this.txtTEN_TO_H;
            this.lblTEN_TO_H.Location = new System.Drawing.Point(0, 72);
            this.lblTEN_TO_H.Name = "lblTEN_TO_H";
            this.lblTEN_TO_H.Size = new System.Drawing.Size(664, 24);
            this.lblTEN_TO_H.TextSize = new System.Drawing.Size(93, 13);
            // 
            // lblID_PB
            // 
            this.lblID_PB.Control = this.cboID_PB;
            this.lblID_PB.CustomizationFormText = "lblID_NM";
            this.lblID_PB.Location = new System.Drawing.Point(0, 0);
            this.lblID_PB.Name = "lblID_PB";
            this.lblID_PB.Size = new System.Drawing.Size(336, 24);
            this.lblID_PB.TextSize = new System.Drawing.Size(93, 13);
            // 
            // lblSTT
            // 
            this.lblSTT.Control = this.txtSTT;
            this.lblSTT.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblSTT.CustomizationFormText = "lblSTT_LM";
            this.lblSTT.Location = new System.Drawing.Point(336, 0);
            this.lblSTT.Name = "lblSTT";
            this.lblSTT.Size = new System.Drawing.Size(328, 24);
            this.lblSTT.TextSize = new System.Drawing.Size(93, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.textEdit1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 373);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(664, 24);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(93, 13);
            this.layoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // frmEditTo
            // 
            this.ClientSize = new System.Drawing.Size(684, 455);
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "frmEditTo";
            this.Text = "frmEditTo";
            this.Load += new System.EventHandler(this.frmEditTo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboID_PB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_TO_H.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_TO_A.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_TO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSTT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTEN_TO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciKhongGhi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGhi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTEN_TO_A)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTEN_TO_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblID_PB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSTT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit txtTEN_TO_H;
        private DevExpress.XtraEditors.TextEdit txtTEN_TO_A;
        private DevExpress.XtraEditors.TextEdit txtTEN_TO;
        private DevExpress.XtraLayout.LayoutControlItem lblTEN_TO;
        private DevExpress.XtraLayout.LayoutControlItem lblTEN_TO_A;
        private DevExpress.XtraLayout.LayoutControlItem lblTEN_TO_H;
        private DevExpress.XtraEditors.SimpleButton btnKhongGhi;
        private DevExpress.XtraEditors.SimpleButton btnGhi;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem lciKhongGhi;
        private DevExpress.XtraLayout.LayoutControlItem lciGhi;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.SearchLookUpEdit cboID_PB;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem lblID_PB;
        private System.Windows.Forms.FontDialog fontDialog1;
        private DevExpress.XtraEditors.SpinEdit txtSTT;
        private DevExpress.XtraLayout.LayoutControlItem lblSTT;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}