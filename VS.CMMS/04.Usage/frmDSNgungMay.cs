using Com;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;
using VS.CMMS;

namespace VS.ERP
{
    public partial class frmDSNgungMay : DevExpress.XtraEditors.XtraForm
    {
        public frmDSNgungMay()
        {
            InitializeComponent();
        }
        private void frmDSNgungMay_Load(object sender, EventArgs e)
        {
            Com.Mod.sLoad = "0Load";
            datDNgay.DateTime = DateTime.Now;
            datTNgay.DateTime = DateTime.Now.AddMonths(-1);
            LoadCboDiaDiem();
            LoadCboLoaiMay();
            cboDiaDiem.EditValue = Convert.ToInt64(-1);
            Com.Mod.sLoad = "";
            LoadDSNM();
            LoadNN();
        }
        public void LoadNN()
        {
            Com.Mod.OS.ThayDoiNN(this, dataLayoutControl1);
            Com.Mod.OS.MLoadNNXtraGrid(grvDSNgungMay, this.Name);
            Com.Mod.OS.MSaveResertGrid(grvDSNgungMay, this.Name);
        }
        private void LoadCboLoaiMay()
        {
            DataTable dt = new DataTable();

            List<SqlParameter> lPar = new List<SqlParameter>();
            lPar.Add(new SqlParameter("@sDMuc", "LOAI_MAY"));
            lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
            lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
            lPar.Add(new SqlParameter("@All", 1));
            dt = VsMain.MGetDatatable("spGetComBo", lPar);
            Com.Mod.OS.MLoadSearchLookUpEdit(cboLoaiMay, dt, "ID_LM", "TEN_LM", this.Name);
        }
        private void LoadCboDiaDiem()
        {
            DataTable dt = new DataTable();
            List<SqlParameter> lPar = new List<SqlParameter>();
            lPar.Add(new SqlParameter("@sDMuc", "DIA_DIEM"));
            lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
            lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
            lPar.Add(new SqlParameter("@All", 1));
            dt = VsMain.MGetDatatable("spGetComBo", lPar);
            MLoadTreeLookUpEdit(cboDiaDiem, dt, "ID_DD", "TEN_DIA_DIEM", "ID_DD_CHA", this.Name);
        }
        public void MLoadTreeLookUpEdit(TreeListLookUpEdit cbo, DataTable dtTmp, string Ma, string Ten, string Cha, string form, bool isNgonNgu = true)
        {
            try
            {
                cbo.Properties.DataSource = null;
                cbo.Properties.DisplayMember = Ten;
                cbo.Properties.ValueMember = Ma;
                cbo.Properties.DataSource = dtTmp;
                cbo.Properties.TreeList.KeyFieldName = Ma;
                cbo.Properties.TreeList.ParentFieldName = Cha;

                if (!isNgonNgu)
                {
                    return;
                }

                foreach (TreeListColumn column in ((TreeList)cbo.Properties.TreeList).Columns)
                {
                    if (column.Visible)
                    {
                        column.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                        column.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;
                        column.AppearanceHeader.Options.UseTextOptions = true;
                        column.Caption = Mod.OS.GetLanguage(form, column.FieldName);
                    }
                }

                cbo.Refresh();
            }
            catch
            {
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show(cboDiaDiem.EditValue.ToString());
        }
        private void LoadDSNM()
        {
            if (Com.Mod.sLoad == "0Load") return;
            DataTable dt = new DataTable();
            List<SqlParameter> lPar = new List<SqlParameter>();
            lPar.Add(new SqlParameter("@sDMuc", "DS_NGUNG_MAY"));
            lPar.Add(new SqlParameter("@TU_TG", datTNgay.DateTime));
            lPar.Add(new SqlParameter("@DEN_TG", datDNgay.DateTime));
            lPar.Add(new SqlParameter("@iCot1", cboDiaDiem.EditValue));
            lPar.Add(new SqlParameter("@iCot2", cboLoaiMay.EditValue));
            lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
            dt = VsMain.MGetDatatable("spThoiGianDungChayMay", lPar);
            if (grdDSNgungMay.DataSource == null)
            {
                Com.Mod.OS.MLoadXtraGrid(grdDSNgungMay, grvDSNgungMay, dt, false, true, true, true, true, this.Name);
                grvDSNgungMay.Columns["ID_TGDM"].Visible = false;
                grvDSNgungMay.Columns["TU_TG"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
                grvDSNgungMay.Columns["DEN_TG"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
                grvDSNgungMay.Columns["TU_TG"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                grvDSNgungMay.Columns["DEN_TG"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            }
            else
            {
                grdDSNgungMay.DataSource = dt;
            }
        }

        private void datTNgay_EditValueChanged(object sender, EventArgs e)
        {
            LoadDSNM();
        }

        private void grvDSNgungMay_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (grvDSNgungMay.DataSource == null || grvDSNgungMay.RowCount <= 0)
                {
                    this.Close();
                    return;
                }
                if (grvDSNgungMay.RowCount <= 0)
                {
                    this.Close();
                    return;
                }
                Com.Mod.sId = grvDSNgungMay.GetFocusedRowCellValue(grvDSNgungMay.Columns[0]).ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString(), this.Text);
            }
        }
    }
}
