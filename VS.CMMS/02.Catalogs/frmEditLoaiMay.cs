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
    public partial class frmEditLoaiMay : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = -1; // = 1: full, <> 1: readonly
        static Boolean AddEdit = true;// true là add false là edit
        static DataRow drRow;
        static Int64 iID_LM = -1;
        public frmEditLoaiMay(int PQ, DataRow row, Boolean bAddEdit)
        {
            InitializeComponent();

            iPQ = PQ;
            drRow = row;
            AddEdit = bAddEdit;
            VsMain.MFieldRequest(lblMS_LM);
            VsMain.MFieldRequest(lblTEN_LM);
            VsMain.MFieldRequest(lblID_NM);

            if (drRow != null)
            {
                try { iID_LM = Convert.ToInt64(drRow["ID_LM"].ToString()); } catch { iID_LM = -1; }
            }
            else
            {
                iID_LM = -1;
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
        private void frmEditLoaiMay_Load(object sender, EventArgs e)
        {
            try
            {
                LoadCbo();
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
                txtMS_LM.Text = drRow["MS_LM"].ToString();
                txtTEN_LM.Text = drRow["TEN_LM"].ToString(); 
                txtTEN_LM_A.Text = drRow["TEN_LM_A"].ToString();
                txtTEN_LM_H.Text = drRow["TEN_LM_H"].ToString();
                txtSTT_LM.Text = drRow["TT_LM"].ToString();
                cboID_NM.EditValue = drRow["ID_NM"].ToString() == "" ? -1 : Convert.ToInt64(drRow["ID_NM"].ToString());
            }
            catch (Exception ex)
            {
                txtMS_LM.Text = ""; txtTEN_LM.Text = ""; txtTEN_LM_A.Text = ""; 
                txtTEN_LM_H.Text = ""; txtSTT_LM.Text = "0"; txtGHI_CHU.Text = ""; cboID_NM.EditValue = -1;
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
                lPar.Add(new SqlParameter("@iID", iID_LM)); ;
                lPar.Add(new SqlParameter("@INT1", iKiem));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtMS_LM.Text));
                lPar.Add(new SqlParameter("@NVARCHAR2", txtTEN_LM.Text));
                lPar.Add(new SqlParameter("@NVARCHAR3", txtTEN_LM_A.Text));
                lPar.Add(new SqlParameter("@NVARCHAR4", txtTEN_LM_H.Text));
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
                lPar.Add(new SqlParameter("@iID", iID_LM));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet("spDanhmuc", lPar);
                DataTable dt = new DataTable();
                dt = ds.Tables[0].Copy();
                Com.Mod.OS.MLoadSearchLookUpEdit(cboID_NM, dt, "ID_NM", "TEN_NM", this.Name, true, false);
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
                if (KiemTrung(1) && txtMS_LM.Text != "")
                {
                    XtraMessageBox.Show(lblMS_LM.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtMS_LM.Focus();
                    return;
                }

                if (KiemTrung(2) && txtTEN_LM.Text != "")
                {
                    XtraMessageBox.Show(lblTEN_LM.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_LM.Focus();
                    return;
                }

                if (KiemTrung(3) && txtTEN_LM_A.Text != "")
                {
                    XtraMessageBox.Show(lblTEN_LM_A.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_LM_A.Focus();
                    return;
                }

                if (KiemTrung(4) && txtTEN_LM_H.Text != "")
                {
                    XtraMessageBox.Show(lblTEN_LM_H.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_LM_H.Focus();
                    return;
                }
                #region Them Sua
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 3));
                lPar.Add(new SqlParameter("@sDMuc", this.Tag));
                lPar.Add(new SqlParameter("@iID", iID_LM));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtMS_LM.Text));
                lPar.Add(new SqlParameter("@NVARCHAR2", txtTEN_LM.Text));
                lPar.Add(new SqlParameter("@NVARCHAR3", txtTEN_LM_A.Text));
                lPar.Add(new SqlParameter("@NVARCHAR4", txtTEN_LM_H.Text));
                lPar.Add(new SqlParameter("@NVARCHAR5", txtGHI_CHU.Text));
                lPar.Add(new SqlParameter("@BIGINT1", cboID_NM.EditValue));
                lPar.Add(new SqlParameter("@INT1", Convert.ToInt32(txtSTT_LM.Text)));
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