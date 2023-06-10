﻿using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VS.CMMS.Properties;

namespace VS.CMMS
{
    public partial class frmThongTinChung : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = -1; // 1 - FULL, 2 - READONLY
        private int ID = 1; // Mặc định là 1
        public frmThongTinChung(int PQ)
        {
            iPQ = PQ;
            InitializeComponent();


            if (iPQ != 1)
            {
                lciGhi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lciChonLogo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else
            {
                lciGhi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lciChonLogo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }


            //Tạm ẩn 
            lblBO_QUA_DH.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }


        #region Load
        private void frmThongTinChung_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();
                LoadNN();
                VsMain.MFieldRequest(lblFont);
            }
            catch { }
        }
        private void btnGhi_Click(object sender, EventArgs e)
        {
            try
            {
                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(Com.Mod.CNStr);
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spThongTinChung", conn);
                cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                cmd.Parameters.Add("@TEN_CTY", SqlDbType.NVarChar).Value = txtTEN_CTY.Text;
                cmd.Parameters.Add("@TEN_CTY_A", SqlDbType.NVarChar).Value = txtTEN_CTY_A.Text;
                cmd.Parameters.Add("@TEN_CTY_H", SqlDbType.NVarChar).Value = txtTEN_CTY_H.Text;
                cmd.Parameters.Add("@TEN_NGAN", SqlDbType.NVarChar).Value = txtTEN_NGAN.Text;
                cmd.Parameters.Add("@TEN_NGAN_A", SqlDbType.NVarChar).Value = txtTEN_NGAN_A.Text;
                cmd.Parameters.Add("@TEN_NGAN_H", SqlDbType.NVarChar).Value = txtTEN_NGAN_H.Text;
                cmd.Parameters.Add("@DIA_CHI", SqlDbType.NVarChar).Value = txtDIA_CHI.Text;
                cmd.Parameters.Add("@DIA_CHI_A", SqlDbType.NVarChar).Value = txtDIA_CHI_A.Text;
                cmd.Parameters.Add("@DIA_CHI_H", SqlDbType.NVarChar).Value = txtDIA_CHI_H.Text;
                cmd.Parameters.Add("@DIEN_THOAI", SqlDbType.NVarChar).Value = txtDIEN_THOAI.Text;
                cmd.Parameters.Add("@FAX", SqlDbType.NVarChar).Value = txtFAX.Text;
                cmd.Parameters.Add("@DUONG_DAN_TL", SqlDbType.NVarChar).Value = txtDUONG_DAN_TL.Text;
                cmd.Parameters.Add("@BO_QUA_DH", SqlDbType.Int).Value = txtBO_QUA_DH.EditValue;
                cmd.Parameters.Add("@SO_LE_SL", SqlDbType.Int).Value = txtSO_LE_SL.EditValue;
                cmd.Parameters.Add("@SO_LE_DG", SqlDbType.Int).Value = txtSO_LE_DG.EditValue;
                cmd.Parameters.Add("@SO_LE_DG_SC", SqlDbType.Int).Value = txtSO_LE_DG_SC.EditValue;
                cmd.Parameters.Add("@SO_LE_TT", SqlDbType.Int).Value = txtSO_LE_TT.EditValue;
                cmd.Parameters.Add("@SO_LE_TT_SC", SqlDbType.Int).Value = txtSO_LE_TT_SC.EditValue;
                cmd.Parameters.Add("@SO_LE_TG", SqlDbType.Int).Value = txtSO_LE_TG.EditValue;
                cmd.Parameters.Add("@SO_LE_DM", SqlDbType.Int).Value = txtSO_LE_DM.EditValue;
                cmd.Parameters.Add("@SO_LE_PT", SqlDbType.Int).Value = txtSO_LE_PT.EditValue;
                cmd.Parameters.Add("@SO_LE_VAT", SqlDbType.Int).Value = txtSO_LE_VAT.EditValue;
                cmd.Parameters.Add("@MD_VAT", SqlDbType.Float).Value = txtMD_VAT.EditValue;
                cmd.Parameters.Add("@LOGO", SqlDbType.Image).Value = Com.Mod.OS.SaveHinh(pteLogo.Image);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                if (conn.State == ConnectionState.Open)
                    conn.Close();

                Program.MBarCapNhapThanhCong();
                VsMain.LoadThongTinChung();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgGhiKhongThanhCong") + "\n" + ex.Message, this.Text);
                Program.MBarCapNhapKhongThanhCong();
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnChonLogo_Click(object sender, EventArgs e)
        {
            this.pteLogo.LoadImage();
        }
        #endregion

        #region Function
        private void LoadNN()
        {
            var typeToBeSelected = new List<Type>
                {typeof(DevExpress.XtraDataLayout.DataLayoutControl)};
            IEnumerable<Control> allCon;
            allCon = Com.Mod.OS.GetAllConTrol(this, typeToBeSelected);
            Com.Mod.OS.ThayDoiNN(this, allCon);

            gcLogo.Text = Com.Mod.OS.GetLanguage(this.Name, "gcLogo");
            gcSoLe.Text = Com.Mod.OS.GetLanguage(this.Name, "gcSoLe");
        }
        private void LoadData()
        {
            DataTable dt = new DataTable();

            System.Data.SqlClient.SqlConnection conn;
            conn = new System.Data.SqlClient.SqlConnection(Com.Mod.CNStr);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spThongTinChung", conn);
            cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            cmd.CommandType = CommandType.StoredProcedure;
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0].Copy();
            if (dt.Rows.Count == 0)
            {
                TextNull();
            }
            else
            {
                try
                {
                    ID = string.IsNullOrEmpty(dt.Rows[0]["ID"].ToString()) ? -1 : Convert.ToInt32(dt.Rows[0]["ID"]);
                    txtTEN_CTY.Text = string.IsNullOrEmpty(dt.Rows[0]["TEN_CTY"].ToString()) ? "" : dt.Rows[0]["TEN_CTY"].ToString();
                    txtTEN_CTY_A.Text = string.IsNullOrEmpty(dt.Rows[0]["TEN_CTY_A"].ToString()) ? "" : dt.Rows[0]["TEN_CTY_A"].ToString();
                    txtTEN_CTY_H.Text = string.IsNullOrEmpty(dt.Rows[0]["TEN_CTY_H"].ToString()) ? "" : dt.Rows[0]["TEN_CTY_H"].ToString();
                    txtTEN_NGAN.Text = string.IsNullOrEmpty(dt.Rows[0]["TEN_NGAN"].ToString()) ? "" : dt.Rows[0]["TEN_NGAN"].ToString();
                    txtTEN_NGAN_A.Text = string.IsNullOrEmpty(dt.Rows[0]["TEN_NGAN_A"].ToString()) ? "" : dt.Rows[0]["TEN_NGAN_A"].ToString();
                    txtTEN_NGAN_H.Text = string.IsNullOrEmpty(dt.Rows[0]["TEN_NGAN_H"].ToString()) ? "" : dt.Rows[0]["TEN_NGAN_H"].ToString();
                    txtDIA_CHI.Text = string.IsNullOrEmpty(dt.Rows[0]["DIA_CHI"].ToString()) ? "" : dt.Rows[0]["DIA_CHI"].ToString();
                    txtDIA_CHI_A.Text = string.IsNullOrEmpty(dt.Rows[0]["DIA_CHI_A"].ToString()) ? "" : dt.Rows[0]["DIA_CHI_A"].ToString();
                    txtDIA_CHI_H.Text = string.IsNullOrEmpty(dt.Rows[0]["DIA_CHI_H"].ToString()) ? "" : dt.Rows[0]["DIA_CHI_H"].ToString();
                    txtDIEN_THOAI.Text = string.IsNullOrEmpty(dt.Rows[0]["DIEN_THOAI"].ToString()) ? "" : dt.Rows[0]["DIEN_THOAI"].ToString();
                    txtFAX.Text = string.IsNullOrEmpty(dt.Rows[0]["FAX"].ToString()) ? "" : dt.Rows[0]["FAX"].ToString();
                    txtDUONG_DAN_TL.Text = string.IsNullOrEmpty(dt.Rows[0]["DUONG_DAN_TL"].ToString()) ? "" : dt.Rows[0]["DUONG_DAN_TL"].ToString();
                   

                    txtSO_LE_SL.EditValue = string.IsNullOrEmpty(dt.Rows[0]["SO_LE_SL"].ToString()) ? 2 : Convert.ToInt32(dt.Rows[0]["SO_LE_SL"]);
                    txtSO_LE_DG.EditValue = string.IsNullOrEmpty(dt.Rows[0]["SO_LE_DG"].ToString()) ? 2 : Convert.ToInt32(dt.Rows[0]["SO_LE_DG"]);
                    txtSO_LE_DG_SC.EditValue = string.IsNullOrEmpty(dt.Rows[0]["SO_LE_DG_SC"].ToString()) ? 4 : Convert.ToInt32(dt.Rows[0]["SO_LE_DG_SC"]);
                    txtSO_LE_TT.EditValue = string.IsNullOrEmpty(dt.Rows[0]["SO_LE_TT"].ToString()) ? 2 : Convert.ToInt32(dt.Rows[0]["SO_LE_TT"]);
                    txtSO_LE_TT_SC.EditValue = string.IsNullOrEmpty(dt.Rows[0]["SO_LE_TT_SC"].ToString()) ? 4 : Convert.ToInt32(dt.Rows[0]["SO_LE_TT_SC"]);
                    txtSO_LE_TG.EditValue = string.IsNullOrEmpty(dt.Rows[0]["SO_LE_TG"].ToString()) ? 4 : Convert.ToInt32(dt.Rows[0]["SO_LE_TG"]);
                    txtSO_LE_DM.EditValue = string.IsNullOrEmpty(dt.Rows[0]["SO_LE_DM"].ToString()) ? 3 : Convert.ToInt32(dt.Rows[0]["SO_LE_DM"]);
                    txtSO_LE_PT.EditValue = string.IsNullOrEmpty(dt.Rows[0]["SO_LE_PT"].ToString()) ? 2 : Convert.ToInt32(dt.Rows[0]["SO_LE_PT"]);
                    txtSO_LE_VAT.EditValue = string.IsNullOrEmpty(dt.Rows[0]["SO_LE_VAT"].ToString()) ? 2 : Convert.ToInt32(dt.Rows[0]["SO_LE_VAT"]);
                    txtMD_VAT.EditValue = string.IsNullOrEmpty(dt.Rows[0]["MD_VAT"].ToString()) ? 10 : Convert.ToInt32(dt.Rows[0]["MD_VAT"]);

                    txtBO_QUA_DH.EditValue = string.IsNullOrEmpty(dt.Rows[0]["BO_QUA_DH"].ToString()) ? 0 : Convert.ToInt32(dt.Rows[0]["BO_QUA_DH"]);


                    try
                    {
                        pteLogo.EditValue = Com.Mod.OS.LoadHinh((byte[])dt.Rows[0]["LOGO"]);
                    }
                    catch 
                    {
                        pteLogo.EditValue = null;
                    }
                }
                catch { TextNull(); }
            }
        }
        private void TextNull()
        {
            ID = -1;
            txtTEN_CTY.Text = "";
            txtTEN_CTY_A.Text = "";
            txtTEN_CTY_H.Text = "";
            txtTEN_NGAN.Text = "";
            txtTEN_NGAN_A.Text = "";
            txtTEN_NGAN_H.Text = "";
            txtDIA_CHI.Text = "";
            txtDIA_CHI_A.Text = "";
            txtDIA_CHI_H.Text = "";
            txtDIEN_THOAI.Text = "";
            txtFAX.Text = "";
            txtDUONG_DAN_TL.Text = "";
            
            txtSO_LE_SL.EditValue = 2;
            txtSO_LE_DG.EditValue = 2;
            txtSO_LE_DG_SC.EditValue = 4;
            txtSO_LE_TT.EditValue = 2;
            txtSO_LE_TT_SC.EditValue = 4;
            txtSO_LE_TG.EditValue = 4;
            txtSO_LE_DM.EditValue = 3;
            txtSO_LE_PT.EditValue = 2;
            txtSO_LE_VAT.EditValue = 2;
            txtMD_VAT.EditValue = 10;

            txtBO_QUA_DH.EditValue = 0;


            pteLogo.EditValue = null;
        }
        #endregion

        #region Event
        private void txtDUONG_DAN_TL_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "";
            try
            {
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (ofd.CheckFileExists)
                    {
                        txtDUONG_DAN_TL.Text = System.IO.Path.GetFullPath(ofd.FileName);
                    }
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            return;
        }
        private void pteLogo_DoubleClick(object sender, EventArgs e)
        {
            try { pteLogo.ShowImageEditorDialog(); }
            catch { }
        }
        private void btnChangeColor_Click(object sender, EventArgs e)
        {
            if (frmMain.CloseForm()) return;
            ColorDialog dlg = new ColorDialog();


            //dlg.AllowFullOpen = false;
            dlg.AnyColor = true;
            dlg.SolidColorOnly = false;


            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Settings.Default["ApplicationColorRed"] = dlg.Color.R.ToString();
                    Settings.Default["ApplicationColorGreen"] = dlg.Color.G.ToString();
                    Settings.Default["ApplicationColorBlue"] = dlg.Color.B.ToString();
                    Settings.Default.Save();
                }
                catch
                {
                    Settings.Default["ApplicationColorRed"] = "156";
                    Settings.Default["ApplicationColorGreen"] = "97";
                    Settings.Default["ApplicationColorBlue"] = "65";
                    Settings.Default.Save();
                }
                VsMain.MFieldRequest(lblFont);
            }
        }
        private void btnChangeFont_Click(object sender, EventArgs e)
        {
            if (frmMain.CloseForm()) return;
            FontDialog dlg = new FontDialog(); //Khởi tạo đối tượng FontDialog 
            try
            {
                dlg.Font = new Font(Settings.Default["ApplicationFontRequestName"].ToString(), float.Parse(Settings.Default["ApplicationFontRequestSize"].ToString()));
            }
            catch { dlg.Font = new System.Drawing.Font("Segoe UI", float.Parse("8.25")); }

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string fontName;
                float fontSize;
                string fontbold;
                fontName = dlg.Font.Name;
                fontSize = dlg.Font.Size;
                fontbold = dlg.Font.Bold.ToString();
                try
                {
                    Settings.Default["ApplicationFontRequestName"] = fontName;
                    Settings.Default["ApplicationFontRequestSize"] = fontSize.ToString();
                    Settings.Default["ApplicationFontRequestBold"] = fontbold;
                    Settings.Default["ApplicationFontRequestItalic"] = dlg.Font.Italic.ToString();
                }
                catch
                {
                    Settings.Default["ApplicationFontRequestName"] = "Segoe UI";
                    Settings.Default["ApplicationFontRequestSize"] = "9";
                    Settings.Default["ApplicationFontRequestBold"] = "false";
                    Settings.Default["ApplicationFontRequestItalic"] = "false";
                }
                Settings.Default.Save();
                VsMain.MFieldRequest(lblFont);
            }
        }
        private void btnDefault_Click(object sender, EventArgs e)
        {
            if (frmMain.CloseForm()) return;
            Settings.Default["ApplicationColorRed"] = "156";
            Settings.Default["ApplicationColorGreen"] = "97";
            Settings.Default["ApplicationColorBlue"] = "65";

            Settings.Default["ApplicationFontRequestName"] = "Segoe UI";
            Settings.Default["ApplicationFontRequestSize"] = "9";
            Settings.Default["ApplicationFontRequestBold"] = "false";
            Settings.Default["ApplicationFontRequestItalic"] = "false";

            Settings.Default.Save();
            VsMain.MFieldRequest(lblFont);
        }
        private void btnThongTinHopDong_Click(object sender, EventArgs e)
        {
            //////try
            //////{
            //////    frmThongTinHopDong frm = new frmThongTinHopDong(iPQ);
            //////    Com.Mod.OS.LocationSizeForm(this, frm);
            //////    frm.ShowDialog();
            //////}
            //////catch { }
        }
        #endregion

    }
}
