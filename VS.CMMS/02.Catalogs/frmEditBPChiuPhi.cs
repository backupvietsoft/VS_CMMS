using DevExpress.Data.Filtering.Helpers;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraLayout;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.XtraPrinting.Native.ExportOptionsPropertiesNames;

namespace VS.CMMS
{ 
    public partial class frmEditBPChiuPhi : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = -1; // =1: full, <> 1: readonly
        static Boolean AddEdit = true;// true la add false la edit
        static DataRow drRow;
        static Int64 iID_BPCP = -1;
        public frmEditBPChiuPhi(int PQ, DataRow row, Boolean bAddEdit)
        {
            InitializeComponent();

            iPQ = PQ;
            drRow = row;
            AddEdit = bAddEdit;
            VsMain.MFieldRequest(lblTEN_BPCP);
            VsMain.MFieldRequest(lblTT_BPCP);
            VsMain.MFieldRequest(lblMS_BPCP);

            if (drRow != null)
            {
                try { iID_BPCP = Convert.ToInt64(drRow["ID_BPCP"].ToString()); } catch { iID_BPCP = -1; }
            }
            else
            {
                iID_BPCP = -1;
            }
            

            if (iPQ != 1)
            {
                lciGhi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else
            {
                lciGhi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            this.grvChung.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.grvChung_InvalidRowException);
            this.grvChung.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.grvChung_ValidateRow);

        }

