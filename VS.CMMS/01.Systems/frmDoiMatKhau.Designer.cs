namespace VS.CMMS
{
    partial class frmDoiMatKhau
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
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.txtUSER_NAME = new DevExpress.XtraEditors.TextEdit();
            this.txtPASSWORD_OLD = new DevExpress.XtraEditors.TextEdit();
            this.txtPASSWORD_NEW = new DevExpress.XtraEditors.TextEdit();
            this.txtPASSWORD_NEW_RE = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lblUSER_NAME = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblPASSWORD_OLD = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblPASSWORD_NEW = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblPASSWORD_NEW_RE = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.textEdit11 = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUSER_NAME.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPASSWORD_OLD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPASSWORD_NEW.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPASSWORD_NEW_RE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUSER_NAME)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPASSWORD_OLD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPASSWORD_NEW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPASSWORD_NEW_RE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit11.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(335, 151);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(104, 30);
            this.btnThoat.StyleController = this.dataLayoutControl1;
            this.btnThoat.TabIndex = 9;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.btnThoat);
            this.dataLayoutControl1.Controls.Add(this.btnLuu);
            this.dataLayoutControl1.Controls.Add(this.txtUSER_NAME);
            this.dataLayoutControl1.Controls.Add(this.txtPASSWORD_OLD);
            this.dataLayoutControl1.Controls.Add(this.txtPASSWORD_NEW);
            this.dataLayoutControl1.Controls.Add(this.txtPASSWORD_NEW_RE);
            this.dataLayoutControl1.Controls.Add(this.textEdit11);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(451, 193);
            this.dataLayoutControl1.TabIndex = 12;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(227, 151);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(104, 30);
            this.btnLuu.StyleController = this.dataLayoutControl1;
            this.btnLuu.TabIndex = 8;
            this.btnLuu.Text = "btnLuu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // txtUSER_NAME
            // 
            this.txtUSER_NAME.Location = new System.Drawing.Point(139, 12);
            this.txtUSER_NAME.Name = "txtUSER_NAME";
            this.txtUSER_NAME.Size = new System.Drawing.Size(300, 20);
            this.txtUSER_NAME.StyleController = this.dataLayoutControl1;
            this.txtUSER_NAME.TabIndex = 4;
            // 
            // txtPASSWORD_OLD
            // 
            this.txtPASSWORD_OLD.Location = new System.Drawing.Point(139, 36);
            this.txtPASSWORD_OLD.Name = "txtPASSWORD_OLD";
            this.txtPASSWORD_OLD.Properties.PasswordChar = '*';
            this.txtPASSWORD_OLD.Properties.UseSystemPasswordChar = true;
            this.txtPASSWORD_OLD.Size = new System.Drawing.Size(300, 20);
            this.txtPASSWORD_OLD.StyleController = this.dataLayoutControl1;
            this.txtPASSWORD_OLD.TabIndex = 4;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.txtPASSWORD_OLD, conditionValidationRule1);
            // 
            // txtPASSWORD_NEW
            // 
            this.txtPASSWORD_NEW.Location = new System.Drawing.Point(139, 60);
            this.txtPASSWORD_NEW.Name = "txtPASSWORD_NEW";
            this.txtPASSWORD_NEW.Properties.PasswordChar = '*';
            this.txtPASSWORD_NEW.Properties.UseSystemPasswordChar = true;
            this.txtPASSWORD_NEW.Size = new System.Drawing.Size(300, 20);
            this.txtPASSWORD_NEW.StyleController = this.dataLayoutControl1;
            this.txtPASSWORD_NEW.TabIndex = 4;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "This value is not valid";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.txtPASSWORD_NEW, conditionValidationRule2);
            // 
            // txtPASSWORD_NEW_RE
            // 
            this.txtPASSWORD_NEW_RE.Location = new System.Drawing.Point(139, 84);
            this.txtPASSWORD_NEW_RE.Name = "txtPASSWORD_NEW_RE";
            this.txtPASSWORD_NEW_RE.Properties.PasswordChar = '*';
            this.txtPASSWORD_NEW_RE.Properties.UseSystemPasswordChar = true;
            this.txtPASSWORD_NEW_RE.Size = new System.Drawing.Size(300, 20);
            this.txtPASSWORD_NEW_RE.StyleController = this.dataLayoutControl1;
            this.txtPASSWORD_NEW_RE.TabIndex = 4;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "This value is not valid";
            conditionValidationRule3.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.txtPASSWORD_NEW_RE, conditionValidationRule3);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lblUSER_NAME,
            this.lblPASSWORD_OLD,
            this.lblPASSWORD_NEW,
            this.lblPASSWORD_NEW_RE,
            this.emptySpaceItem3,
            this.emptySpaceItem4,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(451, 193);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // lblUSER_NAME
            // 
            this.lblUSER_NAME.Control = this.txtUSER_NAME;
            this.lblUSER_NAME.Location = new System.Drawing.Point(0, 0);
            this.lblUSER_NAME.Name = "lblUSER_NAME";
            this.lblUSER_NAME.Size = new System.Drawing.Size(431, 24);
            this.lblUSER_NAME.TextSize = new System.Drawing.Size(115, 13);
            // 
            // lblPASSWORD_OLD
            // 
            this.lblPASSWORD_OLD.Control = this.txtPASSWORD_OLD;
            this.lblPASSWORD_OLD.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblPASSWORD_OLD.CustomizationFormText = "layoutControlItem3";
            this.lblPASSWORD_OLD.Location = new System.Drawing.Point(0, 24);
            this.lblPASSWORD_OLD.Name = "lblPASSWORD_OLD";
            this.lblPASSWORD_OLD.Size = new System.Drawing.Size(431, 24);
            this.lblPASSWORD_OLD.TextSize = new System.Drawing.Size(115, 13);
            // 
            // lblPASSWORD_NEW
            // 
            this.lblPASSWORD_NEW.Control = this.txtPASSWORD_NEW;
            this.lblPASSWORD_NEW.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblPASSWORD_NEW.CustomizationFormText = "layoutControlItem3";
            this.lblPASSWORD_NEW.Location = new System.Drawing.Point(0, 48);
            this.lblPASSWORD_NEW.Name = "lblPASSWORD_NEW";
            this.lblPASSWORD_NEW.Size = new System.Drawing.Size(431, 24);
            this.lblPASSWORD_NEW.TextSize = new System.Drawing.Size(115, 13);
            // 
            // lblPASSWORD_NEW_RE
            // 
            this.lblPASSWORD_NEW_RE.Control = this.txtPASSWORD_NEW_RE;
            this.lblPASSWORD_NEW_RE.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblPASSWORD_NEW_RE.CustomizationFormText = "layoutControlItem3";
            this.lblPASSWORD_NEW_RE.Location = new System.Drawing.Point(0, 72);
            this.lblPASSWORD_NEW_RE.Name = "lblPASSWORD_NEW_RE";
            this.lblPASSWORD_NEW_RE.Size = new System.Drawing.Size(431, 24);
            this.lblPASSWORD_NEW_RE.TextSize = new System.Drawing.Size(115, 13);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 139);
            this.emptySpaceItem3.MinSize = new System.Drawing.Size(1, 1);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(215, 34);
            this.emptySpaceItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(0, 96);
            this.emptySpaceItem4.MinSize = new System.Drawing.Size(1, 1);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(431, 19);
            this.emptySpaceItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnLuu;
            this.layoutControlItem1.Location = new System.Drawing.Point(215, 139);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(108, 34);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(1, 34);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(108, 34);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnThoat;
            this.layoutControlItem2.Location = new System.Drawing.Point(323, 139);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(108, 34);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(1, 34);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(108, 34);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // textEdit11
            // 
            this.textEdit11.Location = new System.Drawing.Point(139, 127);
            this.textEdit11.Name = "textEdit11";
            this.textEdit11.Size = new System.Drawing.Size(300, 20);
            this.textEdit11.StyleController = this.dataLayoutControl1;
            this.textEdit11.TabIndex = 15;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.textEdit11;
            this.layoutControlItem3.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 115);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(431, 24);
            this.layoutControlItem3.Text = "layoutControlItem1";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(115, 13);
            this.layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // frmDoiMatKhau
            // 
            this.ClientSize = new System.Drawing.Size(451, 193);
            this.Controls.Add(this.dataLayoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(459, 239);
            this.Name = "frmDoiMatKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmChangePassword";
            this.Load += new System.EventHandler(this.frmChangePassword_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChangePassword_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtUSER_NAME.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPASSWORD_OLD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPASSWORD_NEW.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPASSWORD_NEW_RE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUSER_NAME)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPASSWORD_OLD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPASSWORD_NEW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPASSWORD_NEW_RE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit11.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.TextEdit txtUSER_NAME;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem lblUSER_NAME;
        private DevExpress.XtraEditors.TextEdit txtPASSWORD_OLD;
        private DevExpress.XtraEditors.TextEdit txtPASSWORD_NEW;
        private DevExpress.XtraEditors.TextEdit txtPASSWORD_NEW_RE;
        private DevExpress.XtraLayout.LayoutControlItem lblPASSWORD_OLD;
        private DevExpress.XtraLayout.LayoutControlItem lblPASSWORD_NEW;
        private DevExpress.XtraLayout.LayoutControlItem lblPASSWORD_NEW_RE;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.TextEdit textEdit11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}