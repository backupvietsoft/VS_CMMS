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
    public partial class frmEditNhomMay : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = -1; // =1: full, <> 1: readonly
        static Boolean AddEdit = true;// true la add false la edit
        static DataRow drRow;
        static Int64 iID_NM = -1;
        public frmEditNhomMay(int PQ, DataRow row, Boolean bAddEdit)
        {
            InitializeComponent();
            iPQ = PQ;
            drRow = row;
            AddEdit = bAddEdit;

            VsMain.MFieldRequest(lblMS_NM);
            VsMain.MFieldRequest(lblTEN_NM);

            if(drRow != null)
            {
                try { iID_NM = Convert.ToInt64(drRow["ID_NM"].ToString()); } catch { iID_NM = -1; }
            }
            else
            {
                iID_NM = -1;
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
        private void frmEditNhomMay_Load(object sender, EventArgs e)
        {
            try
            {
                LoadText();
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
                if (!AddEdit)
                {
                    txtMS_NM.Text = drRow["MS_NM"].ToString();
                    txtTEN_NM.Text = drRow["TEN_NM"].ToString();
                    txtTEN_NM_A.Text = drRow["TEN_NM_A"].ToString();
                    txtTEN_NM_H.Text = drRow["TEN_NM_H"].ToString();
                    txtGHI_CHU.Text = drRow["GHI_CHU"].ToString();

                }
                else
                {
                    txtMS_NM.Text = ""; txtTEN_NM.Text = ""; txtTEN_NM_A.Text = "";
                    txtTEN_NM_H.Text = ""; txtGHI_CHU.Text = ""; 
                }
               
            }
            catch (Exception ex)
            {
                txtMS_NM.Text = ""; txtTEN_NM.Text = ""; txtTEN_NM_A.Text = ""; 
                txtTEN_NM_H.Text = ""; txtGHI_CHU.Text = ""; 
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
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
        #endregion

        #region Funtion
        private Boolean KiemTrung(int iKiem)
        {
            Boolean bKiem = false;
            try
            {
                #region KiemTrung loai = 4
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@sDMuc", this.Tag));
                lPar.Add(new SqlParameter("@iLoai", 4));
                lPar.Add(new SqlParameter("@iID", iID_NM));
                lPar.Add(new SqlParameter("@INT1", iKiem));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtMS_NM.Text));
                lPar.Add(new SqlParameter("@NVARCHAR2", txtTEN_NM.Text));
                lPar.Add(new SqlParameter("@NVARCHAR3", txtTEN_NM_A.Text));
                lPar.Add(new SqlParameter("@NVARCHAR4", txtTEN_NM_H.Text));
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
                if (KiemTrung(1) && txtMS_NM.Text != "")
                {
                    XtraMessageBox.Show(lblMS_NM.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtMS_NM.Focus();
                    return;
                }
                if (KiemTrung(2) && txtTEN_NM.Text != "")
                {
                    XtraMessageBox.Show(lblTEN_NM.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_NM.Focus();
                    return;
                }
                if (KiemTrung(3) && txtTEN_NM_A.Text != "")
                {
                    XtraMessageBox.Show(lblTEN_NM_A.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_NM_A.Focus();
                    return;
                }
                if (KiemTrung(4) && txtTEN_NM_H.Text != "")
                {
                    XtraMessageBox.Show(lblTEN_NM_H.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_NM_H.Focus();
                    return;
                }
                #region Them Sua
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 3));
                lPar.Add(new SqlParameter("@sDMuc", this.Tag));
                lPar.Add(new SqlParameter("@iID", iID_NM));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtMS_NM.Text));
                lPar.Add(new SqlParameter("@NVARCHAR2", txtTEN_NM.Text));
                lPar.Add(new SqlParameter("@NVARCHAR3", txtTEN_NM_A.Text));
                lPar.Add(new SqlParameter("@NVARCHAR4", txtTEN_NM_H.Text));
                lPar.Add(new SqlParameter("@NVARCHAR5", txtGHI_CHU.Text));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                lPar.Add(new SqlParameter("@FullName", Com.Mod.sTenNhanVienMD )); ;
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