        #region Load
        public void LoadNN()
        {
            try
            {
                Com.Mod.OS.ThayDoiNN(this, dataLayoutControl1);
                Com.Mod.OS.MLoadNNXtraGrid(grvChung, this.Name, true);
                Com.Mod.OS.MSaveResertGrid(grvChung, this.Name);
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        private void frmEditBPChiuPhi_Load(object sender, EventArgs e)
        {
            try
            {   
                LoadData();
                LoadCbo();
                if (!AddEdit) LoadText();
                LoadNN();
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        private void LoadText()
        {
            try
            {
                txtTEN_BPCP.Text = drRow["TEN_BPCP"].ToString(); 
                txtTEN_BPCP_A.Text = drRow["TEN_BPCP_A"].ToString();
                txtTEN_BPCP_H.Text = drRow["TEN_BPCP_H"].ToString();
                txtACCOUNT.Text = drRow["ACCOUNT"].ToString();
                txtSUB.Text = drRow["SUB"].ToString();
                txtMS_BPCP.Text = drRow["MS_BPCP"].ToString();
                txtBPCP_MAIL.Text = drRow["BPCP_MAIL"].ToString();
                chkISIT.Checked = Convert.ToBoolean(drRow["ISIT"].ToString());
                txtGHI_CHU.Text = drRow["GHI_CHU"].ToString();
                txtTT_BPCP.Text = drRow["TT_BPCP"].ToString();
                cboID_LCP.EditValue = drRow["ID_LCP"];
                cboID_DV.EditValue = drRow["ID_DV"];
            }
            catch (Exception ex)
            {
                txtTEN_BPCP.Text = "";
                txtTEN_BPCP_A.Text = "";
                txtTEN_BPCP_H.Text = "";
                txtACCOUNT.Text = "";
                txtSUB.Text = "";
                txtMS_BPCP.Text = "";
                txtBPCP_MAIL.Text = "";
                chkISIT.Checked = false;
                txtGHI_CHU.Text = "";
                txtTT_BPCP.Text = "";
                cboID_LCP.EditValue = -1;
                cboID_DV.EditValue = -1;
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        #endregion

        #region Funtion
        private Boolean KiemTrung(int iKiem)
        {
            Boolean bKiem = false;
            try
            {
                #region KiemTrung loai = 4

                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 4));
                lPar.Add(new SqlParameter("@sDMuc", this.Tag));
                lPar.Add(new SqlParameter("@iID", iID_BPCP)); ;
                lPar.Add(new SqlParameter("@INT1", iKiem));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtMS_BPCP.Text));
                lPar.Add(new SqlParameter("@NVARCHAR2", txtTEN_BPCP.Text));
                lPar.Add(new SqlParameter("@NVARCHAR3", txtTEN_BPCP_A.Text));
                lPar.Add(new SqlParameter("@NVARCHAR4", txtTEN_BPCP_H.Text));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                bKiem = Convert.ToBoolean(VsMain.MExecuteScalar("spDanhMuc", lPar));

                #endregion
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return bKiem;
        }
        private void LoadCbo()
        {
            try
            {
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iALL", "1"));
                lPar.Add(new SqlParameter("@iCoALL", -1));
                lPar.Add(new SqlParameter("@sALL", " "));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                lPar.Add(new SqlParameter("@sDanhMuc", "DON_VI;LOAI_CHI_PHI;TT_TY_GIA;"));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet("spGetDataCatalogs", lPar);

                DataTable dt = new DataTable();
                dt = ds.Tables[0].Copy();
                Com.Mod.OS.MLoadSearchLookUpEdit(cboID_DV, dt, "ID_DV", "TEN_DV", this.Name);

                dt = ds.Tables[1].Copy();
                Com.Mod.OS.MLoadSearchLookUpEdit(cboID_LCP, dt, "ID_LCP", "TEN_LCP", this.Name);

                dt = ds.Tables[2].Copy();
                RepositoryItemSearchLookUpEdit cbo = new RepositoryItemSearchLookUpEdit();
                Com.Mod.OS.AddCombSearchLookUpEdit(cbo, "ID_TT", "TEN_TT", grvChung, dt, this.Name);
                cbo.View.Columns["MA_TT"].Visible = false;
                try
                {
                    cbo.EditValueChanged += new System.EventHandler(cboID_TT_EditValueChanged);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, this.Text); 
                }

                RepositoryItemDateEdit datNam = new RepositoryItemDateEdit();
                datNam.CalendarTimeEditing = DefaultBoolean.False;
                datNam.EditMask = "yyyy";
                datNam.DisplayFormat.FormatString = "yyyy";
                datNam.EditFormat.FormatString = "yyyy";
                datNam.CalendarView = CalendarView.Classic;
                datNam.VistaCalendarViewStyle = VistaCalendarViewStyle.YearsGroupView;
                grvChung.Columns["NAM"].Width = 150;
                grvChung.Columns["NAM"].ColumnEdit = datNam;


                RepositoryItemSpinEdit txtTT_KPN = new RepositoryItemSpinEdit();
                grvChung.Columns["TT_KPN"].Width = 150;
                grvChung.Columns["TT_KPN"].ColumnEdit = txtTT_KPN;



            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        private void LoadData()
        {
            try
            {
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@sDMuc", "mnuBPChiuPhi"));
                lPar.Add(new SqlParameter("@iLoai", 7));
                lPar.Add(new SqlParameter("@iID", iID_BPCP));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet("spDanhMuc", lPar);
                DataTable dt = new DataTable();
                dt = ds.Tables[0].Copy();
                grvChung.OptionsMenu.EnableGroupRowMenu = true;
                if (grvChung.DataSource == null)
                {
                    Com.Mod.OS.MLoadXtraGrid(grdChung, grvChung, dt, true, true, false, false);
                    Com.Mod.OS.MSaveResertGrid(grvChung, this.Name);
                    Com.Mod.OS.MFormatCol(grvChung, "SO_TIEN", Com.Mod.iSoLeTT);
                    Com.Mod.OS.MFormatCol(grvChung, "LC_TY_GIA", Com.Mod.iSLTyGia);
                    Com.Mod.OS.MFormatCol(grvChung, "SYS_TY_GIA", Com.Mod.iSLTyGia);
                    Com.Mod.OS.MFormatCol(grvChung, "THANH_TIEN_VND", Com.Mod.iSoLeTT);
                    Com.Mod.OS.MFormatCol(grvChung, "THANH_TIEN_USD", Com.Mod.iSoLeTT);
                    grvChung.Columns["LC_TY_GIA"].OptionsColumn.AllowEdit = true;
                    grvChung.Columns["THANH_TIEN_VND"].OptionsColumn.AllowEdit = true;
                    grvChung.Columns["SYS_TY_GIA"].OptionsColumn.AllowEdit = true;
                    grvChung.Columns["THANH_TIEN_USD"].OptionsColumn.AllowEdit = true;
                }
                else
                    grdChung.DataSource = dt;
            }
            catch { }
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
                    XtraMessageBox.Show(lblMS_BPCP.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtMS_BPCP.Focus();
                    return;
                }
                if (KiemTrung(2))
                {
                    XtraMessageBox.Show(lblTEN_BPCP.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_BPCP.Focus();
                    return;
                }
                if (KiemTrung(3))
                {
                    XtraMessageBox.Show(lblTEN_BPCP_A.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_BPCP_A.Focus();
                    return;
                }
                if (KiemTrung(4))
                {
                    XtraMessageBox.Show(lblTEN_BPCP_H.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_BPCP_H.Focus();
                    return;
                }
                #region Them Sua
                string sBT = "[BPCP" + Com.Mod.UserID + "]";
                Com.Mod.OS.MTableToData(Com.Mod.CNStr, sBT, Com.Mod.OS.ConvertDatatable(grdChung), "");
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 3));
                lPar.Add(new SqlParameter("@sDMuc", this.Tag));
                lPar.Add(new SqlParameter("@iID", iID_BPCP));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtMS_BPCP.Text));
                lPar.Add(new SqlParameter("@INT1", txtTT_BPCP.Text));
                lPar.Add(new SqlParameter("@BIT1", chkISIT.Checked));
                lPar.Add(new SqlParameter("@NVARCHAR2", txtTEN_BPCP.Text));
                lPar.Add(new SqlParameter("@NVARCHAR3", txtTEN_BPCP_A.Text));
                lPar.Add(new SqlParameter("@NVARCHAR4", txtTEN_BPCP_H.Text));
                lPar.Add(new SqlParameter("@NVARCHAR5", txtACCOUNT.Text));
                lPar.Add(new SqlParameter("@BIGINT1", cboID_LCP.EditValue));
                lPar.Add(new SqlParameter("@BIGINT2", cboID_DV.EditValue));
                lPar.Add(new SqlParameter("@NVARCHAR6", txtSUB.Text));
                lPar.Add(new SqlParameter("@NVARCHAR7", txtBPCP_MAIL.Text));
                lPar.Add(new SqlParameter("@NVARCHAR8", txtGHI_CHU.Text));
                lPar.Add(new SqlParameter("@sBT", sBT));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                lPar.Add(new SqlParameter("@FullName", Com.Mod.sTenNhanVienMD));
                DataTable dt_TEMP = VsMain.MGetDatatable("spDanhMuc", lPar);
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
        private void btnKhongGhi_Click(object sender, EventArgs e)
        {
            Com.Mod.sId = "";
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        Double thanhTien;
        private void cboID_TT_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DevExpress.XtraEditors.SearchLookUpEdit cbo = sender as DevExpress.XtraEditors.SearchLookUpEdit;
                grvChung.SetFocusedRowCellValue("ID_TT", cbo.EditValue);
                grvChung.SetFocusedRowCellValue("LC_TY_GIA", cbo.Properties.View.GetFocusedRowCellValue("LC_TY_GIA"));
                grvChung.SetFocusedRowCellValue("SYS_TY_GIA", cbo.Properties.View.GetFocusedRowCellValue("SYS_TY_GIA"));
                try
                {
                    thanhTien = Convert.ToDouble(grvChung.GetFocusedRowCellValue("SO_TIEN")) * Convert.ToDouble(grvChung.GetFocusedRowCellValue("LC_TY_GIA"));
                    grvChung.SetFocusedRowCellValue("THANH_TIEN_USD", thanhTien);

                    thanhTien = Convert.ToDouble(grvChung.GetFocusedRowCellValue("SO_TIEN")) * Convert.ToDouble(grvChung.GetFocusedRowCellValue("SYS_TY_GIA"));
                    grvChung.SetFocusedRowCellValue("THANH_TIEN_VND", thanhTien);
                }
                catch { }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        private void grvChung_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            if (e.Column.FieldName == "SO_TIEN")
            {
                try
                {
                    thanhTien = Convert.ToDouble(grvChung.GetFocusedRowCellValue("SO_TIEN")) * Convert.ToDouble(grvChung.GetFocusedRowCellValue("LC_TY_GIA"));
                    grvChung.SetFocusedRowCellValue("THANH_TIEN_USD", thanhTien);

                    thanhTien = Convert.ToDouble(grvChung.GetFocusedRowCellValue("SO_TIEN")) * Convert.ToDouble(grvChung.GetFocusedRowCellValue("SYS_TY_GIA"));
                    grvChung.SetFocusedRowCellValue("THANH_TIEN_VND", thanhTien);
                }
                catch { }
            }
        }
        private void grvChung_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            grvChung.InvalidRowException += grvChung_InvalidRowException;
            try
            {
                if (Convert.ToString(grvChung.GetFocusedRowCellValue("NAM")) == "")
                {
                    e.Valid = false;
                    XtraMessageBox.Show(Com.Mod.OS.GetLanguage(this.Name, "msgNamKhongDuocTrong"), this.Text);
                    grvChung.FocusedRowHandle = e.RowHandle;
                    grvChung.FocusedColumn = grvChung.Columns["NAM"];
                    return;
                }
                if ((String.IsNullOrEmpty(Convert.ToString(grvChung.GetFocusedRowCellValue("TT_KPN"))) ? 0 : Convert.ToInt32(grvChung.GetFocusedRowCellValue("TT_KPN"))) < 0)
                {
                    e.Valid = false;
                    XtraMessageBox.Show(Com.Mod.OS.GetLanguage(this.Name, "msgSTTKhongDuocNhoHon0"), this.Text);
                    grvChung.FocusedRowHandle = e.RowHandle;
                    grvChung.FocusedColumn = grvChung.Columns["TT_KPN"];
                    return;
                }
                if ((String.IsNullOrEmpty(Convert.ToString(grvChung.GetFocusedRowCellValue("SO_TIEN"))) ? 0 : Convert.ToDouble(grvChung.GetFocusedRowCellValue("SO_TIEN"))) < 0)
                {
                    e.Valid = false;
                    XtraMessageBox.Show(Com.Mod.OS.GetLanguage(this.Name, "msgSoTienKhongDuocNhoHon0"), this.Text);
                    grvChung.FocusedRowHandle = e.RowHandle;
                    grvChung.FocusedColumn = grvChung.Columns["SO_TIEN"];
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        private void grvChung_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }
        private void grvChung_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode != Keys.Delete) return;
                if (grvChung.RowCount == 0 || String.IsNullOrEmpty(Convert.ToString(grvChung.GetFocusedRowCellValue("ID_KPN"))))
                {
                    XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgKhongCoDuLieuDeXoa"), this.Text);
                    return;
                }
                if (XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgBanCoChacXoa"), this.Text, MessageBoxButtons.YesNo) == DialogResult.No) return;

                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 8));
                lPar.Add(new SqlParameter("@sDMuc", this.Tag));
                lPar.Add(new SqlParameter("@iID", Convert.ToInt32(grvChung.GetFocusedRowCellValue("ID_KPN"))));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                Int32 bKiem = Convert.ToInt32(VsMain.MExecuteScalar("spDanhMuc", lPar));
                LoadData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        #endregion
    }
}