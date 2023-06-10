using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Reflection;

namespace VS.CMMS
{
    public partial class frmEditHangSanXuat : DevExpress.XtraEditors.XtraForm
    {
        static Boolean AddEdit = true;  // true la add false la edit
        static DataRow drRow;
        static Int64 iIDIDHSX = -1;
        public frmEditHangSanXuat(int PQ, DataRow row, Boolean bAddEdit)
        {
            InitializeComponent();

            drRow = row;
            AddEdit = bAddEdit;
            try
            {
                if (drRow["ID_HSX"] == null)
                    iIDIDHSX = -1;
                else
                    iIDIDHSX = Int64.Parse(drRow["ID_HSX"].ToString());
            }
            catch { iIDIDHSX = -1; }

            VsMain.MFieldRequest(lblTEN_HSX);

        }

        #region Load
        private void frmEditHangSanXuat_Load(object sender, EventArgs e)
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
                    cboID_QG.EditValue = drRow["ID_QG"].ToString() == "" ? -1 : Convert.ToInt64(drRow["ID_QG"].ToString());
                    txtTEN_HSX.Text = drRow["TEN_HSX"].ToString();
                    
                }
                else
                {
                    cboID_QG.EditValue = -1;
                    txtTEN_HSX.Text = "";
                }

            }
            catch (Exception ex)
            {
                cboID_QG.EditValue = -1;
                txtTEN_HSX.Text = "";
            }
        }
        private void LoadCbo()
        {
            try
            {
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@sDMuc", "mnuHangSanXuat"));
                lPar.Add(new SqlParameter("@iLoai", 5));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet("spDanhmuc", lPar);
                DataTable dt = new DataTable();
                dt = ds.Tables[0].Copy();
                Com.Mod.OS.MLoadSearchLookUpEdit(cboID_QG, dt, "ID_QG", "TEN_QG", this.Name, true, false);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        private void LoadNN()
        {

            Com.Mod.OS.ThayDoiNN(this, dataLayoutControl1);
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
                lPar.Add(new SqlParameter("@sDMuc", "mnuHangSanXuat"));
                lPar.Add(new SqlParameter("@iLoai", 4));
                lPar.Add(new SqlParameter("@iID", iIDIDHSX));
                lPar.Add(new SqlParameter("@INT1", iKiem));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtTEN_HSX.Text));
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
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion
        private void btnGhi_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dxValidationProvider1.Validate()) return;
                if (KiemTrung(1))
                {
                    XtraMessageBox.Show(lblTEN_HSX.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_HSX.Focus();
                    return;
                }
                #region Thêm sửa
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 3));
                lPar.Add(new SqlParameter("@sDMuc", "mnuHangSanXuat"));
                lPar.Add(new SqlParameter("@iID", iIDIDHSX));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtTEN_HSX.Text));
                lPar.Add(new SqlParameter("@BIGINT1",cboID_QG.Text == "" ? null :cboID_QG.EditValue));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                
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
    }
}