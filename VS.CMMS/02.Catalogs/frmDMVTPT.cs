using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraRichEdit.Model;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VS.CMMS
{
    public partial class frmDMVTPT : DevExpress.XtraEditors.XtraForm
    {
        IEnumerable<Control> allControls;
        Int64 iID_PT = -1;
        static int iPQ = 1;
        public frmDMVTPT(int PQ, string Find, string SP)
        {
            InitializeComponent();
            VsMain.MFieldRequest(lblMS_PT);
            VsMain.MFieldRequest(lblTEN_PT);
            VsMain.MFieldRequest(lblID_LPT);
            VsMain.MFieldRequest(lblDVT);
        }
        private void frmDMVTPT_Load(object sender, EventArgs e)
        {
            try
            {
                tabDMVTPT.SelectedTabPage = tabPTK;
                LoadCbo();
                LoadData();
                LoadNN();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
        }
        private void txtMS_PT_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            LoadView();
        }
        private void LoadView()
        {
            try
            {
                XtraForm ctl = new XtraForm();
                Type newType = Type.GetType("VS.CMMS.frmView", true, true);
                object o1 = Activator.CreateInstance(newType, Com.Mod.UserID, "", "spDMPT");
                ctl = o1 as XtraForm;
                ctl.WindowState = FormWindowState.Maximized;
                Com.Mod.sPS = "mnuDMVTPT";
                ctl.Tag = "mnuDMVTPTView";
                ctl.Text = Com.Mod.OS.GetLanguage("frmDMVTPTView", "frmDMVTPTView");
                ctl.Name = "frmDMVTPTView";
                if (ctl.ShowDialog() == DialogResult.OK)
                {
                    iID_PT = Convert.ToInt64(Com.Mod.sId);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
        }
        private void LoadgrvPhuTungThayThe(DataTable dt)
        {
            try
            {
                if (grvPTTD.DataSource == null)
                {
                    Com.Mod.OS.MLoadXtraGrid(grdPTTD, grvPTTD, dt, true, true, false, false);
                }
                else
                    grdPTTD.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
        }
        private void LoadgrvPhuTungKho(DataTable dt)
        {
            try
            {
                grvPTK.OptionsMenu.EnableGroupRowMenu = true;
                if (grvPTK.DataSource == null)
                {
                    Com.Mod.OS.MLoadXtraGrid(grdPTK, grvPTK, dt, true, true, false, false);
                    for (int i = 0; i < grvPTK.Columns.Count; i++)
                    {
                        grvPTK.Columns[i].OptionsColumn.AllowEdit = false;
                    }
                    grvPTK.Columns["TON_TOI_THIEU"].OptionsColumn.AllowEdit = true;
                    grvPTK.Columns["TON_TOI_DA"].OptionsColumn.AllowEdit = true;
                    grvPTK.Columns["LEAD_TIME"].OptionsColumn.AllowEdit = true;

                }
                else
                    grdPTK.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
        }
        private void LoadgrvLoaiThietBi(DataTable dt)
        {
            try
            {
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iALL", "1"));
                lPar.Add(new SqlParameter("@iCoALL", -1));
                lPar.Add(new SqlParameter("@sALL", " "));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                lPar.Add(new SqlParameter("@sDanhMuc", "KHO;LOAI_CHI_PHI;TT_TY_GIA;"));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet("spGetDataCatalogs", lPar);

                Com.Mod.OS.MLoadXtraGrid(grdLTB, grvLTB, dt, true, true, true, true, true, this.Name);
                grvLTB.OptionsMenu.EnableGroupRowMenu = true;
                if (grvLTB.DataSource == null)
                {
                    Com.Mod.OS.MLoadXtraGrid(grdLTB, grvLTB, dt, true, true, false, false);
                }
                else
                    grdLTB.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
        }
        private void LoadGrv()
        {
            try
            {
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 2));
                lPar.Add(new SqlParameter("@ID_PT", iID_PT));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet("spDMPT", lPar);
                DataTable dt = new DataTable();
                LoadgrvPhuTungKho(ds.Tables[3]);
                LoadgrvPhuTungThayThe(ds.Tables[1]);
                Com.Mod.sLoad = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
        }
        private void LoadData()
        {
            Com.Mod.sLoad = "0Load";

            DataSet ds = new DataSet();
            try
            {
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 2));
                lPar.Add(new SqlParameter("@ID_PT", iID_PT));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                ds = VsMain.MGetDataSet("spDMPT", lPar);
                DataTable dt = new DataTable();
                dt = ds.Tables[0].Copy();
                if (dt.Rows.Count > 0 && dt != null)
                {
                    txtMS_PT.EditValue = dt.Rows[0]["MS_PT"];
                    txtMS_PT_NCC.EditValue = dt.Rows[0]["MS_PT_NCC"];
                    txtMS_PT_ERP.EditValue = dt.Rows[0]["MS_PT_ERP"];
                    cboID_CLASS.EditValue = dt.Rows[0]["ID_CLASS"];
                    txtTEN_PT.EditValue = dt.Rows[0]["TEN_PT"];
                    txtTEN_PT_A.EditValue = dt.Rows[0]["TEN_PT_A"];
                    txtTEN_PT_H.EditValue = dt.Rows[0]["TEN_PT_H"];
                    txtQUY_CACH.EditValue = dt.Rows[0]["QUY_CACH"];
                    cboID_LPT.EditValue = dt.Rows[0]["ID_LPT"];
                    cboID_DVT.EditValue = dt.Rows[0]["ID_DVT"];
                    cboID_MDB.EditValue = dt.Rows[0]["ID_MDB"];
                    cboID_HSX.EditValue = dt.Rows[0]["ID_HSX"];
                    cboID_NCC.EditValue = dt.Rows[0]["ID_NCC"];
                    chkPHU_TUNG.EditValue = dt.Rows[0]["PHU_TUNG"];
                    chkKHONG_SD.EditValue = dt.Rows[0]["KHONG_SD"];
                    chkTAI_SD.EditValue = dt.Rows[0]["TAI_SD"];
                    chkDUNG_CU_DO.EditValue = dt.Rows[0]["DUNG_CU_DO"];
                    chkSERIAL_NUM.EditValue = dt.Rows[0]["SERIAL_NUM"];
                    txtCREATE_NAME.EditValue = dt.Rows[0]["CREATE_NAME"];
                    datCREATE_TIME.EditValue = dt.Rows[0]["CREATE_TIME"];
                    txtLAST_NAME.EditValue = dt.Rows[0]["LAST_NAME"];
                    datLAST_TIME.EditValue = dt.Rows[0]["LAST_TIME"];
                }
                if (iID_PT == -1)
                {
                    txtMS_PT.Text = "";
                    txtMS_PT_NCC.Text = "";
                    txtMS_PT_ERP.Text = "";
                    txtTEN_PT.Text = "";
                    txtTEN_PT_A.Text = "";
                    txtTEN_PT_H.Text = "";
                    txtQUY_CACH.Text = "";
                    cboID_MDB.Text = "";
                    chkKHONG_SD.Checked = false;
                    chkPHU_TUNG.Checked = false;
                    chkTAI_SD.Checked = false;
                    chkSERIAL_NUM.Checked = false;
                    chkDUNG_CU_DO.Checked = false;
                    cboID_CLASS.EditValue = Convert.ToInt64(-1);
                    cboID_LPT.EditValue = Convert.ToInt64(-1);
                    cboID_DVT.EditValue = Convert.ToInt64(-1);
                    cboID_HSX.EditValue = Convert.ToInt64(-1);
                    cboID_NCC.EditValue = Convert.ToInt64(-1);
                }
                LoadGrv();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
        }
        private void LoadCboLuoi()
        {
            try
            {
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iALL", "1"));
                lPar.Add(new SqlParameter("@iCoALL", -1));
                lPar.Add(new SqlParameter("@sALL", ""));
                lPar.Add(new SqlParameter("@iID1", iID_PT));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                lPar.Add(new SqlParameter("@sDanhMuc", "KHO;KHO_VI_TRI;"));
                DataSet ds = new DataSet();

                ds = VsMain.MGetDataSet("spGetDataCatalogs", lPar);
                DataTable dt = new DataTable();
                dt = ds.Tables[0].Copy();
                RepositoryItemSearchLookUpEdit cboKHO = new RepositoryItemSearchLookUpEdit();
                Com.Mod.OS.AddCombSearchLookUpEdit(cboKHO, "ID_KHO", "TEN_KHO", grvPTK, dt, this.Name);

                dt = ds.Tables[1].Copy();
                RepositoryItemSearchLookUpEdit cboKVT = new RepositoryItemSearchLookUpEdit();
                Com.Mod.OS.AddCombSearchLookUpEdit(cboKVT, "ID_KVT", "TEN_KVT", grvPTK, dt, this.Name);

            }
            catch { }
        }
        private void LoadCbo()
        {
            try
            {
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iALL", "1"));
                lPar.Add(new SqlParameter("@iCoALL", -1));
                lPar.Add(new SqlParameter("@sALL", ""));
                lPar.Add(new SqlParameter("@iID1", iID_PT));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                lPar.Add(new SqlParameter("@sDanhMuc", "PHU_TUNG_CLASS;LOAI_PHU_TUNG;DON_VI_TINH;HANG_SX;NHA_CUNG_CAP;KHO;LOAI_CONG_VIEC;PHU_TUNG;MUC_BAO_DAM;"));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet("spGetDataCatalogs", lPar);

                DataTable dt = new DataTable();
                dt = ds.Tables[0].Copy();
                Com.Mod.OS.MLoadSearchLookUpEdit(cboID_CLASS, dt, "ID_CLASS", "TEN_CLASS", this.Name);
                cboID_CLASS.Properties.View.Columns["TT_CLASS"].Visible = false;

                dt = ds.Tables[1].Copy();
                Com.Mod.OS.MLoadSearchLookUpEdit(cboID_LPT, dt, "ID_LPT", "TEN_LPT", this.Name);
                cboID_LPT.Properties.View.Columns["TT_LPT"].Visible = false;

                dt = ds.Tables[2].Copy();
                Com.Mod.OS.MLoadSearchLookUpEdit(cboID_DVT, dt, "ID_DVT", "TEN_DVT", this.Name);
                cboID_DVT.Properties.View.Columns["TT_DVT"].Visible = false;

                dt = ds.Tables[3].Copy();
                Com.Mod.OS.MLoadSearchLookUpEdit(cboID_HSX, dt, "ID_HSX", "TEN_HSX", this.Name);

                dt = ds.Tables[4].Copy();
                Com.Mod.OS.MLoadSearchLookUpEdit(cboID_NCC, dt, "ID_NCC", "TEN_NCC", this.Name);

                dt = ds.Tables[8].Copy();
                Com.Mod.OS.MLoadSearchLookUpEdit(cboID_MDB, dt, "ID_MDB", "MUC_DAM_BAO", this.Name);

               
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        public void LoadNN()
        {
            try
            {
                DataTable dtNN = new DataTable();
                dtNN = Com.Mod.OS.MLoadTableNN(this);
                Com.Mod.OS.MLoadNN(dtNN, this, dataLayoutControl1);
                Com.Mod.OS.MLoadNNGrid(dtNN, grvPTK, this.Name);
                Com.Mod.OS.MLoadNNGrid(dtNN, grvPTTD, this.Name);
                Com.Mod.OS.MSaveResertGrid(grvPTK, this.Name);
                Com.Mod.OS.MSaveResertGrid(grvPTTD, this.Name);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
        }
        private void btnGhi_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dxValidationProvider1.Validate()) return;
                string sBT = "[TMP_PTK" + Com.Mod.UserID + "]";
                string sBT1 = "[TMP_LTB" + Com.Mod.UserID + "]";
                string sBT2 = "[TMP_PTTT" + Com.Mod.UserID + "]";

                Com.Mod.OS.MTableToData(Com.Mod.CNStr, sBT, Com.Mod.OS.ConvertDatatable(grdPTK), "");
                Com.Mod.OS.MTableToData(Com.Mod.CNStr, sBT1, Com.Mod.OS.ConvertDatatable(grdLTB), "");
                Com.Mod.OS.MTableToData(Com.Mod.CNStr, sBT2, Com.Mod.OS.ConvertDatatable(grdPTTD), "");

                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 3));
                lPar.Add(new SqlParameter("@MS_PT", txtMS_PT.Text));
                lPar.Add(new SqlParameter("@MS_PT_NCC", txtMS_PT_NCC.Text));
                lPar.Add(new SqlParameter("@MS_PT_ERP", txtMS_PT_ERP.Text));
                lPar.Add(new SqlParameter("@TEN_PT", txtTEN_PT.Text));
                lPar.Add(new SqlParameter("@TEN_PT_A", txtTEN_PT_A.Text));
                lPar.Add(new SqlParameter("@TEN_PT_H", txtTEN_PT_H.Text));
                lPar.Add(new SqlParameter("@QUY_CACH", txtQUY_CACH.Text));
                lPar.Add(new SqlParameter("@ID_LPT", cboID_LPT.Text.Trim() == "" ? null : cboID_LPT.EditValue));
                lPar.Add(new SqlParameter("@ID_DVT", cboID_DVT.Text.Trim() == "" ? null : cboID_DVT.EditValue));
                lPar.Add(new SqlParameter("@ID_NCC", cboID_NCC.Text.Trim() == "" ? null : cboID_NCC.EditValue));
                lPar.Add(new SqlParameter("@ID_HSX", cboID_HSX.Text.Trim() == "" ? null : cboID_HSX.EditValue));
                lPar.Add(new SqlParameter("@KHONG_SD", (chkKHONG_SD.Checked == true ? 1 : 0)));
                lPar.Add(new SqlParameter("@PHU_TUNG", (chkPHU_TUNG.Checked == true ? 1 : 0)));
                lPar.Add(new SqlParameter("@TAI_SD", (chkTAI_SD.Checked == true ? 1 : 0)));
                lPar.Add(new SqlParameter("@ID_CLASS", cboID_CLASS.Text.Trim() == "" ? null : cboID_CLASS.EditValue));
                lPar.Add(new SqlParameter("@ID_MDB", cboID_MDB.EditValue));
                lPar.Add(new SqlParameter("@sBT", sBT));
                lPar.Add(new SqlParameter("@sBT1", sBT1));
                lPar.Add(new SqlParameter("@sBT2", sBT2));
                lPar.Add(new SqlParameter("@ID_PT", iID_PT));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@FullName", Com.Mod.sTenNhanVienMD));
                DataTable dtTMP = new DataTable();
                dtTMP = VsMain.MGetDatatable("spDMPT", lPar);

                if (dtTMP.Rows[0][0].ToString() == "1")
                {
                    XtraMessageBox.Show(dtTMP.Rows[0][2].ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }else
                {
                    XtraMessageBox.Show(dtTMP.Rows[0][2].ToString() + "\n" + dtTMP.Rows[0][1].ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Com.Mod.OS.XoaTable(sBT);
                Com.Mod.OS.XoaTable(sBT1);
                Com.Mod.OS.XoaTable(sBT2);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);

            }
        }
        DevExpress.XtraBars.BarManager BarManager;
        private void btnKhongGhi_Click(object sender, EventArgs e)
        {
            try
            {
                iID_PT = -1;
                LoadData();
                LoadGrv();
            }
            catch(Exception ex) { }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnChon_Click(object sender, EventArgs e)
        {
            try
            {
                frmDMVTPTView_Chon ctl = null;
                DataTable dt = null;
                switch (tabDMVTPT.SelectedTabPageIndex)
                {
                    case 0:
                        {
                            ctl = new frmDMVTPTView_Chon(iPQ, grvPTK.Name.ToString(), (DataTable)grdPTK.DataSource, iID_PT);
                            Com.Mod.OS.LocationSizeForm(this, ctl);
                            break;
                        }
                    case 1:
                        {
                            ctl = new frmDMVTPTView_Chon(iPQ, grvPTTD.Name.ToString(), (DataTable)grdPTTD.DataSource, iID_PT);
                            Com.Mod.OS.LocationSizeForm(this, ctl);
                            break;
                        }
                }
                if (ctl.ShowDialog() == DialogResult.OK)
                {
                    DataTable dt1 = new DataTable();
                    dt1 = ((frmDMVTPTView_Chon)ctl).dt_PhuTung.Copy();
                    if (dt1 != null && dt1.Rows.Count > 0)
                    {
                        string sBT;
                        DataRow dr;
                        if (tabDMVTPT.SelectedTabPageIndex == 0)
                        {
                            dt = (DataTable)grdPTK.DataSource;
                            sBT = "[DMVT" + Com.Mod.UserID + "]";
                            Com.Mod.OS.MTableToData(Com.Mod.CNStr, sBT, dt, "");
                            dr = dt.NewRow();

                            foreach (DataRow dr1 in dt1.Rows)
                            {
                                dr = dt.NewRow();
                                dr["ID_PT"] = iID_PT;
                                dr["ID_KHO"] = dr1["ID_KHO"];
                                dr["TEN_KHO"] = dr1["TEN_KHO"];
                                dr["TON_TOI_THIEU"] = 0;
                                dr["TON_TOI_DA"] = 0;
                                dr["LEAD_TIME"] = 0;
                                dr["ID_KVT"] = dr1["ID_KVT"];
                                dr["TEN_KVT"] = dr1["TEN_KVT"];
                                dr["MS_KHO"] = dr1["MS_KHO"];
                                dt.Rows.Add(dr);
                            }
                        }
                        if (tabDMVTPT.SelectedTabPageIndex == 1)
                        {
                            dt = (DataTable)grdPTTD.DataSource;
                            sBT = "[DMVT" + Com.Mod.UserID + "]";
                            Com.Mod.OS.MTableToData(Com.Mod.CNStr, sBT, dt, "");
                            dr = dt.NewRow();

                            foreach (DataRow dr1 in dt1.Rows)
                            {
                                dr = dt.NewRow();
                                dr["ID_PT"] = iID_PT;
                                dr["ID_PT_TT"] = dr1["ID_PT"];
                                dr["TEN_PT"] = dr1["TEN_PT"];
                                dr["MS_PT"] = dr1["MS_PT"];
                                dt.Rows.Add(dr);
                            }
                        }

                    }
                    dt.AcceptChanges();
                }
            }
            catch { }
        }
        private void tabDMVTPT_SelectedPageChanged(object sender, DevExpress.XtraLayout.LayoutTabPageChangedEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(tabDMVTPT.SelectedTabPageIndex) == 2)
                {
                    lciChon.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
                else
                {
                    lciChon.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }
            }
            catch { }
        }
        private void grvPTK_ShowingEditor(object sender, CancelEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(tabDMVTPT.SelectedTabPageIndex) != 0)return ;
                //grvPTK.ClearColumnErrors();

                GridView view = sender as GridView;

                if (Convert.ToInt32(grvPTK.GetFocusedRowCellValue("TON_TOI_THIEU")) < 0)
                {
                    
                    grvPTK.SetColumnError(grvPTK.Columns["TON_TOI_THIEU"], Com.Mod.OS.GetLanguage(this.Name, "msgTonToiThieuKhongNhoHon0"));
                    e.Cancel = true;
                    return;
                }
                if (Convert.ToInt32(grvPTK.GetFocusedRowCellValue("TON_TOI_DA")) < 0)
                {

                    grvPTK.SetColumnError(grvPTK.Columns["TON_TOI_DA"], Com.Mod.OS.GetLanguage(this.Name, "msgTonToiDaKhongNhoHon0"));
                    e.Cancel = true;
                    return;
                }
                if (Convert.ToInt32(grvPTK.GetFocusedRowCellValue("LEAD_TIME")) < 0)
                {

                    grvPTK.SetColumnError(grvPTK.Columns["LEAD_TIME"], Com.Mod.OS.GetLanguage(this.Name, "msgleadtimeKhongNhoHon0"));
                    e.Cancel = true;
                    return;
                }
                e.Cancel = false;
            }
            catch { }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgBanCoChacXoa"), this.Text, MessageBoxButtons.YesNo) == DialogResult.No) return;
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai",4));
                lPar.Add(new SqlParameter("@iID_PT", iID_PT));
                DataTable dtTMP = new DataTable();
                dtTMP = VsMain.MGetDatatable("spDMPT", lPar);

                if (dtTMP.Rows[0][0].ToString() == "1")
                {
                    XtraMessageBox.Show(dtTMP.Rows[0][2].ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    iID_PT = -1;
                    LoadData();
                    LoadGrv();
                    return;
                }
                else
                {
                    XtraMessageBox.Show(dtTMP.Rows[0][2].ToString() + "\n" + dtTMP.Rows[0][1].ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


            }
            catch { }
        }

        private void grvPTTD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete) return;
            if ( grvPTTD.RowCount == 0)
            {
                XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgKhongCoDuLieuDeXoa"), this.Text);
                return;
            }
            if (XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgBanCoChacXoa"), this.Text, MessageBoxButtons.YesNo) == DialogResult.No) return;


            List<SqlParameter> lPar = new List<SqlParameter>();
            lPar.Add(new SqlParameter("@iLoai", 5));
            lPar.Add(new SqlParameter("@ID_PT", iID_PT));
            lPar.Add(new SqlParameter("@iLuoi", Convert.ToInt32(tabDMVTPT.SelectedTabPageIndex)));
            lPar.Add(new SqlParameter("@ID_PT_TT", Convert.ToInt64(grvPTK.GetFocusedRowCellValue("ID_PT_TT"))));
            DataTable dtTMP = new DataTable();
            dtTMP = VsMain.MGetDatatable("spDMPT", lPar);

            if (dtTMP.Rows[0][0].ToString() == "1")
            {
                XtraMessageBox.Show(dtTMP.Rows[0][2].ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                grvPTTD.DeleteSelectedRows();
                return;
            }
            else
            {
                XtraMessageBox.Show(dtTMP.Rows[0][2].ToString() + "\n" + dtTMP.Rows[0][1].ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void grvPTK_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode != Keys.Delete) return;
                if (grvPTK.RowCount == 0)
                {
                    XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgKhongCoDuLieuDeXoa"), this.Text);
                    return;
                }
                if (XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgBanCoChacXoa"), this.Text, MessageBoxButtons.YesNo) == DialogResult.No) return;


                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 5));
                lPar.Add(new SqlParameter("@ID_PT", iID_PT));
                lPar.Add(new SqlParameter("@iLuoi", Convert.ToInt32(tabDMVTPT.SelectedTabPageIndex)));
                lPar.Add(new SqlParameter("@ID_KHO", Convert.ToInt64(grvPTK.GetFocusedRowCellValue("ID_KHO"))));
                DataTable dtTMP = new DataTable();
                dtTMP = VsMain.MGetDatatable("spDMPT", lPar);

                if (dtTMP.Rows[0][0].ToString() == "1")
                {
                    XtraMessageBox.Show(dtTMP.Rows[0][2].ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    grvPTK.DeleteSelectedRows();
                    return;
                }
                else
                {
                    XtraMessageBox.Show(dtTMP.Rows[0][2].ToString() + "\n" + dtTMP.Rows[0][1].ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch { }
        }
    }
}
