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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using DevExpress.XtraEditors.Repository;

namespace VS.CMMS
{
    public partial class frmEditDiaDiem : DevExpress.XtraEditors.XtraForm
    {
        static Boolean AddEdit = true;  // true la add false la edit
        static DataRow drRow;
        static Int64 iID_DD = -1;
        static Int64 iID_DD_CHA = -1;
        static Int32 iPQ = -1;
        public frmEditDiaDiem(int PQ, DataRow row, Boolean bAddEdit, Int64 ID_DDIEM)
        {
            InitializeComponent();
            drRow = row;
            AddEdit = bAddEdit;
            iPQ = PQ;
            if (drRow != null)
            {
                try { iID_DD = Convert.ToInt64(drRow["ID_DD"].ToString()); } catch { iID_DD = -1; }
            }
            else
            {
                iID_DD = -1;
                iID_DD_CHA = ID_DDIEM;
            }
            VsMain.MFieldRequest(lblMS_DD);
            VsMain.MFieldRequest(lblTEN_DIA_DIEM);
            txtDIEN_THOAI.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            txtDIEN_THOAI.Properties.Mask.EditMask = "###########";

            this.tabChung.SelectedPageChanged += new DevExpress.XtraLayout.LayoutTabPageChangedEventHandler(this.tabChung_SelectedPageChanged);
            this.tabChung.SelectedPageChanged += new DevExpress.XtraLayout.LayoutTabPageChangedEventHandler(this.tabChung_SelectedPageChanged);

        }
        #region Load
        private void frmEditDiaDiem_Load(object sender, EventArgs e)
        {
            AddEvent();
            LoadCboDDiem();
            LoadCboQG();
            LoadText();
            LoadGrv();
            LoadNN();
            tabChung.SelectedTabPageIndex = 0;
        }
        private void LoadNN()
        {
            Com.Mod.OS.ThayDoiNN(this, dataLayoutControl1);
            Com.Mod.OS.ThayDoiNN(this,Root);
            Com.Mod.OS.MLoadNNXtraGrid(grvTaiLieu, this.Name, true);
        }
        private void LoadText()
        {
            try
            {
                if (!AddEdit)
                {
                    cboID_DD_CHA.EditValue = drRow["ID_DD_CHA"].ToString() == "" ? -1 : Convert.ToInt64(drRow["ID_DD_CHA"].ToString());
                    txtMS_DD.EditValue = drRow["MS_DD"].ToString();
                    txtTEN_DIA_DIEM.EditValue = drRow["TEN_DIA_DIEM"].ToString();
                    txtTEN_DIA_DIEM_A.EditValue = drRow["TEN_DIA_DIEM_A"].ToString();
                    txtTEN_DIA_DIEM_H.EditValue = drRow["TEN_DIA_DIEM_H"].ToString();
                    txtNGUOI_PHU_TRACH.EditValue = drRow["NGUOI_PHU_TRACH"].ToString();
                    txtDIEN_THOAI.EditValue = drRow["DIEN_THOAI"].ToString();
                    txtDIA_CHI.EditValue = drRow["DIA_CHI"].ToString();
                    txtTT_DD.EditValue = drRow["TT_DD"].ToString();
                    cboID_QG.EditValue = drRow["ID_QG"].ToString() == "" ? -1 : Convert.ToInt64(drRow["ID_QG"].ToString());
                    cboID_TP.EditValue = drRow["ID_TP"].ToString() == "" ? -1 : Convert.ToInt64(drRow["ID_TP"].ToString());
                    cboID_QH.EditValue = drRow["ID_QH"].ToString() == "" ? -1 : Convert.ToInt64(drRow["ID_QH"].ToString());
                }
                else
                {
                    cboID_DD_CHA.EditValue = iID_DD_CHA;
                    cboID_QG.EditValue = -1;
                    cboID_QH.EditValue = -1;
                    cboID_TP.EditValue = -1;
                    txtMS_DD.Text = "";
                    txtTEN_DIA_DIEM.Text = "";
                    txtTEN_DIA_DIEM_A.Text = "";
                    txtTEN_DIA_DIEM_H.Text = "";
                    txtNGUOI_PHU_TRACH.Text = "";
                    txtDIEN_THOAI.Text = "";
                    txtDIA_CHI.Text = "";
                    txtTT_DD.Text = "";
                }

            }
            catch (Exception ex)
            {
                cboID_DD_CHA.EditValue = iID_DD_CHA;
                cboID_QG.EditValue = -1;
                cboID_QH.EditValue = -1;
                cboID_TP.EditValue = -1;
                txtMS_DD.Text = "";
                txtTEN_DIA_DIEM.Text = "";
                txtTEN_DIA_DIEM_A.Text = "";
                txtTEN_DIA_DIEM_H.Text = "";
                txtNGUOI_PHU_TRACH.Text = "";
                txtDIEN_THOAI.Text = "";
                txtDIA_CHI.Text = "";
                txtTT_DD.Text = "";
            }
        }
        private void LoadCboGrv()
        {
            try
            {
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 9));
                lPar.Add(new SqlParameter("@sDMuc", "mnuDDiem"));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet("spDanhMuc01", lPar);
                DataTable dt = new DataTable();
                dt = ds.Tables[0].Copy();
                DataTable dtNV = new DataTable();
                dtNV = ds.Tables[1].Copy();
                DataTable dtLG = new DataTable();
                dtLG = ds.Tables[2].Copy();

