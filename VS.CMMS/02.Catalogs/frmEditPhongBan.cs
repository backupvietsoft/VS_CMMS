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
    public partial class frmEditPhongBan : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = -1; // =1: full, <> 1: readonly
        static Boolean AddEdit = true;// true la add false la edit
        static DataRow drRow;
        static Int64 iID_PB = -1;
        public frmEditPhongBan(int PQ, DataRow row, Boolean bAddEdit)
        {
            InitializeComponent();
            iPQ = PQ;
            drRow = row;
            AddEdit = bAddEdit;

            VsMain.MFieldRequest(lblTEN_PB);
            VsMain.MFieldRequest(lblID_DV);
            VsMain.MFieldRequest(lblSTT);

            if (drRow != null)
            {
                try { iID_PB = Convert.ToInt64(drRow["ID_PB"].ToString()); } catch { iID_PB = -1; }
            }
            else
            {
                iID_PB = -1;
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
        private void frmEditPhongBan_Load(object sender, EventArgs e)
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
                    cboID_DV.EditValue = drRow["ID_DV"].ToString() == "" ? -1 : Convert.ToInt64(drRow["ID_DV"].ToString());
                    txtTENPB.Text = drRow["TEN_PB"].ToString();
                    txtTEN_PB_A.Text = drRow["TEN_PB_A"].ToString();
                    txtTEN_PB_H.Text = drRow["TEN_PB_H"].ToString();
                    txtTO_TRUONG.Text = drRow["TO_TRUONG"].ToString();
                    txtSTT.Text = drRow["TT_PB"].ToString();

                }
                else
                {
                    txtTENPB.Text = ""; txtTEN_PB_A.Text = "";
                    txtTEN_PB_H.Text = ""; txtTO_TRUONG.Text = ""; cboID_DV.EditValue = -1;txtSTT.Text = "";
                }
               
            }
            catch (Exception ex)
            {
                txtTENPB.Text = ""; txtTENPB.Text = ""; txtTEN_PB_A.Text = ""; 
                txtTEN_PB_H.Text = ""; txtTO_TRUONG.Text = ""; cboID_DV.EditValue = -1 ;
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
                lPar.Add(new SqlParameter("@iID", iID_PB));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet("spDanhmuc", lPar);
                DataTable dt = new DataTable();
                dt = ds.Tables[0].Copy();
                Com.Mod.OS.MLoadSearchLookUpEdit(cboID_DV, dt, "ID_DV", "TEN_DV", this.Name, true, false);
            }
            catch(Exception ex)
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
                lPar.Add(new SqlParameter("@iID", cboID_DV.EditValue));
                lPar.Add(new SqlParameter("@INT1", iKiem));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtTENPB.Text));
                lPar.Add(new SqlParameter("@NVARCHAR2", txtTEN_PB_A.Text));
                lPar.Add(new SqlParameter("@NVARCHAR3", txtTEN_PB_H.Text));
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
                    XtraMessageBox.Show(lblTEN_PB.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTENPB.Focus();
                    return;
                }
                if (KiemTrung(2))
                {
                    XtraMessageBox.Show(lblTEN_PB_A.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTENPB.Focus();
                    return;
                }
                if (KiemTrung(3))
                {
                    XtraMessageBox.Show(lblTEN_PB_H.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTENPB.Focus();
                    return;
                }
                #region Them Sua
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 3));
                lPar.Add(new SqlParameter("@sDMuc", this.Tag));
                lPar.Add(new SqlParameter("@iID", iID_PB));
                lPar.Add(new SqlParameter("@BIGINT1", Convert.ToInt64(cboID_DV.EditValue)));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtTENPB.Text));
                lPar.Add(new SqlParameter("@NVARCHAR2", txtTEN_PB_A.Text));
                lPar.Add(new SqlParameter("@NVARCHAR3", txtTEN_PB_H.Text));
                lPar.Add(new SqlParameter("@NVARCHAR4", txtTO_TRUONG.Text));
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