using DevExpress.XtraDataLayout;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Filtering.Templates;
using DevExpress.XtraRichEdit.Import.Html;
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
using VS.ERP;
using static DevExpress.Xpo.DB.DataStoreLongrunnersWatch;

namespace VS.CMMS
{
    public partial class frmThoiGianDungMay : DevExpress.XtraEditors.XtraForm
    {
        IEnumerable<Control> allControls;
        int iPQ = 1;  // == 1  full; <> 1 la read only
        private Int64 iIDNM = -1;
        public frmThoiGianDungMay(int PQ)
        {
            iPQ = PQ;
            InitializeComponent();
            VsMain.MFieldRequest(lblMS_MAY);
            VsMain.MFieldRequest(lblNguyenNhan);
        }
        private void frmChung_Load(object sender, EventArgs e)
        {
            Com.Mod.sLoad = "0Load";
            datNgayBD.DateTime = DateTime.Now.AddHours(-1);
            datNgayKT.DateTime = datNgayBD.DateTime.AddHours(1);
            LoadcboCa();
            LoadcboMay();
            LoadcboLoaiNN();
            LoadPhieuBaoTri();
            LoadcboNhanVien();
            Com.Mod.sLoad = "";
            LoadcboNN(false);
            LoadDSNM();
            LoadNN();


        }
        public void LoadNN()
        {
            Com.Mod.OS.ThayDoiNN(this, dataLayoutControl1);
            Com.Mod.OS.MLoadNNXtraGrid(grvDSNM, this.Name);
            Com.Mod.OS.MSaveResertGrid(grvDSNM, this.Name);
        }

        private void LoadcboCa()
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
                sqlcom.Parameters.AddWithValue("NNgu", int.Parse(Com.Mod.iNNgu.ToString()));
                sqlcom.Parameters.AddWithValue("UName", Com.Mod.UName);
                sqlcom.Parameters.AddWithValue("@sDMuc", "CA");
                sqlcom.Parameters.AddWithValue("All", "0");
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.CommandText = "spGetComBo";
                var da = new SqlDataAdapter(sqlcom);
                dt = new DataTable();
                da.Fill(dt);
                Com.Mod.OS.MLoadLookUpEdit(cboCa, dt, "ID", "TEN", this.Name);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }
        private void LoadcboMay()
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
                sqlcom.Parameters.AddWithValue("NNgu", int.Parse(Com.Mod.iNNgu.ToString()));
                sqlcom.Parameters.AddWithValue("UName", Com.Mod.UName);
                sqlcom.Parameters.AddWithValue("@sDMuc", "MAY");
                sqlcom.Parameters.AddWithValue("All", "0");
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.CommandText = "spGetComBo";
                var da = new SqlDataAdapter(sqlcom);
                dt = new DataTable();
                da.Fill(dt);
                Com.Mod.OS.MLoadSearchLookUpEdit(cboMay, dt, "ID", "TEN_MAY", this.Name);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        private void LoadcboLoaiNN()
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
                sqlcom.Parameters.AddWithValue("NNgu", int.Parse(Com.Mod.iNNgu.ToString()));
                sqlcom.Parameters.AddWithValue("UName", Com.Mod.UName);
                sqlcom.Parameters.AddWithValue("@sDMuc", "LOAI_NN");
                sqlcom.Parameters.AddWithValue("All", "0");
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.CommandText = "spGetComBo";
                var da = new SqlDataAdapter(sqlcom);
                dt = new DataTable();
                da.Fill(dt);
                Com.Mod.OS.MLoadSearchLookUpEdit(cboLoaiNN, dt, "ID", "TEN_LOAI_NNDM", this.Name);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        private void LoadcboNN(bool all)
        {
            if (Com.Mod.sLoad == "0Load") return;
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
                sqlcom.Parameters.AddWithValue("NNgu", int.Parse(Com.Mod.iNNgu.ToString()));
                sqlcom.Parameters.AddWithValue("UName", Com.Mod.UName);
                sqlcom.Parameters.AddWithValue("iCot1", cboMay.EditValue);
                sqlcom.Parameters.AddWithValue("iCot2", cboLoaiNN.EditValue);
                sqlcom.Parameters.AddWithValue("@sDMuc", "NN_NM");
                sqlcom.Parameters.AddWithValue("All", all);
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.CommandText = "spGetComBo";
                var da = new SqlDataAdapter(sqlcom);
                dt = new DataTable();
                da.Fill(dt);
                Com.Mod.OS.MLoadSearchLookUpEdit(cboNN, dt, "ID", "TEN_NGUYEN_NHAN", this.Name);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }
        private void LoadcboNhanVien()
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
                sqlcom.Parameters.AddWithValue("NNgu", int.Parse(Com.Mod.iNNgu.ToString()));
                sqlcom.Parameters.AddWithValue("UName", Com.Mod.UName);
                sqlcom.Parameters.AddWithValue("@sDMuc", "NHAN_VIEN_GIAI_QUYET_NM");
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.CommandText = "spGetComBo";
                var da = new SqlDataAdapter(sqlcom);
                da.Fill(dt);
                Com.Mod.OS.MLoadComboBoxEdit(cboNguoiGiaiQuyet, dt);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        private void LoadPhieuBaoTri()
        {
            if (Com.Mod.sLoad == "0Load") return;
            if (iIDNM != -1) return;
            try
            {
                DataTable dt = new DataTable();
                string query = "SELECT DISTINCT MS_PBT FROM  dbo.PHIEU_BAO_TRI  WHERE  ID_MAY = '" + cboMay.EditValue + "' AND  NGAY_BD_KH >= '" + datNgayBD.DateTime.ToString("yyyy/MM/dd") + "' UNION SELECT '' AS MS_PHIEU_BAO_TRI  ";
                dt.Load(SqlHelper.ExecuteReader(Com.Mod.CNStr, CommandType.Text, query));
                Com.Mod.OS.MLoadSearchLookUpEdit(cboNN, dt, "ID", "MS_PHIEU_BAO_TRI", this.Name);
            }
            catch
            {
            }
        }

