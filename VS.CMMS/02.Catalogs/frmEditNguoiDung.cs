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

namespace VS.CMMS
{
    public partial class frmEditNguoiDung : DevExpress.XtraEditors.XtraForm
    {
        static Boolean AddEdit; //True la add, false la edit
        static DataRow drRow;
        static Int64 iIDUSER = -1;
        static Int32 iPQ = 1;
        public frmEditNguoiDung(int PQ, DataRow row, Boolean bAddEdit)
        {
            InitializeComponent();

            VsMain.MFieldRequest(lblID_NHOM);
            VsMain.MFieldRequest(lblUSER_NAME);

            drRow = row;
            AddEdit = bAddEdit;
            iPQ = PQ;
            try {
                if ( drRow == null)
                    iIDUSER = -1;
                else
                    iIDUSER = Int64.Parse(drRow["ID_USER"].ToString());
            }
            catch { iIDUSER = -1; }
            LoadCbo();
        }
        private void frmEditThemNguoiDung_Load(object sender, EventArgs e)
        {
            if (!AddEdit) LoadText();
            LoadNN();

        }

        #region Load
        private void LoadCbo()
        {
            System.Data.SqlClient.SqlConnection conn;
            conn = new System.Data.SqlClient.SqlConnection(Com.Mod.CNStr);
            conn.Open();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spNguoiDung", conn);
            cmd.Parameters.Add("@iID", SqlDbType.Int).Value = iIDUSER;
            cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuThemNguoiDung";
            cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 5;
            cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Com.Mod.iNNgu;
            cmd.CommandType = CommandType.StoredProcedure;
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = new DataTable();
            dt = ds.Tables[0].Copy();
            Com.Mod.OS.MLoadLookUpEdit(cboID_NHOM, dt, "ID_NHOM", "TEN_NHOM", Com.Mod.OS.GetLanguage(this.Name, "TEN_NHOM"));
        }
        private void LoadNN()
        {
            Com.Mod.OS.ThayDoiNN(this, dataLayoutControl1);
        }
        private void LoadText()
        {
            try
            {
                cboID_NHOM.EditValue = Convert.ToInt32(SqlHelper.ExecuteScalar(Com.Mod.CNStr, CommandType.Text, "SELECT ID_NHOM FROM dbo.USERS WHERE ID_USER = " + iIDUSER));
                txtUSER_NAME.Text = drRow["USER_NAME"].ToString();
                txtFULL_NAME.Text = drRow["FULL_NAME"].ToString();
                txtPASSWORD.Text = Com.Mod.OS.Decrypt(drRow["PASSWORD"].ToString(), true);
                txtDESCRIPTION.Text = drRow["DESCRIPTION"].ToString();
                txtUSER_MAIL.Text = drRow["USER_MAIL"].ToString();
                txtUSER_PHONE.Text = drRow["USER_PHONE"].ToString();
                ckbACTIVE.EditValue = drRow["ACTIVE"];
                chkLIC.EditValue = drRow["LIC"];
            }
            catch (Exception ex)
            {
                txtUSER_NAME.Text = ""; txtFULL_NAME.Text = ""; txtPASSWORD.Text = ""; txtDESCRIPTION.Text = ""; txtUSER_MAIL.Text = ""; txtUSER_PHONE.Text = ""; cboID_NHOM.EditValue = 0;
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        #endregion

        #region Funtion
        private void Them()
        {
            #region Them
            System.Data.SqlClient.SqlConnection conn;
            conn = new System.Data.SqlClient.SqlConnection(Com.Mod.CNStr);
            conn.Open();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spNguoiDung", conn);
            cmd.Parameters.Add("@iID", SqlDbType.BigInt).Value = iIDUSER;
            cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuThemNguoiDung";
            cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 3;
            cmd.Parameters.Add("@COT8", SqlDbType.Int).Value = cboID_NHOM.EditValue;
            cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = txtUSER_NAME.Text;
            cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = txtFULL_NAME.Text;
            cmd.Parameters.Add("@COT3", SqlDbType.NVarChar).Value = Com.Mod.OS.Encrypt(txtPASSWORD.Text, true);
            cmd.Parameters.Add("@COT4", SqlDbType.NVarChar).Value = txtDESCRIPTION.Text;
            cmd.Parameters.Add("@COT5", SqlDbType.NVarChar).Value = txtUSER_MAIL.Text;
            cmd.Parameters.Add("@COT6", SqlDbType.Bit).Value = ckbACTIVE.EditValue;
            cmd.Parameters.Add("@sBT", SqlDbType.NVarChar).Value = txtUSER_PHONE.Text;
            cmd.CommandType = CommandType.StoredProcedure;
            Com.Mod.sId = Convert.ToString(cmd.ExecuteScalar());

            this.DialogResult = DialogResult.OK;
            #endregion
        }
        private Boolean KiemTrung(int Cot)
        {
            try
            {
                #region KiemTrung loai = 4
                System.Data.SqlClient.SqlConnection conn;
                conn = new System.Data.SqlClient.SqlConnection(Com.Mod.CNStr);
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spNguoiDung", conn);
                cmd.Parameters.Add("@iID", SqlDbType.BigInt).Value = iIDUSER;
                cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuThemNguoiDung";
                cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 4;
                if (Cot == 1)
                {
                    cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = txtUSER_NAME.Text;
                    cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT3", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT4", SqlDbType.NVarChar).Value = "";
                }
          
                cmd.CommandType = CommandType.StoredProcedure;
                if (Convert.ToInt16(cmd.ExecuteScalar()) == 1)
                {
                    if (Cot == 1)
                    {
                        XtraMessageBox.Show(lblUSER_NAME.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                        txtUSER_NAME.Focus();
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
        private void btnKhong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cboID_NHOM_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //string a = this.Name.ToString();
            //if (e.Button.Index == 1)
            //{
            //    try
            //    {
            //        XtraForm ctl;
            //        Type newType = Type.GetType("VS.CMMS.frmView", true, true);
            //        object o1 = Activator.CreateInstance(newType, iPQ , "-1", "spNguoiDung");
            //        ctl = o1 as XtraForm;
            //        ctl.StartPosition = FormStartPosition.CenterParent;
            //        if (ctl.ShowDialog() == DialogResult.OK)
            //        {
            //            LoadCbo();
            //            int ID_NHOM_cbo;
            //            ID_NHOM_cbo = int.Parse(string.IsNullOrEmpty(ctl.Tag.ToString()) ? "1" : ctl.Tag.ToString());
            //            cboID_NHOM.EditValue = ID_NHOM_cbo;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        XtraMessageBox.Show(ex.Message, this.Text);
            //    }
            //}
        }
        private void btnGhi_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dxValidationProvider1.Validate()) return;
                //KIEM TRA USER NAME
                if (!KiemTrung(1)) return;
                string sTmp = "";
                sTmp = Com.Mod.OS.MChechkMail(txtUSER_MAIL.Text);
                if (sTmp != "")
                {
                    XtraMessageBox.Show(sTmp);
                    txtUSER_MAIL.Focus();
                    return;
                }

                if (AddEdit == true)
                {
                    Them();
                }
                else
                {
                    frmXacNhan ctl = new frmXacNhan();
                    ctl.StartPosition = FormStartPosition.CenterParent;
                    if (ctl.ShowDialog() == DialogResult.OK)
                    {
                        Them();
                    }
                    else
                        return;
                }

                string sSql = "";
                if (!chkLIC.Checked)
                {
                    sSql = "UPDATE dbo.USERS SET LIC = 0,USER_PQ = N'" + Com.Mod.OS.Encrypt(txtUSER_NAME.Text + "false", true) + "' WHERE ID_USER =  " + iIDUSER;
                    SqlHelper.ExecuteNonQuery(Com.Mod.CNStr, CommandType.Text, sSql);
                    return;
                }

                //
                sSql = "SELECT ISNULL(COUNT(*),0) AS NLIC FROM dbo.USERS WHERE ISNULL(LIC,0) = 1 AND USER_NAME <> N'" + txtUSER_NAME.Text + "' ";
                try
                {
                    sSql = Convert.ToString(SqlHelper.ExecuteScalar(Com.Mod.CNStr, CommandType.Text, sSql));
                }
                catch
                {
                    XtraMessageBox.Show(Com.Mod.OS.GetLanguage(this.Name, "msgVuiLongLienHeNhaSanXuatXemLaiSoLicsen"), this.Text);
                }
                if (int.Parse(sSql) >= Com.Mod.iLic)
                {
                    XtraMessageBox.Show(Com.Mod.OS.GetLanguage(this.Name, "msgQuaSoLuongLicsenSoLuongLicsenHienTaiLa") + " : " + Com.Mod.iLic.ToString(), this.Text);
                    chkLIC.Checked = false;
                    sSql = "UPDATE dbo.USERS SET LIC = 0,USER_PQ = N'" + Com.Mod.OS.Encrypt(txtUSER_NAME.Text + "false", true) + "' WHERE ID_USER =  " + iIDUSER;
                    SqlHelper.ExecuteNonQuery(Com.Mod.CNStr, CommandType.Text, sSql);


                    return;
                }
                else
                {

                    sSql = "UPDATE dbo.USERS SET LIC = 1,USER_PQ = N'" + Com.Mod.OS.Encrypt(txtUSER_NAME.Text.ToLower() + "true", true) + "' WHERE ID_USER =  " + iIDUSER;
                    SqlHelper.ExecuteNonQuery(Com.Mod.CNStr, CommandType.Text, sSql);
                }

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