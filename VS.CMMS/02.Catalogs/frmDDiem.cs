using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
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
using System.Reflection;
using static DevExpress.Utils.Drawing.Helpers.NativeMethods;

namespace VS.CMMS
{
    public partial class frmDDiem : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = 1;// =1: full/ <>1: readonly
        private Color _highlightColor;
        string sSP; 
        public frmDDiem(int PQ, string Find, string SP)
        {
            InitializeComponent();
            iPQ = PQ;
            sSP = SP;
            this.treDiaDiem.PopupMenuShowing += new DevExpress.XtraTreeList.PopupMenuShowingEventHandler(this.treDiaDiem_PopupMenuShowing);
            this.treDiaDiem.DoubleClick += new System.EventHandler(this.treDiaDiem_DoubleClick);
        }
        #region Load
        private void frmDDiem_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadNN();
        }
        private void LoadData()
        {
            try
            {
                if (Com.Mod.sLoad == "0Load") return;
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 7));
                lPar.Add(new SqlParameter("@sDMuc", "mnuDDiem"));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@ID_USER", Com.Mod.UserID));
                lPar.Add(new SqlParameter("@iID", -1));

                DataTable dtTmp = new DataTable();
                dtTmp = VsMain.MGetDatatable(sSP, lPar);
                treDiaDiem.DataSource = null;
                treDiaDiem.BeginUpdate();
                treDiaDiem.DataSource = dtTmp;
                treDiaDiem.KeyFieldName = "ID_DD";
                treDiaDiem.ParentFieldName = "ID_DD_CHA";
                treDiaDiem.EndUpdate();
                Format_TreeList();
                StatusControl();
                treDiaDiem.ExpandAll();

            }
            catch (Exception ex)
            { Program.MBarThongTin(ex.Message.ToString(), true); }
        }
        private void LoadNN()
        {
            try
            {
                Com.Mod.OS.MLoadNNXtraTreeList(treDiaDiem, this.Name.ToString());
                Com.Mod.OS.MSaveResertLTree(treDiaDiem, this.Name.ToString());
                Com.Mod.OS.ThayDoiNN(this, dataLayoutControl1);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        private void Format_TreeList()
        {
            try
            {
                //Config treelist view
                treDiaDiem.BeginUpdate();

                //Add button Thêm, Xóa
                DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnThem = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
                btnThem.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
                btnThem.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
                btnThem.Buttons[0].Caption = "+";

                treDiaDiem.Columns["THEM"].ColumnEdit = btnThem;
                treDiaDiem.Columns["THEM"].Visible = true;

                btnThem.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(btnThem_ButtonClick);

                DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnXoa = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
                btnXoa.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
                btnXoa.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
                btnXoa.Buttons[0].Caption = "X";

                treDiaDiem.Columns["XOA"].ColumnEdit = btnXoa;
                treDiaDiem.Columns["XOA"].Visible = true;

                btnXoa.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(btnXoa_ButtonClick);

                //Set edit tree list
                for (int i = 0; i < treDiaDiem.Columns.Count; i++)
                {
                    treDiaDiem.Columns[i].OptionsColumn.AllowEdit = false;
                }
                treDiaDiem.Columns["THEM"].OptionsColumn.AllowEdit = true;
                treDiaDiem.Columns["XOA"].OptionsColumn.AllowEdit = true;

                treDiaDiem.EndUpdate();
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

                    treDiaDiem.Columns["THEM"].Visible = false;
                    treDiaDiem.Columns["XOA"].Visible = false;

                }
                else
                {

                    treDiaDiem.Columns["THEM"].Visible = true;
                    treDiaDiem.Columns["XOA"].Visible = true;

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        #endregion

        #region Xử lý chuột phải
        private void treDiaDiem_PopupMenuShowing(object sender, DevExpress.XtraTreeList.PopupMenuShowingEventArgs e)
        {
            try
            {
                TreeListHitInfo hitInfo = (sender as TreeList).CalcHitInfo(e.Point);
                TreeListNode node = null;
                node = hitInfo.Node;
                if (node == null) return;

                DXMenuItem itemAddKho = new DXMenuItem(Com.Mod.OS.GetLanguage(this.Name, "btnThemDDiem"), AddDDiem);
                itemAddKho.Tag = node;
                e.Menu.Items.Add(itemAddKho);

                DXMenuItem itemEditKho = new DXMenuItem(Com.Mod.OS.GetLanguage(this.Name, "btnSuaDDiem"), EditDiaDiem);
                itemEditKho.Tag = node;
                e.Menu.Items.Add(itemEditKho);

                DXMenuItem itemDeleteKho = new DXMenuItem(Com.Mod.OS.GetLanguage(this.Name, "btnXoaDDiem"), DeleteDiaDiem);
                itemDeleteKho.Tag = node;
                e.Menu.Items.Add(itemDeleteKho);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        public void AddDDiem(object sender, EventArgs e)
        {
            try
            {
                int ID_DD = string.IsNullOrEmpty(treDiaDiem.FocusedNode.GetValue("ID_DD").ToString()) ? 0 : Convert.ToInt32(treDiaDiem.FocusedNode.GetValue("ID_DD"));
                if (Com.Mod.sLoad == "0Load") return;
                if (iPQ != 1) return;
                frmEditDiaDiem frm = new frmEditDiaDiem(iPQ, null, true, ID_DD);
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
        public void EditDiaDiem(object sender, EventArgs e)
        {
            try
            {
                int ID_DDIEM = string.IsNullOrEmpty(treDiaDiem.FocusedNode.GetValue("ID_DD").ToString()) ? 0 : Convert.ToInt32(treDiaDiem.FocusedNode.GetValue("ID_DD"));
                int ID_DDIEM_CHA = string.IsNullOrEmpty(treDiaDiem.FocusedNode.GetValue("ID_DD_CHA").ToString()) ? 0 : Convert.ToInt32(treDiaDiem.FocusedNode.GetValue("ID_DD_CHA"));
                if (ID_DDIEM == 0) return;
                if (Com.Mod.sLoad == "0Load") return;
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 1));
                lPar.Add(new SqlParameter("@sDMuc", "mnuDDiem"));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                lPar.Add(new SqlParameter("@iID", ID_DDIEM));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet(sSP, lPar);
                DataTable dt = new DataTable();
                dt = ds.Tables[0].Copy();
                DataRow row = dt.Rows[0];

                if (row == null) return;

                frmEditDiaDiem frm = new frmEditDiaDiem(iPQ, row, false, ID_DDIEM_CHA);
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
        public void DeleteDiaDiem(object sender, EventArgs e)
        {

        }
        #endregion

        #region Event
        private void btnThem_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int ID_DD = string.IsNullOrEmpty(treDiaDiem.FocusedNode.GetValue("ID_DD").ToString()) ? 0 : Convert.ToInt32(treDiaDiem.FocusedNode.GetValue("ID_DD"));
                if (Com.Mod.sLoad == "0Load") return;
                if (iPQ != 1) return;
                frmEditDiaDiem frm = new frmEditDiaDiem(iPQ, null, true, ID_DD);
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
        private void btnXoa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
          

            try
            {
                int ID_DD = string.IsNullOrEmpty(treDiaDiem.FocusedNode.GetValue("ID_DD").ToString()) ? 0 : Convert.ToInt32(treDiaDiem.FocusedNode.GetValue("ID_DD"));
                string dMuc = "mnuDDiem";
                string sTB = "msgBanCoChacXoa";
                if (!KiemSuDung(ID_DD, dMuc)) return;
                if (XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", sTB), this.Text, MessageBoxButtons.YesNo) == DialogResult.No) return;
                #region Xoa

                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 2));
                lPar.Add(new SqlParameter("@iID", ID_DD));
                lPar.Add(new SqlParameter("@sDMuc", "mnuDDiem"));
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
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int ID_DD = string.IsNullOrEmpty(treDiaDiem.FocusedNode.GetValue("ID_DD").ToString()) ? 0 : Convert.ToInt32(treDiaDiem.FocusedNode.GetValue("ID_DD"));
                if (Com.Mod.sLoad == "0Load") return;
                if (iPQ != 1) return;
                frmEditDiaDiem frm = new frmEditDiaDiem(iPQ, null, true, ID_DD);
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
        private void treDiaDiem_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int ID_DDIEM = string.IsNullOrEmpty(treDiaDiem.FocusedNode.GetValue("ID_DD").ToString()) ? 0 : Convert.ToInt32(treDiaDiem.FocusedNode.GetValue("ID_DD"));
                int ID_DDIEM_CHA = string.IsNullOrEmpty(treDiaDiem.FocusedNode.GetValue("ID_DD_CHA").ToString()) ? 0 : Convert.ToInt32(treDiaDiem.FocusedNode.GetValue("ID_DD_CHA"));
                if (ID_DDIEM == 0) return;
                if (Com.Mod.sLoad == "0Load") return;
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 1));
                lPar.Add(new SqlParameter("@sDMuc", "mnuDDiem"));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                lPar.Add(new SqlParameter("@iID", ID_DDIEM));
                DataSet ds = new DataSet(); 
                ds = VsMain.MGetDataSet(sSP, lPar);
                DataTable dt = new DataTable();
                dt = ds.Tables[0].Copy();
                DataRow row = dt.Rows[0];

                if (row == null) return;

                frmEditDiaDiem frm = new frmEditDiaDiem(iPQ, row, false, ID_DDIEM_CHA);
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
        #endregion
    }
}
