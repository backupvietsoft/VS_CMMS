using DevExpress.Utils.Gesture;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using VS.ERP;

namespace VS.CMMS
{
    public partial class frmThoiGianDungMay : DevExpress.XtraEditors.XtraForm
    {
        int iPQ = 1;  // == 1  full; <> 1 la read only
        private Int64 iIDNM = -1;
        private Int64? iIDT = null;
        DataTable dtNNgu = new DataTable();
        public frmThoiGianDungMay(int PQ,string sID ="-1",string sDM = "")
        {
            iPQ = PQ;
            InitializeComponent();
            FormatControl();
        }
        private void frmThoiGianDungMay_Load(object sender, EventArgs e)
        {
            try
            {
                Com.Mod.sLoad = "0Load";
                datNgayBD.DateTime = DateTime.Now.AddHours(-1);
                datNgayKT.DateTime = datNgayBD.DateTime.AddHours(1);
                Loadcombo();
                LoadPhieuBaoTri();
                Com.Mod.sLoad = "";
                LoadcboNN();
                LoadDSNM();
                LoadNN();
                addEvent();
            }
            catch (Exception ex)
            { Program.MBarThongTin(ex.Message.ToString(), true); }
        }

        private void Loadcombo()
        {
            List<SqlParameter> lPar = new List<SqlParameter>();
            lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
            lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
            lPar.Add(new SqlParameter("@iALL", 0));
            lPar.Add(new SqlParameter("@iLoai", 1));
            lPar.Add(new SqlParameter("@sDanhMuc", "CA;MAY;LOAI_NNDM;NHAN_VIEN;"));
            DataSet ds = new DataSet();
            ds = VsMain.MGetDataSet("spGetDataCatalogs", lPar);
            if (ds.Tables.Count == 0) return;
            Com.Mod.OS.MLoadLookUpEdit(cboCa, ds.Tables[0], "ID", "TEN", this.Name);
            Com.Mod.OS.MLoadSearchLookUpEdit(cboMay, ds.Tables[1], "ID", "TEN_MAY", this.Name);
            Com.Mod.OS.MLoadSearchLookUpEdit(cboLoaiNN, ds.Tables[2], "ID", "TEN_LOAI_NNDM", this.Name);
            Com.Mod.OS.MLoadComboBoxEdit(cboNguoiGiaiQuyet, ds.Tables[3]);
        }

        private void addEvent()
        {
            cboLoaiNN.EditValueChanged += cboLoaiNN_EditValueChanged;
            datNgayBD.EditValueChanged += datNgayBD_EditValueChanged;
            datNgayKT.EditValueChanged += datNgayKT_EditValueChanged;
            cboMay.ButtonClick += cboMay_ButtonClick;
            grvDSNM.PopupMenuShowing += grvDSNM_PopupMenuShowing;
            mnuThemTiepNgungMay.Click += mnuThemTiepNgungMayToolStripMenuItem_Click;
            mnuXoaNgungMayTruocDo.Click += mnuXoaNgungMayTruocDo_Click;
            grvDSNM.FocusedRowChanged += grvDSNM_FocusedRowChanged;
        }

        #region Event
     
