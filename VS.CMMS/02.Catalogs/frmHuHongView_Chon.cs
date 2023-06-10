using DevExpress.XtraEditors;
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
using static DevExpress.Utils.Drawing.Helpers.NativeMethods;

namespace VS.CMMS
{
    public partial class frmHuHongView_Chon : DevExpress.XtraEditors.XtraForm
    {

        static int iPQ = -1;// == 1  full; <> 1 la read only
        private string sDMuc;
        private Int64 iID;
        public DataTable dt_HuHong;
        private DataTable dt_grdView;
        public frmHuHongView_Chon(int PQ, string DMuc, DataTable grdView_Datasource)
        {
            InitializeComponent();
            iPQ = PQ;
            sDMuc = DMuc;
            dt_grdView = grdView_Datasource;
        }

        private void frmHuHongView_Chon_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadNN();
        }

        #region Funtion
        private void LoadData()
        {
            try
            {
                if (Com.Mod.sLoad == "0Load") return;
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@sDMuc", sDMuc));
                lPar.Add(new SqlParameter("@iLoai", 11));
                DataSet ds = new DataSet();
                ds = VsMain.MGetDataSet("spHuHong", lPar);
                DataTable dt = new DataTable();
                dt = ds.Tables[0].Copy();

                if (dt.Rows.Count > 0)
                {
                    try
                    {
                        string sCheck = "";
                        switch(sDMuc)
                        {
                            case "frmEditBoPhanHH":
                            {
                                    sCheck = "ID_HH_HH"; 
                                    break;
                            }
                            case "frmEditHuHongHH":
                            {
                                    sCheck = "ID_HH_NN";
                                    break;
                                }
                        }

                        try
                        {
                            dt = dt.AsEnumerable()
                                      .Where(row => !dt_grdView.AsEnumerable()
                                                            .Select(r => r.Field<Int64>(sCheck))
                                                            .Any(x => x == row.Field<Int64>(sCheck))
                                                            ).CopyToDataTable();
                        }
                        catch { dt.Clear(); }
                        
                        if (grdChung.DataSource == null)
                        {
                            Com.Mod.OS.MLoadXtraGrid(grdChung, grvChung, dt, true, true, true, true, true, this.Name);
                        }
                    }
                    catch {
                       
                    }
                }
            }
            catch(Exception ex) { }
        }
        private void LoadNN()
        {
            try
            {
                Com.Mod.OS.ThayDoiNN(this, dataLayoutControl1);
                this.Name = sDMuc + "_Chon";
                Com.Mod.OS.MLoadNNXtraGrid(grvChung, this.Name, true);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
            }
        }
        #endregion

        #region Event
        private void btnKhongGhi_Click(object sender, EventArgs e)
        {
            try
            {
                dt_HuHong = new DataTable();
                dt_HuHong = ((DataTable)grdChung.DataSource).Select("CHON = 1").CopyToDataTable().Copy();
                this.DialogResult = DialogResult.OK;
                this.Close();
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
        #endregion
    }
}
