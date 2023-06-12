using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace VS.CMMS
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            try
            {
                Com.Mod.ModuleName = "VS.CMMS";
                Com.Mod.UName = "admin";
                Com.Mod.GroupID = 1;
                DataSet ds = new DataSet();

                //Com.Mod.Server = @"192.168.2.8\sql2016";
                Com.Mod.sDDTaiLieu = @"D:\VietSoft\tailieu";
                Com.Mod.UserID = 1;
                Com.Mod.sPrivate = "";
                ds.ReadXml(AppDomain.CurrentDomain.BaseDirectory + "\\vsconfig.xml");
                Com.Mod.UserDB = ds.Tables[0].Rows[0]["U"].ToString();
                Com.Mod.Server = Com.Mod.OS.Decrypt(ds.Tables[0].Rows[0]["S"].ToString(), true);

                Com.Mod.Database = ds.Tables[0].Rows[0]["D"].ToString();
                Com.Mod.Password = Com.Mod.OS.Decrypt(ds.Tables[0].Rows[0]["P"].ToString(), true);
                Com.Mod.sUrlCheckServer = Com.Mod.OS.Decrypt(ds.Tables[0].Rows[0]["IP"].ToString(), true);
                Com.Mod.LicServer = Convert.ToBoolean(Com.Mod.sUrlCheckServer.Split('!')[0].ToString());  //==TRUE KIEM TREN API SERVER FALSE TREN API VSOFT
                Com.Mod.sPrivate = Com.Mod.OS.Decrypt(ds.Tables[0].Rows[0]["CT"].ToString(), true);

                if (Com.Mod.LicServer)
                {
                    try
                    {
                        Com.Mod.iLic = Com.Mod.OS.MCot(Com.Mod.sUrlCheckServer.Split('!')[2].ToString());
                    }
                    catch { Com.Mod.iLic = 1; }
                }
                Com.Mod.sUrlCheckServer = Com.Mod.sUrlCheckServer.Split('!')[1].ToString();



                //Com.Mod.Username = "sa";
                //Com.Mod.Database = "VS_CMMS";


                //Com.Mod.Server = @"192.168.2.8\sql2016";
                //Com.Mod.Password = "codaikadaiku";

                ////////////Com.Mod.UserDB = @"sa";
                ////////////Com.Mod.Server = @"DESKTOP-G3G3EKE";
               //////// Com.Mod.Database = @"VS_CMMS";
                Com.Mod.Database = @"VS_CMMS";
                ////////////Com.Mod.Password = @"123";


                Com.Mod.UserID = 1;
                Com.Mod.sTenNhanVienMD = "Administrator";
                Com.Mod.GroupID = 1;
                Com.Mod.bDDTL = true;

                //Com.Mod.iNNgu = 0;
                //Application.EnableVisualStyles();

                Com.Mod.OS.CheckUpdate();
                Thread t = new Thread(new ThreadStart(MRunForm));
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
            }
            catch (Exception ex) { DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message + "\n" + Com.Mod.UserDB + "\n" + Com.Mod.Database + "\n" + Com.Mod.Server + "\n" + Com.Mod.Password + "\n"); }

        }

        static void MRunForm()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                DevExpress.UserSkins.BonusSkins.Register();
                DevExpress.Skins.SkinManager.EnableFormSkins();
                LogIn();
                //Application.Run(new frmThoiGianChayMay(1));
                //Application.Run(new frmThoiGianDungMay(1));
                //Application.Run(new Form1());
                //Application.Run(new frmMain());
                //Application.Run(new frmQuanLyBaoGoi(1));
                //Application.Run(new frmXacNhanDonHangBan(1));
                //Application.Run(new frmDuyetTaiLieu(1));
                //Application.Run(new frmDuyetTemplate(1));


                //Application.Run(new frmMRPChon(1));
                //Application.Run(new frmCapNhapDuLieuHangHoa());

                //Application.Run(new Form1());
                //Application.Run(new frmHangHoaImport());
                //Application.Run(new frmDangNhap(0));
                //Application.Run(new frmDonHangBan(1));
                //Application.Run(new frmPhanQuyenChucNang());
                //Application.Run(new frmView());

                //Application.Run(new frmDoiTacKD(1)
                //Application.Run(new frmBangMau(1));
                //Application.Run(new frmBOM(1));
                //Application.Run(new frmHangHoa(1));
                //Application.Run(new frmDoiTacKD(1));
                //Application.Run(new frmDieuChinhDinhMuc(1));
                //Application.Run(new frmPhieuNhapKho(1));
                //Application.Run(new frmToHopHangHoa(1));
                //Application.Run(new frmHangHoa(1));
                //Application.Run(new frmPhanBoOrderNM(1));
                //Application.Run(new frmSuDungHangTonKho(1));
                //Application.Run(new frmChiPhiSanXuatThang(1));
                //Application.Run(new frmKiemKeHangHoa(1));
                //Application.Run(new frmKho(1));
                //Application.Run(new frmPackingList_KeHoach(1));
                //Application.Run(new frmPackinglist());

                //frmView frm = new frmView(1, "-1", "spDanhMuc");
                //Com.Mod.sPS = "mnuThanhPhanVai";
                //frm.Name = "frmThanhPhanVai";
                //frm.Tag = "mnuThanhPhanVai";
                //Application.Run(frm);

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }



        static void LogIn()
        {
            Application.Run(new frmMain());
            ///Application.Run(new frmNguyenNhanHH()); 

            ////frmDangNhap frm = new frmDangNhap(0);
            ////int widthRatio = Screen.PrimaryScreen.Boun
            ///
            /// .Width / 3;
            ////int heightRatio = Screen.PrimaryScreen.Bounds.Height / 3;

            ////frm.Size = new Size(widthRatio + (widthRatio / 4), heightRatio + (heightRatio / 4));
            ////if (frm.ShowDialog() == DialogResult.Cancel)
            ////{
            ////    ExitApp();
            ////}
            ////else
            ////{
            ////    if (!VsMain.CheckServer())
            ////    {
            ////        ExitApp();
            ////    }
            ////    else
            ////        Application.Run(new frmMain());
            ////}
        }



        static void ExitApp()
        {
            if (Com.Mod.UName != "")
            {
                string sSql = " DELETE FROM dbo.LOGIN WHERE USER_LOGIN = '" + Com.Mod.UName + "' ";
                VsMain.MExecuteNonQuery(sSql);
            }
            Application.ExitThread();
            System.Windows.Forms.Application.Exit();
        }

        
        public static void MBarThongTin(string sThongTin)
        {
            try
            {
                string sTmp = Com.Mod.OS.GetLanguage("frmChung", sThongTin);
                frmMain.BarInfoText(sTmp);
                
            }
            catch { }
        }
        public static void MBarThongTin(string sThongTin, Boolean bLoi)
        {
            try
            {
                string sTmp = Com.Mod.OS.GetLanguage("frmChung", sThongTin);
                frmMain.BarInfoText(sTmp, bLoi);
            }
            catch { }
        }
        public static void MBarThongTin(string sThongTin, string sForm)
        {
            try
            {
                string sTmp = Com.Mod.OS.GetLanguage(sForm, sThongTin);
                frmMain.BarInfoText(sTmp);
            }
            catch { }
        }


        public static void MBarXoaKhongThanhCong()
        {
            try
            {
                string sTmp = Com.Mod.OS.GetLanguage("frmChung", "msgDeleteUnSuccessful");
                frmMain.BarInfoText(sTmp, true);
            }
            catch { }
        }
        public static void MBarXoaThanhCong()
        {
            try
            {
                string sTmp = Com.Mod.OS.GetLanguage("frmChung", "msgDeleteSuccessful");
                frmMain.BarInfoText(sTmp);
            }
            catch { }
        }

        public static void MBarCapNhapKhongThanhCong()
        {
            try
            {
                string sTmp = Com.Mod.OS.GetLanguage("frmChung", "msgUpdateUnSuccessful");
                frmMain.BarInfoText(sTmp, true);
            }
            catch { }
        }
        public static void MBarCapNhapThanhCong()
        {
            try
            {
                string sTmp = Com.Mod.OS.GetLanguage("frmChung", "msgUpdateSuccessful");
                frmMain.BarInfoText(sTmp);
            }
            catch { }
        }


    }
}
