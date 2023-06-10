using DevExpress.Printing.ExportHelpers;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraLayout;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using static DevExpress.XtraPrinting.Native.ExportOptionsPropertiesNames;

namespace VS.CMMS
{
    public partial class frmEditHuHong : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = 1; // =1: full, <> 1: readonly
        static DataRow drRow;
        static Int64 iID = -1;
        static string sDMuc;
        public bool bXoa = false ;
        public frmEditHuHong(DataRow row , String DMuc)
        {
            InitializeComponent();
            drRow = row;
            sDMuc = DMuc;
            if (drRow != null)
            {
                switch(DMuc)
                {
                    case "frmEditNguyenNhanHH":
                        {
                            try { iID = Convert.ToInt64(drRow["ID_HH_NN"].ToString()); } catch { iID = -1; }
                            lciChon.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                            break;
                        }
                    case "frmEditHuHongHH":
                        {
                            try { iID = Convert.ToInt64(drRow["ID_HH_HH"].ToString()); } catch { iID = -1; }
                            break;
                        }
                    case "frmEditBoPhanHH":
                        {
                            try { iID = Convert.ToInt64(drRow["ID_HH_BP"].ToString()); } catch { iID = -1; }
                            break;
                        }
                    default: break;
                }
            }
            else
            {
                iID = -1;
            }
            if (iPQ != 1)
            {
                lciGhi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else
            {
                lciGhi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }

            VsMain.MFieldRequest(lblMA_SO);
            VsMain.MFieldRequest(lblTEN);


            try
            {
                this.grdChung.ViewRegistered += new DevExpress.XtraGrid.ViewOperationEventHandler(this.grdChung_ViewRegistered);
                this.grvChung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvChung_KeyDown);
            }
            catch{ }
        }
        private void frmEditHuHong_Load(object sender, EventArgs e)
        {
            LoadText();
            switch (sDMuc)
            {
                case "frmEditBoPhanHH":
                {
                    LoadDataBoPhanHH(1 , null , iID);
                    break;
                }
                case "frmEditHuHongHH":
                {
                    LoadDataHuHongHH(1, null, iID);
                    break;
                }
                case "frmEditNguyenNhanHH":
                {
                        grvChung.OptionsBehavior.Editable = true;  // Cho phép chỉnh sửa
                        grvChung.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;  // Cho phép thêm dòng mới
                        grvChung.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
                        LoadDataNguyenNhan();
                    break;
                }
            }
            LoadNN();
        }

