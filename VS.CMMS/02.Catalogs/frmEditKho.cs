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
    public partial class frmEditKho : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = -1; // =1: full, <> 1: readonly
        static Boolean AddEdit = true;// true la add false la edit
        static DataRow drRow;
        static Int64 iID_KHO = -1;
        public frmEditKho(int PQ, DataRow row, Boolean bAddEdit)
        {
            InitializeComponent();
            iPQ = PQ;
            drRow = row;
            AddEdit = bAddEdit;
            
            VsMain.MFieldRequest(lblMS_KHO);
            VsMain.MFieldRequest(lblID_DV);
            VsMain.MFieldRequest(lblTEN_KHO);
            VsMain.MFieldRequest(lblSTT);

            if (drRow != null)
            {
                try { iID_KHO = Convert.ToInt64(drRow["ID_KHO"].ToString()); } catch { iID_KHO = -1; }
            }
            else
            {
                iID_KHO = -1;
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
        private void frmEditKho_Load(object sender, EventArgs e)
        {
            try
            {
                LoadCbo();
                LoadText();
                LoadNN();

                if (Convert.ToInt32(chkKHO_DI_DUONG.EditValue) == 1)
                {
                    cboID_KHO_CHINH.ReadOnly = false;
                }
                else
                {
                    cboID_KHO_CHINH.ReadOnly = true;
                }
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
                    cboID_DV.EditValue = drRow["ID_DV"].ToString() == "" ? -1 : Convert.ToInt64(drRow["ID_DV"].ToString());
                    cboID_KHO_CHINH.EditValue = drRow["ID_KHO_CHINH"].ToString() == ""? -1 : Convert.ToInt64(drRow["ID_KHO_CHINH"].ToString());
                    txtMS_KHO.Text = drRow["MS_KHO"].ToString();
                    txtTEN_KHO.Text = drRow["TEN_KHO"].ToString();
                    txtTEN_KHO_A.Text = drRow["TEN_KHO_A"].ToString();
                    txtTEN_KHO_H.Text = drRow["TEN_KHO_H"].ToString();
                    txtDIA_CHI.Text = drRow["DIA_CHI"].ToString();
                    txtGHI_CHU.Text = drRow["GHI_CHU"].ToString();
                    txtSTT.Text = drRow["TT_KHO"].ToString();
                    chkMAC_DINH.EditValue = drRow["MAC_DINH"];
                    chkKHONG_SD.EditValue = drRow["KHONG_SD"];
                    chkKHO_DI_DUONG.EditValue = drRow["KHO_DD"];
                }
                else
                {
                    cboID_DV.EditValue = -1;
                    cboID_KHO_CHINH.EditValue = -1;
                    txtMS_KHO.Text = "";
                    txtTEN_KHO.Text = "";
                    txtTEN_KHO_A.Text = "";
                    txtTEN_KHO_H.Text = "";
                    txtDIA_CHI.Text = "";
                    txtGHI_CHU.Text = "";
                    txtSTT.Text = "";
                    chkMAC_DINH.EditValue = false;
                    chkKHONG_SD.EditValue = false;
                    chkKHO_DI_DUONG.EditValue = false;

                }

            }
            catch (Exception ex)
            {
                cboID_DV.EditValue = -1;
                cboID_KHO_CHINH.EditValue = -1;
                txtMS_KHO.Text = "";
                txtTEN_KHO.Text = "";
                txtTEN_KHO_A.Text = "";
                txtTEN_KHO_H.Text = "";
                txtDIA_CHI.Text = "";
                txtGHI_CHU.Text = "";
                txtSTT.Text = "";
                chkMAC_DINH.EditValue = false;
                chkKHONG_SD.EditValue = false;
                chkKHO_DI_DUONG.EditValue = false;

            }
        }
        private void LoadCbo()
        {
            try
             {
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@sDMuc", "mnuKho"));
                lPar.Add(new SqlParameter("@iLoai", 5));
                lPar.Add(new SqlParameter("@iID", iID_KHO));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet("spDanhMuc01", lPar);
                DataTable dt = new DataTable();

                dt = ds.Tables[0].Copy();
                Com.Mod.OS.MLoadSearchLookUpEdit(cboID_DV, dt, "ID_DV", "TEN_DV", this.Name, true, false);

                DataTable dt1 = new DataTable();
                dt1 = ds.Tables[1].Copy();
                Com.Mod.OS.MLoadSearchLookUpEdit(cboID_KHO_CHINH, dt1, "ID_KHO", "TEN_KHO", this.Name, true, false);
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
                lPar.Add(new SqlParameter("@sDMuc", "mnuKho"));
                lPar.Add(new SqlParameter("@iLoai", 4));
                lPar.Add(new SqlParameter("@iID", iID_KHO));
                lPar.Add(new SqlParameter("@INT1", iKiem));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtTEN_KHO.Text));
                lPar.Add(new SqlParameter("@NVARCHAR2", txtMS_KHO.Text));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                bKiem = Convert.ToBoolean(VsMain.MExecuteScalar("spDanhMuc01", lPar));
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
                    XtraMessageBox.Show(lblTEN_KHO.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_KHO.Focus();
                    return;
                }
                if (KiemTrung(2))
                {
                    XtraMessageBox.Show(lblMS_KHO.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtMS_KHO.Focus();
                    return;
                }
                #region Them Sua
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 3));
                lPar.Add(new SqlParameter("@sDMuc", "mnuKho")); 
                lPar.Add(new SqlParameter("@iID", iID_KHO));
                lPar.Add(new SqlParameter("@BIGINT1", Convert.ToInt64(cboID_DV.EditValue)));
                lPar.Add(new SqlParameter("@BIGINT2", Convert.ToInt64(cboID_KHO_CHINH.EditValue)));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtMS_KHO.Text));
                lPar.Add(new SqlParameter("@NVARCHAR2", txtTEN_KHO.Text));
                lPar.Add(new SqlParameter("@NVARCHAR3", txtTEN_KHO_A.Text));
                lPar.Add(new SqlParameter("@NVARCHAR4", txtTEN_KHO_H.Text));
                lPar.Add(new SqlParameter("@NVARCHAR5", txtDIA_CHI.Text));
                lPar.Add(new SqlParameter("@NVARCHAR6", txtGHI_CHU.Text));
                lPar.Add(new SqlParameter("@BIT1", chkKHONG_SD.EditValue));
                lPar.Add(new SqlParameter("@BIT3", chkMAC_DINH.EditValue));
                lPar.Add(new SqlParameter("@BIT4", chkKHO_DI_DUONG.EditValue));
                lPar.Add(new SqlParameter("@INT1", txtSTT.Text));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@ID_USER", Com.Mod.UserID));
                lPar.Add(new SqlParameter("@FullName", Com.Mod.sTenNhanVienMD )); ;
                Com.Mod.sId = Convert.ToString(VsMain.MExecuteScalar("spDanhMuc01", lPar));
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

        private void chkKHO_DI_DUONG_EditValueChanged(object sender, EventArgs e)
         {
            try
            {
                if (Convert.ToInt32(chkKHO_DI_DUONG.EditValue) == 1)
                {
                    cboID_KHO_CHINH.ReadOnly = false;
                }
                else { 
                    cboID_KHO_CHINH.ReadOnly = true;
                    cboID_KHO_CHINH.EditValue =null;
                }
            }catch(Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }
    }
}