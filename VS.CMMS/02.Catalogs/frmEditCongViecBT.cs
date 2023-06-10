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
    public partial class frmEditCongViecBT : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = -1;
        static Boolean AddEdit = true;
        static DataRow drRow;
        static Int64 iID_CV = -1;
        public frmEditCongViecBT(int PQ, DataRow row, Boolean bAddEdit)
        {
            InitializeComponent();
            iPQ = PQ;
            drRow = row;
            AddEdit = bAddEdit;
            VsMain.MFieldRequest(lblMA_CV);
            VsMain.MFieldRequest(lblMO_TA_CV);

            if (drRow != null)
            {
                try { iID_CV = Convert.ToInt64(drRow["ID_CV"].ToString()); } catch { iID_CV = -1; }
            }
            else
            {
                iID_CV = -1;
                txtDUONG_DAN_TL.ReadOnly = true;
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
        private void frmChung_Load(object sender, EventArgs e)
        {
    
            LoadCbo();
            if (!AddEdit)
            LoadText();
            LoadGrv();
            LoadNN();
        }
        public void LoadNN()
        {
            try
            {
                Com.Mod.OS.ThayDoiNN(this, dataLayoutControl1);
                Com.Mod.OS.MLoadNNXtraGrid(grvChung, this.Name, true);
                Com.Mod.OS.MSaveResertGrid(grvChung, this.Name);
            }
            catch (Exception ex) 
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        private void LoadCbo()
        {
            try
            {
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@sDMuc", "mnuCongViecBT"));
                lPar.Add(new SqlParameter("@iLoai", 5));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet("spDanhmuc01", lPar);
                DataTable dt = new DataTable();
                dt = ds.Tables[0].Copy();
                Com.Mod.OS.MLoadSearchLookUpEdit(cboID_NM, dt, "ID_NM", "TEN_NM", this.Name, true, false);

                DataTable dt1 = new DataTable();
                dt1 = ds.Tables[1].Copy();
                Com.Mod.OS.MLoadSearchLookUpEdit(cboID_LCV, dt1, "ID_LCV", "TEN_LCV", this.Name, true, false);

                DataTable dt2 = new DataTable();
                dt2 = ds.Tables[2].Copy();
                Com.Mod.OS.MLoadSearchLookUpEdit(cboID_BT, dt2, "ID_BT", "TEN_BAC_THO", this.Name, true, false);
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        private void LoadGrv()
        {
            try
            {
                String sSql = "SELECT LOAI_CV FROM dbo.LOAI_CONG_VIEC WHERE ID_LCV = " + Convert.ToString(cboID_LCV.EditValue == null ? -1 : Convert.ToInt32(cboID_LCV.EditValue));
                int iSql = Convert.ToInt32(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(Com.Mod.CNStr, CommandType.Text, sSql));
                if (iSql != 2) //Bằng 2 là định tính nếu không bằng 2 thì ẩn grd 
                {
                    lciChung.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    grdChung.DataSource = null;
                    return;
                }
                lciChung.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@sDMuc", "mnuCongViecBT"));
                lPar.Add(new SqlParameter("@iLoai", 7));
                lPar.Add(new SqlParameter("@iID", iID_CV));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet("spDanhmuc01", lPar);
                DataTable dt = new DataTable();
                dt = ds.Tables[0].Copy();
                Com.Mod.OS.MLoadXtraGrid(grdChung, grvChung, dt, true, true, true, true, true, this.Name);
                grvChung.OptionsMenu.EnableGroupRowMenu = true;
                if (grvChung.DataSource == null)
                {
                    Com.Mod.OS.MLoadXtraGrid(grdChung, grvChung, dt, true, true, false, false);
                    Com.Mod.OS.MSaveResertGrid(grvChung, this.Name);
                }
                else
                    grdChung.DataSource = dt;
                    Com.Mod.OS.MSaveResertGrid(grvChung, this.Name);

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
                    txtMA_CV.Text = drRow["MA_CV"].ToString();
                    txtKY_HIEU_CV.Text = drRow["KY_HIEU_CV"].ToString();
                    txtMO_TA_CV.Text = drRow["MO_TA_CV"].ToString();
                    txtMO_TA_CV_A.Text = drRow["MO_TA_CV_A"].ToString();
                    txtMO_TA_CV_H.Text = drRow["MO_TA_CV_H"].ToString();
                    cboID_NM.EditValue = drRow["ID_NM"].ToString() == "" ? -1 : Convert.ToInt64(drRow["ID_NM"].ToString());
                    cboID_LCV.EditValue = drRow["ID_LCV"].ToString() == "" ? -1 : Convert.ToInt64(drRow["ID_LCV"].ToString());
                    cboID_BT.EditValue = drRow["ID_BT"].ToString() == "" ? -1 : Convert.ToInt64(drRow["ID_BT"].ToString());
                    txtTG_DM.Text = drRow["TG_DM"].ToString();
                    txtSO_NGUOI.Text = drRow["SO_NGUOI"].ToString();
                    chkAN_TOAN.Checked = Convert.ToBoolean(drRow["AN_TOAN"].ToString());
                    txtHUONG_DAN.Text = drRow["HUONG_DAN"].ToString();
                    txtTIEU_CHUAN.Text = drRow["TIEU_CHUAN"].ToString();
                    txtNHAN_SU.Text = drRow["NHAN_SU"].ToString();
                    txtDUNG_CU.Text = drRow["DUNG_CU"].ToString();
                    txtDUONG_DAN_TL.Text = drRow["DUONG_DAN_TL"].ToString();
                }
                else
                {
                    txtMA_CV.Text = "";
                    txtKY_HIEU_CV.Text = "";
                    txtMO_TA_CV.Text = "";
                    txtMO_TA_CV_A.Text = "";
                    txtMO_TA_CV_H.Text = "";
                    cboID_BT.EditValue = -1;
                    cboID_LCV.EditValue = -1;
                    cboID_NM.EditValue = -1;
                    txtTG_DM.Text = "0";
                    txtSO_NGUOI.Text = "0";
                    chkAN_TOAN.Checked = false;
                    txtHUONG_DAN.Text = "";
                    txtTIEU_CHUAN.Text = "";
                    txtNHAN_SU.Text = "";
                    txtDUNG_CU.Text = "";
                    txtDUONG_DAN_TL.Text = "";
                }
            }
            catch (Exception ex)
            {
                txtMA_CV.Text = "";
                txtKY_HIEU_CV.Text = "";
                txtMO_TA_CV.Text = "";
                txtMO_TA_CV_A.Text = "";
                txtMO_TA_CV_H.Text = "";
                cboID_BT.EditValue = -1;
                cboID_LCV.EditValue = -1;
                cboID_NM.EditValue = -1;
                txtTG_DM.Text = "0";
                txtSO_NGUOI.Text = "0";
                chkAN_TOAN.Checked = false;
                txtHUONG_DAN.Text = "";
                txtTIEU_CHUAN.Text = "";
                txtNHAN_SU.Text = "";
                txtDUNG_CU.Text = "";
                txtDUONG_DAN_TL.Text = "";
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
                lPar.Add(new SqlParameter("@sDMuc", "mnuCongViecBT"));
                lPar.Add(new SqlParameter("@iLoai", 4));
                lPar.Add(new SqlParameter("@iID", iID_CV));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtMA_CV.Text));
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

                //Kiểm trùng
                if (KiemTrung(1))
                {
                    XtraMessageBox.Show(lblMA_CV.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtMA_CV.Focus();
                    return;
                }

                string sBT = "[CV" + Com.Mod.UserID + "]";
                Com.Mod.OS.MTableToData(Com.Mod.CNStr, sBT, Com.Mod.OS.ConvertDatatable(grdChung), "");
                #region Them Sua
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 3));
                lPar.Add(new SqlParameter("@sDMuc", "mnuCongViecBT"));
                lPar.Add(new SqlParameter("@iID", iID_CV));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtMA_CV.Text));
                lPar.Add(new SqlParameter("@NVARCHAR2", txtKY_HIEU_CV.Text));
                lPar.Add(new SqlParameter("@NVARCHAR3", txtMO_TA_CV.Text));
                lPar.Add(new SqlParameter("@NVARCHAR4", txtMO_TA_CV_A.Text));
                lPar.Add(new SqlParameter("@NVARCHAR5", txtMO_TA_CV_H.Text));
                lPar.Add(new SqlParameter("@BIGINT1", cboID_NM.Text == ""? null : cboID_NM.EditValue));
                lPar.Add(new SqlParameter("@BIGINT2", cboID_LCV.Text == "" ? null : cboID_LCV.EditValue));
                lPar.Add(new SqlParameter("@BIGINT3", cboID_BT.Text == "" ? null : cboID_BT.EditValue));
                lPar.Add(new SqlParameter("@INT1", txtTG_DM.EditValue));
                lPar.Add(new SqlParameter("@INT2", txtSO_NGUOI.EditValue));
                lPar.Add(new SqlParameter("@BIT1", chkAN_TOAN.Checked));
                lPar.Add(new SqlParameter("@NVARCHAR6", txtHUONG_DAN.Text));
                lPar.Add(new SqlParameter("@NVARCHAR7", txtTIEU_CHUAN.Text));
                lPar.Add(new SqlParameter("@NVARCHAR8", txtNHAN_SU.Text));
                lPar.Add(new SqlParameter("@NVARCHAR9", txtDUNG_CU.Text));
                lPar.Add(new SqlParameter("@NVARCHAR10", txtDUONG_DAN_TL.Text));
                lPar.Add(new SqlParameter("@sBT1", sBT));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                lPar.Add(new SqlParameter("@FullName", Com.Mod.sTenNhanVienMD));
                DataTable dt_TEMP = VsMain.MGetDatatable("spDanhMuc01", lPar);
                if (Com.Mod.sId == "-99")
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
        private void txtDUONG_DAN_TL_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (!dxValidationProvider1.Validate())
                {
                    XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgChuaNhapDuDuLieu"), this.Text);
                    return;
                }

                if (txtDUONG_DAN_TL.ReadOnly == true)
                {
                    return;
                }


                Com.Mod.MFileServer mFile;
                mFile = Com.Mod.OS.CopyFileToServer("DiaDiem\\CongViecBaoTro", txtMA_CV.Text);

                if (mFile.sfilegoc.Count <= 0) return;

                this.Cursor = Cursors.WaitCursor;

                string sPath, sPathGoc;
                sPath = mFile.sfileserver[0].ToString();
                txtDUONG_DAN_TL.Text = sPath;
            }
            catch
            {
                XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgBanKhongCoQuyenTruyCapDD"), this.Text, MessageBoxButtons.OK);
            }
            this.Cursor = Cursors.Default;
        }
        private void cboID_LCV_EditValueChanged(object sender, EventArgs e)
        {
            if (Com.Mod.sLoad == "0Load") return;
            LoadGrv();
        }
        #endregion

    }
}
