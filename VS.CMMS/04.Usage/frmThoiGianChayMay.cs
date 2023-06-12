using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace VS.CMMS
{
    public partial class frmThoiGianChayMay : DevExpress.XtraEditors.XtraForm
    {
        int iPQ = 1;  // == 1  full; <> 1 la read only
        DataTable dtNNgu = new DataTable();
        double chiSoDenNgay = 0;
        public frmThoiGianChayMay(int PQ, string sID = "-1", string sDM = "")
        {
            InitializeComponent();
            this.iPQ = PQ;
            FormatControl();
        }
        #region event

        private void frmChung_Load(object sender, EventArgs e)
        {
            Com.Mod.sLoad = "0Load";
            datTNgay.DateTime = DateTime.Now.AddDays(-7);
            datDNgay.DateTime = DateTime.Now;
            Loadcombo();
            Com.Mod.sLoad = "";
            LoadDanhSachMay();
            if (grdDSChayMay.DataSource == null)
            {
                LoadDSChayMay(false);
            }
            LoadNN();
            addEvent();
        }
        private void GrvMay_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadDSChayMay(false);
        }
        private void GrvDSChayMay_KeyDown(object sender, KeyEventArgs e)
        {
            if (grvDSChayMay.RowCount < 1) return;
            if (e.KeyCode == Keys.Delete)
            {
                DeleteData();
            }
        }
        private void GrvDSChayMay_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int n = e.RowHandle;
            try
            {
                if (Com.Mod.sLoad == "0Load") return;

                if (e.Column.FieldName == "CHI_SO_DONG_HO")
                {
                    try
                    {
                        DataTable tempt = (DataTable)grdDSChayMay.DataSource;
                        TinhGioLuyKe(tempt, e.RowHandle, false);
                    }
                    catch
                    {
                        return;
                    }
                }
                if (e.Column.FieldName == "TGCM")
                {
                    try
                    {
                        DataTable tempt = (DataTable)grdDSChayMay.DataSource;
                        TinhGioLuyKeNhapLuyKe(tempt, e.RowHandle);
                    }
                    catch
                    {
                        return;
                    }
                }

            }
            catch { }
        }
        private void GrvDSChayMay_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (Convert.ToBoolean(grvDSChayMay.GetRowCellValue(e.RowHandle, "CHAY_LAI")))
                {

                    e.Appearance.BackColor = Color.LawnGreen;
                    e.Appearance.BackColor2 = Color.Honeydew;
                    e.HighPriority = true;
                }
            }
            //    e.Appearance.BackColor = Color.Salmon;
            //    e.Appearance.BackColor2 = Color.SeaShell;
            //    e.HighPriority = true;
        }
        private void GrvDSChayMay_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (grvDSChayMay.RowCount == 0) return;
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
            {
                int irow = e.HitInfo.RowHandle;
                e.Menu.Items.Clear();
                if (layGhi.Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Always)
                {
                    if (Convert.ToBoolean(grvDSChayMay.GetFocusedRowCellValue("CHAY_LAI")))
                    {
                        DevExpress.Utils.Menu.DXMenuItem itemCopyHH = new DXMenuItem(Com.Mod.OS.GetNN(dtNNgu, "mnuHuyCanLaiDongHo", this.Name), new EventHandler(mnuCanLaiDongHoClick));
                        e.Menu.Items.Add(itemCopyHH);
                    }
                    else
                    {
                        DevExpress.Utils.Menu.DXMenuItem itemCopyHH = new DXMenuItem(Com.Mod.OS.GetNN(dtNNgu, "mnuCanLaiDongHo", this.Name), new EventHandler(mnuCanLaiDongHoClick));
                        e.Menu.Items.Add(itemCopyHH);
                    }


                }
            }
        }
        private void CboLoaiMay_EditValueChanged(object sender, EventArgs e)
        {
            LoadDanhSachMay();
        }
        private void CboDiaDiem_EditValueChanged(object sender, EventArgs e)
        {
            LoadDanhSachMay();
        }
        private void DatDNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (layGhi.Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Never)
            {
                LoadDSChayMay(false);
            }
            else
            {
                LoadDSChayMay(true);
            }
        }
        private void DatTNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (layGhi.Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Never)
            {
                LoadDSChayMay(false);
            }
            else
            {
                LoadDSChayMay(true);
            }
        }
        private void btnImport_Click(object sender, EventArgs e)
        {
            frmImport frm = new frmImport("frmThoiGianChayMayImport");
            Com.Mod.OS.LocationSizeForm(this, frm);
            if (frm.ShowDialog() != DialogResult.OK) return;
            LoadDSChayMay(false);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            LoadDSChayMay(true);
            VisibleControl(true);
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            //kiểm tra trùng ngày
            try
            {
                DataTable dt = Com.Mod.OS.ConvertDatatable(grdDSChayMay);
                string BTam = "[sBTTGCM" + Com.Mod.UserID + "]";
                Com.Mod.OS.MTableToData(Com.Mod.CNStr, BTam, dt, "");
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@sDMuc", "SAVE_CHAY_MAY"));
                lPar.Add(new SqlParameter("@sBT", BTam));
                VsMain.MExecuteNonQuery("spThoiGianDungChayMay", lPar);
                LoadDSChayMay(false);
                VisibleControl(false);
                Program.MBarCapNhapThanhCong();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Com.Mod.OS.GetNN(dtNNgu, "msgGhiKhongThanhCong", this.Name), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Program.MBarCapNhapKhongThanhCong();
            }
        }

        private void btnKhongGhi_Click(object sender, EventArgs e)
        {
            LoadDSChayMay(false);
            VisibleControl(false);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = Com.Mod.OS.ConvertDatatable(grdDSChayMay);
            foreach (DataRow item in dt.Rows)
            {
                switch (Convert.ToDateTime(item["TG_GHI"]).DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        {
                            item["CHI_SO_DONG_HO"] = txtChuNhat.EditValue;
                            break;
                        }
                    case DayOfWeek.Monday:
                    case DayOfWeek.Tuesday:
                    case DayOfWeek.Wednesday:
                    case DayOfWeek.Thursday:
                    case DayOfWeek.Friday:
                        {
                            item["CHI_SO_DONG_HO"] = txtNgayThuong.EditValue;
                            break;
                        }
                    case DayOfWeek.Saturday:
                        {
                            item["CHI_SO_DONG_HO"] = txtThuBay.EditValue;
                            break;
                        }
                    default:
                        break;
                }

            }
            TinhGioLuyKe(dt, 0, true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            DeleteData();
        }

        #endregion

        #region function
        private void FormatControl()
        {
            if (iPQ != 1)
            {
                layGhi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layThem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layXoa.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layKhong.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layImport.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else
            {
                VisibleControl(false);
            }
            Com.Mod.OS.MFormatDateEdit(datTNgay, "g");
            Com.Mod.OS.MFormatDateEdit(datDNgay, "g");

        }
        private void addEvent()
        {
            cboDiaDiem.EditValueChanged += CboDiaDiem_EditValueChanged;
            cboLoaiMay.EditValueChanged += CboLoaiMay_EditValueChanged;
            grvMay.FocusedRowChanged += GrvMay_FocusedRowChanged;
            grvDSChayMay.CellValueChanged += GrvDSChayMay_CellValueChanged;
            grvDSChayMay.KeyDown += GrvDSChayMay_KeyDown;
            datTNgay.EditValueChanged += DatTNgay_EditValueChanged;
            datDNgay.EditValueChanged += DatDNgay_EditValueChanged;

            grvDSChayMay.PopupMenuShowing += GrvDSChayMay_PopupMenuShowing;
            grvDSChayMay.RowStyle += GrvDSChayMay_RowStyle;
        }

        void mnuCanLaiDongHoClick(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToBoolean(grvDSChayMay.GetFocusedRowCellValue("CHAY_LAI")))
                {     
                    grvDSChayMay.SetFocusedRowCellValue("CHAY_LAI", false);
                }
                else
                {
                    grvDSChayMay.SetFocusedRowCellValue("CHI_SO_DONG_HO", 0);
                    grvDSChayMay.SetFocusedRowCellValue("TGCM", 0);
                    grvDSChayMay.SetFocusedRowCellValue("CHAY_LAI", true);
                }    
          
            }
            catch
            {
            }
        }    
        private void TinhGioLuyKe(DataTable tempt, int row, bool link)
        {
            double max = 0;
            int row0 = tempt.Rows.IndexOf(tempt.AsEnumerable().Where(x => x["TGCM"].Equals(0)).FirstOrDefault());
            if (link == false)
            {
                if (row >= row0)
                {
                    row0 = tempt.Rows.Count;
                }
            }
            else
            {
                row0 = tempt.Rows.Count;
            }
            try
            {
                if (row == 0)
                {
                    string sSql = "SELECT ISNULL(TGCM,0) FROM dbo.THOI_GIAN_CHAY_MAY WHERE TG_GHI in (SELECT MAX(TG_GHI) FROM  dbo.THOI_GIAN_CHAY_MAY WHERE  TG_GHI < CONVERT(DATETIME,'" + datTNgay.DateTime.Month + "/" + datTNgay.DateTime.Day + "/" + datTNgay.DateTime.Year + "') AND ID_MAY='" + grvMay.GetFocusedDataRow()["ID_MAY"].ToString() + "' ) AND ID_MAY='" + grvMay.GetFocusedDataRow()["ID_MAY"].ToString() + "'";
                    max = Convert.ToDouble(SqlHelper.ExecuteScalar(Com.Mod.CNStr, CommandType.Text, sSql));
                    chiSoDenNgay = max;
                }
                else
                {
                    for (int i = row - 1; i >= 0; i--)
                    {
                        max = Convert.ToDouble(tempt.Rows[i]["TGCM"]);
                        if (max > 0 || Convert.ToDouble(tempt.Rows[i]["CHI_SO_DONG_HO"]) > 0 || Convert.ToBoolean(tempt.Rows[i]["CHAY_LAI"]) == true)
                            break;
                    }
                }
                for (int i = row; i < row0; i++)
                {
                    if (Convert.ToDouble(tempt.Rows[i]["CHI_SO_DONG_HO"]) > 0)
                    {
                        tempt.Rows[i]["TGCM"] = max + Convert.ToDouble(tempt.Rows[i]["CHI_SO_DONG_HO"]);
                        max += Convert.ToDouble(tempt.Rows[i]["CHI_SO_DONG_HO"]);
                    }
                    else
                    {
                        tempt.Rows[i]["TGCM"] = 0;
                        //break;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }
        private void TinhGioLuyKeNhapLuyKe(DataTable tempt, int row)
        {
            try
            {
                double max = Convert.ToDouble(tempt.Rows[row]["TGCM"]);
                double resulst = 0;
                double maxtb = 0;
                for (int i = row - 1; i >= 0; i--)
                {
                    if (Convert.ToDouble(tempt.Rows[i]["TGCM"]) > 0 || (Convert.ToDouble(tempt.Rows[i]["CHI_SO_DONG_HO"]) > 0) || Convert.ToBoolean(tempt.Rows[i]["CHAY_LAI"]) == true)
                    {
                        maxtb = Convert.ToDouble(tempt.Rows[i]["TGCM"]);
                        if (Convert.ToBoolean(tempt.Rows[i]["CHAY_LAI"]) == true) chiSoDenNgay = 0;
                        break;
                    }
                }
                if (row == 0)
                {
                    //nếu là dòng đầu tiên thì chỉ số đồng hồ đo bằng chỉ số hiện tại trừ đi đến ngày
                    resulst = max - chiSoDenNgay;
                    tempt.Rows[row]["CHI_SO_DONG_HO"] = resulst > 0 ? resulst : (Convert.ToDouble(tempt.Rows[row]["CHI_SO_DONG_HO"]) > 0 ? (Convert.ToDouble(tempt.Rows[row]["CHI_SO_DONG_HO"])) : 0);
                }
                else
                {
                    //nếu không phải là dòng đầu tiên thì chỉ số đồng hồ đo bằng chỉ số hiện tại trừ đi số giờ lũy kế trước
                    resulst = max - (maxtb > 0 ? maxtb : chiSoDenNgay);
                    tempt.Rows[row]["CHI_SO_DONG_HO"] = resulst > 0 ? resulst : (Convert.ToDouble(tempt.Rows[row]["CHI_SO_DONG_HO"]) > 0 ? (Convert.ToDouble(tempt.Rows[row]["CHI_SO_DONG_HO"])) : 0);
                }
                int row0 = tempt.Rows.IndexOf(tempt.AsEnumerable().Where(x => Convert.ToInt32(x["TGCM"]).Equals(0)).FirstOrDefault());
                if (row >= row0)
                {
                    row0 = tempt.Rows.Count;
                }
                for (int i = row + 1; i < row0; i++)
                {
                    if (Convert.ToDouble(tempt.Rows[i]["CHI_SO_DONG_HO"]) > 0)
                    {
                        tempt.Rows[i]["TGCM"] = max + Convert.ToDouble(tempt.Rows[i]["CHI_SO_DONG_HO"]);
                        max += Convert.ToDouble(tempt.Rows[i]["CHI_SO_DONG_HO"]);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void VisibleControl(bool them)
        {
            grvDSChayMay.OptionsBehavior.Editable = them;
            groDanhSachMay.Enabled = !them;
            txtTim.Properties.ReadOnly = them;
            if (them == true)
            {
                layImport.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layThem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layXoa.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layThoat.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lblNgayThuong.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lblThuBay.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lbl_ChuNhat.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lblTongSo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layCapNhat.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layemty.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                layGhi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layKhong.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {

                layImport.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layThem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layXoa.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layThoat.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                lblNgayThuong.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lblThuBay.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lbl_ChuNhat.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lblTongSo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layCapNhat.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layemty.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                layGhi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layKhong.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;


            }
        }
        public void LoadNN()
        {
            try
            {
                dtNNgu.Load(SqlHelper.ExecuteReader(Com.Mod.CNStr, CommandType.Text, "SELECT KEYWORD , CASE " + Com.Mod.iNNgu + " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'" + this.Name + "' "));
                Com.Mod.OS.MLoadNN(dtNNgu, this, dataLayoutControl1);
                Com.Mod.OS.MLoadNNGrid(dtNNgu, grvMay, this.Name, true);
                Com.Mod.OS.MLoadNNGrid(dtNNgu, grvDSChayMay, this.Name, true);
            }
            catch { }
        }
        private void Loadcombo()
        {
            List<SqlParameter> lPar = new List<SqlParameter>();
            lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
            lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
            lPar.Add(new SqlParameter("@iALL", 1));
            lPar.Add(new SqlParameter("@sDanhMuc", "TREE_DD;LOAI_MAY;"));
            DataSet ds = new DataSet();
            ds = VsMain.MGetDataSet("spGetDataCatalogs", lPar);
            if (ds.Tables.Count == 0) return;
            Com.Mod.OS.MLoadTreeLookUpEdit(cboDiaDiem, ds.Tables[0], "ID_DD", "TEN_DIA_DIEM", "ID_DD_CHA", this.Name);
            Com.Mod.OS.MLoadSearchLookUpEdit(cboLoaiMay, ds.Tables[1], "ID_LM", "TEN_LM", this.Name);
            cboDiaDiem.EditValue = Convert.ToInt64(-1);
        }
        private void LoadDanhSachMay()
        {
            if (Com.Mod.sLoad == "0Load") return;
            Com.Mod.sLoad = "0Load";
            try
            {
                DataTable dt = new DataTable();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@sDMuc", "GET_DANH_SACH_MAY"));
                lPar.Add(new SqlParameter("@iCot1", cboDiaDiem.EditValue));
                lPar.Add(new SqlParameter("@iCot2", cboLoaiMay.EditValue));
                dt = VsMain.MGetDatatable("spThoiGianDungChayMay", lPar);
                if (grdMay.DataSource == null)
                {
                    Com.Mod.OS.MLoadXtraGrid(grdMay, grvMay, dt, false, true, true, true);
                    grvMay.Columns["ID_MAY"].Visible = false;
                }
                else
                {
                    grdMay.DataSource = dt;
                }
            }
            catch
            {

            }
            Com.Mod.sLoad = "";
        }
        private void LoadDSChayMay(bool them)
        {
            if (Com.Mod.sLoad == "0Load") return;
            Com.Mod.sLoad = "0Load";
            DataTable dt = new DataTable();

            try
            {
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@sDMuc", "GET_THOI_GIAN_CHAY_MAY"));
                try
                {
                    lPar.Add(new SqlParameter("@iCot1", grvMay.GetFocusedRowCellValue("ID_MAY")));
                }
                catch
                {
                }
                lPar.Add(new SqlParameter("@TU_TG", datTNgay.DateTime));
                lPar.Add(new SqlParameter("@DEN_TG", datDNgay.DateTime));
                lPar.Add(new SqlParameter("@bCot1", them));
                dt = VsMain.MGetDatatable("spThoiGianDungChayMay", lPar);
                dt.Columns["TGCM"].ReadOnly = false;
                dt.Columns["CHI_SO_DONG_HO"].ReadOnly = false;
                if (grdDSChayMay.DataSource == null)
                {
                    Com.Mod.OS.MLoadXtraGrid(grdDSChayMay, grvDSChayMay, dt, true, true, false, false);
                    grvDSChayMay.Columns["ID_MAY"].Visible = false;
                    grvDSChayMay.Columns["CHAY_LAI"].Visible = false;
                    grvDSChayMay.Columns["TG_GHI"].OptionsColumn.AllowEdit = false;
                    grvDSChayMay.Columns["TGCM"].OptionsColumn.AllowEdit = true;
                    grvDSChayMay.Columns["CHI_SO_DONG_HO"].OptionsColumn.AllowEdit = true;
                }
                else
                {
                    grdDSChayMay.DataSource = dt;
                }
                string sSql = "SELECT ISNULL(TGCM,0) FROM dbo.THOI_GIAN_CHAY_MAY WHERE TG_GHI in (SELECT MAX(TG_GHI) FROM  dbo.THOI_GIAN_CHAY_MAY WHERE  TG_GHI < CONVERT(DATETIME,'" + datTNgay.DateTime.Month + "/" + datTNgay.DateTime.Day + "/" + datTNgay.DateTime.Year + "') AND	ID_MAY='" + grvMay.GetFocusedDataRow()["ID_MAY"].ToString() + "' ) AND	ID_MAY='" + grvMay.GetFocusedDataRow()["ID_MAY"].ToString() + "'";

                chiSoDenNgay = Convert.ToDouble(SqlHelper.ExecuteScalar(Com.Mod.CNStr, CommandType.Text, sSql));

                lblTongSo.Text = Com.Mod.OS.GetNN(dtNNgu, lblTongSo.Name, this.Name) + " " + datTNgay.DateTime.Date.AddDays(-1).ToString("dd/MM/yyyy") + ": " + chiSoDenNgay.ToString();
            }
            catch 
            {
            }
            Com.Mod.sLoad = "";
        }
        private void DeleteData()
        {
            if (grvDSChayMay.RowCount == 0)
            {
                XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgChuaCoDuLieu"), this.Text);
                return;
            }
            if (XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgBanCoChacXoa"), this.Text, MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            try
            {
                DevExpress.XtraGrid.Views.Grid.GridView view = grvDSChayMay;
                if (view.SelectedRowsCount != 0)
                {
                    view.GridControl.BeginUpdate();
                    List<int> selectedLogItems = new List<int>(view.GetSelectedRows());

                    for (int i = selectedLogItems.Count - 1; i >= 0; i--)
                    {
                        List<SqlParameter> lPar = new List<SqlParameter>();
                        lPar.Add(new SqlParameter("@sDMuc", "DELETE_CHAY_MAY"));
                        lPar.Add(new SqlParameter("@iCot1", grvMay.GetFocusedRowCellValue("ID_MAY")));
                        lPar.Add(new SqlParameter("@TU_TG", Convert.ToDateTime(grvDSChayMay.GetRowCellValue(selectedLogItems[i], "TG_GHI"))));
                        VsMain.MExecuteNonQuery("spThoiGianDungChayMay", lPar);

                        view.DeleteRow(selectedLogItems[i]);
                    }
                    view.GridControl.EndUpdate();

                }
                Program.MBarXoaThanhCong();
            }
            catch
            {
                XtraMessageBox.Show(Com.Mod.OS.GetNN(dtNNgu, "msgXoaThatBai", this.Name), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Program.MBarXoaKhongThanhCong();
            }


        }


        #endregion

    }
}
