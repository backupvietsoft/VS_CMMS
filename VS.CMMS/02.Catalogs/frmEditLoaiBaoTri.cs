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
    public partial class frmEditLoaiBaoTri : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = -1; // =1: full, <> 1: readonly
        static Boolean AddEdit = true;// true la add false la edit
        static DataRow drRow;
        static Int64 iID_LBT = -1;
        public frmEditLoaiBaoTri(int PQ, DataRow row, Boolean bAddEdit)
        {
            InitializeComponent();
            iPQ = PQ;
            drRow = row;
            AddEdit = bAddEdit;

            VsMain.MFieldRequest(lblTEN_LOAI_BT);

            if (drRow != null)
            {
                try { iID_LBT = Convert.ToInt64(drRow["ID_LOAI_BT"].ToString()); } catch { iID_LBT = -1; }
            }
            else
            {
                iID_LBT = -1;
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
            catch (Exception ex) { XtraMessageBox.Show(ex.Message, this.Text); }
        }
        private void frmEditLoaiBaoTri_Load(object sender, EventArgs e)
        {
            try
            {
                LoadText();
                LoadNN();
            }
            catch(Exception ex ) { XtraMessageBox.Show(ex.Message, this.Text); }
        }
        private void LoadText()
        {
            try
            {
                if (!AddEdit)
                {
                    txtTEN_LOAI_BT.Text = drRow["TEN_LOAI_BT"].ToString();
                    txtTEN_LOAI_BT_A.Text = drRow["TEN_LOAI_BT_A"].ToString();
                    txtTEN_LOAI_BT_H.Text = drRow["TEN_LOAI_BT_H"].ToString();
                    txtGHI_CHU.Text = drRow["GHI_CHU"].ToString();
                    txtSTT.Text = drRow["TT_LOAI_BT"].ToString();
                    txtHU_HONG.EditValue = drRow["HU_HONG"];
                }
                else
                {
                    txtTEN_LOAI_BT.Text = ""; txtTEN_LOAI_BT_A.Text = ""; txtTEN_LOAI_BT_H.Text = "";
                    txtGHI_CHU.Text = ""; txtSTT.Text = ""; txtHU_HONG.Text = "";
                }
               
            }
            catch (Exception ex)
            {
                txtTEN_LOAI_BT.Text = ""; txtTEN_LOAI_BT_A.Text = ""; txtTEN_LOAI_BT_H.Text = "";
                txtGHI_CHU.Text = ""; txtSTT.Text = ""; txtHU_HONG.Text = "";
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
                lPar.Add(new SqlParameter("@iID", iID_LBT));
                lPar.Add(new SqlParameter("@INT1", iKiem));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtTEN_LOAI_BT.Text));
                lPar.Add(new SqlParameter("@NVARCHAR2", txtTEN_LOAI_BT_A.Text));
                lPar.Add(new SqlParameter("@NVARCHAR3", txtTEN_LOAI_BT_H.Text));
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
                if (KiemTrung(1) && txtTEN_LOAI_BT.Text != "")
                {
                    XtraMessageBox.Show(lblTEN_LOAI_BT.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_LOAI_BT.Focus();
                    return;
                }
                if (KiemTrung(2) && txtTEN_LOAI_BT_A.Text != "" )
                {
                    XtraMessageBox.Show(lblTEN_LOAI_BT_A.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_LOAI_BT_A.Focus();
                    return;
                }
                if (KiemTrung(3) && txtTEN_LOAI_BT_H.Text != "")
                {
                    XtraMessageBox.Show(lblTEN_LOAI_BT_H.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_LOAI_BT_H.Focus();
                    return;
                }
                #region Them Sua
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 3));
                lPar.Add(new SqlParameter("@sDMuc", this.Tag));
                lPar.Add(new SqlParameter("@iID", iID_LBT));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtTEN_LOAI_BT.Text));
                lPar.Add(new SqlParameter("@NVARCHAR2", txtTEN_LOAI_BT_A.Text));
                lPar.Add(new SqlParameter("@NVARCHAR3", txtTEN_LOAI_BT_H.Text));
                lPar.Add(new SqlParameter("@NVARCHAR4", txtGHI_CHU.Text));
                lPar.Add(new SqlParameter("@INT1", txtSTT.Text));
                lPar.Add(new SqlParameter("@INT2",  txtHU_HONG.Text));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                lPar.Add(new SqlParameter("@FullName", Com.Mod.sTenNhanVienMD )); 
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