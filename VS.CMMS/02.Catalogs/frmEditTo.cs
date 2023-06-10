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
    public partial class frmEditTo : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = -1; // =1: full, <> 1: readonly
        static Boolean AddEdit = true;// true la add false la edit
        static DataRow drRow;
        static Int64 iID_TO = -1;
        public frmEditTo(int PQ, DataRow row, Boolean bAddEdit)
        {
            InitializeComponent();
            iPQ = PQ;
            drRow = row;
            AddEdit = bAddEdit;

            VsMain.MFieldRequest(lblTEN_TO);
            VsMain.MFieldRequest(lblID_PB);
            VsMain.MFieldRequest(lblSTT);

            if (drRow != null)
            {
                try { iID_TO = Convert.ToInt64(drRow["ID_TO"].ToString()); } catch { iID_TO = -1; }
            }
            else
            {
                iID_TO = -1;
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
        private void frmEditTo_Load(object sender, EventArgs e)
        {
            try
            {
                LoadCbo();
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
                    cboID_PB.EditValue = drRow["ID_PB"].ToString() == "" ? -1 : Convert.ToInt64(drRow["ID_PB"].ToString());
                    txtTEN_TO.Text = drRow["TEN_TO"].ToString();
                    txtTEN_TO_A.Text = drRow["TEN_TO_A"].ToString();
                    txtTEN_TO_H.Text = drRow["TEN_TO_H"].ToString();
                    txtSTT.Text = drRow["TT_TO"].ToString();

                }
                else
                {
                    txtTEN_TO.Text = ""; txtTEN_TO_A.Text = "";
                    txtTEN_TO_H.Text = "";  cboID_PB.EditValue = -1;txtSTT.Text = "";
                }
               
            }
            catch (Exception ex)
            {
                txtTEN_TO.Text = ""; txtTEN_TO.Text = ""; txtTEN_TO_A.Text = ""; 
                txtTEN_TO_H.Text = "";  cboID_PB.EditValue = -1 ;
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        private void LoadCbo()
        {
            try
            {
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@sDMuc", this.Tag));
                lPar.Add(new SqlParameter("@iLoai", 5));
                lPar.Add(new SqlParameter("@iID", iID_TO));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet("spDanhmuc", lPar);
                DataTable dt = new DataTable();
                dt = ds.Tables[0].Copy();
                Com.Mod.OS.MLoadSearchLookUpEdit(cboID_PB, dt, "ID_PB", "TEN_PB", this.Name, true, false);
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
                lPar.Add(new SqlParameter("@iID", cboID_PB.EditValue));
                lPar.Add(new SqlParameter("@BIGINT1", iID_TO));
                lPar.Add(new SqlParameter("@INT1", iKiem));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtTEN_TO.Text));
                lPar.Add(new SqlParameter("@NVARCHAR2", txtTEN_TO_A.Text));
                lPar.Add(new SqlParameter("@NVARCHAR3", txtTEN_TO_H.Text));
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
                ///  Kiểm trùng
                if (KiemTrung(1) && txtTEN_TO.Text != "")
                {
                    XtraMessageBox.Show(lblTEN_TO.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_TO.Focus();
                    return;
                }
                if (KiemTrung(2) && txtTEN_TO_A.Text != "")
                {
                    XtraMessageBox.Show(lblTEN_TO_A.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_TO_A.Focus();
                    return;
                }
                if (KiemTrung(3) && txtTEN_TO_H.Text != "")
                {
                    XtraMessageBox.Show(lblTEN_TO_H.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_TO_H.Focus();
                    return;
                }
                #region Them Sua
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 3));
                lPar.Add(new SqlParameter("@sDMuc", this.Tag));
                lPar.Add(new SqlParameter("@iID", iID_TO));
                lPar.Add(new SqlParameter("@BIGINT1", Convert.ToInt64(cboID_PB.EditValue)));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtTEN_TO.Text));
                lPar.Add(new SqlParameter("@NVARCHAR2", txtTEN_TO_A.Text));
                lPar.Add(new SqlParameter("@NVARCHAR3", txtTEN_TO_H.Text));
                lPar.Add(new SqlParameter("@INT1", txtSTT.Text));
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