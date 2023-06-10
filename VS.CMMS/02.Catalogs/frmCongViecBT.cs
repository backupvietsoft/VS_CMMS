using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace VS.CMMS
{
    public partial class frmCongViecBT : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = 1;
        private Color _highlightColor;
        string sPS = "";
        public frmCongViecBT(int PQ, string Find, string SP)
        {
            InitializeComponent();
            iPQ = PQ;
            sPS = SP;
        }
        #region Load
        private void frmCongViecBT_Load(object sender, EventArgs e)
        {
            LoadCboNLCV();
            LoadCboNM();
            LoadData();
            LoadNN();
        }
        private void LoadData()
        {
            try
            {
                if (Com.Mod.sLoad == "0Load") return;
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 1));
                lPar.Add(new SqlParameter("@sDMuc", "mnuCongViecBT"));
                lPar.Add(new SqlParameter("@BIGINT1", cboID_LCV.EditValue));
                lPar.Add(new SqlParameter("@BIGINT2", cboID_NM.EditValue));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                lPar.Add(new SqlParameter("@iID", -1));

                DataTable dtTmp = new DataTable();
                dtTmp = VsMain.MGetDatatable(sPS, lPar);
                grvChung.OptionsMenu.EnableGroupRowMenu = true;
                if (grdChung.DataSource == null)
                {
                    Com.Mod.OS.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, false, false, false);
                }
                else
                    grdChung.DataSource = dtTmp;
            }
            catch (Exception ex)
            { Program.MBarThongTin(ex.Message.ToString(), true); }
        }
        private void LoadNN()
        {
            try
            {
                Com.Mod.OS.ThayDoiNN(this, dataLayoutControl1);
                Com.Mod.OS.MLoadNNXtraGrid(grvChung, this.Name, true);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        private void LoadCboNM()
        {
            try
            {
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iALL", "1"));
                lPar.Add(new SqlParameter("@iCoALL",-1));
                lPar.Add(new SqlParameter("@sALL", "< All >"));
                lPar.Add(new SqlParameter("@iID1", cboID_NM.Text == "" ? -1 : Convert.ToInt64(cboID_NM.EditValue)));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                lPar.Add(new SqlParameter("@sDanhMuc", "NHOM_MAY;"));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet("spGetDataCatalogs", lPar);
                DataTable dt = new DataTable();

                dt = ds.Tables[0].Copy();
                Com.Mod.OS.MLoadSearchLookUpEdit(cboID_NM, dt, "ID_NM", "TEN_NM", this.Name);
                cboID_NM.Properties.View.Columns["ID_NM"].Visible = false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        private void LoadCboNLCV()
        {
            try
            {
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iALL", "1"));
                lPar.Add(new SqlParameter("@iCoALL",-1));
                lPar.Add(new SqlParameter("@sALL", "< All >"));
                lPar.Add(new SqlParameter("@iID1", cboID_LCV.Text == "" ? -1 : Convert.ToInt64(cboID_LCV.EditValue)));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                lPar.Add(new SqlParameter("@sDanhMuc", "LOAI_CONG_VIEC;"));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet("spGetDataCatalogs", lPar);
                DataTable dt = new DataTable();

                dt = ds.Tables[0].Copy();
                Com.Mod.OS.MLoadSearchLookUpEdit(cboID_LCV, dt, "ID_LCV", "TEN_LCV", this.Name);
                cboID_LCV.Properties.View.Columns["ID_LCV"].Visible = false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        #endregion

        #region Event
        private Boolean KiemSuDung(Int64 iID, string dMuc)
        {
            Boolean bKiem = false;
            try
            {
                #region KiemTrung loai = 6
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 6));
                lPar.Add(new SqlParameter("@sDMuc", dMuc));
                lPar.Add(new SqlParameter("@iID", iID)); ;
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet(sPS, lPar);
                DataTable dtTmp = new DataTable();
                dtTmp = ds.Tables[0].Copy();
                int checkTrung = Convert.ToInt32(dtTmp.Rows[0]["ERR_CODE"].ToString());
                if (Convert.ToInt32(dtTmp.Rows[0]["ERR_CODE"].ToString()) == 1)
                {
                    XtraMessageBox.Show(dtTmp.Rows[0]["ERR_NAME"].ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                #endregion
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Com.Mod.sLoad == "0Load") return;
                if (iPQ != 1) return;
                frmEditCongViecBT frm = new frmEditCongViecBT(iPQ, null, true);
                Com.Mod.OS.LocationSizeForm(this, frm);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                    Program.MBarCapNhapThanhCong();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
                Program.MBarCapNhapKhongThanhCong();
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int ID_CV = Convert.ToInt32(grvChung.GetFocusedRowCellValue("ID_CV").ToString());
                string dMuc = "mnuCongViecBT";
                string sTB = "msgBanCoChacXoa";
                if (!KiemSuDung(ID_CV, dMuc)) return;
                if (XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", sTB), this.Text, MessageBoxButtons.YesNo) == DialogResult.No) return;
                #region Xoa
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iID", ID_CV));
                lPar.Add(new SqlParameter("@iLoai", 2));
                lPar.Add(new SqlParameter("@sDMuc",dMuc));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                Int32 bKiem = Convert.ToInt32(VsMain.MExecuteScalar("spDanhMuc01", lPar));
                if (bKiem == 1)
                {
                    XtraMessageBox.Show(Com.Mod.OS.GetLanguage(this.Name, "msgDelDangSuDung"), this.Text);
                    Program.MBarXoaThanhCong();
                }
                LoadData();
                #endregion
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgDelDangSuDung") + "\n" + ex.Message, this.Text);
                Program.MBarXoaKhongThanhCong();
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cboID_NM_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (Com.Mod.sLoad == "0Load") return;
                LoadData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        private void cboID_LCV_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (Com.Mod.sLoad == "0Load") return;
                LoadData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        private void grvChung_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int ID_CV = Convert.ToInt32(grvChung.GetFocusedRowCellValue("ID_CV").ToString());
                DataRow row = grvChung.GetDataRow(grvChung.FocusedRowHandle) as DataRow;
                frmEditCongViecBT frm = new frmEditCongViecBT(iPQ, row, false);
                Com.Mod.OS.LocationSizeForm(this, frm);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                    Program.MBarCapNhapThanhCong();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }

        }
        #endregion

    }
}
