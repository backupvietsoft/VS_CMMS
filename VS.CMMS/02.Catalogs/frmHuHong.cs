using Com;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Card;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraRichEdit.Layout;
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
using static DevExpress.XtraPrinting.Native.ExportOptionsPropertiesNames;

namespace VS.CMMS
{
    public partial class frmHuHong : DevExpress.XtraEditors.XtraForm
    {
        public frmHuHong(int PQ, string Find, string SP)
        {
            InitializeComponent();
            rdgHuHong.SelectedIndex = 0;

            try
            {
                this.grdChung.ViewRegistered += new DevExpress.XtraGrid.ViewOperationEventHandler(this.grdChung_ViewRegistered);
                this.grvChung.DoubleClick += new System.EventHandler(this.grvChung_DoubleClick);
            }catch{ }

        }

        private void frmHuHong_Load(object sender, EventArgs e)
        {
            LoadNN();
            
        }

        #region Function
        private void LoadData()
        {
            try
            {
                if (Com.Mod.sLoad == "0Load") return;
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 0));
                lPar.Add(new SqlParameter("@sDMuc", "frmHuHong"));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet("spHuHong", lPar);     

                DataColumn keyLever1 = ds.Tables[0].Columns["ID_HH_BP"];
                DataColumn frKeyLever1 = ds.Tables[1].Columns["ID_HH_BP"];
                try
                {
                    ds.Relations.Add(Com.Mod.OS.GetLanguage(this.Name, "grvDanhMucCacHuHong"), keyLever1, frKeyLever1);
                }
                catch {  }
                DataColumn[] keyLever2 = new DataColumn[2];
                DataColumn[] frKeyLever2 = new DataColumn[2];
                keyLever2[0] = ds.Tables[1].Columns["ID_HH_BP"];
                keyLever2[1] = ds.Tables[1].Columns["ID_HH_HH"];

                frKeyLever2[0] = ds.Tables[2].Columns["ID_HH_BP"];
                frKeyLever2[1] = ds.Tables[2].Columns["ID_HH_HH"];
                try
                {
                    ds.Relations.Add(Com.Mod.OS.GetLanguage(this.Name, "grvNguyenNhanHuHong"), keyLever2, frKeyLever2);
                }
                catch { }
                DataColumn[] keyLever3 = new DataColumn[3];
                keyLever3[0] = ds.Tables[2].Columns["ID_HH_NN"];
                keyLever3[1] = ds.Tables[2].Columns["ID_HH_BP"];
                keyLever3[2] = ds.Tables[2].Columns["ID_HH_HH"];

