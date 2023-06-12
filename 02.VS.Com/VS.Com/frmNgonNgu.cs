using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Com
{
    public partial class frmNgonNgu : DevExpress.XtraEditors.XtraForm
    {
        string sName = "";
        public frmNgonNgu(string fName)
        {
            sName = fName;
            InitializeComponent();
        }
        public void LoadNN()
        {
            Com.Mod.OS.ThayDoiNN(this, dataLayoutControl1);
            Com.Mod.OS.MLoadNNXtraGrid(grvChung, this.Name);
        }
        private void frmNNgu_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadNN();
            Com.Mod.OS.MSaveResertGrid(grvChung, this.Name);
            LoadCmb();
        }


        private void LoadData()
        {
            try
            {
                System.Data.SqlClient.SqlConnection conn;
                conn = new System.Data.SqlClient.SqlConnection(Mod.CNStr);
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spDanhMuc", conn);
                cmd.Parameters.Add("@iLoai", SqlDbType.NVarChar).Value = 1;
                if (chkTheoCbo.Checked)
                {
                    string sForm = "N@@" + cboForm.EditValue.ToString() + "@@";
                    //N@@frmChung@@
                    cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = sForm;
                }
                else
                    cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = sName;

                cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuEditLanguages";
                cmd.CommandType = CommandType.StoredProcedure;
                System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                DataTable dtTmp = new DataTable();
                dtTmp = ds.Tables[0].Copy();
                dtTmp.TableName = "DataView";
                
                if (grdChung.DataSource == null)
                {
                    Com.Mod.OS.MLoadXtraGrid(grdChung, grvChung, dtTmp, true, true, true, true);
                    grvChung.Columns["STT"].OptionsColumn.AllowEdit = false; 
                    grvChung.Columns["FORM"].OptionsColumn.AllowEdit = false;
                    grvChung.Columns["KEYWORD"].OptionsColumn.AllowEdit = false;

                    //grvChung.Columns[i].OptionsColumn.AllowEdit = false;
                    //grvChung.Columns[i].OptionsColumn.AllowEdit = false;
                }
                else
                    grdChung.DataSource = dtTmp;
                


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }


        }

        private void LoadCmb()
        {
            try
            {
                System.Data.SqlClient.SqlConnection conn;
                conn = new System.Data.SqlClient.SqlConnection(Mod.CNStr);
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spDanhMuc", conn);
                cmd.Parameters.Add("@iLoai", SqlDbType.NVarChar).Value = 3;
                cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuEditLanguages";
                cmd.CommandType = CommandType.StoredProcedure;
                System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                DataTable dtTmp = new DataTable();
                dtTmp = ds.Tables[0].Copy();
                dtTmp.TableName = "DataView";
                
                Com.Mod.OS.MLoadSearchLookUpEdit(cboForm, dtTmp, "ID_FORM", "FORM", this.Name);
                

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }


        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            CapNhap("0");
        }


        private void btnGhiAll_Click(object sender, EventArgs e)
        {
            CapNhap("1");
            LoadData();
        }


        private void CapNhap(string sAll)  // = 1 Cap nhap TViet 0r = TV -- TA or = TA -- THoa = TA
        {
            grvChung.PostEditor();
            grvChung.UpdateCurrentRow();
            string sBT = "[TMPNNEdit" + Com.Mod.UserID + "]";
            Com.Mod.OS.MTableToData(Mod.CNStr, sBT, (DataTable)grdChung.DataSource, "");
            try
            {
                System.Data.SqlClient.SqlConnection conn;
                conn = new System.Data.SqlClient.SqlConnection(Mod.CNStr);
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spDanhMuc", conn);
                cmd.Parameters.Add("@iLoai", SqlDbType.NVarChar).Value = 2;


                if (chkTheoCbo.Checked)
                {
                    string sForm = "N@@" + cboForm.EditValue.ToString() + "@@";
                    cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = sForm;
                }
                else
                    cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = sName;

                cmd.Parameters.Add("@COT3", SqlDbType.NVarChar).Value = sAll;

                cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = sBT;
                cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuEditLanguages";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }



        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            //this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void chkTheoCbo_CheckedChanged(object sender, EventArgs e)
        {
            cboForm.Properties.ReadOnly =! cboForm.Properties.ReadOnly;
            LoadData();
        }

        private void cboForm_EditValueChanged(object sender, EventArgs e)
        {
            if (chkTheoCbo.Checked == false) return;
            LoadData();
        }

        private void grvChung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete) return;
            if (grvChung.RowCount == 0) return;

            XoaDL();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            XoaDL();
        }
        private void XoaDL()
        {

            if (XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgBanCoChacXoa"), this.Text, MessageBoxButtons.YesNo) == DialogResult.No) return;
            string STT = grvChung.GetFocusedRowCellValue("STT").ToString();


            try
            {
                string sSql = "DELETE FROM dbo.LANGUAGES WHERE STT = " + STT;
                SqlHelper.ExecuteNonQuery(Mod.CNStr, CommandType.Text, sSql);

                grvChung.DeleteSelectedRows();
                ((DataTable)grdChung.DataSource).AcceptChanges();
            }
            catch { }

        }
    }
}
