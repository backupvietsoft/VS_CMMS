namespace VS.CMMS
{
    partial class frmTestZalo
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
            this.dxValidationProvider11 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdZalo = new DevExpress.XtraGrid.GridControl();
            this.grvZalo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnGui = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh_token = new DevExpress.XtraEditors.SimpleButton();
            this.txtZalo = new DevExpress.XtraEditors.ButtonEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lblGui = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtRefresh_token = new DevExpress.XtraEditors.ButtonEdit();
            this.lblRefresh_token = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtAccess_token = new DevExpress.XtraEditors.ButtonEdit();
            this.lblAccess_token = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtTime = new DevExpress.XtraEditors.ButtonEdit();
            this.lblTime = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdZalo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZalo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZalo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGui)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRefresh_token.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRefresh_token)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccess_token.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAccess_token)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTime)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdZalo);
            this.layoutControl1.Controls.Add(this.btnGui);
            this.layoutControl1.Controls.Add(this.btnRefresh_token);
            this.layoutControl1.Controls.Add(this.txtZalo);
            this.layoutControl1.Controls.Add(this.txtRefresh_token);
            this.layoutControl1.Controls.Add(this.txtAccess_token);
            this.layoutControl1.Controls.Add(this.txtTime);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(812, 96, 812, 500);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(844, 434);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdZalo
            // 
            this.grdZalo.Location = new System.Drawing.Point(12, 12);
            this.grdZalo.MainView = this.grvZalo;
            this.grdZalo.Name = "grdZalo";
            this.grdZalo.Size = new System.Drawing.Size(820, 280);
            this.grdZalo.TabIndex = 14;
            this.grdZalo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvZalo});
            // 
            // grvZalo
            // 
            this.grvZalo.GridControl = this.grdZalo;
            this.grvZalo.Name = "grvZalo";
            this.grvZalo.OptionsView.ShowGroupPanel = false;
            // 
            // btnGui
            // 
            this.btnGui.Location = new System.Drawing.Point(629, 392);
            this.btnGui.Name = "btnGui";
            this.btnGui.Size = new System.Drawing.Size(99, 30);
            this.btnGui.StyleController = this.layoutControl1;
            this.btnGui.TabIndex = 10;
            this.btnGui.Text = "btnGui";
            this.btnGui.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // btnRefresh_token
            // 
            this.btnRefresh_token.Location = new System.Drawing.Point(732, 392);
            this.btnRefresh_token.Name = "btnRefresh_token";
            this.btnRefresh_token.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh_token.StyleController = this.layoutControl1;
            this.btnRefresh_token.TabIndex = 9;
            this.btnRefresh_token.Text = "btnRefresh_token";
            this.btnRefresh_token.Click += new System.EventHandler(this.btnRefresh_token_Click);
            // 
            // txtZalo
            // 
            this.txtZalo.Location = new System.Drawing.Point(105, 296);
            this.txtZalo.Name = "txtZalo";
            this.txtZalo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtZalo.Size = new System.Drawing.Size(727, 20);
            this.txtZalo.StyleController = this.layoutControl1;
            this.txtZalo.TabIndex = 13;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.emptySpaceItem1,
            this.lblGui,
            this.layoutControlItem1,
            this.lblRefresh_token,
            this.lblAccess_token,
            this.lblTime});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(844, 434);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnRefresh_token;
            this.layoutControlItem6.Location = new System.Drawing.Point(720, 380);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(108, 34);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(1, 34);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(104, 34);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnGui;
            this.layoutControlItem7.Location = new System.Drawing.Point(617, 380);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(108, 34);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(1, 34);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(103, 34);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 380);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(617, 34);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lblGui
            // 
            this.lblGui.Control = this.txtZalo;
            this.lblGui.Location = new System.Drawing.Point(0, 284);
            this.lblGui.Name = "lblGui";
            this.lblGui.Size = new System.Drawing.Size(824, 24);
            this.lblGui.TextSize = new System.Drawing.Size(81, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdZalo;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(824, 284);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // txtRefresh_token
            // 
            this.txtRefresh_token.Location = new System.Drawing.Point(105, 320);
            this.txtRefresh_token.Name = "txtRefresh_token";
            this.txtRefresh_token.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtRefresh_token.Size = new System.Drawing.Size(727, 20);
            this.txtRefresh_token.StyleController = this.layoutControl1;
            this.txtRefresh_token.TabIndex = 13;
            // 
            // lblRefresh_token
            // 
            this.lblRefresh_token.Control = this.txtRefresh_token;
            this.lblRefresh_token.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblRefresh_token.CustomizationFormText = "lblGui";
            this.lblRefresh_token.Location = new System.Drawing.Point(0, 308);
            this.lblRefresh_token.Name = "lblRefresh_token";
            this.lblRefresh_token.Size = new System.Drawing.Size(824, 24);
            this.lblRefresh_token.Text = "lblRefresh_token";
            this.lblRefresh_token.TextSize = new System.Drawing.Size(81, 13);
            // 
            // txtAccess_token
            // 
            this.txtAccess_token.Location = new System.Drawing.Point(105, 344);
            this.txtAccess_token.Name = "txtAccess_token";
            this.txtAccess_token.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtAccess_token.Size = new System.Drawing.Size(727, 20);
            this.txtAccess_token.StyleController = this.layoutControl1;
            this.txtAccess_token.TabIndex = 13;
            // 
            // lblAccess_token
            // 
            this.lblAccess_token.Control = this.txtAccess_token;
            this.lblAccess_token.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblAccess_token.CustomizationFormText = "lblGui";
            this.lblAccess_token.Location = new System.Drawing.Point(0, 332);
            this.lblAccess_token.Name = "lblAccess_token";
            this.lblAccess_token.Size = new System.Drawing.Size(824, 24);
            this.lblAccess_token.Text = "lblAccess_token";
            this.lblAccess_token.TextSize = new System.Drawing.Size(81, 13);
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(105, 368);
            this.txtTime.Name = "txtTime";
            this.txtTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtTime.Size = new System.Drawing.Size(727, 20);
            this.txtTime.StyleController = this.layoutControl1;
            this.txtTime.TabIndex = 13;
            // 
            // lblTime
            // 
            this.lblTime.Control = this.txtTime;
            this.lblTime.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblTime.CustomizationFormText = "lblGui";
            this.lblTime.Location = new System.Drawing.Point(0, 356);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(824, 24);
            this.lblTime.Text = "lblTime";
            this.lblTime.TextSize = new System.Drawing.Size(81, 13);
            // 
            // frmTestZalo
            // 
            this.ClientSize = new System.Drawing.Size(844, 434);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmTestZalo";
            this.Text = "frmTestZalo";
            this.Load += new System.EventHandler(this.frmTestZalo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdZalo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZalo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZalo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGui)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRefresh_token.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRefresh_token)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccess_token.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAccess_token)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider11;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SimpleButton btnGui;
        private DevExpress.XtraEditors.SimpleButton btnRefresh_token;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.ButtonEdit txtZalo;
        private DevExpress.XtraLayout.LayoutControlItem lblGui;
        private DevExpress.XtraGrid.GridControl grdZalo;
        private DevExpress.XtraGrid.Views.Grid.GridView grvZalo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.ButtonEdit txtRefresh_token;
        private DevExpress.XtraLayout.LayoutControlItem lblRefresh_token;
        private DevExpress.XtraEditors.ButtonEdit txtAccess_token;
        private DevExpress.XtraLayout.LayoutControlItem lblAccess_token;
        private DevExpress.XtraEditors.ButtonEdit txtTime;
        private DevExpress.XtraLayout.LayoutControlItem lblTime;
    }
}