                DataColumn[] frKeyLever3 = new DataColumn[3];
                frKeyLever3[0] = ds.Tables[3].Columns["ID_HH_NN"];
                frKeyLever3[1] = ds.Tables[3].Columns["ID_HH_BP"];
                frKeyLever3[2] = ds.Tables[3].Columns["ID_HH_HH"];
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
                    Com.Mod.OS.MSaveResertGrid(grvChung,this.Name, grvChung.Name.ToString() + dtTmp.Rows[0]["GRV_LEVEL"].ToString());
                }catch { Com.Mod.OS.MSaveResertGrid(grvChung, grvChung.Name.ToString() + "1"); }
            }
            catch
            {}
        }
        private void LoadDataHH()
        {
            try
            {
                if (Com.Mod.sLoad == "0Load") return;
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 1));
                lPar.Add(new SqlParameter("@sDMuc", "frmHuHong"));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet("spHuHong", lPar);

                DataColumn keyLever1 = ds.Tables[0].Columns["ID_HH_HH"];
                DataColumn frKeyLever1 = ds.Tables[1].Columns["ID_HH_HH"];
                try
                {
                    ds.Relations.Add(Com.Mod.OS.GetLanguage(this.Name, "grvNguyenNhanHuHong"), keyLever1, frKeyLever1);
                }
                catch { }

                DataColumn[] keyLever2 = new DataColumn[2];
                DataColumn[] frKeyLever2 = new DataColumn[2];
                keyLever2[0] = ds.Tables[1].Columns["ID_HH_NN"];
                keyLever2[1] = ds.Tables[1].Columns["ID_HH_HH"];

                frKeyLever2[0] = ds.Tables[2].Columns["ID_HH_NN"];
                frKeyLever2[1] = ds.Tables[2].Columns["ID_HH_HH"];

                try
                {
                    ds.Relations.Add(Com.Mod.OS.GetLanguage(this.Name, "grvPhuongPhapKhacPhuc"), keyLever2, frKeyLever2);
                }
                catch { }

                DataTable dtTmp = new DataTable();

                dtTmp = ds.Tables[0];

                Com.Mod.OS.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, true, true, true, this.Name);
                try
                {
                    Com.Mod.OS.MSaveResertGrid(grvChung, this.Name, grvChung.Name.ToString() + dtTmp.Rows[0]["GRV_LEVEL"].ToString());
                }
                catch { Com.Mod.OS.MSaveResertGrid(grvChung, grvChung.Name.ToString() + "2"); }
            }
            catch { }
        }
        private void LoadNN()
        {
            try
            {
                Com.Mod.OS.ThayDoiNN(this, dataLayoutControl1);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        private void LoadDataNN()
        {
            try
            {
                if (Com.Mod.sLoad == "0Load") return;
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 2));
                lPar.Add(new SqlParameter("@sDMuc", "frmHuHong"));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet("spHuHong", lPar);

                DataColumn keyLever1 = ds.Tables[0].Columns["ID_HH_NN"];
                DataColumn frKeyLever1 = ds.Tables[1].Columns["ID_HH_NN"];
                try
                {
                    ds.Relations.Add(Com.Mod.OS.GetLanguage(this.Name, "grvNguyenNhanHuHong"), keyLever1, frKeyLever1);
                }
                catch { }

                DataTable dtTmp = new DataTable();

                dtTmp = ds.Tables[0];

                Com.Mod.OS.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, true, true, true, this.Name);
                try
                {
                    Com.Mod.OS.MSaveResertGrid(grvChung, this.Name, grvChung.Name.ToString() + dtTmp.Rows[0]["GRV_LEVEL"].ToString());
                }
                catch { Com.Mod.OS.MSaveResertGrid(grvChung, this.Name, grvChung.Name.ToString() + "3"); }
            }
            catch { }
        }
        #endregion

        #region Event
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
                }
                catch { Com.Mod.OS.MSaveResertGrid(grv, this.Name, grvChung.Name.ToString() + "3"); }

                grv.DoubleClick += new System.EventHandler(this.grvChung_DoubleClick);



            }
            catch { }
        }
        private void rdgHuHong_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (rdgHuHong.SelectedIndex)
            {
                case 0:
                    {
                        LoadData();
                        break;
                    }
                case 1:
                    {
                        LoadDataHH();
                        break;
                    }
                case 2:
                    {
                        LoadDataNN();
                        break;
                    }
                    
            }


        }
        string sDMuc = "";
        private void grvChung_DoubleClick(object sender, EventArgs e)  
        {
            try
            {
                GridView grv = sender as GridView;
                grv.GetFocusedDataRow();
                Int64 iID;
             
                switch (Convert.ToUInt32(grv.GetRowCellValue(0, "GRV_LEVEL")))
                {
                    case 1:
                        try
                        {
                            if (grv.GetFocusedRowCellValue("ID_HH_BP").ToString() == "-1") return;
                        }
                        catch { }
                        sDMuc = "frmEditBoPhanHH";
                        iID = string.IsNullOrEmpty(grv.GetFocusedRowCellValue("ID_HH_BP").ToString()) ? 0 : Convert.ToInt64(grv.GetFocusedRowCellValue("ID_HH_BP"));
                        break;
                    case 2:
                        try
                        {
                            if (grv.GetFocusedRowCellValue("ID_HH_BP").ToString() == "-1" && grv.GetFocusedRowCellValue("ID_HH_HH").ToString() == "-1") return;
                        }
                        catch { }
                        sDMuc = "frmEditHuHongHH";
                        iID = string.IsNullOrEmpty(grv.GetFocusedRowCellValue("ID_HH_HH").ToString()) ? 0 : Convert.ToInt64(grv.GetFocusedRowCellValue("ID_HH_HH"));
                        break;
                    case 3:
                        try
                        {
                            if (grv.GetFocusedRowCellValue("ID_HH_BP").ToString() == "-1" && grv.GetFocusedRowCellValue("ID_HH_HH").ToString() == "-1" && grv.GetFocusedRowCellValue("ID_HH_NN").ToString() == "-1") return;
                        }
                        catch { }
                        sDMuc = "frmEditNguyenNhanHH";
                        iID = string.IsNullOrEmpty(grv.GetFocusedRowCellValue("ID_HH_NN").ToString()) ? 0 : Convert.ToInt64(grv.GetFocusedRowCellValue("ID_HH_NN"));
                        break;
                    default: break;
                }
                if (sDMuc == "") return;
                DataRow row = grv.GetDataRow(grv.FocusedRowHandle) as DataRow;
                frmEditHuHong frm = new frmEditHuHong(row, sDMuc);
                Com.Mod.OS.LocationSizeForm(this, frm);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    switch (rdgHuHong.SelectedIndex)
                    {
                        case 0:
                            {
                                LoadData();
                                break;
                            }
                        case 1:
                            {
                                LoadDataHH();
                                break;
                            }
                        case 2:
                            {
                                LoadDataNN();
                                break;
                            }
                    }
                    Program.MBarCapNhapThanhCong();
                }
            }
            catch { }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            switch (rdgHuHong.SelectedIndex)
            {
                case 0:
                    {
                        sDMuc =  "frmEditBoPhanHH";
                        break;
                    }
                case 1:
                    {
                        sDMuc = "frmEditHuHongHH";
                        break;
                    }
                case 2:
                    {
                        sDMuc = "frmEditNguyenNhanHH";
                        break;
                    }
            }
            frmEditHuHong frm = new frmEditHuHong(null, sDMuc);
            Com.Mod.OS.LocationSizeForm(this, frm);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                switch (rdgHuHong.SelectedIndex)
                {
                    case 0 :
                        {   
                            LoadData();
                            break;
                        }
                    case 1 : 
                        {
                            LoadDataHH();
                            break;
                        }
                    case 2:
                        {
                            LoadDataNN();
                            break;
                        }
                }
                Program.MBarCapNhapThanhCong();
            }
        }
        #endregion
    }
}
