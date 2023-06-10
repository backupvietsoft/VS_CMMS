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
    public partial class frmEditKhoViTri : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = -1; // =1: full, <> 1: readonly
        static Boolean AddEdit = true;// true la add false la edit
        static DataRow drRow;
        static Int64 iID_KHO = -1;
        static Int64 iID_KHO_CHINH;
        static Int64 iID_KVT_CHA = -1;
        static Int64 iID_KVT = -1;
        public frmEditKhoViTri(int PQ, DataRow row, Boolean bAddEdit, Int64 ID_KHO, Int64 ID_KVT_CHA, Int64 ID_KVT)
        {
            InitializeComponent();
            iPQ = PQ;
            drRow = row;
            AddEdit = bAddEdit;
            iID_KVT_CHA = ID_KVT_CHA;
            iID_KVT = ID_KVT;
            iID_KHO_CHINH = ID_KHO;
            VsMain.MFieldRequest(lblMS_KVT);
            VsMain.MFieldRequest(lblIKHO);
            VsMain.MFieldRequest(lblTEN_KVT);
            VsMain.MFieldRequest(lblSTT);
            if (drRow != null)
            {
                try { iID_KHO = Convert.ToInt64(drRow["ID_KHO"].ToString()); } catch { iID_KHO = -1; }
            }
            else
            {
                iID_KHO = -1;
            }

            if (iID_KHO_CHINH != -1)
            {
                cboID_KHO.ReadOnly = true;
            }
            else
            {
                cboID_KHO.ReadOnly = false;
            }
            if (iID_KVT_CHA != -1)
            {
                cboID_VTK_CHA.ReadOnly = true;
            }
            else
            {
                cboID_VTK_CHA.ReadOnly = false;
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
        private void frmEditKhoViTri_Load(object sender, EventArgs e)
        {
            try
            {
                LoadCbo();
                LoadText();
                LoadNN();
            }
            catch(Exception ex )
            {
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
        private void LoadText()
        {
            try
            { 
                if (!AddEdit)
                {
                    cboID_KHO.EditValue = drRow["ID_KHO"].ToString() == "" ? -1 : Convert.ToInt64(drRow["ID_KHO"].ToString());
                    txtMS_KVT.Text = drRow["MS_KVT"].ToString();
                    txtTEN_KVT.Text = drRow["TEN_KVT"].ToString();
                    txtTEN_KVT_A.Text = drRow["TEN_KVT_A"].ToString();
                    txtTEN_KVT_H.Text = drRow["TEN_KVT_H"].ToString();
                    txtSTT.Text = drRow["TT_KVT"].ToString();
                    chkMAC_DINH.EditValue = drRow["MAC_DINH"];
                    chkKHONG_SD.EditValue = drRow["KHONG_SD"];
                    cboID_VTK_CHA.EditValue = drRow["ID_KVT_CHA"]; 
                }
                else
                {
                    cboID_KHO.EditValue = iID_KHO_CHINH;
                    cboID_VTK_CHA.EditValue = iID_KVT;
                    txtMS_KVT.Text = "";
                    txtTEN_KVT.Text = "";
                    txtTEN_KVT_A.Text = "";
                    txtTEN_KVT_H.Text = "";
                    txtSTT.Text = "";
                    chkMAC_DINH.EditValue = false;
                    chkKHONG_SD.EditValue = false;
                }
               
            }
            catch (Exception ex)
            {
                cboID_KHO.EditValue = iID_KHO_CHINH;
                cboID_VTK_CHA.EditValue = iID_KVT;
                txtMS_KVT.Text = "";
                txtTEN_KVT.Text = "";
                txtTEN_KVT_A.Text = "";
                txtTEN_KVT_H.Text = "";
                txtSTT.Text = "";
                chkMAC_DINH.EditValue = false;
                chkKHONG_SD.EditValue = false;
            }
        }
        private void LoadCbo()
        {
            try
            {
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@sDMuc", "mnuKhoViTri"));
                lPar.Add(new SqlParameter("@iLoai", 5));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet("spDanhmuc01", lPar);
                DataTable dt = new DataTable();
                dt = ds.Tables[0].Copy();
                Com.Mod.OS.MLoadSearchLookUpEdit(cboID_KHO, dt, "ID_KHO", "TEN_KHO", this.Name, true, false);
                DataTable dt1 = new DataTable();
                dt1 = ds.Tables[1].Copy();
                Com.Mod.OS.MLoadSearchLookUpEdit(cboID_VTK_CHA, dt1, "ID_KVT", "TEN_KVT", this.Name, true, false);
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
                lPar.Add(new SqlParameter("@sDMuc", "mnuKhoViTri"));
                lPar.Add(new SqlParameter("@iLoai", 4));
                lPar.Add(new SqlParameter("@iID", iID_KHO));
                lPar.Add(new SqlParameter("@BIGINT1", cboID_KHO.EditValue));
                lPar.Add(new SqlParameter("@INT1", iKiem));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtMS_KVT.Text));
                lPar.Add(new SqlParameter("@NVARCHAR2", txtTEN_KVT.Text));
                lPar.Add(new SqlParameter("@NVARCHAR3", txtTEN_KVT_A.Text));
                lPar.Add(new SqlParameter("@NVARCHAR4", txtTEN_KVT_H.Text));
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
                    XtraMessageBox.Show(lblTEN_KVT.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_KVT.Focus();
                    return;
                }
                if (KiemTrung(2))
                {
                    XtraMessageBox.Show(lblMS_KVT.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtMS_KVT.Focus();
                    return;
                }
                #region Them Sua
                List<SqlParameter> lPar = new List<SqlParameter>(); 
                lPar.Add(new SqlParameter("@iLoai", 3));
                lPar.Add(new SqlParameter("@sDMuc", "mnuKhoViTri"));
                lPar.Add(new SqlParameter("@iID", iID_KHO));
                lPar.Add(new SqlParameter("@BIGINT1", Convert.ToInt64(cboID_KHO.EditValue)));
                lPar.Add(new SqlParameter("@BIGINT2", Convert.ToString(cboID_VTK_CHA.Text) == "" ? null:cboID_VTK_CHA.EditValue));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtMS_KVT.Text));
                lPar.Add(new SqlParameter("@NVARCHAR2", txtTEN_KVT.Text));
                lPar.Add(new SqlParameter("@NVARCHAR3", txtTEN_KVT_A.Text));
                lPar.Add(new SqlParameter("@NVARCHAR4", txtTEN_KVT_H.Text));
                lPar.Add(new SqlParameter("@BIT1", chkKHONG_SD.EditValue));
                lPar.Add(new SqlParameter("@BIT2", chkMAC_DINH.EditValue));
                lPar.Add(new SqlParameter("@INT1", txtSTT.Text));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
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
    }
}