using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Localization;
using DevExpress.XtraTreeList.Nodes;
using DXApplication1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VS.CMMS
{
    public partial class frmKho : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = 1;// =1: full/ <>1: readonly
        private Color _highlightColor;
        string sSP;
        public frmKho(int PQ, string Find, string SP)
        {
            
            InitializeComponent();
            iPQ = PQ;
            sSP = SP;
            if (iPQ != 1)
            {
                lciThemKho.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else
            {
                lciThemKho.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            this.treKho.PopupMenuShowing += new DevExpress.XtraTreeList.PopupMenuShowingEventHandler(this.treKho_PopupMenuShowing);
            this.treKho.DoubleClick += new System.EventHandler(this.treKho_DoubleClick);

        }

        #region Event
        private void frmKho_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();
               ///// Com.Mod.OS.MSaveResertLTree(tlKho, this.Name);
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

       private void treKho_DoubleClick(object sender, EventArgs e)
        {
            TreeList tree = sender as TreeList;
            TreeListHitInfo hi = tree.CalcHitInfo(tree.PointToClient(Control.MousePosition));
            if (hi.Node != null)
            {
                try
                {
                    //Sửa kho
                    if (treKho.FocusedNode.GetValue("ID_CHA") == DBNull.Value && treKho.FocusedNode.GetValue("ID_KVT") == DBNull.Value)
                    {
                        int ID_KHO = string.IsNullOrEmpty(treKho.FocusedNode.GetValue("ID_KHO").ToString()) ? 0 : Convert.ToInt32(treKho.FocusedNode.GetValue("ID_KHO"));

                        //ID_KHO = 0 => Lỗi dữ liệu
                        if (ID_KHO == 0) return;
                        if (Com.Mod.sLoad == "0Load") return;
                        List<SqlParameter> lPar = new List<SqlParameter>();
                        lPar.Add(new SqlParameter("@iLoai", 1));
                        lPar.Add(new SqlParameter("@sDMuc", "mnuKho"));
                        lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                        lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                        lPar.Add(new SqlParameter("@iID", ID_KHO));
                        lPar.Add(new SqlParameter("@ID_USER", Com.Mod.UserID));
                        DataSet ds = new DataSet();
                        ds = VsMain.MGetDataSet(sSP, lPar);
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
                    //Sửa kho vị trí
                    else
                    {
                        int ID_KVT = string.IsNullOrEmpty(treKho.FocusedNode.GetValue("ID_KVT").ToString()) ? 0 : Convert.ToInt32(treKho.FocusedNode.GetValue("ID_KVT"));
                        int ID_KHO = string.IsNullOrEmpty(treKho.FocusedNode.GetValue("ID_KHO").ToString()) ? 0 : Convert.ToInt32(treKho.FocusedNode.GetValue("ID_KHO"));
                        int ID_KVT_CHA = string.IsNullOrEmpty(treKho.FocusedNode.GetValue("ID_KVT_CHA").ToString()) ? 0 : Convert.ToInt32(treKho.FocusedNode.GetValue("ID_KVT_CHA"));

                        //ID_KVT || ID_KHO = 0 => Lỗi dữ liệu
                        if (ID_KVT == 0 || ID_KHO == 0) return;
                        if (Com.Mod.sLoad == "0Load") return;
                        List<SqlParameter> lPar = new List<SqlParameter>();
                        lPar.Add(new SqlParameter("@iLoai", 1));
                        lPar.Add(new SqlParameter("@sDMuc", "mnuKhoViTri"));
                        lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                        lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                        lPar.Add(new SqlParameter("@iID", ID_KVT));

                        DataSet ds = new DataSet();
                        ds = VsMain.MGetDataSet(sSP, lPar);
                        DataTable dt = new DataTable();
                        dt = ds.Tables[0].Copy();
                        DataRow row = dt.Rows[0];

                        //Row = null => Lỗi dữ liệu
                        if (row == null) return;

                        frmEditKhoViTri frm = new frmEditKhoViTri(iPQ, row, false, ID_KHO, ID_KVT_CHA, ID_KVT );
                        Com.Mod.OS.LocationSizeForm(this, frm);
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            LoadData();
                            Program.MBarCapNhapThanhCong();
                        }
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, this.Text);
                    Program.MBarCapNhapKhongThanhCong();
                }
            }
        }

        private void btnThem_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                Int64 ID_KHO = string.IsNullOrEmpty(treKho.FocusedNode.GetValue("ID_KHO").ToString()) ? 0 : Convert.ToInt64(treKho.FocusedNode.GetValue("ID_KHO"));
                Int64 ID_KVT = string.IsNullOrEmpty(treKho.FocusedNode.GetValue("ID_KVT").ToString()) ? 0 : Convert.ToInt64(treKho.FocusedNode.GetValue("ID_KVT"));
                Int64 ID_KVT_CHA = string.IsNullOrEmpty(treKho.FocusedNode.GetValue("ID_KVT_CHA").ToString()) ? 0 : Convert.ToInt64(treKho.FocusedNode.GetValue("ID_KVT"));
               
                //ID_KHO = 0 => Lỗi không dữ liệu
                if (ID_KHO == 0) return;

                frmEditKhoViTri frm = new frmEditKhoViTri(iPQ, null, true, ID_KHO , ID_KVT_CHA, ID_KVT);
                Com.Mod.OS.LocationSizeForm(this, frm);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                    Program.MBarCapNhapThanhCong();
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
                Program.MBarCapNhapKhongThanhCong();
            }
        }

        private void btnXoa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (treKho.FocusedNode.GetValue("ID_CHA") == DBNull.Value && treKho.FocusedNode.GetValue("ID_KVT") == DBNull.Value)
                {
                    int ID_KVT = string.IsNullOrEmpty(treKho.FocusedNode.GetValue("ID_KVT").ToString()) ? 0 : Convert.ToInt32(treKho.FocusedNode.GetValue("ID_KVT"));
                    int ID_KHO = string.IsNullOrEmpty(treKho.FocusedNode.GetValue("ID_KHO").ToString()) ? 0 : Convert.ToInt32(treKho.FocusedNode.GetValue("ID_KHO"));
                    string dMuc = "mnuKho";
                    string sTB = "mnuBanCoMuonXoaKhoKhong";

                    try
                    {

                        if (!KiemSuDung(ID_KHO, dMuc)) return;
                        if (XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", sTB), this.Text, MessageBoxButtons.YesNo) == DialogResult.No) return;
                        #region Xoa

                        List<SqlParameter> lPar = new List<SqlParameter>();
                        lPar.Add(new SqlParameter("@iLoai", 2));
                        lPar.Add(new SqlParameter("@iID", ID_KHO));
                        lPar.Add(new SqlParameter("@sDMuc", dMuc));
                        lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                        lPar.Add(new SqlParameter("@UName", Com.Mod.UName));

                        Int32 bKiem = Convert.ToInt32(VsMain.MExecuteScalar(sSP, lPar));
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
                else
                {
                    string dMuc;
                    string sTB;

                    int ID_KVT = string.IsNullOrEmpty(treKho.FocusedNode.GetValue("ID_KVT").ToString()) ? 0 : Convert.ToInt32(treKho.FocusedNode.GetValue("ID_KVT"));
                    int ID_KHO = string.IsNullOrEmpty(treKho.FocusedNode.GetValue("ID_KHO").ToString()) ? 0 : Convert.ToInt32(treKho.FocusedNode.GetValue("ID_KHO"));
                    dMuc = "mnuKhoViTri";
                    sTB = "mnuBanCoMuonXoaKhoviTriKhong";

                    try
                    {

                        if (!KiemSuDung(ID_KVT, dMuc)) return;
                        if (XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", sTB), this.Text, MessageBoxButtons.YesNo) == DialogResult.No) return;
                        #region Xoa

                        List<SqlParameter> lPar = new List<SqlParameter>();
                        lPar.Add(new SqlParameter("@iLoai", 2));
                        lPar.Add(new SqlParameter("@iID", ID_KVT));
                        lPar.Add(new SqlParameter("@sDMuc", dMuc));
                        lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                        lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                        //tra về
                        Int32 bKiem = Convert.ToInt32(VsMain.MExecuteScalar(sSP, lPar));
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
            }
            catch 
            {
                XtraMessageBox.Show(Com.Mod.OS.GetLanguage(this.Name, "msgXoaThatBai"), this.Text);
                Program.MBarXoaKhongThanhCong();
            }

        }

        private void tlKho_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(e.Node.GetValue("ID_CHA").ToString()))
                {
                    e.Appearance.ForeColor = _highlightColor;

                    try
                    {
                        if (VS.CMMS.Properties.Settings.Default["ApplicationFontRequestName"].ToString() == "")
                        {
                            VS.CMMS.Properties.Settings.Default["ApplicationFontRequestName"] = "Segoe UI";
                            VS.CMMS.Properties.Settings.Default["ApplicationFontRequestSize"] = "9";
                            VS.CMMS.Properties.Settings.Default["ApplicationFontRequestBold"] = "false";
                            VS.CMMS.Properties.Settings.Default["ApplicationFontRequestItalic"] = "false";
                            VS.CMMS.Properties.Settings.Default.Save();
                        }

                        e.Appearance.Font = new System.Drawing.Font(VS.CMMS.Properties.Settings.Default["ApplicationFontRequestName"].ToString(), float.Parse(VS.CMMS.Properties.Settings.Default["ApplicationFontRequestSize"].ToString()), (VS.CMMS.Properties.Settings.Default["ApplicationFontRequestBold"].ToString().ToUpper() == "TRUE" ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular) | (VS.CMMS                               .Properties.Settings.Default["ApplicationFontRequestItalic"].ToString().ToUpper() == "TRUE" ? System.Drawing.FontStyle.Italic : System.Drawing.FontStyle.Regular));
                            
                    }
                    catch
                    {


                        VS.CMMS.Properties.Settings.Default["ApplicationFontRequestName"] = "Segoe UI";
                        VS.CMMS.Properties.Settings.Default["ApplicationFontRequestSize"] = "9";
                        VS.CMMS.Properties.Settings.Default["ApplicationFontRequestBold"] = "false";
                        VS.CMMS.Properties.Settings.Default["ApplicationFontRequestItalic"] = "false";

                        e.Appearance.Font = new System.Drawing.Font(VS.CMMS.Properties.Settings.Default["ApplicationFontRequestName"].ToString(), float.Parse(VS.CMMS.Properties.Settings.Default["ApplicationFontRequestSize"].ToString()), (VS.CMMS.Properties.Settings.Default["ApplicationFontRequestBold"].ToString().ToUpper() == "TRUE" ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular) | (VS.CMMS.Properties.Settings.Default["ApplicationFontRequestItalic"].ToString().ToUpper() == "TRUE" ? System.Drawing.FontStyle.Italic : System.Drawing.FontStyle.Regular));
                    }
                }
                else
                    e.Appearance.ForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }

        }
        #endregion

        #region Xử lý chuột phải
        private void treKho_PopupMenuShowing(object sender, DevExpress.XtraTreeList.PopupMenuShowingEventArgs e)
        {
            try
            {
                TreeListHitInfo hitInfo = (sender as TreeList).CalcHitInfo(e.Point);
                TreeListNode node = null;
                node = hitInfo.Node;
                if (node == null) return;

                if (treKho.FocusedNode.GetValue("ID_CHA") == DBNull.Value && treKho.FocusedNode.GetValue("ID_KVT") == DBNull.Value)
                {
                    DXMenuItem itemAddKho = new DXMenuItem(Com.Mod.OS.GetLanguage(this.Name, "btnThemKVT"), AddKhoViTri);
                    itemAddKho.Tag = node;
                    e.Menu.Items.Add(itemAddKho);

                    DXMenuItem itemEditKho = new DXMenuItem(Com.Mod.OS.GetLanguage(this.Name, "btnSuaKho"), EditKho);
                    itemEditKho.Tag = node;
                    e.Menu.Items.Add(itemEditKho);

                    DXMenuItem itemDeleteKho = new DXMenuItem(Com.Mod.OS.GetLanguage(this.Name, "btnXoaKho"), DeleteKho);
                    itemDeleteKho.Tag = node;
                    e.Menu.Items.Add(itemDeleteKho);
                }
                else
                {
                    DXMenuItem itemAddKho = new DXMenuItem(Com.Mod.OS.GetLanguage(this.Name, "btnThemKVT"), AddKhoViTri);
                    itemAddKho.Tag = node;
                    e.Menu.Items.Add(itemAddKho);

                    DXMenuItem itemEditKho = new DXMenuItem(Com.Mod.OS.GetLanguage(this.Name, "btnSuaKVT"), EditKhoViTri);
                    itemEditKho.Tag = node;
                    e.Menu.Items.Add(itemEditKho);

                    DXMenuItem itemDeleteKho = new DXMenuItem(Com.Mod.OS.GetLanguage(this.Name, "btnXoaKVT"), DeleteKhoViTri);
                    itemDeleteKho.Tag = node;
                    e.Menu.Items.Add(itemDeleteKho);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }

        public void EditKho(object sender, EventArgs e)
        {
            try
            {
                int ID_KVT = string.IsNullOrEmpty(treKho.FocusedNode.GetValue("ID_KVT").ToString()) ? 0 : Convert.ToInt32(treKho.FocusedNode.GetValue("ID_KVT"));
                int ID_KHO = string.IsNullOrEmpty(treKho.FocusedNode.GetValue("ID_KHO").ToString()) ? 0 : Convert.ToInt32(treKho.FocusedNode.GetValue("ID_KHO"));
                if (ID_KHO == 0) return;
                if (Com.Mod.sLoad == "0Load") return;
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 1));
                lPar.Add(new SqlParameter("@sDMuc", "mnuKho"));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                lPar.Add(new SqlParameter("@iID", ID_KHO));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet(sSP, lPar);
                DataTable dt = new DataTable();
                dt = ds.Tables[0].Copy();
                DataRow row = dt.Rows[0];

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
                int ID_KVT = string.IsNullOrEmpty(treKho.FocusedNode.GetValue("ID_KVT").ToString()) ? 0 : Convert.ToInt32(treKho.FocusedNode.GetValue("ID_KVT"));
                int ID_KHO = string.IsNullOrEmpty(treKho.FocusedNode.GetValue("ID_KHO").ToString()) ? 0 : Convert.ToInt32(treKho.FocusedNode.GetValue("ID_KHO"));
                int ID_KVT_CHA = string.IsNullOrEmpty(treKho.FocusedNode.GetValue("ID_KVT_CHA").ToString()) ? 0 : Convert.ToInt32(treKho.FocusedNode.GetValue("ID_KHO"));
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 1));
                lPar.Add(new SqlParameter("@sDMuc", "mnuKhoViTri"));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                lPar.Add(new SqlParameter("@iID", ID_KVT));

                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet(sSP, lPar);
                DataTable dt = new DataTable();
                dt = ds.Tables[0].Copy();
                DataRow row = dt.Rows[0];

                //Row = null => Lỗi dữ liệu
                if (row == null) return;

                frmEditKhoViTri frm = new frmEditKhoViTri(iPQ, row, false, ID_KHO, ID_KVT_CHA, ID_KVT);
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
                int ID_KVT = string.IsNullOrEmpty(treKho.FocusedNode.GetValue("ID_KVT").ToString()) ? 0 : Convert.ToInt32(treKho.FocusedNode.GetValue("ID_KVT"));
                int ID_KHO = string.IsNullOrEmpty(treKho.FocusedNode.GetValue("ID_KHO").ToString()) ? 0 : Convert.ToInt32(treKho.FocusedNode.GetValue("ID_KHO"));
                int ID_KVT_CHA = string.IsNullOrEmpty(treKho.FocusedNode.GetValue("ID_KVT_CHA").ToString()) ? 0 : Convert.ToInt32(treKho.FocusedNode.GetValue("ID_KHO"));

  
                if (iPQ != 1) return;
                frmEditKhoViTri frm = new frmEditKhoViTri(iPQ, null, true, ID_KHO , ID_KVT_CHA ,ID_KVT);
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

        private Boolean KiemSuDung(Int64 iID, string dMuc)
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
                ds = VsMain.MGetDataSet(sSP, lPar);
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

        public void DeleteKhoViTri(object sender, EventArgs e)
        {
            string dMuc;
            string sTB;

            int ID_KVT = string.IsNullOrEmpty(treKho.FocusedNode.GetValue("ID_KVT").ToString()) ? 0 : Convert.ToInt32(treKho.FocusedNode.GetValue("ID_KVT"));
            int ID_KHO = string.IsNullOrEmpty(treKho.FocusedNode.GetValue("ID_KHO").ToString()) ? 0 : Convert.ToInt32(treKho.FocusedNode.GetValue("ID_KHO"));
            dMuc = "mnuKhoViTri";
            sTB = "mnuBanCoMuonXoaKhoviTriKhong";

            try
            {

                if (!KiemSuDung(ID_KVT, dMuc)) return;
                if (XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", sTB), this.Text, MessageBoxButtons.YesNo) == DialogResult.No) return;
                #region Xoa

                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 2));
                lPar.Add(new SqlParameter("@iID", ID_KVT));
                lPar.Add(new SqlParameter("@sDMuc", dMuc));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                //tra về
                Int32 bKiem = Convert.ToInt32(VsMain.MExecuteScalar(sSP, lPar));
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


            int ID_KVT = string.IsNullOrEmpty(treKho.FocusedNode.GetValue("ID_KVT").ToString()) ? 0 : Convert.ToInt32(treKho.FocusedNode.GetValue("ID_KVT"));
            int ID_KHO = string.IsNullOrEmpty(treKho.FocusedNode.GetValue("ID_KHO").ToString()) ? 0 : Convert.ToInt32(treKho.FocusedNode.GetValue("ID_KHO"));
            string dMuc = "mnuKho";
            string sTB = "mnuBanCoMuonXoaKhoKhong";

            try
            {
                
                if (!KiemSuDung(ID_KHO, dMuc)) return;
                if (XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", sTB), this.Text, MessageBoxButtons.YesNo) == DialogResult.No) return;
                #region Xoa

                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 2));
                lPar.Add(new SqlParameter("@iID", ID_KHO));
                lPar.Add(new SqlParameter("@sDMuc", dMuc));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));

                Int32 bKiem = Convert.ToInt32(VsMain.MExecuteScalar(sSP, lPar));
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
        private void LoadNN()
        {
            try
            {
                Com.Mod.OS.MLoadNNXtraTreeList(treKho, this.Name.ToString());
                Com.Mod.OS.MSaveResertLTree(treKho, this.Name.ToString());
                Com.Mod.OS.ThayDoiNN(this, dataLayoutControl1);
            }
            catch (Exception ex) { }
        }

        private void LoadData()
        {
            try
            {
                if (Com.Mod.sLoad == "0Load") return;
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 7));
                lPar.Add(new SqlParameter("@sDMuc", "mnuKho"));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@ID_USER", Com.Mod.UserID));
                lPar.Add(new SqlParameter("@iID", -1));

                DataTable dtTmp = new DataTable();
                dtTmp = VsMain.MGetDatatable(sSP, lPar);
                treKho.DataSource = null;
                treKho.BeginUpdate();
                treKho.DataSource = dtTmp;
                treKho.KeyFieldName = "ID_K_KVT";
                treKho.ParentFieldName = "ID_CHA";
                treKho.EndUpdate();
                Format_TreeList();
                StatusControl();
               ////treKho.ExpandAll();
                
            }
            catch (Exception ex)
            { Program.MBarThongTin(ex.Message.ToString(), true); }
        }

        private void Format_TreeList()
        {
            try
            {
                //Config treelist view
                treKho.BeginUpdate();

                //Add button Thêm, Xóa
                DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnThem = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
                btnThem.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
                btnThem.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
                btnThem.Buttons[0].Caption = "+";

                treKho.Columns["THEM"].ColumnEdit = btnThem;
                treKho.Columns["THEM"].Visible = true;

                btnThem.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(btnThem_ButtonClick);

                DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnXoa = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
                btnXoa.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
                btnXoa.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
                btnXoa.Buttons[0].Caption = "X";

                treKho.Columns["XOA"].ColumnEdit = btnXoa;
                treKho.Columns["XOA"].Visible = true;

                btnXoa.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(btnXoa_ButtonClick);

                //Set edit tree list
                for (int i = 0; i < treKho.Columns.Count; i++)
                {
                    treKho.Columns[i].OptionsColumn.AllowEdit = false;
                }
                treKho.Columns["THEM"].OptionsColumn.AllowEdit = true;
                treKho.Columns["XOA"].OptionsColumn.AllowEdit = true;

                //Visible
                treKho.Columns["ID_KHO"].Visible = false;
                treKho.Columns["ID_KVT"].Visible = false;
                treKho.Columns["THU_TU"].Visible = false;

                treKho.EndUpdate();
            }
            catch (Exception ex) 
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }

        private void StatusControl()
        {
            try
            {
                if (iPQ != 1)
                {

                    treKho.Columns["THEM"].Visible = false;
                    treKho.Columns["XOA"].Visible = false;

                }
                else
                {

                    treKho.Columns["THEM"].Visible = true;
                    treKho.Columns["XOA"].Visible = true;

                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }

        #endregion

    }
}
