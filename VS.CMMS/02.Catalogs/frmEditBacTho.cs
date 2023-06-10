using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace VS.CMMS
{
    public partial class frmEditBacTho : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = -1; // =1: full, <> 1: readonly
        static Boolean AddEdit = true;// true la add false la edit
        static DataRow drRow;
        static Int64 iID_BT = -1;

        #region Load
        public frmEditBacTho(int PQ, DataRow row, Boolean bAddEdit)
        {
            InitializeComponent();
            iPQ = PQ;
            drRow = row;
            AddEdit = bAddEdit;
            VsMain.MFieldRequest(lblTEN_BAC_THO);

            if (drRow != null)
            {
                try { iID_BT = Convert.ToInt64(drRow["ID_BT"].ToString()); } catch { iID_BT = -1; }
            }
            else
            {
                iID_BT = -1;
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
        private void frmChung_Load(object sender, EventArgs e)
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
                txtTEN_BAC_THO.Text = drRow["TEN_BAC_THO"].ToString();
                txtTEN_BAC_THO_A.Text = drRow["TEN_BAC_THO_A"].ToString();
                txtTEN_BAC_THO_H.Text = drRow["TEN_BAC_THO_H"].ToString();
                txtGHI_CHU.Text = drRow["GHI_CHU"].ToString();
            }
            catch (Exception ex)
            {
                txtTEN_BAC_THO.Text = ""; txtTEN_BAC_THO_A.Text = "";
                txtTEN_BAC_THO_H.Text = ""; txtGHI_CHU.Text = "";
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        #endregion

        #region Function
        private Boolean KiemTrung(int iKiem)
        {
            Boolean bKiem = false;
            try
            {
                #region KiemTrung loai = 4

                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 4));
                lPar.Add(new SqlParameter("@sDMuc", this.Tag));
                lPar.Add(new SqlParameter("@iID", iID_BT)); ;
                lPar.Add(new SqlParameter("@INT1", iKiem));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtTEN_BAC_THO.Text));
                lPar.Add(new SqlParameter("@NVARCHAR2", txtTEN_BAC_THO_A.Text));
                lPar.Add(new SqlParameter("@NVARCHAR3", txtTEN_BAC_THO_H.Text));
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

        #region Envent
        private void btnGhi_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dxValidationProvider1.Validate()) return;
                //Kiểm trùng
                if (!KiemTrung(1) && txtTEN_BAC_THO.Text != "")
                {
                    XtraMessageBox.Show(lblTEN_BAC_THO.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_BAC_THO.Focus();
                    return;
                }
                if (!KiemTrung(2) && txtTEN_BAC_THO_A.Text != "")
                {
                    XtraMessageBox.Show(lblTEN_BAC_THO_A.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_BAC_THO_A.Focus();
                    return;
                }
                if (!KiemTrung(3) && txtTEN_BAC_THO_H.Text != "")
                {
                    XtraMessageBox.Show(lblTEN_BAC_THO_H.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_BAC_THO_H.Focus();
                    return;
                }
                #region Them Sua
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 3));
                lPar.Add(new SqlParameter("@sDMuc", this.Tag));
                lPar.Add(new SqlParameter("@iID", iID_BT));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtTEN_BAC_THO.Text));
                lPar.Add(new SqlParameter("@NVARCHAR2", txtTEN_BAC_THO_A.Text));
                lPar.Add(new SqlParameter("@NVARCHAR3", txtTEN_BAC_THO_H.Text));
                lPar.Add(new SqlParameter("@NVARCHAR4", txtGHI_CHU.Text));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                lPar.Add(new SqlParameter("@FullName", Com.Mod.sTenNhanVienMD));
                Com.Mod.sId = Convert.ToString(VsMain.MExecuteScalar("spDanhMuc", lPar));
                if (Com.Mod.sId == "-1")
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
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion
    }
}
