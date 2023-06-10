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

namespace VS.CMMS
{
    public partial class frmEditNhomNguoiDung : DevExpress.XtraEditors.XtraForm
    {
        static Boolean AddEdit;// True la add, false la edit
        static DataRow drRow;
        static Int64 iIDNHOM = -1; 
        public frmEditNhomNguoiDung(int PQ, DataRow row, Boolean bAddEdit)
        {
            InitializeComponent();
            VsMain.MFieldRequest(lblTEN_NHOM);

            drRow = row;
            AddEdit = bAddEdit;
            try
            {
                if (drRow == null)
                    iIDNHOM = -1;
                else
                    iIDNHOM = Int64.Parse(drRow["ID_NHOM"].ToString());
            }
            catch { iIDNHOM = -1; }
        }

        #region Load
        private void frmEditNhomNguoiDung_Load(object sender, EventArgs e)
        {
            if (!AddEdit) LoadText();
            LoadNN();
        }
        private void LoadNN()
        {
            Com.Mod.OS.ThayDoiNN(this, Root);
        }
        private void LoadText()
        {
            try
            {
                txtTEN_NHOM.Text = drRow["TEN_NHOM"].ToString();
                txtTEN_NHOM_A.Text = drRow["TEN_NHOM_A"].ToString();
                txtTEN_NHOM_H.Text = drRow["TEN_NHOM_H"].ToString();
                txtGHI_CHU.Text = drRow["GHI_CHU"].ToString();
            }
            catch (Exception ex)
            {
                txtTEN_NHOM.Text = ""; txtTEN_NHOM_A.Text = ""; txtTEN_NHOM_H.Text = ""; txtGHI_CHU.Text = "";
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
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spNguoiDung", conn);
                cmd.Parameters.Add("@iID", SqlDbType.BigInt).Value = iIDNHOM;
                cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuNhomNguoiDung";
                cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 4;
                if (Cot == 1)
                {
                    cmd.Parameters.Add("@NVARCHAR1", SqlDbType.NVarChar).Value = txtTEN_NHOM.Text;
                    cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT3", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT6", SqlDbType.Bit).Value = null;

                }
                if (Cot == 2)
                {
                    cmd.Parameters.Add("@NVARCHAR1", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = txtTEN_NHOM_A.Text;
                    cmd.Parameters.Add("@COT3", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT6", SqlDbType.Bit).Value = null;
                }
                if (Cot == 3)
                {
                    cmd.Parameters.Add("@NVARCHAR1", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT3", SqlDbType.NVarChar).Value = txtTEN_NHOM_H.Text;
                    cmd.Parameters.Add("@COT6", SqlDbType.Bit).Value = null;
                }

                cmd.CommandType = CommandType.StoredProcedure;
                if (Convert.ToInt16(cmd.ExecuteScalar()) == 1)
                {
                    if (Cot == 1)
                    {
                        XtraMessageBox.Show(lblTEN_NHOM.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                        txtTEN_NHOM.Focus();
                    }
                    if (Cot == 2)
                    {
                        XtraMessageBox.Show(lblTEN_NHOM_A.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                        txtTEN_NHOM_A.Focus();
                    }
                    if (Cot == 3)
                    {
                        XtraMessageBox.Show(lblTEN_NHOM_H.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                        txtGHI_CHU.Focus();
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
        private void btnGhi_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dxValidationProvider1.Validate()) return;
                //kiem Ten Loai Doi Tac
                if (!KiemTrung(1)) return;
                //kiem ten anh
                if (txtTEN_NHOM_A.Text.Trim() != "") if (!KiemTrung(2)) return;
                //kiem ten Hoa
                if (txtTEN_NHOM_H.Text.Trim() != "") if (!KiemTrung(3)) return;

                #region Them
                System.Data.SqlClient.SqlConnection conn;
                conn = new System.Data.SqlClient.SqlConnection(Com.Mod.CNStr);
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spNguoiDung", conn);
                cmd.Parameters.Add("@iID", SqlDbType.BigInt).Value = iIDNHOM;
                cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuNhomNguoiDung";
                cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 3;
                cmd.Parameters.Add("@NVARCHAR1", SqlDbType.NVarChar).Value = txtTEN_NHOM.Text;
                cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = txtTEN_NHOM_A.Text;
                cmd.Parameters.Add("@COT3", SqlDbType.NVarChar).Value = txtTEN_NHOM_H.Text;
                cmd.Parameters.Add("@COT4", SqlDbType.NVarChar).Value = txtGHI_CHU.Text;

                cmd.CommandType = CommandType.StoredProcedure;

                string ID_NHOM = "";
                ID_NHOM = Convert.ToString(cmd.ExecuteScalar());
                Com.Mod.sId = ID_NHOM;
                this.Tag = ID_NHOM;

                this.DialogResult = DialogResult.OK;
                #endregion
            }
            catch (Exception ex)
            {
                //XtraMessageBox.Show(Com.Modules.ObjLanguages.GetLanguage("frmChung", "msgDelDangSuDung") + "\n" + ex.Message.ToString(), "");
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion
    }
}