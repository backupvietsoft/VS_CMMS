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
using System.Data.SqlClient;
using System.Reflection;

namespace VS.CMMS
{
    public partial class frmEditTienTeTG : DevExpress.XtraEditors.XtraForm
    {
        static Boolean AddEdit = true;  // true la add false la edit
        static DataRow drRow;
        static Int64 iID_TT_TG = -1;
        public frmEditTienTeTG(int PQ, DataRow row, Boolean bAddEdit)
        {
            InitializeComponent();

            drRow = row;
            AddEdit = bAddEdit;
            try
            {
                if (drRow["ID_TT_TG"] == null)
                    iID_TT_TG = -1;
                else
                    iID_TT_TG = Int64.Parse(drRow["ID_TT_TG"].ToString());
            }
            catch { iID_TT_TG = -1; }

            VsMain.MFieldRequest(lblNGAY);
            VsMain.MFieldRequest(lblID_TT);
            VsMain.MFieldRequest(lblSYS_TY_GIA);
            VsMain.MFieldRequest(lblLC_TY_GIA);

        }

        #region Load
        private void frmEditTienTeTG_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            var sqlcom = new SqlCommand();
            var con = new SqlConnection(Com.Mod.CNStr);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                sqlcom.Connection = con;
                sqlcom.Parameters.AddWithValue("iALL", "0");
                sqlcom.Parameters.AddWithValue("NNgu", Com.Mod.iNNgu.ToString());
                sqlcom.Parameters.AddWithValue("@iCoALL", -1);
                sqlcom.Parameters.AddWithValue("sDanhMuc", "TIEN_TE;");
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.CommandText = "spGetDataCatalogs";
                var da = new SqlDataAdapter(sqlcom);
                var ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0].Copy();
                Com.Mod.OS.MLoadSearchLookUpEdit(cboID_TT, dt, "ID_TT", "TEN_TT", this.Name);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
            if (!AddEdit) LoadText(false); else LoadText(true);
            LoadNN();
        }
        private void LoadNN()
        {

            Com.Mod.OS.ThayDoiNN(this, dataLayoutControl2);
        }
        private void LoadText(Boolean LoadNull)
        {
            datNGAY.ReadOnly = false;
            cboID_TT.ReadOnly = false;
            if (LoadNull)
            {
                AddEdit = true;
                datNGAY.DateTime = DateTime.Now.Date;
                cboID_TT.EditValue = "-1";
                txtSYS_TY_GIA.Text = "";
                txtLC_TY_GIA.Text = "";
                txtID_TT_TG.Text = "-1";
            }
            else
            {
                try
                {
                    datNGAY.DateTime = Convert.ToDateTime(drRow["NGAY"].ToString());
                    cboID_TT.EditValue = drRow["ID_TT"].ToString();
                    txtSYS_TY_GIA.Text = drRow["SYS_TY_GIA"].ToString();
                    txtLC_TY_GIA.Text = drRow["LC_TY_GIA"].ToString();
                    txtID_TT_TG.EditValue = drRow["ID_TT_TG"];
                    datNGAY.ReadOnly = true;
                    cboID_TT.ReadOnly = true;
                }
                catch (Exception ex)
                {
                    datNGAY.DateTime = DateTime.Now.Date; cboID_TT.EditValue = "-1"; txtSYS_TY_GIA.Text = ""; txtLC_TY_GIA.Text = ""; txtID_TT_TG.Text = "-1";
                    XtraMessageBox.Show(ex.Message, this.Text);
                }

            }

            this.txtSYS_TY_GIA.Properties.Mask.EditMask = "n" + Com.Mod.iSLTyGia;
            this.txtLC_TY_GIA.Properties.Mask.EditMask = "n" + Com.Mod.iSLTyGia;
        }
        #endregion

        #region Event
       
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion

        private void btnGhi_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dxValidationProvider1.Validate()) return;
                if (!dxValidationProvider2.Validate()) return;
                if (AddEdit)
                {
                    string sSql = "SELECT TOP 1 * FROM dbo.TIEN_TE_TG WHERE ID_TT = " + cboID_TT.EditValue.ToString() + " AND NGAY = '" + datNGAY.DateTime.Date.ToString("MM/dd/yyyy") + "' ";
                    DataTable dt = new DataTable();
                    dt.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Com.Mod.CNStr, CommandType.Text, sSql));
                    if (dt.Rows.Count > 0)
                    {
                        XtraMessageBox.Show(Com.Mod.OS.GetLanguage(this.Name, "msgTyGiaCuaNgoaiTeNayDaCo"), this.Text);
                        return;
                        ////////iID_TT_TG = Int64.Parse(dt.Rows[0]["ID_TT_TG"].ToString());
                        ////////txtID_TT_TG.Text = iID_TT_TG.ToString();
                    }
                }
                #region Them
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 3));
                lPar.Add(new SqlParameter("@sDMuc", this.Tag));
                lPar.Add(new SqlParameter("@iID", iID_TT_TG));
                lPar.Add(new SqlParameter("@DATETIME1", datNGAY.DateTime));
                lPar.Add(new SqlParameter("@iIDQG", cboID_TT.EditValue.ToString()));
                lPar.Add(new SqlParameter("@NVARCHAR2", string.IsNullOrEmpty(txtLC_TY_GIA.EditValue.ToString()) ? "0" : txtLC_TY_GIA.EditValue));
                lPar.Add(new SqlParameter("@NVARCHAR3", string.IsNullOrEmpty(txtSYS_TY_GIA.EditValue.ToString()) ? "0" : txtSYS_TY_GIA.EditValue));
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