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
using System.Windows.Media;
using static DevExpress.XtraPrinting.Native.ExportOptionsPropertiesNames;

namespace VS.CMMS
{ 
    public partial class frmEditLoaiCV : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = -1; // =1: full, <> 1: readonly
        static Boolean AddEdit = true;// true la add false la edit
        static DataRow drRow;
        static Int64 iID_LCV = -1;
        public frmEditLoaiCV(int PQ, DataRow row, Boolean bAddEdit)
        {
            InitializeComponent();

            iPQ = PQ;
            drRow = row;
            AddEdit = bAddEdit;
            VsMain.MFieldRequest(lblTEN_LCV);

            if(drRow != null)
            {
                try { iID_LCV = Convert.ToInt64(drRow["ID_LCV"].ToString()); } catch { iID_LCV = -1; }
            }
            else
            {
                iID_LCV = -1;
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
        private void frmEditLoaiCV_Load(object sender, EventArgs e)
        {
            try
            {
                if (!AddEdit) LoadText();
                LoadNN();
            }
            catch(Exception ex) { XtraMessageBox.Show(ex.Message, this.Text); }
        }
        private void LoadText()
        {
            try
            {
                txtTEN_LCV.Text = drRow["TEN_LCV"].ToString();
                txtTEN_LCV_A.Text = drRow["TEN_LCV_A"].ToString();
                txtTEN_LCV_H.Text = drRow["TEN_LCV_H"].ToString();
                if (Convert.ToInt32(drRow["TT_LCV"]) == 999)
                {
                    txtSTT.Text = "";
                }
                else
                {
                    txtSTT.Text = drRow["TT_LCV"].ToString();
                }    
                
                txtMAU_LCV.Text = drRow["MAU_LCV"].ToString();
                txtMAU_LCV.BackColor = ColorTranslator.FromHtml(drRow["MAU_LCV"].ToString());
            }
            catch (Exception ex)
            {
                txtTEN_LCV.Text = ""; txtTEN_LCV_A.Text = ""; 
                txtTEN_LCV_H.Text = ""; txtSTT.Text = "0";txtMAU_LCV.Text = "";
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
                lPar.Add(new SqlParameter("@iID", iID_LCV)); ;
                lPar.Add(new SqlParameter("@INT1", iKiem));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtTEN_LCV.Text));
                lPar.Add(new SqlParameter("@NVARCHAR2", txtTEN_LCV_A.Text));
                lPar.Add(new SqlParameter("@NVARCHAR3", txtTEN_LCV_H.Text));
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
                if (KiemTrung(1) && txtTEN_LCV.Text != "")
                {
                    XtraMessageBox.Show(lblTEN_LCV.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_LCV.Focus();
                    return;
                }
                if (KiemTrung(2) && txtTEN_LCV_A.Text != "")
                {
                    XtraMessageBox.Show(lblTEN_LCV_A.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_LCV_A.Focus();
                    return;
                }
                if (KiemTrung(3) && txtTEN_LCV_H.Text != "")
                {
                    XtraMessageBox.Show(lblTEN_LCV_H.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_LCV_H.Focus();
                    return;
                }
                System.Drawing.Color color = (System.Drawing.Color)txtMAU_LCV.EditValue;
                #region Them Sua
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 3));
                lPar.Add(new SqlParameter("@sDMuc", this.Tag));
                lPar.Add(new SqlParameter("@iID", iID_LCV));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtTEN_LCV.Text));
                lPar.Add(new SqlParameter("@NVARCHAR2", txtTEN_LCV_A.Text));
                lPar.Add(new SqlParameter("@NVARCHAR3", txtTEN_LCV_H.Text));
                lPar.Add(new SqlParameter("@NVARCHAR4", Convert.ToString("#" + color.ToArgb().ToString("X6"))));
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
        private void txtMAU_LCV_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtMAU_LCV.BackColor = ColorTranslator.FromHtml(Convert.ToString(txtMAU_LCV.Text));

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        #endregion

    }
}