        private void cboLoaiNN_EditValueChanged(object sender, EventArgs e)
        {
            LoadcboNN();
        }
        private void datNgayBD_EditValueChanged(object sender, EventArgs e)
        {
            LoadPhieuBaoTri();
            if (iIDNM == -1) return;
            TinhTHoiGianSua();
        }
        private void datNgayKT_EditValueChanged(object sender, EventArgs e)
        {
            if (iIDNM == -1) return;
            TinhTHoiGianSua();
        }
        private void cboMay_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0) return;
            LoadView("");
        }
        private void grvDSNM_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            try
            {
                if (e.HitInfo.InDataRow)
                {
                    if (!KiemTraIDCHA(Convert.ToInt64(grvDSNM.GetFocusedRowCellValue("ID_TGDM"))))
                    {
                        mnuThemTiepNgungMay.Visible = true;
                    }
                    else
                    {
                        mnuThemTiepNgungMay.Visible = false;
                    }

                    //kiem tra cos cha
                    if (Convert.ToInt32(VsMain.MExecuteScalar("SELECT COUNT(*) FROM dbo.THOI_GIAN_DUNG_MAY WHERE ID_TGDM = " + Convert.ToInt64(grvDSNM.GetFocusedRowCellValue("ID_TGDM")) + " AND ID_TGDM_TRUOC IS NULL")) == 0)
                    {
                        mnuXoaNgungMayTruocDo.Visible = true;
                    }
                    else
                    {
                        mnuXoaNgungMayTruocDo.Visible = false;
                    }


                    contextMenu.Show(Cursor.Position.X, Cursor.Position.Y);
                }
                else
                {
                    contextMenu.Hide();
                }
            }
            catch
            {
            }
        }
        private void mnuThemTiepNgungMayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iIDNM = -1;
            iIDT = Convert.ToInt64(grvDSNM.GetFocusedDataRow()["ID_TGDM"]);
            grdDSNM.Enabled = false;
            datNgayBD.DateTime = Convert.ToDateTime(grvDSNM.GetFocusedDataRow()["DEN_TG"].ToString());
            datNgayKT.DateTime = datNgayBD.DateTime.AddHours(1);
            chkTiepTuc.Checked = true;
            VisibleControl(true);

        }
        private void mnuXoaNgungMayTruocDo_Click(object sender, EventArgs e)
        {
            VsMain.MExecuteNonQuery("UPDATE dbo.THOI_GIAN_DUNG_MAY SET ID_TGDM_TRUOC = NULL WHERE ID_TGDM = " + grvDSNM.GetFocusedRowCellValue("ID_TGDM") + "");
            LoadDSNM();
        }
        private void grvDSNM_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            dxErrorProvider1.ClearErrors();
            BindingData();
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
                    dxErrorProvider1.SetError(txtTGSua, Com.Mod.OS.GetNN(dtNNgu, "msgThoigiansuakhonglonhonthoigianngung", this.Name));
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
                    if (XtraMessageBox.Show(Com.Mod.OS.GetNN(dtNNgu, "msgCapNhatTatCaNgungMayLienQuan", this.Name), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bCN = true;

                    }
                    else
                    {
                        bCN = false;
                    }
                }
                //kiểm tra khoản thời gian đã tồn tại
                DataTable tbTG = new DataTable();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@sDMuc", "CHECK_OVERLOAD"));
                if (grvDSNM.RowCount > 0)
                {
                    lPar.Add(new SqlParameter("@iID", iIDT != null ? -1 : grvDSNM.GetFocusedRowCellValue("ID_TGDM")));
                }
                else
                {
                    lPar.Add(new SqlParameter("@iID", iIDNM));
                }
                lPar.Add(new SqlParameter("@TU_TG", datNgayBD.DateTime));
                lPar.Add(new SqlParameter("@DEN_TG", datNgayKT.DateTime));
                lPar.Add(new SqlParameter("@ID_MAY", cboMay.EditValue));
                tbTG = VsMain.MGetDatatable("spThoiGianDungChayMay", lPar);
                for (int i = 0; i < tbTG.Rows.Count - 1; i++)
                {
                    if (Convert.ToDateTime(tbTG.Rows[i + 1]["TU_GIO"]) < Convert.ToDateTime(tbTG.Rows[i]["DEN_GIO"]))
                    {
                        XtraMessageBox.Show(Com.Mod.OS.GetNN(dtNNgu, "msgThoiGianBiTrung", this.Name), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dxErrorProvider1.SetError(datNgayBD, Com.Mod.OS.GetNN(dtNNgu, "msgThoiGianBiTrung", this.Name));
                        return;
                    }
                }

                DataTable dt = new DataTable();
                dt = BocTachTheoCa(datNgayBD.DateTime, datNgayKT.DateTime);
                Com.Mod.OS.MTableToData(Com.Mod.CNStr, "sBTTGDM" + Com.Mod.UName, dt, "");

                //kiểm 
                lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@sDMuc", "SAVE_NGUNG_MAY"));
                lPar.Add(new SqlParameter("@iID", iIDNM));
                lPar.Add(new SqlParameter("@ID_TGDM_TRUOC", iIDT));
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
                VsMain.MExecuteNonQuery("spThoiGianDungChayMay", lPar);
                Program.MBarCapNhapThanhCong();
                if (iIDNM == -1 && iIDT == null)
                {
                    BindingData();
                    VisibleControl(false);
                }
                else
                {
                    if (iIDNM == -1)
                    {
                        iIDNM = Convert.ToInt64(VsMain.MExecuteScalar("SELECT TOP 1 ID_TGDM FROM dbo.THOI_GIAN_DUNG_MAY WHERE ID_TGDM IN (SELECT * FROM dbo.fnGetNguyenNhanNM(" + iIDT + ")) AND ID_TGDM_TRUOC IS NULL"));
                    }
                    LoadDSNM();
                    iIDT = null;
                    VisibleControl(true);
                }
            }
            catch
            {

                XtraMessageBox.Show(Com.Mod.OS.GetNN(dtNNgu, "msgGhiKhongThanhCong", this.Name), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Program.MBarCapNhapKhongThanhCong();
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (grvDSNM.RowCount == 0)
            {
                XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgKhongCoDuLieuDeXoa"), btnXoa.Text);
                return;
            }
            if (XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgBanCoChacXoa"), this.Text, MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            try
            {
                string sStr = "DELETE FROM THOI_GIAN_DUNG_MAY WHERE ID_TGDM IN(SELECT * FROM  dbo.fnGetNguyenNhanNM(" + iIDNM + ")) DBCC CHECKIDENT (THOI_GIAN_DUNG_MAY,RESEED,0) DBCC CHECKIDENT (THOI_GIAN_DUNG_MAY,RESEED)";
                VsMain.MExecuteNonQuery(sStr);
                iIDNM = -1;
                LoadDSNM();
                btnKhongGhi_Click(null, null);
            }
            catch
            {
                XtraMessageBox.Show(Com.Mod.OS.GetNN(dtNNgu, "msgXoaThatBai", this.Name), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Program.MBarXoaKhongThanhCong();
            }
        }
        private void btnKhongGhi_Click(object sender, EventArgs e)
        {
            iIDNM = -1;
            iIDT = null;
            BindingData();
            VisibleControl(false);
            LoadDSNM();
        }
        private void btnChon_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvDSNM.RowCount == 0)
                {
                    XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgBanChuaChonDuLieu"), btnXoa.Text);
                    return;
                }
                frmThoiGianDungMayView frm = new frmThoiGianDungMayView(2, iIDNM, Convert.ToInt64(cboMay.EditValue));
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    List<SqlParameter> lPar = new List<SqlParameter>();
                    lPar.Add(new SqlParameter("@sDMuc", "UPDATE_TGDM_TRUOC"));
                    lPar.Add(new SqlParameter("@iID", iIDNM));
                    lPar.Add(new SqlParameter("@ID_TGDM_TRUOC", frm.iID));
                    lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                    lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                    VsMain.MGetDatatable("spThoiGianDungChayMay", lPar);
                    Program.MBarCapNhapThanhCong();
                    LoadDSNM();
                }
            }
            catch
            {
                XtraMessageBox.Show(Com.Mod.OS.GetNN(dtNNgu, "msgGopthongGianNgungThatBai", this.Name), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Program.MBarCapNhapKhongThanhCong();
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Function
        private void FormatControl()
        {
            if (iPQ != 1)
            {
                layXoa.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layGhi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layKhong.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layChon.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                grvDSNM.OptionsBehavior.Editable = false;
                //grvView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            }
            else
            {
                layXoa.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layGhi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layKhong.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layChon.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                grvDSNM.OptionsBehavior.Editable = true;
                //grvView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            }
            VsMain.MFieldRequest(lblMS_MAY);
            VsMain.MFieldRequest(lblNguyenNhan);
            //Com.Mod.OS.MFormatDateEdit(datNGAY_KIEM, "dd/MM/yyyy");
            Com.Mod.OS.MFormatDateEdit(datNgayBD, "g");
            Com.Mod.OS.MFormatDateEdit(datNgayKT, "g");

        }

        private void VisibleControl(bool visible)
        {
            cboMay.Properties.ReadOnly = visible;
            txtTGSua.Properties.ReadOnly = !visible;

            if (iPQ != 1) return;
            if (iIDT != null)
            {
                layXoa.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layChon.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                txtTGSua.Properties.ReadOnly = true;
            }
            else
            {
                layXoa.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layChon.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                grdDSNM.Enabled = true;

            }
        }

        public void LoadNN()
        {
            //Com.Mod.OS.ThayDoiNN(this, dataLayoutControl1);
            //Com.Mod.OS.MLoadNNXtraGrid(grvDSNM, this.Name);
            //Com.Mod.OS.MSaveResertGrid(grvDSNM, this.Name);
            try
            {
                dtNNgu.Load(SqlHelper.ExecuteReader(Com.Mod.CNStr, CommandType.Text, "SELECT KEYWORD , CASE " + Com.Mod.iNNgu + " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'" + this.Name + "' "));
                Com.Mod.OS.MLoadNN(dtNNgu, this, dataLayoutControl1);
                Com.Mod.OS.MLoadNNGrid(dtNNgu, grvDSNM, this.Name, true);
                foreach (ToolStripMenuItem item in contextMenu.Items)
                {
                    item.Text = Com.Mod.OS.GetNN(dtNNgu, item.Name, this.Name);
                }

            }
            catch { }

        }
        private void LoadcboNN()
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
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@NNgu", Com.Mod.iNNgu));
                lPar.Add(new SqlParameter("@UName", Com.Mod.UName));
                lPar.Add(new SqlParameter("@iID1", cboMay.EditValue));
                lPar.Add(new SqlParameter("@iID2", cboLoaiNN.EditValue));
                lPar.Add(new SqlParameter("@sDanhMuc", "NGUYEN_NHAN_DD;"));
                lPar.Add(new SqlParameter("iALL", 0));
                dt = VsMain.MGetDatatable("spGetDataCatalogs", lPar);
                Com.Mod.OS.MLoadSearchLookUpEdit(cboNN, dt, "ID", "TEN_NGUYEN_NHAN", this.Name);
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
                Com.Mod.OS.MLoadSearchLookUpEdit(cboPBT, dt, "ID", "MS_PHIEU_BAO_TRI", this.Name);
            }
            catch
            {
            }
        }

        private void TinhTHoiGianSua()
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

        private bool CheckSaveData(DateTime datBD, DateTime datKT)
        {
            try
            {
                int n = 0;
                //kiểm tra đến ngày hợp lệ
                if (datKT < datBD)
                {
                    dxErrorProvider1.SetError(datNgayBD, Com.Mod.OS.GetLanguage("frmChung", "MsgTungayphainhohondenngay"));
                    datNgayBD.Focus();
                    dxErrorProvider1.SetError(datNgayKT, Com.Mod.OS.GetLanguage("frmChung", "MsgTungayphainhohondenngay"));
                    return false;
                }
                //kiểm tra lớn hơn 24 h
                if ((datKT - datBD).TotalHours > 24)
                {
                    dxErrorProvider1.SetError(datNgayBD, Com.Mod.OS.GetNN(dtNNgu, "MsgThoigianphainhohon24h", this.Name));
                    datNgayBD.Focus();
                    dxErrorProvider1.SetError(datNgayKT, Com.Mod.OS.GetNN(dtNNgu, "MsgThoigianphainhohon24h", this.Name));
                    return false;
                }
                //kiểm tra từ ngày đến ngày năm trong một ca hiện tại
                if (Convert.ToInt32(SqlHelper.ExecuteScalar(Com.Mod.CNStr, CommandType.Text, "SELECT dbo.fnGetCa('" + datBD.ToString("MM/dd/yyyy HH:mm:ss") + "')")) != Convert.ToInt32(SqlHelper.ExecuteScalar(Com.Mod.CNStr, CommandType.Text, "SELECT dbo.fnGetCa(DATEADD(SECOND,-1,'" + datKT.ToString("MM/dd/yyyy HH:mm:ss") + "'))")))
                {

                    dxErrorProvider1.SetError(datNgayBD, Com.Mod.OS.GetNN(dtNNgu, "MsgThoigiankhongnamtrongmotca", this.Name));
                    datNgayBD.Focus();
                    dxErrorProvider1.SetError(datNgayKT, Com.Mod.OS.GetNN(dtNNgu, "MsgThoigiankhongnamtrongmotca", this.Name));
                    return false;
                }

                //kiểm tra thời gian sửa chữa không lớn hơn thời gian sữa
                if (Convert.ToDecimal(txtTGSua.EditValue) > Convert.ToDecimal(txtTGNgung.EditValue))
                {
                    dxErrorProvider1.SetError(txtTGSua, Com.Mod.OS.GetNN(dtNNgu, "MsgThoigiansuachuakhonglonhonthoigiansua", this.Name));
                    return false;
                }
                return true;
            }
            catch (Exception ex)
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
            dt = VsMain.MGetDatatable("spThoiGianDungChayMay", lPar);
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

        private bool KiemTraTiepTuc(Int64 ID)
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
        private DataTable BocTachTheoCa(DateTime TN, DateTime DN)
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
                dt = VsMain.MGetDatatable("spThoiGianDungChayMay", lPar);

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
                chkTiepTuc.Checked = KiemTraTiepTuc(Convert.ToInt64(grvDSNM.GetFocusedRowCellValue("ID_TGDM")));

            }
        }
        private void LoadView(string sFind)
        {
            try
            {
                frmThoiGianDungMayView ctl = new frmThoiGianDungMayView();
                Com.Mod.OS.LocationSizeForm(this, ctl);
                if (ctl.ShowDialog() == DialogResult.OK)
                {
                    iIDNM = Convert.ToInt64(Com.Mod.sId);
                    iIDT = null;
                    LoadDSNM();
                    VisibleControl(true);

                }
            }
            catch { }
        }

        private bool KiemTraIDCHA(Int64 ID)
        {
            bool Tiep_Tuc = false;
            try
            {
                Tiep_Tuc = Convert.ToBoolean(SqlHelper.ExecuteScalar(Com.Mod.CNStr, CommandType.Text, "SELECT 1 AS TIEP_TUC FROM dbo.THOI_GIAN_DUNG_MAY WHERE ID_TGDM_TRUOC = " + ID + ""));
            }
            catch { return false; }
            return Tiep_Tuc;
        }

        #endregion
    }
}