        private void cboMay_EditValueChanged(object sender, EventArgs e)
        {
            LoadcboNN(false);
        }

        private void cboLoaiNN_EditValueChanged(object sender, EventArgs e)
        {
            LoadcboNN(false);
        }

        private void datNgayBD_EditValueChanged(object sender, EventArgs e)
        {
            LoadPhieuBaoTri();
            if (iIDNM == -1) return;
            Tinh_THOI_GIAN_SUA();
        }

        private void Tinh_THOI_GIAN_SUA()
        {
            try
            {
                if (Com.Mod.sLoad == "0Load") return;
                DateTime TuNgay = datNgayBD.DateTime;
                DateTime DenNgay = datNgayKT.DateTime;
                TimeSpan THOI_GIAN_SUA = DenNgay - TuNgay;
                txtTGSua.EditValue = THOI_GIAN_SUA.TotalMinutes;
                txtTGNgung.EditValue = THOI_GIAN_SUA.TotalMinutes;
            }
            catch { }
        }

        private void datNgayKT_EditValueChanged(object sender, EventArgs e)
        {
            if (iIDNM == -1) return;
            Tinh_THOI_GIAN_SUA();
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            try
            {
                dxErrorProvider1.ClearErrors();
                if (string.IsNullOrEmpty(cboMay.Text) || cboMay.Equals(DBNull.Value))
                {
                    dxErrorProvider1.SetError(cboMay, lblMS_MAY.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgKhongDuocTrong"));
                    cboMay.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(cboNN.Text) || cboNN.Equals(DBNull.Value))
                {
                    dxErrorProvider1.SetError(cboNN, lblNguyenNhan.Text + " " + Com.Mod.OS.GetLanguage("frmChung", "msgKhongDuocTrong"));
                    cboMay.Focus();
                    return;
                }
                if (Convert.ToDecimal(txtTGSua.EditValue) > Convert.ToDecimal(txtTGNgung.EditValue))
                {
                    dxErrorProvider1.SetError(txtTGSua, Com.Mod.OS.GetLanguage("frmChung", "msgThoigiansuakhonglonhonthoigianngung"));
                    txtTGSua.Focus();
                    return;
                }
                if (datNgayBD.DateTime >= datNgayKT.DateTime)
                {
                    dxErrorProvider1.SetError(datNgayBD, Com.Mod.OS.GetLanguage("frmChung", "MsgTungayphainhohondenngay"));
                    dxErrorProvider1.SetError(datNgayKT, Com.Mod.OS.GetLanguage("frmChung", "MsgTungayphainhohondenngay"));
                    txtTGSua.Focus();
                    return;
                }
                bool bCN = false;
                if (iIDNM != -1)
                {
                    if (!CheckSaveData(datNgayBD.DateTime, datNgayKT.DateTime))
                    {
                        return;
                    }
                    if (XtraMessageBox.Show(Com.Mod.OS.GetLanguage(this.Name, "msgCapNhatTatCaNgungMayLienQuan"), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bCN = true;

                    }   
                    else
                    {
                        bCN = false;
                    }    
                }

                DataTable dt = new DataTable();
                dt = BocTach_TheoCa(datNgayBD.DateTime, datNgayKT.DateTime);
                Com.Mod.OS.MTableToData(Com.Mod.CNStr, "sBTTGDM" + Com.Mod.UName, dt, "");

                //kiểm 
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@sDMuc", "SAVE_NGUNG_MAY"));
                lPar.Add(new SqlParameter("@iID", iIDNM));
                lPar.Add(new SqlParameter("@ID_MAY", cboMay.EditValue));
                lPar.Add(new SqlParameter("@ID_NNDM", cboNN.EditValue));
                lPar.Add(new SqlParameter("@TU_TG", datNgayBD.DateTime));
                lPar.Add(new SqlParameter("@DEN_TG", datNgayKT.DateTime));
                lPar.Add(new SqlParameter("@TG_DUNG", txtTGNgung.EditValue));
                lPar.Add(new SqlParameter("@TG_SUA", txtTGSua.EditValue));
                lPar.Add(new SqlParameter("@NGUOI_GIAI_QUYET", cboNguoiGiaiQuyet.Text));
                lPar.Add(new SqlParameter("@HIEN_TUONG", txtHienTuong.EditValue));
                lPar.Add(new SqlParameter("@CACH_GIAI_QUYET", txtCachGiaiQuyet.EditValue));
                lPar.Add(new SqlParameter("@NGUYEN_NHAN_CU_THE", txtNguyenNhanCT.EditValue));
                lPar.Add(new SqlParameter("@bCot1", bCN));
                lPar.Add(new SqlParameter("@sBT", "sBTTGDM" + Com.Mod.UName));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                VsMain.MExecuteNonQuery("spThoiGianDungMay", lPar);
                Program.MBarCapNhapThanhCong();
                if (iIDNM == -1)
                {
                    BindingData();
                }
                {
                    LoadDSNM();
                }
            }
            catch
            {
                XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgGhiKhongThanhCong"));
                Program.MBarCapNhapKhongThanhCong();
            }
        }


        private bool CheckSaveData(DateTime datBD, DateTime datKT)
        {
            try
            {
                int n = 0;
                //kiểm tra đến ngày hợp lệ
                if (datKT < datBD)
                {
                    dxErrorProvider1.SetError(datNgayBD, Com.Mod.OS.GetLanguage(this.Name, "MsgTungayphainhohondenngay"));
                    datNgayBD.Focus();
                    dxErrorProvider1.SetError(datNgayKT, Com.Mod.OS.GetLanguage(this.Name, "MsgTungayphainhohondenngay"));
                    return false;
                }
                //kiểm tra lớn hơn 24 h
                if ((datKT - datBD).TotalHours > 24)
                {
                    dxErrorProvider1.SetError(datNgayBD, Com.Mod.OS.GetLanguage(this.Name, "MsgThoigianphainhohon24h"));
                    datNgayBD.Focus();
                    dxErrorProvider1.SetError(datNgayKT, Com.Mod.OS.GetLanguage(this.Name, "MsgThoigianphainhohon24h"));
                    return false;
                }
                //kiểm tra từ ngày đến ngày năm trong một ca hiện tại
                if (Convert.ToInt32(SqlHelper.ExecuteScalar(Com.Mod.CNStr, CommandType.Text, "SELECT dbo.fnGetCa('" + datBD.ToString("MM/dd/yyyy HH:mm:ss") + "')")) != Convert.ToInt32(SqlHelper.ExecuteScalar(Com.Mod.CNStr, CommandType.Text, "SELECT dbo.fnGetCa(DATEADD(SECOND,-1,'" + datKT.ToString("MM/dd/yyyy HH:mm:ss") + "'))")))
                {
                    dxErrorProvider1.SetError(datNgayBD, Com.Mod.OS.GetLanguage(this.Name, "MsgThoigiankhongnamtrongmotca"));
                    datNgayBD.Focus();
                    dxErrorProvider1.SetError(datNgayKT, Com.Mod.OS.GetLanguage(this.Name, "MsgThoigiankhongnamtrongmotca"));
                    return false;
                }

                //kiểm tra thời gian sửa chữa không lớn hơn thời gian sữa
                if (Convert.ToDecimal(txtTGSua.EditValue) > Convert.ToDecimal(txtTGNgung.EditValue))
                {
                    dxErrorProvider1.SetError(txtTGSua, Com.Mod.OS.GetLanguage(this.Name, "MsgThoigiansuachuakhonglonhonthoigiansua"));
                    return false;
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }



        private void LoadDSNM()
        {
            DataTable dt = new DataTable();
            List<SqlParameter> lPar = new List<SqlParameter>();
            lPar.Add(new SqlParameter("@sDMuc", "VIEW_NGUNG_MAY"));
            lPar.Add(new SqlParameter("@iID", iIDNM));
            lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
            lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
            dt = VsMain.MGetDatatable("spThoiGianDungMay", lPar);
            if (grdDSNM.DataSource == null)
            {
                Com.Mod.OS.MLoadXtraGrid(grdDSNM, grvDSNM, dt, false, true, true, true, true, this.Name);
                grvDSNM.Columns["ID_TGDM"].Visible = false;
                grvDSNM.Columns["ID_CA"].Visible = false;
                grvDSNM.Columns["ID_LOAI_NNDM"].Visible = false;
                grvDSNM.Columns["ID_NNDM"].Visible = false;
                grvDSNM.Columns["ID_MAY"].Visible = false;
                grvDSNM.Columns["TU_TG"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
                grvDSNM.Columns["DEN_TG"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
                grvDSNM.Columns["TU_TG"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                grvDSNM.Columns["DEN_TG"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                //DataTable datacbo = Com.Mod.OS.Datatablecombo("KHO;", "", 0);
                //grvKhoHang.Columns["ID_KHO_TEN"].OptionsColumn.AllowEdit = false;
                //Format
                //Com.Mod.OS.MFormatCol(grvKhoHang, "TON_TOI_THIEU", Com.Mod.iSoLeSL);
            }
            else
            {
                grdDSNM.DataSource = dt;
            }
        }

        private bool KiemTra_TiepTuc(Int64 ID)
        {
            bool Tiep_Tuc = false;
            try
            {
                Tiep_Tuc = Convert.ToBoolean(SqlHelper.ExecuteScalar(Com.Mod.CNStr, CommandType.Text, "SELECT TOP 1 1 FROM (SELECT 1 AS TIEP_TUC FROM dbo.THOI_GIAN_DUNG_MAY WHERE ID_TGDM = " + ID + " AND ISNULL(ID_TGDM_TRUOC, 0) <> 0 UNION SELECT 1 AS TIEP_TUC FROM dbo.THOI_GIAN_DUNG_MAY WHERE ID_TGDM_TRUOC = " + ID + ") A"));
            }
            catch { return false; }
            return Tiep_Tuc;
        }

        public class CapNhatCa
        {
            public int ID_CA { get; set; }
            public DateTime NGAY_BD { get; set; }
            public DateTime NGAY_KT { get; set; }
        }
        private DataTable BocTach_TheoCa(DateTime TN, DateTime DN)
        {
            DateTime TNgay = TN;
            DateTime DNgay = DN;
            List<DateTime> ListNgay = new List<DateTime>();
            //lấy tất cả các ngày có trong list
            ListNgay.Add(TN.AddDays(-1));
            do
            {
                ListNgay.Add(TN);
                TN = TN.AddDays(1);
            } while (TN.Date <= DN.Date);
            //List<CapNhatCa> listResulst = new List<CapNhatCa>();
            DataTable dt_Result = new DataTable();
            for (int i = 0; i < ListNgay.Count; i++)
            {
                //lấy các ca của ngày hôm đó
                DataTable dt = new DataTable();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@sDMuc", "GET_CA"));
                lPar.Add(new SqlParameter("@dCot1", ListNgay[i]));
                dt = VsMain.MGetDatatable("spThoiGianDungMay", lPar);

                if (dt_Result == null || dt_Result.Rows.Count == 0)
                    dt_Result = dt.Clone().Copy();
                if (ListNgay.Count() == 2 && dt.AsEnumerable().Where(x => TNgay >= Convert.ToDateTime(x["NGAY_BD"]) && DNgay <= Convert.ToDateTime(x["NGAY_KT"])).ToList().Count() == 1)
                {
                    //var item = listCA.Where(x => TNgay >= x.NGAY_BD && DNgay <= x.NGAY_KT).FirstOrDefault();
                    //item.NGAY_BD = TN;
                    //item.NGAY_KT= DN;
                    //listCA.Add(item);


                    DataRow r = dt_Result.NewRow();
                    r["NGAY_BD"] = TNgay;
                    r["NGAY_KT"] = DN;
                    r["ID_CA"] = dt.AsEnumerable().Where(x => TNgay >= Convert.ToDateTime(x["NGAY_BD"]) && DNgay <= Convert.ToDateTime(x["NGAY_KT"])).CopyToDataTable().Rows[0]["ID_CA"];
                    dt_Result.Rows.Add(r);
                    dt_Result.AcceptChanges();
                    return dt_Result;
                }

                //ngày bắc đầu nằm trong ca
                foreach (var row in dt.AsEnumerable().Where(x => x.Field<DateTime>("NGAY_BD") <= DNgay))
                {
                    //kiểm tra từ ngày có nằm trong item không
                    DataRow r = dt_Result.NewRow();

                    if (TNgay >= Convert.ToDateTime(row["NGAY_BD"]) && TNgay < Convert.ToDateTime(row["NGAY_KT"]))
                    {
                        //kiểm tra đến ngày có nhỏ hơn ngày kết thúc không
                        if (DN > Convert.ToDateTime(row["NGAY_KT"]))
                        {
                            // Đến ngày lớn hơn ngày kết thúc
                            r["NGAY_BD"] = TNgay;
                            r["NGAY_KT"] = row["NGAY_KT"];
                            r["ID_CA"] = row["ID_CA"];
                            dt_Result.Rows.Add(r);
                            dt_Result.AcceptChanges();
                            TNgay = Convert.ToDateTime(row["NGAY_KT"]);
                        }
                        else
                        {
                            // Đến ngày nhỏ hơn ngày kết thúc
                            r["NGAY_BD"] = row["NGAY_BD"];
                            r["NGAY_KT"] = DN;
                            r["ID_CA"] = row["ID_CA"];
                            dt_Result.Rows.Add(r);
                            dt_Result.AcceptChanges();
                            break;
                        }
                    }

                }
            }
            return dt_Result;
        }

        private void BindingData()
        {
            if (iIDNM == -1)
            {
                cboMay.EditValue = Convert.ToInt64(-99);
                cboCa.EditValue = -99;
                datNgayBD.DateTime = DateTime.Now.AddHours(-1);
                datNgayKT.DateTime = datNgayBD.DateTime.AddHours(1);
                cboLoaiNN.EditValue = Convert.ToInt64(-99);
                cboNN.EditValue = Convert.ToInt64(-99);
                txtTGSua.EditValue = 0;
                txtTGNgung.EditValue = 0;
                cboPBT.EditValue = -99;
                cboNguoiGiaiQuyet.EditValue = "";

                txtNguyenNhanCT.ResetText();
                txtHienTuong.ResetText();
                txtCachGiaiQuyet.ResetText();
                chkTiepTuc.Checked = false;

            }
            else
            {
                cboMay.EditValue = grvDSNM.GetFocusedRowCellValue("ID_MAY");
                cboCa.EditValue = grvDSNM.GetFocusedRowCellValue("ID_CA");
                datNgayBD.EditValue = grvDSNM.GetFocusedRowCellValue("TU_TG");
                datNgayKT.EditValue = grvDSNM.GetFocusedRowCellValue("DEN_TG");
                cboLoaiNN.EditValue = grvDSNM.GetFocusedRowCellValue("ID_LOAI_NNDM");
                cboNN.EditValue = grvDSNM.GetFocusedRowCellValue("ID_NNDM");
                txtTGSua.EditValue = grvDSNM.GetFocusedRowCellValue("TG_SUA");
                txtTGNgung.EditValue = grvDSNM.GetFocusedRowCellValue("TG_DUNG");
                cboPBT.EditValue = grvDSNM.GetFocusedRowCellValue("MS_PBT");
                cboNguoiGiaiQuyet.EditValue = grvDSNM.GetFocusedRowCellValue("NGUOI_GIAI_QUYET");

                txtNguyenNhanCT.EditValue = grvDSNM.GetFocusedRowCellValue("NGUYEN_NHAN_CU_THE");
                txtHienTuong.EditValue = grvDSNM.GetFocusedRowCellValue("HIEN_TUONG");
                txtCachGiaiQuyet.EditValue = grvDSNM.GetFocusedRowCellValue("CACH_GIAI_QUYET");
                chkTiepTuc.Checked = KiemTra_TiepTuc(Convert.ToInt64(grvDSNM.GetFocusedRowCellValue("ID_TGDM")));

            }
        }
        private void cboMay_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0) return;
            LoadView("");
        }
        private void LoadView(string sFind)
        {
            try
            {
                frmDSNgungMay ctl = new frmDSNgungMay();
                if (ctl.ShowDialog() == DialogResult.OK)
                {
                    iIDNM = Convert.ToInt64(Com.Mod.sId);
                    LoadDSNM();
                }
            }
            catch { }
        }

        private void LoadViewChon()
        {
            try
            {
                
                XtraForm ctl = new XtraForm();
                Type newType = Type.GetType("VS.CMMS.frmView", true, true);
                object o1 = Activator.CreateInstance(newType, Com.Mod.UserID, "", "spThoiGianDungMay");
                ctl = o1 as XtraForm;
                ctl.WindowState = FormWindowState.Maximized;
                Com.Mod.sPS = "CHON_NGUNG_MAY";
                ctl.Tag = "CHON_NGUNG_MAY";
                ctl.Text = Com.Mod.OS.GetLanguage("frmChooseTGianNMay", "frmChooseTGianNMay");
                ctl.Name = "frmChooseTGianNMay";
                if (ctl.ShowDialog() == DialogResult.OK)
                {
                    iIDNM = Convert.ToInt64(Com.Mod.sId);
                    LoadDSNM();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void grvDSNM_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            BindingData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgBanCoChacXoa"), this.Text, MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            try
            {
                string sStr = "DELETE FROM THOI_GIAN_DUNG_MAY WHERE ID_TGDM IN(SELECT * FROM  dbo.fnGetNguyenNhanNM(" + iIDNM + "))";
                VsMain.MExecuteNonQuery(sStr);
                VsMain.MExecuteNonQuery("DBCC CHECKIDENT (THOI_GIAN_DUNG_MAY,RESEED,0) DBCC CHECKIDENT (THOI_GIAN_DUNG_MAY,RESEED)");
                VsMain.MExecuteNonQuery(sStr);
                iIDNM = -1;
                LoadDSNM();
            }
            catch 
            {
                XtraMessageBox.Show(Com.Mod.OS.GetLanguage(this.Name, "msgXoaThatBai"));
                Program.MBarXoaKhongThanhCong();
            }

        
        }

        private void btnKhongGhi_Click(object sender, EventArgs e)
        {
            iIDNM = -1;
            BindingData();
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            LoadViewChon();
        }





        //private void cboNguoiGiaiQuyet_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (iIDNM == -1) return;
        //    try
        //    {
        //        grvDSNM.SetFocusedRowCellValue("NGUOI_GIAI_QUYET", cboNguoiGiaiQuyet.EditValue);
        //    }
        //    catch
        //    {
        //    }
        //}

        //private void txtNguyenNhanCT_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (iIDNM == -1) return;
        //    try
        //    {
        //        grvDSNM.SetFocusedRowCellValue("NGUYEN_NHAN_CU_THE", txtNguyenNhanCT.EditValue);
        //    }
        //    catch
        //    {
        //    }
        //}

        //private void txtHienTuong_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (iIDNM == -1) return;
        //    try
        //    {
        //        grvDSNM.SetFocusedRowCellValue("HIEN_TUONG", txtHienTuong.EditValue);
        //    }
        //    catch
        //    {
        //    }
        //}

        //private void txtCachGiaiQuyet_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (iIDNM == -1) return;
        //    try
        //    {
        //        grvDSNM.SetFocusedRowCellValue("CACH_GIAI_QUYET", txtCachGiaiQuyet.EditValue);
        //    }
        //    catch
        //    {
        //    }
        //}

        //private void cboPBT_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (iIDNM == -1) return;
        //    try
        //    {
        //        grvDSNM.SetFocusedRowCellValue("MS_PBT", cboPBT.EditValue);
        //    }
        //    catch
        //    {
        //    }
        //}
    }
}
