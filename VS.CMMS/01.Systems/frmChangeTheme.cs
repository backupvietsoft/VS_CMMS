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
using DevExpress.XtraBars.Helpers;
using DevExpress.LookAndFeel;
using VS.CMMS.Properties;
using DevExpress.XtraBars.Ribbon;

namespace VS.CMMS
{

    public partial class frmChangeTheme : DevExpress.XtraEditors.XtraForm
    {
        //private bool selectionChanged;
        public frmChangeTheme()
        {
            InitializeComponent();
            //SkinHelper.InitSkinGallery(galleryControl1, true, true);
            SkinHelper.InitSkinGallery(galleryControl1, true);
            //this.LookAndFeel.SetSkinStyle(SkinStyle.Bezier, SkinSvgPalette.Bezier.OfficeColorful);
            //this.FormClosing += Form1_FormClosing;
            //RestorePalette();
            VsMain.MRestorePalette();
            galleryControl1.Gallery.ItemClick += new GalleryItemClickEventHandler(Gallery_ItemClick);
            this.FormClosing += frmChangeTheme_FormClosing;

        }
        private void frmChangeTheme_FormClosing(object sender, FormClosingEventArgs e)
        {
            VsMain.MSavePalette();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCapNhap_Click(object sender, EventArgs e)
        {
            if (UserLookAndFeel.Default.SkinName != "The Bezier")
            {
                Settings.Default["AppPalette"] = "";
            }
            else
            {
                Settings.Default["AppPalette"] = UserLookAndFeel.Default.ActiveSvgPaletteName;
            }


            Settings.Default["ApplicationSkinName"] = UserLookAndFeel.Default.SkinName;          

            Settings.Default.Save();
            VsMain.MRestorePalette();
            this.Close();
        }

        private void frmChangeTheme_Load(object sender, EventArgs e)
        {
            Com.Mod.OS.ThayDoiNN(this);
        }
        private void ShowSwatchPicker(Form owner)
        {
            using (var dialog = new DevExpress.Customization.SvgSkinPaletteSelector(owner))
            {
                UserLookAndFeel.Default.SkinName = "The Bezier";
                dialog.ShowDialog();
                VsMain.MSavePalette();
            }
        }

        private void SetSkin(string skinName)
        {
            UserLookAndFeel.Default.SetSkinStyle(skinName);
        }
        private void btnSkin_Click(object sender, EventArgs e)
        {
            ShowSwatchPicker(this);
        }

        private void Gallery_ItemClick(object sender, GalleryItemClickEventArgs e)
        {

            if (UserLookAndFeel.Default.SkinName == "The Bezier")
            {
                ShowSwatchPicker(this);
            }
            else
            {
                Settings.Default["AppPalette"] = "";
                Settings.Default.Save();
            }

        }

    }


}