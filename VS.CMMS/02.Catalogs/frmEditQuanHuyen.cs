using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Reflection;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace VS.CMMS
{
    public partial class frmEditQuanHuyen : DevExpress.XtraEditors.XtraForm
    {
        static Boolean AddEdit = true;  // true la add false la edit
        static DataRow drRow;
        static Int64 iIDQH = -1;
        public frmEditQuanHuyen(int PQ, DataRow row, Boolean bAddEdit)
        {
            InitializeComponent();
            VsMain.MFieldRequest(lblID_TP);
            VsMain.MFieldRequest(lblTEN_QH);

            drRow = row;
            AddEdit = bAddEdit;
            try
            {
                if (drRow["ID_QH"] == null)
                    iIDQH = -1;
                else
                    iIDQH = Int64.Parse(drRow["ID_QH"].ToString());
            }
            catch { iIDQH = -1; }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {

                if (!dxValidationProvider11.Validate()) return;
                //KIEM TRA TEN VIET
                if (!KiemTrung(1)) return;
                //kiem ten ANH
                if (txtTEN_QH_A.Text.Trim() != "") if (!KiemTrung(2)) return;
                //kiem ten HOA
                if (txtTEN_QH_H.Text.Trim() != "") if (!KiemTrung(3)) return;
                #region Them
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 3));
                lPar.Add(new SqlParameter("@sDMuc", "mnuQuanHuyen"));
                lPar.Add(new SqlParameter("@BIGINT1", cboID_TP.EditValue));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtTEN_QH.Text));
                lPar.Add(new SqlParameter("@NVARCHAR2", txtTEN_QH_A.Text));
                lPar.Add(new SqlParameter("@NVARCHAR3", txtTEN_QH_H.Text));
                lPar.Add(new SqlParameter("@NVARCHAR4", txtGHI_CHU.Text));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@ID_USER", Com.Mod.UserID));
                lPar.Add(new SqlParameter("@iID",iIDQH));
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
                #endregion
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private Boolean KiemTrung(int Cot)
        {
            try
            {
                #region KiemTrung loai = 4
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iID", iIDQH));
                lPar.Add(new SqlParameter("@iIDQG", Convert.ToInt64(cboID_TP.EditValue)));
                lPar.Add(new SqlParameter("@sDMuc", "mnuQuanHuyen"));
                lPar.Add(new SqlParameter("@iLoai", 4));
                if (Cot == 1)
                {
                    lPar.Add(new SqlParameter("@NVARCHAR1", txtTEN_QH.Text));
                    lPar.Add(new SqlParameter("@NVARCHAR2", ""));
                    lPar.Add(new SqlParameter("@NVARCHAR3", ""));
                }
                if (Cot == 2)
                {
                    lPar.Add(new SqlParameter("@NVARCHAR1", ""));
                    lPar.Add(new SqlParameter("@NVARCHAR2", txtTEN_QH_A.Text));
                    lPar.Add(new SqlParameter("@NVARCHAR3", ""));
                }
                if (Cot == 3)
                {
                    lPar.Add(new SqlParameter("@NVARCHAR1", ""));
                    lPar.Add(new SqlParameter("@NVARCHAR2", ""));
                    lPar.Add(new SqlParameter("@NVARCHAR3", txtTEN_QH_H.Text));
                }
                bool bKiem = Convert.ToBoolean(VsMain.MExecuteScalar("spDanhMuc", lPar));

                if (Convert.ToInt16(bKiem) == 1)
                {
                    if (Cot == 1)
                    {
                        XtraMessageBox.Show(lblTEN_QH.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                        txtTEN_QH.Focus();
                    }
                    if (Cot == 2)
                    {
                        XtraMessageBox.Show(lblTEN_QH_A.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                        txtTEN_QH_A.Focus();
                    }
                    if (Cot == 3)
                    {
                        XtraMessageBox.Show(lblTEN_QH_H.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                        txtTEN_QH_H.Focus();
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

        private void frmEditQuanHuyen_Load(object sender, EventArgs e)
        {
            LoadCbo();
            if (!AddEdit) LoadText();
            else
            {
                cboID_TP.Text = Convert.ToString(SqlHelper.ExecuteScalar(Com.Mod.CNStr, CommandType.Text, "SELECT TEN_QG FROM QUOC_GIA WHERE MAC_DINH=1"));
            }
            Com.Mod.OS.ThayDoiNN(this, Root);
        }
        private void LoadText()
        {
            try
            {
                txtTEN_QH.Text = drRow["TEN_QH"].ToString();
                txtTEN_QH_A.Text = drRow["TEN_QH_A"].ToString();
                txtTEN_QH_H.Text = drRow["TEN_QH_H"].ToString();
                txtGHI_CHU.Text = drRow["GHI_CHU"].ToString();
                cboID_TP.EditValue = drRow["ID_TP"].ToString() == "" ? -1 : Convert.ToInt64(drRow["ID_TP"].ToString());
            }
            catch (Exception ex)
            {
                txtTEN_QH.Text = ""; txtTEN_QH_A.Text = ""; txtTEN_QH_H.Text = ""; txtGHI_CHU.Text = "";
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }

        private void txtMT_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }

                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
            }
        }

        private void LoadCbo()
        {
            try
            {
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@sDMuc", "mnuQuanHuyen"));
                lPar.Add(new SqlParameter("@iLoai", 5));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet("spDanhMuc", lPar);
                DataTable dt = new DataTable();
                dt = ds.Tables[0].Copy();
                Com.Mod.OS.MLoadSearchLookUpEdit(cboID_TP, dt, "ID_TP", "TEN_TP", this.Name, true, false);
                DataTable dt1 = new DataTable();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
    }
}