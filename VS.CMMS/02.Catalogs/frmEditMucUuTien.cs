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
    public partial class frmEditMucUuTien : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = -1; // =1: full, <> 1: readonly
        static Boolean AddEdit = true;// true la add false la edit
        static DataRow drRow;
        static Int64 iID_MUT = -1;
        public frmEditMucUuTien(int PQ, DataRow row, Boolean bAddEdit)
        {
            InitializeComponent();

            iPQ = PQ;
            drRow = row;
            AddEdit = bAddEdit;
            VsMain.MFieldRequest(lblTEN_MUT);
            VsMain.MFieldRequest(lblTT_MUT);

            if(drRow != null)
            {
                try { iID_MUT = Convert.ToInt64(drRow["ID_MUT"].ToString()); } catch { iID_MUT = -1; }
            }
            else
            {
                iID_MUT = -1;
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
        private void frmEditMucUuTien_Load(object sender, EventArgs e)
        {
            try
            {
                if (!AddEdit) LoadText();
                LoadNN();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        private void LoadText()
        {
            try
            {
                txtTEN_MUT.Text = drRow["TEN_MUT"].ToString(); 
                txtTEN_MUT_A.Text = drRow["TEN_MUT_A"].ToString();
                txtTEN_MUT_H.Text = drRow["TEN_MUT_H"].ToString();
                txtGHI_CHU.Text = drRow["GHI_CHU"].ToString();
                txtSO_NGAY_BD.Text = drRow["SO_NGAY_BD"].ToString();
                txtSO_NGAY_KT.Text = drRow["SO_NGAY_KT"].ToString();
                txtGHI_CHU.Text = drRow["GHI_CHU"].ToString();
                txtTT_MUT.Text = drRow["TT_MUT"].ToString();
            }
            catch (Exception ex)
            {
                txtTEN_MUT.Text = ""; txtTEN_MUT_A.Text = ""; 
                txtTEN_MUT_H.Text = ""; txtTT_MUT.Text = "0"; txtGHI_CHU.Text = "";
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
                lPar.Add(new SqlParameter("@iID", iID_MUT));
                lPar.Add(new SqlParameter("@INT1", iKiem));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtTEN_MUT.Text));
                lPar.Add(new SqlParameter("@NVARCHAR2", txtTEN_MUT_A.Text));
                lPar.Add(new SqlParameter("@NVARCHAR3", txtTEN_MUT_H.Text));
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
                if(Convert.ToInt32(txtSO_NGAY_BD.EditValue) > Convert.ToInt32(txtSO_NGAY_KT.EditValue))
                {
                    XtraMessageBox.Show(Com.Mod.OS.GetLanguage(this.Text, "msgNgayKTLonHonNgayBD"), this.Text);
                    return;
                }
                //Kiểm trùng
                if (KiemTrung(1))
                {
                    XtraMessageBox.Show(lblTEN_MUT.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_MUT.Focus();
                    return;
                }
                if (KiemTrung(2))
                {
                    XtraMessageBox.Show(lblTEN_MUT_A.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_MUT_A.Focus();
                    return;
                }
                if (KiemTrung(3))
                {
                    XtraMessageBox.Show(lblTEN_MUT_H.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_MUT_H.Focus();
                    return;
                }
                #region Them Sua
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 3));
                lPar.Add(new SqlParameter("@sDMuc", this.Tag));
                lPar.Add(new SqlParameter("@iID", iID_MUT));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtTEN_MUT.Text));
                lPar.Add(new SqlParameter("@NVARCHAR2", txtTEN_MUT_A.Text));
                lPar.Add(new SqlParameter("@NVARCHAR3", txtTEN_MUT_H.Text));
                lPar.Add(new SqlParameter("@NVARCHAR4", txtGHI_CHU.Text));
                lPar.Add(new SqlParameter("@INT1", txtSO_NGAY_BD.EditValue));
                lPar.Add(new SqlParameter("@INT2", txtSO_NGAY_KT.EditValue));
                lPar.Add(new SqlParameter("@INT3", txtTT_MUT.EditValue));
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