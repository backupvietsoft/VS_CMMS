
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
    public class VsMain
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



        public static void MExportExcel(DataTable dtTmp, Excel.Worksheet ExcelSheets, Excel.Range sRange)
        {
            object[,] rawData = new object[dtTmp.Rows.Count + 1, dtTmp.Columns.Count - 1 + 1];
            for (var col = 0; col <= dtTmp.Columns.Count - 1; col++)
                rawData[0, col] = dtTmp.Columns[col].Caption;
            for (var col = 0; col <= dtTmp.Columns.Count - 1; col++)
            {
                for (var row = 0; row <= dtTmp.Rows.Count - 1; row++)
                    rawData[row + 1, col] = dtTmp.Rows[row][col].ToString();
            }
            sRange.Value = rawData;
        }


        #region Check


        public static bool CheckServer()
        {
            string resulst = "";
            //2.kiểm tra HHD
            resulst = Com.Mod.OS.GetAPI("HDD");
            if (resulst == "")
            {
                XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgChuaCoThongTinServer"), Com.Mod.OS.GetLanguage("frmChung", "sThongBao"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (resulst.Split('!')[0].ToUpper() == "TRUE")
            {
                String sSql = "";
                sSql = resulst.Split('!')[2];
                try
                {
                    if (Com.Mod.LicServer)  // = true la kiem tren server  // da co mac dinh khi lay vao 
                    {
                        var items = sSql.Split('|');
                        if (items.Length > 2)
                        {
                            for (int i = 1; i < items.Length; i++)
                            {
                                string sTmp = items[i].ToString();
                                if (sTmp.Contains(" CMMS~") == true)
                                {
                                    Com.Mod.iLic = Com.Mod.OS.MCot(sTmp.Split('~')[1].ToString());
                                    break;
                                }
                            }
                        }
                        else
                            Com.Mod.iLic = Com.Mod.OS.MCot(items[1].ToString().Split('~')[1].ToString());
                    }
                    else Com.Mod.iLic = -1;
                }
                catch { }

                // Kiem co phai ban demo, neu demo thi moi kiem ngay
                if (sSql.Split('|')[0].ToUpper() == "DEMO")
                {
                    //5.kiểm tra hết hạn
                    DateTime Ngay = DateTime.ParseExact(resulst.Split('!')[1], "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                    sSql = "SELECT GETDATE() AS NGAY";
                    sSql = Convert.ToString(SqlHelper.ExecuteScalar(Com.Mod.CNStr, System.Data.CommandType.Text, sSql));
                    if (Ngay.Date < Convert.ToDateTime(sSql).Date)
                    {
                        XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgHetHanSuDung"), Com.Mod.OS.GetLanguage("frmChung", "sThongBao"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    return true;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgSaiHDD"), Com.Mod.OS.GetLanguage("frmChung", "sThongBao"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static void CheckUpdate()
        {
            string sSql = "";
            try
            {
                #region Lay thong tin ver server
                sSql = "SELECT TOP 1 VER FROM dbo.THONG_TIN_CHUNG";
                sSql = Convert.ToString(SqlHelper.ExecuteScalar(Com.Mod.CNStr, System.Data.CommandType.Text, sSql));
                try
                {
                    Com.Mod.sInfoSer = sSql.Substring(0, (sSql.Length - 4));
                    Com.Mod.sInfoSer = Com.Mod.sInfoSer.Substring(6, 2) + "/" + Com.Mod.sInfoSer.Substring(4, 2) + "/" + Com.Mod.sInfoSer.Substring(0, 4) + "." + sSql.Substring(8, sSql.Length - 8);
                }
                catch
                {
                    Com.Mod.sInfoSer = "01/01/2000.0001";
                    sSql = "200001010001";
                }
                #endregion

                #region Lay thong tin ver client
                string sVerClient;
                sVerClient = Com.Mod.OS.LayDuLieu(@"Version.txt");
                try
                {
                    Com.Mod.sInfoClient = sVerClient.Substring(0, (sVerClient.Length - 4));
                    Com.Mod.sInfoClient = Com.Mod.sInfoClient.Substring(6, 2) + "/" + Com.Mod.sInfoClient.Substring(4, 2) + "/" + Com.Mod.sInfoClient.Substring(0, 4) + "." + sVerClient.Substring(8, sVerClient.Length - 8);
                }
                catch
                {
                    Com.Mod.sInfoClient = "01/01/2000.0001";
                    sVerClient = "200001010001";
                }
                #endregion
                try { if (double.Parse(sVerClient) == double.Parse(sSql)) return; } catch { return; }
                sSql = "SELECT TOP 1 (CONVERT(NVARCHAR,LOAI_CN) + '!' + isnull(LINK1, '-1') + '!' + isnull(LINK2, '-1') + '!' + isnull(LINK3, '-1')) AS CAPNHAT FROM THONG_TIN_CHUNG";
                sSql = Convert.ToString(SqlHelper.ExecuteScalar(Com.Mod.CNStr, System.Data.CommandType.Text, sSql));

                string[] sArr = sSql.Split('!');
                int loai = Convert.ToInt32(sArr[0].ToString());
                String link1 = sArr[1];
                String link2 = sArr[2];
                String link3 = sArr[3];
                //Khong có loai update thi thoát
                if (loai <= -1) return;
                switch (loai)
                {
                    //Loai 2 xai link1,2 : path link tren dropbox 
                    //Loai 1 xai link3: path link tren server
                    case 1:  //Update tren server voi link3
                        {
                            if (string.IsNullOrEmpty(link3)) return;
                            if (!Directory.Exists(link3))
                            {
                                XtraMessageBox.Show("Link update : " + link3 + " không tồn tại.");
                                return;
                            }
                            MUpdate(loai, ".", ".", link3);
                            break;
                        }
                    case 2: // Updatetren dropbox
                        {
                            if (string.IsNullOrEmpty(link1)) return;
                            MUpdate(loai, link1, link2, ".");
                            break;
                        }
                    default: { break; }
                }
            }
            catch
            { }
        }
        private static void MUpdate(int loai, String link1, String link2, String link3)
        {
            try
            {
                System.Diagnostics.Process.Start("Update.exe", loai.ToString() + " " + link1 + " " + link2 + " " + link3 + " " + Application.ProductName);
                //https://www.dropbox.com/s/ntwwve7ys4awrkj/Update.zip?dl=0
                //https://www.dropbox.com/s/6gppx79hbcph1qp/Version.txt?dl=0
                //VS.OEE

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
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
                try
                {
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
            ////try
            ////{
            ////    using (new ConnectToSharedFolder(Com.Mod.sDDTaiLieu, new System.Net.NetworkCredential(Com.Mod.sUserSer, Com.Mod.sPassSer)))
            ////    {
            ////        Com.Mod.bDDTL = true;
            ////    }
            ////}
            ////catch { Com.Mod.bDDTL = false; }
            ///
            Com.Mod.bDDTL = true;
        }

        public static DataTable MSendMail(string sAddress, string sBody, string sSubject, string sHTML = "HTML")
        {
            //EXEC [spWThongTin] @sDanhMuc  = N'SENT_MAIL' , @sNVARCHAR1 = 'mashinhat@gmail.com;bamboo2711@gmail.com' @sCot2 = '',@sNVARCHAR1 =  'DM2-NL-GH', @sCot3 = 'HTML', @sCot4 = N'Kính gửi Phòng QC và Phòng Quản lý đơn hàng '
            List<SqlParameter> lPar = new List<SqlParameter>
                {
                    new SqlParameter("@sDanhmuc", "SENT_MAIL"),
                    new SqlParameter("@sNVARCHAR1" ,sAddress),  //@sNVARCHAR1 = 'mashinhat@gmail.com;bamboo2711@gmail.com'
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
            catch { UserLookAndFeel.Default.SetSkinStyle("Blue"); }
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
            catch
            {
                settings.ApplicationSkinName = "Blue";
                settings.AppPalette = "";
            }
            settings.Save();

        }

        #endregion
        public static void MLinkBom(Boolean bHH, Int64 iID)
        {

        }



    }

    public class MPrintInfo
    {
        public MPrintInfo(List<string> DKPhai, List<Font> DKFont, List<Rectangle> DKRectangle, List<BrickStringFormat> DKBrickStringFormat)
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




