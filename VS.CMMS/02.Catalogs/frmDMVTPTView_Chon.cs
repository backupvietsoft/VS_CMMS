using DevExpress.Utils.Behaviors;
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
    public partial class frmDMVTPTView_Chon : DevExpress.XtraEditors.XtraForm
    {

        static int iPQ = -1;// == 1  full; <> 1 la read only
        private string sDMuc;
        private Int64 iID_PT;
        public DataTable dt_PhuTung;
        private DataTable dt_grdView;
        public frmDMVTPTView_Chon(int PQ, string DMuc, DataTable grdView_Datasource , Int64 ID_PT)
        {
            InitializeComponent();
            iPQ = PQ;
            iID_PT = ID_PT; 
            sDMuc = DMuc;
            dt_grdView = grdView_Datasource;
        }

        private void frmDMVTPTView_Chon_Load(object sender, EventArgs e)
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
                lPar.Add(new SqlParameter("@iLoai", 10));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@ID_PT", iID_PT)); 
                DataTable dt = new DataTable();
                dt = VsMain.MGetDatatable("spDMPT", lPar);

                if (dt.Rows.Count > 0)
                {
                    try
                    {
                        string sCheck = "";
                        string sCheck2 = "";
                        switch (sDMuc)
                        {
                            case "grvPTK":
                            {
                                sCheck = "ID_KHO";
                                sCheck2 = "ID_KVT";
                                try
                                {
                                 dt = dt.AsEnumerable()
                                .Where(row => !dt_grdView.AsEnumerable()
                                .Any(r => r.Field<Int64>(sCheck) == row.Field<Int64>(sCheck) && r.Field<Int64>(sCheck2) == row.Field<Int64>(sCheck2)))
                                .CopyToDataTable();
                                }
                                catch { dt.Clear(); }
                                break;
                            }
                            case "grvPTTD":
                            {
                                sCheck = "ID_PT";
                                try
                                {
                                    dt = dt.AsEnumerable()
                                    .Where(row => !dt_grdView.AsEnumerable()
                                    .Any(r => r.Field<Int64>(sCheck) == row.Field<Int64>(sCheck) || row.Field<Int64>(sCheck) == iID_PT))
                                    .CopyToDataTable();
                                }
                                catch { dt.Clear(); }
                                break;
                             }
                        }
                        if (grdChung.DataSource == null)
                        {
                            Com.Mod.OS.MLoadXtraGrid(grdChung, grvChung, dt, true, true, true, true, true, this.Name);
                            for (int i = 0; i < grvChung.Columns.Count; i++)
                            {
                                grvChung.Columns[i].OptionsColumn.AllowEdit = false;
                            }
                            grvChung.Columns["CHON"].OptionsColumn.AllowEdit = true;
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
                dt_PhuTung = new DataTable();
                dt_PhuTung = ((DataTable)grdChung.DataSource).Select("CHON = 1").CopyToDataTable().Copy();
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
