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
    public partial class frmEditCa : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = -1; // =1: full, <> 1: readonly
        static Boolean AddEdit = true;// true la add false la edit
        static DataRow drRow;
        static Int64 iID_CA = -1;
        public frmEditCa(int PQ, DataRow row, Boolean bAddEdit)
        {
            InitializeComponent();
            iPQ = PQ;
            drRow = row;
            AddEdit = bAddEdit;

            VsMain.MFieldRequest(lblTEN_CA);
            VsMain.MFieldRequest(lblTU_GIO);
            VsMain.MFieldRequest(lblDEN_GIO);


            if (drRow != null)
            {
                try { iID_CA = Convert.ToInt64(drRow["ID_CA"].ToString()); } catch { iID_CA = -1; }
            }
            else
            {
                iID_CA = -1;
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
        private void frmEditCa_Load(object sender, EventArgs e)
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
                    txtTENCA.Text = drRow["CA"].ToString();
                    txtTENCA_A.Text = drRow["CA_ANH"].ToString();
                    txtTENCA_H.Text = drRow["CA_HOA"].ToString();
                    txtTU_GIO.EditValue = drRow["TU_GIO"].ToString();
                    txtDEN_GIO.EditValue = drRow["DEN_GIO"].ToString();
                    chkCaDem.Checked = Convert.ToBoolean(drRow["CA_DEM"]);
                }
                else
                {
                    txtTENCA.Text = ""; 
                    txtTENCA_A.Text = "";
                    txtTENCA_H.Text = "";
                    chkCaDem.Checked = false;
                }
               
            }
            catch (Exception ex)
            {
                txtTENCA.Text = "";
                txtTENCA_A.Text = "";
                txtTENCA_H.Text = "";
                chkCaDem.Checked = false;
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
                lPar.Add(new SqlParameter("@iID",iID_CA));
                lPar.Add(new SqlParameter("@INT1", iKiem));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtTENCA.Text));
                lPar.Add(new SqlParameter("@NVARCHAR2", txtTENCA_A.Text));
                lPar.Add(new SqlParameter("@NVARCHAR3", txtTENCA_H.Text));
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
                if (KiemTrung(1))
                {
                    XtraMessageBox.Show(lblTEN_CA.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTENCA.Focus();
                    return;
                }
                #region Them Sua
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 3));
                lPar.Add(new SqlParameter("@sDMuc", this.Tag));
                lPar.Add(new SqlParameter("@iID", iID_CA));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtTENCA.Text));
                lPar.Add(new SqlParameter("@NVARCHAR2", txtTENCA_A.Text));
                lPar.Add(new SqlParameter("@NVARCHAR3", txtTENCA_H.Text));
                lPar.Add(new SqlParameter("@DATETIME1", Convert.ToDateTime("01/01/1900 "+ txtTU_GIO.Text)));
                lPar.Add(new SqlParameter("@DATETIME2", Convert.ToDateTime("01/01/1900 " + txtDEN_GIO.Text)));
                lPar.Add(new SqlParameter("@BIT1", chkCaDem.Checked));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
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