using System;
using System.Collections.Generic;
using Microsoft.ApplicationBlocks.Data;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraEditors;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using DevExpress.XtraGrid.Views.Grid;

namespace Com
{
    public class MExcel
    {
        //private string sFile = "";
        public string SaveFiles(string MFilter)
        {
            try
            {
                SaveFileDialog f = new SaveFileDialog();
                f.Filter = MFilter;
                f.FileName = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                try
                {
                    DialogResult res = f.ShowDialog();
                    if (res == DialogResult.OK)
                        return f.FileName;
                    return "";
                }
                catch
                {
                    return "";
                }
            }
            catch (Exception)
            {
                return "";
            }
        }
        public string SaveFiles(string MFilter, string MDefault)
        {
            try
            {
                SaveFileDialog f = new SaveFileDialog();
                f.Filter = MFilter;
                f.FileName = MDefault + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
                try
                {
                    DialogResult res = f.ShowDialog();
                    if (res == DialogResult.OK)
                        return f.FileName;
                    return "";
                }
                catch
                {
                    return "";
                }
            }
            catch (Exception)
            {
                return "";
            }
        }
        public string TimDiemExcel(int Dong, int Cot)
        {
            string sTmp;
            try
            {
                sTmp = "";
                if (Cot > 26)
                {
                    sTmp = char.ConvertFromUtf32((Cot - 1) / 26 + 64);

                    sTmp = sTmp + char.ConvertFromUtf32((Cot - 1) % 26 + 65);
                }
                else
                    sTmp = char.ConvertFromUtf32(Cot + 64);
                if (Dong <= 0)
                    sTmp = sTmp;
                else
                    sTmp = sTmp + Convert.ToString(Dong);
                return sTmp;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public int MCot(string sCot)
        {
            int sStmp = 0;
            try
            {
                for (int i = 0; i <= sCot.Length - 1; i++)
                {
                    if (sStmp == 0)
                        sStmp = MTimCot(sCot.Substring(i, 1));
                    else
                        sStmp = sStmp + MTimCot(sCot.Substring(i, 1));
                }
            }
            catch (Exception)
            {
            }
            return sStmp;
        }

        private int MTimCot(string sCot)
        {
            int sTmp = 0;
            try
            {
                if (sCot == "!")
                    return 1;
                if (sCot == "@")
                    return 2;
                if (sCot == "#")
                    return 3;
                if (sCot == "$")
                    return 4;
                if (sCot == "%")
                    return 5;
                if (sCot == "^")
                    return 6;
                if (sCot == "&")
                    return 7;
                if (sCot == "*")
                    return 8;
                if (sCot == "(")
                    return 9;
                if (sCot == ")")
                    return 0;
            }
            catch (Exception)
            {
            }
            return sTmp;
        }
        


        public void MTTChung(int DongBD, int CotBD, int logoWidth, int logoHeight, ExcelWorksheet ws)
        {
            System.Data.DataTable dtTmp = new System.Data.DataTable();
            string sSql = "";
            if (Com.Mod.sPrivate.ToUpper() == "GREENFEED")
                sSql = "SELECT  CASE " + Com.Mod.iNNgu.ToString() + " WHEN 0 THEN C.TEN_DON_VI WHEN 1 THEN C.TEN_DON_VI_ANH ELSE C.TEN_DON_VI_HOA END AS TEN_CTY, " + " (SELECT TOP 1 LOGO   FROM THONG_TIN_CHUNG ) AS LOGO, C.DIA_CHI AS DIA_CHI, DIEN_THOAI AS Phone, FAX, '' AS EMAIL " + " FROM dbo.DON_VI AS C INNER JOIN dbo.TO_PHONG_BAN AS D ON C.MS_DON_VI = D.MS_DON_VI INNER JOIN dbo.USERS AS A " + " ON D.MS_TO = A.MS_TO WHERE(A.USERNAME = N'" + Com.Mod.UName.ToString() + "') ";
            else
                sSql = " SELECT CASE WHEN " + Com.Mod.iNNgu + "=0 " + " THEN TEN_CTY_TIENG_VIET ELSE TEN_CTY_TIENG_ANH END AS TEN_CTY,LOGO, " + " CASE WHEN " + Com.Mod.iNNgu + "=0 THEN DIA_CHI_VIET  ELSE DIA_CHI_ANH  END AS DIA_CHI,Phone," + " Fax,EMAIL FROM THONG_TIN_CHUNG ";
            dtTmp.Load(SqlHelper.ExecuteReader(Com.Mod.CNStr, System.Data.CommandType.Text, sSql));

            if (dtTmp.Rows.Count == 0 & Com.Mod.sPrivate.ToUpper() == "GREENFEED")
            {
                sSql = " SELECT CASE WHEN " + Com.Mod.iNNgu + "=0 " + " THEN TEN_CTY_TIENG_VIET ELSE TEN_CTY_TIENG_ANH END AS TEN_CTY,LOGO, " + " CASE WHEN " + Com.Mod.iNNgu + "=0 THEN DIA_CHI_VIET  ELSE DIA_CHI_ANH  END AS DIA_CHI,Phone," + " Fax,EMAIL FROM THONG_TIN_CHUNG ";
                dtTmp.Load(SqlHelper.ExecuteReader(Com.Mod.CNStr, System.Data.CommandType.Text, sSql));
            }

            AddImage(ws, DongBD, CotBD, logoWidth, logoHeight);

            ws.Cells["B1"].Value = dtTmp.Rows[0]["TEN_CTY"].ToString();
            ws.Cells["B2"].Value = Com.Mod.OS.GetLanguage("frmChung", "diachi") + " : " + dtTmp.Rows[0]["DIA_CHI"].ToString();
            ws.Cells["B3"].Value = ((Com.Mod.OS.GetLanguage("frmChung", "dienthoai") + " : ") + dtTmp.Rows[0]["phone"] + "  " + Com.Mod.OS.GetLanguage("frmChung", "fax") + " : ") + dtTmp.Rows[0]["FAX"];
        }


        public void MTTChung(int DongBD, int CotBD, int logoWidth, int logoHeight, ExcelWorksheet ws, string CotTTBD)
        {
            System.Data.DataTable dtTmp = new System.Data.DataTable();

            AddImage(ws, DongBD, CotBD, logoWidth, logoHeight);
            if ((CotTTBD == ""))
                return;
            ws.Cells[CotTTBD + "1"].Value = Com.Mod.sTenCTy; // dtTmp.Rows[0]["TEN_CTY"].ToString();
            ws.Cells[CotTTBD + "2"].Value = Com.Mod.OS.GetLanguage("frmChung", "diachi") + " : " + Com.Mod.sDiaChi; //dtTmp.Rows[0]["DIA_CHI"].ToString();

            ws.Cells[CotTTBD + "3"].Value = ((Com.Mod.OS.GetLanguage("frmChung", "dienthoai") + " : ") + Com.Mod.sDienThoai + "  " + Com.Mod.OS.GetLanguage("frmChung", "fax") + " : ") + Com.Mod.sFax;
        }

        public void AddImage(ExcelWorksheet ws, int DongBD, int CotBD, int logoWidth, int logoHeight)
        {
            System.Drawing.Image img;
            OfficeOpenXml.Drawing.ExcelPicture excelImage = null/* TODO Change to default(_) if this is not a reference type */;

            img = System.Drawing.Image.FromStream(Com.Mod.mLogoCty);

            if (Com.Mod.LogoWidth == 0)
                logoWidth = 110;
            if (Com.Mod.LogoHeight == 0)
                logoHeight = 45;

            excelImage = ws.Drawings.AddPicture(Com.Mod.sPrivate, img);
            excelImage.From.Column = CotBD;
            excelImage.From.Row = DongBD;
            excelImage.SetSize(logoWidth, logoHeight);
        }


        public void AddImage(ExcelWorksheet ws, int DongBD, int CotBD, int logoWidth, int logoHeight, string sPath)
        {
            System.Drawing.Bitmap image = new System.Drawing.Bitmap(sPath);
            OfficeOpenXml.Drawing.ExcelPicture excelImage = null/* TODO Change to default(_) if this is not a reference type */;

            if (image != null)
            {
                if (logoWidth == 0)
                    logoWidth = 110;
                if (logoHeight == 0)
                    logoHeight = 45;
                excelImage = ws.Drawings.AddPicture(Com.Mod.sPrivate, image);
                excelImage.From.Column = CotBD;
                excelImage.From.Row = DongBD;
                excelImage.SetSize(logoWidth, logoHeight);
                excelImage.From.ColumnOff = Pixel2MTU(2);
                excelImage.From.RowOff = Pixel2MTU(2);
            }
        }

        private int Pixel2MTU(int pixels)
        {
            int mtus = pixels * 9525;
            return mtus;
        }

        public void MFormatExcel(ExcelWorksheet ws, DataTable dtData, int iRow, string sBC, bool mNNgu = true, bool mAutoFitColumns = true, bool mWrapText = true)
        {
            try
            {
                int columnCount = dtData.Columns.Count;
                int rowCount = dtData.Rows.Count;

                var allCells = ws.Cells[iRow, 1, iRow + rowCount, columnCount];
                var border = allCells.Style.Border;

                border.Top.Style = ExcelBorderStyle.Thin;
                border.Left.Style = ExcelBorderStyle.Thin;
                border.Bottom.Style = ExcelBorderStyle.Thin;
                border.Right.Style = ExcelBorderStyle.Thin;
                

                if (mAutoFitColumns)
                    allCells.AutoFitColumns();
                allCells.Style.WrapText = mWrapText;
                allCells.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                allCells = ws.Cells[iRow, 1, iRow, columnCount];
                allCells.Style.Font.Bold = true;
                allCells.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;


                for (int i = 1; i <= columnCount + 1; i++)
                {
                    try
                    {
                        if (mNNgu)
                            ws.Cells[iRow, i].Value = Com.Mod.OS.GetLanguage(sBC, dtData.Columns[i - 1].ColumnName);
                    }
                    catch
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }
        }

        public void MFormatExcel(ExcelWorksheet ws, DataTable dtData, int iRow, string sBC, List<string> sCotNgay, string sDateFormat, bool mNNgu = true, bool mAutoFitColumns = true, bool mWrapText = true)
        {
            try
            {
                int columnCount = dtData.Columns.Count;
                int rowCount = dtData.Rows.Count;

                var allCells = ws.Cells[iRow, 1, iRow + rowCount, columnCount];
                var border = allCells.Style.Border;

                border.Top.Style = ExcelBorderStyle.Thin;
                border.Left.Style = ExcelBorderStyle.Thin;
                border.Bottom.Style = ExcelBorderStyle.Thin;
                border.Right.Style = ExcelBorderStyle.Thin;


                if (mAutoFitColumns)
                    allCells.AutoFitColumns();
                allCells.Style.WrapText = mWrapText;
                allCells.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                allCells = ws.Cells[iRow, 1, iRow, columnCount];
                allCells.Style.Font.Bold = true;
                allCells.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;


                for (int i = 1; i <= columnCount + 1; i++)
                {
                    try
                    {
                        if (sCotNgay != null)
                        {
                            if (sCotNgay.Contains(ws.Cells[iRow, i].Value.ToString()))
                            {
                                ws.Column(i).Style.Numberformat.Format = sDateFormat;
                                ws.Column(i).Width = 13;
                            }
                        }
                    }
                    catch
                    {
                    }

                    try
                    {
                        if (mNNgu)
                            ws.Cells[iRow, i].Value = Com.Mod.OS.GetLanguage(sBC, dtData.Columns[i - 1].ColumnName);
                    }
                    catch
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }
        }

        public void MFormatExcel(ExcelWorksheet ws, DataTable dtData, int iRow, string sBC, List<List<Object>> WidthColumns, bool mNNgu = true, bool mAutoFitColumns = true, bool mWrapText = true)
        {
            try
            {
                int columnCount = dtData.Columns.Count;
                int rowCount = dtData.Rows.Count;

                var allCells = ws.Cells[iRow, 1, iRow + rowCount, columnCount];
                var border = allCells.Style.Border;

                border.Top.Style = ExcelBorderStyle.Thin;
                border.Left.Style = ExcelBorderStyle.Thin;
                border.Bottom.Style = ExcelBorderStyle.Thin;
                border.Right.Style = ExcelBorderStyle.Thin;


                if (mAutoFitColumns)
                    allCells.AutoFitColumns();

                allCells.Style.WrapText = mWrapText;
                allCells.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                allCells = ws.Cells[iRow, 1, iRow, columnCount];
                allCells.Style.Font.Bold = true;
                allCells.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;


                for (int i = 1; i <= columnCount + 1; i++)
                {
                    try
                    {
                        if (WidthColumns != null)
                        {
                            for (int j = 0; j < WidthColumns.Count; j++)
                            {
                                if (WidthColumns[j][0].ToString().Contains(ws.Cells[iRow, i].Value.ToString()))
                                {
                                    ws.Column(i).Width = int.Parse(WidthColumns[j][1].ToString());

                                    try
                                    {
                                        if (WidthColumns[j][2].ToString() != "")
                                            ws.Column(i).Style.Numberformat.Format = WidthColumns[j][2].ToString();
                                    }
                                    catch { }
                                    break;
                                }
                            }
                        }
                    }
                    catch
                    {
                    }

                    try
                    {
                        if (mNNgu)
                            ws.Cells[iRow, i].Value = Com.Mod.OS.GetLanguage(sBC, dtData.Columns[i - 1].ColumnName);
                    }
                    catch
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }
        }

        public void MFormatExcel(ExcelWorksheet ws, DataTable dtData, int iRow, string sBC, List<List<Object>> WidthColumns, int iNNgu, bool mAutoFitColumns = true, bool mWrapText = true)
        {
            try
            {
                int columnCount = dtData.Columns.Count;
                int rowCount = dtData.Rows.Count;

                var allCells = ws.Cells[iRow, 1, iRow + rowCount, columnCount];
                var border = allCells.Style.Border;

                border.Top.Style = ExcelBorderStyle.Thin;
                border.Left.Style = ExcelBorderStyle.Thin;
                border.Bottom.Style = ExcelBorderStyle.Thin;
                border.Right.Style = ExcelBorderStyle.Thin;


                if (mAutoFitColumns)
                    allCells.AutoFitColumns();

                allCells.Style.WrapText = mWrapText;
                allCells.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                allCells = ws.Cells[iRow, 1, iRow, columnCount];
                allCells.Style.Font.Bold = true;
                allCells.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;


                for (int i = 1; i <= columnCount + 1; i++)
                {
                    try
                    {
                        if (WidthColumns != null)
                        {
                            for (int j = 0; j < WidthColumns.Count; j++)
                            {
                                if (WidthColumns[j][0].ToString().Contains(ws.Cells[iRow, i].Value.ToString()))
                                {
                                    ws.Column(i).Width = int.Parse(WidthColumns[j][1].ToString());

                                    try
                                    {
                                        if (WidthColumns[j][2].ToString() != "")
                                            ws.Column(i).Style.Numberformat.Format = WidthColumns[j][2].ToString();
                                    }
                                    catch { }
                                    break;
                                }
                            }
                        }
                    }
                    catch
                    {
                    }

                    try
                    {
                        if (iNNgu >= 0)
                            ws.Cells[iRow, i].Value = Com.Mod.OS.GetLanguage(sBC, dtData.Columns[i - 1].ColumnName, iNNgu);
                    }
                    catch
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }
        }

        public void MFormatExcel(ExcelWorksheet ws, DataTable dtData, int iRow, int iColumn, string sBC, List<List<Object>> WidthColumns, bool mNNgu = true, bool mAutoFitColumns = true, bool mWrapText = true, bool mCenter = true)
        {
            try
            {
                int columnCount = dtData.Columns.Count;
                int rowCount = dtData.Rows.Count;

                var allCells = ws.Cells[iRow, iColumn, iRow + rowCount, columnCount + iColumn - 1];
                var border = allCells.Style.Border;

                border.Top.Style = ExcelBorderStyle.Thin;
                border.Left.Style = ExcelBorderStyle.Thin;
                border.Bottom.Style = ExcelBorderStyle.Thin;
                border.Right.Style = ExcelBorderStyle.Thin;


                if (mAutoFitColumns)
                    allCells.AutoFitColumns();

                allCells.Style.WrapText = mWrapText;
                allCells.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                allCells = ws.Cells[iRow, 1, iRow, columnCount + iColumn];
                allCells.Style.Font.Bold = true;
                allCells.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;


                for (int i = 1; i <= columnCount + 1; i++)
                {
                    try
                    {
                        if (WidthColumns != null)
                        {
                            for (int j = 0; j < WidthColumns.Count; j++)
                            {
                                if (WidthColumns[j][0].ToString().Contains(ws.Cells[iRow, i + iColumn - 1].Value.ToString()))
                                {
                                    ws.Column(i + iColumn - 1).Width = int.Parse(WidthColumns[j][1].ToString());

                                    if(mCenter)
                                    {
                                        ws.Column(i + iColumn - 1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                        ws.Column(i + iColumn - 1).Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                    }    

                                    try
                                    {
                                        if (WidthColumns[j][2].ToString() != "")
                                            ws.Column(i + iColumn - 1).Style.Numberformat.Format = WidthColumns[j][2].ToString();
                                    }
                                    catch { }
                                    break;
                                }
                            }
                        }
                    }
                    catch
                    {
                    }

                    try
                    {
                        if (mNNgu)
                            ws.Cells[iRow, i + iColumn - 1].Value = Com.Mod.OS.GetLanguage(sBC, dtData.Columns[i - 1].ColumnName);
                    }
                    catch
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }
        }

        public void MFormatExcel(ExcelWorksheet ws, DataTable dtData, int iRow, string sBC, List<string> sCotHide, bool mNNgu = true, bool mAutoFitColumns = true, bool mWrapText = true)
        {
            try
            {
                int columnCount = dtData.Columns.Count;
                int rowCount = dtData.Rows.Count;

                var allCells = ws.Cells[iRow, 1, iRow + rowCount, columnCount];
                var border = allCells.Style.Border;

                border.Top.Style = ExcelBorderStyle.Thin;
                border.Left.Style = ExcelBorderStyle.Thin;
                border.Bottom.Style = ExcelBorderStyle.Thin;
                border.Right.Style = ExcelBorderStyle.Thin;

                if (mAutoFitColumns)
                    allCells.AutoFitColumns();
                allCells.Style.WrapText = mWrapText;
                allCells.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                allCells = ws.Cells[iRow, 1, iRow, columnCount];
                allCells.Style.Font.Bold = true;
                allCells.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;


                for (int i = 1; i <= columnCount + 1; i++)
                {
                    try
                    {
                        if (sCotHide != null)
                        {
                            if (sCotHide.Contains(ws.Cells[iRow, i].Value.ToString()))
                                ws.Column(i).Hidden = true;
                        }
                    }
                    catch
                    {
                    }

                    try
                    {
                        if (mNNgu)
                            ws.Cells[iRow, i].Value = Com.Mod.OS.GetLanguage(sBC, dtData.Columns[i - 1].ColumnName);
                    }
                    catch
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }
        }

        public void MFormatExcel(ExcelWorksheet ws, DataTable dtData, int iRow, string sBC, List<string> sCotNgay, string sDateFormat, List<List<Object>> WidthColumns, bool mNNgu = true, bool mAutoFitColumns = true, bool mWrapText = true)
        {
            try
            {
                int columnCount = dtData.Columns.Count;
                int rowCount = dtData.Rows.Count;

                var allCells = ws.Cells[iRow, 1, iRow + rowCount, columnCount];
                var border = allCells.Style.Border;

                border.Top.Style = ExcelBorderStyle.Thin;
                border.Left.Style = ExcelBorderStyle.Thin;
                border.Bottom.Style = ExcelBorderStyle.Thin;
                border.Right.Style = ExcelBorderStyle.Thin;

                if (mAutoFitColumns)
                    allCells.AutoFitColumns();
                allCells.Style.WrapText = mWrapText;
                allCells.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                allCells = ws.Cells[iRow, 1, iRow, columnCount];
                allCells.Style.Font.Bold = true;
                allCells.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;


                for (int i = 1; i <= columnCount + 1; i++)
                {
                    try
                    {
                        if (sCotNgay != null)
                        {
                            if (sCotNgay.Contains(ws.Cells[iRow, i].Value.ToString()))
                            {
                                ws.Column(i).Style.Numberformat.Format = sDateFormat;
                                ws.Column(i).Width = 13;
                            }
                        }
                        if (WidthColumns != null)
                        {
                            for (int j = 0; j < WidthColumns.Count; j++)
                            {
                                if (WidthColumns[j][0].ToString().Contains(ws.Cells[iRow, i].Value.ToString()))
                                {
                                    ws.Column(i).Width = int.Parse(WidthColumns[j][1].ToString());
                                    break;
                                }
                            }
                        }
                    }
                    catch
                    {
                    }

                    try
                    {
                        if (mNNgu)
                            ws.Cells[iRow, i].Value = Com.Mod.OS.GetLanguage(sBC, dtData.Columns[i - 1].ColumnName);
                    }
                    catch
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }
        }

        public void MFormatExcel(ExcelWorksheet ws, DataTable dtData, int iRow, string sBC, List<string> sCotNgay, string sDateFormat, List<string> sCotHide, bool mNNgu = true, bool mAutoFitColumns = true, bool mWrapText = true)
        {
            try
            {
                int columnCount = dtData.Columns.Count;
                int rowCount = dtData.Rows.Count;

                var allCells = ws.Cells[iRow, 1, iRow + rowCount, columnCount];
                var border = allCells.Style.Border;

                border.Top.Style = ExcelBorderStyle.Thin;
                border.Left.Style = ExcelBorderStyle.Thin;
                border.Bottom.Style = ExcelBorderStyle.Thin;
                border.Right.Style = ExcelBorderStyle.Thin;


                if (mAutoFitColumns)
                    allCells.AutoFitColumns();
                allCells.Style.WrapText = mWrapText;
                allCells.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                allCells = ws.Cells[iRow, 1, iRow, columnCount];
                allCells.Style.Font.Bold = true;
                allCells.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;


                for (int i = 1; i <= columnCount + 1; i++)
                {
                    try
                    {
                        if (sCotNgay != null)
                        {
                            if (sCotNgay.Contains(ws.Cells[iRow, i].Value.ToString()))
                            {
                                ws.Column(i).Style.Numberformat.Format = sDateFormat;
                                ws.Column(i).Width = 13;
                            }
                        }

                        if (sCotHide != null)
                        {
                            if (sCotHide.Contains(ws.Cells[iRow, i].Value.ToString()))
                                ws.Column(i).Hidden = true;
                        }
                    }
                    catch
                    {
                    }

                    try
                    {
                        if (mNNgu)
                            ws.Cells[iRow, i].Value = Com.Mod.OS.GetLanguage(sBC, dtData.Columns[i - 1].ColumnName);
                    }
                    catch
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }
        }

        public void MFormatExcel(ExcelWorksheet ws, DataTable dtData, int iRow, string sBC, List<string> sCotNgay, string sDateFormat, List<string> sCotHide, List<List<Object>> WidthColumns, bool mNNgu = true, bool mAutoFitColumns = true, bool mWrapText = true)
        {
            try
            {
                int columnCount = dtData.Columns.Count;
                int rowCount = dtData.Rows.Count;

                var allCells = ws.Cells[iRow, 1, iRow + rowCount, columnCount];
                var border = allCells.Style.Border;

                border.Top.Style = ExcelBorderStyle.Thin;
                border.Left.Style = ExcelBorderStyle.Thin;
                border.Bottom.Style = ExcelBorderStyle.Thin;
                border.Right.Style = ExcelBorderStyle.Thin;


                if (mAutoFitColumns)
                    allCells.AutoFitColumns();
                allCells.Style.WrapText = mWrapText;
                allCells.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                allCells = ws.Cells[iRow, 1, iRow, columnCount];
                allCells.Style.Font.Bold = true;
                allCells.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;


                for (int i = 1; i <= columnCount + 1; i++)
                {
                    try
                    {
                        if (sCotNgay != null)
                        {
                            if (sCotNgay.Contains(ws.Cells[iRow, i].Value.ToString()))
                            {
                                ws.Column(i).Style.Numberformat.Format = sDateFormat;
                                ws.Column(i).Width = 13;
                            }
                        }

                        if (sCotHide != null)
                        {
                            if (sCotHide.Contains(ws.Cells[iRow, i].Value.ToString()))
                                ws.Column(i).Hidden = true;
                        }

                        if (WidthColumns != null)
                        {
                            for (int j = 0; j < WidthColumns.Count; j++)
                            {
                                if (WidthColumns[j][0].ToString().Contains(ws.Cells[iRow, i].Value.ToString()))
                                {
                                    ws.Column(i).Width = int.Parse(WidthColumns[j][1].ToString());
                                    break;
                                }
                            }
                        }
                    }
                    catch
                    {
                    }

                    try
                    {
                        if (mNNgu)
                            ws.Cells[iRow, i].Value = Com.Mod.OS.GetLanguage(sBC, dtData.Columns[i - 1].ColumnName);
                    }
                    catch
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }
        }

        public void MText(ExcelWorksheet ws, string sBC, string sKeyWord, int DongBD, int CotBD)
        {
            if (sBC == "")
                ws.Cells[DongBD, CotBD].Value = sKeyWord;
            else
                ws.Cells[DongBD, CotBD].Value = Com.Mod.OS.GetLanguage(sBC, sKeyWord);
        }

        public void MText(ExcelWorksheet ws, string sBC, string sKeyWord, int DongBD, int CotBD, bool mBold)
        {
            var allCells = ws.Cells[DongBD, CotBD];
            allCells.Style.Font.Bold = mBold;
            if (sBC == "")
                allCells.Value = sKeyWord;
            else
                allCells.Value = Com.Mod.OS.GetLanguage(sBC, sKeyWord);
        }

        public void MText(ExcelWorksheet ws, string sBC, string sKeyWord, int DongBD, int CotBD, float mSize)
        {
            var allCells = ws.Cells[DongBD, CotBD];
            allCells.Style.Font.Size = mSize;
            if (sBC == "")
                allCells.Value = sKeyWord;
            else
                allCells.Value = Com.Mod.OS.GetLanguage(sBC, sKeyWord);
        }

        public void MText(ExcelWorksheet ws, string sBC, string sKeyWord, int DongBD, int CotBD, bool mBold, float mSize)
        {
            var allCells = ws.Cells[DongBD, CotBD];
            allCells.Style.Font.Bold = mBold;
            allCells.Style.Font.Size = mSize;
            if (sBC == "")
                allCells.Value = sKeyWord;
            else
                allCells.Value = Com.Mod.OS.GetLanguage(sBC, sKeyWord);
        }

        public void MText(ExcelWorksheet ws, string sBC, string sKeyWord, int DongBD, int CotBD, bool mBold, float mSize, OfficeOpenXml.Style.ExcelHorizontalAlignment mHorAli, OfficeOpenXml.Style.ExcelVerticalAlignment mVerAli)
        {
            var allCells = ws.Cells[DongBD, CotBD];
            allCells.Style.Font.Bold = mBold;
            allCells.Style.Font.Size = mSize;
            allCells.Style.HorizontalAlignment = mHorAli;
            allCells.Style.VerticalAlignment = mVerAli;
            if (sBC == "")
                allCells.Value = sKeyWord;
            else
                allCells.Value = Com.Mod.OS.GetLanguage(sBC, sKeyWord);
        }

        public void MText(ExcelWorksheet ws, string sBC, string sKeyWord, int DongBD, int CotBD, int DongKT, int CotKT, bool mMerge)
        {
            var allCells = ws.Cells[DongBD, CotBD, DongKT, CotKT];
            allCells.Merge = mMerge;
            if (sBC == "")
                allCells.Value = sKeyWord;
            else
                allCells.Value = Com.Mod.OS.GetLanguage(sBC, sKeyWord);
        }

        public void MText(ExcelWorksheet ws, string sBC, string sKeyWord, int DongBD, int CotBD, int DongKT, int CotKT, bool mMerge, bool mBold)
        {
            var allCells = ws.Cells[DongBD, CotBD, DongKT, CotKT];
            allCells.Merge = mMerge;
            allCells.Style.Font.Bold = mBold;
            if (sBC == "")
                allCells.Value = sKeyWord;
            else
                allCells.Value = Com.Mod.OS.GetLanguage(sBC, sKeyWord);
        }

        public void MText(ExcelWorksheet ws, string sBC, string sKeyWord, int DongBD, int CotBD, int DongKT, int CotKT, bool mMerge, bool mBold, float mSize)
        {
            var allCells = ws.Cells[DongBD, CotBD, DongKT, CotKT];
            allCells.Merge = mMerge;
            allCells.Style.Font.Bold = mBold;
            allCells.Style.Font.Size = mSize;
            if (sBC == "")
                allCells.Value = sKeyWord;
            else
                allCells.Value = Com.Mod.OS.GetLanguage(sBC, sKeyWord);
        }

        public void MText(ExcelWorksheet ws, string sBC, string sKeyWord, int DongBD, int CotBD, int DongKT, int CotKT, bool mMerge, bool mBold, float mSize, OfficeOpenXml.Style.ExcelHorizontalAlignment mHorAli, OfficeOpenXml.Style.ExcelVerticalAlignment mVerAli)
        {
            var allCells = ws.Cells[DongBD, CotBD, DongKT, CotKT];
            allCells.Merge = mMerge;
            allCells.Style.Font.Bold = mBold;
            allCells.Style.Font.Size = mSize;
            allCells.Style.HorizontalAlignment = mHorAli;
            allCells.Style.VerticalAlignment = mVerAli;
            if (sBC == "")
                allCells.Value = sKeyWord;
            else
                allCells.Value = Com.Mod.OS.GetLanguage(sBC, sKeyWord);
        }
        public bool MGetSheetNames(string sFilePath, LookUpEdit cboChonSheet)
        {

            try
            {
                DataTable dt = new DataTable();
                DataColumn dtColID = new DataColumn();
                dtColID.DataType = System.Type.GetType("System.Int16");
                dtColID.ColumnName = "ID";
                dt.Columns.Add(dtColID);

                DataColumn dtColName = new DataColumn();
                dtColName.DataType = System.Type.GetType("System.String");
                dtColName.ColumnName = "Name";
                dt.Columns.Add(dtColName);
                dt.Rows.Add(-1, "");

                byte[] CSVBytes = File.ReadAllBytes(sFilePath);
                var excelStream = new MemoryStream(CSVBytes);
                string FileName = Path.GetFileName(sFilePath);
                var FileExt = Path.GetExtension(FileName);


                if (FileExt == ".xls")
                {
                    HSSFWorkbook hssfwb = new HSSFWorkbook(excelStream);
                    for (int i = 0; i < hssfwb.NumberOfSheets; i++)
                    {
                        string SheetName = hssfwb.GetSheetName(i);
                        if (!string.IsNullOrEmpty(SheetName))
                            dt.Rows.Add(i, SheetName);
                    }
                }
                else if (FileExt == ".xlsx")
                {
                    XSSFWorkbook hssfwb = new XSSFWorkbook(excelStream);
                    for (int i = 0; i < hssfwb.NumberOfSheets; i++)
                    {
                        string SheetName = hssfwb.GetSheetName(i);
                        if (!string.IsNullOrEmpty(SheetName))
                            dt.Rows.Add(i, SheetName);
                    }
                }

                Com.Mod.sLoad = "0Load";
                if (dt.Rows.Count > 0)
                    Com.Mod.OS.MLoadLookUpEdit(cboChonSheet, dt, "ID", "Name", "");

                Com.Mod.sLoad = "";
                return true;
            }
            catch (Exception ex)
            {
                cboChonSheet.Properties.DataSource = null;
                Com.Mod.sLoad = "";
                XtraMessageBox.Show(ex.Message.ToString());
                return false;
            }

        }

        public DataTable MGetData2xls(String Path, string sheet)
        {
            HSSFWorkbook wb;
            HSSFSheet sh;
            try
            {

                using (var fs = new FileStream(Path, FileMode.Open, FileAccess.Read))
                {
                    wb = new HSSFWorkbook(fs);
                    fs.Close();
                }
                DataTable DT = new DataTable();
                DT.Rows.Clear();
                DT.Columns.Clear();
                System.Globalization.DateTimeFormatInfo dtF = new System.Globalization.DateTimeFormatInfo();
                sh = (HSSFSheet)wb.GetSheetAt(int.Parse(sheet));
                HSSFFormulaEvaluator formula = new HSSFFormulaEvaluator(wb);
                formula.EvaluateAll();
                int i = 0;
                int j1 = 0;
                if (DT.Columns.Count < sh.GetRow(i).Cells.Count)
                {
                    try
                    {
                        for (j1 = 0; j1 < sh.GetRow(i).Cells.Count; j1++)
                        {
                            var cell = sh.GetRow(i).GetCell(j1);
                            if (cell != null)
                            {

                                try
                                {
                                    DT.Columns.Add(sh.GetRow(i).GetCell(j1).StringCellValue, typeof(string));
                                }
                                catch
                                { DT.Columns.Add(sh.GetRow(i).GetCell(j1).StringCellValue + "F" + j1.ToString(), typeof(string)); }
                            }
                            else
                            {
                                DT.Columns.Add("NULL" + j1.ToString(), typeof(string));
                            }
                        }
                    }
                    catch (Exception ex12)
                    {

                        XtraMessageBox.Show(ex12.Message.ToString());
                        return null;
                    }
                }
                int iTongCot = sh.GetRow(i).Cells.Count;
                i = 1;
                int j;
                while (sh.GetRow(i) != null)
                {
                    DT.Rows.Add();
                    // write row value
                    for (j = 0; j < iTongCot; j++)
                    {
                        var cell = sh.GetRow(i).GetCell(j);

                        if (cell != null)
                        {

                            try
                            {
                                formula.EvaluateInCell(cell);
                                switch (cell.CellType)
                                {


                                    case NPOI.SS.UserModel.CellType.Numeric:

                                        try
                                        {
                                            string sFormat = cell.CellStyle.GetDataFormatString().ToUpper();
                                            if (sFormat.Contains("M") || sFormat.Contains("D") || sFormat.Contains("Y") || sFormat.Contains("H") || sFormat.Contains("M") || sFormat.Contains("S") || sFormat.Contains(":") || sFormat.Contains("/"))
                                            {
                                                DateTime dtNgay;
                                                try
                                                {
                                                    //dtNgay = DateTime.Parse(cell.DateCellValue.ToString(), dtF, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                                    dtNgay = cell.DateCellValue;
                                                }
                                                catch { DateTime.TryParse(cell.DateCellValue.ToString(), out dtNgay); }

                                                try
                                                {
                                                    DT.Rows[i - 1][j] = dtNgay;
                                                }
                                                catch
                                                {
                                                    DT.Rows[i - 1][j] = sh.GetRow(i).GetCell(j).NumericCellValue;
                                                }
                                            }
                                            else
                                            {
                                                double dGTi = 0;
                                                sFormat = "0.000000";
                                                int index = sFormat.IndexOf(".");
                                                if (index > 0)
                                                    dGTi = Math.Round(sh.GetRow(i).GetCell(j).NumericCellValue, sFormat.Substring(index).Length);
                                                else
                                                    dGTi = sh.GetRow(i).GetCell(j).NumericCellValue;

                                                DT.Rows[i - 1][j] = dGTi;
                                            }


                                        }
                                        catch { DT.Rows[i - 1][j] = sh.GetRow(i).GetCell(j).NumericCellValue; }

                                        break;
                                    case NPOI.SS.UserModel.CellType.Boolean:
                                        DT.Rows[i - 1][j] = sh.GetRow(i).GetCell(j).BooleanCellValue.ToString();
                                        break;

                                    default:
                                        DT.Rows[i - 1][j] = sh.GetRow(i).GetCell(j).StringCellValue;
                                        break;
                                }

                            }
                            catch (Exception ex1)
                            {

                                XtraMessageBox.Show(ex1.Message.ToString() + "\n " + " row : " + i.ToString() + " col : " + j.ToString());
                                return null;
                            }





                        }
                    }

                    i++;
                    #region prb
                    try
                    {

                    }
                    catch { }
                    #endregion
                }
                sh.CloneSheet(wb);
                wb.Close();
                return DT;
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message.ToString());
                return null;
            }
        }

        public DataTable MGetData2xlsx(String Path, string sheet)
        {
            XSSFWorkbook wb;
            XSSFSheet sh;
            int i = 0;

            try
            {

                using (var fs = new FileStream(Path, FileMode.Open, FileAccess.Read))
                {
                    wb = new XSSFWorkbook(fs);
                    fs.Close();
                }

                DataTable DT = new DataTable();
                DT.Rows.Clear();
                DT.Columns.Clear();
                System.Globalization.DateTimeFormatInfo dtF = new System.Globalization.DateTimeFormatInfo();
                // get sheet
                sh = (XSSFSheet)wb.GetSheetAt(int.Parse(sheet));

                i = 0;
                if (DT.Columns.Count < sh.GetRow(i).Cells.Count)
                {
                    for (int j = 0; j < sh.GetRow(i).Cells.Count; j++)
                    {
                        var cell = sh.GetRow(i).GetCell(j);
                        try
                        {
                            if (sh.GetRow(i).GetCell(j).StringCellValue.ToString().ToUpper() == "STT")
                            { DT.Columns.Add(sh.GetRow(i).GetCell(j).StringCellValue, typeof(float)); }
                            else
                            {
                                DT.Columns.Add(sh.GetRow(i).GetCell(j).StringCellValue, typeof(string));
                            }
                        }
                        catch
                        { DT.Columns.Add(sh.GetRow(i).GetCell(j).StringCellValue + "F" + j.ToString(), typeof(string)); }
                    }
                }
                int iTongCot = sh.GetRow(i).Cells.Count;

                i = 1;
                while (sh.GetRow(i) != null)
                {
                    DT.Rows.Add();
                    // write row value
                    for (int j = 0; j < iTongCot; j++)
                    {

                        var cell = sh.GetRow(i).GetCell(j);

                        if (cell != null)
                        {
                            switch (cell.CellType)
                            {
                                case NPOI.SS.UserModel.CellType.Numeric:

                                    try
                                    {
                                        string sFormat = cell.CellStyle.GetDataFormatString().ToUpper();
                                        if (sFormat.Contains("M") || sFormat.Contains("D") || sFormat.Contains("Y") || sFormat.Contains("H") || sFormat.Contains("M") || sFormat.Contains("S") || sFormat.Contains(":") || sFormat.Contains("/"))
                                        {
                                            DateTime dtNgay;
                                            try
                                            {
                                                //dtNgay = DateTime.Parse(cell.DateCellValue.ToString(), dtF, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                                dtNgay = cell.DateCellValue;
                                            }
                                            catch { DateTime.TryParse(cell.DateCellValue.ToString(), out dtNgay); }

                                            try
                                            {
                                                DT.Rows[i - 1][j] = dtNgay;
                                            }
                                            catch
                                            {
                                                DT.Rows[i - 1][j] = sh.GetRow(i).GetCell(j).NumericCellValue;
                                            }
                                        }
                                        else
                                        {
                                            double dGTi = 0;
                                            sFormat = "0.000000";
                                            int index = sFormat.IndexOf(".");
                                            if (index > 0)
                                                dGTi = Math.Round(sh.GetRow(i).GetCell(j).NumericCellValue, sFormat.Substring(index).Length);
                                            else
                                                dGTi = sh.GetRow(i).GetCell(j).NumericCellValue;

                                            DT.Rows[i - 1][j] = dGTi;
                                        }


                                    }
                                    catch { DT.Rows[i - 1][j] = sh.GetRow(i).GetCell(j).NumericCellValue; }

                                    break;
                                case NPOI.SS.UserModel.CellType.Boolean:
                                    DT.Rows[i - 1][j] = sh.GetRow(i).GetCell(j).BooleanCellValue.ToString();
                                    break;

                                default:
                                    try
                                    {
                                        DT.Rows[i - 1][j] = sh.GetRow(i).GetCell(j).StringCellValue;
                                    }
                                    catch { }
                                    break;
                            }

                        }
                    }

                    i++;
                    #region prb
                    try
                    {
                    }
                    catch { }
                    #endregion
                }
                wb.Close();
                return DT;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString() + " - ROW : " + i.ToString());
                return null;
            }
        }

        public void MInsRow(ExcelWorksheet ws, int iDongBD, int iDongThem)
        {
            ws.InsertRow(iDongBD, iDongThem);
        }

        public void DinhDangTieuDe(Excel.Worksheet MWsheet, int Dong, int Cot, int MDongMerge, int MCotMerge)
        {
            try
            {
                Excel.Range MRange = MWsheet.Range[MWsheet.Cells[Dong, Cot], MWsheet.Cells[MDongMerge, MCotMerge]];
                MRange.Interior.Color = System.Drawing.Color.FromArgb(221, 235, 247);
                MRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                MRange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                MRange.Font.Bold = true;
                MRange.WrapText = true;
                MRange.RowHeight = 15;
            }
            catch
            {
            }
        }

        #region kiểm dữ liệu

        public int CheckLen(GridView grvData, DataRow dr, int col, int giatri, int chieudai, string thongbao)
        {
            try
            {
                if (dr[grvData.Columns[col].FieldName.ToString()] == DBNull.Value || dr[grvData.Columns[col].FieldName.ToString()].ToString() == String.Empty)
                { giatri += 1; }
                else
                    if (dr[grvData.Columns[col].FieldName.ToString()].ToString().Length > chieudai)
                {
                    dr.SetColumnError(grvData.Columns[col].FieldName.ToString(), thongbao + " dài hơn " + chieudai + " ký tự." + "(" + dr[grvData.Columns[col].FieldName.ToString()].ToString().Length.ToString() + ")");
                    dr["XOA"] = 1;
                }
                else
                    giatri += 1;
                return giatri;
            }
            catch { return giatri; }
        }
        private string ChuoiKT = "";
        public bool KiemKyTu(string strInput, string strChuoi)
        {

            if (strChuoi == "") strChuoi = ChuoiKT;

            for (int i = 0; i < strInput.Length; i++)
            {
                for (int j = 0; j < strChuoi.Length; j++)
                {
                    if (strInput[i] == strChuoi[j])
                    {
                        return true;
                    }
                }
            }
            if (strInput.Contains("//"))
            {
                return true;
            }
            return false;
        }

        public bool KiemDuLieu(GridView grvData, DataRow dr, int iCot, Boolean bKiemNull, int iDoDaiKiem, string sform)
        {
            string sDLKiem;
            try
            {
                sDLKiem = dr[grvData.Columns[iCot].FieldName.ToString()].ToString();
                if (bKiemNull)
                {
                    if (string.IsNullOrEmpty(sDLKiem))
                    {
                        dr.SetColumnError(grvData.Columns[iCot].FieldName.ToString(), Com.Mod.OS.GetLanguage(sform, "msgKhongDuocTrong"));
                        dr["XOA"] = 1;
                        return false;
                    }
                    else
                    {
                        if (KiemKyTu(sDLKiem, ChuoiKT))  //KiemKyTu
                        {
                            dr.SetColumnError(grvData.Columns[iCot].FieldName.ToString(), Com.Mod.OS.GetLanguage(sform, "msgCoChuaKyTuDB"));
                            dr["XOA"] = 1;
                            return false;
                        }
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(sDLKiem))
                    {
                        if (KiemKyTu(sDLKiem, ChuoiKT))  //KiemKyTu
                        {
                            dr.SetColumnError(grvData.Columns[iCot].FieldName.ToString(), Com.Mod.OS.GetLanguage(sform, "msgCoChuaKyTuDB"));
                            dr["XOA"] = 1;
                            return false;
                        }
                    }
                }
                if (iDoDaiKiem != 0)
                {
                    if (sDLKiem.Length > iDoDaiKiem)
                    {
                        dr.SetColumnError(grvData.Columns[iCot].FieldName.ToString(), Com.Mod.OS.GetLanguage(sform, "msgDoDaiKyTuVuocQua " + iDoDaiKiem));
                        return false;
                    }
                }
            }
            catch
            {
                dr.SetColumnError(grvData.Columns[iCot].FieldName.ToString(), "error");
                dr["XOA"] = 1;
                return false;
            }
            return true;
        }

        public bool KiemTrungDL(GridView grvData, DataTable dt, DataRow dr, int iCot, string sDLKiem, string tabName, string ColName, string sform)
        {
            string sTenKTra = Com.Mod.OS.GetLanguage(sform, "msgTrungDL");
            try
            {

                if (dt.AsEnumerable().Where(x => x[iCot].Equals(sDLKiem)).CopyToDataTable().Rows.Count > 1)
                {
                    sTenKTra = Com.Mod.OS.GetLanguage(sform, "msgTrungDLLuoi");
                    dr.SetColumnError(grvData.Columns[iCot].FieldName.ToString(), sTenKTra);
                    dr["XOA"] = 1;
                    return false;
                }
                else
                {
                    if (Convert.ToInt32(SqlHelper.ExecuteScalar(Com.Mod.CNStr, CommandType.Text, "SELECT COUNT(*) FROM dbo.[" + tabName + "] WHERE " + ColName + " = N'" + sDLKiem + "'")) > 0)
                    {

                        sTenKTra = Com.Mod.OS.GetLanguage(sform, "msgTrungDLCSDL");
                        dr.SetColumnError(grvData.Columns[iCot].FieldName.ToString(), sTenKTra);
                        dr["XOA"] = 1;
                        return false;
                    }
                }
                return true;
            }
            catch //(Exception ex)
            {
                dr.SetColumnError(grvData.Columns[iCot].FieldName.ToString(), sTenKTra);
                dr["XOA"] = 1;
                return false;
            }
        }
        public bool KiemTonTai(GridView grvData, DataRow dr, int iCot, string sDLKiem, string tabName, string ColName, Boolean bKiemNull = true, string sform = "")
        {
            //null không kiểm
            if (bKiemNull)
            {//nếu null
                if (string.IsNullOrEmpty(sDLKiem))
                {
                    dr.SetColumnError(grvData.Columns[iCot].FieldName.ToString(), Com.Mod.OS.GetLanguage(sform, "msgKhongduocTrong"));
                    dr["XOA"] = 1;
                    return false;
                }
                //khác null
                {
                    if (Convert.ToInt32(SqlHelper.ExecuteScalar(Com.Mod.CNStr, CommandType.Text, "SELECT COUNT(*) FROM dbo." + tabName + " WHERE " + ColName + " = N'" + sDLKiem + "'")) == 0)
                    {
                        dr.SetColumnError(grvData.Columns[iCot].FieldName.ToString(), Com.Mod.OS.GetLanguage(sform, "msgChuaTonTaiCSDL"));
                        dr["XOA"] = 1;
                        return false;
                    }
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(sDLKiem))
                {
                    if (Convert.ToInt32(SqlHelper.ExecuteScalar(Com.Mod.CNStr, CommandType.Text, "SELECT COUNT(*) FROM dbo." + tabName + " WHERE " + ColName + " = N'" + sDLKiem + "'")) == 0)
                    {
                        dr.SetColumnError(grvData.Columns[iCot].FieldName.ToString(), Com.Mod.OS.GetLanguage(sform, "msgChuaTonTaiCSDL"));
                        dr["XOA"] = 1;
                        return false;
                    }
                }
            }
            return true;
        }

        public bool KiemTonTai(GridView grvData, DataRow dr, int iCot, string sDLKiem, string tabName, string ColName, string ColName1, string sform)
        {
            //null không kiểm
            if (!string.IsNullOrEmpty(sDLKiem))
            {
                if (Convert.ToInt32(SqlHelper.ExecuteScalar(Com.Mod.CNStr, CommandType.Text, "SELECT COUNT(*) FROM dbo." + tabName + " WHERE " + ColName + " " + ColName1 + " = N'" + sDLKiem + "'")) == 0)
                {
                    dr.SetColumnError(grvData.Columns[iCot].FieldName.ToString(), Com.Mod.OS.GetLanguage(sform, "msgChuaTonTaiCSDL"));
                    dr["XOA"] = 1;
                    return false;
                }
            }
            return true;
        }


        public bool KiemDuLieuNgay(GridView grvData, DataRow dr, int iCot, Boolean bKiemNull, string sform)
        {
            string sDLKiem;
            sDLKiem = dr[grvData.Columns[iCot].FieldName.ToString()].ToString();
            DateTime DLKiem;

            try
            {

                if (bKiemNull)
                {
                    if (string.IsNullOrEmpty(sDLKiem))
                    {
                        dr.SetColumnError(grvData.Columns[iCot].FieldName.ToString(), Com.Mod.OS.GetLanguage(sform, "msgKhongduocTrong"));
                        dr["XOA"] = 1;
                        return false;
                    }
                    else
                    {
                        //sDLKiem = DateTime.ParseExact(sDLKiem, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString();
                        if (!DateTime.TryParse(sDLKiem, out DLKiem))
                        {
                            dr.SetColumnError(grvData.Columns[iCot].FieldName.ToString(), Com.Mod.OS.GetLanguage(sform, "msgKhongPhaiNgay"));
                            dr["XOA"] = 1;
                            return false;
                        }

                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(sDLKiem))
                    {
                        if (!DateTime.TryParse(sDLKiem, out DLKiem))
                        {
                            dr.SetColumnError(grvData.Columns[iCot].FieldName.ToString(), Com.Mod.OS.GetLanguage(sform, "msgKhongPhaiNgay"));
                            dr["XOA"] = 1;
                            return false;
                        }
                    }
                }
            }
            catch
            {
                dr.SetColumnError(grvData.Columns[iCot].FieldName.ToString(), Com.Mod.OS.GetLanguage(sform, "msgKhongPhaiNgay"));
                dr["XOA"] = 1;
                return false;
            }
            return true;
        }

        public bool KiemDuLieuNgay(GridView grvData, DataRow dr, int iCot, string sTenKTra, Boolean bKiemNull, string GTSoSanh, int iKieuSS)
        {
            // iKieuSS = 1 la so sanh = 
            // iKieuSS = 2 la so sanh nho hon giá trị so sanh
            // iKieuSS = 3 la so sanh nho hon hoac bang
            // iKieuSS = 4 la so sanh lon hon
            // iKieuSS = 5 la so sanh lon hon hoac bang
            try
            {
                string sDLKiem;
                sDLKiem = DateTime.Parse(dr[grvData.Columns[iCot].FieldName.ToString()].ToString()).ToString("dd/MM/yyyy HH:mm:ss");
                DateTime DLKiem;
                DateTime DLSSanh;
                DateTime.TryParse(GTSoSanh, out DLSSanh);

                if (bKiemNull)
                {
                    if (string.IsNullOrEmpty(sDLKiem))
                    {
                        dr.SetColumnError(grvData.Columns[iCot].FieldName.ToString(), sTenKTra + " không được để trống");
                        dr["XOA"] = 1;
                        return false;
                    }
                    else
                    {
                        if (!DateTime.TryParse(sDLKiem, out DLKiem))
                        {
                            dr.SetColumnError(grvData.Columns[iCot].FieldName.ToString(), sTenKTra + " phải là datetime");
                            dr["XOA"] = 1;
                            return false;
                        }
                        else
                        {
                            if (DateTime.Parse(GTSoSanh) != DateTime.Parse("01/01/1900"))
                            {
                                #region Giá trị so sánh
                                //iKieuSS = 1 la so sanh = 
                                if (iKieuSS == 1)
                                {
                                    if (DLKiem == DLSSanh)
                                    {
                                        dr.SetColumnError(grvData.Columns[iCot].FieldName.ToString(), sTenKTra + " không được bằng " + DLSSanh.ToShortDateString());
                                        dr["XOA"] = 1;
                                        return false;
                                    }
                                }
                                // iKieuSS = 2 la so sanh nho hon giá trị so sanh
                                if (iKieuSS == 2)
                                {
                                    if (DLKiem < DLSSanh)
                                    {
                                        dr.SetColumnError(grvData.Columns[iCot].FieldName.ToString(), sTenKTra + " không được nhỏ hơn " + DLSSanh.ToShortDateString());
                                        dr["XOA"] = 1;
                                        return false;
                                    }
                                }
                                // iKieuSS = 3 la so sanh nho hon hoac bang
                                if (iKieuSS == 3)
                                {
                                    if (DLKiem <= DLSSanh)
                                    {
                                        dr.SetColumnError(grvData.Columns[iCot].FieldName.ToString(), sTenKTra + " không được nhỏ hơn hay bằng " + DLSSanh.ToShortDateString());
                                        dr["XOA"] = 1;
                                        return false;
                                    }
                                }
                                // iKieuSS = 4 la so sanh lon hon
                                if (iKieuSS == 4)
                                {
                                    if (DLKiem > DLSSanh)
                                    {
                                        dr.SetColumnError(grvData.Columns[iCot].FieldName.ToString(), sTenKTra + " không được lớn hơn " + DLSSanh.ToShortDateString());
                                        dr["XOA"] = 1;
                                        return false;
                                    }
                                }
                                // iKieuSS = 5 la so sanh lon hon hoac bang
                                if (iKieuSS >= 5)
                                {
                                    if (DLKiem < DLSSanh)
                                    {
                                        dr.SetColumnError(grvData.Columns[iCot].FieldName.ToString(), sTenKTra + " không được lớn hơn hay bằng " + DLSSanh.ToShortDateString());
                                        dr["XOA"] = 1;
                                        return false;
                                    }
                                }
                                #endregion
                            }
                        }

                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(sDLKiem))
                    {
                        if (!DateTime.TryParse(sDLKiem, out DLKiem))
                        {
                            dr.SetColumnError(grvData.Columns[iCot].FieldName.ToString(), sTenKTra + " phải là datetime");
                            dr["XOA"] = 1;
                            return false;
                        }
                        else
                        {
                            if (GTSoSanh != "01/01/1900")
                            {
                                #region Giá trị so sánh
                                //iKieuSS = 1 la so sanh = 
                                if (iKieuSS == 1)
                                {
                                    if (DLKiem == DLSSanh)
                                    {
                                        dr.SetColumnError(grvData.Columns[iCot].FieldName.ToString(), sTenKTra + " không được bằng " + DLSSanh.ToShortDateString());
                                        dr["XOA"] = 1;
                                        return false;
                                    }
                                }
                                // iKieuSS = 2 la so sanh nho hon giá trị so sanh
                                if (iKieuSS == 2)
                                {
                                    if (DLKiem < DLSSanh)
                                    {
                                        dr.SetColumnError(grvData.Columns[iCot].FieldName.ToString(), sTenKTra + " không được nhỏ hơn " + DLSSanh.ToShortDateString());
                                        dr["XOA"] = 1;
                                        return false;
                                    }
                                }
                                // iKieuSS = 3 la so sanh nho hon hoac bang
                                if (iKieuSS == 3)
                                {
                                    if (DLKiem <= DLSSanh)
                                    {
                                        dr.SetColumnError(grvData.Columns[iCot].FieldName.ToString(), sTenKTra + " không được nhỏ hơn hay bằng " + DLSSanh.ToShortDateString());
                                        dr["XOA"] = 1;
                                        return false;
                                    }
                                }
                                // iKieuSS = 4 la so sanh lon hon
                                if (iKieuSS == 4)
                                {
                                    if (DLKiem > DLSSanh)
                                    {
                                        dr.SetColumnError(grvData.Columns[iCot].FieldName.ToString(), sTenKTra + " không được lớn hơn " + DLSSanh.ToShortDateString());
                                        dr["XOA"] = 1;
                                        return false;
                                    }
                                }
                                // iKieuSS = 5 la so sanh lon hon hoac bang
                                if (iKieuSS >= 5)
                                {
                                    if (DLKiem < DLSSanh)
                                    {
                                        dr.SetColumnError(grvData.Columns[iCot].FieldName.ToString(), sTenKTra + " không được lớn hơn hay bằng " + DLSSanh.ToShortDateString());
                                        dr["XOA"] = 1;
                                        return false;
                                    }
                                }
                                #endregion
                            }
                        }
                    }
                }
            }
            catch
            {
                dr.SetColumnError(grvData.Columns[iCot].FieldName.ToString(), sTenKTra + " phải là datetime");
                dr["XOA"] = 1;
                return false;
            }
            return true;
        }

        public bool KiemDuLieuSo(GridView grvData, DataRow dr, int iCot, string sTenKTra, double GTSoSanh, double GTMacDinh, Boolean bKiemNull, string sForm)
        {
            string sDLKiem;
            sDLKiem = dr[grvData.Columns[iCot].FieldName.ToString()].ToString();
            double DLKiem;
            if (bKiemNull)
            {
                if (string.IsNullOrEmpty(sDLKiem))
                {
                    dr.SetColumnError(grvData.Columns[iCot].FieldName.ToString(), Com.Mod.OS.GetLanguage(sForm, "msgKhongduocTrong"));
                    dr["XOA"] = 1;
                    return false;
                }
                else
                {
                    if (!double.TryParse(dr[grvData.Columns[iCot].FieldName.ToString()].ToString(), out DLKiem))
                    {
                        dr.SetColumnError(grvData.Columns[iCot].FieldName.ToString(), Com.Mod.OS.GetLanguage(sForm, "msgKhongPhaiSo"));
                        dr["XOA"] = 1;
                        return false;
                    }
                    else
                    {
                        if (GTSoSanh != -999999)
                        {
                            if (DLKiem < GTSoSanh)
                            {
                                dr.SetColumnError(grvData.Columns[iCot].FieldName.ToString(), sTenKTra + Com.Mod.OS.GetLanguage(sForm, "msgKhongNhoHon") + GTSoSanh.ToString());
                                dr["XOA"] = 1;
                                return false;
                            }

                            DLKiem = Math.Round(DLKiem, 8);
                            dr[grvData.Columns[iCot].FieldName.ToString()] = DLKiem.ToString();

                        }
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(sDLKiem) && GTMacDinh != -999999)
                {
                    dr[grvData.Columns[iCot].FieldName.ToString()] = GTMacDinh;
                    DLKiem = GTMacDinh;
                    sDLKiem = GTMacDinh.ToString();
                }

                if (!string.IsNullOrEmpty(sDLKiem))
                {
                    if (!double.TryParse(dr[grvData.Columns[iCot].FieldName.ToString()].ToString(), out DLKiem))
                    {
                        dr.SetColumnError(grvData.Columns[iCot].FieldName.ToString(), sTenKTra + Com.Mod.OS.GetLanguage(sForm, "msgKhongPhaiSo"));
                        dr["XOA"] = 1;
                        return false;
                    }
                    else
                    {
                        if (GTSoSanh != -999999)
                        {
                            if (DLKiem < GTSoSanh)
                            {
                                dr.SetColumnError(grvData.Columns[iCot].FieldName.ToString(), sTenKTra + Com.Mod.OS.GetLanguage(sForm, "msgKhongNhoHon") + GTSoSanh.ToString());
                                dr["XOA"] = 1;
                                return false;
                            }

                            DLKiem = Math.Round(DLKiem, 8);
                            dr[grvData.Columns[iCot].FieldName.ToString()] = DLKiem.ToString();
                        }

                    }
                }


            }



            return true;
        }

        public bool KiemDuLieuBool(GridView grvData, DataRow dr, int iCot, string sTenKTra, string GTMacDinh)
        {
            if (string.IsNullOrEmpty(sTenKTra))
            {
                dr[grvData.Columns[iCot].FieldName.ToString()] = GTMacDinh;
                sTenKTra = GTMacDinh.ToString();
                dr[grvData.Columns[iCot].FieldName.ToString()] = sTenKTra;

            }

            if (!string.IsNullOrEmpty(sTenKTra))
            {
                try
                {
                    sTenKTra = sTenKTra.Trim() == "1" ? "True" : "False";
                }
                catch
                {
                    dr.SetColumnError(grvData.Columns[iCot].FieldName.ToString(), Com.Mod.OS.GetLanguage("frmChung", "KhongPhaiKieuBool"));
                    dr["XOA"] = 1;
                    return false; ;
                }
            }
            return true;
        }

        public bool KiemDuLieuSo(GridView grvData, DataRow dr, int iCot, string sTenKTra, double GTSoSanh, double GTMacDinh, Boolean bKiemNull, double GTTKhoang, string sForm)
        {
            double DLKiem;
            if (bKiemNull)
            {
                if (string.IsNullOrEmpty(sTenKTra))
                {
                    dr.SetColumnError(grvData.Columns[iCot].FieldName.ToString(), Com.Mod.OS.GetLanguage(sForm, "msgKhongduocTrong"));
                    dr["XOA"] = 1;
                    return false;
                }
                else
                {
                    if (!double.TryParse(sTenKTra, out DLKiem))
                    {
                        dr.SetColumnError(grvData.Columns[iCot].FieldName.ToString(), sTenKTra + Com.Mod.OS.GetLanguage(sForm, "msgKhongPhaiSo"));
                        dr["XOA"] = 1;
                        return false;
                    }
                    else
                    {
                        if (GTSoSanh != -999999)
                        {
                            if (DLKiem < GTSoSanh || DLKiem > GTTKhoang)
                            {
                                dr.SetColumnError(grvData.Columns[iCot].FieldName.ToString(), sTenKTra + Com.Mod.OS.GetLanguage(sForm, "msgKhongNhoHon") +
                                    GTSoSanh.ToString() + Com.Mod.OS.GetLanguage(sForm, "msgVaLonHon") + GTTKhoang.ToString());
                                dr["XOA"] = 1;
                                return false;

                            }
                        }
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(sTenKTra) && GTMacDinh != -999999)
                {
                    dr[grvData.Columns[iCot].FieldName.ToString()] = GTMacDinh;
                    DLKiem = GTMacDinh;
                    sTenKTra = GTMacDinh.ToString();
                }

                if (!string.IsNullOrEmpty(sTenKTra))
                {
                    if (!double.TryParse(sTenKTra, out DLKiem))
                    {
                        dr.SetColumnError(grvData.Columns[iCot].FieldName.ToString(), sTenKTra + Com.Mod.OS.GetLanguage(sForm, "msgKhongPhaiSo"));
                        dr["XOA"] = 1;
                        return false;
                    }
                    else
                    {
                        if (GTSoSanh != -999999)
                        {
                            if (DLKiem < GTSoSanh || DLKiem > GTTKhoang)
                            {
                                dr.SetColumnError(grvData.Columns[iCot].FieldName.ToString(), sTenKTra + Com.Mod.OS.GetLanguage(sForm, "msgKhongNhoHon") +
                                       GTSoSanh.ToString() + Com.Mod.OS.GetLanguage(sForm, "msgVaLonHon") + GTTKhoang.ToString());
                                dr["XOA"] = 1;
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        #endregion

        #region code hướng
        public void MReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }
        public void GetImage(byte[] Logo, string sPath, string sFile)
        {
            try
            {
                string strPath = sPath + @"\" + sFile;
                System.IO.MemoryStream stream = new System.IO.MemoryStream(Logo);
                System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
                img.Save(strPath);
            }
            catch (Exception)
            {
            }
        }

        public int TaoTTChung(Excel.Worksheet MWsheet, int DongBD, int CotBD, int DongKT, int CotKT, float MLeft, float MTop, float MWidth, float MHeight)
        {
            try
            {
                System.Data.DataTable dtTmp = new System.Data.DataTable();
                string sSql = "";
                sSql = "SELECT CASE WHEN " + Com.Mod.iNNgu + " =0  THEN TEN_CTY ELSE TEN_CTY_A END AS TEN_CTY,LOGO,  CASE WHEN " + Com.Mod.iNNgu + "=0 THEN DIA_CHI  ELSE DIA_CHI_A  END AS DIA_CHI,DIEN_THOAI,Fax,EMAIL,LOGO FROM THONG_TIN_CHUNG  ";

                dtTmp.Load(SqlHelper.ExecuteReader(Com.Mod.CNStr, System.Data.CommandType.Text, sSql));


                Microsoft.Office.Interop.Excel.Range CurCell = MWsheet.Range[MWsheet.Cells[DongBD, 1], MWsheet.Cells[DongKT, 1]];
                CurCell.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);

                CurCell = MWsheet.Range[MWsheet.Cells[DongBD, CotKT - 2], MWsheet.Cells[DongKT, CotKT]];
                CurCell.Merge(true);
                CurCell.Font.Bold = true;
                CurCell.Borders.LineStyle = 0;
                CurCell.Value2 = "Ngày in:" + DateTime.Today.ToString("dd/MM/yyyy");
                CurCell.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                CurCell.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                CurCell = MWsheet.Range[MWsheet.Cells[DongBD, CotBD], MWsheet.Cells[DongKT, CotKT - 3]];
                CurCell.Merge(true);
                CurCell.Font.Bold = true;
                CurCell.Borders.LineStyle = 0;
                CurCell.Value2 = dtTmp.Rows[0]["TEN_CTY"];



                DongBD += 1;
                DongKT += 1;
                CurCell = MWsheet.Range[MWsheet.Cells[DongBD, "A"], MWsheet.Cells[DongKT, "A"]];
                CurCell.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                CurCell = MWsheet.Range[MWsheet.Cells[DongBD, CotBD], MWsheet.Cells[DongKT, CotKT]];
                CurCell.Merge(true);
                CurCell.Font.Bold = true;
                CurCell.Borders.LineStyle = 0;
                CurCell.Value2 = Com.Mod.OS.GetLanguage("frmChung", "diachi") + " : " + dtTmp.Rows[0]["DIA_CHI"].ToString();

                DongBD += 1;
                DongKT += 1;
                CurCell = MWsheet.Range[MWsheet.Cells[DongBD, "A"], MWsheet.Cells[DongKT, "A"]];
                CurCell.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                CurCell = MWsheet.Range[MWsheet.Cells[DongBD, CotBD], MWsheet.Cells[DongKT, CotKT]];
                CurCell.Merge(true);
                CurCell.Font.Bold = true;
                CurCell.Borders.LineStyle = 0;
                CurCell.Value2 = Com.Mod.OS.GetLanguage("frmChung", "dienthoai") + " + " + dtTmp.Rows[0]["DIEN_THOAI"] + "  " + Com.Mod.OS.GetLanguage("frmChung", "Fax") + " : " + dtTmp.Rows[0]["FAX"].ToString();

                DongBD += 1;
                DongKT += 1;
                CurCell = MWsheet.Range[MWsheet.Cells[DongBD, "A"], MWsheet.Cells[DongKT, "A"]];
                CurCell.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                CurCell = MWsheet.Range[MWsheet.Cells[DongBD, CotBD], MWsheet.Cells[DongKT, CotKT]];
                CurCell.Merge(true);
                CurCell.Font.Bold = true;
                CurCell.Borders.LineStyle = 0;
                CurCell.Value2 = "Email : " + dtTmp.Rows[0]["EMAIL"];

                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "Masters");
                GetImage((byte[])dtTmp.Rows[0]["LOGO"], Application.StartupPath, "logo.bmp");
                MWsheet.Shapes.AddPicture(Application.StartupPath + @"\logo.bmp", Office.MsoTriState.msoFalse, Office.MsoTriState.msoCTrue, MLeft, MTop, MWidth, MHeight);
                System.IO.File.Delete(Application.StartupPath + @"\logo.bmp");

                return DongBD + 1;
            }
            catch
            {
                return DongBD + 1;
            }
        }

        public void ThemDong(Excel.Worksheet MWsheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection DangThem, int SoDongThem, int DongBDThem)
        {
            try
            {
                Excel.Range MRange = MWsheet.Range[MWsheet.Cells[DongBDThem, 1], MWsheet.Cells[DongBDThem, 1]];
                for (int i = 1; i <= SoDongThem; i++)
                    MRange.EntireRow.Insert(DangThem);
            }
            catch
            {
            }
        }

        public void DinhDang(Excel.Worksheet MWsheet, string NoiDung, int Dong, int Cot, String MNumberFormat, float MFontSize, bool MFontBold, Excel.XlHAlign MHAlign, Excel.XlVAlign MVAlign, bool MMerge, int MDongMerge, int MCotMerge, int MRowHeight)
        {
            try
            {
                Excel.Range MRange = MWsheet.Range[MWsheet.Cells[Dong, Cot], MWsheet.Cells[MDongMerge, MCotMerge]];
                MRange.Merge(MMerge);
                if (MFontSize > 0)
                    MRange.Font.Size = MFontSize;

                MRange.Font.Bold = MFontBold;
                MRange.HorizontalAlignment = MHAlign;
                MRange.VerticalAlignment = MVAlign;
                MRange.RowHeight = MRowHeight;

                if (MNumberFormat != "")
                    MRange.NumberFormat = MNumberFormat;
                if (NoiDung != "")
                    MWsheet.Cells[Dong, Cot] = NoiDung;
                MRange.Borders.LineStyle = 0;
            }
            catch
            {
            }
        }

        public Microsoft.Office.Interop.Excel.Range GetRange(Excel.Worksheet MWsheet, int DongBD, int CotBD, int DongKT, int CotKT)
        {
            try
            {
                // Dim allCells = MWsheet.Cells[DongBD, CotBD, DongKT, CotKT]
                Microsoft.Office.Interop.Excel.Range MRange = MWsheet.Range[MWsheet.Cells[DongBD, CotBD], MWsheet.Cells[DongKT, CotKT]];
                return MRange;
            }
            catch (Exception)
            {
                return null/* TODO Change to default(_) if this is not a reference type */;
            }
        }

        public void ColumnWidth(Excel.Worksheet MWsheet, float MColumnWidth, string MNumberFormat, bool MWrapText, int DongBD, int CotBD, int DongKT, int CotKT)
        {
            try
            {
                Excel.Range MRange = MWsheet.Range[MWsheet.Cells[DongBD, CotBD], MWsheet.Cells[DongKT, CotKT]];
                MRange.ColumnWidth = MColumnWidth;
                if (MNumberFormat != "")
                    MRange.NumberFormat = MNumberFormat;
                MRange.WrapText = MWrapText;
            }
            catch (Exception)
            {
            }
        }


        #endregion

        public void AddExcelDataValidationList(OfficeOpenXml.ExcelWorksheet wsWorkSheet, int iFromRow, int iFromCol, int iToRow, int iToCol, string sFomula, string sErrorTitle = "", string sError = "", OfficeOpenXml.DataValidation.ExcelDataValidationWarningStyle ErrorStyle = OfficeOpenXml.DataValidation.ExcelDataValidationWarningStyle.stop, string sPromptTitle = "", string sPrompt = "")
        {
            try
            {
                ExcelRange r = wsWorkSheet.Cells[iFromRow, iFromCol, iToRow, iToCol];
                var dvDataValidation = r.DataValidation.AddListDataValidation();
                dvDataValidation.Formula.ExcelFormula = sFomula;

                if (sErrorTitle != "" || sError != "")
                {
                    dvDataValidation.ShowErrorMessage = true;
                    dvDataValidation.ErrorTitle = sErrorTitle;
                    dvDataValidation.Error = sError;
                    dvDataValidation.ErrorStyle = ErrorStyle;
                }

                if (sPromptTitle != "" || sPrompt != "")
                {
                    dvDataValidation.ShowInputMessage = true;
                    dvDataValidation.PromptTitle = sPromptTitle;
                    dvDataValidation.Prompt = sPrompt;
                }

            }
            catch { }
        }

        public void AddExcelDataValidationList(OfficeOpenXml.ExcelWorksheet wsWorkSheet, int iFromRow, int iFromCol, int iToRow, int iToCol, List<string> sFomula, string sErrorTitle = "", string sError = "", OfficeOpenXml.DataValidation.ExcelDataValidationWarningStyle ErrorStyle = OfficeOpenXml.DataValidation.ExcelDataValidationWarningStyle.stop, string sPromptTitle = "", string sPrompt = "")
        {
            try
            {
                ExcelRange r = wsWorkSheet.Cells[iFromRow, iFromCol, iToRow, iToCol];
                var dvDataValidation = r.DataValidation.AddListDataValidation();

                foreach (var item in sFomula)
                {
                    dvDataValidation.Formula.Values.Add(item);
                }

                if (sErrorTitle != "" || sError != "")
                {
                    dvDataValidation.ShowErrorMessage = true;
                    dvDataValidation.ErrorTitle = sErrorTitle;
                    dvDataValidation.Error = sError;
                    dvDataValidation.ErrorStyle = ErrorStyle;
                }

                if (sPromptTitle != "" || sPrompt != "")
                {
                    dvDataValidation.ShowInputMessage = true;
                    dvDataValidation.PromptTitle = sPromptTitle;
                    dvDataValidation.Prompt = sPrompt;
                }

            }
            catch { }
        }


        public void AddExcelDataValidationList(OfficeOpenXml.ExcelWorksheet wsWorkSheet, int iFromRow, int iFromCol, int iToRow, int iToCol, string sFomula, string[] list, string sErrorTitle = "", string sError = "", OfficeOpenXml.DataValidation.ExcelDataValidationWarningStyle ErrorStyle = OfficeOpenXml.DataValidation.ExcelDataValidationWarningStyle.stop, string sPromptTitle = "", string sPrompt = "")
        {
            try
            {
                ExcelRange r = wsWorkSheet.Cells[iFromRow, iFromCol, iToRow, iToCol];
                var dvDataValidation = r.DataValidation.AddListDataValidation();
                if (sFomula != "")
                {
                    dvDataValidation.Formula.ExcelFormula = sFomula;
                }
                else
                {
                    foreach (var item in list)
                    {
                        dvDataValidation.Formula.Values.Add(item);

                    }
                }
                if (sErrorTitle != "" || sError != "")
                {
                    dvDataValidation.ShowErrorMessage = true;
                    dvDataValidation.ErrorTitle = sErrorTitle;
                    dvDataValidation.Error = sError;
                    dvDataValidation.ErrorStyle = ErrorStyle;
                }

                if (sPromptTitle != "" || sPrompt != "")
                {
                    dvDataValidation.ShowInputMessage = true;
                    dvDataValidation.PromptTitle = sPromptTitle;
                    dvDataValidation.Prompt = sPrompt;
                }

            }
            catch //(Exception ex)
            { }
        }

        //    Sub ThemDong(ByVal MWsheet As Excel.Worksheet, ByVal DangThem As Microsoft.Office.Interop.Excel.XlInsertShiftDirection, ByVal SoDongThem As Integer, ByVal DongBDThem As Integer)
        //    Try
        //        Dim MRange As Excel.Range = MWsheet.Range(MWsheet.Cells(DongBDThem, 1), MWsheet.Cells(DongBDThem, 1))
        //        For i As Integer = 1 To SoDongThem
        //            MRange.EntireRow.Insert(DangThem)
        //        Next
        //    Catch
        //    End Try
        //End Sub
    }
}