        #region Function
        private void LoadText()
        {
            try
            {
                switch (sDMuc)
                {
                    case "frmEditNguyenNhanHH":
                        txtMA_SO.Text = drRow["MS_HH_NN"].ToString();
                        txtTEN.Text = drRow["TEN_NN"].ToString();
                        txtTEN_A.Text = drRow["TEN_NN_A"].ToString();
                        txtTEN_H.Text = drRow["TEN_NN_H"].ToString();
                        txtGHI_CHU.Text = drRow["GHI_CHU"].ToString();
                        txtSTT.Text = drRow["TT_HH_NN"].ToString() == "999" ? "0" : drRow["TT_HH_NN"].ToString();
                        break;
                    case "frmEditHuHongHH":
                        txtMA_SO.Text = drRow["MS_HH_HH"].ToString();
                        txtTEN.Text = drRow["TEN_HU_HONG"].ToString();
                        txtTEN_A.Text = drRow["TEN_HU_HONG_A"].ToString();
                        txtTEN_H.Text = drRow["TEN_HU_HONG_H"].ToString();
                        txtGHI_CHU.Text = drRow["GHI_CHU"].ToString();
                        txtSTT.Text = drRow["TT_HH_HH"].ToString() == "999" ? "0" : drRow["TT_HH_HH"].ToString();
                        break;
                    case "frmEditBoPhanHH":
                        txtMA_SO.Text = drRow["MS_HH_BP"].ToString();
                        txtTEN.Text = drRow["TEN_HH_BP"].ToString();
                        txtTEN_A.Text = drRow["TEN_HH_BP_A"].ToString();
                        txtTEN_H.Text = drRow["TEN_HH_BP_H"].ToString();
                        txtGHI_CHU.Text = drRow["GHI_CHU"].ToString();
                        txtSTT.Text = drRow["TT_HH_BP"].ToString() == "999" ? "0" : drRow["TT_HH_BP"].ToString();
                        break;
                }

            }
            catch
            {
                txtMA_SO.Text = "";
                txtTEN.Text = "";
                txtTEN_A.Text = "";
                txtTEN_H.Text = "";
                txtGHI_CHU.Text = "";
                txtSTT.Text = "0";

            }
        }
        private void LoadNN()
        {
            try
            {
                this.Name = sDMuc; 
                Com.Mod.OS.ThayDoiNN(this, dataLayoutControl1);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        //iLoad 1 là load bình thường, 12 là load chọn
        private void LoadDataNguyenNhan()
        {
            try
            {
                if (Com.Mod.sLoad == "0Load") return;
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 1));
                lPar.Add(new SqlParameter("@sDMuc", sDMuc));
                lPar.Add(new SqlParameter("@iID", iID));
                DataTable dtTmp = new DataTable();
                dtTmp = VsMain.MGetDatatable("spHuHong", lPar);
                grvChung.OptionsMenu.EnableGroupRowMenu = true;
                Com.Mod.OS.MLoadXtraGrid(grdChung, grvChung, dtTmp, true, true, true, true, true, this.Name);
                try
                {
                    Com.Mod.OS.MSaveResertGrid(grvChung, this.Name, grvChung.Name.ToString() + dtTmp.Rows[0]["GRV_LEVEL"].ToString());

                }
                catch
                {
                    Com.Mod.OS.MSaveResertGrid(grvChung, grvChung.Name.ToString() + "4");
                }

                RepositoryItemButtonEdit btnTaiLieu = new RepositoryItemButtonEdit();

                grvChung.Columns["DUONG_DAN_FILE"].ColumnEdit = btnTaiLieu;

                btnTaiLieu.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(btnTaiLieu_ButtonClick);
            }
            catch { }
        }
        private void LoadDataBoPhanHH(int iLoad, string sBT, Int64 iID_BP)
        {
            try
            {
                if (Com.Mod.sLoad == "0Load") return;
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@sDMuc", sDMuc));
                lPar.Add(new SqlParameter("@iLoai", iLoad));
                lPar.Add(new SqlParameter("@iID", iID_BP));
                lPar.Add(new SqlParameter("@sBT", sBT));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet("spHuHong", lPar);

                DataColumn[] keyLever2 = new DataColumn[2];
                DataColumn[] frKeyLever2 = new DataColumn[2];
                keyLever2[0] = ds.Tables[0].Columns["ID_HH_BP"];
                keyLever2[1] = ds.Tables[0].Columns["ID_HH_HH"];

                frKeyLever2[0] = ds.Tables[1].Columns["ID_HH_BP"];
                frKeyLever2[1] = ds.Tables[1].Columns["ID_HH_HH"];
                try
                {
                    ds.Relations.Add(Com.Mod.OS.GetLanguage(this.Name, "grvNguyenNhanHuHong"), keyLever2, frKeyLever2);
                }
                catch { }
                DataColumn[] keyLever3 = new DataColumn[3];
                keyLever3[0] = ds.Tables[1].Columns["ID_HH_NN"];
                keyLever3[1] = ds.Tables[1].Columns["ID_HH_BP"];
                keyLever3[2] = ds.Tables[1].Columns["ID_HH_HH"];

                DataColumn[] frKeyLever3 = new DataColumn[3];
                frKeyLever3[0] = ds.Tables[2].Columns["ID_HH_NN"];
                frKeyLever3[1] = ds.Tables[2].Columns["ID_HH_BP"];
                frKeyLever3[2] = ds.Tables[2].Columns["ID_HH_HH"];
                try
                {
                    ds.Relations.Add(Com.Mod.OS.GetLanguage(this.Name, "grvPhuongPhapKhacPhuc"), keyLever3, frKeyLever3);
                }
                catch { }
                DataTable dtTmp = new DataTable();
                dtTmp = ds.Tables[0];
                Com.Mod.OS.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, true, true, true, this.Name);
                try
                {
                    if (dtTmp.Rows[0]["GRV_LEVEL"].ToString() == "")
                    {
                        Com.Mod.OS.MSaveResertGrid(grvChung, grvChung.Name.ToString() + "2");
                    }
                    else
                    {
                        Com.Mod.OS.MSaveResertGrid(grvChung, this.Name, grvChung.Name.ToString() + dtTmp.Rows[0]["GRV_LEVEL"].ToString());
                    }
                }
                catch { Com.Mod.OS.MSaveResertGrid(grvChung, grvChung.Name.ToString() + "2"); }
            }
            catch { }
        }
        private void LoadDataHuHongHH(int iLoad, string sBT, Int64 iID_BP)
        {
            try
            {
                if (Com.Mod.sLoad == "0Load") return;
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@sDMuc", sDMuc));
                lPar.Add(new SqlParameter("@iLoai", iLoad));
                lPar.Add(new SqlParameter("@iID", iID_BP));
                lPar.Add(new SqlParameter("@sBT", sBT));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet("spHuHong", lPar);

                switch (iLoad)
                {
                    case 1:
                        {
                            DataColumn[] keyLever3 = new DataColumn[2];
                            keyLever3[0] = ds.Tables[0].Columns["ID_HH_NN"];
                            keyLever3[1] = ds.Tables[0].Columns["ID_HH_HH"];

                            DataColumn[] frKeyLever3 = new DataColumn[2];
                            frKeyLever3[0] = ds.Tables[1].Columns["ID_HH_NN"];
                            frKeyLever3[1] = ds.Tables[1].Columns["ID_HH_HH"];

                            try
                            {
                                ds.Relations.Add(Com.Mod.OS.GetLanguage(this.Name, "grvPhuongPhapKhacPhuc"), keyLever3, frKeyLever3);
                            }
                            catch { }
                            break;
                        }
                    default:
                        {
                            DataColumn keyLever3 = new DataColumn();
                            keyLever3 = ds.Tables[0].Columns["ID_HH_NN"];

                            DataColumn frKeyLever3 = new DataColumn();
                            frKeyLever3 = ds.Tables[1].Columns["ID_HH_NN"];
                            try
                            {
                                ds.Relations.Add(Com.Mod.OS.GetLanguage(this.Name, "grvPhuongPhapKhacPhuc"), keyLever3, frKeyLever3);
                            }
                            catch { }
                            break;
                        }
                }





                DataTable dtTmp = new DataTable();
                dtTmp = ds.Tables[0];
                Com.Mod.OS.MLoadXtraGrid(grdChung, grvChung, dtTmp, true, true, true, true, true, this.Name);
                try
                {

                    Com.Mod.OS.MSaveResertGrid(grvChung, this.Name, grvChung.Name.ToString() + dtTmp.Rows[0]["GRV_LEVEL"].ToString());
                    for (int i = 0; i < grvChung.Columns.Count; i++)
                    {
                        grvChung.Columns[i].OptionsColumn.AllowEdit = false;
                    }
                    grvChung.Columns["UU_TIEN"].OptionsColumn.AllowEdit = true;
                }
                catch
                {
                    Com.Mod.OS.MSaveResertGrid(grvChung,this.Name, grvChung.Name.ToString() + "3");
                }
            }
            catch { }
        }
        private Boolean KiemTrung(int iKiem)
        {
            Boolean bKiem = false;
            try
            {
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 4));
                lPar.Add(new SqlParameter("@sDMuc", sDMuc));
                lPar.Add(new SqlParameter("@iID", iID)); ;
                lPar.Add(new SqlParameter("@iKiem", iKiem));
                lPar.Add(new SqlParameter("@MA_SO", txtMA_SO.Text));
                lPar.Add(new SqlParameter("@TEN", txtTEN.Text));
                lPar.Add(new SqlParameter("@TEN_A", txtTEN_A.Text));
                lPar.Add(new SqlParameter("@TEN_H", txtTEN_H.Text));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                bKiem = Convert.ToBoolean(VsMain.MExecuteScalar("spHuHong", lPar));
            }
            catch { }
            return bKiem;
        }
        private Boolean KiemSuDung()
        {
            try
            {
                #region KiemTrung loai = 6
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 6));
                lPar.Add(new SqlParameter("@sDMuc", sDMuc ));
                lPar.Add(new SqlParameter("@iID", iID)); ;
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet("spHuHong", lPar);
                DataTable dtTmp = new DataTable();
                dtTmp = ds.Tables[0].Copy();
                int checkTrung = Convert.ToInt32(dtTmp.Rows[0]["ERR_CODE"].ToString());
                if (Convert.ToInt32(dtTmp.Rows[0]["ERR_CODE"].ToString()) == 1)
                {
                    XtraMessageBox.Show(dtTmp.Rows[0]["ERR_NAME"].ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private Boolean kiemTrung_frmEditNguyenNhanHH(string TEN_BPKP, string MS_HH_BPKP, Int32 UU_TIEN)
        {
            try
            {

                DataTable dt = ((DataView)grvChung.DataSource).ToTable();
                int count = 0;
                if (dt.AsEnumerable().Count(x => !x.IsNull("MS_HH_BPKP")) == 1) return false;
                count = dt.AsEnumerable().Count(x => x["MS_HH_BPKP"].ToString().Equals(MS_HH_BPKP));
                if ((count >= 2))
                {
                    XtraMessageBox.Show(Com.Mod.OS.GetLanguage(this.Name, "msgMaSoBienPhapKhachPhucBiTrung"), this.Text);
                    return false;
                }
                if (dt.AsEnumerable().Count(x => !x.IsNull("TEN_BPKP")) == 1) return false;
                count = dt.AsEnumerable().Count(x => x["TEN_BPKP"].ToString().Equals(TEN_BPKP));
                if ((count >= 2))
                {
                    XtraMessageBox.Show(Com.Mod.OS.GetLanguage(this.Name, "msgTenBienPhapKhachPhucBiTrung"), this.Text);
                    return false;
                }

                try
                {

                    count = dt.AsEnumerable().Count(x => Convert.ToInt32(x["UU_TIEN"]) < 0);
                    if ((count >= 2))
                    {
                        XtraMessageBox.Show(Com.Mod.OS.GetLanguage(this.Name, "msgMucUUTienKhongNhoHon0"), this.Text);
                        return false;
                    }
                }
                catch { }


            }
            catch { }
            return true;
        }
        private Boolean kiemTrung_frmEditHuHongHH(Int32 UU_TIEN)
        {
            try
            {
                DataTable dt = ((DataTable)grvChung.DataSource).Copy();
                int count = 0;
                count = dt.AsEnumerable().Count(x => Convert.ToInt32(x["UU_TIEN"]) < 0);
                if ((count >= 2))
                {
                    XtraMessageBox.Show(Com.Mod.OS.GetLanguage(this.Name, "msgMucUUTienKhongNhoHon0"), this.Text);
                    return false;
                }
            }
            catch { }
            return true;
        }
        #endregion

        #region Event
        private void btnTaiLieu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                Com.Mod.MFileServer mFile;

                if(grvChung.GetFocusedRowCellValue("ID_HH_BPKP") == null)
                {
                    XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgVuiLongLuuTruocKhiChoTaiLieu"), this.Text, MessageBoxButtons.OK);
                    return;
                }
                mFile = Com.Mod.OS.CopyFileToServer("DiaDiem\\CongViecBaoTro", grvChung.GetFocusedRowCellValue("MS_HH_BPKP").ToString());

                if (mFile.sfilegoc.Count <= 0) return;

                this.Cursor = Cursors.WaitCursor;

                string sPath, sPathGoc;
                sPath = mFile.sfileserver[0].ToString();
                grvChung.SetFocusedRowCellValue("DUONG_DAN_FILE", sPath);

                
            }
            catch
            {
                XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgBanKhongCoQuyenTruyCapDD"), this.Text, MessageBoxButtons.OK);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnGhi_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (!dxValidationProvider1.Validate()) return;
                if (KiemTrung(1) && txtMA_SO.Text != "")
                {
                    XtraMessageBox.Show(lblMA_SO.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtMA_SO.Focus();
                    return;
                }
                if (KiemTrung(2) && txtTEN.Text != "")
                {
                    XtraMessageBox.Show(lblTEN.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN.Focus();
                    return;
                }
                if (KiemTrung(3) && txtTEN_A.Text != "")
                {
                    XtraMessageBox.Show(lblTEN_A.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_A.Focus();
                    return;
                }
                if (KiemTrung(4) && txtTEN_H.Text != "")
                {
                    XtraMessageBox.Show(lblTEN_H.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgNayDaTonTai"), this.Text);
                    txtTEN_H.Focus();
                    return;
                }
                string sHH = "[HH" + Com.Mod.UserID + "]";
                Com.Mod.OS.MTableToData(Com.Mod.CNStr, sHH, Com.Mod.OS.ConvertDatatable(grdChung), "");
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 3));
                lPar.Add(new SqlParameter("@iID", iID));
                lPar.Add(new SqlParameter("@sBT", sHH));
                lPar.Add(new SqlParameter("@MA_SO", txtMA_SO.Text));
                lPar.Add(new SqlParameter("@STT", txtSTT.Text));
                lPar.Add(new SqlParameter("@TEN", txtTEN.Text));
                lPar.Add(new SqlParameter("@TEN_A", txtTEN_A.Text));
                lPar.Add(new SqlParameter("@TEN_H", txtTEN_H.Text));
                lPar.Add(new SqlParameter("@GHI_CHU", txtGHI_CHU.Text));
                lPar.Add(new SqlParameter("@sDMuc", sDMuc));
                
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet("spHuHong", lPar);
                if (Com.Mod.sId == "-1")
                {
                    XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgThemSuaKhongThanhCong"), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Com.Mod.OS.XoaTable(sHH);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch { }
        }
        private void grdChung_ViewRegistered(object sender, ViewOperationEventArgs e)
        {
            try
            {
                if (e.View.IsDetailView == false)
                    return;
                DevExpress.XtraGrid.Views.Grid.GridView grv = new DevExpress.XtraGrid.Views.Grid.GridView();
                grv = (e.View as DevExpress.XtraGrid.Views.Grid.GridView);

                Com.Mod.OS.MLoadNNXtraGrid(grv, this.Name);
                try
                {
                    grv.Name = grvChung.Name.ToString() + grv.GetRowCellValue(0, "GRV_LEVEL").ToString();
                    Com.Mod.OS.MSaveResertGrid(grv, this.Name, grv.Name.ToString());
                    if(sDMuc == "frmEditHuHongHH")
                    {
                        for (int i = 0; i < grvChung.Columns.Count; i++)
                        {
                            grv.Columns[i].OptionsColumn.AllowEdit = false;
                        }
                    }
                    

                }
                catch { Com.Mod.OS.MSaveResertGrid(grv, this.Name, grvChung.Name.ToString() + "3"); }

             
            }
            catch { }
        }
        private void btnChon_Click(object sender, EventArgs e)
        {
            try
            {
                frmHuHongView_Chon ctl = new frmHuHongView_Chon(iPQ, sDMuc, (DataTable)grdChung.DataSource);
                Com.Mod.OS.LocationSizeForm(this, ctl);
                if (ctl.ShowDialog() == DialogResult.OK)
                {
                    DataTable dt1 = new DataTable();
                    dt1 = ((frmHuHongView_Chon)ctl).dt_HuHong.Copy();
                    if (dt1 != null && dt1.Rows.Count > 0)
                    {
                        DataTable dt = (DataTable)grdChung.DataSource;
                        string sBT = "[HHHH" + Com.Mod.UserID + "]";
                        Com.Mod.OS.MTableToData(Com.Mod.CNStr, sBT, dt, "");
                        DataRow dr = dt.NewRow();

                        switch (sDMuc)
                        {
                            case "frmEditHuHongHH":
                                {
                                    foreach (DataRow dr1 in dt1.Rows)
                                    {
                                        dr = dt.NewRow();
                                        dr["MS_HH_NN"] = dr1["MS_HH_NN"];
                                        dr["TEN_NN"] = dr1["TEN_NN"];
                                        dr["TEN_NN_A"] = dr1["TEN_NN_A"];
                                        dr["TEN_NN_H"] = dr1["TEN_NN_H"];
                                        dr["GHI_CHU"] = dr1["GHI_CHU"];
                                        dr["ID_HH_NN"] = dr1["ID_HH_NN"];
                                        dr["ID_HH_HH"] = iID;
                                        dt.Rows.Add(dr);
                                    }
                                    break;
                                }
                            case "frmEditBoPhanHH":
                                {
                                    foreach (DataRow dr1 in dt1.Rows)
                                     {
                                        dr = dt.NewRow();
                                        dr["ID_HH_BP"] = iID;
                                        dr["ID_HH_HH"] = dr1["ID_HH_HH"];
                                        dr["MS_HH_HH"] = dr1["MS_HH_HH"];
                                        dr["TEN_HU_HONG"] = dr1["TEN_HU_HONG"];
                                        dr["TEN_HU_HONG_A"] = dr1["TEN_HU_HONG_A"];
                                        dr["TEN_HU_HONG_H"] = dr1["TEN_HU_HONG_H"];
                                        dr["GHI_CHU"] = dr1["GHI_CHU"];
                                        dt.Rows.Add(dr);
                                    }
                                    break;
                                }
                        }
                        dt.AcceptChanges();

                        Com.Mod.OS.MTableToData(Com.Mod.CNStr, sBT, Com.Mod.OS.ConvertDatatable(grdChung), "");

                        switch (sDMuc)
                        {
                            case "frmEditBoPhanHH": 
                                {
                                    LoadDataBoPhanHH(12, sBT, iID);
                                    break;
                                }
                            case "frmEditHuHongHH":
                                {
                                    LoadDataHuHongHH(12, sBT, iID);
                                    break;
                                }
                        }
                    }
                }
            }
            catch { }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            ///////this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btnKhongGhi_Click(object sender, EventArgs e)
        {
            try
            {
                iID = -1;
                txtMA_SO.Text = "";
                txtSTT.Text = "0";
                txtTEN.Text = "";
                txtTEN_A.Text = "";
                txtTEN_H.Text = "";
                txtGHI_CHU.Text = "";
                switch (sDMuc) {
                    case "frmEditBoPhanHH":
                        {
                            LoadDataBoPhanHH(1, "", -1);
                            break; 
                        }
                }
            }
            catch { }
        }
        private void grvChung_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode != Keys.Delete) return;
                if (grvChung.RowCount == 0)
                {
                    XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgKhongCoDuLieuDeXoa"), this.Text);
                    return;
                }
                if (XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgBanCoChacXoa"), this.Text, MessageBoxButtons.YesNo) == DialogResult.No) return;
                Int64 idDelete = -1; 
                switch (sDMuc)
                {
                    case "frmEditBoPhanHH":
                        {
                            idDelete = grvChung.GetFocusedRowCellValue("ID_HH_HH") == null ? -1 : Convert.ToInt64(grvChung.GetFocusedRowCellValue("ID_HH_HH"));
                            break; 
                        }
                    case "frmEditHuHongHH":
                        {
                            idDelete = grvChung.GetFocusedRowCellValue("ID_HH_NN") == null ? -1 : Convert.ToInt64(grvChung.GetFocusedRowCellValue("ID_HH_NN"));
                            break;
                        }
                    case "frmEditNguyenNhanHH":
                        {
                            idDelete = grvChung.GetFocusedRowCellValue("ID_HH_BPKP") == null ? -1 : Convert.ToInt64(grvChung.GetFocusedRowCellValue("ID_HH_BPKP"));
                            break;
                        }
                }
                
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 13));
                lPar.Add(new SqlParameter("@sDMuc", sDMuc));
                lPar.Add(new SqlParameter("@iID", iID));
                lPar.Add(new SqlParameter("@iID_DELETE", idDelete));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet("spHuHong", lPar);
                grvChung.DeleteSelectedRows();
            }
            catch { }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {

                if (!KiemSuDung()) return;
                if (XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgBanCoChacXoa"), this.Text, MessageBoxButtons.YesNo) == DialogResult.No) return;

                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 2));
                lPar.Add(new SqlParameter("@sDMuc", sDMuc));
                lPar.Add(new SqlParameter("@iID", iID));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet("spHuHong", lPar);
                DataTable dtTmp = new DataTable();
                dtTmp = ds.Tables[0].Copy();
                int checkTrung = Convert.ToInt32(dtTmp.Rows[0]["ERR_CODE"].ToString());
                if (Convert.ToInt32(dtTmp.Rows[0]["ERR_CODE"].ToString()) == 1)
                {
                    XtraMessageBox.Show(dtTmp.Rows[0]["ERR_NAME"].ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            catch { }
        }
        #endregion
        private void grvChung_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            string sTEN_BPKP = "";
            string sMS_HH_BPKP = ""; 
            int iUU_TIEN = 0;
            bool bKiem = false;
            switch (sDMuc)
            {
                case "frmEditNguyenNhanHH":
                    {
                        sTEN_BPKP = grvChung.GetRowCellValue(grvChung.FocusedRowHandle, "TEN_BPKP").ToString();
                        sMS_HH_BPKP = grvChung.GetRowCellValue(grvChung.FocusedRowHandle, "MS_HH_BPKP").ToString();
                        iUU_TIEN = string.IsNullOrEmpty(grvChung.GetRowCellValue(grvChung.FocusedRowHandle, "UU_TIEN").ToString()) ? 0 : Convert.ToInt32(grvChung.GetRowCellValue(e.RowHandle, "UU_TIEN"));
                        bKiem = kiemTrung_frmEditNguyenNhanHH(sTEN_BPKP, sMS_HH_BPKP, iUU_TIEN);
                        
                        break;
                    }
                case "frmEditHuHongHH":
                    {
                        iUU_TIEN = string.IsNullOrEmpty(grvChung.GetRowCellValue(grvChung.FocusedRowHandle, "UU_TIEN").ToString()) ? 0 : Convert.ToInt32(grvChung.GetRowCellValue(e.RowHandle, "UU_TIEN"));
                        bKiem = kiemTrung_frmEditHuHongHH(iUU_TIEN);
                        break;
                    }
            }
            e.Valid = bKiem;

        }
        private void grvChung_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

    }
}


