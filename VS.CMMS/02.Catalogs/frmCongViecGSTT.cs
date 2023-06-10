using DevExpress.XtraEditors;
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

namespace VS.CMMS
{
    public partial class frmCongViecGSTT : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = 1;
        private Color _highlightColor;
        string sPS = "";
        public frmCongViecGSTT(int PQ, string Find, string SP)
        {
            InitializeComponent();
            iPQ = PQ;
            sPS = SP;
            optActive.SelectedIndex = 0;
        }

        #region Load
        private void frmCongViecGSTT_Load(object sender, EventArgs e)
        {
            LoadCboBPGSTT();
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
                lPar.Add(new SqlParameter("@sDMuc", "mnuCongViecGSTT"));
                if(optActive.SelectedIndex == 1)
                {
                    lPar.Add(new SqlParameter("@INT1", 1));
                }else if(optActive.SelectedIndex == 2)
                {
                    lPar.Add(new SqlParameter("@INT1", Convert.ToInt32(0)));
                }else
                {
                    lPar.Add(new SqlParameter("@INT1", -1));
                }
                lPar.Add(new SqlParameter("@iID", cboID_BP_GSTT.EditValue));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
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
        private void LoadCboBPGSTT()
        {
            try
            {
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iALL", "1"));
                lPar.Add(new SqlParameter("@iCoALL", -1));
                lPar.Add(new SqlParameter("@sALL", "<All>"));
                lPar.Add(new SqlParameter("@iID1", cboID_BP_GSTT.Text == "" ? -1 : Convert.ToInt64(cboID_BP_GSTT.EditValue)));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                lPar.Add(new SqlParameter("@sDanhMuc", "BO_PHAN_GSTT;"));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet("spGetDataCatalogs", lPar);
                DataTable dt = new DataTable();

                dt = ds.Tables[0].Copy();
                Com.Mod.OS.MLoadSearchLookUpEdit(cboID_BP_GSTT, dt, "ID_BP_GSTT", "TEN_BO_PHAN", this.Name);
                cboID_BP_GSTT.Properties.View.Columns["ID_BP_GSTT"].Visible = false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        #endregion

        #region Event
        private void cboID_BP_GSTT_EditValueChanged(object sender, EventArgs e)
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
        private void optActive_SelectedIndexChanged(object sender, EventArgs e)
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
        private void grdChung_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int ID_GSTT = Convert.ToInt32(grvChung.GetFocusedRowCellValue("ID_GSTT").ToString());
                DataRow row = grvChung.GetDataRow(grvChung.FocusedRowHandle) as DataRow;
                frmEditCongViecGSTT frm = new frmEditCongViecGSTT(iPQ, row, false);
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Com.Mod.sLoad == "0Load") return;
                if (iPQ != 1) return;
                frmEditCongViecGSTT frm = new frmEditCongViecGSTT(iPQ, null, true);
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
    }
}
