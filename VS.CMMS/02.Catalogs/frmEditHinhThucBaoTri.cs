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
using Microsoft.ApplicationBlocks.Data;
using System.Reflection;
using System.Data.SqlClient;

namespace VS.CMMS
{
    public partial class frmEditHinhThucBaoTri : DevExpress.XtraEditors.XtraForm
    {
        static Boolean AddEdit; //True la add, false la edit
        static DataRow drRow;
        static Int64 iIDHTBT = -1;
        static Int32 iPQ = 1;
        public frmEditHinhThucBaoTri(int PQ, DataRow row, Boolean bAddEdit)
        {
            InitializeComponent();

            VsMain.MFieldRequest(lblTEN_HT_BT);

            drRow = row;
            AddEdit = bAddEdit;
            iPQ = PQ;
            try {
                if ( drRow == null)
                    iIDHTBT = -1;
                else
                    iIDHTBT = Int64.Parse(drRow["ID_HT_BT"].ToString());
            }
            catch { iIDHTBT = -1; }
        }

        #region Load
        private void frmEditThemNguoiDung_Load(object sender, EventArgs e)
        {
            if (!AddEdit) LoadText();
            LoadNN();

        }
        private void LoadNN()
        {
            Com.Mod.OS.ThayDoiNN(this, dataLayoutControl1);
        }
        private void LoadText()
        {
            try
            {
                txtTEN_HT_BT.Text = drRow["TEN_HT_BT"].ToString();
                txtTEN_HT_BT_A.Text = drRow["TEN_HT_BT_A"].ToString();
                txtTEN_HT_BT_H.Text = drRow["TEN_HT_BT_H"].ToString();
                txtGHI_CHU.Text = drRow["GHI_CHU"].ToString();
                txtSTT.Text = drRow["TT_HTBT"].ToString();
                chkPHONG_NGUA.EditValue = drRow["PHONG_NGUA"];
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        #endregion

        #region Funtion
        private void Them()
        {
            #region Them
            
            #endregion
        }
        private Boolean KiemTrung(int iKiem)
        {
            Boolean bKiem = false;
            try
            {
                #region KiemTrung loai = 4
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@sDMuc", this.Tag));
                lPar.Add(new SqlParameter("@iLoai", 4));
                lPar.Add(new SqlParameter("@iID", iIDHTBT));
                lPar.Add(new SqlParameter("@INT1", iKiem));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtTEN_HT_BT.Text));
                lPar.Add(new SqlParameter("@NVARCHAR2", txtTEN_HT_BT_A.Text));
                lPar.Add(new SqlParameter("@NVARCHAR3", txtTEN_HT_BT_H.Text));
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
        private void btnKhong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnGhi_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dxValidationProvider1.Validate()) return;

                if (KiemTrung(1))
                {
                    XtraMessageBox.Show(lblTEN_HT_BT.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_HT_BT.Focus();
                    return;
                }
                if (KiemTrung(2))
                {
                    XtraMessageBox.Show(lblTEN_HT_BT_A.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_HT_BT_A.Focus();
                    return;
                }
                if (KiemTrung(3))
                {
                    XtraMessageBox.Show(lblTEN_HT_BT_H.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_HT_BT_H.Focus();
                    return;
                }

                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 3));
                lPar.Add(new SqlParameter("@sDMuc", this.Tag));
                lPar.Add(new SqlParameter("@iID", iIDHTBT));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtTEN_HT_BT.Text));
                lPar.Add(new SqlParameter("@NVARCHAR2", txtTEN_HT_BT_A.Text));
                lPar.Add(new SqlParameter("@NVARCHAR3", txtTEN_HT_BT_H.Text));
                lPar.Add(new SqlParameter("@NVARCHAR4", txtGHI_CHU.Text));
                lPar.Add(new SqlParameter("@BIT1", chkPHONG_NGUA.EditValue));
                lPar.Add(new SqlParameter("@INT1", Convert.ToInt32(txtSTT.Text)));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                lPar.Add(new SqlParameter("@FullName", Com.Mod.sTenNhanVienMD)); ;
                Com.Mod.sId = Convert.ToString(VsMain.MExecuteScalar("spDanhMuc", lPar));
                if (Com.Mod.sId == "-1")
                {
                    XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgThemSuaKhongThanhCong"), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion
    }
}