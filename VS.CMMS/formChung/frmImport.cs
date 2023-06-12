using System;
using DevExpress.Spreadsheet;
using DevExpress.DataAccess.Excel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using System.Collections;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.SqlClient;
using OfficeOpenXml;
using static DevExpress.Office.Utils.DrawingGroupShapePosH;

namespace VS.CMMS
{
    public partial class frmImport : DevExpress.XtraEditors.XtraForm
    {
        GridView viewChung;
        Point ptChung;
        DataTable dtNNgu = new DataTable();
        public DataTable dtemp;
        string sName = "frmThoiGianChayMayImport";
        string ChuoiKT = "";
        public frmImport(string sName)
        {
            sName = sName;
            InitializeComponent();
        }
        private void frmImport_Load(object sender, EventArgs e)
        {
            this.Name = sName;
            LoadNN();
            addvent();
        }
        #region event
        private void txtPath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string sPath = "";
            sPath = Com.Mod.OS.OpenFiles("All Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx|" + "All Files (*.*)|*.*");
            if (sPath == "") return;
            txtPath.Text = sPath;
            try
            {
                cboSheet.Text = "";
                cboSheet.Properties.Items.Clear();
                Workbook workbook = new Workbook();

                string ext = System.IO.Path.GetExtension(sPath);
                if (ext.ToLower() == ".xlsx")
                    workbook.LoadDocument(txtPath.Text, DocumentFormat.Xlsx);
                else
                    workbook.LoadDocument(txtPath.Text, DocumentFormat.Xls);
                List<string> wSheet = new List<string>();
                for (int i = 0; i < workbook.Worksheets.Count; i++)
                {
                    wSheet.Add(workbook.Worksheets[i].Name.ToString());
                }
                cboSheet.Properties.Items.AddRange(wSheet);

                cboSheet.EditValue = wSheet[0].ToString();
            }
            catch (InvalidOperationException ex)
            { XtraMessageBox.Show(ex.Message); }
        }
        private void cboSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdChung.DataSource = null;
            if (cboSheet.Text.Trim() == "")
            {
                return;
            }
            try
            {
                var source = new ExcelDataSource();
                source.FileName = txtPath.Text;
                var worksheetSettings = new ExcelWorksheetSettings(cboSheet.Text);
                source.SourceOptions = new ExcelSourceOptions(worksheetSettings);
                source.Fill();
                DataTable dtemp = ToDataTable(source);
                dtemp.Columns.Add("XOA", System.Type.GetType("System.Boolean"));
                grdChung.DataSource = dtemp;
                Com.Mod.OS.MLoadXtraGrid(grdChung, grvChung, dtemp, true, true, false, true);

            }
            catch (Exception ex)
            { XtraMessageBox.Show(ex.Message); }
        }

        private void grvChung_KeyDown(object sender, KeyEventArgs e)
        {
            if (grvChung.RowCount < 1) return;

            if (e.KeyCode == Keys.Delete)
            {
                if (XtraMessageBox.Show(Com.Mod.OS.GetNN(dtNNgu, "msgBanCoChacXoa", this.Name), this.Text, MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
                //GridView view = sender as GridView;
                DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                //view.DeleteRow(view.FocusedRowHandle);

                if (view.SelectedRowsCount != 0)
                {
                    view.GridControl.BeginUpdate();
                    List<int> selectedLogItems = new List<int>(view.GetSelectedRows());

                    for (int i = selectedLogItems.Count - 1; i >= 0; i--)
                    {
                        view.DeleteRow(selectedLogItems[i]);
                    }
                    view.GridControl.EndUpdate();

                }
                else if (view.FocusedRowHandle != GridControl.InvalidRowHandle)
                {
                    view.DeleteRow(view.FocusedRowHandle);
                }
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp = (DataTable)grdChung.DataSource;

                if (dtTmp == null || dtTmp.Select("XOA = 1").Count() == 0) return;

                DialogResult res = XtraMessageBox.Show(Com.Mod.OS.GetNN(dtNNgu, "msgBanCoChacXoa", this.Name), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No) return;

                dtTmp.AcceptChanges();
                foreach (DataRow dr in dtTmp.Rows)
                {
                    if (dr["XOA"].ToString() == "True")
                    {
                        dr.Delete();
                    }
                }
                dtTmp.AcceptChanges();
            }
            catch
            {
                XtraMessageBox.Show(Com.Mod.OS.GetNN(dtNNgu, "msgXoaThatBai", this.Name), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void grvChung_ShownEditor(object sender, EventArgs e)
        {
            viewChung = (GridView)sender;
            ptChung = viewChung.GridControl.PointToClient(Control.MousePosition);
            viewChung.ActiveEditor.DoubleClick += new EventHandler(ActiveEditor_DoubleClick);
        }
        private void ActiveEditor_DoubleClick(object sender, System.EventArgs e)
        {
            DoRowDoubleClick(viewChung, ptChung);
            grvChung.RefreshData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            switch (sName)
            {
                case "frmThoiGianChayMayImport":
                    {
                        ExporttempeteTGCM();
                        break;
                    }
                default:
                    break;
            }
        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdChung.DataSource == null) return;
                if (grvChung.RowCount <= 0) return;

                switch (sName)
                {
                    case "frmThoiGianChayMayImport":
                        {
                            iMportTGCM((DataTable)grdChung.DataSource);
                            break;
                        }
                    default:
                        break;
                }

            }
            catch { }
        }

        #endregion

        #region funciton

        private void ExporttempeteTGCM()
        {
            try
            {
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@sDMuc", "TEMPLETE_IMPORT_CHAY_MAY"));
                DataTable dt = new DataTable();
                dt = VsMain.MGetDatatable("spThoiGianDungChayMay", lPar);
                string sPath = "";
                sPath = Com.Mod.OS.SaveFiles("Excel file (*.xlsx)|*.xlsx");

                if (sPath == "") return;
                this.Cursor = Cursors.WaitCursor;

                var fi = new System.IO.FileInfo(sPath);
                if (fi.Exists)
                {
                    fi.Delete();
                }

                this.Cursor = Cursors.WaitCursor;

                ExcelPackage pck = new ExcelPackage();

                var ws1 = pck.Workbook.Worksheets.Add(Com.Mod.OS.GetLanguage(this.Name, Convert.ToString("sTieuDe1")));
                pck.SaveAs(fi);
                List<List<Object>> WidthColumns = new List<List<Object>>();
                List<Object> WidthColumnsName = new List<Object>();


                WidthColumnsName = new List<Object>() { "MS_MAY", 25 };
                WidthColumns.Add(WidthColumnsName);
                WidthColumnsName = new List<Object>() { "TG_GHI", 25, "dd/MM/yyyy" };
                WidthColumns.Add(WidthColumnsName);
                WidthColumnsName = new List<Object>() { "TGCM", 20, Com.Mod.sSoLeSL };
                WidthColumns.Add(WidthColumnsName);

                ws1.Cells[1, 1, 1, dt.Columns.Count].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.DarkDown;
                ws1.Cells[1, 1, 1, dt.Columns.Count].Style.Fill.BackgroundColor.SetColor(Color.Gainsboro);
                ws1.Cells[1, 1, 1, 1].Style.Font.Color.SetColor(Color.Red);

                if (dt.Rows.Count > 0)
                    ws1.Cells[1, 1].LoadFromDataTable(dt, true);
                Com.Mod.MExcel.MFormatExcel(ws1, dt, 1, this.Name, WidthColumns);

                if (fi.Exists)
                    fi.Delete();
                pck.SaveAs(fi);
                System.Diagnostics.Process.Start(fi.FullName);
            }
            catch { }
            this.Cursor = Cursors.Default;
        }    

        public void LoadNN()
        {
            try
            {
                dtNNgu.Load(SqlHelper.ExecuteReader(Com.Mod.CNStr, CommandType.Text, "SELECT KEYWORD , CASE " + Com.Mod.iNNgu + " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'" + this.Name + "' "));
                Com.Mod.OS.MLoadNN(dtNNgu, this, dataLayoutControl1);
                Com.Mod.OS.MLoadNNXtraGrid(grvChung, this.Name);
                Com.Mod.OS.MSaveResertGrid(grvChung, this.Name);
            }
            catch { }
        }
        private void addvent()
        {
            txtPath.ButtonClick += txtPath_ButtonClick;
            cboSheet.SelectedIndexChanged += cboSheet_SelectedIndexChanged;
            grvChung.ShownEditor += grvChung_ShownEditor;
            grvChung.KeyDown += grvChung_KeyDown;
        }
        private void DoRowDoubleClick(GridView view, Point pt)
        {
            if (cboSheet.Text == "") return;
            try
            {
                DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo info = view.CalcHitInfo(pt);
                int col = -1;
                col = info.Column.AbsoluteIndex;
                if (col == -1)
                    return;

                string sSql = "";
                string sKQ = "";

                System.Data.DataRow row = grvChung.GetDataRow(info.RowHandle);
                System.Data.DataRow drow;

                switch (sName)
                {
                    case "frmThoiGianChayMayImport":
                        {
                            switch (col)
                            {
                                case 0:
                                    sSql = "SELECT MS_MAY,TEN_MAY FROM dbo.MAY WHERE ID_HTSD = 2 ORDER BY MS_MAY";
                                    drow = GetData("MS_MAY", sSql);
                                    sKQ = Convert.ToString(drow["MS_MAY"]);
                                    row.ClearErrors();
                                    break;
                                default:
                                    break;
                            }
                            break;
                        }
                    default:
                        break;
                }

                if (sKQ != null && sKQ != "")
                    grvChung.SetFocusedRowCellValue(info.Column.FieldName, sKQ);
                grvChung.RefreshData();
            }
            catch { }
        }
        private DataTable ToDataTable(ExcelDataSource excelDataSource)
        {
            IList list = ((IListSource)excelDataSource).GetList();
            DevExpress.DataAccess.Native.Excel.DataView dataView = (DevExpress.DataAccess.Native.Excel.DataView)list;
            List<PropertyDescriptor> props = dataView.Columns.ToList<PropertyDescriptor>();
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (DevExpress.DataAccess.Native.Excel.ViewRow item in list)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }
        private bool KiemDuLieuSo(DataRow dr, int iCot, string sTenKTra, double GTSoSanh, double GTMacDinh, Boolean bKiemNull)
        {
            string sDLKiem;
            sDLKiem = dr[grvChung.Columns[iCot].FieldName.ToString()].ToString();
            double DLKiem;
            if (bKiemNull)
            {
                if (string.IsNullOrEmpty(sDLKiem))
                {
                    dr.SetColumnError(grvChung.Columns[iCot].FieldName.ToString(), sTenKTra + " " + Com.Mod.OS.GetNN(dtNNgu, "msgKhongDuocTrong", this.Name));
                    dr["XOA"] = 1;
                    return false;
                }
                else
                {
                    if (!double.TryParse(dr[grvChung.Columns[iCot].FieldName.ToString()].ToString(), out DLKiem))
                    {
                        dr.SetColumnError(grvChung.Columns[iCot].FieldName.ToString(), sTenKTra + " " + Com.Mod.OS.GetNN(dtNNgu, "msgPhaiLaSo", this.Name));
                        dr["XOA"] = 1;
                        return false;
                    }
                    else
                    {
                        if (GTSoSanh != -999999)
                        {
                            if (DLKiem < GTSoSanh)
                            {
                                dr.SetColumnError(grvChung.Columns[iCot].FieldName.ToString(), sTenKTra + " " + Com.Mod.OS.GetNN(dtNNgu, "msgKhongDuocNhoHon", this.Name) + " " + GTSoSanh.ToString());
                                dr["XOA"] = 1;
                                return false;
                            }

                            DLKiem = Math.Round(DLKiem, 8);
                            dr[grvChung.Columns[iCot].FieldName.ToString()] = DLKiem.ToString();

                        }
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(sDLKiem) && GTMacDinh != -999999)
                {
                    dr[grvChung.Columns[iCot].FieldName.ToString()] = GTMacDinh;
                    DLKiem = GTMacDinh;
                    sDLKiem = GTMacDinh.ToString();
                }

                if (!string.IsNullOrEmpty(sDLKiem))
                {
                    if (!double.TryParse(dr[grvChung.Columns[iCot].FieldName.ToString()].ToString(), out DLKiem))
                    {
                        dr.SetColumnError(grvChung.Columns[iCot].FieldName.ToString(), sTenKTra + " " + Com.Mod.OS.GetNN(dtNNgu, "msgPhaiLaSo", this.Name));
                        dr["XOA"] = 1;
                        return false;
                    }
                    else
                    {
                        if (GTSoSanh != -999999)
                        {
                            if (DLKiem < GTSoSanh)
                            {
                                dr.SetColumnError(grvChung.Columns[iCot].FieldName.ToString(), sTenKTra + " " + Com.Mod.OS.GetNN(dtNNgu, "msgKhongDuocNhoHon", this.Name) + " " + GTSoSanh.ToString());
                                dr["XOA"] = 1;
                                return false;
                            }

                            DLKiem = Math.Round(DLKiem, 8);
                            dr[grvChung.Columns[iCot].FieldName.ToString()] = DLKiem.ToString();
                        }

                    }
                }
            }
            return true;
        }
        private bool KiemKyTu(string strInput, string strChuoi)
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
        private DataRow GetData(string ImportType, string SQL)
        {
            try
            {
                frmImportView frm = new frmImportView(ImportType, SQL);
                Com.Mod.OS.LocationSizeForm(this, frm);
                if (frm.ShowDialog() == DialogResult.OK)
                    return frm._dtrow;
            }
            catch { }
            return null;
        }
        private void iMportTGCM(DataTable dtImport)
        {
            int col = 0;
            int count = grvChung.RowCount;
            #region Khai Bao Bien
            bool MsMayOK = true;
            bool NgayOK = true;
            bool TGCMOK = true;


            string MsMay = "";
            //string sSql = "";
            int errorCount = 0;
            #endregion

            DataTable dtTmp = new DataTable();

            #region Status bar
            prbIN.Position = 0;
            prbIN.Properties.Step = 1;
            prbIN.Properties.PercentView = true;
            prbIN.Properties.Maximum = dtImport.Rows.Count;
            prbIN.Properties.Minimum = 0;
            #endregion
            foreach (DataRow dr in dtImport.Rows)
            {
                MsMayOK = true;
                NgayOK = true;
                TGCMOK = true;

                dr.ClearErrors();
                dr["XOA"] = 0;
                col = 0;
                #region Mã Máy
                try
                {
                    MsMay = string.IsNullOrEmpty(Convert.ToString(dr[col])) ? "" : Convert.ToString(dr[col]).Trim();
                    if (MsMay == "")
                    {
                        dr.SetColumnError(grvChung.Columns[col].FieldName.ToString(), Com.Mod.OS.GetNN(dtNNgu, "msgMayKhongDuocTrong", this.Name));
                        MsMayOK = false;
                    }
                    else
                    {
                        if (KiemKyTu(MsMay, ""))
                        {
                            dr.SetColumnError(grvChung.Columns[col].FieldName.ToString(), Com.Mod.OS.GetNN(dtNNgu, "msgMaHangCoChuaKyTuDacBiet", this.Name));
                            MsMayOK = false;
                        }
                        else
                        {
                            dtTmp = new DataTable();
                            dtTmp.Load(SqlHelper.ExecuteReader(Com.Mod.CNStr, CommandType.Text, "SELECT * FROM dbo.MAY WHERE MS_MAY = N'" + MsMay + "' "));
                            if (dtTmp.Rows.Count == 0)
                            {
                                dr.SetColumnError(grvChung.Columns[col].FieldName.ToString(), Com.Mod.OS.GetNN(dtNNgu, "msgMayKhongTonTai", this.Name));
                                MsMayOK = false;
                            }
                        }
                    }
                }
                catch
                {
                    dr.SetColumnError(grvChung.Columns[col].FieldName.ToString(), Com.Mod.OS.GetNN(dtNNgu, "msgMayBiLoi", this.Name));
                    MsMayOK = false;
                }

                #endregion
                col = 1;
                #region tgcm
                try
                {
                    if (DateTime.TryParse(dr[col].ToString(), out DateTime date))
                    {
                        NgayOK = true;
                    }
                }
                catch
                {
                    dr.SetColumnError(grvChung.Columns[col].FieldName.ToString(), Com.Mod.OS.GetNN(dtNNgu, "msgKhongPhaiNgay", this.Name));
                    TGCMOK = false;
                }
                #endregion
                col = 2;
                #region tgcm
                try
                {
                    if (KiemDuLieuSo(dr, col, "", 0, 0, true))
                    {
                        TGCMOK = true;
                    }
                }
                catch
                {
                    dr.SetColumnError(grvChung.Columns[col].FieldName.ToString(), Com.Mod.OS.GetNN(dtNNgu, "msgPhaiLaSo", this.Name));
                    TGCMOK = false;
                }
                #endregion
                //kiểm tra trùng nhau
                if (dtImport.AsEnumerable().Count(x => x[0].Equals(MsMay) && x[1].ToString().Equals(dr[1].ToString())) > 1)
                {
                    dr.SetColumnError(grvChung.Columns[0].FieldName.ToString(), Com.Mod.OS.GetNN(dtNNgu, "msgTrungDuLieu", this.Name));
                    MsMayOK = false;
                    dr.SetColumnError(grvChung.Columns[1].FieldName.ToString(), Com.Mod.OS.GetNN(dtNNgu, "msgTrungDuLieu", this.Name));
                    NgayOK = false;
                }
                if (MsMayOK == true && NgayOK == true && TGCMOK == true)
                {
                    dr["XOA"] = 0;
                }
                else
                {
                    dr["XOA"] = 1;
                    errorCount++;
                }
                #region prb
                try
                {
                    prbIN.PerformStep();
                    prbIN.Update();
                }
                catch { }
                #endregion
            }
            #region check success
            if (errorCount == 0)
            {
                DialogResult res = XtraMessageBox.Show(Com.Mod.OS.GetNN(dtNNgu, "msgHoiCoChacImportThoGianChayMay", this.Name), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    try
                    {
                        //lấy tất cả giá trị có mã hàng hóa distinct
                        //var disSizes = dtImport.AsEnumerable().Select(row => new { MSHH = row.Field<string>(0), MSHT = row.Field<string>(1), TENHH = row.Field<string>(2) }).Distinct().ToList();

                        string BTam = "[TMPImportCM" + Com.Mod.UserID + "]";
                        DataTable dtCM = new DataTable();
                        dtCM = Com.Mod.OS.ConvertDatatable(grdChung).Copy();
                        dtCM.Columns[0].ColumnName = "MS_MAY";
                        dtCM.Columns[1].ColumnName = "TG_GHI";
                        dtCM.Columns[2].ColumnName = "TGCM";
                        Com.Mod.OS.MTableToData(Com.Mod.CNStr, BTam, dtCM, "");

                        List<SqlParameter> lPar = new List<SqlParameter>();
                        lPar.Add(new SqlParameter("@sDMuc", "IMPORT_CHAY_MAY"));
                        lPar.Add(new SqlParameter("@sBT", BTam));
                        VsMain.MExecuteNonQuery("spThoiGianDungChayMay", lPar);

                        Com.Mod.OS.XoaTable(BTam);
                        //thực hiện insert vào table CTTB
                        XtraMessageBox.Show(string.Format(Com.Mod.OS.GetNN(dtNNgu, "msgImportThanhCong", this.Name), dtImport.Rows.Count), this.Text);
                        DialogResult = DialogResult.OK;

                    }
                    catch (Exception ex)
                    {

                        XtraMessageBox.Show(Com.Mod.OS.GetNN(dtNNgu, "msgImportKhongThanhCong", this.Name) + "\n" +
                            ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show(Com.Mod.OS.GetNN(dtNNgu, "msgImportKhongThanhCong", this.Name));
                prbIN.Position = dtImport.Rows.Count;
            }
            prbIN.Position = dtImport.Rows.Count;
            #endregion
        }

        #endregion

    }
}

