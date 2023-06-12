using Com;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using VS.CMMS;

namespace VS.ERP
{
    public partial class frmThoiGianDungMayView : DevExpress.XtraEditors.XtraForm
    {
        public int iLoai = 1;//1 view //2 chọn
        public Int64 iID = 1;//1 view //2 chọn
        public Int64 iIDMay = 1;//1 view //2 chọn
        public frmThoiGianDungMayView(int Loai = 1, Int64 ID = -1, Int64 IDMay = 0)
        {
            InitializeComponent();
            this.iLoai = Loai;
            this.iID = ID;
            this.iIDMay = IDMay;
        }
        private void frmThoiGianDungMayView_Load(object sender, EventArgs e)
        {
            if (iLoai == 1)
            {
                lblThucHien.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else
            {
                this.Name = "frmThoiGianDungMayView_Chon";
                lblDiaDiem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lblLoaiMay.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            Com.Mod.sLoad = "0Load";
            datDNgay.DateTime = DateTime.Now;
            datTNgay.DateTime = DateTime.Now.AddMonths(-1);
            Loadcombo();
            cboDiaDiem.EditValue = Convert.ToInt64(-1);
            Com.Mod.sLoad = "";
            LoadDSNM();
            LoadNN();
            addEvent();
        }
        private void addEvent()
        {
            datTNgay.EditValueChanged += datTNgay_EditValueChanged;
            datDNgay.EditValueChanged += datTNgay_EditValueChanged;
            cboDiaDiem.EditValueChanged += datTNgay_EditValueChanged;
            cboLoaiMay.EditValueChanged += datTNgay_EditValueChanged;
            grvDSNgungMay.DoubleClick += grvDSNgungMay_DoubleClick;
            grvDSNgungMay.CellValueChanging += grvDSNgungMay_CellValueChanging;
        }

        #region event
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void datTNgay_EditValueChanged(object sender, EventArgs e)
        {
            LoadDSNM();
        }
        private void btnThucHien_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = (DataTable)grdDSNgungMay.DataSource;

                if (dt.AsEnumerable().Count(x => Convert.ToBoolean(x["CHON"]) == true) == 0)
                {
                    XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgBanChuaChonDuLieu"), Com.Mod.OS.GetLanguage("frmChung", "msgThongBao"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                iID = Convert.ToInt64(dt.AsEnumerable().Where(x => Convert.ToBoolean(x["CHON"]) == true).Select(x => x["ID_TGDM"]).FirstOrDefault());
                DialogResult = DialogResult.OK;
                this.Close();

            }
            catch
            {

            }
        }

        private void grvDSNgungMay_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (iLoai == 1) return;
            try
            {
                DataTable dt = new DataTable();
                dt = (DataTable)grdDSNgungMay.DataSource;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["CHON"] = 0;
                }
                dt.AcceptChanges();
            }
            catch { }
        }

        private void grvDSNgungMay_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (iLoai == 2) return;
                if (grvDSNgungMay.DataSource == null || grvDSNgungMay.RowCount <= 0)
                {
                    this.Close();
                    return;
                }
                if (grvDSNgungMay.RowCount <= 0)
                {
                    this.Close();
                    return;
                }
                Com.Mod.sId = grvDSNgungMay.GetFocusedRowCellValue(grvDSNgungMay.Columns[0]).ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString(), this.Text);
            }
        }

        #endregion

        #region funciton
        public void LoadNN()
        {
            Com.Mod.OS.ThayDoiNN(this, dataLayoutControl1);
            Com.Mod.OS.MLoadNNXtraGrid(grvDSNgungMay, this.Name);
            Com.Mod.OS.MSaveResertGrid(grvDSNgungMay, this.Name);
        }
        private void LoadDSNM()
        {
            if (Com.Mod.sLoad == "0Load") return;
            DataTable dt = new DataTable();
            List<SqlParameter> lPar = new List<SqlParameter>();
            lPar.Add(new SqlParameter("@sDMuc", iLoai == 1 ? "DS_NGUNG_MAY" : "CHON_NGUNG_MAY"));
            lPar.Add(new SqlParameter("@TU_TG", datTNgay.DateTime));
            lPar.Add(new SqlParameter("@DEN_TG", datDNgay.DateTime));
            lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
            if (iLoai == 1)
            {
                lPar.Add(new SqlParameter("@iCot1", cboDiaDiem.EditValue));
                lPar.Add(new SqlParameter("@iCot2", cboLoaiMay.EditValue));
            }
            else
            {
                lPar.Add(new SqlParameter("@iID", iID));
                lPar.Add(new SqlParameter("@ID_MAY", iIDMay));
            }
            dt = VsMain.MGetDatatable("spThoiGianDungChayMay", lPar);
            if (grdDSNgungMay.DataSource == null)
            {
                Com.Mod.OS.MLoadXtraGrid(grdDSNgungMay, grvDSNgungMay, dt, iLoai == 2 ? true : false, true, true, true, true, this.Name);
                grvDSNgungMay.Columns["ID_TGDM"].Visible = false;
                grvDSNgungMay.Columns["TU_TG"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
                grvDSNgungMay.Columns["DEN_TG"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
                grvDSNgungMay.Columns["TU_TG"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                grvDSNgungMay.Columns["DEN_TG"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

                if (iLoai == 2)
                {
                    for (int i = 0; i < grvDSNgungMay.Columns.Count; i++)
                    {
                        if (grvDSNgungMay.Columns[i].FieldName == "CHON")
                        {
                            grvDSNgungMay.Columns[i].OptionsColumn.AllowEdit = true;
                        }
                        else
                        {
                            grvDSNgungMay.Columns[i].OptionsColumn.AllowEdit = false;
                        }
                    }
                }
            }
            else
            {
                grdDSNgungMay.DataSource = dt;
            }
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
        #endregion
    }
}