                RepositoryItemSearchLookUpEdit cbo = new RepositoryItemSearchLookUpEdit();
                cbo.QueryPopUp += new CancelEventHandler(cboID_USER_QueryPopUp);
                Com.Mod.OS.AddCombSearchLookUpEdit(cbo, "ID_USER", "USER_NAME", grvNLH, dt, this.Name);

                RepositoryItemSearchLookUpEdit cboNV = new RepositoryItemSearchLookUpEdit();
                cboNV.QueryPopUp += new CancelEventHandler(cboID_NV_QueryPopUp);
                Com.Mod.OS.AddCombSearchLookUpEdit(cboNV, "ID_NV", "TEN_NV", grvNLH, dtNV, this.Name);

                RepositoryItemSearchLookUpEdit cboLG = new RepositoryItemSearchLookUpEdit();
                Com.Mod.OS.AddCombSearchLookUpEdit(cboLG, "ID_LG", "TEN_LG", grvNLH, dtLG, this.Name);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        private void LoadCboQG()
        {
            try
            {
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iALL", "1"));
                lPar.Add(new SqlParameter("@iCoALL",0));
                lPar.Add(new SqlParameter("@sALL", ""));
                lPar.Add(new SqlParameter("@iID1", cboID_QG.Text == "" ? -1 : Convert.ToInt64(cboID_QG.EditValue)));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                lPar.Add(new SqlParameter("@sDanhMuc", "QUOC_GIA;"));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet("spGetDataCatalogs", lPar);
                DataTable dt = new DataTable();

                dt = ds.Tables[0].Copy();
                Com.Mod.OS.MLoadSearchLookUpEdit(cboID_QG, dt, "ID_QG", "TEN_QG", this.Name);
                cboID_QG.Properties.View.Columns["ID_QG"].Visible = false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        private void LoadCboTP()
        {
            try
            {
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iALL", "1"));
                lPar.Add(new SqlParameter("@iCoALL", 0));
                lPar.Add(new SqlParameter("@sALL", ""));
                lPar.Add(new SqlParameter("@iID1", cboID_QG.Text == "" ? -1 : Convert.ToInt64(cboID_QG.EditValue)));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                lPar.Add(new SqlParameter("@sDanhMuc", "THANH_PHO;"));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet("spGetDataCatalogs", lPar);
                DataTable dt = new DataTable();

                dt = ds.Tables[0].Copy();
                Com.Mod.OS.MLoadSearchLookUpEdit(cboID_TP, dt, "ID_TP", "TEN_TP", this.Name);
                cboID_TP.Properties.View.Columns["ID_TP"].Visible = false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        private void LoadCboQH()
        {
            try
            {
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iALL", "1"));
                lPar.Add(new SqlParameter("@iCoALL", 0));
                lPar.Add(new SqlParameter("@sALL", ""));
                lPar.Add(new SqlParameter("@iID1", cboID_TP.Text == "" ? -1 : Convert.ToInt64(cboID_TP.EditValue)));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                lPar.Add(new SqlParameter("@sDanhMuc", "QUAN_HUYEN;"));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet("spGetDataCatalogs", lPar);
                DataTable dt = new DataTable();

                dt = ds.Tables[0].Copy();
                Com.Mod.OS.MLoadSearchLookUpEdit(cboID_QH, dt, "ID_QH", "TEN_QH", this.Name);
                cboID_QH.Properties.View.Columns["ID_QH"].Visible = false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        private void LoadCboDDiem()
        {
            try
            {
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iALL", "1"));
                lPar.Add(new SqlParameter("@iCoALL",0));
                lPar.Add(new SqlParameter("@sALL", ""));
                lPar.Add(new SqlParameter("@iID1", iID_DD));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                lPar.Add(new SqlParameter("@sDanhMuc", "DIA_DIEM;"));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet("spGetDataCatalogs", lPar);
                DataTable dt = new DataTable();
                dt = ds.Tables[0].Copy();
                Com.Mod.OS.MLoadSearchLookUpEdit(cboID_DD_CHA, dt, "ID_DD", "TEN_DIA_DIEM", this.Name);
                cboID_DD_CHA.Properties.View.Columns["TT_DD"].Visible = false;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        private void AddEvent()
        {
            this.cboID_TP.EditValueChanged += new System.EventHandler(this.cboID_TP_EditValueChanged);
            this.cboID_QG.EditValueChanged += new System.EventHandler(this.cboID_QG_EditValueChanged);
            this.grvTaiLieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvTaiLieu_KeyDown);
            this.grvNLH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvNLH_KeyDown);
            this.grvTaiLieu.DoubleClick += new System.EventHandler(this.grvTaiLieu_DoubleClick);

        }
        private void LoadGrv()
        {
            try
            {
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 8));
                lPar.Add(new SqlParameter("@iID", iID_DD));
                lPar.Add(new SqlParameter("@sDMuc", "mnuDDiem"));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet("spDanhMuc01", lPar);
                DataTable dt = new DataTable();
                if (tabChung.SelectedTabPageIndex == 0)
                {
                    dt = (DataTable)grdTaiLieu.DataSource;
                    LoadData_grvTaiLieu(ds.Tables[0]);
                }
                if (tabChung.SelectedTabPageIndex == 1)
                {
                    dt = (DataTable)grdNLH.DataSource;
                    LoadData_grvNLH(ds.Tables[1]);
                    LoadCboGrv();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        private void LoadData_grvTaiLieu(DataTable dt)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (grdTaiLieu.DataSource == null)
                {
                    Com.Mod.OS.MLoadXtraGrid(grdTaiLieu, grvTaiLieu, dt, true, false, true, true);
                    Com.Mod.OS.MLoadNNXtraGrid(grvTaiLieu, this.Name);
                    Com.Mod.OS.MSaveResertGrid(grvTaiLieu, this.Name);


                    grvTaiLieu.Columns["ID_DD_TL"].Visible = false;
                    grvTaiLieu.Columns["ID_DD"].Visible = false;

                    for (int i = 0; i < grvTaiLieu.Columns.Count; i++)
                    {
                        grvTaiLieu.Columns[i].OptionsColumn.AllowEdit = false;
                    }

                    grvTaiLieu.Columns["TEN_TL"].OptionsColumn.AllowEdit = true;
                    grvTaiLieu.Columns["GHI_CHU"].OptionsColumn.AllowEdit = true;

                }
                else
                    grdTaiLieu.DataSource = dt;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
            this.Cursor = Cursors.Default;
        }
        private void LoadData_grvNLH(DataTable dt)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (grdNLH.DataSource == null)
                {
                    Com.Mod.OS.MLoadXtraGrid(grdNLH, grvNLH, dt, true, false, true, true);
                    Com.Mod.OS.MLoadNNXtraGrid(grvNLH, this.Name);
                    Com.Mod.OS.MSaveResertGrid(grvNLH, this.Name);

                    grvNLH.Columns["ID_NLH"].Visible = false;
                    grvNLH.Columns["ID_DD"].Visible = false;

                    for (int i = 0; i < grvNLH.Columns.Count; i++)
                    {
                        grvNLH.Columns[i].OptionsColumn.AllowEdit = true;
                    }
                }
                else
                    grdNLH.DataSource = dt;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
            this.Cursor = Cursors.Default;
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
                lPar.Add(new SqlParameter("@sDMuc", "mnuDDiem"));
                lPar.Add(new SqlParameter("@iLoai", 4));
                lPar.Add(new SqlParameter("@iID", iID_DD));
                lPar.Add(new SqlParameter("@INT1", iKiem));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtTEN_DIA_DIEM.Text));
                lPar.Add(new SqlParameter("@NVARCHAR2", txtTEN_DIA_DIEM_A.Text));
                lPar.Add(new SqlParameter("@NVARCHAR3", txtTEN_DIA_DIEM_H.Text));
                lPar.Add(new SqlParameter("@NVARCHAR4", txtMS_DD.Text));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                bKiem = Convert.ToBoolean(VsMain.MExecuteScalar("spDanhMuc01", lPar));
                #endregion
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return bKiem;
        }
        private void DeleteAllFile_grvTaiLieu()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = (DataTable)grdTaiLieu.DataSource;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Com.Mod.OS.DeleteFileToServer(string.IsNullOrEmpty(Convert.ToString(dt.Rows[i]["DUONG_DAN_DD"])) ? "" : Convert.ToString(dt.Rows[i]["DUONG_DAN_DD"]));
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        private void SaveData_grvTaiLieu()
        {
            //CAP NHAP VAO CSDL 
            try
            {
                if (iID_DD == -1 || iPQ != 1) return;
                this.Cursor = Cursors.WaitCursor;
                string sBTTL = "[DDTL" + Com.Mod.UserID + "]";
                Com.Mod.OS.MTableToData(Com.Mod.CNStr, sBTTL, (DataTable)grdTaiLieu.DataSource, "");
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 10));
                lPar.Add(new SqlParameter("@iID", iID_DD));
                lPar.Add(new SqlParameter("@sDMuc", "mnuDDiem"));
                lPar.Add(new SqlParameter("@sBT1", sBTTL));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet("spDanhMuc01", lPar);
                DataTable dt_TEMP = new DataTable();
                dt_TEMP = ds.Tables[0].Copy();
                Int64 iTEMP = string.IsNullOrEmpty(Convert.ToString(dt_TEMP.Rows[0][0])) ? 0 : Convert.ToInt64(dt_TEMP.Rows[0][0]);
                string sTEMP = string.IsNullOrEmpty(Convert.ToString(dt_TEMP.Rows[0][1])) ? "" : Convert.ToString(dt_TEMP.Rows[0][1]);
                if (iTEMP > 0)
                {
                    Program.MBarCapNhapThanhCong();
                }
                else
                {
                    XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgGhiKhongThanhCong") + "\n" + sTEMP, this.Text);
                    Program.MBarCapNhapKhongThanhCong();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgGhiKhongThanhCong") + "\n" + ex.Message, this.Text);
                Program.MBarCapNhapKhongThanhCong();
            }
            this.Cursor = Cursors.Default;
        }
        #endregion



        #region Event
        private void btnGhi_Click(object sender, EventArgs e)
        {
            #region Them Sua
             if (!dxValidationProvider1.Validate()) return;
            if (KiemTrung(1))
            {
                XtraMessageBox.Show(lblTEN_DIA_DIEM.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                txtTEN_DIA_DIEM.Focus();
                return;
            }
            if (KiemTrung(2) && txtTEN_DIA_DIEM_A.Text != "")
            {
                XtraMessageBox.Show(lblTEN_DIA_DIEM_A.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                txtTEN_DIA_DIEM_A.Focus();
                return;
            }
            if (KiemTrung(3) && txtTEN_DIA_DIEM_H.Text != "")
            {
                XtraMessageBox.Show(lblTEN_DIA_DIEM_H.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                txtTEN_DIA_DIEM_H.Focus();
                return;
            }
            if (KiemTrung(4)&& txtMS_DD.Text != "")
            {
                XtraMessageBox.Show(lblMS_DD.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                txtMS_DD.Focus();
                return;
            }
            try
            {
                string sDDTL = "[sDDTL" + Com.Mod.UserID + "]";
                Com.Mod.OS.MTableToData(Com.Mod.CNStr, sDDTL, grdTaiLieu.DataSource as DataTable, "");
                string sDDNLH = "[sDDNLH" + Com.Mod.UserID + "]";
                Com.Mod.OS.MTableToData(Com.Mod.CNStr, sDDNLH, grdNLH.DataSource as DataTable, "");
                long? result = null;
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 3));
                lPar.Add(new SqlParameter("@sDMuc", "mnuDDiem"));
                lPar.Add(new SqlParameter("@iID", iID_DD));
                lPar.Add(new SqlParameter("@BIGINT1", cboID_DD_CHA.Text == ""? result : Convert.ToInt64(cboID_DD_CHA.EditValue)));
                lPar.Add(new SqlParameter("@BIGINT2", cboID_QG.Text == "" ? result : Convert.ToInt64(cboID_QG.EditValue)));
                lPar.Add(new SqlParameter("@BIGINT3", cboID_TP.Text == "" ? result : Convert.ToInt64(cboID_TP.EditValue)));
                lPar.Add(new SqlParameter("@BIGINT4", cboID_QH.Text == "" ? result : Convert.ToInt64(cboID_QH.EditValue)));
                lPar.Add(new SqlParameter("@NVARCHAR1", txtMS_DD.Text));
                lPar.Add(new SqlParameter("@NVARCHAR2", txtTEN_DIA_DIEM.Text));
                lPar.Add(new SqlParameter("@NVARCHAR3", txtTEN_DIA_DIEM_A.Text));
                lPar.Add(new SqlParameter("@NVARCHAR4", txtTEN_DIA_DIEM_H.Text));
                lPar.Add(new SqlParameter("@NVARCHAR5", txtNGUOI_PHU_TRACH.Text));
                lPar.Add(new SqlParameter("@NVARCHAR6", txtDIEN_THOAI.Text));
                lPar.Add(new SqlParameter("@NVARCHAR7", txtDIA_CHI.Text));
                lPar.Add(new SqlParameter("@INT1", txtTT_DD.Text));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                lPar.Add(new SqlParameter("@FullName", Com.Mod.sTenNhanVienMD));
                lPar.Add(new SqlParameter("@sBT1", sDDTL));
                lPar.Add(new SqlParameter("@sBT2", sDDNLH));
                Com.Mod.sId = Convert.ToString(VsMain.MExecuteScalar("spDanhMuc01", lPar));
                if (Com.Mod.sId == "-1")
                {
                    XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgThemSuaKhongThanhCong"), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Com.Mod.OS.XoaTable(sDDTL);
                Com.Mod.OS.XoaTable(sDDNLH);
            }catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
            #endregion
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cboID_TP_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (Com.Mod.sLoad == "0Load") return;
                LoadCboQH();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        private void cboID_QG_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (Com.Mod.sLoad == "0Load") return;
                LoadCboTP();
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.Message, this.Text); }
        }
        private void cboID_USER_QueryPopUp(object sender, CancelEventArgs e)
        {
            try
            {
                object idNhanVienObj = grvNLH.GetRowCellValue(grvNLH.FocusedRowHandle, "ID_NV");
                if (idNhanVienObj == null || idNhanVienObj == DBNull.Value || string.IsNullOrWhiteSpace(idNhanVienObj.ToString()))
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        private void cboID_NV_QueryPopUp(object sender, CancelEventArgs e)
        {
            try
            {
                object idNhanVienObj = grvNLH.GetRowCellValue(grvNLH.FocusedRowHandle, "ID_USER");
                if (idNhanVienObj == null || idNhanVienObj == DBNull.Value || string.IsNullOrWhiteSpace(idNhanVienObj.ToString()))
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        private void btnTaiLieu_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dxValidationProvider1.Validate())
                {
                    XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgChuaNhapDuDuLieu"), this.Text);
                    return;
                }

                Com.Mod.MFileServer mFile;
                mFile = Com.Mod.OS.CopyFileToServer("DiaDiem\\DiaDiemTL", txtTEN_DIA_DIEM.Text);

                if (mFile.sfilegoc.Count <= 0) return;

                this.Cursor = Cursors.WaitCursor;

                string sPath, sPathGoc;

                DataTable dt = (DataTable)grdTaiLieu.DataSource;
                for (int i = 0; i < mFile.sfilegoc.Count; i++)
                {
                    sPath = mFile.sfilegoc[i].ToString();
                    sPathGoc = mFile.sfilegoc[i].ToString();
                    DataRow row = ((DataTable)grdTaiLieu.DataSource).NewRow();
                    row["ID_DD_TL"] = grvTaiLieu.RowCount + 1;
                    row["ID_DD"] = iID_DD;
                    row["DUONG_DAN_DD"] = mFile.sfileserver[i].ToString();
                    row["DUONG_DAN_GOC"] = mFile.sfilegoc[i].ToString();
                    row["TEN_TL"] = System.IO.Path.GetFileName(mFile.sfilegoc[i].ToString());
                    row["COMPUTER_UP"] = Environment.MachineName;
                    row["USER_UP"] = Com.Mod.UName;
                    row["TIME_UP"] = DateTime.Now;
                    dt.Rows.Add(row);
                }
                dt.AcceptChanges();

                SaveData_grvTaiLieu();

            }
            catch
            {
                XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgBanKhongCoQuyenTruyCapDD"), this.Text, MessageBoxButtons.OK);
            }
            this.Cursor = Cursors.Default;
        }
        private void tabChung_SelectedPageChanged(object sender, DevExpress.XtraLayout.LayoutTabPageChangedEventArgs e)
        {
            try
            {
                if (Com.Mod.sLoad == "0Load") return;
                LoadGrv();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        private void grvTaiLieu_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode != Keys.Delete || iID_DD == -1 || iPQ != 1) return;
                if (XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgDeleteTaiLieuDongDangChon"), this.Text, MessageBoxButtons.YesNo) == DialogResult.No) return;
                this.Cursor = Cursors.WaitCursor;

                Int64 iID_DDTL = string.IsNullOrEmpty(Convert.ToString(grvTaiLieu.GetFocusedRowCellValue("ID_DD_TL"))) ? 0 : Convert.ToInt64(grvTaiLieu.GetFocusedRowCellValue("ID_DD_TL"));
                List<SqlParameter> lPar = new List<SqlParameter>();
                {
                    lPar.Add(new SqlParameter("@iLoai", 11));
                    lPar.Add(new SqlParameter("@sDMuc", "mnuDDiem"));
                    lPar.Add(new SqlParameter("@iID", iID_DDTL));
                    lPar.Add(new SqlParameter("@INT1", Convert.ToInt32(tabChung.SelectedTabPageIndex)));
                    lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                    lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                };
                DataTable dtTEMP = new DataTable(); 
                dtTEMP = VsMain.MGetDatatable("spDanhMuc01", lPar);
                int iTEMP = string.IsNullOrEmpty(Convert.ToString(dtTEMP.Rows[0][0])) ? 0 : Convert.ToInt32(dtTEMP.Rows[0][0]);

                if (iTEMP > 0)
                {
                    Com.Mod.OS.DeleteFileToServer(grvTaiLieu.GetFocusedRowCellValue("DUONG_DAN_DD").ToString());
                    grvTaiLieu.DeleteSelectedRows();
                    ((DataTable)grdTaiLieu.DataSource).AcceptChanges();
                }
                else
                {
                    XtraMessageBox.Show(Com.Mod.OS.GetLanguage(this.Name, "msgXoaThatBai"), this.Text);
                    Program.MBarXoaKhongThanhCong();
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Com.Mod.OS.GetLanguage(this.Name, "msgXoaThatBai") + "\n" + ex.Message, this.Text);
                Program.MBarXoaKhongThanhCong();
            }
            this.Cursor = Cursors.Default;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if(Convert.ToInt32(tabChung.SelectedTabPageIndex) == 0)
                {
                    if (XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgDeleteTatCaTaiLieu"), this.Text, MessageBoxButtons.YesNo) == DialogResult.No) return;
                }
                if (Convert.ToInt32(tabChung.SelectedTabPageIndex) == 1)
                {
                    if (XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgDeleteTatCaNLH"), this.Text, MessageBoxButtons.YesNo) == DialogResult.No) return;
                }
                this.Cursor = Cursors.WaitCursor;

                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 12));
                lPar.Add(new SqlParameter("@iID", iID_DD));
                lPar.Add(new SqlParameter("@sDMuc", "mnuDDiem"));
                lPar.Add(new SqlParameter("@INT1", Convert.ToInt32(tabChung.SelectedTabPageIndex)));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                DataTable dtTEMP = new DataTable();
                dtTEMP = VsMain.MGetDatatable("spDanhMuc01", lPar);
                int iTEMP = string.IsNullOrEmpty(Convert.ToString(dtTEMP.Rows[0][0])) ? 0 : Convert.ToInt32(dtTEMP.Rows[0][0]);
                if (iTEMP > 0)
                {
                    DeleteAllFile_grvTaiLieu();
                    grvTaiLieu.DeleteSelectedRows();
                    ((DataTable)grdTaiLieu.DataSource).AcceptChanges();
                }
                else
                {
                    XtraMessageBox.Show(Com.Mod.OS.GetLanguage(this.Name, "msgXoaThatBai"), this.Text);
                    Program.MBarXoaKhongThanhCong();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        private void grvNLH_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode != Keys.Delete || iID_DD == -1 || iPQ != 1) return;
                if (XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgDeleteNLHDongDangChon"), this.Text, MessageBoxButtons.YesNo) == DialogResult.No) return;
                this.Cursor = Cursors.WaitCursor;
                Int64 iID_NLH = string.IsNullOrEmpty(Convert.ToString(grvNLH.GetFocusedRowCellValue("ID_NLH"))) ? 0 : Convert.ToInt64(grvNLH.GetFocusedRowCellValue("ID_NLH"));
                List<SqlParameter> lPar = new List<SqlParameter>();
                {
                    lPar.Add(new SqlParameter("@iLoai", 11));
                    lPar.Add(new SqlParameter("@sDMuc", "mnuDDiem"));
                    lPar.Add(new SqlParameter("@iID", iID_NLH));
                    lPar.Add(new SqlParameter("@INT1", Convert.ToInt32(tabChung.SelectedTabPageIndex)));
                    lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                    lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                };
                DataTable dtTEMP = new DataTable();
                dtTEMP = VsMain.MGetDatatable("spDanhMuc01", lPar);
                int iTEMP = string.IsNullOrEmpty(Convert.ToString(dtTEMP.Rows[0][0])) ? 0 : Convert.ToInt32(dtTEMP.Rows[0][0]);

                if (iTEMP > 0)
                {
                    
                    grvNLH.DeleteSelectedRows();
                    ((DataTable)grdTaiLieu.DataSource).AcceptChanges();
                }
                else
                {
                    XtraMessageBox.Show(Com.Mod.OS.GetLanguage(this.Name, "msgXoaThatBai"), this.Text);
                    Program.MBarXoaKhongThanhCong();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        private void grvTaiLieu_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (iID_DD == -1) return;
                if (string.IsNullOrWhiteSpace(grvTaiLieu.GetFocusedRowCellValue("DUONG_DAN_DD").ToString())) return;
                this.Cursor = Cursors.WaitCursor;
                Com.Mod.OS.OpenHinhServer(grvTaiLieu.GetFocusedRowCellValue("DUONG_DAN_DD").ToString());
            }
            catch
            {
                return;
            }
            this.Cursor = Cursors.Default;
        }
        #endregion
    }
}
