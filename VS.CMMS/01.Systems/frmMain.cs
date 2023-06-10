using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraBars.Docking2010.Views.Tabbed;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VS.CMMS.Properties;
using VS.Data;

namespace VS.CMMS
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        DocumentManager manager;
        public static frmMain _instance;
        DockManager dockManager1;
        public frmMain()
        {

            _instance = this;
            InitializeComponent();
            //load skin

            VsMain.MRestorePalette();
            //load font
            try
            {
                WindowsFormsSettings.DefaultFont = new System.Drawing.Font(VS.CMMS.Properties.Settings.Default["ApplicationFontName"].ToString(), float.Parse(VS.CMMS.Properties.Settings.Default["ApplicationFontSize"].ToString()), (VS.CMMS.Properties.Settings.Default["ApplicationFontBold"].ToString().ToUpper() == "TRUE" ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular) | (VS.CMMS.Properties.Settings.Default["ApplicationFontItalic"].ToString().ToUpper() == "TRUE" ? System.Drawing.FontStyle.Italic : System.Drawing.FontStyle.Regular));

            }
            catch { WindowsFormsSettings.DefaultFont = new System.Drawing.Font("Segoe UI", float.Parse("9")); }


            try
            {
                Com.Mod.sFontSys = VS.CMMS.Properties.Settings.Default["ApplicationFontName"].ToString();
            }
            catch { Com.Mod.sFontSys = "Segoe UI"; }


            //load fonr menu
            try
            {
                DevExpress.Utils.AppearanceObject.DefaultMenuFont = new System.Drawing.Font(VS.CMMS.Properties.Settings.Default["MenuFontName"].ToString(), float.Parse(VS.CMMS.Properties.Settings.Default["MenuFontSize"].ToString()), (VS.CMMS.Properties.Settings.Default["MenuFontBold"].ToString().ToUpper() == "TRUE" ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular) | (VS.CMMS.Properties.Settings.Default["MenuFontItalic"].ToString().ToUpper() == "TRUE" ? System.Drawing.FontStyle.Italic : System.Drawing.FontStyle.Regular));

            }
            catch { DevExpress.Utils.AppearanceObject.DefaultMenuFont = new System.Drawing.Font("Segoe UI", float.Parse("12")); }

            // 
            // VSIdle
            // 
            ////_instance.VSIdle.IdleTime = System.TimeSpan.Parse("00:30:00"); // thoi gian nghi 
            ////_instance.VSIdle.WarnTime = System.TimeSpan.Parse("00:00:05"); // Bat dau bao neu còn 
            ////_instance.VSIdle.IntervalTime = int.Parse(TimeSpan.FromMinutes(1).TotalMilliseconds.ToString()); //thoi gian chay timer
            ////_instance.VSIdle.Started += new EventHandler(applicationIdle_Started);
            ////_instance.VSIdle.TickAsync += new EventHandler<TickEventArgs>(applicationIdle_TickAsync);
            ////_instance.VSIdle.Stopped += new EventHandler(applicationIdle_Stopped);
            ////_instance.VSIdle.Activity += new EventHandler<ActivityEventArgs>(applicationIdle_Activity);
            ////_instance.VSIdle.WarnAsync += new EventHandler(applicationIdle_WarnAsync);
            ////_instance.VSIdle.IdleAsync += new EventHandler(applicationIdle_IdleAsync);
            //toastNotificationsManager1.RegisterApplicationActivator(typeof(ToastNotificationActivatorCustom));





        }
        private Boolean bLicKiem = false;
        System.Timers.Timer timer = new System.Timers.Timer();


        #region -- function
        private void mTime_Tick(object sender, EventArgs e)
        {
            barInfo.Caption = "";
            mTime.Stop();
        }
        public static void BarInfoText(string sInFo)
        {
            _instance.barInfo.ItemAppearance.Normal.ForeColor = Color.FromArgb(255, 80, 80);
            _instance.barInfo.ItemAppearance.Normal.Options.UseForeColor = false;
            _instance.barInfo.Caption = sInFo;
            _instance.mTime.Start();
        }
        public static void BarInfoText(string sInFo, Boolean bLoi)
        {
            _instance.barInfo.Caption = sInFo;
            _instance.barInfo.ItemAppearance.Normal.ForeColor = System.Drawing.Color.Red;
            _instance.barInfo.ItemAppearance.Normal.Options.UseForeColor = true;
            _instance.mTime.Start();
        }
        public static bool IsFormActive(string sFrm)
        {
            if (_instance.MdiChildren.Count() > 0)
            {
                foreach (var item in _instance.MdiChildren)
                {
                    if (sFrm == item.Name)
                    {
                        item.Activate();
                        return true;
                    }
                }
            }

            #region Kiem form active
            FormCollection frmOpen = Application.OpenForms;
            List<Form> ListForm = new List<Form>();
            foreach (Form frmO in frmOpen)
            {
                if (frmO.Name == sFrm)
                {
                    frmO.Activate();
                    return true;
                }
            }

            #endregion




            return false;
        }
        public static bool CloseForm()
        {
            try
            {
                FormCollection formCollection = Application.OpenForms;
                List<Form> ListFormToClose = new List<Form>();
                foreach (Form form in formCollection)
                {
                    if (form.Name == "")
                    {
                        form.Close();
                    }
                    if (form.Name != "frmMain" && form.Name != "frmThongTinChung" && form.Name != "")
                    {
                        ListFormToClose.Add(form);
                    }
                }
                if (ListFormToClose.Count > 0)
                {
                    XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgVuiLongDongCacFormDangMo"), "VietSoft CMMS");
                    return true;
                }
                return false;
            }
            catch
            {
                return true;
            }

        }



        #region setting form
        public static void ShowChangeTheme()
        {
            //if (CloseForm()) return;
            frmChangeTheme frm = new frmChangeTheme();
            Com.Mod.OS.LocationSizeForm(_instance, frm);
            frm.ShowDialog();
        }


        public static void ShowChangeFontMeNu()
        {
            //if (CloseForm()) return;
            FontDialog dlg = new FontDialog(); //Khởi tạo đối tượng FontDialog 
            try
            {
                //dlg.Font = new Font(Settings.Default["MenuFontName"].ToString(), float.Parse(Settings.Default["MenuFontSize"].ToString()));

                dlg.Font = new System.Drawing.Font(VS.CMMS.Properties.Settings.Default["MenuFontName"].ToString(), float.Parse(VS.CMMS.Properties.Settings.Default["MenuFontSize"].ToString()), (VS.CMMS.Properties.Settings.Default["MenuFontBold"].ToString().ToUpper() == "TRUE" ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular) | (VS.CMMS.Properties.Settings.Default["MenuFontItalic"].ToString().ToUpper() == "TRUE" ? System.Drawing.FontStyle.Italic : System.Drawing.FontStyle.Regular));
            }
            catch { dlg.Font = new System.Drawing.Font("Segoe UI", float.Parse("12")); }
            //+DevExpress.Utils.AppearanceObject.DefaultMenuFont   { Name = "Segoe UI" Size = 12}


            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string fontName;
                float fontSize;
                fontName = dlg.Font.Name;
                fontSize = dlg.Font.Size;

                try
                {
                    Settings.Default["MenuFontName"] = fontName;
                    Settings.Default["MenuFontSize"] = fontSize.ToString();
                    Settings.Default["MenuFontBold"] = dlg.Font.Bold.ToString();
                    Settings.Default["MenuFontItalic"] = dlg.Font.Italic.ToString();
                }
                catch
                {
                    Settings.Default["MenuFontName"] = "Segoe UI";
                    Settings.Default["MenuFontSize"] = "12";
                    Settings.Default["MenuFontBold"] = "false";
                    Settings.Default["MenuFontItalic"] = "false";
                }
                Settings.Default.Save();
                try
                {
                    //WindowsFormsSettings.DefaultFont = new System.Drawing.Font(Settings.Default["MenuFontName"].ToString(), float.Parse(Settings.Default["MenuFontSize"].ToString()));
                    //DevExpress.Utils.AppearanceObject.DefaultMenuFont = new Font("Tahoma", 12F);

                    DevExpress.Utils.AppearanceObject.DefaultMenuFont = new System.Drawing.Font(VS.CMMS.Properties.Settings.Default["MenuFontName"].ToString(), float.Parse(VS.CMMS.Properties.Settings.Default["MenuFontSize"].ToString()), (VS.CMMS.Properties.Settings.Default["MenuFontBold"].ToString().ToUpper() == "TRUE" ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular) | (VS.CMMS.Properties.Settings.Default["MenuFontItalic"].ToString().ToUpper() == "TRUE" ? System.Drawing.FontStyle.Italic : System.Drawing.FontStyle.Regular));

                }
                catch { DevExpress.Utils.AppearanceObject.DefaultMenuFont = new System.Drawing.Font("Segoe UI", float.Parse("12")); }


            }

        }
        public static void ShowChangeFont()
        {
            //if (CloseForm()) return;
            FontDialog dlg = new FontDialog(); //Khởi tạo đối tượng FontDialog 
            try
            {
                //dlg.Font = new Font(Settings.Default["ApplicationFontName"].ToString(), float.Parse(Settings.Default["ApplicationFontSize"].ToString()));

                dlg.Font = new System.Drawing.Font(VS.CMMS.Properties.Settings.Default["ApplicationFontName"].ToString(), float.Parse(VS.CMMS.Properties.Settings.Default["ApplicationFontSize"].ToString()), (VS.CMMS.Properties.Settings.Default["ApplicationFontBold"].ToString().ToUpper() == "TRUE" ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular) | (VS.CMMS.Properties.Settings.Default["ApplicationFontItalic"].ToString().ToUpper() == "TRUE" ? System.Drawing.FontStyle.Italic : System.Drawing.FontStyle.Regular));
            }
            catch { dlg.Font = new System.Drawing.Font("Segoe UI", float.Parse("9")); }

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string fontName;
                float fontSize;
                fontName = dlg.Font.Name;
                fontSize = dlg.Font.Size;

                try
                {
                    Settings.Default["ApplicationFontName"] = fontName;
                    Settings.Default["ApplicationFontSize"] = fontSize.ToString();
                    Settings.Default["ApplicationFontBold"] = dlg.Font.Bold.ToString();
                    Settings.Default["ApplicationFontItalic"] = dlg.Font.Italic.ToString();
                }
                catch
                {
                    Settings.Default["ApplicationFontName"] = "Segoe UI";
                    Settings.Default["ApplicationFontSize"] = "9";
                    Settings.Default["ApplicationFontBold"] = "false";
                    Settings.Default["ApplicationFontItalic"] = "false";
                }
                Settings.Default.Save();
                try
                {
                    //WindowsFormsSettings.DefaultFont = new System.Drawing.Font(Settings.Default["ApplicationFontName"].ToString(), float.Parse(Settings.Default["ApplicationFontSize"].ToString()));


                    WindowsFormsSettings.DefaultFont = new System.Drawing.Font(VS.CMMS.Properties.Settings.Default["ApplicationFontName"].ToString(), float.Parse(VS.CMMS.Properties.Settings.Default["ApplicationFontSize"].ToString()), (VS.CMMS.Properties.Settings.Default["ApplicationFontBold"].ToString().ToUpper() == "TRUE" ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular) | (VS.CMMS.Properties.Settings.Default["ApplicationFontItalic"].ToString().ToUpper() == "TRUE" ? System.Drawing.FontStyle.Italic : System.Drawing.FontStyle.Regular));

                }
                catch { WindowsFormsSettings.DefaultFont = new System.Drawing.Font("Segoe UI", float.Parse("9")); }


                try
                {
                    Com.Mod.sFontSys = VS.CMMS.Properties.Settings.Default["ApplicationFontName"].ToString();
                }
                catch { Com.Mod.sFontSys = "Segoe UI"; }

            }

        }
        public static void ShowResertDefault()
        {
            //if (CloseForm()) return;

            #region default
            try
            {
                Settings.Default["ApplicationSkinName"] = "Blue";
                Settings.Default["ApplicationFontName"] = "Segoe UI";
                Settings.Default["ApplicationFontSize"] = "9";

                Settings.Default["MenuFontName"] = "Segoe UI";
                Settings.Default["MenuFontSize"] = "12";
                Settings.Default["MenuFontBold"] = "false";
                Settings.Default["MenuFontItalic"] = "false";

            }
            catch
            { }
            Settings.Default.Save();
            #endregion


            #region theme
            VsMain.MRestorePalette();
            #endregion

            #region font form
            try
            {
                WindowsFormsSettings.DefaultFont = new System.Drawing.Font(Settings.Default["ApplicationFontName"].ToString(), float.Parse(Settings.Default["ApplicationFontSize"].ToString()));
            }
            catch { WindowsFormsSettings.DefaultFont = new System.Drawing.Font("Segoe UI", float.Parse("9")); }
            #endregion


            #region font menu
            try
            {
                DevExpress.Utils.AppearanceObject.DefaultMenuFont = new System.Drawing.Font(Settings.Default["MenuFontName"].ToString(), float.Parse(Settings.Default["MenuFontSize"].ToString()));
            }
            catch { DevExpress.Utils.AppearanceObject.DefaultMenuFont = new System.Drawing.Font("Segoe UI", float.Parse("12")); }


            #endregion


        }
        #endregion




        public void AddBarItems()
        {
            bm.BeginUpdate();
            bar2.ClearLinks();
            bm.EndUpdate();

            DataTable dtRoot = new DataTable();

            string sSql = "	SELECT T1.ID_MENU, KEY_MENU,CASE " + Com.Mod.iNNgu.ToString() + " WHEN 0 THEN T1.TEN_MENU WHEN 1 THEN ISNULL(NULLIF(T1.TEN_MENU_A,''),TEN_MENU) ELSE ISNULL(NULLIF(T1.TEN_MENU_H,''),T1.TEN_MENU) END AS TEN_MENU,T1.MENU_PARENT, HIDE, BACK_COLOR, IMG, TT_MENU, CONTROLS,ISNULL(MENU_LINE,0) AS MENU_LINE, T1.MENU_PARAMETER,T1.HOT_KEY, MENU_FUN FROM dbo.MENU T1 	INNER JOIN dbo.NHOM_MENU T2 ON T1.ID_MENU = T2.ID_MENU INNER JOIN dbo.USERS T3 ON T3.ID_NHOM = T2.ID_NHOM 	WHERE (ISNULL(MENU_PARENT,'') = '0' ) AND (ISNULL(HIDE,0) = 0) AND INACTIVE = 0	AND (T3.USER_NAME = '" + Com.Mod.UName + "') ORDER BY TT_MENU ";


            dtRoot.Load(SqlHelper.ExecuteReader(Com.Mod.CNStr, "spGetMenu", Com.Mod.UName, Com.Mod.iNNgu, "0"));

            foreach (DataRow item in dtRoot.Rows)
            {
                bm.BeginUpdate();
                BarSubItem bsRoot = new BarSubItem(bm, item["TEN_MENU"].ToString());
                bsRoot.Name = item["KEY_MENU"].ToString();
                bsRoot.Tag = item["CONTROLS"].ToString();
                bsRoot.Id = int.Parse(item["ID_MENU"].ToString());
                bsRoot.Description = item["MENU_PARAMETER"].ToString();
                bsRoot.AccessibleName = item["MENU_FUN"].ToString();
                try
                {
                    bsRoot.Hint = item["BACK_COLOR"].ToString();
                }
                catch { }
                bm.MainMenu.AddItem(bsRoot);
                AddBarChild(bsRoot);
                bm.EndUpdate();

            }


        }
        private void AddBarChild(BarSubItem bsiRoot)
        {

            DataTable dtChild = new DataTable();
            string sSql = "	SELECT T1.ID_MENU, KEY_MENU,CASE " + Com.Mod.iNNgu.ToString() + " WHEN 0 THEN T1.TEN_MENU WHEN 1 THEN ISNULL(NULLIF(T1.TEN_MENU_A,''),TEN_MENU) ELSE ISNULL(NULLIF(T1.TEN_MENU_H,''),T1.TEN_MENU) END AS TEN_MENU,T1.MENU_PARENT, HIDE, BACK_COLOR, IMG, TT_MENU, CONTROLS,ISNULL(MENU_LINE,0) AS MENU_LINE, T1.MENU_PARAMETER,T1.HOT_KEY, MENU_FUN FROM dbo.MENU T1 	INNER JOIN dbo.NHOM_MENU T2 ON T1.ID_MENU = T2.ID_MENU INNER JOIN dbo.USERS T3 ON T3.ID_NHOM = T2.ID_NHOM 	WHERE (ISNULL(MENU_PARENT,'') = N'" + bsiRoot.Name + "' ) AND (ISNULL(HIDE,0) = 0) AND INACTIVE = 0	AND (T3.USER_NAME = '" + Com.Mod.UName + "') 	ORDER BY TT_MENU ";
            //dtChild.Load(SqlHelper.ExecuteReader(Com.Mod.CNStr, CommandType.Text, sSql));

            dtChild.Load(SqlHelper.ExecuteReader(Com.Mod.CNStr, "spGetMenu", Com.Mod.UName, Com.Mod.iNNgu, bsiRoot.Name));

            foreach (DataRow item in dtChild.Rows)
            {

                DataTable dt = new DataTable();
                sSql = "	SELECT T1.ID_MENU, KEY_MENU,CASE " + Com.Mod.iNNgu.ToString() + " WHEN 0 THEN T1.TEN_MENU WHEN 1 THEN ISNULL(NULLIF(T1.TEN_MENU_A,''),TEN_MENU) ELSE ISNULL(NULLIF(T1.TEN_MENU_H,''),T1.TEN_MENU) END AS TEN_MENU,T1.MENU_PARENT, HIDE, BACK_COLOR, IMG, TT_MENU, CONTROLS,ISNULL(MENU_LINE,0) AS MENU_LINE, T1.MENU_PARAMETER,T1.HOT_KEY,MENU_FUN FROM dbo.MENU T1 	INNER JOIN dbo.NHOM_MENU T2 ON T1.ID_MENU = T2.ID_MENU INNER JOIN dbo.USERS T3 ON T3.ID_NHOM = T2.ID_NHOM 	WHERE (ISNULL(MENU_PARENT,'') = N'" + item["KEY_MENU"].ToString() + "' ) AND (ISNULL(HIDE,0) = 0) AND INACTIVE = 0	AND (T3.USER_NAME = '" + Com.Mod.UName + "') 	ORDER BY TT_MENU ";
                //dt.Load(SqlHelper.ExecuteReader(Com.Mod.CNStr, CommandType.Text, sSql));

                dt.Load(SqlHelper.ExecuteReader(Com.Mod.CNStr, "spGetMenu", Com.Mod.UName, Com.Mod.iNNgu, item["KEY_MENU"].ToString()));

                if (dt.Rows.Count == 0)
                {


                    if (item["KEY_MENU"].ToString().ToUpper() == "mnuNgonNguAnh".ToUpper() || item["KEY_MENU"].ToString().ToUpper() == "mnuNgonNguViet".ToUpper())
                    {
                        bool bCheck = false;
                        if (Com.Mod.iNNgu == 0 && item["KEY_MENU"].ToString().ToUpper() == "mnuNgonNguViet".ToUpper()) bCheck = true;
                        if (Com.Mod.iNNgu == 1 && item["KEY_MENU"].ToString().ToUpper() == "mnuNgonNguAnh".ToUpper()) bCheck = true;

                        BarCheckItem bbiChild = new BarCheckItem(bm, bCheck);
                        bbiChild.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
                        bbiChild.Name = item["KEY_MENU"].ToString();
                        bbiChild.Tag = item["CONTROLS"].ToString();
                        bbiChild.Id = int.Parse(item["ID_MENU"].ToString());
                        bbiChild.Description = item["MENU_PARAMETER"].ToString();
                        bbiChild.Caption = item["TEN_MENU"].ToString();
                        bbiChild.Category.Name = bsiRoot.Name;

                        bbiChild.AccessibleName = item["MENU_FUN"].ToString();
                        try
                        {
                            bbiChild.Hint = item["BACK_COLOR"].ToString();
                        }
                        catch { }
                        bbiChild.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiChild_ItemClick);
                        if (int.Parse(item["MENU_LINE"].ToString()) == 1)
                            bsiRoot.AddItem(bbiChild).BeginGroup = true;
                        else
                            bsiRoot.AddItem(bbiChild);


                    }
                    else
                    {
                        //if (item["KEY_MENU"].ToString().ToLower() == "mnuChangeTheme".ToLower())
                        //{
                        //    BarSubItem bsRoot1 = new BarSubItem(bm, item["TEN_MENU"].ToString());
                        //    bsRoot1.Name = item["KEY_MENU"].ToString();
                        //    bsRoot1.Tag = item["CONTROLS"].ToString();
                        //    bsRoot1.Id = int.Parse(item["ID_MENU"].ToString());
                        //    bsRoot1.Description = item["MENU_PARAMETER"].ToString();
                        //    bsRoot1.AccessibleName = item["MENU_FUN"].ToString();
                        //    bsRoot1.Category.Name = bsiRoot.Name;

                        //    if (int.Parse(item["MENU_LINE"].ToString()) == 1)
                        //        bsiRoot.AddItem(bsRoot1).BeginGroup = true;
                        //    else
                        //        bsiRoot.AddItem(bsRoot1);


                        //    DevExpress.XtraBars.Helpers.SkinHelper.InitSkinPopupMenu(bsRoot1);
                        //    DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Settings.Default["ApplicationSkinName"].ToString();

                        //    continue;
                        //}


                        BarButtonItem bbiChild = new BarButtonItem(bm, item["TEN_MENU"].ToString());
                        bbiChild.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
                        bbiChild.Name = item["KEY_MENU"].ToString();
                        bbiChild.Tag = item["CONTROLS"].ToString();
                        bbiChild.Id = int.Parse(item["ID_MENU"].ToString());
                        bbiChild.Description = item["MENU_PARAMETER"].ToString();
                        bbiChild.Category.Name = bsiRoot.Name;
                        bbiChild.AccessibleName = item["MENU_FUN"].ToString();
                        try
                        {
                            bbiChild.Hint = item["BACK_COLOR"].ToString();
                        }
                        catch { }
                        if (item["KEY_MENU"].ToString().ToUpper() == "mnuHangHoa".ToUpper())
                        {
                            bbiChild.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H));


                            //bbiChild.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control && System.Windows.Forms.Keys.P));


                            //bbiChild.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.J), (System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K));

                        }


                        bbiChild.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiChild_ItemClick);
                        if (int.Parse(item["MENU_LINE"].ToString()) == 1)
                            bsiRoot.AddItem(bbiChild).BeginGroup = true;
                        else
                            bsiRoot.AddItem(bbiChild);

                    }
                }
                else
                {

                    BarSubItem bsRoot1 = new BarSubItem(bm, item["TEN_MENU"].ToString());
                    bsRoot1.Name = item["KEY_MENU"].ToString();
                    bsRoot1.Tag = item["CONTROLS"].ToString();
                    bsRoot1.Id = int.Parse(item["ID_MENU"].ToString());
                    bsRoot1.Description = item["MENU_PARAMETER"].ToString();
                    bsRoot1.AccessibleName = item["MENU_FUN"].ToString();
                    try
                    {
                        bsRoot1.Hint = item["BACK_COLOR"].ToString();
                    }
                    catch { }
                    bsRoot1.Category.Name = bsiRoot.Name;
                    if (int.Parse(item["MENU_LINE"].ToString()) == 1)
                        bsiRoot.AddItem(bsRoot1).BeginGroup = true;
                    else
                        bsiRoot.AddItem(bsRoot1);

                    AddBarChild(bsRoot1);
                }
            }
        }
        private void ThayDoiManHinh()
        {

            //////string sSql = "";

            //sSql = "UPDATE dbo.THONG_TIN_CHUNG SET PIC  = @PIC ";
            //Image inImg = Image.FromFile(@"D:\mhc.jpg");
            //SqlConnection con = new SqlConnection(Com.Mod.CNStr);
            //con.Open();

            //SqlCommand cmd = new SqlCommand(sSql, con);
            //cmd.Parameters.Add("@PIC", SqlDbType.Image).Value = Com.Mod.OS.SaveHinh(inImg);
            //cmd.ExecuteNonQuery();
            BackgroundImage = Properties.Resources.mhc;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            return;

            //////////this.Cursor = Cursors.WaitCursor;
            //////////sSql = "SELECT ISNULL(PIC,'') AS PIC  FROM THONG_TIN_CHUNG ";

            //////////DataTable dt = new DataTable();

            //////////try
            //////////{
            //////////    dt.Load(SqlHelper.ExecuteReader(Com.Mod.CNStr, CommandType.Text, sSql));
            //////////    Byte[] data = new Byte[0];
            //////////    data = (Byte[])(dt.Rows[0]["PIC"]);
            //////////    System.IO.MemoryStream mPic = new System.IO.MemoryStream(data);
            //////////    BackgroundImage = System.Drawing.Image.FromStream(mPic, true, true);
            //////////}
            //////////catch { BackgroundImage = Properties.Resources.mhc; }
            //////////this.Cursor = Cursors.Default;
            ////////////

            //////////this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        }
        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //DialogResult res;
            // try
            //{
            /////MNotification();
            bLicKiem = true;
            //    if (!bLicKiem)
            //    {
            //        //kiểm tra tài khoảng có  LIC hay chưa
            //        string sSql = "SELECT ISNULL(USER_PQ,'') AS USER_PQ FROM dbo.USERS WHERE USER_NAME ='" + Com.Mod.UName.ToLower() + "' AND  ISNULL(LIC,0) = 1  ";

            //        sSql = Com.Mod.OS.Decrypt(Convert.ToString(SqlHelper.ExecuteScalar(Com.Mod.CNStr, CommandType.Text, sSql)), true).Replace(Com.Mod.UName.ToLower(), "");
            //        if (sSql.ToUpper() == "TRUE")
            //        {

            //            sSql = "SELECT LTRIM(RTRIM(ISNULL(M_NAME,'') + ' - ' + USER_NAME)) AS USER_NAME FROM dbo.LOGIN WHERE USER_LOGIN = N'" + Com.Mod.UName + "'  AND USER_NAME <> '" + Com.Mod.OS.LoadIPLocal() + "' ";
            //            sSql = Convert.ToString(SqlHelper.ExecuteScalar(Com.Mod.CNStr, CommandType.Text, sSql));
            //            if (sSql == "")
            //            {
            //                Com.Mod.OS.CapNhapUser();
            //                return;
            //            }
            //            else
            //            {
            //                if (Com.Mod.OS.LoadIPLocal() != sSql)
            //                {
            //                    bLicKiem = true;
            //                    timer.Stop();
            //                    _instance.VSIdle.Stop();
            //                    _instance.LogOut();
            //                    timer = new System.Timers.Timer();
            //                    timer.Interval = 100000;//TimeSpan.FromMinutes(5).TotalMilliseconds;


            //                    XtraMessageBoxArgs args = new XtraMessageBoxArgs();
            //                    args.AutoCloseOptions.Delay = 60000;
            //                    args.Caption = "VietSoft CMMS";
            //                    args.Text = Com.Mod.OS.GetLanguage(this.Name, "msgUserDangDangNhapTaiIP") + " : " + sSql + "\n" + Com.Mod.OS.GetLanguage(this.Name, "msgBanCo1PhutThoatPhanMemBanCoMuonThoatLien");
            //                    args.AutoCloseOptions.ShowTimerOnDefaultButton = true;

            //                    args.Buttons = new DialogResult[] { DialogResult.OK, DialogResult.Cancel };
            //                    res = XtraMessageBox.Show(args);
            //                    if (res == DialogResult.OK)
            //                    {
            //                        StopIDLE();
            //                        return;
            //                    }else
            //                    {
            //                        timer.Elapsed += timer_End;
            //                        timer.Start();
            //                    }


            //                    return;
            //                }else
            //                {
            //                    Com.Mod.OS.CapNhapUser();
            //                    return;
            //                }
            //            }
            //        }
            //    }

            //    bLicKiem = true;
            //    timer.Stop();
            //    _instance.VSIdle.Stop();
            //    _instance.LogOut();
            //    timer = new System.Timers.Timer();
            //    timer.Interval = 100000;//TimeSpan.FromMinutes(5).TotalMilliseconds;


            //    XtraMessageBoxArgs args1 = new XtraMessageBoxArgs();
            //    args1.AutoCloseOptions.Delay = 60000;
            //    args1.Caption = "VietSoft CMMS";
            //    args1.Text = Com.Mod.OS.GetLanguage(this.Name, "msgTaiKhoanKhongCoLicsen") + "\n" + Com.Mod.OS.GetLanguage(this.Name, "msgBanCo1PhutThoatPhanMemBanCoMuonThoatLien");
            //    args1.Buttons = new DialogResult[] { DialogResult.OK, DialogResult.Cancel };
            //    args1.AutoCloseOptions.ShowTimerOnDefaultButton = true;
            //    res = XtraMessageBox.Show(args1);
            //    if (res == DialogResult.OK)
            //    {
            //        StopIDLE();
            //        return;
            //    }else
            //    {
            //        timer.Elapsed += timer_End;
            //        timer.Start();
            //    }
            //}
            //catch {
            //    bLicKiem = true;
            //    timer.Stop();
            //    _instance.VSIdle.Stop();
            //    _instance.LogOut();
            //    timer = new System.Timers.Timer();
            //    timer.Interval = 100000;//TimeSpan.FromMinutes(5).TotalMilliseconds;
            //    timer.Elapsed += timer_End;
            //    timer.Start();
            //}

        }
        private void StartIDLE()
        {
            ////if (!_instance.VSIdle.IsRunning)
            ////{
            ////    _instance.VSIdle.Start();
            ////    _instance.LogIn();
            ////}
            ////else
            ////{
            ////    _instance.VSIdle.Stop();
            ////    _instance.LogOut();
            ////}
        }
        private void StopIDLE()
        {
        ////    LogOut();
        ////    try
        ////    {
        ////        if (_instance.VSIdle.IsRunning)
        ////        {
        ////            _instance.VSIdle.Stop();
        ////            _instance.LogOut();
        ////        }
        ////    }
        ////    catch { }
        ////    try
        ////    {
        ////        Application.ExitThread();
        ////        System.Windows.Forms.Application.Exit();
        ////    }
        ////    catch
        ////    {

        ////        try
        ////        {
        ////            Application.ExitThread();
        ////            System.Windows.Forms.Application.Exit();
        ////        }
        ////        catch { }
        ////    }

        }
        #endregion


        #region --- Event
        public void bbiChild_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Com.Mod.OS.ShowWaitForm(this);  
            this.Cursor = Cursors.WaitCursor;
            try
            {

                switch (e.Item.AccessibleName.ToString().ToLower())
                {
                    case "showngonngu":
                        {


                            ShowNgonNgu((e.Item as BarCheckItem));

                            break;
                        }
                    case "showthoat":
                        {
                            if (XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgBanCoChacThoatPhanMem"), "VietSoft CMMS", MessageBoxButtons.YesNo) == DialogResult.No) break;
                            try
                            {
                                SqlHelper.ExecuteNonQuery(Com.Mod.CNStr, CommandType.Text, "DELETE FROM [dbo].[LOGIN] WHERE USER_LOGIN = N'" + Com.Mod.UName + "'  ");
                                Com.Mod.sPS = "0Load";
                                StopIDLE();
                            }
                            catch { }
                            break;
                        }
                    case "showdangnhap":
                        {
                            ShowDangNhap(e);
                            barServer.Caption = "V : " + Com.Mod.sInfoClient + " - S : " + Com.Mod.Server + " - D : " + Com.Mod.Database + " - U : " + Com.Mod.UName + "";
                            barTTC.Caption = Com.Mod.sLoad;


                            break;
                        }
                    case "showdoimatkhau":
                        {
                            frmDoiMatKhau frm = new frmDoiMatKhau(Com.Mod.UName, 0);
                            frm.ShowDialog();
                            break;
                        }
                    //Show cac form view 
                    case "showview": { ShowView(e); break; }
                    case "showviewfull": { ShowViewFull(e); break; }
                    case "showviewxacnhan": { ShowViewXacNhan(e); break; }
                    ////////case "showviewreport": { ShowViewReport(e); break; }
                    ////////case "showyeucauhotro": { ShowYeuCauHoTro(); break; }
                    ////////case "showelearning": { ShowELearning(); break; }
                    ////////case "showdinhmuc": { ShowDinhMuc(e); break; }
                    ////////case "showgiaonhangc": { ShowGiaoNhanGC(e); break; }
                    ////////case "showdhb": { ShowDHB(e); break; }
                    default:
                        {
                            if (!string.IsNullOrEmpty(e.Item.AccessibleName.ToString()))
                            {
                                try
                                {
                                    Type type = typeof(VS.CMMS.frmMain);
                                    MethodInfo methodInfo = type.GetMethod(e.Item.AccessibleName);
                                    methodInfo.Invoke(e.Item.AccessibleName, null);
                                }catch {}
                            }
                            break;
                        }


                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "VietSoft CMMS");
            }
            this.Cursor = Cursors.Default;
            Com.Mod.OS.HideWaitForm();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            Com.Mod.OS.ShowWaitForm(this);
            ThayDoiManHinh();
            int widthRatio = Screen.PrimaryScreen.Bounds.Width / 3;
            int heightRatio = Screen.PrimaryScreen.Bounds.Height / 3;


            foreach (Control ctl in this.Controls)
            {
                if (ctl is MdiClient)
                {

                    ctl.BackgroundImage = Properties.Resources.mhc;
                    ////ctl.BackgroundImage = load
                    //Image image1 = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\mainform.jpg");
                    //ctl.BackgroundImage = image1;
                    ctl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    break;
                }
            }

            this.barServer.ItemAppearance.Normal.Font = new System.Drawing.Font("Segoe UI", 10F);
            barServer.Caption = "V : " + Com.Mod.sInfoClient + " - S : " + Com.Mod.Server + " - D : " + Com.Mod.Database + " - U : " + Com.Mod.UName + "";
            //barServer.Caption = Com.Mod.sInfoClient + " - " + Com.Mod.Server + " - " + Com.Mod.Database + " - " + Com.Mod.UName + "";
            barTTC.Caption = Com.Mod.sLoad;

            this.BeginInvoke(new MethodInvoker(delegate {
                AddBarItems();
            }));
            //ADD MANAGER
            manager = new DocumentManager(components);
            manager.MdiParent = this;
            manager.View = new TabbedView();

            // ...
            // Create a dock manager and initialize its Form property.
            dockManager1 = new DockManager(_instance);

            Com.Mod.Size2P3 = new System.Drawing.Size(widthRatio + widthRatio, heightRatio + heightRatio);
            Com.Mod.Point1P3 = new Point(_instance.Width / 2 - Com.Mod.Size2P3.Width / 2 + _instance.Location.X,
                          _instance.Height / 2 - Com.Mod.Size2P3.Height / 2 + _instance.Location.Y);

            widthRatio = Screen.PrimaryScreen.Bounds.Width / 2;
            heightRatio = Screen.PrimaryScreen.Bounds.Height / 2;
            Com.Mod.Size1P2 = new System.Drawing.Size(widthRatio, heightRatio);
            Com.Mod.Point1P2 = new Point(_instance.Width / 2 - Com.Mod.Size1P2.Width / 2 + _instance.Location.X,
                          _instance.Height / 2 - Com.Mod.Size1P2.Height / 2 + _instance.Location.Y);

            Com.Mod.OS.ThayDoiNN(this);

            StartIDLE();

            timer.Interval = TimeSpan.FromMinutes(1).TotalMilliseconds;
            //timer.Interval = TimeSpan.FromSeconds(1).TotalSeconds;
            timer.Elapsed += timer_Elapsed;
            timer.Start();

            Com.Mod.OS.HideWaitForm();
        }
        #endregion


        #region --- Loại hiển thị 
        public static void ShowView(ItemClickEventArgs e)
        {
            string n = typeof(frmMain).Namespace.ToString();
            string sFormName;
            if (e.Item.Tag.ToString() == "VS.CMMS.frmView")
                sFormName = e.Item.Name.Replace("mnu", "frm");
            else
                sFormName = e.Item.Tag.ToString().Replace(n.ToString() + ".", "");


            if (IsFormActive(sFormName)) return;
            int iPQ = Com.Mod.OS.CheckPermission(e.Item.Name);
            XtraForm ctl = new XtraForm();



            if (e.Item.Description.ToString() == "2")
            {
                Type newType = Type.GetType(e.Item.Tag.ToString(), true, true);
                string DMuc = "spDanhMuc";
                if (e.Item.Name.ToUpper() == "mnuNhomNguoiDung".ToUpper() || e.Item.Name.ToUpper() == "mnuNguoiDung".ToUpper())
                {
                    DMuc = "spNguoiDung";
                }
                object o1 = Activator.CreateInstance(newType, iPQ, "-1", DMuc);
                ctl = o1 as XtraForm;

            }
            Com.Mod.sPS = e.Item.Name;
            ctl.Text = e.Item.ToString();
            ctl.Name = sFormName;
            ctl.Tag = e.Item.Name;
            ctl.MdiParent = _instance;

            ctl.StartPosition = FormStartPosition.Manual;
            _instance.manager.View.AddFloatDocument(ctl, Com.Mod.Point1P3, Com.Mod.Size2P3);

            ctl.Show();

        }
        public static void ShowViewFull(ItemClickEventArgs e)
        {
            try
            {
                string n = typeof(frmMain).Namespace.ToString();
                string sFormName = e.Item.Tag.ToString().Replace(n.ToString() + ".", "");

                if (IsFormActive(sFormName)) return;
                Com.Mod.OS.ShowWaitForm(_instance);

                int iPQ = Com.Mod.OS.CheckPermission(e.Item.Name);
                XtraForm ctl = new XtraForm();
                string DMuc = "spDanhMuc01";
                Type newType = Type.GetType(e.Item.Tag.ToString(), true, true);
                object o1 = Activator.CreateInstance(newType, iPQ , "-1", DMuc);
                ctl = o1 as XtraForm;

                Com.Mod.sPS = e.Item.Name;
                ctl.Text = e.Item.ToString();
                ctl.Tag = e.Item.Name;
                ctl.MdiParent = _instance;
                _instance.manager.View.AddFloatingDocumentsHost(ctl);

                ctl.Show();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "VietSoft CMMS");
            }
            Com.Mod.OS.HideWaitForm();
        }

        public static void ShowViewXacNhan(ItemClickEventArgs e)
        {

            string n = typeof(frmMain).Namespace.ToString();
            string sFormName;

            sFormName = e.Item.Name.Replace("mnu", "frm");
            if (IsFormActive(sFormName)) return;
            int iPQ = Com.Mod.OS.CheckPermission(e.Item.Name);
            XtraForm ctl = new XtraForm();



            Type newType = Type.GetType(e.Item.Tag.ToString(), true, true);
            object o1 = Activator.CreateInstance(newType, iPQ);
            ctl = o1 as XtraForm;

            Com.Mod.sPS = e.Item.Name;
            ctl.Name = sFormName;
            ctl.Text = e.Item.ToString();
            ctl.Tag = e.Item.Name;
            ctl.MdiParent = _instance;
            _instance.manager.View.AddFloatingDocumentsHost(ctl);

            ctl.Show();
        }
        public static void ShowNgonNgu(BarCheckItem barItem)
        {
            try
            {
                FormCollection formCollection = Application.OpenForms;
                List<Form> ListFormToClose = new List<Form>();
                foreach (Form form in formCollection)
                {
                    if (form.Name == "")
                    {
                        form.Close();
                    }
                    if (form.Name != "frmMain" && form.Name != "")
                    {
                        ListFormToClose.Add(form);
                    }
                }
                if (ListFormToClose.Count > 0)
                {
                    XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgVuiLongDongCacFormDangMo"), "VietSoft CMMS");
                    try { barItem.Checked = false; } catch { }
                    return;
                }
            }
            catch { }


            if (barItem.Name.ToUpper() == "mnuNgonNguViet".ToUpper()) Com.Mod.iNNgu = 0;
            if (barItem.Name.ToUpper() == "mnuNgonNguAnh".ToUpper()) Com.Mod.iNNgu = 1;
            if (barItem.Name.ToUpper() == "mnuNgonNguHoa".ToUpper()) Com.Mod.iNNgu = 2;

            string path = System.IO.Directory.GetCurrentDirectory();
            DataSet ds = new DataSet();
            ds.ReadXml(AppDomain.CurrentDomain.BaseDirectory + "\\savelogin.xml");
            ds.Tables[0].Rows[0]["N"] = Com.Mod.iNNgu;
            ds.WriteXml(AppDomain.CurrentDomain.BaseDirectory + "\\savelogin.xml");


            _instance.AddBarItems();
            try { if (!barItem.Checked) barItem.Checked = true; } catch { }

        }
        public static void ShowDangNhap(ItemClickEventArgs e)
        {

        ////    //Xóa tài khoản đăng nhập
        ////    SqlHelper.ExecuteNonQuery(Com.Mod.CNStr, CommandType.Text, "DELETE FROM [dbo].[LOGIN] WHERE USER_LOGIN = N'" + Com.Mod.UName + "'  ");

        ////    //Load frmDangNHap
        ////    frmDangNhap frmDN = new frmDangNhap(1);
        ////    int widthRatio = Screen.PrimaryScreen.Bounds.Width / 3;
        ////    int heightRatio = Screen.PrimaryScreen.Bounds.Height / 3;
        ////    frmDN.Size = new Size(widthRatio + (widthRatio / 4), heightRatio + (heightRatio / 4));
        ////    if (frmDN.ShowDialog() != DialogResult.OK) return;
        ////    //_instance.ThayDoiManHinh(); 


        ////    //Xóa các form con            
        ////    FormCollection formCollection = Application.OpenForms;
        ////    List<Form> ListFormToClose = new List<Form>();
        ////    foreach (Form form in formCollection)
        ////    {
        ////        if (form.Name != "frmMain" && form.Name != e.Item.Name.Replace("mnu", "frm"))
        ////        {
        ////            ListFormToClose.Add(form);
        ////        }
        ////    }
        ////    ListFormToClose.ForEach(f => f.Close());
        ////    _instance.AddBarItems();
        ////    _instance.StartIDLE();
        ////    _instance.MBarTT();
        }
        #endregion
    }
}