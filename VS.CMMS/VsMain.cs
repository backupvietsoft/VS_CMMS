using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
using System.Drawing.Printing;
using System.IO;
using Com;
using System.Threading;
using DevExpress.LookAndFeel;

namespace VS.CMMS
{
    public static class VsMain
    {
        
        static Boolean bLoadPrint = false;


        public static void MFieldRequest(DevExpress.XtraLayout.LayoutControlItem Mlayout)
        { ////red, green, blue
            int R = 156, G = 97, B = 65;
            try { R = int.Parse(VS.CMMS.Properties.Settings.Default["ApplicationColorRed"].ToString()); } catch { R = 156; }
            try { G = int.Parse(VS.CMMS.Properties.Settings.Default["ApplicationColorGreen"].ToString()); } catch { G = 97; }
            try { B = int.Parse(VS.CMMS.Properties.Settings.Default["ApplicationColorBlue"].ToString()); } catch { B = 65; }

            Mlayout.AppearanceItemCaption.ForeColor = System.Drawing.Color.FromArgb(R, G, B);
            Mlayout.AppearanceItemCaption.Options.UseForeColor = true;
            try
            {

                Mlayout.AppearanceItemCaption.Font = new System.Drawing.Font(VS.CMMS.Properties.Settings.Default["ApplicationFontRequestName"].ToString(), int.Parse(VS.CMMS.Properties.Settings.Default["ApplicationFontRequestSize"].ToString()), (VS.CMMS.Properties.Settings.Default["ApplicationFontRequestBold"].ToString().ToUpper() == "TRUE" ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular) | (VS.CMMS.Properties.Settings.Default["ApplicationFontRequestItalic"].ToString().ToUpper() == "TRUE" ? System.Drawing.FontStyle.Italic : System.Drawing.FontStyle.Regular));
            }
            catch { Mlayout.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", float.Parse("9")); }


        }


        // -- sName Goi cái gì HH hay don hang hay j ....
        //sCall = HH = hang hoa
        //sCall = VT = Vat tu
        //sCall = HDB don hang ban
        //sCall = HDM don hang mua
        //sCall = HDGC don hang gia cong
        //sCall = LPB lenh phan bo
        public static void MLoadSearchLink(SearchLookUpEdit cbo, bool blink, string sForm, string sCall)
        {
            try
            {
                if (blink == false)
                {
                    ContextMenuStrip menu = new ContextMenuStrip();
                    ToolStripMenuItem btnLink = new ToolStripMenuItem();
                    btnLink.Text = Com.Mod.OS.GetLanguage(sForm, "slink" + cbo.Name);
                    btnLink.Click += delegate (object a, EventArgs b) { BtnLink_Click(null, null, cbo, sCall); };
                    menu.Items.Add(btnLink);
                    cbo.ContextMenuStrip = menu;
                }
                else
                {
                    DevExpress.XtraEditors.Controls.EditorButton btnLink = new DevExpress.XtraEditors.Controls.EditorButton();
                    btnLink.Caption = "...";
                    btnLink.Click += delegate (object a, EventArgs b) { BtnLink_Click(null, null, cbo, sCall); };
                    cbo.Properties.Buttons.Add(btnLink);
                }
            }
            catch { }
        }

        public static void MLoadLookLink(ButtonEdit txt, bool blink, string sForm, string sCall)
        {
            try
            {
                if (blink == false)
                {
                    ContextMenuStrip menu = new ContextMenuStrip();
                    ToolStripMenuItem btnLink = new ToolStripMenuItem();
                    btnLink.Text = Com.Mod.OS.GetLanguage(sForm, "slink" + txt.Name);
                    btnLink.Click += delegate (object a, EventArgs b) { BtnLink_Click(null, null, txt, sCall); };
                    menu.Items.Add(btnLink);
                    txt.ContextMenuStrip = menu;
                }
                else
                {
                    DevExpress.XtraEditors.Controls.EditorButton btnLink = new DevExpress.XtraEditors.Controls.EditorButton();
                    btnLink.Caption = "...";
                    btnLink.Click += delegate (object a, EventArgs b) { BtnLink_Click(null, null, txt, sCall); };
                    txt.Properties.Buttons.Add(btnLink);
                }
            }
            catch { }
        }


        private static void BtnLink_Click(object sender, EventArgs e, ButtonEdit txt, string sCall)
        {
            try
            {
                Int64 iID;
                string sSql = " SELECT TOP 1 ID_HH FROM HANG_HOA WHERE MS_HH = N'" + txt.Text.ToString() + "' ";
                try
                {
                    sSql = Convert.ToString(SqlHelper.ExecuteScalar(Com.Mod.CNStr, CommandType.Text, sSql));
                }
                catch { sSql = "-1"; }

                iID = Int64.Parse(sSql);
                //MLinkHangHoa(iID);
            }
            catch { }
        }
        private static void BtnLink_Click(object sender, EventArgs e, SearchLookUpEdit cbo, string sCall)
        {
            try
            {

                //VsMain.MLinkHangHoa(Int64.Parse(cbo.EditValue.ToString()));
            }
            catch { }
        }


        #region   ConnSQL


        public static DataSet MGetDataSet(string mStoredName, List<SqlParameter> mParameters)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection conn = new SqlConnection(Com.Mod.CNStr);
                SqlCommand cmd = new SqlCommand(mStoredName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                if (mParameters != null)
                {
                    foreach (SqlParameter param in mParameters)
                    {
                        cmd.Parameters.Add(param);
                    }
                }

                try
                {
                    if (cmd.Connection.State == ConnectionState.Open)
                    {
                        cmd.Connection.Close();
                    }
                    cmd.Connection.Open();
                    da.Fill(ds);
                }
                catch (Exception ex)
                {
                    Program.MBarThongTin(ex.Message.ToString(), true);
                }
                finally
                {
                    if (cmd.Connection.State == ConnectionState.Open)
                    {
                        cmd.Connection.Close();
                    }
                    cmd.Dispose();
                    da.Dispose();
                }
            }
            catch (Exception ex)
            {
                Program.MBarThongTin(ex.Message.ToString(), true);
            }
            return ds;
        }
        public static DataTable MGetDatatable(string mStoredName, List<SqlParameter> mParameters)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = MGetDataSet(mStoredName, mParameters);
                DataTable dt = new DataTable();
                dt = ds.Tables[0].Copy();
                return dt;
            }
            catch (Exception ex)
            {
                Program.MBarThongTin(ex.Message.ToString(), true);
                return null;
            }
        }

        public static DataTable MExecuteDataTable(string sSql)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                dtTmp.Load(SqlHelper.ExecuteReader(Com.Mod.CNStr, CommandType.Text, sSql));
            }
            catch
            { }
            return dtTmp;

        }

        public static object MExecuteScalar(string mStoredName, List<SqlParameter> mParameters)
        {
            object result = 0;
            try
            {
                SqlConnection conn = new SqlConnection(Com.Mod.CNStr);
                SqlCommand cmd = new SqlCommand(mStoredName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;

                if (mParameters != null)
                {
                    foreach (SqlParameter param in mParameters)
                    {
                        cmd.Parameters.Add(param);
                    }
                }
                try
                {
                    if (cmd.Connection.State == ConnectionState.Open)
                    {
                        cmd.Connection.Close();
                    }
                    cmd.Connection.Open();
                    result = cmd.ExecuteScalar();
                    return result;
                }
                catch (Exception ex)
                {
                    Program.MBarThongTin(ex.Message.ToString(), true);
                    throw ex;
                }
                finally
                {
                    if (cmd.Connection.State == ConnectionState.Open)
                    {
                        cmd.Connection.Close();
                    }
                    cmd.Dispose();

                }
            }
            catch (Exception ex)
            {
                Program.MBarThongTin(ex.Message.ToString(), true);
                throw ex;
            }
        }

        public static object MExecuteScalarFuntion(string sSqlFuntion, List<SqlParameter> mParameters)
        {
            object result = 0;
            try
            {
                SqlConnection conn = new SqlConnection(Com.Mod.CNStr);
                SqlCommand cmd = new SqlCommand(sSqlFuntion, conn);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;

                if (mParameters != null)
                {
                    foreach (SqlParameter param in mParameters)
                    {
                        cmd.Parameters.Add(param);
                    }
                }
                try
                {
                    if (cmd.Connection.State == ConnectionState.Open)
                    {
                        cmd.Connection.Close();
                    }
                    cmd.Connection.Open();
                    result = cmd.ExecuteScalar();
                    return result;
                }
                catch (Exception ex)
                {
                    Program.MBarThongTin(ex.Message.ToString(), true);
                    throw ex;
                }
                finally
                {
                    if (cmd.Connection.State == ConnectionState.Open)
                    {
                        cmd.Connection.Close();
                    }
                    cmd.Dispose();

                }
            }
            catch (Exception ex)
            {
                Program.MBarThongTin(ex.Message.ToString(), true);
                throw ex;
            }
        }

        public static object MExecuteScalar(string sSql)
        {
            try
            {
                return SqlHelper.ExecuteScalar(Com.Mod.CNStr, CommandType.Text, sSql);
            }
            catch
            { return false; }
        }
        public static object MExecuteNonQuery(string mStoredName, List<SqlParameter> mParameters)
        {
            object result = 0;

            SqlConnection conn = new SqlConnection(Com.Mod.CNStr);
            SqlCommand cmd = new SqlCommand(mStoredName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 300; //seconds

            //add parameters
            SqlParameter returnParam = new SqlParameter();
            if (mParameters != null)
            {
                foreach (SqlParameter param in mParameters)
                {
                    cmd.Parameters.Add(param);

                    if (param.Direction == ParameterDirection.ReturnValue)
                    {
                        returnParam = param;
                    }
                }
            }

            try
            {
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();

                result = "";// returnParam.Value == null ? "-1000" : returnParam.Value;
            }
            catch (Exception ex)
            {
                result = ex.ToString();
                Program.MBarThongTin(ex.Message.ToString(), true);
                throw ex;
            }
            finally
            {
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
                cmd.Dispose();
            }

            return result;
        }

        public static Boolean MExecuteNonQuery(string sSql)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(Com.Mod.CNStr, CommandType.Text, sSql);
            }
            catch
            { return false; }
            return true;
        }
        #endregion


        public static bool LoadThongTinChung()
        {
            Com.Mod.iSoLeSL = 2;
            Com.Mod.iSoLeDG = 2;
            Com.Mod.iSoLeDGSC = 4;
            Com.Mod.iSoLeTT = 2;
            Com.Mod.iSoLeTTSC = 4;
            Com.Mod.iSLVAT = 2;
            Com.Mod.VATMD = 10;
            Com.Mod.iSLTyGia = 5;
            Com.Mod.iSLDinhMuc = 3;
            Com.Mod.iSLPTram = 2;

            DataTable dt = new DataTable();
            try
            {

                string sSql = "SELECT ISNULL(SO_LE_SL,0) AS SO_LE_SL , ISNULL(SO_LE_DG,3) AS SO_LE_DG , ISNULL(SO_LE_DG_SC,3) AS SO_LE_DG_SC, ISNULL(SO_LE_TT,2) AS SO_LE_TT, ISNULL(SO_LE_TT_SC,3) AS SO_LE_TT_SC, ISNULL(SO_LE_TG,4) AS SO_LE_TG,ISNULL(SO_LE_DM,3) AS SO_LE_DM, ISNULL(SO_LE_PT,2) AS SO_LE_PT, ISNULL(SO_LE_CP,2) AS SO_LE_CP, ISNULL(LAM_TRON,0) AS LAM_TRON, CASE " + Com.Mod.iNNgu.ToString() + " WHEN 0 THEN TEN_NGAN WHEN 1 THEN ISNULL(NULLIF(TEN_NGAN_A,''), TEN_NGAN) ELSE ISNULL(NULLIF(TEN_NGAN_H,''), TEN_NGAN) END AS TEN_NGAN , ISNULL(DUONG_DAN_TL,'') AS DUONG_DAN_TL, ISNULL(DUONG_DAN_TL_CLOUD,'') AS DUONG_DAN_TL_CLOUD, USER_DD, PASS_DD,CASE " + Com.Mod.iNNgu.ToString() + " WHEN 0 THEN TEN_CTY WHEN 1 THEN ISNULL(NULLIF(TEN_CTY_A, ''), TEN_CTY) ELSE ISNULL(NULLIF(TEN_CTY_H, ''), TEN_CTY) END AS TEN_CTY, CASE " + Com.Mod.iNNgu.ToString() + " WHEN 0 THEN DIA_CHI WHEN 1 THEN ISNULL(NULLIF(DIA_CHI_A, ''), DIA_CHI) ELSE ISNULL(NULLIF(DIA_CHI_H, ''), DIA_CHI) END AS DIA_CHI, ISNULL(DIEN_THOAI,'') AS DIEN_THOAI , ISNULL(FAX,'') AS FAX,ISNULL(EMAIL,'') AS EMAIL, ISNULL( (SELECT TOP 1 ID_TT FROM dbo.TIEN_TE WHERE SYS_TT = 1),12) AS SYS_TT, ISNULL((SELECT TOP 1 ID_TT FROM dbo.TIEN_TE WHERE LC_TT = 1),11) AS LC_TT, ISNULL((SELECT TOP 1 MA_TT FROM dbo.TIEN_TE WHERE SYS_TT = 1),'USD') AS MA_TT_SYS, ISNULL((SELECT TOP 1 MA_TT FROM dbo.TIEN_TE WHERE LC_TT = 1),'VND') AS MA_TT_LC,ISNULL(SO_LE_VAT,2) AS SO_LE_VAT,ISNULL(MD_VAT,10) AS MD_VAT, ISNULL(APIServer,'192.168.1.1') AS APIServer, ISNULL(TTCT,'VIETSOFT') AS TTCT,ISNULL(LOGO,'') AS LOGO,ISNULL(LG_LEFT,5) AS LG_LEFT, ISNULL(LG_TOP,0) AS LG_TOP,ISNULL(LG_WIDTH,150) AS LG_WIDTH,ISNULL(LG_HEIGHT,50) AS LG_HEIGHT  FROM THONG_TIN_CHUNG ";


                dt.Load(SqlHelper.ExecuteReader(Com.Mod.CNStr, CommandType.Text, sSql));
                try
                {
                    Byte[] data = new Byte[0];
                    data = (Byte[])(dt.Rows[0]["LOGO"]);
                    Com.Mod.mLogoCty = new System.IO.MemoryStream(data);
                }
                catch { }
                try
                {
                    Com.Mod.iSoLeSL = int.Parse(dt.Rows[0]["SO_LE_SL"].ToString());
                    Com.Mod.iSoLeDG = int.Parse(dt.Rows[0]["SO_LE_DG"].ToString());
                    Com.Mod.iSoLeDGSC = int.Parse(dt.Rows[0]["SO_LE_DG_SC"].ToString());
                    Com.Mod.iSoLeTT = int.Parse(dt.Rows[0]["SO_LE_TT"].ToString());
                    Com.Mod.iSoLeTTSC = int.Parse(dt.Rows[0]["SO_LE_TT_SC"].ToString());
                    Com.Mod.iSLVAT = int.Parse(dt.Rows[0]["SO_LE_VAT"].ToString());
                    Com.Mod.VATMD = float.Parse(dt.Rows[0]["MD_VAT"].ToString());
                    Com.Mod.iSLTyGia = int.Parse(dt.Rows[0]["SO_LE_TG"].ToString());
                    Com.Mod.iSLDinhMuc = int.Parse(dt.Rows[0]["SO_LE_DM"].ToString());
                    Com.Mod.iSLPTram = int.Parse(dt.Rows[0]["SO_LE_PT"].ToString());
                    Com.Mod.iSoLeCP = int.Parse(dt.Rows[0]["SO_LE_CP"].ToString());
                    Com.Mod.iLamTron = int.Parse(dt.Rows[0]["LAM_TRON"].ToString());
                    Com.Mod.sLoad = dt.Rows[0]["TEN_NGAN"].ToString();
                    Com.Mod.sDDTaiLieu = dt.Rows[0]["DUONG_DAN_TL"].ToString();
                    Com.Mod.sDDTaiLieuCloud = dt.Rows[0]["DUONG_DAN_TL_CLOUD"].ToString();
                    Com.Mod.sUserSer = Com.Mod.OS.Decrypt(dt.Rows[0]["USER_DD"].ToString(), true);
                    Com.Mod.sPassSer = Com.Mod.OS.Decrypt(dt.Rows[0]["PASS_DD"].ToString(), true);
                    Com.Mod.sPrivate = dt.Rows[0]["TTCT"].ToString();
                    if (Com.Mod.sDDTaiLieu != "")
                    {
                        Thread t = new Thread(() => {
                            CheckDDTL();
                        });
                        t.Start();
                    }



                }
                catch { }
                try
                {
                    Com.Mod.sTenCTy = dt.Rows[0]["TEN_CTY"].ToString();
                    Com.Mod.sDiaChi = dt.Rows[0]["DIA_CHI"].ToString();
                    Com.Mod.sDienThoai = dt.Rows[0]["DIEN_THOAI"].ToString();
                    Com.Mod.sFax = dt.Rows[0]["FAX"].ToString();
                    Com.Mod.sMail = dt.Rows[0]["EMAIL"].ToString();
                }
                catch { }
                try
                {
                    Com.Mod.iLCTT = int.Parse(dt.Rows[0]["LC_TT"].ToString());
                    Com.Mod.iSysTT = int.Parse(dt.Rows[0]["SYS_TT"].ToString());
                    Com.Mod.sTenLCTT = dt.Rows[0]["MA_TT_LC"].ToString();
                    Com.Mod.sTenSysTT = dt.Rows[0]["MA_TT_SYS"].ToString();
                }
                catch { }
                try {
                    Com.Mod.LogoLeft = float.Parse(dt.Rows[0]["LG_LEFT"].ToString());
                    Com.Mod.LogoTop = float.Parse(dt.Rows[0]["LG_TOP"].ToString());
                    Com.Mod.LogoWidth = float.Parse(dt.Rows[0]["LG_WIDTH"].ToString());
                    Com.Mod.LogoHeight = float.Parse(dt.Rows[0]["LG_HEIGHT"].ToString());
                }
                catch { }
            }
            catch { }
            try
            {
                Com.Mod.sSoLeSL = Com.Mod.OS.sDinhDangSoLe(Com.Mod.iSoLeSL);
                Com.Mod.sSoLeDG = Com.Mod.OS.sDinhDangSoLe(Com.Mod.iSoLeDG);
                Com.Mod.sSoLeDGSC = Com.Mod.OS.sDinhDangSoLe(Com.Mod.iSoLeDGSC);
                Com.Mod.sSoLeTT = Com.Mod.OS.sDinhDangSoLe(Com.Mod.iSoLeTT);
                Com.Mod.sSoLeTTSC = Com.Mod.OS.sDinhDangSoLe(Com.Mod.iSoLeTTSC);
                Com.Mod.sSoLeTyGia = Com.Mod.OS.sDinhDangSoLe(Com.Mod.iSLTyGia);
                Com.Mod.sSLDinhMuc = Com.Mod.OS.sDinhDangSoLe(Com.Mod.iSLDinhMuc);
                Com.Mod.sSLPTram = Com.Mod.OS.sDinhDangSoLe(Com.Mod.iSLPTram);
                Com.Mod.sSLVAT = Com.Mod.OS.sDinhDangSoLe(Com.Mod.iSLVAT);
            }
            catch { }
            try
            {
                Com.Mod.sUrlCheckServer = Com.Mod.OS.Decrypt(dt.Rows[0]["APIServer"].ToString(), true).Replace("VIETSOFTNAME", Com.Mod.sUrlCheckServer);
            }
            catch { }

            try
            {
                string sVerClient = Com.Mod.OS.LayDuLieu(@"Version.txt");
                if (sVerClient != null && sVerClient != "" && sVerClient.Length > 4)
                {
                    Com.Mod.sInfoClient = sVerClient.Substring(0, (sVerClient.Length - 4));
                    Com.Mod.sInfoClient = Com.Mod.sInfoClient.Substring(6, 2) + "/" + Com.Mod.sInfoClient.Substring(4, 2) + "/" + Com.Mod.sInfoClient.Substring(0, 4) + "." + sVerClient.Substring(8, sVerClient.Length - 8);
                }
                else
                    Com.Mod.sInfoClient = "NULL";
            }
            catch { }

            Program.MBarThongTin("msgLoginSuccessful");
            return true;

        }

        static void CheckDDTL()
        {
            try
            {
                using (new ConnectToSharedFolder(Com.Mod.sDDTaiLieu, new System.Net.NetworkCredential(Com.Mod.sUserSer, Com.Mod.sPassSer)))
                {
                    Com.Mod.bDDTL = true;
                }
            }
            catch { Com.Mod.bDDTL = false; }
        }

        //void CheckConnectServer1()
        //{
            

        //}
        public static DataTable MSendMail(string sAddress, string sBody,string sSubject,string sHTML = "HTML")
        {
            //EXEC [spWThongTin] @sDanhMuc  = N'SENT_MAIL' , @sCot1 = 'mashinhat@gmail.com;bamboo2711@gmail.com' @sCot2 = '',@sCot1 =  'DM2-NL-GH', @sCot3 = 'HTML', @sCot4 = N'Kính gửi Phòng QC và Phòng Quản lý đơn hàng '
            List<SqlParameter> lPar = new List<SqlParameter>
                {
                    new SqlParameter("@sDanhmuc", "SENT_MAIL"),
                    new SqlParameter("@sCot1" ,sAddress),  //@sCot1 = 'mashinhat@gmail.com;bamboo2711@gmail.com'
                    new SqlParameter("@sCot2", sBody),
                    new SqlParameter("@sCot3", sHTML),
                    new SqlParameter("@sCot4", sSubject)
                };

            //DataTable dt = new DataTable();
            return VsMain.MGetDatatable("spWThongTin", lPar);

        }


        #region Skin
        public static void MRestorePalette()
        {
            try
            {
                var settings = Properties.Settings.Default;
                if (!string.IsNullOrEmpty(settings.ApplicationSkinName))
                {
                    if (settings.APPCompactMode)
                        UserLookAndFeel.ForceCompactUIMode(true, false);
                    if (!string.IsNullOrEmpty(settings.AppPalette))
                        UserLookAndFeel.Default.SetSkinStyle(settings.ApplicationSkinName, settings.AppPalette);
                    else UserLookAndFeel.Default.SetSkinStyle(settings.ApplicationSkinName);
                }
            }
            catch { UserLookAndFeel.Default.SetSkinStyle("Blue");}
        }

        public static void MSavePalette()
        {
            var settings = Properties.Settings.Default;            
            try
            {
                
                settings.ApplicationSkinName = UserLookAndFeel.Default.SkinName;
                settings.AppPalette = UserLookAndFeel.Default.ActiveSvgPaletteName;
                settings.APPCompactMode = UserLookAndFeel.Default.CompactUIModeForced;
            }
            catch {
                settings.ApplicationSkinName = "Blue";
                settings.AppPalette = "";
            }
            settings.Save();

        }

        #endregion




    }

    public class MPrintInfo
    {
        public MPrintInfo(List<string> DKPhai, List<Font> DKFont,List<Rectangle> DKRectangle, List<BrickStringFormat> DKBrickStringFormat) 
        {
            _DKPhai = DKPhai;
            _DKFont = DKFont;
            _DKRectangle = DKRectangle;
            _DKBrickStringFormat = DKBrickStringFormat;
        }

        public List<string> _DKPhai;
        public List<Font> _DKFont;
        public List<Rectangle> _DKRectangle;
        public List<BrickStringFormat> _DKBrickStringFormat;
    }
    
    class RowInfo
    {
        public RowInfo(GridView view, int rowHandle, string column)
        {
            this.RowHandle = rowHandle;
            this.View = view;
            this.Column = column;
        }

        public RowInfo(XtraForm frm, GridView view, int rowHandle, string column)
        {
            this.Frm = frm;
            this.RowHandle = rowHandle;
            this.View = view;
            this.Column = column;
        }

        public XtraForm Frm;
        public GridView View;
        public int RowHandle;
        public string Column;
    }
}




