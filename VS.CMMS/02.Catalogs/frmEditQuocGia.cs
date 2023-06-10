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
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

namespace VS.CMMS
{
    public partial class FrmEditQuocGia : DevExpress.XtraEditors.XtraForm
    {
        static Boolean AddEdit = true;
        static DataRow drRow;
        static Int64 iIDQG = -1;
        public FrmEditQuocGia(int PQ,DataRow row, Boolean bAddEdit)
        {
            InitializeComponent();
            VsMain.MFieldRequest(lblMA_QG);
            VsMain.MFieldRequest(lblTEN_QG);

            drRow = row;
            AddEdit = bAddEdit;
            try
            {
                if (drRow["ID_QG"] == null)
                    iIDQG = -1;
                else
                    iIDQG = Int64.Parse(drRow["ID_QG"].ToString());
            }
            catch { iIDQG = -1; }
        }

        #region Load
        public void LoadNN()
        {
            Com.Mod.OS.ThayDoiNN(this,Root);

        }
        private void FrmEditQuocGia_Load(object sender, EventArgs e)
        {
            if (!AddEdit) LoadText();
            LoadNN();
            
        }
        #endregion

        #region Funtion
        private void LoadText()
        {
            try
            {
                txtMA_QG.Text = drRow["MA_QG"].ToString();
                txtTEN_QG.Text = drRow["TEN_QG"].ToString();
                txtTEN_QG_A.Text = drRow["TEN_QG_A"].ToString();
                txtTEN_QG_H.Text = drRow["TEN_QG_H"].ToString();
                txtGHI_CHU.Text = drRow["GHI_CHU"].ToString();
                chkMAC_DINH.EditValue = drRow["MAC_DINH"];
            }
            catch (Exception ex)
            {
                txtTEN_QG.Text = ""; txtTEN_QG_A.Text = ""; txtTEN_QG_H.Text = ""; txtGHI_CHU.Text = "";
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        private Boolean KiemTrung(int Cot)
        {
            try
            {
                #region KiemTrung loai = 4
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iID", iIDQG));
                lPar.Add(new SqlParameter("@sDMuc", "mnuQuocGia"));
                lPar.Add(new SqlParameter("@iLoai", 4));

                if (Cot == 1)
                {
                    lPar.Add(new SqlParameter("@NVARCHAR1", txtMA_QG.Text));
                    lPar.Add(new SqlParameter("@NVARCHAR2", ""));
                    lPar.Add(new SqlParameter("@NVARCHAR3", ""));
                    lPar.Add(new SqlParameter("@NVARCHAR4", ""));
                }
                if (Cot == 2)
                {
                    lPar.Add(new SqlParameter("@NVARCHAR1", ""));
                    lPar.Add(new SqlParameter("@NVARCHAR2", txtMA_QG.Text));
                    lPar.Add(new SqlParameter("@NVARCHAR3", ""));
                    lPar.Add(new SqlParameter("@NVARCHAR4", ""));
                }
                if (Cot == 3)
                {
                    lPar.Add(new SqlParameter("@NVARCHAR1", ""));
                    lPar.Add(new SqlParameter("@NVARCHAR2", ""));
                    lPar.Add(new SqlParameter("@NVARCHAR3", txtMA_QG.Text));
                    lPar.Add(new SqlParameter("@NVARCHAR4", ""));
                }

                if (Cot == 4)
                {
                    lPar.Add(new SqlParameter("@NVARCHAR1", ""));
                    lPar.Add(new SqlParameter("@NVARCHAR2", ""));
                    lPar.Add(new SqlParameter("@NVARCHAR3", ""));
                    lPar.Add(new SqlParameter("@NVARCHAR4", txtMA_QG.Text));
                }

                if (Cot == 6)
                {
                    lPar.Add(new SqlParameter("@NVARCHAR1", ""));
                    lPar.Add(new SqlParameter("@NVARCHAR2", ""));
                    lPar.Add(new SqlParameter("@NVARCHAR3", ""));
                    lPar.Add(new SqlParameter("@NVARCHAR4", ""));
                    lPar.Add(new SqlParameter("@INT1", 1));
                }
                bool bKiem = Convert.ToBoolean(VsMain.MExecuteScalar("spDanhMuc", lPar));
                if (Convert.ToInt16(bKiem) == 1)
                {
                    if (Cot == 1)
                    {
                        XtraMessageBox.Show(lblMA_QG.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                        txtMA_QG.Focus();
                    }
                    if (Cot == 2)
                    {
                        XtraMessageBox.Show(lblTEN_QG.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                        txtTEN_QG.Focus();
                    }
                    if (Cot == 3)
                    {
                        XtraMessageBox.Show(lblTEN_QG_A.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                        txtTEN_QG_A.Focus();
                    }
                    if (Cot == 4)
                    {
                        XtraMessageBox.Show(lblTEN_QG_H.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                        txtTEN_QG_H.Focus();
                    }
                    if (Cot == 6)
                    {
                        XtraMessageBox.Show(Com.Mod.OS.GetLanguage(this.Name, "msgCheckDaTonTai"), this.Text);
                        txtTEN_QG_H.Focus();
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
        private void btnLuu_Click(object sender, EventArgs e)
        {


            try
            {

                if (!dxValidationProvider1.Validate()) return;
                //kiem ma quoc gia
                if (!KiemTrung(1)) return;
                //kiem ten viet
                if (txtTEN_QG.Text.Trim() != "") if (!KiemTrung(2)) return;
                //kiem ten anh
                if (txtTEN_QG_A.Text.Trim() != "") if (!KiemTrung(3)) return;
                //kiem ten HOA
                if (txtTEN_QG_A.Text.Trim() != "") if (!KiemTrung(4)) return;
                //kiem tra mac dinh
                if (chkMAC_DINH.Checked) if (!KiemTrung(6)) return;

                #region Them
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 3));
                lPar.Add(new SqlParameter("@sDMuc", "mnuQuocGia"));
                lPar.Add(new SqlParameter("@iID", iIDQG));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtMA_QG.Text));
                lPar.Add(new SqlParameter("@NVARCHAR2", txtTEN_QG.Text));
                lPar.Add(new SqlParameter("@NVARCHAR3", txtTEN_QG_A.Text));
                lPar.Add(new SqlParameter("@NVARCHAR4", txtTEN_QG_H.Text));
                lPar.Add(new SqlParameter("@NVARCHAR5", txtGHI_CHU.Text));
                lPar.Add(new SqlParameter("@BIT1", chkMAC_DINH.EditValue));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
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
        #endregion

    }
}