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
using System.Reflection;
using System.Data.SqlClient;

namespace VS.CMMS
{
    public partial class frmEditTienTe : DevExpress.XtraEditors.XtraForm
    {
        static Boolean AddEdit = true;  // true la add false la edit
        static DataRow drRow;
        static Int64 iIDTT = -1;
        public frmEditTienTe(int PQ, DataRow row, Boolean bAddEdit)
        {
            InitializeComponent();

            drRow = row;
            AddEdit = bAddEdit;
            try
            {
                if (drRow["ID_TT"] == null)
                    iIDTT = -1;
                else
                    iIDTT = Int64.Parse(drRow["ID_TT"].ToString());
            }
            catch { iIDTT = -1; }

            VsMain.MFieldRequest(lblMaTT);
            VsMain.MFieldRequest(lblTenTT);

        }

        #region Load
        private void frmEditTienTe_Load(object sender, EventArgs e)
        {
            if (!AddEdit) LoadText();
            LoadNN();
        }
        private void LoadNN()
        {
            Com.Mod.OS.ThayDoiNN(this,Root);
        }
        private void LoadText()
        {
            try
            {
                txtMaTT.Text = drRow["MA_TT"].ToString();
                txtTenTT.Text = drRow["TEN_TT"].ToString();
                txtTenTTA.Text = drRow["TEN_TT_A"].ToString();
                txtTenTTH.Text = drRow["TEN_TT_H"].ToString();
                chkSYSTT.EditValue = drRow["SYS_TT"];
                chkLC.EditValue = drRow["LC_TT"];
                txtSL.EditValue = drRow["SO_SO_LE"];
                
            }
            catch (Exception ex)
            {
                txtMaTT.Text = ""; txtTenTT.Text = ""; txtTenTTA.Text = ""; txtTenTTH.Text = ""; chkSYSTT.EditValue = false;chkLC.EditValue = false;txtSL.EditValue = 0;
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        #endregion

        #region Funtion
        private Boolean KiemTrung(int Cot)
        {
            try
            {
                #region KiemTrung loai = 4
                System.Data.SqlClient.SqlConnection conn;
                conn = new System.Data.SqlClient.SqlConnection(Com.Mod.CNStr);
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spDanhMuc", conn);
                cmd.Parameters.Add("@iID", SqlDbType.BigInt).Value = iIDTT;
                cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuTienTe";
                cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 4;
                if (Cot == 1)
                {
                    cmd.Parameters.Add("@NVARCHAR1", SqlDbType.NVarChar).Value = txtMaTT.Text;
                    cmd.Parameters.Add("@NVARCHAR2", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@NVARCHAR3", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@NVARCHAR4", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@BIT1", SqlDbType.Bit).Value = null;
                    cmd.Parameters.Add("@BIT2", SqlDbType.Bit).Value = null;

                }
                if (Cot == 2)
                {
                    cmd.Parameters.Add("@NVARCHAR1", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@NVARCHAR2", SqlDbType.NVarChar).Value = txtTenTT.Text;
                    cmd.Parameters.Add("@NVARCHAR3", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@NVARCHAR4", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@BIT1", SqlDbType.Bit).Value = null;
                    cmd.Parameters.Add("@BIT2", SqlDbType.Bit).Value = null;
                }
                if (Cot == 3)
                {
                    cmd.Parameters.Add("@NVARCHAR1", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@NVARCHAR2", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@NVARCHAR3", SqlDbType.NVarChar).Value = txtTenTTA.Text;
                    cmd.Parameters.Add("@NVARCHAR4", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@BIT1", SqlDbType.Bit).Value = null;
                    cmd.Parameters.Add("@BIT2", SqlDbType.Bit).Value = null;
                }

                if (Cot == 4)
                {
                    cmd.Parameters.Add("@NVARCHAR1", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@NVARCHAR2", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@NVARCHAR3", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@NVARCHAR4", SqlDbType.NVarChar).Value = txtTenTTA.Text; 
                    cmd.Parameters.Add("@BIT1", SqlDbType.Bit).Value = null;
                    cmd.Parameters.Add("@BIT2", SqlDbType.Bit).Value = null;
                }
                if (Cot == 6)
                {
                    cmd.Parameters.Add("@NVARCHAR1", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@NVARCHAR2", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@NVARCHAR3", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@NVARCHAR4", SqlDbType.NVarChar).Value = ""; 
                    cmd.Parameters.Add("@BIT1", SqlDbType.Bit).Value = chkSYSTT.Checked;
                    cmd.Parameters.Add("@BIT2", SqlDbType.Bit).Value = null;

                }
                if (Cot == 7)
                {
                    cmd.Parameters.Add("@NVARCHAR1", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@NVARCHAR2", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@NVARCHAR3", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@NVARCHAR4", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@BIT1", SqlDbType.Bit).Value = null;
                    cmd.Parameters.Add("@BIT2", SqlDbType.Bit).Value = chkLC.Checked;
                }



                cmd.CommandType = CommandType.StoredProcedure;
                if (Convert.ToInt16(cmd.ExecuteScalar()) == 1)
                {
                    if (Cot == 1)
                    {
                        XtraMessageBox.Show(lblMaTT.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                        txtMaTT.Focus();
                    }
                    if (Cot == 2)
                    {
                        XtraMessageBox.Show(lblTenTT.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                        txtTenTT.Focus();
                    }
                    if (Cot == 3)
                    {
                        XtraMessageBox.Show(lblTenTTA.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                        txtTenTTA.Focus();
                    }
                    if (Cot == 4)
                    {
                        XtraMessageBox.Show(lblTenTTH.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                        txtTenTTH.Focus();
                    }
                    if(Cot ==6)
                    {
                        if(chkSYSTT.Checked)
                        {
                            XtraMessageBox.Show(chkSYSTT.Text + " " + Com.Mod.OS.GetLanguage(this.Name, "msgDangDuocSuDung"), this.Text);
                            chkSYSTT.Focus();
                        }
                        else
                        {
                            XtraMessageBox.Show(chkSYSTT.Text + " " + Com.Mod.OS.GetLanguage(this.Name, "msgDangDuocSuDung"), this.Text);
                            chkSYSTT.Focus();
                        }
                    }
                    if(Cot==7)
                    {
                        if (chkLC.Checked)
                        {
                            XtraMessageBox.Show(chkLC.Text + " " + Com.Mod.OS.GetLanguage(this.Name, "msgDangDuocSuDung"), this.Text);
                            chkLC.Focus();
                        }
                        else
                        {
                            XtraMessageBox.Show(chkLC.Text + " " + Com.Mod.OS.GetLanguage(this.Name, "msgDangDuocSuDung"), this.Text);
                            chkLC.Focus();
                        }
                    }
                    return false;
                }
                #endregion
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        #endregion

        #region Event
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtMaTT_Validating(object sender, CancelEventArgs e)
        {
            if(txtMaTT.Text.Length>4)
            {
                e.Cancel = true;
                txtMaTT.Focus();
                XtraMessageBox.Show("Mã Tiền Tệ Chỉ được Nhập 4 ký tự");
                txtMaTT.Text = "";
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {

                if (!dxValidationProvider1.Validate()) return;
                //kiem ma quoc gia
                if (!KiemTrung(1)) return;
                //kiem ten viet
                if (txtTenTT.Text.Trim() != "") if (!KiemTrung(2)) return;
                //kiem ten anh
                if (txtTenTTA.Text.Trim() != "") if (!KiemTrung(3)) return;
                //kiem ten HOA
                if (txtTenTTH.Text.Trim() != "") if (!KiemTrung(4)) return;
                //kiem tra SYS

                try
                {
                    if (Convert.ToBoolean(drRow["SYS_TT"]) == true || chkSYSTT.Checked) if (!KiemTrung(6)) return;
                }
                catch
                {
                    if (!KiemTrung(6)) return;
                }
                //kiem tra LC
                try
                {
                    if (Convert.ToBoolean(drRow["LC_TT"]) == true || chkLC.Checked) if (!KiemTrung(7)) return;
                }
                catch
                {
                    if (!KiemTrung(7)) return;
                }
                #region Them
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iID", iIDTT));
                lPar.Add(new SqlParameter("@sDMuc", this.Tag));
                lPar.Add(new SqlParameter("@iLoai", 3));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtMaTT.Text));
                lPar.Add(new SqlParameter("@NVARCHAR2", txtTenTT.Text));
                lPar.Add(new SqlParameter("@NVARCHAR3", txtTenTTA.Text));
                lPar.Add(new SqlParameter("@NVARCHAR4", txtTenTTH.Text));
                lPar.Add(new SqlParameter("@BIT1", chkSYSTT.EditValue));
                lPar.Add(new SqlParameter("@INT1", chkLC.EditValue));
                lPar.Add(new SqlParameter("@INT2", (txtSL.Text.Trim() == "") ? 0 : Convert.ToInt32(txtSL.EditValue)));
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
        #endregion
    }
}