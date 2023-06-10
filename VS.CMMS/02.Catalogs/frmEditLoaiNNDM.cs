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
    public partial class frmEditLoaiNNDM : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = -1; // =1: full, <> 1: readonly
        static Boolean AddEdit = true;// true la add false la edit
        static DataRow drRow;
        static Int64 iID_BPCP = -1;
        public frmEditLoaiNNDM(int PQ, DataRow row, Boolean bAddEdit)
        {
            InitializeComponent();

            iPQ = PQ;
            drRow = row;
            AddEdit = bAddEdit;
            VsMain.MFieldRequest(lblTEN_LOAI_NNDM);
            VsMain.MFieldRequest(lblTT_LNNDM);

            if(drRow != null)
            {
                try { iID_BPCP = Convert.ToInt64(drRow["ID_LOAI_NNDM"].ToString()); } catch { iID_BPCP = -1; }
            }
            else
            {
                iID_BPCP = -1;
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
        private void frmEditLoaiNNDM_Load(object sender, EventArgs e)
        {
            try
            {
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
                txtTEN_LOAI_NNDM.Text = drRow["TEN_LOAI_NNDM"].ToString(); 
                txtTEN_LOAI_NNDM_A.Text = drRow["TEN_LOAI_NNDM_A"].ToString();
                txtTEN_LOAI_NNDM_H.Text = drRow["TEN_LOAI_NNDM_H"].ToString();
                txtTT_LNNDM.Text = drRow["TT_LNNDM"].ToString();
                chkBAO_TRI.Checked = Convert.ToBoolean(drRow["BAO_TRI"].ToString());
                chkMAY_HONG.Checked = Convert.ToBoolean(drRow["MAY_HONG"].ToString());
                chkPLANNED.Checked = Convert.ToBoolean(drRow["PLANNED"].ToString());
            }
            catch (Exception ex)
            {
                txtTEN_LOAI_NNDM.Text = ""; txtTEN_LOAI_NNDM_A.Text = ""; 
                txtTEN_LOAI_NNDM_H.Text = ""; txtTT_LNNDM.Text = "0";
                chkBAO_TRI.Checked = false; chkMAY_HONG.Checked= false; chkPLANNED.Checked= false;
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
                lPar.Add(new SqlParameter("@iID", iID_BPCP)); ;
                lPar.Add(new SqlParameter("@INT1", iKiem));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtTEN_LOAI_NNDM.Text));
                lPar.Add(new SqlParameter("@NVARCHAR2", txtTEN_LOAI_NNDM_A.Text));
                lPar.Add(new SqlParameter("@NVARCHAR3", txtTEN_LOAI_NNDM_H.Text));
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
        private void btnGhi_Click(object sender, EventArgs e)
        {

            try
            {
                if (!dxValidationProvider1.Validate()) return;
                //Kiểm trùng
                if (KiemTrung(1))
                {
                    XtraMessageBox.Show(lblTEN_LOAI_NNDM.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_LOAI_NNDM.Focus();
                    return;
                }
                if (KiemTrung(2))
                {
                    XtraMessageBox.Show(lblTEN_LOAI_NNDM_A.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_LOAI_NNDM_A.Focus();
                    return;
                }
                if (KiemTrung(3))
                {
                    XtraMessageBox.Show(lblTEN_LOAI_NNDM_H.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_LOAI_NNDM_H.Focus();
                    return;
                }
                #region Them Sua
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 3));
                lPar.Add(new SqlParameter("@sDMuc", this.Tag));
                lPar.Add(new SqlParameter("@iID", iID_BPCP));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtTEN_LOAI_NNDM.Text));
                lPar.Add(new SqlParameter("@NVARCHAR2", txtTEN_LOAI_NNDM_A.Text));
                lPar.Add(new SqlParameter("@NVARCHAR3", txtTEN_LOAI_NNDM_H.Text));
                lPar.Add(new SqlParameter("@INT1", Convert.ToInt32(txtTT_LNNDM.Text)));
                lPar.Add(new SqlParameter("@BIT1", chkMAY_HONG.EditValue));
                lPar.Add(new SqlParameter("@BIT2", chkBAO_TRI.EditValue));
                lPar.Add(new SqlParameter("@BIT3", chkPLANNED.EditValue));
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