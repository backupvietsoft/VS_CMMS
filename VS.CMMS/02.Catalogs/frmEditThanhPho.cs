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
    public partial class FrmEditThanhPho : DevExpress.XtraEditors.XtraForm
    {
        static Boolean AddEdit = true;  // true la add false la edit
        static DataRow drRow;
        static Int64 iIDTP = -1;
        public FrmEditThanhPho(int PQ, DataRow row, Boolean bAddEdit)
        {
            InitializeComponent();
            VsMain.MFieldRequest(lblID_QG);
            VsMain.MFieldRequest(lblTEN_PT);

            drRow = row;
            AddEdit = bAddEdit;
            try
            {
                if (drRow["ID_TP"] == null)
                    iIDTP = -1;
                else
                    iIDTP = Int64.Parse(drRow["ID_TP"].ToString());
            }
            catch { iIDTP = -1; }

            DataTable dt = new DataTable();
            List<SqlParameter> lPar = new List<SqlParameter>();
            lPar.Add(new SqlParameter("@iALL", 0));
            lPar.Add(new SqlParameter("@sALL", ""));
            lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
            lPar.Add(new SqlParameter("@sDanhMuc", "QUOC_GIA;"));
            dt = VsMain.MGetDatatable("spGetDataCatalogs", lPar);
            Com.Mod.OS.MLoadLookUpEdit(cboID_QG, dt,  "ID_QG" ,"TEN_QG",Com.Mod.OS.GetLanguage(this.Name, "TEN_QG"));
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
                if (txtTEN_PT_A.Text.Trim() != "") if (!KiemTrung(2)) return;
                //kiem ten HOA
                if (txtTEN_TP_H.Text.Trim() != "") if (!KiemTrung(3)) return;
                #region Them
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 3));
                lPar.Add(new SqlParameter("@sDMuc", "mnuThanhPho"));
                lPar.Add(new SqlParameter("@BIGINT1", cboID_QG.EditValue));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtTEN_PT.Text));
                lPar.Add(new SqlParameter("@NVARCHAR2", txtTEN_PT_A.Text));
                lPar.Add(new SqlParameter("@NVARCHAR3", txtTEN_TP_H.Text));
                lPar.Add(new SqlParameter("@NVARCHAR4", txtGHI_CHU.Text));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@iID",iIDTP));
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
        private Boolean KiemTrung(int Cot)
        {
            try
            {
                #region KiemTrung loai = 4
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iID", iIDTP));
                lPar.Add(new SqlParameter("@iIDQG", Convert.ToInt64(cboID_QG.EditValue)));
                lPar.Add(new SqlParameter("@sDMuc", "mnuThanhPho"));
                lPar.Add(new SqlParameter("@iLoai", 4));
                if (Cot == 1)
                {
                    lPar.Add(new SqlParameter("@NVARCHAR1", txtTEN_PT.Text));
                    lPar.Add(new SqlParameter("@NVARCHAR2", ""));
                    lPar.Add(new SqlParameter("@NVARCHAR3", ""));
                }
                if (Cot == 2)
                {
                    lPar.Add(new SqlParameter("@NVARCHAR1", ""));
                    lPar.Add(new SqlParameter("@NVARCHAR2", txtTEN_PT_A.Text));
                    lPar.Add(new SqlParameter("@NVARCHAR3", ""));
                }
                if (Cot == 3)
                {
                    lPar.Add(new SqlParameter("@NVARCHAR1", ""));
                    lPar.Add(new SqlParameter("@NVARCHAR2", ""));
                    lPar.Add(new SqlParameter("@NVARCHAR3", txtTEN_TP_H.Text));
                }
                bool bKiem = Convert.ToBoolean(VsMain.MExecuteScalar("spDanhMuc", lPar));

                if (Convert.ToInt16(bKiem) == 1)
                {
                    if (Cot == 1)
                    {
                        XtraMessageBox.Show(lblTEN_PT.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                        txtTEN_PT.Focus();
                    }
                    if (Cot == 2)
                    {
                        XtraMessageBox.Show(lblTEN_PT_A.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                        txtTEN_PT_A.Focus();
                    }
                    if (Cot == 3)
                    {
                        XtraMessageBox.Show(lblTEN_TP_H.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                        txtTEN_TP_H.Focus();
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

        private void FrmEditThanhPho_Load(object sender, EventArgs e)
        {
            if (!AddEdit) LoadText();
            else
            {
                cboID_QG.Text = Convert.ToString(SqlHelper.ExecuteScalar(Com.Mod.CNStr, CommandType.Text, "SELECT TEN_QG FROM QUOC_GIA WHERE MAC_DINH=1"));
            }
            Com.Mod.OS.ThayDoiNN(this, Root);
        }
        private void LoadText()
        {
            try
            {
                txtTEN_PT.Text = drRow["TEN_TP"].ToString();
                txtTEN_PT_A.Text = drRow["TEN_TP_A"].ToString();
                txtTEN_TP_H.Text = drRow["TEN_TP_H"].ToString();
                txtGHI_CHU.Text = drRow["GHI_CHU"].ToString();
                cboID_QG.EditValue = drRow["ID_QG"].ToString() == "" ? -1 : Convert.ToInt64(drRow["ID_QG"].ToString());
                cboID_QG.Text = Convert.ToString(SqlHelper.ExecuteScalar(Com.Mod.CNStr, CommandType.Text, "SELECT TEN_QG FROM QUOC_GIA t1,THANH_PHO T2 WHERE "+iIDTP+"=ID_TP AND  T1.ID_QG=T2.ID_QG "));
            }
            catch (Exception ex)
            {
                txtTEN_PT.Text = ""; txtTEN_PT_A.Text = ""; txtTEN_TP_H.Text = ""; txtGHI_CHU.Text = "";
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
    }
}