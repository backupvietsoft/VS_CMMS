using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.XtraPrinting.Native.ExportOptionsPropertiesNames;

namespace VS.CMMS
{ 
    public partial class frmEditNNDungMay : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = -1; // =1: full, <> 1: readonly
        static Boolean AddEdit = true;// true la add false la edit
        static DataRow drRow;
        static Int64 iID_NNDM = -1;
        public frmEditNNDungMay(int PQ, DataRow row, Boolean bAddEdit)
        {
            InitializeComponent();

            iPQ = PQ;
            drRow = row;
            AddEdit = bAddEdit;
            VsMain.MFieldRequest(lblTEN_NGUYEN_NHAN);
            VsMain.MFieldRequest(lblTT_LNNDM);
            VsMain.MFieldRequest(lblID_LOAI_NNDM);

            if (drRow != null)
            {
                try { iID_NNDM = Convert.ToInt64(drRow["ID_NNDM"].ToString()); } catch { iID_NNDM = -1; }
            }
            else
            {
                iID_NNDM = -1;
            }
            if (iPQ != 1)
            {
                lciGhi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else
            {
                lciGhi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }

        }
        #region Load
        public void LoadNN()
        {
            try
            {
                Com.Mod.OS.ThayDoiNN(this, dataLayoutControl1);
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        private void frmEditNNDungMay_Load(object sender, EventArgs e)
        {
            try
            {
                LoadCbo();
                LoadText();
                LoadNN();
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        private void LoadText()
        {
            try
            {
                txtTEN_NGUYEN_NHAN.Text = drRow["TEN_NGUYEN_NHAN"].ToString(); 
                txtTEN_NGUYEN_NHAN_ANH.Text = drRow["TEN_NGUYEN_NHAN_ANH"].ToString();
                txtTEN_NGUYEN_NHAN_HOA.Text = drRow["TEN_NGUYEN_NHAN_HOA"].ToString();
                txtTT_NNDM.Text = drRow["TT_NNDM"].ToString();
                txtKY_HIEU.Text = drRow["KY_HIEU"].ToString();
                cboID_LOAI_NNDM.EditValue = Convert.ToInt64(drRow["ID_LOAI_NNDM"]);
            }
            catch (Exception ex)
            {
                txtTEN_NGUYEN_NHAN.Text = ""; txtTEN_NGUYEN_NHAN_ANH.Text = ""; 
                txtTEN_NGUYEN_NHAN_HOA.Text = ""; txtTT_NNDM.Text = "0";cboID_LOAI_NNDM.EditValue = -1;txtKY_HIEU.Text = "";
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
                lPar.Add(new SqlParameter("@iLoai", 4));
                lPar.Add(new SqlParameter("@sDMuc", this.Tag));
                lPar.Add(new SqlParameter("@iID", iID_NNDM)); ;
                lPar.Add(new SqlParameter("@INT1", iKiem));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtTEN_NGUYEN_NHAN.Text));
                lPar.Add(new SqlParameter("@NVARCHAR2", txtTEN_NGUYEN_NHAN_ANH.Text));
                lPar.Add(new SqlParameter("@NVARCHAR3", txtTEN_NGUYEN_NHAN_HOA.Text));
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
        private void LoadCbo()
        {
            try
            {
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@sDMuc", this.Tag));
                lPar.Add(new SqlParameter("@iLoai", 5));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet("spDanhmuc", lPar);
                DataTable dt = new DataTable();
                dt = ds.Tables[0].Copy();
                Com.Mod.OS.MLoadSearchLookUpEdit(cboID_LOAI_NNDM, dt, "ID_LOAI_NNDM", "TEN_LOAI_NNDM", this.Name, true, false);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        #endregion

        #region Event
        private void btnGhi_Click(object sender, EventArgs e)
        {

            try
            {
                if (!dxValidationProvider1.Validate()) return;
                //Kiểm trùng
                if (KiemTrung(1))
                {
                    XtraMessageBox.Show(lblTEN_NGUYEN_NHAN.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_NGUYEN_NHAN.Focus();
                    return;
                }
                if (KiemTrung(2))
                {
                    XtraMessageBox.Show(lblTEN_NGUYEN_NHAN_ANH.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_NGUYEN_NHAN_ANH.Focus();
                    return;
                }
                if (KiemTrung(3))
                {
                    XtraMessageBox.Show(lblTEN_NGUYEN_NHAN_HOA.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_NGUYEN_NHAN_HOA.Focus();
                    return;
                }
                #region Them Sua
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 3));
                lPar.Add(new SqlParameter("@sDMuc", this.Tag));
                lPar.Add(new SqlParameter("@iID", iID_NNDM));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtTEN_NGUYEN_NHAN.Text));
                lPar.Add(new SqlParameter("@NVARCHAR2", txtTEN_NGUYEN_NHAN_ANH.Text));
                lPar.Add(new SqlParameter("@NVARCHAR3", txtTEN_NGUYEN_NHAN_HOA.Text));
                lPar.Add(new SqlParameter("@NVARCHAR4", txtKY_HIEU.Text));
                lPar.Add(new SqlParameter("@BIGINT1", cboID_LOAI_NNDM.EditValue));
                lPar.Add(new SqlParameter("@INT1", Convert.ToInt32(txtTT_NNDM.Text)));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                lPar.Add(new SqlParameter("@FullName", Com.Mod.sTenNhanVienMD));
                Com.Mod.sId = Convert.ToString(VsMain.MExecuteScalar("spDanhMuc", lPar));
                if (Com.Mod.sId =="-1")
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
        private void btnKhongGhi_Click(object sender, EventArgs e)
        {
            Com.Mod.sId = "";
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion
    }
}