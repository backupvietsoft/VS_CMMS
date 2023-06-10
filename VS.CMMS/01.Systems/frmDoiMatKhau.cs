using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Docking2010;
using Microsoft.ApplicationBlocks.Data;
namespace VS.CMMS
{
    public partial class frmDoiMatKhau : DevExpress.XtraEditors.XtraForm
    {
        static int iChangeForOther = 0; // 0 la tu doi mat khau, 1 doi mat khau cho nguoi khac
        public frmDoiMatKhau(string sUser, int ChangeForOther)
        {
            InitializeComponent();
            iChangeForOther = ChangeForOther;
            if(sUser != "-1")
            {
                Eneblecontrol(sUser);
            }


            VsMain.MFieldRequest(lblUSER_NAME);
            VsMain.MFieldRequest(lblPASSWORD_OLD);
            VsMain.MFieldRequest(lblPASSWORD_NEW);
            VsMain.MFieldRequest(lblPASSWORD_NEW_RE);

        }
        private void Eneblecontrol(string sUser)
        {
            txtUSER_NAME.EditValue = (sUser != "-1") ?  sUser : Com.Mod.UName;
          
            if (iChangeForOther == 0)
            {
                txtUSER_NAME.ReadOnly = true;
                txtPASSWORD_OLD.Text = "";
                txtPASSWORD_NEW.Text = "";
                txtPASSWORD_NEW_RE.Text = "";
                this.ActiveControl = txtPASSWORD_OLD;
            }
            if (iChangeForOther == 1)
            {
                txtUSER_NAME.ReadOnly = true;
                txtPASSWORD_OLD.ReadOnly = true;
                txtPASSWORD_OLD.Text = Com.Mod.OS.Decrypt(SqlHelper.ExecuteScalar(Com.Mod.CNStr, CommandType.Text, "SELECT PASSWORD FROM dbo.USERS WHERE USER_NAME ='" + sUser + "'").ToString(),true);
                txtPASSWORD_NEW.Text = "";
                txtPASSWORD_NEW_RE.Text = "";
                this.ActiveControl = txtPASSWORD_NEW;
            }
        }
        private void ChangePassWord()
        {
           
            //kiêm tra pass cũ có đúng không
            string sPass = SqlHelper.ExecuteScalar(Com.Mod.CNStr,CommandType.Text, "SELECT PASSWORD FROM dbo.USERS WHERE USER_NAME ='"+  txtUSER_NAME.EditValue + "'").ToString();
            if (txtPASSWORD_OLD.Text != Com.Mod.OS.Decrypt(sPass, true))
            {
               XtraMessageBox.Show(Com.Mod.OS.GetLanguage(this.Name, "msgPassWorkkhongdung"), this.Text, MessageBoxButtons.OK,MessageBoxIcon.Error); return;
            }
            if(txtPASSWORD_NEW.Text != txtPASSWORD_NEW_RE.Text)
            {
                XtraMessageBox.Show(Com.Mod.OS.GetLanguage(this.Name, "msgPassWordKhongKhop"), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            //Xác nhận khi đổi mật khẩu cho người khác
            if (iChangeForOther == 1)
            {
                XtraForm ctl;
                Type newType = Type.GetType("VS.ERP.frmXacNhan", true, true);
                object o1 = Activator.CreateInstance(newType);
                ctl = o1 as XtraForm;
                ctl.StartPosition = FormStartPosition.CenterParent;
                if (ctl.ShowDialog() != DialogResult.OK)
                    return;
            }
            //update password
            SqlHelper.ExecuteNonQuery(Com.Mod.CNStr,CommandType.Text, "UPDATE dbo.USERS SET PASSWORD = '" + Com.Mod.OS.Encrypt(txtPASSWORD_NEW_RE.Text,true) + "' WHERE USER_NAME = '" + txtUSER_NAME.Text + "'");
            XtraMessageBox.Show(Com.Mod.OS.GetLanguage(this.Name, "msgSaveThanhCong"), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information); this.Close();
            //kiểm tra pass mới có giống nhâu không
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            ChangePassWord();
        }
        private void frmChangePassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                ChangePassWord();
        }
        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            Com.Mod.OS.ThayDoiNN(this, dataLayoutControl1);
        }
    }
}