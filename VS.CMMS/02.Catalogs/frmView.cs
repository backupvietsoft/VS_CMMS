using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraPrintingLinks;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Forms;
using static System.Windows.Forms.ImageList;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace VS.CMMS
{
    public partial class frmView : DevExpress.XtraEditors.XtraForm
    {
        string sfind = "-1";  // -1 la view menu <> -1 là view tu menu -- 
        Boolean bView = true;  //true là viwe form, faorm tu form find
        int iPQ = 1;  // == 1  full; <> 1 la read only
        string sPS = "spDanhMuc";
        // Dữ liệu được chọn
        public frmView(int PQ, string Find, string SP)
        {
            if (Find == "-1")
            { bView = true; sfind = ""; }
            else { bView = false; sfind = Find; }
            InitializeComponent();
            sPS = SP;
            iPQ = PQ;
            txtTim.Text = sfind;
         

            if(sPS == "spDMPT")
            {
                this.lbl.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                this.lblKhachHang.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                lblKhachHang.Move(lbl, DevExpress.XtraLayout.Utils.InsertType.Left, DevExpress.XtraLayout.Utils.MoveType.Inside);

            }
           
        }

        #region Load
        private void frmView_Load(object sender, EventArgs e)
        {
            try
            {
                Com.Mod.OS.ShowWaitForm(this);
                
                if(sPS == "spDMPT")
                {
                    this.cboID_DT_BH.EditValueChanged += new System.EventHandler(this.cboID_DT_BH_EditValueChanged);
                    this.optActive.SelectedIndexChanged += new System.EventHandler(this.optActive_SelectedIndexChanged);
                    Com.Mod.sLoad = "0Load";
                    LoadCboLPT();
                    optActive.SelectedIndex = 0;
                    LoadDataPT();
                }
                else
                {
                    LoadData(-1);
                }
                LoadNN();

                grvChung.ExpandAllGroups();
                if (iPQ != 1)
                {
                    layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    btnIN.Visible = false;
                    layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    btnThem.Visible = false;
                    layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    btnXoa.Visible = false;
                }
                else
                {
                    if (!bView)
                    {
                        btnThem.Visible = false;
                        layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        btnXoa.Visible = false;
                        layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    }
                }
                if (sfind == "1")
                {
                    lbl.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }
                if (sfind != "") txtTim.Text = sfind;
                txtTim.Focus();

            }catch(Exception EX)
            {
                XtraMessageBox.Show(EX.Message.ToString(), this.Text);
            }
            Com.Mod.OS.HideWaitForm();
        }
        private void LoadCbo()
        {
            try
            {
                DataTable dt = new DataTable();
                var sqlcom = new SqlCommand();
                var con = new SqlConnection(Com.Mod.CNStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                sqlcom.Connection = con;
                sqlcom.Parameters.AddWithValue("iALL", "1");
                sqlcom.Parameters.AddWithValue("sALL", " < All > ");
                sqlcom.Parameters.AddWithValue("NNgu", Com.Mod.iNNgu.ToString());
                sqlcom.Parameters.AddWithValue("sDanhMuc", "DOI_TAC_KH;");
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.CommandText = "spGetDataCatalogs";
                var da = new SqlDataAdapter(sqlcom);
                var ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0].Copy();

                DataRow dr1 = dt.NewRow();
                dr1["ID_DT"] = -99;
                dt.Rows.Add(dr1);

                if (dt.Rows.Count > 0)
                {
                    dt.DefaultView.Sort = "ID_DT ASC, TEN_NGAN ASC";
                    dt = dt.DefaultView.ToTable();
                }
                Com.Mod.OS.MLoadSearchLookUpEdit(cboID_DT_BH, dt, "ID_DT", "TEN_NGAN", Com.Mod.OS.GetLanguage(this.Name, "TEN_NGAN"));

                cboID_DT_BH.EditValue = -1;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }


        private void LoadCboLPT()
        {
            try
             {
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iALL", "1"));
                lPar.Add(new SqlParameter("@iCoALL", -1));
                lPar.Add(new SqlParameter("@sALL", ""));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                lPar.Add(new SqlParameter("@sDanhMuc", "LOAI_PHU_TUNG;"));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet("spGetDataCatalogs", lPar);
                DataTable dt = new DataTable();
                dt = ds.Tables[0].Copy();
                Com.Mod.OS.MLoadSearchLookUpEdit(cboID_DT_BH, dt, "ID_LPT", "TEN_LPT", this.Name);
                cboID_DT_BH.Properties.View.Columns["TT_LPT"].Visible = false;
            }
            catch { }
        }
        public void LoadNN()
        {
            try
            {
                Com.Mod.sLoad = "0Load";
                Com.Mod.OS.ThayDoiNN(this, dataLayoutControl1);
                Com.Mod.OS.MLoadNNXtraGrid(grvChung, this.Name, true);
                Com.Mod.sLoad = "";
            }
            catch { }
        }
        private void LoadData(Int64 iID)
        {
            try
            {
                if (Convert.ToString(this.Tag) == "mnuLoaiCV")
                {
                    this.grvChung.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grvChung_RowCellStyle);
                }
                if (Com.Mod.sLoad == "0Load") return;
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 1));
                lPar.Add(new SqlParameter("@sDMuc", this.Tag));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet(sPS, lPar);
                DataTable dtTmp = new DataTable();
                dtTmp = ds.Tables[0].Copy();
                dtTmp.PrimaryKey = new DataColumn[] { dtTmp.Columns[0] };

                if (grdChung.DataSource == null)
                {
                    if (dtTmp.Columns.Count < 10)
                        Com.Mod.OS.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, true, true);
                    else
                        Com.Mod.OS.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, false, false);
                }
                else
                    grdChung.DataSource = dtTmp;
                
                if (iID != -1)
                {
                    int index = dtTmp.Rows.IndexOf(dtTmp.Rows.Find(iID));
                    grvChung.FocusedRowHandle = grvChung.GetRowHandle(index);
                    grvChung.SelectRow(index);
                }
                else
                {
                    grvChung.FocusedRowHandle = 0;
                    grvChung.SelectRow(0);
                }

                DXSkinColors xColor = new DXSkinColors();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        #endregion
        //giành riêng cho phụ tùng
        private void LoadDataPT()
        {
            try
            {
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 1));
                lPar.Add(new SqlParameter("@sDMuc", this.Tag));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                lPar.Add(new SqlParameter("@ID_PT", cboID_DT_BH.EditValue == null ? -1 : Convert.ToInt64(cboID_DT_BH.EditValue)));
                lPar.Add(new SqlParameter("@KHONG_SD", Convert.ToInt32(optActive.SelectedIndex) - 1));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet(sPS, lPar);
                DataTable dtTmp = new DataTable();
                dtTmp = ds.Tables[0].Copy();
                dtTmp.PrimaryKey = new DataColumn[] { dtTmp.Columns[0] };

                if (grdChung.DataSource == null)
                {
                    if (dtTmp.Columns.Count < 10)
                        Com.Mod.OS.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, true, true);
                    else
                        Com.Mod.OS.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, false, false);
                }
                else
                    grdChung.DataSource = dtTmp;

                Com.Mod.sLoad = "";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        #region Function
        private Boolean KiemSuDung()
        {
            Boolean bKiem = false;
            try
            {
                #region KiemTrung loai = 6
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 6));
                lPar.Add(new SqlParameter("@sDMuc", this.Tag));
                lPar.Add(new SqlParameter("@iID", grvChung.GetFocusedRowCellValue(((DataTable)grdChung.DataSource).Columns[0].ColumnName))); ;
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet(sPS, lPar);
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

        #region --- Event
        private void grvChung_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (grvChung.DataSource == null || grvChung.RowCount <= 0)
                {
                    this.Close();
                    return;
                }
                if (grvChung.RowCount <= 0)
                {
                    this.Close();
                    return;
                }
                if (!bView)
                {

                    Com.Mod.sId = grvChung.GetFocusedRowCellValue(grvChung.Columns[0]).ToString();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }

                if (iPQ != 1) return;
                DataRow row = grvChung.GetDataRow(grvChung.FocusedRowHandle) as DataRow;
                XtraForm ctl;
                Type newType = Type.GetType("VS.CMMS.frmEdit" + this.Tag.ToString().Replace("mnu", ""), true, true);
                object o1 = Activator.CreateInstance(newType, 1, row, null);
                ctl = o1 as XtraForm;
                ctl.StartPosition = FormStartPosition.CenterParent;
                ctl.Tag = this.Tag;
                ctl.Size = new System.Drawing.Size(Com.Mod.Size2P3.Width, Com.Mod.Size2P3.Height);
                Com.Mod.sPS = this.Tag.ToString();

                if (ctl.ShowDialog() == DialogResult.OK)
                {
                    LoadData(-1);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString(), this.Text);
            }
            

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                XtraForm ctl;
                Type newType = Type.GetType("VS.CMMS.frmEdit" + this.Tag.ToString().Replace("mnu", ""), true, true);
                object o1 = Activator.CreateInstance(newType, 1 ,null, true);
                ctl = o1 as XtraForm;
                ctl.StartPosition = FormStartPosition.CenterParent;
                Com.Mod.sPS = this.Tag.ToString();
                ctl.Tag = this.Tag;
                ctl.Size = new System.Drawing.Size(Com.Mod.Size2P3.Width, Com.Mod.Size2P3.Height);

                if (ctl.ShowDialog() == DialogResult.OK)
                {
                    LoadData(-1);
                }

               
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString(), this.Text);
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvChung.RowCount == 0)
                {
                    XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgKhongCoDuLieuDeXoa"), this.Text);
                    return;
                }
                if (!KiemSuDung()) return;
                if (XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgBanCoChacXoa"), this.Text, MessageBoxButtons.YesNo) == DialogResult.No) return;
                #region Xoa

                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 2));
                lPar.Add(new SqlParameter("@sDMuc", this.Tag));
                lPar.Add(new SqlParameter("@iID", grvChung.GetFocusedRowCellValue(((DataTable)grdChung.DataSource).Columns[0].ColumnName)));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                //tra về
                Int32 bKiem = Convert.ToInt32(VsMain.MExecuteScalar(sPS, lPar));

                if (bKiem == 1)
                {
                    XtraMessageBox.Show(Com.Mod.OS.GetLanguage(this.Name, "msgDelDangSuDung"), this.Text);
                    Program.MBarXoaThanhCong();
                }
                LoadData(-1);
                #endregion
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgDelDangSuDung") + "\n" + ex.Message, this.Text);
                Program.MBarXoaKhongThanhCong();
            }
        }
        private void btnIN_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (this.Tag.ToString() == "mnuTUBanHang")
            //    {
            //        frmViewReport frm = new frmViewReport();
            //        frm.rpt = new rptEditTUBanHang();


            //        List<SqlParameter> lPar = new List<SqlParameter>
            //        {
            //             new SqlParameter("@sDMuc", "mnuTUBanHang"),
            //             new SqlParameter("@iLoai", 6),
            //             new SqlParameter("@NNgu", Com.Mod.iNNgu),
            //             new SqlParameter("@COTNUM1", string.IsNullOrEmpty(Convert.ToString(grvChung.GetFocusedRowCellValue(grvChung.Columns[0]))) ? 0 : Convert.ToInt64(grvChung.GetFocusedRowCellValue(grvChung.Columns[0]))),
            //        };
            //        DataSet ds = new DataSet();
            //        ds = VsMain.MGetDataSet("spDanhMuc", lPar);
            //        ds.Tables[0].TableName = "DATA";
            //        frm.AddDataSource(ds);
            //        frm.ShowDialog();
            //    }
            //    else
            //        VsMain.MXtraPrint(this.Name, grdChung, grvChung, this.Text.ToUpper(), null,false);
            //}
            ////catch (Exception ex) { XtraMessageBox.Show(ex.Message, this.Text); }
            ///var body = "<size=14>Size = 14<br>" +
            var body = "<div> <size=14>Size = 14<br>\" +\r\n             \"<b>Bold</b> <i>Italic</i> <u>Underline</u><br>\" +\r\n             \"<size=11>Size = 11<br>\" +\r\n             \"<color=255, 0, 0>Sample Text</color></size>\" +\r\n             \"<br><size=14><color=0, 255, 0><href=https://laptrinhvb.net>https://laptrinhvb.net</href></color></size></div>";
            XtraMessageBox.Show(body, "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information, DevExpress.Utils.DefaultBoolean.True);
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void grvChung_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "MAU_LCV" && Convert.ToString(this.Tag) == "mnuLoaiCV")
                {
                    e.Appearance.BackColor = ColorTranslator.FromHtml(Convert.ToString(e.CellValue));
                    e.Appearance.ForeColor = ColorTranslator.FromHtml(Convert.ToString(e.CellValue));
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString(), this.Text);
            }
        }
        #endregion

        private void cboID_DT_BH_EditValueChanged(object sender, EventArgs e)
        {
            if (Com.Mod.sLoad == "0Load") return;
            LoadDataPT();
        }

        private void optActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Com.Mod.sLoad == "0Load") return;
            LoadDataPT();
        }
    }
}
