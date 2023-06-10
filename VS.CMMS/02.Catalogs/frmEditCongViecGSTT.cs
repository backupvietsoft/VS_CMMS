using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors.Repository;
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
    public partial class frmEditCongViecGSTT : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = -1;
        static Boolean AddEdit = true;
        static DataRow drRow;
        static Int64 iID_CVGSTT = -1;
        public frmEditCongViecGSTT(int PQ, DataRow row, Boolean bAddEdit)
        {
            InitializeComponent();
            iPQ = PQ;
            drRow = row;
            AddEdit = bAddEdit;
            //////VsMain.MFieldRequest(lblMA_CV);
            //////VsMain.MFieldRequest(lblMO_TA_CV);

            if (drRow != null)
            {
                try { iID_CVGSTT = Convert.ToInt64(drRow["ID_GSTT"].ToString()); } catch { iID_CVGSTT = -1; }
            }
            else
            {
                iID_CVGSTT = -1;
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
            if (!AddEdit) ;
            LoadCbo();
            LoadText();
        }
        private void LoadText()
        {
            try
            {
                if (!AddEdit)
                {
                    txtMA_CV_GSTT.Text = drRow["MA_CV_GSTT"].ToString();
                    txtKY_HIEU_CV_GSTT.Text = drRow["KY_HIEU_CV_GSTT"].ToString();
                    txtMO_TA_CV_GSTT.Text = drRow["MO_TA_CV_GSTT"].ToString();
                    txtMO_TA_CV_GSTT_A.Text = drRow["MO_TA_CV_GSTT_A"].ToString();
                    txtMO_TA_CV_GSTT_H.Text = drRow["MO_TA_CV_GSTT_H"].ToString();
                    cboID_BP_GSTT.EditValue = Convert.ToInt64(drRow["ID_BP_GSTT"].ToString());
                    cboID_LCV.EditValue = Convert.ToInt64(drRow["ID_LCV"].ToString());
                    cboID_DVD.EditValue = Convert.ToInt64(drRow["ID_DVD"].ToString());
                    txtTG_DM.Text = drRow["TG_DM"].ToString();
                    txtSO_NGUOI.Text = drRow["SO_NGUOI"].ToString();
                    txtNHAN_SU.Text = drRow["NHAN_SU"].ToString();
                    txtDUNG_CU.Text = drRow["DUNG_CU"].ToString();
                    txtAM.Text = drRow["AM"].ToString();
                    chkDINH_TINH.Checked = Convert.ToBoolean(drRow["DINH_TINH"]);
                    txtDUONG_DAN_TL.Text = drRow["DUONG_DAN_TL"].ToString();
                    txtHUONG_DAN.Text = drRow["HUONG_DAN"].ToString();
                    txtTIEU_CHUAN.Text = drRow["TIEU_CHUAN"].ToString();
                    txtGHI_CHU.Text = drRow["GHI_CHU"].ToString();
                }
            }
            catch(Exception ex)
            {
                txtMA_CV_GSTT.Text = "";
                txtKY_HIEU_CV_GSTT.Text = "";
                txtMO_TA_CV_GSTT.Text = "";
                txtMO_TA_CV_GSTT_A.Text = "";
                txtMO_TA_CV_GSTT_H.Text = "";
                cboID_BP_GSTT.EditValue = -1;
                cboID_LCV.EditValue = -1;
                cboID_DVD.EditValue = -1;
                txtTG_DM.Text = "0";
                txtSO_NGUOI.Text = "0";
                txtNHAN_SU.Text = "";
                txtDUNG_CU.Text = "";
                txtAM.Text = "";
                chkDINH_TINH.Checked = false;
                txtDUONG_DAN_TL.Text = "";
                txtHUONG_DAN.Text = "";
                txtTIEU_CHUAN.Text = "";
                txtGHI_CHU.Text = "";
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        private void LoadCbo()
        {
            try
            {
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iALL", "1"));
                lPar.Add(new SqlParameter("@iCoALL", -1));
                lPar.Add(new SqlParameter("@sALL", " "));
                lPar.Add(new SqlParameter("@iID1", cboID_BP_GSTT.Text == "" ? -1 : Convert.ToInt64(cboID_BP_GSTT.EditValue)));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                lPar.Add(new SqlParameter("@sDanhMuc", "DON_VI_DO;LOAI_CONG_VIEC;BO_PHAN_GSTT;"));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet("spGetDataCatalogs", lPar);

                DataTable dt = new DataTable();
                dt = ds.Tables[2].Copy();
                Com.Mod.OS.MLoadSearchLookUpEdit(cboID_DVD, dt, "ID_DVD", "TEN_DVD", this.Name);
                cboID_DVD.Properties.View.Columns["TT_DVD"].Visible = false;

                dt = ds.Tables[0].Copy();
                Com.Mod.OS.MLoadSearchLookUpEdit(cboID_LCV, dt, "ID_LCV", "TEN_LCV", this.Name);
                cboID_LCV.Properties.View.Columns["TT_LCV"].Visible = false;

                dt = ds.Tables[1].Copy();
                Com.Mod.OS.MLoadSearchLookUpEdit(cboID_BP_GSTT, dt, "ID_BP_GSTT", "TEN_BO_PHAN", this.Name);

   
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dxValidationProvider1.Validate()) return;

                //Kiểm trùng
                ////if (KiemTrung(1))
                ////{
                ////    XtraMessageBox.Show(lblMA_CV.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                ////    txtMA_CV.Focus();
                ////    return;
                ////}

                #region Them Sua
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 3));
                lPar.Add(new SqlParameter("@sDMuc", "mnuCongViecGSTT"));
                lPar.Add(new SqlParameter("@iID", iID_CVGSTT));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtMA_CV_GSTT.Text));
                lPar.Add(new SqlParameter("@NVARCHAR2", txtKY_HIEU_CV_GSTT.Text));
                lPar.Add(new SqlParameter("@NVARCHAR3", txtMO_TA_CV_GSTT.Text));
                lPar.Add(new SqlParameter("@NVARCHAR4", txtMO_TA_CV_GSTT_A.Text));
                lPar.Add(new SqlParameter("@NVARCHAR5", txtMO_TA_CV_GSTT_H.Text));
                lPar.Add(new SqlParameter("@BIGINT1", cboID_LCV.Text == "" ? null : cboID_LCV.EditValue));
                lPar.Add(new SqlParameter("@BIGINT2", cboID_BP_GSTT.Text == "" ? null : cboID_BP_GSTT.EditValue));
                lPar.Add(new SqlParameter("@BIGINT3", cboID_DVD.Text == "" ? null : cboID_DVD.EditValue));
                lPar.Add(new SqlParameter("@INT1", txtTG_DM.EditValue));
                lPar.Add(new SqlParameter("@INT2", txtSO_NGUOI.EditValue));
                lPar.Add(new SqlParameter("@BIT1", chkDINH_TINH.Checked));
                lPar.Add(new SqlParameter("@NVARCHAR6", txtHUONG_DAN.Text));
                lPar.Add(new SqlParameter("@NVARCHAR7", txtTIEU_CHUAN.Text));
                lPar.Add(new SqlParameter("@NVARCHAR8", txtNHAN_SU.Text));
                lPar.Add(new SqlParameter("@NVARCHAR9", txtDUNG_CU.Text));
                lPar.Add(new SqlParameter("@NVARCHAR10", txtDUONG_DAN_TL.Text));
                lPar.Add(new SqlParameter("@NVARCHAR11", txtAM.Text));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                lPar.Add(new SqlParameter("@FullName", Com.Mod.sTenNhanVienMD));
                Com.Mod.sId = Convert.ToString(VsMain.MExecuteScalar("spDanhMuc01", lPar));
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
