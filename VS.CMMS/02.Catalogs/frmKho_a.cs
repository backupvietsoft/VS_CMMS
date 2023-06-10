using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Localization;
using DevExpress.XtraTreeList.Nodes;
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
using static DevExpress.XtraPrinting.Native.ExportOptionsPropertiesNames;
using VS.CMMS;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Reflection;
using DevExpress.XtraGrid.Menu;

namespace VS.CMMS
{
    public partial class frmKho_a : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = 1;
        private Color _highlightColor;
        public frmKho_a(int PQ)
        {
            iPQ = PQ;
            InitializeComponent();

            if (iPQ != 1)
            {
                lciThemKho.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else
            {
                lciThemKho.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }

            var skin = DevExpress.Skins.CommonSkins.GetSkin(grdChung.LookAndFeel.ActiveLookAndFeel);

            var foreColor = skin.Colors.GetColor("HighlightText");

            grvChung.Appearance.FocusedRow.ForeColor = foreColor;
            grvChung.Appearance.FocusedCell.ForeColor = foreColor;

            int R = 156, G = 97, B = 65;
            try { R = int.Parse(VS.CMMS.Properties.Settings.Default["ApplicationColorRed"].ToString()); } catch { R = 156; }
            try { G = int.Parse(VS.CMMS.Properties.Settings.Default["ApplicationColorGreen"].ToString()); } catch { G = 97; }
            try { B = int.Parse(VS.CMMS.Properties.Settings.Default["ApplicationColorBlue"].ToString()); } catch { B = 65; }

            _highlightColor = System.Drawing.Color.FromArgb(R, G, B); ;

        }
        
        #region Xử lý chuột phải
        private void LoadNN()
        {
            try
            {
                Com.Mod.OS.ThayDoiNN(this, dataLayoutControl1);
                Com.Mod.OS.MLoadNNXtraGrid(grvChung, this.Name, true);
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
                try
                {
                    if (Com.Mod.sLoad == "0Load") return;
                    List<SqlParameter> lPar = new List<SqlParameter>();
                    lPar.Add(new SqlParameter("@iLoai", 1));
                    lPar.Add(new SqlParameter("@sDMuc", "mnuKho"));
                    lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                    lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                    lPar.Add(new SqlParameter("@iID", -1));

                    DataTable dtTmp = new DataTable();
                    dtTmp = VsMain.MGetDatatable("spDanhMuc", lPar);
                    grvChung.OptionsMenu.EnableGroupRowMenu = true;
                    if (grdChung.DataSource == null)
                    {
                        Com.Mod.OS.MLoadXtraGrid(grdChung, grvChung, dtTmp, true, true, false, false);
                    }
                    else
                    grdChung.DataSource = dtTmp;                 
                    //tlKho.ExpandAll();
                }
                catch (Exception ex)
                { Program.MBarThongTin(ex.Message.ToString(), true); }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        private void grvChung_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            try
            {
                DataRow rows = grvChung.GetDataRow(grvChung.FocusedRowHandle) as DataRow;
                int focusedRowHandle = grvChung.FocusedRowHandle;
                int irow = e.HitInfo.RowHandle;
                GridView view = sender as GridView;
                DataRow row = view.GetDataRow(focusedRowHandle);
                if (row != null && view.IsGroupRow(focusedRowHandle))
                {
                    DevExpress.Utils.Menu.DXMenuItem itemEditKho = MCreateEditKho(view, focusedRowHandle);
                    DevExpress.Utils.Menu.DXMenuItem itemAddKho = MCreateAddKho(view, focusedRowHandle);
                    DevExpress.Utils.Menu.DXMenuItem itemDeleteKho = MCreateDeleteKho(view, focusedRowHandle);

                    itemAddKho.BeginGroup = true;
                    e.Menu.Items.Add(itemAddKho);
                    e.Menu.Items.Add(itemDeleteKho);
                    e.Menu.Items.Add(itemEditKho);
                }


                else
                {

                    if (rows["ID_KVT"].ToString() != "")
                    {
                        DevExpress.Utils.Menu.DXMenuItem itemEditKhoViTri = MCreateEditKhoViTri(view, irow);
                        e.Menu.Items.Add(itemEditKhoViTri);
                    }

                    DevExpress.Utils.Menu.DXMenuItem itemAddKhoViTri = MCreateAddKhoViTri(view, irow);
                    e.Menu.Items.Add(itemAddKhoViTri);

                    DevExpress.Utils.Menu.DXMenuItem itemDeleteKhoViTri = MCreateDeleteKhoViTri(view, irow);
                    e.Menu.Items.Add(itemDeleteKhoViTri);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }


        public DXMenuItem MCreateEditKho(DevExpress.XtraGrid.Views.Grid.GridView view, int rowHandle)
        {
            string sStr = Com.Mod.OS.GetLanguage(this.Name, "lblEditKho", 0);
            DXMenuItem menuEditKho = new DXMenuItem(sStr, new EventHandler(EditKho));
            menuEditKho.Tag = new RowInfo(view, rowHandle);
            return menuEditKho;
        }
        public DXMenuItem MCreateEditKhoViTri(DevExpress.XtraGrid.Views.Grid.GridView view, int rowHandle)
        {
            string sStr = Com.Mod.OS.GetLanguage(this.Name, "lblEditKhoViTri", 0);
            DXMenuItem menuEditKhoViTri = new DXMenuItem(sStr, new EventHandler(EditKhoViTri));
            menuEditKhoViTri.Tag = new RowInfo(view, rowHandle);
            return menuEditKhoViTri;
        }
        public DXMenuItem MCreateAddKhoViTri(DevExpress.XtraGrid.Views.Grid.GridView view, int rowHandle)
        {
            string sStr = Com.Mod.OS.GetLanguage(this.Name, "lblAddKhoViTri", 0);
            DXMenuItem menuEditKhoViTri = new DXMenuItem(sStr, new EventHandler(AddKhoViTri));
            menuEditKhoViTri.Tag = new RowInfo(view, rowHandle);
            return menuEditKhoViTri;
        }
        public DXMenuItem MCreateAddKho(DevExpress.XtraGrid.Views.Grid.GridView view, int rowHandle)
        {
            string sStr = Com.Mod.OS.GetLanguage(this.Name, "lblAddKho", 0);
            DXMenuItem menuEditKho = new DXMenuItem(sStr, new EventHandler(AddKho));
            menuEditKho.Tag = new RowInfo(view, rowHandle);
            return menuEditKho;
        }
        public DXMenuItem MCreateDeleteKhoViTri(DevExpress.XtraGrid.Views.Grid.GridView view, int rowHandle)
        {
            string sStr = Com.Mod.OS.GetLanguage(this.Name, "lblDeleteKhoViTri", 0);
            DXMenuItem menuDeleteKhoViTri = new DXMenuItem(sStr, new EventHandler(DeleteKhoViTri));
            menuDeleteKhoViTri.Tag = new RowInfo(view, rowHandle);
            return menuDeleteKhoViTri;
        }
        public DXMenuItem MCreateDeleteKho(DevExpress.XtraGrid.Views.Grid.GridView view, int rowHandle)
        {
            string sStr = Com.Mod.OS.GetLanguage(this.Name, "lblDeleteKho", 0);
            DXMenuItem menuDeleteKho = new DXMenuItem(sStr, new EventHandler(DeleteKho));
            menuDeleteKho.Tag = new RowInfo(view, rowHandle);
            return menuDeleteKho;
        }
        class RowInfo
        {
            public RowInfo(DevExpress.XtraGrid.Views.Grid.GridView view, int rowHandle)
            {
                this.RowHandle = rowHandle;
                this.View = view;
            }
            public DevExpress.XtraGrid.Views.Grid.GridView View;
            public int RowHandle;
        }
        public void EditKho(object sender, EventArgs e)
        {
            try
            {
                DataRow rows = grvChung.GetDataRow(grvChung.FocusedRowHandle) as DataRow;

                Int64 ID_KHO = Convert.ToInt64(rows["ID_KHO"]);
                //Sửa kho
                if (ID_KHO == 0) return;
                if (Com.Mod.sLoad == "0Load") return;
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 1));
                lPar.Add(new SqlParameter("@sDMuc", "mnuKho"));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                lPar.Add(new SqlParameter("@iID", ID_KHO));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet("spDanhMuc", lPar);
                DataTable dt = new DataTable();
                dt = ds.Tables[0].Copy();
                DataRow row = dt.Rows[0];

                //Row = null => Lỗi dữ liệu
                if (row == null) return;
                
                frmEditKho frm = new frmEditKho(iPQ, row, false);
                Com.Mod.OS.LocationSizeForm(this, frm);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                    Program.MBarCapNhapThanhCong();
                }
                
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
                Program.MBarCapNhapKhongThanhCong();
            }
        }
        public void EditKhoViTri(object sender, EventArgs e)
        {
            try
            {
                DataRow rows = grvChung.GetDataRow(grvChung.FocusedRowHandle) as DataRow;
                if (Com.Mod.sLoad == "0Load") return;
                frmEditKhoViTri frm;
                if (rows["ID_KVT"].ToString() == "")
                {
                    XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgChonDungKVTBanMuonEdit"), this.Text);
                    frm = new frmEditKhoViTri(iPQ, null, false, 0,0);
                    return;
                }
                Int64 ID_KVT = Convert.ToInt64(rows["ID_KVT"]);
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 1));
                lPar.Add(new SqlParameter("@sDMuc", "mnuKhoViTri"));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                lPar.Add(new SqlParameter("@iID", ID_KVT));

                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet("spDanhMuc", lPar);
                DataTable dt = new DataTable();
                dt = ds.Tables[0].Copy();
                DataRow row = dt.Rows[0];

                //Row = null => Lỗi dữ liệu
                if (row == null) return;

                frm = new frmEditKhoViTri(iPQ, row, false, 0,0);
                Com.Mod.OS.LocationSizeForm(this, frm);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                    Program.MBarCapNhapThanhCong();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
                Program.MBarCapNhapKhongThanhCong();
            }
    }
        public void AddKhoViTri(object sender, EventArgs e)
        {
            try
            {
                DataRow rows = grvChung.GetDataRow(grvChung.FocusedRowHandle) as DataRow;
                if (Com.Mod.sLoad == "0Load") return;
                if (Convert.ToInt64(rows["QUAN_LY_VI_TRI"]) != 1)
                {
                    XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgKhoKhongDuocQuanLyViTri"), this.Text);
                    return;
                }
                if (iPQ != 1) return;
                frmEditKhoViTri frm = new frmEditKhoViTri(iPQ, null, false, Convert.ToInt64(rows["ID_KHO"]),0); 
                Com.Mod.OS.LocationSizeForm(this, frm);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                    Program.MBarCapNhapThanhCong();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
                Program.MBarCapNhapKhongThanhCong();
            }
        }
        public void AddKho(object sender, EventArgs e)
        {
            try
            {
                if (iPQ != 1) return;
                frmEditKho frm = new frmEditKho(iPQ, null, true);
                Com.Mod.OS.LocationSizeForm(this, frm);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                    Program.MBarCapNhapThanhCong();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
                Program.MBarCapNhapKhongThanhCong();
            }
        }
        public void DeleteKhoViTri(object sender, EventArgs e)
        {

            int focusedRowHandle = grvChung.FocusedRowHandle;
            Int64 iID;
            string dMuc;
            string sTB;

            DataRow rows = grvChung.GetDataRow(grvChung.FocusedRowHandle) as DataRow;
            iID = Convert.ToInt64(rows["ID_KVT"]);
            dMuc = "mnuKhoViTri";
            sTB = "mnuBanCoMuonXoaKhoviTriKhong";

            try
            {
                if (grvChung.RowCount == 0)
                {
                    XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgKhongCoDuLieuDeXoa"), this.Text);
                    return;
                }
                if (!KiemSuDung(iID, dMuc)) return;
                if (XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", sTB), this.Text, MessageBoxButtons.YesNo) == DialogResult.No) return;
                #region Xoa

                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 2));
                lPar.Add(new SqlParameter("@iID", iID));
                lPar.Add(new SqlParameter("@sDMuc", dMuc));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                //tra về
                Int32 bKiem = Convert.ToInt32(VsMain.MExecuteScalar("spDanhMuc", lPar));
                if (bKiem == 1)
                {
                    XtraMessageBox.Show(Com.Mod.OS.GetLanguage(this.Name, "msgDelDangSuDung"), this.Text);
                    Program.MBarXoaThanhCong();
                }
                LoadData();
                #endregion
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgDelDangSuDung") + "\n" + ex.Message, this.Text);
                Program.MBarXoaKhongThanhCong();
            }
        }
        public void DeleteKho(object sender, EventArgs e)
        {

            int focusedRowHandle = grvChung.FocusedRowHandle;
            Int64 iID;
            string dMuc;
            string sTB;

            DataRow rows = grvChung.GetDataRow(grvChung.FocusedRowHandle) as DataRow;
            iID = Convert.ToInt64(rows["ID_KHO"]);
            dMuc = "mnuKho";
            sTB = "mnuBanCoMuonXoaKhoKhong";

            try
            {
                if (grvChung.RowCount == 0)
                {
                    XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgKhongCoDuLieuDeXoa"), this.Text);
                    return;
                }
                if (!KiemSuDung(iID, dMuc)) return;
                if (XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", sTB), this.Text, MessageBoxButtons.YesNo) == DialogResult.No) return;
                #region Xoa

                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 2));
                lPar.Add(new SqlParameter("@iID", iID));
                lPar.Add(new SqlParameter("@sDMuc", dMuc));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                //tra về
                Int32 bKiem = Convert.ToInt32(VsMain.MExecuteScalar("spDanhMuc", lPar));
                if (bKiem == 1)
                {
                    XtraMessageBox.Show(Com.Mod.OS.GetLanguage(this.Name, "msgDelDangSuDung"), this.Text);
                    Program.MBarXoaThanhCong();
                }
                LoadData();
                #endregion
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgDelDangSuDung") + "\n" + ex.Message, this.Text);
                Program.MBarXoaKhongThanhCong();
            }
        }
        #endregion
        #region Function
        private Boolean KiemSuDung( Int64 iID , string dMuc)
        {
            Boolean bKiem = false;
            try
            {
                #region KiemTrung loai = 6
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 6));
                lPar.Add(new SqlParameter("@sDMuc", dMuc));
                lPar.Add(new SqlParameter("@iID", iID)); ;
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet("spDanhMuc", lPar);
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
        #endregion
        #region Event
        private void frmKho_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();
                LoadNN();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnThemKho_Click(object sender, EventArgs e)
        {
            try
            {
                if (iPQ != 1) return;
                frmEditKho frm = new frmEditKho(iPQ, null, true);
                Com.Mod.OS.LocationSizeForm(this, frm);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                    Program.MBarCapNhapThanhCong();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
                Program.MBarCapNhapKhongThanhCong();
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {

            int focusedRowHandle = grvChung.FocusedRowHandle;
            Int64 iID;
            string dMuc;
            string sTB; 
            if (grvChung.IsGroupRow(focusedRowHandle))
            {
                DataRow rows = grvChung.GetDataRow(grvChung.FocusedRowHandle) as DataRow;
                iID = Convert.ToInt64(rows["ID_KHO"]);
                dMuc = "mnuKho";
                sTB = "mnuBanCoMuonXoaKhoKhong";

            }
            else
            {
                DataRow rows = grvChung.GetDataRow(grvChung.FocusedRowHandle) as DataRow;
                iID = Convert.ToInt64(rows["ID_KVT"]);
                dMuc = "mnuKhoViTri";
                sTB = "mnuBanCoMuonXoaKhoviTriKhong";

            }

            try
            {
                if (grvChung.RowCount == 0)
                {
                    XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgKhongCoDuLieuDeXoa"), this.Text);
                    return;
                }
                if (!KiemSuDung(iID, dMuc)) return;
                if (XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", sTB), this.Text, MessageBoxButtons.YesNo) == DialogResult.No) return;
                #region Xoa

                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 2));
                lPar.Add(new SqlParameter("@iID", iID));
                lPar.Add(new SqlParameter("@sDMuc", dMuc));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                //tra về
                Int32 bKiem = Convert.ToInt32(VsMain.MExecuteScalar("spDanhMuc", lPar));
                if (bKiem == 1)
                {
                    XtraMessageBox.Show(Com.Mod.OS.GetLanguage(this.Name, "msgDelDangSuDung"), this.Text);
                    Program.MBarXoaThanhCong();
                }
                LoadData();
                #endregion
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgDelDangSuDung") + "\n" + ex.Message, this.Text);
                Program.MBarXoaKhongThanhCong();
            }
        }
        #endregion

        
    }
}
