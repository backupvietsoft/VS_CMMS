using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Reflection;
using System.Data.SqlClient;

namespace VS.CMMS
{
    public partial class frmEditNhaCungCap : DevExpress.XtraEditors.XtraForm
    {
        static Boolean AddEdit;// True la add, false la edit
        static DataRow drRow;
        static Int64 iIDNCC= -1; 
        public frmEditNhaCungCap(int PQ, DataRow row, Boolean bAddEdit)
        {
            InitializeComponent();
            VsMain.MFieldRequest(lblTEN_NCC);

            drRow = row;
            AddEdit = bAddEdit;
            try
            {
                if (drRow == null)
                    iIDNCC = -1;
                else
                    iIDNCC = Int64.Parse(drRow["ID_NCC"].ToString());
            }
            catch { iIDNCC = -1; }
        }

        #region Load
        private void frmEditNhaCungCap_Load(object sender, EventArgs e)
        {
            LoadCbo();
            if (!AddEdit) LoadText();
            LoadNN();
        }
        private void LoadNN()
        {
            Com.Mod.OS.ThayDoiNN(this, Root);
        }
        private void LoadText()
        {
            try
            {
                txtTEN_NCC.Text = drRow["TEN_NCC"].ToString();
                txtTEN_NCC_NGAN.Text = drRow["TEN_NCC_NGAN"].ToString();
                txtGIAM_DOC.Text = drRow["GIAM_DOC"].ToString();
                txtDIA_CHI.Text = drRow["DIA_CHI"].ToString();
                txtDIEN_THOAI.Text = drRow["DIEN_THOAI"].ToString();
                txtFAX.Text = drRow["FAX"].ToString();
                txtEMAIL.Text = drRow["EMAIL"].ToString();
                txtSO_TAI_KHOAN.Text = drRow["SO_TAI_KHOAN"].ToString();
                txtTEN_NGAN_HANG.Text = drRow["SO_TAI_KHOAN"].ToString();
                txtDIA_CHI_NGAN_HANG.Text = drRow["DIA_CHI_NGAN_HANG"].ToString();
                txtMS_THUE.Text = drRow["MS_THUE"].ToString();
                 cboID_QG.EditValue = drRow["ID_QG"].ToString() == "" ? - 1 : Convert.ToInt64(drRow["ID_QG"].ToString());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        private void LoadCbo()
        {
            try
            {
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@sDMuc", "mnuNhaCungCap"));
                lPar.Add(new SqlParameter("@iLoai", 5));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet("spDanhmuc", lPar);
                DataTable dt = new DataTable();
                dt = ds.Tables[0].Copy();
                Com.Mod.OS.MLoadSearchLookUpEdit(cboID_QG, dt, "ID_QG", "TEN_QG", this.Name, true, false);
                DataTable dt1 = new DataTable();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }

        #endregion

        #region Funtion
        private Boolean KiemTrung(int iKiem)
        {
            Boolean bKiem = false;
            try
            {
                #region KiemTrung loai = 4
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@sDMuc", "mnuNhacungCap"));
                lPar.Add(new SqlParameter("@iLoai", 4));
                lPar.Add(new SqlParameter("@iID", iIDNCC));
                lPar.Add(new SqlParameter("@INT1", iKiem));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtTEN_NCC.Text));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                bKiem = Convert.ToBoolean(VsMain.MExecuteScalar("spDanhMuc", lPar));
                #endregion
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return bKiem;
        }

        #endregion

        #region Event
        private void btnKhong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnGhi_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dxValidationProvider1.Validate()) return;
                if (KiemTrung(1))
                {
                    XtraMessageBox.Show(lblTEN_NCC.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_NCC.Focus();
                    return;
                }
                #region Thêm sửa
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 3));
                lPar.Add(new SqlParameter("@sDMuc", "mnuNhaCungCap"));
                lPar.Add(new SqlParameter("@iID", iIDNCC));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtTEN_NCC.Text));
                lPar.Add(new SqlParameter("@NVARCHAR2", txtTEN_NCC_NGAN.Text));
                lPar.Add(new SqlParameter("@NVARCHAR3", txtGIAM_DOC.Text));
                lPar.Add(new SqlParameter("@NVARCHAR4", txtDIA_CHI.Text));
                lPar.Add(new SqlParameter("@NVARCHAR5", txtDIEN_THOAI.Text));
                lPar.Add(new SqlParameter("@NVARCHAR6", txtFAX.Text));
                lPar.Add(new SqlParameter("@NVARCHAR7", txtEMAIL.Text));
                lPar.Add(new SqlParameter("@NVARCHAR8", txtSO_TAI_KHOAN.Text));
                lPar.Add(new SqlParameter("@NVARCHAR9", txtTEN_NGAN_HANG.Text));
                lPar.Add(new SqlParameter("@NVARCHAR10", txtDIA_CHI_NGAN_HANG.Text));
                lPar.Add(new SqlParameter("@NVARCHAR11", txtMS_THUE.Text));
                lPar.Add(new SqlParameter("@BIGINT1", cboID_QG.Text == ""? null :cboID_QG.EditValue ));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                lPar.Add(new SqlParameter("@FullName", Com.Mod.sTenNhanVienMD));

                Com.Mod.sId = Convert.ToString(VsMain.MExecuteScalar("spDanhMuc", lPar));
                if (Com.Mod.sId == "-1")
                {
                    XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgThemSuaKhongThanhCong"), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
                #endregion
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion
    }
}