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
    public partial class frmEditDonVi : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = -1; // =1: full, <> 1: readonly
        static Boolean AddEdit = true;// true la add false la edit
        static DataRow drRow;
        static Int64 iID_DV= -1;
        public frmEditDonVi(int PQ, DataRow row, Boolean bAddEdit)
        {
            InitializeComponent();

            iPQ = PQ;
            drRow = row;
            AddEdit = bAddEdit;
            VsMain.MFieldRequest(lblMS_DV);
            VsMain.MFieldRequest(lblSTT);
            VsMain.MFieldRequest(lblTEN_DV);
            if (drRow != null)
            {
                try { iID_DV = Convert.ToInt64(drRow["ID_DV"].ToString()); } catch { iID_DV = -1; }
            }
            else
            {
                iID_DV = -1;
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
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        private void frmEditDonVi_Load(object sender, EventArgs e)
        {
            try
            {
                if (!AddEdit) LoadText();
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
                txtMS_DV.Text = drRow["MS_DV"].ToString(); 
                txtTEN_DV.Text = drRow["TEN_DV"].ToString();
                txtTEN_DV_A.Text = drRow["TEN_DV_A"].ToString();
                txtTEN_DV_H.Text = drRow["TEN_DV_H"].ToString();
                txtTEN_NGAN.Text = drRow["TEN_NGAN"].ToString();
                txtTEN_RUT_GON.Text = drRow["TEN_RUT_GON"].ToString();
                txtDIEN_THOAI.Text = drRow["DIEN_THOAI"].ToString();
                txtDIA_CHI.Text = drRow["DIA_CHI"].ToString();
                txtFAX.Text = drRow["FAX"].ToString();
                txtSTT.Text = drRow["TT_DV"].ToString();
                chkTHUE_NGOAI.EditValue = drRow["THUE_NGOAI"];
                chkMAC_DINH.EditValue = drRow["MAC_DINH"];

            }
            catch (Exception ex)
            {
                txtMS_DV.Text = "";txtTEN_DV.Text = "";txtTEN_DV_A.Text = "";txtTEN_DV_H.Text = "";txtTEN_NGAN.Text = "";txtTEN_RUT_GON.Text = "";txtDIEN_THOAI.Text = "";
                txtDIA_CHI.Text = "";txtFAX.Text = "";txtSTT.Text = "";chkTHUE_NGOAI.EditValue = false;chkMAC_DINH.EditValue = false;
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
                lPar.Add(new SqlParameter("@iLoai", 4));
                lPar.Add(new SqlParameter("@sDMuc", this.Tag));
                lPar.Add(new SqlParameter("@iID", iID_DV)); ;
                lPar.Add(new SqlParameter("@INT1", iKiem));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtTEN_DV.Text));
                lPar.Add(new SqlParameter("@NVARCHAR2", txtMS_DV.Text));
                lPar.Add(new SqlParameter("@NVARCHAR3", txtTEN_DV_A.Text));
                lPar.Add(new SqlParameter("@NVARCHAR4", txtTEN_DV_H.Text));
                lPar.Add(new SqlParameter("@NVARCHAR5", txtTEN_RUT_GON.Text));
                lPar.Add(new SqlParameter("@NVARCHAR6", txtTEN_NGAN.Text));
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
                if (KiemTrung(2) && txtMS_DV.Text != "")
                {
                    XtraMessageBox.Show(lblMS_DV.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtMS_DV.Focus();
                    return;
                }
                if (KiemTrung(1) && txtTEN_DV.Text != "")
                {
                    XtraMessageBox.Show(lblTEN_DV.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_DV.Focus();
                    return;
                }
                if (KiemTrung(3) && txtTEN_DV_A.Text != "")
                {
                    XtraMessageBox.Show(lblTEN_DV_A.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_DV_H.Focus();
                    return;
                }
                if (KiemTrung(4) && txtTEN_DV_H.Text != "")
                {
                    XtraMessageBox.Show(lblTEN_DV_H.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_DV_H.Focus();
                    return;
                }
                if (KiemTrung(5) && txtTEN_RUT_GON.Text != "")
                {
                    XtraMessageBox.Show(lblTEN_RUT_GON.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_RUT_GON.Focus();
                    return;
                }
                if (KiemTrung(6) && txtTEN_NGAN.Text != "")
                {
                    XtraMessageBox.Show(lblTEN_NGAN.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_NGAN.Focus();
                    return;
                }
                #region Them Sua
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 3));
                lPar.Add(new SqlParameter("@sDMuc", this.Tag));
                lPar.Add(new SqlParameter("@iID", iID_DV));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtMS_DV.Text));
                lPar.Add(new SqlParameter("@NVARCHAR2", txtTEN_DV.Text));
                lPar.Add(new SqlParameter("@NVARCHAR3", txtTEN_DV_A.Text));
                lPar.Add(new SqlParameter("@NVARCHAR4", txtTEN_DV_H.Text));
                lPar.Add(new SqlParameter("@NVARCHAR5", txtTEN_NGAN.Text));
                lPar.Add(new SqlParameter("@NVARCHAR6", txtDIA_CHI.Text));
                lPar.Add(new SqlParameter("@NVARCHAR7", txtDIEN_THOAI.Text));
                lPar.Add(new SqlParameter("@NVARCHAR8", txtFAX.Text));
                lPar.Add(new SqlParameter("@NVARCHAR9", txtTEN_RUT_GON.Text));
                lPar.Add(new SqlParameter("@BIT1", chkTHUE_NGOAI.EditValue));
                lPar.Add(new SqlParameter("@BIT2", chkMAC_DINH.EditValue));
                lPar.Add(new SqlParameter("@INT1", Convert.ToInt32(txtSTT.Text)));
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