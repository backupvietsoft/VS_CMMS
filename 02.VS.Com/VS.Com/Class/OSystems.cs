
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraBars.Navigation;
using DevExpress.Utils.Layout;
using System.Threading;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraReports.UI;
using System.Text.RegularExpressions;
using System.IO;
using DevExpress.XtraDataLayout;
using DevExpress.XtraEditors.DXErrorProvider;
using System.Reflection;
using System.Drawing;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using DevExpress.LookAndFeel;
using NPOI.Util.Collections;
using DevExpress.Utils;
using DevExpress.XtraTreeList.Columns;

namespace Com
{
    public class OSystems
    {
        private static string sPathServer = "-1";

        #region LoadLookupedit

        public void MLoadTreeLookUpEdit(TreeListLookUpEdit cbo, DataTable dtTmp, string Ma, string Ten, string Cha, string form, bool isNgonNgu = true)
        {
            try
            {
                cbo.Properties.DataSource = null;
                cbo.Properties.DisplayMember = Ten;
                cbo.Properties.ValueMember = Ma;
                cbo.Properties.DataSource = dtTmp;
                cbo.Properties.TreeList.KeyFieldName = Ma;
                cbo.Properties.TreeList.ParentFieldName = Cha;

                if (!isNgonNgu)
                {
                    return;
                }

                foreach (TreeListColumn column in ((TreeList)cbo.Properties.TreeList).Columns)
                {
                    if (column.Visible)
                    {
                        column.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                        column.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;
                        column.AppearanceHeader.Options.UseTextOptions = true;
                        column.Caption = Mod.OS.GetLanguage(form, column.FieldName);
                    }
                }

                cbo.Refresh();
            }
            catch
            {
            }
        }

        public bool MLoadLookUpEdit(DevExpress.XtraEditors.LookUpEdit cbo, DataTable dtTmp, string Ma, string Ten, string TenCot)
        {
            try
            {
                cbo.Properties.DataSource = null;
                cbo.Properties.DataSource = dtTmp;
                cbo.Properties.DisplayMember = Ten;
                cbo.Properties.ValueMember = Ma;
                cbo.Properties.Columns.Clear();
                cbo.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(Ten));
                cbo.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                cbo.Properties.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                cbo.Properties.BestFitMode = BestFitMode.BestFit;
                cbo.Properties.SearchMode = SearchMode.AutoComplete;
                cbo.EditValue = dtTmp.Rows[0][Ma];
                if (dtTmp.Rows.Count > 10)
                    cbo.Properties.DropDownRows = 15;
                else
                    cbo.Properties.DropDownRows = 10;
                cbo.Properties.Columns[Ten].Caption = TenCot;
                if (TenCot.Trim() == "")
                    cbo.Properties.ShowHeader = false;
                else
                    cbo.Properties.ShowHeader = true;
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region AutoComplete
        public bool MAutoCompleteTextEdit(DevExpress.XtraEditors.TextEdit txt, string sQuery, string Ma)
        {
            try
            {
                txt.MaskBox.AutoCompleteCustomSource = null;
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Mod.CNStr, CommandType.Text, sQuery));
                string[] postSource;
                dtTmp = dtTmp.DefaultView.ToTable(true, Ma);
                postSource = dtTmp.Rows.Cast<DataRow>().Select(dr => dr[Ma].ToString()).ToArray();
                var source = new AutoCompleteStringCollection();
                source.AddRange(postSource);
                txt.MaskBox.AutoCompleteCustomSource = source;
                txt.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txt.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool MAutoCompleteTextEdit(DevExpress.XtraEditors.TextEdit txt, DataTable dtData, string Ma)
        {
            try
            {
                txt.MaskBox.AutoCompleteCustomSource = null;
                string[] postSource;
                dtData = dtData.DefaultView.ToTable(true, Ma);
                postSource = dtData.Rows.Cast<DataRow>().Select(dr => dr[Ma].ToString()).ToArray();
                var source = new AutoCompleteStringCollection();
                source.AddRange(postSource);
                txt.MaskBox.AutoCompleteCustomSource = source;
                txt.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txt.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Load SearchLookUpEdit
        public void MLoadSearchLookUpEdit(DevExpress.XtraEditors.SearchLookUpEdit cbo, DataTable dtTmp, string Ma, string Ten, string form, bool isNgonNgu = true)
        {
            try
            {
                cbo.Properties.DataSource = null;
                cbo.Properties.DisplayMember = "";
                cbo.Properties.ValueMember = "";
                cbo.Properties.DataSource = dtTmp;
                cbo.Properties.DisplayMember = Ten;
                cbo.Properties.ValueMember = Ma;
                cbo.Properties.BestFitMode = BestFitMode.BestFit;
                try
                {
                    cbo.EditValue = dtTmp.Rows[0][Ma];
                }
                catch { }
                cbo.Properties.PopulateViewColumns();
                cbo.Properties.View.Columns[0].Visible = false;
                if (isNgonNgu)
                {
                    DevExpress.XtraGrid.Views.Grid.GridView grv = (DevExpress.XtraGrid.Views.Grid.GridView)cbo.Properties.PopupView;
                    foreach (DevExpress.XtraGrid.Columns.GridColumn col in grv.Columns)
                    {
                        if (col.Visible)
                        {

                            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            col.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                            col.AppearanceHeader.Options.UseTextOptions = true;
                            col.Caption = Mod.OS.GetLanguage( form, col.FieldName);
                        }
                    }
                    cbo.Refresh();
                }


            }
            catch { }
        }
        public void MLoadSearchLookUpEdit(DevExpress.XtraEditors.SearchLookUpEdit cbo, DataTable dtTmp, string Ma, string Ten, string form, bool isNgonNgu, bool isLoad = true)
        {
            try
            {
                cbo.Properties.DataSource = null;
                cbo.Properties.DisplayMember = "";
                cbo.Properties.ValueMember = "";
                cbo.Properties.DataSource = dtTmp;
                cbo.Properties.DisplayMember = Ten;
                cbo.Properties.ValueMember = Ma;
                cbo.Properties.BestFitMode = BestFitMode.BestFit;
                if (isLoad == true && dtTmp.Rows.Count > 0)
                    cbo.EditValue = dtTmp.Rows[0][Ma];
                else
                    cbo.EditValue = null;
                cbo.Properties.PopulateViewColumns();
                cbo.Properties.View.Columns[0].Visible = false;
                if (isNgonNgu)
                {
                    DevExpress.XtraGrid.Views.Grid.GridView grv = (DevExpress.XtraGrid.Views.Grid.GridView)cbo.Properties.PopupView;
                    foreach (DevExpress.XtraGrid.Columns.GridColumn col in grv.Columns)
                    {
                        if (col.Visible)
                        {

                            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            col.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                            col.AppearanceHeader.Options.UseTextOptions = true;
                            col.Caption = Mod.OS.GetLanguage(form, col.FieldName);
                        }
                    }
                    cbo.Refresh();
                }

            }
            catch { }
        }
        public void MLoadSearchN(DevExpress.XtraEditors.SearchLookUpEdit cbo, DataTable dtTmp, string Ma, string Ten, string form, bool isNgonNgu)

        {
            try
            {
                cbo.Properties.DataSource = null;
                cbo.Properties.DisplayMember = "";
                cbo.Properties.ValueMember = "";

                cbo.Properties.DataSource = dtTmp;
                cbo.Properties.DisplayMember = Ten;
                cbo.Properties.ValueMember = Ma;
                cbo.Properties.PopulateViewColumns();
                cbo.Properties.View.Columns[0].Visible = false;
                if (isNgonNgu)
                {
                    DevExpress.XtraGrid.Views.Grid.GridView grv = (DevExpress.XtraGrid.Views.Grid.GridView)cbo.Properties.PopupView;
                    foreach (DevExpress.XtraGrid.Columns.GridColumn col in grv.Columns)
                    {
                        if (col.Visible)
                        {
                            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            col.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                            col.AppearanceHeader.Options.UseTextOptions = true;
                            col.Caption = Mod.OS.GetLanguage(form, col.FieldName);
                        }
                    }
                    cbo.Refresh();
                }
                cbo.Properties.BestFitMode = BestFitMode.BestFit;

            }
            catch { }
        }
        public void MLoadCheckedComboBoxEdit(DevExpress.XtraEditors.CheckedComboBoxEdit cbo, DataTable dtTmp, string Ma, string Ten, string form, bool isNgonNgu)

        {
            try
            {
                cbo.Properties.DataSource = null;
                cbo.Properties.DisplayMember = "";
                cbo.Properties.ValueMember = "";

                cbo.Properties.DataSource = dtTmp;
                cbo.Properties.DisplayMember = Ten;
                cbo.Properties.ValueMember = Ma;
                //cbo.Properties.PopulateViewColumns();
                //cbo.Properties.View.Columns[0].Visible = false;
                cbo.Properties.AppearanceDropDown.Font = (Font)cbo.Font.Clone();
                cbo.Properties.DropDownRows = dtTmp.Rows.Count+ 2;
            }
            catch { }
        }
        #endregion

        #region Load ComboBoxEdit
        public void MLoadComboBoxEdit(DevExpress.XtraEditors.ComboBoxEdit ComboBoxEdit, DataTable DataTable)
        {
            try
            {
                foreach(DataRow DataRow in DataTable.Rows)
                {
                    ComboBoxEdit.Properties.Items.Add(DataRow[0]);
                }
            }
            catch { }
        }

        public void MLoadComboBoxEdit(DevExpress.XtraEditors.ComboBoxEdit ComboBoxEdit, List<string> ListString)
        {
            try
            {
                ComboBoxEdit.Properties.Items.AddRange(ListString);
            }
            catch { }
        }
        #endregion



        #region GetValue Form SearchLookUpEdit

        public DataTable MGetToSearchDataTable(DevExpress.XtraEditors.SearchLookUpEdit cbo, string sFieldWhere, int iValueWhere)
        {
            DataTable dtTmp = new DataTable();
            if (cbo.EditValue.ToString() != "")
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = (DataTable)cbo.Properties.DataSource;
                    dtTmp = MGetValueToData(dt, sFieldWhere, iValueWhere);
                }
                catch { }
            }
            return dtTmp;

        }

        public string MGetToSearchString(DevExpress.XtraEditors.SearchLookUpEdit cbo, string sFieldWhere, int iValueWhere, string sGetValue)
        {
            DataTable dtTmp = new DataTable();
            string sTmp = "";
            if (cbo.EditValue.ToString() != "")
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = (DataTable)cbo.Properties.DataSource;
                    dtTmp = MGetValueToData(dt, sFieldWhere, iValueWhere);
                    sTmp = dtTmp.Rows[0][sGetValue].ToString();
                }
                catch { }
            }
            return sTmp;

        }

        public DataTable MGetValueToData(DataTable dt, string sFieldWhere, int iValueWhere)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                dtTmp = dt.AsEnumerable().Where(dr => dr.Field<int>(sFieldWhere) == int.Parse(iValueWhere.ToString())).CopyToDataTable();
            }
            catch { }
            return dtTmp;


        }
        #endregion

        
        #region Load xtragrid
        public bool MLoadXtraGrid(DevExpress.XtraGrid.GridControl grd, DevExpress.XtraGrid.Views.Grid.GridView grv, DataTable dtTmp, bool MEditable, bool MPopulateColumns, bool MColumnAutoWidth, bool MBestFitColumns)
        {
            try
            {
                grd.DataSource = dtTmp;
                grv.OptionsBehavior.Editable = MEditable;
                if (MPopulateColumns == true)
                    grv.PopulateColumns();

                grv.OptionsView.ColumnAutoWidth = MColumnAutoWidth;
                


                grv.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
                grv.OptionsView.RowAutoHeight = true;
                grv.Appearance.HeaderPanel.Options.UseTextOptions = true;
                grv.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                grv.OptionsView.AllowHtmlDrawHeaders = true;
                grv.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                grv.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

                grv.AppearancePrint.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                grv.AppearancePrint.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                grv.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;




                if (MBestFitColumns)
                    grv.BestFitColumns();
                grv.OptionsBehavior.FocusLeaveOnTab = true;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool MLoadXtraGrid(DevExpress.XtraGrid.GridControl grd, DevExpress.XtraGrid.Views.Grid.GridView grv, DataTable dtTmp, bool MEditable, bool MPopulateColumns, bool MColumnAutoWidth, bool MBestFitColumns, bool MloadNNgu, string fName)
        {
            try
            {
                grd.DataSource = dtTmp;
                grv.OptionsBehavior.Editable = MEditable;
                if (MPopulateColumns == true)
                    grv.PopulateColumns();
                grv.OptionsView.ColumnAutoWidth = MColumnAutoWidth;
                grv.OptionsView.AllowHtmlDrawHeaders = true;
                grv.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                if (MBestFitColumns) grv.BestFitColumns();
                grv.OptionsBehavior.FocusLeaveOnTab = true;


                if (MloadNNgu)
                    MLoadNNXtraGrid(grv, fName);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool MLoadXtraGrid(DevExpress.XtraGrid.Views.Grid.GridView grv, bool MEditable, bool MPopulateColumns, bool MColumnAutoWidth, bool MBestFitColumns, bool MloadNNgu, string fName)
        {
            try
            {

                grv.OptionsBehavior.Editable = MEditable;
                if (MPopulateColumns == true)
                    grv.PopulateColumns();
                grv.OptionsView.ColumnAutoWidth = MColumnAutoWidth;
                grv.OptionsView.AllowHtmlDrawHeaders = true;
                grv.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                if (MBestFitColumns) grv.BestFitColumns();
                grv.OptionsBehavior.FocusLeaveOnTab = true;


                if (MloadNNgu)
                    MLoadNNXtraGrid(grv, fName);

                return true;
            }
            catch
            {
                return false;
            }
        }


        public void MFormatCol(GridView grv, string sColFormat, int iFormatString)
        {
            try
            {
                string  sFormatString = "n" + iFormatString.ToString();
                RepositoryItemTextEdit txtEdit = new RepositoryItemTextEdit();
                txtEdit.DisplayFormat.FormatString = sFormatString;
                txtEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                txtEdit.EditFormat.FormatString = sFormatString;
                txtEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                txtEdit.Mask.EditMask = sFormatString;
                txtEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                txtEdit.Mask.UseMaskAsDisplayFormat = true;
                grv.Columns[sColFormat].ColumnEdit = txtEdit;
                //grv.Columns[sColFormat].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                //grv.Columns[sColFormat].DisplayFormat.FormatString = sFormatString;
            }
            catch
            {
                grv.Columns[sColFormat].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grv.Columns[sColFormat].DisplayFormat.FormatString = "N2";
            }
        }
        public void MFormatCol(GridView grv, string sColFormat, string sFormatString)
        {
            try
            {
                RepositoryItemTextEdit txtEdit = new RepositoryItemTextEdit();
                txtEdit.DisplayFormat.FormatString = sFormatString;
                txtEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                txtEdit.EditFormat.FormatString = sFormatString;
                txtEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                txtEdit.Mask.EditMask = sFormatString;
                txtEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Custom;
                txtEdit.Mask.UseMaskAsDisplayFormat = true;
                grv.Columns[sColFormat].ColumnEdit = txtEdit;
            }
            catch
            {
                grv.Columns[sColFormat].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                grv.Columns[sColFormat].DisplayFormat.FormatString = "";
            }
        }

        public void MFormatSpinEdit(SpinEdit txtEdit, int iFormatString)
        {
            try
            {
                string sFormatString = "n" + iFormatString.ToString();        
                txtEdit.Properties.DisplayFormat.FormatString = sFormatString;
                txtEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                txtEdit.Properties.EditFormat.FormatString = sFormatString;
                txtEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                txtEdit.Properties.Mask.EditMask = sFormatString;
                txtEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                txtEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            }
            catch
            {
                txtEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                txtEdit.Properties.EditFormat.FormatString = "N2";
            }
        }

        public void MFormatTextEdit(TextEdit txtEdit, int iFormatString)
        {
            try
            {
                string sFormatString = "n" + iFormatString.ToString();
                txtEdit.Properties.DisplayFormat.FormatString = sFormatString;
                txtEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                txtEdit.Properties.EditFormat.FormatString = sFormatString;
                txtEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                txtEdit.Properties.Mask.EditMask = sFormatString;
                txtEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                txtEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            }
            catch
            {
                txtEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                txtEdit.Properties.EditFormat.FormatString = "N2";
            }
        }


        public void MFormatDateEdit(DateEdit txtEdit, string sFormatString)
        {
            try
            {
                if (sFormatString == "") sFormatString = "d";
                txtEdit.Properties.CalendarTimeProperties.Mask.EditMask = "d";
                txtEdit.Properties.CalendarTimeProperties.Mask.UseMaskAsDisplayFormat = true;
                //txtEdit.Properties.DisplayFormat.FormatString = "";
                txtEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                txtEdit.Properties.EditFormat.FormatString = "";
                txtEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                txtEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            }
            catch
            {
                txtEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                txtEdit.Properties.EditFormat.FormatString = "N2";
            }
        }

      

        public void MSaveResertLTree(DevExpress.XtraTreeList.TreeList lst, string fName)
        {
            try
            {
                //kiểm tra có trong table định dạng lưới chưa có thì load
                if (Convert.ToInt32(SqlHelper.ExecuteScalar(Mod.CNStr, CommandType.Text, "SELECT COUNT(*) FROM dbo.DINH_DANG_LUOI WHERE TEN_FORM = '" + fName + "' AND TEN_GRID = '" + lst.Name + "'")) == 1)
                {
                    // RESTORE  
                    var layoutString = (string)SqlHelper.ExecuteScalar(Mod.CNStr, CommandType.Text, "SELECT ISNULL(DINH_DANG,'') AS DINH_DANG FROM dbo.DINH_DANG_LUOI WHERE TEN_FORM = '" + fName + "' AND TEN_GRID = '" + lst.Name + "'");
                    if (!string.IsNullOrEmpty(layoutString))
                    {

                        Stream s = new MemoryStream();
                        StreamWriter sw = new StreamWriter(s);
                        sw.Write(layoutString);
                        sw.Flush();
                        s.Seek(0, SeekOrigin.Begin);
                        lst.RestoreLayoutFromStream(s);
                        sw.Close();
                    }
                    else
                    { SaveLayOutLTree(lst, fName); }
                }
                else
                {
                    // SAVE  
                    SaveLayOutLTree(lst, fName);
                }



                //if (Com.Mod.UName.ToLower() == "admin")
                //{
                    lst.PopupMenuShowing += delegate (object a, DevExpress.XtraTreeList.PopupMenuShowingEventArgs b) { TList_PopupMenuShowing(lst, b, lst, fName); };
                //}

            }
            catch
            {
            }
        }

        public Boolean MRestoreLayout(DevExpress.XtraGrid.Views.Grid.GridView grv, string fName)
        {
            try
            {
                // RESTORE  
                var layoutString = (string)SqlHelper.ExecuteScalar(Mod.CNStr, CommandType.Text, "SELECT ISNULL(DINH_DANG,'') AS DINH_DANG FROM dbo.DINH_DANG_LUOI WHERE TEN_FORM = '" + fName + "' AND TEN_GRID = '" + grv.Name + "'");
                if (!string.IsNullOrEmpty(layoutString))
                {

                    Stream s = new MemoryStream();
                    StreamWriter sw = new StreamWriter(s);
                    sw.Write(layoutString);
                    sw.Flush();
                    s.Seek(0, SeekOrigin.Begin);
                    grv.RestoreLayoutFromStream(s);
                    sw.Close();
                    return true;
                }else
                    return false;
            }
            catch
            {
                return false;
            }
            
        }

        public void MSaveResertGrid(DevExpress.XtraGrid.Views.Grid.GridView grv, string fName)
        {
            try
            {
                //kiểm tra có trong table định dạng lưới chưa có thì load
                if (!MRestoreLayout(grv, fName))
                    SaveLayOutGrid(grv, fName);

                if (Com.Mod.GroupID == 1 || Com.Mod.GroupID == 13)
                {
                    grv.DoubleClick += delegate (object a, EventArgs b) { Grv_DoubleClick(a, b, fName); };
                }

                grv.PopupMenuShowing += delegate (object a, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs b) { Grv_PopupMenuShowing(grv, b, grv, fName); };
               

            }
            catch
            {
            }
        }


        public Boolean MRestoreLayout(DevExpress.XtraGrid.Views.Grid.GridView grv,  string fName, string sName)
        {
            try
            {
                // RESTORE  
                var layoutString = (string)SqlHelper.ExecuteScalar(Mod.CNStr, CommandType.Text, "SELECT ISNULL(DINH_DANG,'') AS DINH_DANG FROM dbo.DINH_DANG_LUOI WHERE TEN_FORM = '" + fName + "' AND TEN_GRID = N'" + sName + "'");
                if (!string.IsNullOrEmpty(layoutString))
                {
                    Stream s = new MemoryStream();
                    StreamWriter sw = new StreamWriter(s);
                    sw.Write(layoutString);
                    sw.Flush();
                    s.Seek(0, SeekOrigin.Begin);
                    grv.RestoreLayoutFromStream(s);
                    sw.Close();
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
            
        }

        public void MSaveResertGrid(DevExpress.XtraGrid.Views.Grid.GridView grv, string fName, string sName)
        {
            try
            {
                if (!MRestoreLayout(grv, fName,sName))
                    SaveLayOutGrid(grv, fName,sName);
                grv.PopupMenuShowing += delegate (object a, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs b) { Grv_PopupMenuShowing(grv, b, grv, fName, sName); };
                grv.Tag = sName;
            }
            catch
            {
            }
        }


        public void MSaveResertTList(DevExpress.XtraTreeList.TreeList lst, string fName)
        {
            try
            {
                //kiểm tra có trong table định dạng lưới chưa có thì load
                if (Convert.ToInt32(SqlHelper.ExecuteScalar(Mod.CNStr, CommandType.Text, "SELECT COUNT(*) FROM dbo.DINH_DANG_LUOI WHERE TEN_FORM = '" + fName + "' AND TEN_GRID = '" + lst.Name + "'")) == 1)
                {
                    // RESTORE  
                    var layoutString = (string)SqlHelper.ExecuteScalar(Mod.CNStr, CommandType.Text, "SELECT ISNULL(DINH_DANG,'') AS DINH_DANG FROM dbo.DINH_DANG_LUOI WHERE TEN_FORM = '" + fName + "' AND TEN_GRID = '" + lst.Name + "'");
                    if (!string.IsNullOrEmpty(layoutString))
                    {

                        Stream s = new MemoryStream();
                        StreamWriter sw = new StreamWriter(s);
                        sw.Write(layoutString);
                        sw.Flush();
                        s.Seek(0, SeekOrigin.Begin);
                        lst.RestoreLayoutFromStream(s);
                        sw.Close();
                    }
                    else
                    { SaveLayOutLTree(lst, fName); }
                }
                else
                {
                    // SAVE  
                    SaveLayOutLTree(lst, fName);
                }


                //if (Com.Mod.UName.ToLower() == "admin")
                //{
                    lst.PopupMenuShowing += delegate (object a, DevExpress.XtraTreeList.PopupMenuShowingEventArgs b) { TList_PopupMenuShowing(lst, b, lst, fName); };
                //}

            }
            catch
            {
            }
        }


        private void MenuItemReset_Click(object sender, EventArgs e, GridView grv, string fName)
        {
            try
            {
                //update
                SqlHelper.ExecuteNonQuery(Mod.CNStr, CommandType.Text, "UPDATE dbo.DINH_DANG_LUOI SET DINH_DANG = MAC_DINH WHERE TEN_FORM = '" + fName + "' AND TEN_GRID = '" + grv.Name + "'");


                string text = (Convert.ToString(SqlHelper.ExecuteScalar(Mod.CNStr, CommandType.Text, "SELECT DINH_DANG FROM dbo.DINH_DANG_LUOI WHERE TEN_FORM = '" + fName + "' AND TEN_GRID = '" + grv.Name + "'")));
                byte[] byteArray = Encoding.ASCII.GetBytes(text);
                MemoryStream stream = new MemoryStream(byteArray);
                grv.RestoreLayoutFromStream(stream);
                MLoadNNXtraGrid(grv, fName);
            }
            catch { }
        }

        private void MenuItemReset_Click(object sender, EventArgs e, GridView grv, string fName, string sName)
        {
            try
            {
                //update
                SqlHelper.ExecuteNonQuery(Mod.CNStr, CommandType.Text, "UPDATE dbo.DINH_DANG_LUOI SET DINH_DANG = MAC_DINH WHERE TEN_FORM = '" + fName + "' AND TEN_GRID = '" + sName + "'");


                string text = (Convert.ToString(SqlHelper.ExecuteScalar(Mod.CNStr, CommandType.Text, "SELECT DINH_DANG FROM dbo.DINH_DANG_LUOI WHERE TEN_FORM = '" + fName + "' AND TEN_GRID = '" + sName + "'")));
                byte[] byteArray = Encoding.ASCII.GetBytes(text);
                MemoryStream stream = new MemoryStream(byteArray);
                grv.RestoreLayoutFromStream(stream);
                MLoadNNXtraGrid(grv, fName);
            }
            catch { }
        }


        private void MenuItemResetTList(object sender, EventArgs e, DevExpress.XtraTreeList.TreeList lst, string fName)
        {
            try
            {
                //update
                SqlHelper.ExecuteNonQuery(Mod.CNStr, CommandType.Text, "UPDATE dbo.DINH_DANG_LUOI SET DINH_DANG = MAC_DINH WHERE TEN_FORM = '" + fName + "' AND TEN_GRID = '" + lst.Name + "'");


                string text = (Convert.ToString(SqlHelper.ExecuteScalar(Mod.CNStr, CommandType.Text, "SELECT DINH_DANG FROM dbo.DINH_DANG_LUOI WHERE TEN_FORM = '" + fName + "' AND TEN_GRID = '" + lst.Name + "'")));
                byte[] byteArray = Encoding.ASCII.GetBytes(text);
                MemoryStream stream = new MemoryStream(byteArray);
                lst.RestoreLayoutFromStream(stream);
                MLoadNNXtraTreeList(lst, fName);
            }
            catch { }
        }

        public void MyMenuItemExport(System.Object sender, System.EventArgs e, GridView grv, string fName)
        {
            MExportGridView(grv);
        }
        public void MyMenuItemSave(System.Object sender, System.EventArgs e, GridView grv, string fName)
        {
            // SAVE  
            SaveLayOutGrid(grv, fName);
        }

        public void MyMenuItemSave(System.Object sender, System.EventArgs e, GridView grv, string fName, string sName)
        {
            // SAVE  
            SaveLayOutGrid(grv, fName, sName);
        }


        public void MyMenuItemSaveTList(System.Object sender, System.EventArgs e, DevExpress.XtraTreeList.TreeList lst, string fName)
        {
            // SAVE  
            SaveLayOutLTree(lst, fName);
        }


        public void MyMenuItemDelete(System.Object sender, System.EventArgs e, GridView grv, string fName)
        {
            // DELETE  
            try
            {
                //update
                SqlHelper.ExecuteNonQuery(Mod.CNStr, CommandType.Text, "DELETE dbo.DINH_DANG_LUOI WHERE TEN_FORM = '" + fName + "' AND TEN_GRID = '" + grv.Name + "'");
                //Com.Mod.ObjSystems.MLoadNNXtraGrid(grv, fName);
            }
            catch { }
        }

        public void MyMenuItemDelete(System.Object sender, System.EventArgs e, GridView grv, string fName, string sName)
        {
            // DELETE  
            try
            {
                //update
                SqlHelper.ExecuteNonQuery(Mod.CNStr, CommandType.Text, "DELETE dbo.DINH_DANG_LUOI WHERE TEN_FORM = '" + fName + "' AND TEN_GRID = '" + sName + "'");
                //Com.Mod.ObjSystems.MLoadNNXtraGrid(grv, fName);
            }
            catch { }
        }


        public void MyMenuItemDeleteTList(System.Object sender, System.EventArgs e, DevExpress.XtraTreeList.TreeList lst, string fName)
        {
            // DELETE  
            try
            {
                //update
                SqlHelper.ExecuteNonQuery(Mod.CNStr, CommandType.Text, "DELETE dbo.DINH_DANG_LUOI WHERE TEN_FORM = '" + fName + "' AND TEN_GRID = '" + lst.Name + "'");
                //Com.Mod.ObjSystems.MLoadNNXtraGrid(grv, fName);
            }
            catch { }
        }


        private void SaveLayOutLTree(DevExpress.XtraTreeList.TreeList lst, string fName)
        {
            // SAVE  grid.SaveLayoutToStream(s);
            try
            {
                Stream str = new System.IO.MemoryStream();
                lst.SaveLayoutToStream(str);
                str.Seek(0, System.IO.SeekOrigin.Begin);
                StreamReader reader = new StreamReader(str);
                string text = reader.ReadToEnd();



                //kiểm tra xem tồn tại chưa có thì update chưa có thì inser
                if (Convert.ToInt32(SqlHelper.ExecuteScalar(Mod.CNStr, CommandType.Text, "SELECT COUNT(*) FROM dbo.DINH_DANG_LUOI WHERE TEN_FORM = '" + fName + "' AND TEN_GRID = '" + lst.Name + "'")) == 0)
                {
                    //insert
                    SqlHelper.ExecuteNonQuery(Mod.CNStr, CommandType.Text, "INSERT INTO dbo.DINH_DANG_LUOI ( TEN_FORM, TEN_GRID, DINH_DANG,MAC_DINH )VALUES  ( N'" + fName + "',N'" + lst.Name + "',N'" + text + "',N'" + reader.ReadToEnd() + "')");
                }
                else
                {
                    //update
                    SqlHelper.ExecuteNonQuery(Mod.CNStr, CommandType.Text, "UPDATE dbo.DINH_DANG_LUOI SET DINH_DANG = N'" + text + "' WHERE TEN_FORM = '" + fName + "' AND TEN_GRID = '" + lst.Name + "'");
                }
            }
            catch { }
        }

        private void SaveLayOutGrid(GridView grv, string fName)
        {
            // SAVE  grid.SaveLayoutToStream(s);
            try
            {
                Stream str = new System.IO.MemoryStream();
                grv.SaveLayoutToStream(str);
                str.Seek(0, System.IO.SeekOrigin.Begin);
                StreamReader reader = new StreamReader(str);
                string text = reader.ReadToEnd();
                //kiểm tra xem tồn tại chưa có thì update chưa có thì insert
                if (Convert.ToInt32(SqlHelper.ExecuteScalar(Mod.CNStr, CommandType.Text, "SELECT COUNT(*) FROM dbo.DINH_DANG_LUOI WHERE TEN_FORM = '" + fName + "' AND TEN_GRID = '" + grv.Name + "'")) == 0)
                {
                    //insert
                    SqlHelper.ExecuteNonQuery(Mod.CNStr, CommandType.Text, "INSERT INTO dbo.DINH_DANG_LUOI ( TEN_FORM, TEN_GRID, DINH_DANG,MAC_DINH )VALUES  ( N'" + fName + "',N'" + grv.Name + "',N'" + text + "',N'" + reader + "')");
                }
                else
                {
                    //update
                    SqlHelper.ExecuteNonQuery(Mod.CNStr, CommandType.Text, "UPDATE dbo.DINH_DANG_LUOI SET DINH_DANG = '" + text + "' WHERE TEN_FORM = '" + fName + "' AND TEN_GRID = '" + grv.Name + "'");
                }
            }
            catch { }
        }

        private void SaveLayOutGrid(GridView grv, string fName, string sName)
        {
            // SAVE  grid.SaveLayoutToStream(s);
            try
            {
                //GridView.OptionsLayout.Columns.StoreAllOptions

                Stream str = new System.IO.MemoryStream();
                grv.SaveLayoutToStream(str);
                str.Seek(0, System.IO.SeekOrigin.Begin);
                StreamReader reader = new StreamReader(str);
                string text = reader.ReadToEnd();

                //kiểm tra xem tồn tại chưa có thì update chưa có thì inser
                if (Convert.ToInt32(SqlHelper.ExecuteScalar(Mod.CNStr, CommandType.Text, "SELECT COUNT(*) FROM dbo.DINH_DANG_LUOI WHERE TEN_FORM = '" + fName + "' AND TEN_GRID = N'" + sName + "'")) == 0)
                {
                    //insert
                    SqlHelper.ExecuteNonQuery(Mod.CNStr, CommandType.Text, "INSERT INTO dbo.DINH_DANG_LUOI ( TEN_FORM, TEN_GRID, DINH_DANG,MAC_DINH )VALUES  ( N'" + fName + "',N'" + sName + "',N'" + text + "',N'" + reader.ReadToEnd() + "')");
                }
                else
                {
                    //update
                    SqlHelper.ExecuteNonQuery(Mod.CNStr, CommandType.Text, "UPDATE dbo.DINH_DANG_LUOI SET DINH_DANG = '" + text + "' WHERE TEN_FORM = '" + fName + "' AND TEN_GRID = '" + sName + "'");
                }
            }
            catch { }
        }



        private void Grv_DoubleClick(object sender, EventArgs e, string sName)
        {
            if (Form.ModifierKeys == Keys.Control)
            {
                try
                {
                    DevExpress.XtraGrid.Views.Grid.GridView View;
                    string sText = "";
                    View = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
                    DevExpress.Utils.DXMouseEventArgs dxMouseEventArgs = e as DevExpress.Utils.DXMouseEventArgs;
                    DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hitInfo = View.CalcHitInfo(dxMouseEventArgs.Location);
                    if (hitInfo.InColumn)
                    {
                        try
                        {
                            sText = XtraInputBox.Show(hitInfo.Column.GetTextCaption(), "Sửa ngôn ngữ", "");
                            if (String.IsNullOrEmpty(sText)  )
                                return;
                            else if (sText == "Windows.Forms.DialogResult.Retry")
                            {
                                
                                sText = "";
                                CapNhapNN(sName, hitInfo.Column.FieldName, sText, true);
                            }
                            else
                                CapNhapNN(sName, hitInfo.Column.FieldName, sText, false);
                            sText = " SELECT TOP 1 " + (Com.Mod.iNNgu == 0 ? "VIETNAM" : "ENGLISH") + " FROM LANGUAGES WHERE FORM = '" + sName + "' AND KEYWORD = '" + hitInfo.Column.FieldName + "' AND MS_MODULE = 'ECOMAIN' ";
                            sText = Convert.ToString(SqlHelper.ExecuteScalar(Mod.CNStr, CommandType.Text, sText));
                            hitInfo.Column.Caption = sText;
                        }
                        catch
                        {
                        }
                    }
                }
                catch
                {
                }
            }
        }

        private void Grv_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e, GridView grv, string fName)
        {
            if (e.MenuType != DevExpress.XtraGrid.Views.Grid.GridMenuType.Column)
                return;
            try
            {
                DevExpress.XtraGrid.Menu.GridViewMenu headerMenu = (DevExpress.XtraGrid.Menu.GridViewMenu)e.Menu;
                if (headerMenu.Items.Where(x => x.Caption.Equals("Reset Grid")).Count() == 1) return;

                if (Com.Mod.GroupID == 1 || Com.Mod.GroupID == 13)
                {
                    // menu resetgrid
                    DevExpress.Utils.Menu.DXMenuItem menuItem = new DevExpress.Utils.Menu.DXMenuItem("Reset Grid");
                    menuItem.BeginGroup = true;
                    menuItem.Tag = e.Menu;
                    menuItem.Click += delegate (object a, EventArgs b) { MenuItemReset_Click(null, null, grv, fName); };
                    headerMenu.Items.Add(menuItem);
                    // menu resetgrid
                    DevExpress.Utils.Menu.DXMenuItem menuSave = new DevExpress.Utils.Menu.DXMenuItem("Save Grid");
                    //menuSave.BeginGroup = true;
                    menuSave.Tag = e.Menu;
                    menuSave.Click += delegate (object a, EventArgs b) { MyMenuItemSave(null, null, grv, fName); };
                    headerMenu.Items.Add(menuSave);
                    // menu deletegrid
                    if (Com.Mod.UName.ToLower() == "minh.tc" || Com.Mod.UName.ToLower() == "h.tc" || Com.Mod.UName.ToLower() == "admin"|| Com.Mod.UName.ToLower() == "it" || Com.Mod.UName.ToLower() == "erpsupport" || Com.Mod.UName.ToLower() == "administrator")
                    {
                        DevExpress.Utils.Menu.DXMenuItem menuDelete = new DevExpress.Utils.Menu.DXMenuItem("Delete Save Grid");
                        //menuDelete.BeginGroup = true;
                        menuDelete.Tag = e.Menu;
                        menuDelete.Click += delegate (object a, EventArgs b) { MyMenuItemDelete(null, null, grv, fName); };
                        headerMenu.Items.Add(menuDelete);
                    }
                }
                DevExpress.Utils.Menu.DXMenuItem menuExport = new DevExpress.Utils.Menu.DXMenuItem("Export Grid");
                menuExport.BeginGroup = true;
                menuExport.Tag = e.Menu;
                menuExport.Click += delegate (object a, EventArgs b) { MyMenuItemExport(null, null, grv, fName); };
                headerMenu.Items.Add(menuExport);

            }
            catch
            {
            }
        }

        private void Grv_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e, GridView grv, string fName, string sName)
        {
            if (e.MenuType != DevExpress.XtraGrid.Views.Grid.GridMenuType.Column || grv.Tag.ToString().ToUpper() != sName.ToUpper()) return;

            try
            {
                DevExpress.XtraGrid.Menu.GridViewMenu headerMenu = (DevExpress.XtraGrid.Menu.GridViewMenu)e.Menu;

                if (headerMenu.Items.Where(x => x.Caption.Equals("Reset Grid")).Count() == 1) return;
                if (Com.Mod.GroupID == 1 || Com.Mod.GroupID == 13)
                {
                    // menu resetgrid
                    DevExpress.Utils.Menu.DXMenuItem menuItem = new DevExpress.Utils.Menu.DXMenuItem("Reset Grid");
                    menuItem.BeginGroup = true;
                    menuItem.Tag = e.Menu;
                    menuItem.Click -= delegate (object a, EventArgs b) { MenuItemReset_Click(null, null, grv, fName, sName); };
                    menuItem.Click += delegate (object a, EventArgs b) { MenuItemReset_Click(null, null, grv, fName, sName); };
                    headerMenu.Items.Add(menuItem);
                    // menu resetgrid
                    DevExpress.Utils.Menu.DXMenuItem menuSave = new DevExpress.Utils.Menu.DXMenuItem("Save Grid");
                    //menuSave.BeginGroup = true;
                    menuSave.Tag = e.Menu;
                    menuSave.Click -= delegate (object a, EventArgs b) { MyMenuItemSave(null, null, grv, fName, sName); };
                    menuSave.Click += delegate (object a, EventArgs b) { MyMenuItemSave(null, null, grv, fName, sName); };
                    headerMenu.Items.Add(menuSave);
                    // menu deletegrid
                    if (Com.Mod.UName.ToLower() == "minh" || Com.Mod.UName.ToLower() == "minh.tc" || Com.Mod.UName.ToLower() == "h.tc" || Com.Mod.UName.ToLower() == "admin" || Com.Mod.UName.ToLower() == "it" || Com.Mod.UName.ToLower() == "erpsupport" || Com.Mod.UName.ToLower() == "administrator")
                    {
                        DevExpress.Utils.Menu.DXMenuItem menuDelete = new DevExpress.Utils.Menu.DXMenuItem("Delete Save Grid");
                        //menuDelete.BeginGroup = true;
                        menuDelete.Tag = e.Menu;
                        menuDelete.Click -= delegate (object a, EventArgs b) { MyMenuItemDelete(null, null, grv, fName, sName); };
                        menuDelete.Click += delegate (object a, EventArgs b) { MyMenuItemDelete(null, null, grv, fName, sName); };
                        headerMenu.Items.Add(menuDelete);
                    }
                }
                DevExpress.Utils.Menu.DXMenuItem menuExport = new DevExpress.Utils.Menu.DXMenuItem("Export Grid");
                menuExport.BeginGroup = true;
                menuExport.Tag = e.Menu;
                menuExport.Click += delegate (object a, EventArgs b) { MyMenuItemExport(null, null, grv, fName); };
                headerMenu.Items.Add(menuExport);
            }
            catch
            {
            }
        }
        
        private void TList_PopupMenuShowing(object sender, DevExpress.XtraTreeList.PopupMenuShowingEventArgs e, DevExpress.XtraTreeList.TreeList lst, string fName)
        {
            //e.HitInfo.HitInfoType == HitInfoType.Column

            //if (e.Menu != DevExpress.XtraGrid.Views.Grid.GridMenuType.Column)
            //    return;
            //if (e.Menu != DevExpress.XtraTreeList.treelistme)
            //    return;

            if (e.HitInfo.InRow) return;

            try
            {
                DevExpress.XtraTreeList.Menu.TreeListMenu headerMenu = (DevExpress.XtraTreeList.Menu.TreeListMenu)e.Menu;
                if (Com.Mod.GroupID == 1)
                {
                    if (headerMenu.Items.Where(x => x.Caption.Equals("Reset List")).Count() == 1) return;
                    // menu resetgrid
                    DevExpress.Utils.Menu.DXMenuItem menuItem = new DevExpress.Utils.Menu.DXMenuItem("Reset List");
                    menuItem.BeginGroup = true;
                    menuItem.Tag = e.Menu;
                    menuItem.Click += delegate (object a, EventArgs b) { MenuItemResetTList(null, null, lst, fName); };
                    headerMenu.Items.Add(menuItem);
                    // menu resetgrid
                    DevExpress.Utils.Menu.DXMenuItem menuSave = new DevExpress.Utils.Menu.DXMenuItem("Save List");
                    //menuSave.BeginGroup = true;
                    menuSave.Tag = e.Menu;
                    menuSave.Click += delegate (object a, EventArgs b) { MyMenuItemSaveTList(null, null, lst, fName); };
                    headerMenu.Items.Add(menuSave);
                    // menu deletegrid
                    if (Com.Mod.UName.ToLower() == "minh.tc" || Com.Mod.UName.ToLower() == "h.tc" || Com.Mod.UName.ToLower() == "admin" || Com.Mod.UName.ToLower() == "it" || Com.Mod.UName.ToLower() == "erpsupport" || Com.Mod.UName.ToLower() == "administrator")
                    {
                        DevExpress.Utils.Menu.DXMenuItem menuDelete = new DevExpress.Utils.Menu.DXMenuItem("Delete Save List");
                        //menuDelete.BeginGroup = true;
                        menuDelete.Tag = e.Menu;
                        menuDelete.Click += delegate (object a, EventArgs b) { MyMenuItemDeleteTList(null, null, lst, fName); };
                        headerMenu.Items.Add(menuDelete);
                    }
                }
            }
            catch
            {
            }
        }

        public void MLoadNNGrid(DevExpress.XtraGrid.Views.Grid.GridView grv, string fName, string sGrvName)
        {
            try
            {
                if (sGrvName == "") sGrvName = grv.Name.ToString();
                 DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Mod.CNStr, CommandType.Text, "SELECT KEYWORD , CASE " + Mod.iNNgu + " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'" + fName + "' AND KEY_VIEW = N'"  +  sGrvName + "' "));
                for (int i = 0; i < grv.VisibleColumns.Count; i++)
                {
                    if (!grv.OptionsBehavior.Editable)
                    {
                        grv.Columns[grv.GetVisibleColumn(i).FieldName.ToString()].OptionsColumn.AllowFocus = false;
                    }
                    else
                    {
                        grv.Columns[grv.GetVisibleColumn(i).FieldName.ToString()].OptionsColumn.AllowFocus = true;
                    }
                    grv.Columns[grv.GetVisibleColumn(i).FieldName.ToString()].Caption = GetNNGrv(dtTmp, grv.GetVisibleColumn(i).FieldName.ToString(), fName,sGrvName);
                }
                grv.OptionsView.RowAutoHeight = true;
                grv.OptionsNavigation.EnterMoveNextColumn = true;

                grv.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                grv.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                grv.Appearance.HeaderPanel.Options.UseTextOptions = true;
            }
            catch { }
        }
        public void MLoadNNGrid(DevExpress.XtraGrid.Views.Grid.GridView grv, string fName, string sGrvName, bool mSaveGrid)
        {
            try
            {
                if (sGrvName == "") sGrvName = grv.Name.ToString();
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Mod.CNStr, CommandType.Text, "SELECT KEYWORD , CASE " + Mod.iNNgu + " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'" + fName + "' AND KEY_VIEW = N'" + sGrvName + "' "));
                
                for (int i = 0; i < grv.VisibleColumns.Count; i++)
                {
                    if (!grv.OptionsBehavior.Editable)
                    {
                        grv.Columns[grv.GetVisibleColumn(i).FieldName.ToString()].OptionsColumn.AllowFocus = false;
                    }
                    else
                    {
                        grv.Columns[grv.GetVisibleColumn(i).FieldName.ToString()].OptionsColumn.AllowFocus = true;
                    }
                    grv.Columns[grv.GetVisibleColumn(i).FieldName.ToString()].Caption = GetNNGrv(dtTmp, grv.GetVisibleColumn(i).FieldName.ToString(), fName, sGrvName);
                }
                grv.OptionsView.RowAutoHeight = true;
                grv.OptionsNavigation.EnterMoveNextColumn = true;

                grv.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                grv.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                grv.Appearance.HeaderPanel.Options.UseTextOptions = true;
            }
            catch { }
            try
            {
                if (mSaveGrid) MSaveResertGrid(grv, fName);
            }
            catch { }
        }
        public void MLoadNNGrid(DataTable dtNN, DevExpress.XtraGrid.Views.Grid.GridView grv, string fName)
        {
            try
            {
                grv.OptionsView.RowAutoHeight = true;
                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grv.Columns)
                {
                    if (col.Visible)
                    {
                        if (!grv.OptionsBehavior.Editable)
                        {
                            col.OptionsColumn.AllowFocus = false;
                        }
                        else
                        {
                            col.OptionsColumn.AllowFocus = true;
                            grv.OptionsNavigation.EnterMoveNextColumn = true;

                        }

                        col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        col.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                        col.AppearanceHeader.Options.UseTextOptions = true;
                        col.Caption = GetNN(dtNN, col.FieldName, fName);
                    }
                }
            }
            catch { }
        }
        public void MLoadNNGrid(DataTable dtNN, DevExpress.XtraGrid.Views.Grid.GridView grv, string fName, bool mSaveGrid)
        {
            try
            {
                grv.OptionsView.RowAutoHeight = true;
                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grv.Columns)
                {
                    if (col.Visible)
                    {
                        //if (col.ColumnType.ToString() == "System.String")
                        //    col.ColumnEdit = repoMemo;

                        if (!grv.OptionsBehavior.Editable)
                        {
                            col.OptionsColumn.AllowFocus = false;
                        }
                        else
                        {
                            col.OptionsColumn.AllowFocus = true;
                            grv.OptionsNavigation.EnterMoveNextColumn = true;

                        }

                        col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        col.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                        col.AppearanceHeader.Options.UseTextOptions = true;
                        col.Caption = GetNN(dtNN, col.FieldName, fName);
                    }
                }
            }
            catch { }

            try
            {
                if(mSaveGrid) MSaveResertGrid(grv, fName);
            }
            catch { }
        }
        public void MLoadNNXtraGrid(DevExpress.XtraGrid.Views.Grid.GridView grv, string fName)
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Mod.CNStr, CommandType.Text, "SELECT KEYWORD , CASE " + Mod.iNNgu + " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'" + fName + "' "));


                grv.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
                grv.OptionsView.RowAutoHeight = true;
                grv.Appearance.HeaderPanel.Options.UseTextOptions = true;
                grv.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                grv.OptionsView.AllowHtmlDrawHeaders = true;
                grv.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                grv.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                
                grv.AppearancePrint.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                grv.AppearancePrint.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                grv.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;

                for (int i = 0; i < grv.VisibleColumns.Count; i++)
                {
                    try
                      {
                        if (!grv.OptionsBehavior.Editable)
                        {
                            grv.Columns[grv.GetVisibleColumn(i).FieldName.ToString()].OptionsColumn.AllowFocus = false;
                        }
                        else
                        {
                            grv.Columns[grv.GetVisibleColumn(i).FieldName.ToString()].OptionsColumn.AllowFocus = true;
                        }
                    }
                    catch { }
                    grv.Columns[grv.GetVisibleColumn(i).FieldName.ToString()].Caption = GetNN(dtTmp, grv.GetVisibleColumn(i).FieldName.ToString(), fName);
                }
                grv.OptionsView.RowAutoHeight = true;
                grv.OptionsNavigation.EnterMoveNextColumn = true;
            }
            catch 
            { }
        }
        public void MLoadNNXtraGrid(DevExpress.XtraGrid.Views.Grid.GridView grv, string fName, Boolean mSaveGrid)
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Mod.CNStr, CommandType.Text, "SELECT KEYWORD , CASE " + Mod.iNNgu + " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'" + fName + "' "));
                for (int i = 0; i < grv.VisibleColumns.Count; i++)
                {
                    if (!grv.OptionsBehavior.Editable)
                    {
                        grv.Columns[grv.GetVisibleColumn(i).FieldName.ToString()].OptionsColumn.AllowFocus = false;
                    }
                    else
                    {
                        grv.Columns[grv.GetVisibleColumn(i).FieldName.ToString()].OptionsColumn.AllowFocus = true;
                    }

                    grv.Columns[grv.GetVisibleColumn(i).FieldName.ToString()].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    grv.Columns[grv.GetVisibleColumn(i).FieldName.ToString()].AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    grv.Columns[grv.GetVisibleColumn(i).FieldName.ToString()].AppearanceHeader.Options.UseTextOptions = true;
                    grv.Columns[grv.GetVisibleColumn(i).FieldName.ToString()].Caption = GetNN(dtTmp, grv.GetVisibleColumn(i).FieldName.ToString(), fName);

                }
                grv.OptionsView.RowAutoHeight = true;
                grv.OptionsNavigation.EnterMoveNextColumn = true;
            }
            catch { }

            if (mSaveGrid)
                Com.Mod.OS.MSaveResertGrid(grv, fName);
        }
        public void MLoadNNXtraGrid(DevExpress.XtraGrid.Views.Grid.GridView grv, string fName, int dSo)
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Mod.CNStr, CommandType.Text, "SELECT KEYWORD , CASE " + Mod.iNNgu + " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'" + fName + "' "));
                grv.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
                grv.OptionsView.RowAutoHeight = true;
                grv.Appearance.HeaderPanel.Options.UseTextOptions = true;
                grv.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                grv.OptionsView.AllowHtmlDrawHeaders = true;
                grv.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                grv.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                grv.AppearancePrint.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                grv.AppearancePrint.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                grv.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;

                for (int i = 0; i < dSo; i++)
                {
                    try
                    {
                        if (!grv.OptionsBehavior.Editable)
                        {
                            grv.Columns[grv.GetVisibleColumn(i).FieldName.ToString()].OptionsColumn.AllowFocus = false;
                        }
                        else
                        {
                            grv.Columns[grv.GetVisibleColumn(i).FieldName.ToString()].OptionsColumn.AllowFocus = true;
                        }
                    }
                    catch { }
                    grv.Columns[grv.GetVisibleColumn(i).FieldName.ToString()].Caption = GetNN(dtTmp, grv.GetVisibleColumn(i).FieldName.ToString(), fName);
                }
                grv.OptionsView.RowAutoHeight = true;
                grv.OptionsNavigation.EnterMoveNextColumn = true;



            }
            catch
            { }
        }
        public void MLoadNNXtraTreeList(DevExpress.XtraTreeList.TreeList lst, string fName)
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Mod.CNStr, CommandType.Text, "SELECT KEYWORD , CASE " + Mod.iNNgu + " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'" + fName + "' "));

                //foreach (DevExpress.XtraGrid.Columns.GridColumn col in grv.Columns)
                for (int i = 0; i < lst.VisibleColumns.Count; i++)
                {
                    if (!lst.OptionsBehavior.Editable)
                    {
                        lst.Columns[lst.GetColumnByVisibleIndex(i).FieldName.ToString()].OptionsColumn.AllowFocus = false;
                    }
                    else
                    {
                        lst.Columns[lst.GetColumnByVisibleIndex(i).FieldName.ToString()].OptionsColumn.AllowFocus = true;
                    }
                    lst.Columns[lst.GetColumnByVisibleIndex(i).FieldName.ToString()].Caption = GetNN(dtTmp, lst.GetColumnByVisibleIndex(i).FieldName.ToString(), fName);
                }
                lst.OptionsView.BestFitNodes = TreeListBestFitNodes.Display;


                lst.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                lst.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                lst.Appearance.HeaderPanel.Options.UseTextOptions = true;
            }
            catch { }
        }
        public void ClearValidationProvider(DXValidationProvider validationProvider)
        {
            FieldInfo fi = typeof(DXValidationProvider).GetField("errorProvider", BindingFlags.NonPublic | BindingFlags.Instance);
            DXErrorProvider errorProvier = fi.GetValue(validationProvider) as DXErrorProvider;
            foreach (Control c in validationProvider.GetInvalidControls())
            {
                errorProvier.SetError(c, null);
            }
        }
        #endregion

        #region Load hình database
        public byte[] SaveHinh(Image inImg)
        {
            ImageConverter imgCon = new ImageConverter();
            return (byte[])imgCon.ConvertTo(inImg, typeof(byte[]));
        }
        public Image LoadHinh(Byte[] hinh)
        {
            Byte[] data = new Byte[0];
            data = (Byte[])(hinh);
            MemoryStream mem = new MemoryStream(data);
            return Image.FromStream(mem);
        }

        #endregion

        #region thay doi nn
        public DataTable MLoadTableNN(XtraForm frm, int loaingonngu = -99)
        {
            DataTable dtNN = new DataTable();
            try
            {
                if (loaingonngu == -99)
                    loaingonngu = Com.Mod.iNNgu;

                dtNN.Load(SqlHelper.ExecuteReader(Com.Mod.CNStr, CommandType.Text, "SELECT KEYWORD , CASE " + loaingonngu + " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'frmChung' OR FORM = N'" + frm.Name + "' "));
            }
            catch { }
            return dtNN;
        }

        public void ThayDoiNN(XtraForm frm)
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Mod.CNStr, CommandType.Text, "SELECT KEYWORD , CASE " + Mod.iNNgu + " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'" + frm.Name + "' "));
            frm.Text = GetNN(dtTmp, frm.Name, frm.Name);
            List<Control> resultControlList = new List<Control>();
            GetControlsCollection(frm, ref resultControlList, null);
            foreach (Control control1 in resultControlList)
            {
                try
                {
                    DoiNN(control1, frm.Name, dtTmp);
                }
                catch
                { }
            }
            if (Com.Mod.UName.ToLower() == "minh.tc" || Com.Mod.UName.ToLower() == "h.tc" || Com.Mod.UName.ToLower() == "admin" || Com.Mod.UName.ToLower() == "it" || Com.Mod.UName.ToLower() == "erpsupport" || Com.Mod.UName.ToLower() == "administrator")
            {
                frm.KeyPreview = true;
                frm.KeyDown += new System.Windows.Forms.KeyEventHandler(frm_KeyDown);
            }


        }
        
        public void ThayDoiNN(XtraForm frm, LayoutControlGroup group)
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Mod.CNStr, CommandType.Text, "SELECT KEYWORD , CASE " + Mod.iNNgu + " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'" + frm.Name + "' "));
            frm.Text = GetNN(dtTmp, frm.Name, frm.Name);
            List<Control> resultControlList = new List<Control>();
            GetControlsCollection(frm, ref resultControlList, null);
            foreach (Control control1 in resultControlList)
            {
                try
                {
                    DoiNN(control1, frm.Name, dtTmp);
                }
                catch
                { }
            }
            LoadNNGroupControl(frm, group, dtTmp);
            if (Com.Mod.UName.ToLower() == "minh.tc" || Com.Mod.UName.ToLower() == "h.tc" || Com.Mod.UName.ToLower() == "admin")
            {
                frm.KeyPreview = true;
                frm.KeyDown += new System.Windows.Forms.KeyEventHandler(frm_KeyDown);
            }
        }

        public void ThayDoiNN(XtraReport report)
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Mod.CNStr, CommandType.Text, "SELECT KEYWORD , CASE " + Mod.iNNgu + " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'" + report.Tag.ToString() + "' "));

            foreach (DevExpress.XtraReports.UI.Band band in report.Bands)
            {
                foreach (DevExpress.XtraReports.UI.SubBand subband in band.SubBands)
                {
                    foreach (DevExpress.XtraReports.UI.XRControl control in subband)
                    {
                        if (control.GetType() == typeof(DevExpress.XtraReports.UI.XRTable))
                        {
                            DevExpress.XtraReports.UI.XRTable table = (DevExpress.XtraReports.UI.XRTable)control;
                            foreach (DevExpress.XtraReports.UI.XRTableRow row in table)
                            {
                                foreach (DevExpress.XtraReports.UI.XRTableCell cell in row)
                                {
                                    try
                                    {
                                        if (cell.Name.Substring(0, 3).ToString() == "tiN" || cell.Name.Substring(0, 2).ToString().ToLower() == "xr") break;
                                        cell.Text = GetNN(dtTmp, cell.Name, report.Tag.ToString());// translation processing here
                                        //cell.Font.Name = vs
                                        MSetFontCellReport(cell);
                                    }
                                    catch
                                    {
                                        MessageBox.Show("err language substring");
                                    }


                                }
                            }
                        }
                        else
                        {
                            if (control.Name.Substring(0, 2).ToString().ToLower() != "xr")
                            {
                                control.Text = GetNN(dtTmp, control.Name, report.Tag.ToString());
                                MSetFontControlReport(control);
                            }
                        }
                    }
                }
                foreach (DevExpress.XtraReports.UI.XRControl control in band)
                {
                    if (control.GetType() == typeof(DevExpress.XtraReports.UI.XRTable))
                    {
                        DevExpress.XtraReports.UI.XRTable table = (DevExpress.XtraReports.UI.XRTable)control;
                        foreach (DevExpress.XtraReports.UI.XRTableRow row in table)
                        {
                            foreach (DevExpress.XtraReports.UI.XRTableCell cell in row)
                            {
                                try
                                {

                                    if (cell.Name.Substring(0, 3).ToString() == "tiN" || cell.Name.Substring(0, 2).ToString() == "xr") break;
                                    cell.Text = GetNN(dtTmp, cell.Name, report.Tag.ToString());// translation processing here
                                    MSetFontCellReport(cell);
                                }
                                catch
                                {
                                    MessageBox.Show("err language substring");
                                }

                            }
                        }
                    }
                    else
                    {
                        if (control.Name.Substring(0, 2).ToString().ToLower() != "xr")
                        {
                            control.Text = GetNN(dtTmp, control.Name, report.Tag.ToString());
                            MSetFontControlReport(control);

                        }
                    }

                }

            }
        }
        private void MSetFontCellReport(DevExpress.XtraReports.UI.XRTableCell cell)
        {
            try
            {
                System.Drawing.Font fCellNew = new System.Drawing.Font(Com.Mod.sFontSys, cell.Font.Size);
                //cell.Font = new System.Drawing.Font(fCellNew, cell.Font.Style);

            }
            catch { }
        }

        private void MSetFontControlReport(DevExpress.XtraReports.UI.XRControl control)
        {
            try
            {
                System.Drawing.Font fControlNew = new System.Drawing.Font(Com.Mod.sFontSys, control.Font.Size);
                //control.Font = new System.Drawing.Font(fControlNew, control.Font.Style);
            }
            catch { }
        }

        private void LoadNNGroupControl(XtraForm frm, LayoutControlGroup group, DataTable dtTmp)
        {
            foreach (var gr in group.Items)
            {
                if (gr.GetType().Name == "LayoutControlGroup")
                {

                    LayoutControlGroup gro = (LayoutControlGroup)gr;
                    gro.Text = GetNN(dtTmp, gro.Name, frm.Name);
                    LoadNNGroupControl(frm, (LayoutControlGroup)gr, dtTmp);
                }
                else
                {
                    try
                    {
                        LayoutControlItem control1 = (LayoutControlItem)gr;

                        if (!control1.TextVisible) continue;
                        if (control1.Text.Length > 17 && control1.Text.Substring(0, 17).ToUpper() == "layoutControlItem".ToUpper()) continue;
                        if (control1.TypeName.ToUpper() == "EmptySpaceItem".ToUpper()) continue;
                        if (control1.TypeName.ToUpper() == "TabbedGroup".ToUpper()) continue;
                        if (control1.TypeName.ToUpper() == "SimpleLabelItem".ToUpper())
                        {
                            if (control1.Name.Length < 5) continue;
                            control1.Text = GetNN(dtTmp, control1.Name, frm.Name);
                            continue;
                        }



                        try
                        {
                            if (control1.Control.GetType().Name.ToLower() == "checkedit")
                            {
                                control1.Control.Text = GetNN(dtTmp, control1.Name, frm.Name);
                            }
                            else
                            if (control1.Control.GetType().Name.ToLower() == "radiogroup")
                            {
                                DoiNN(control1.Control, frm.Name, dtTmp);
                            }

                            else
                            {
                                control1.Text = GetNN(dtTmp, control1.Name, frm.Name);
                            }
                            ((DevExpress.XtraEditors.BaseEdit)control1.Control).EnterMoveNextControl = true;
                        }
                        catch
                        { }
                    }
                    catch (Exception)
                    {
                    }
                }

            }
        }
        
        private void LoadNNGroupControl(XtraUserControl frm, LayoutControlGroup group, DataTable dtTmp)
        {
            //TabbedControlGroup
            foreach (var gr in group.Items)
            {
                if (gr.GetType().Name == "LayoutControlGroup")
                {
                    LayoutControlGroup gro = (LayoutControlGroup)gr;
                    gro.Text = GetNN(dtTmp, gro.Name, frm.Name);
                    LoadNNGroupControl(frm, (LayoutControlGroup)gr, dtTmp);
                }
                else
                {
                    try
                    {
                        LayoutControlItem control1 = (LayoutControlItem)gr;
                        try
                        {
                            if (control1.Control.GetType().Name.ToLower() == "checkedit")
                            {
                                control1.Control.Text = GetNN(dtTmp, control1.Name, frm.Name);
                            }
                            else
                            if (control1.Control.GetType().Name.ToLower() == "radiogroup")
                            {
                                DoiNN(control1.Control, frm.Name, dtTmp);
                            }

                            else
                            {
                                control1.Text = GetNN(dtTmp, control1.Name, frm.Name);
                            }
                            ((DevExpress.XtraEditors.BaseEdit)control1.Control).EnterMoveNextControl = true;
                        }
                        catch
                        { }
                    }
                    catch (Exception)
                    {
                    }
                }

            }
        }
        
        private void LoadNNGroupControl(LayoutControlGroup group, DataTable dtTmp, string name)
        {
            group.Text = GetNN(dtTmp, group.Name, name);
            foreach (var gr in group.Items)
            {
                if (gr.GetType().Name == "LayoutControlGroup")
                    LoadNNGroupControl((LayoutControlGroup)gr, dtTmp, name);
                else
                {
                    try
                    {
                        LayoutControlItem control1 = (LayoutControlItem)gr;
                        control1.Text = GetNN(dtTmp, control1.Name, name);
                        ((DevExpress.XtraEditors.BaseEdit)control1.Control).EnterMoveNextControl = true;

                    }
                    catch (Exception)
                    {
                    }
                }

            }
        }
        

        public void frm_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F2 && e.Modifiers == (Keys.Control | Keys.Alt))
            {
                try
                {
                    FormCollection formCollection = Application.OpenForms;
                    string sform = @"N@@frmChung@@ ";
                    sform = @"N@@" + ((System.Windows.Forms.Control)sender).Name.ToString() + "@@ ";
                    frmNgonNgu frm = new frmNgonNgu(sform);
                    frm.WindowState = FormWindowState.Maximized;
                    frm.ShowDialog();

                }
                catch { }
            }
        }


        public void frm_KeyDown(object sender, KeyEventArgs e, string sForm)
        {

            if (e.KeyCode == Keys.F2 && e.Modifiers == (Keys.Control | Keys.Alt))
            {
                try
                {
                    FormCollection formCollection = Application.OpenForms;
                    //sForm = @"N@@frmChung@@ ";
                    sForm = @"N@@" + sForm + "@@ ";
                    

                    frmNgonNgu frm = new frmNgonNgu(sForm);
                    frm.WindowState = FormWindowState.Maximized;
                    frm.ShowDialog();

                }
                catch { }
            }
        }


        public void MLoadNN(DataTable dtNN, XtraForm frm, IEnumerable<Control> datalayout1)
        {
            frm.Text = GetNN(dtNN, frm.Name, frm.Name);

            foreach (DataLayoutControl dtlayout in datalayout1)
            {

                dtlayout.AllowCustomization = false;

                if (Com.Mod.UName.ToLower() == "minh.tc" || Com.Mod.UName.ToLower() == "h.tc" || Com.Mod.UName.ToLower() == "admin" || Com.Mod.UName.ToLower() == "it" || Com.Mod.UName.ToLower() == "erpsupport" || Com.Mod.UName.ToLower() == "administrator")
                {
                    frm.KeyPreview = true;
                    try { frm.KeyDown -= new System.Windows.Forms.KeyEventHandler(frm_KeyDown); }
                    catch { }
                    try { frm.KeyDown += new System.Windows.Forms.KeyEventHandler(frm_KeyDown); }
                    catch { }
                }

                foreach (var ctrl in dtlayout.Items.ConvertToTypedList())
                {
                    //if (!ctrl.TextVisible) continue;
                    if (ctrl.Text.ToUpper() == "ROOT".ToUpper()) continue;
                    if (ctrl.TypeName.ToUpper() == "EmptySpaceItem".ToUpper()) continue;
                    if (ctrl.TypeName.ToUpper() == "TabbedGroup".ToUpper()) continue;
                    if (ctrl.Text.Length > 17 && ctrl.Text.Substring(0, 17).ToUpper() == "layoutControlItem".ToUpper()) continue;

                    if (Com.Mod.GroupID == 1 || Com.Mod.GroupID == 13)
                    {
                        try { ctrl.DoubleClick += delegate (object c, EventArgs b) { ControlGroup_DoubleClick(c, b, frm.Name); }; } catch { }
                    }

                    try
                    {

                        if (ctrl is LayoutControlItem)
                        {
                            var a = (LayoutControlItem)ctrl;
                            string sType = "-1";
                            try
                            {
                                sType = a.Control.GetType().Name.ToLower();
                            }
                            catch { sType = "-1"; }

                            if (sType != "-1")
                            {
                                if (sType == "simplebutton" || sType == "checkedit")
                                    a.Control.Text = GetNN(dtNN, a.Control.Name, frm.Name);
                                else
                                    ctrl.Text = GetNN(dtNN, ctrl.Name, frm.Name);
                            }
                            else
                                ctrl.Text = GetNN(dtNN, ctrl.Name, frm.Name);


                        }
                        else
                            ctrl.Text = GetNN(dtNN, ctrl.Name, frm.Name);
                    }
                    catch
                    { }

                }

            }



            List<string> lstControl = new List<string>(new string[] { "LabelControl", "SimpleButton", "CheckEdit", "RadioGroup", "XtraTabPage" });
            List<Control> resultControlList = new List<Control>();
            GetControlsLabel(frm, ref resultControlList, lstControl, null);


            foreach (Control ctrl in resultControlList)
            {
                try
                {
                    DoiNN(ctrl, frm.Name, dtNN);
                }
                catch
                { }
            }
        }
        
        public void MLoadNN(DataTable dtNN, XtraForm frm, DataLayoutControl datalayout)
        {

            frm.Text = GetNN(dtNN, frm.Name, frm.Name);
            datalayout.AllowCustomization = false;

            if (Com.Mod.UName.ToLower() == "minh.tc" || Com.Mod.UName.ToLower() == "h.tc" || Com.Mod.UName.ToLower() == "admin")
            {
                frm.KeyPreview = true;

                try { frm.KeyDown -= new System.Windows.Forms.KeyEventHandler(frm_KeyDown); }
                catch { }

                try { frm.KeyDown += new System.Windows.Forms.KeyEventHandler(frm_KeyDown); }
                catch { }
            }

            foreach (var ctrl in datalayout.Items.ConvertToTypedList())
            {
                if (!ctrl.TextVisible) continue;
                if (ctrl.Text.Length > 17 && ctrl.Text.Substring(0, 17).ToUpper() == "layoutControlItem".ToUpper()) continue;
                if (ctrl.Text.ToUpper() == "ROOT".ToUpper()) continue;
                if (ctrl.TypeName.ToUpper() == "EmptySpaceItem".ToUpper()) continue;
                if (ctrl.TypeName.ToUpper() == "TabbedGroup".ToUpper()) continue;
                if (ctrl.TypeName.ToUpper() == "SimpleLabelItem".ToUpper())
                {
                    if (ctrl.Name.Length < 5) continue;
                    ctrl.Text = GetNN(dtNN, ctrl.Name, frm.Name);
                    continue;
                }


                try
                {

                    if (ctrl is LayoutControlItem)
                    {
                        var a = (LayoutControlItem)ctrl;
                        string sType = "-1";
                        try
                        {
                            sType = a.Control.GetType().Name.ToLower();
                        }
                        catch { sType = "-1"; }

                        if (sType != "-1")
                        {
                            if (sType == "simplebutton" || sType == "checkedit")
                                a.Control.Text = GetNN(dtNN, a.Control.Name, frm.Name);
                            else
                                ctrl.Text = GetNN(dtNN, ctrl.Name, frm.Name);
                        }
                        else
                            ctrl.Text = GetNN(dtNN, ctrl.Name, frm.Name);


                    }
                    else
                        ctrl.Text = GetNN(dtNN, ctrl.Name, frm.Name);
                }
                catch
                { }

            }


            //List<string> lstControl = new List<string>(new string[] { "LabelControl", "RadioGroup" });
            List<string> lstControl = new List<string>(new string[] { "LabelControl", "SimpleButton", "CheckEdit", "RadioGroup" });

            List<Control> resultControlList = new List<Control>();
            GetControlsLabel(frm, ref resultControlList, lstControl, null);

            foreach (Control ctrl in resultControlList)
            {
                try
                {
                    DoiNN(ctrl, frm.Name, dtNN);
                }
                catch
                { }
            }
        }
        public void ThayDoiNN(XtraForm frm, DataLayoutControl datalayout)
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Mod.CNStr, CommandType.Text, "SELECT KEYWORD , CASE " + Mod.iNNgu + " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'" + frm.Name + "' "));
            frm.Text = GetNN(dtTmp, frm.Name, frm.Name);
            datalayout.AllowCustomization = false;

            if (Com.Mod.UName.ToLower() == "minh.tc" || Com.Mod.UName.ToLower() == "h.tc" || Com.Mod.UName.ToLower() == "admin")
            {
                frm.KeyPreview = true;

                try { frm.KeyDown -= new System.Windows.Forms.KeyEventHandler(frm_KeyDown); }
                catch { }

                try { frm.KeyDown += new System.Windows.Forms.KeyEventHandler(frm_KeyDown); }
                catch { }
            }

            //foreach (var ctrl in datalayout.Items.ConvertToTypedList()) foreach (Control ctrl in resultControlList)
            foreach (var ctrl in datalayout.Items.ConvertToTypedList())
            {
                if (ctrl.TypeName.ToUpper() == "TabbedGroup".ToUpper())
                {
                    var a = (TabbedGroup)ctrl;
                    a.SelectedTabPageIndex = 0;
                }
                if (!ctrl.TextVisible) continue;
                if (ctrl.Text.Length > 17 && ctrl.Text.Substring(0, 17).ToUpper() == "layoutControlItem".ToUpper()) continue;
                if (ctrl.Text.ToUpper() == "ROOT".ToUpper()) continue;
                if (ctrl.TypeName.ToUpper() == "EmptySpaceItem".ToUpper()) continue;


                
                if (ctrl.Name.ToUpper() == "tabbedControlGroup1".ToUpper())
                {
                    ctrl.Text = GetNN(dtTmp, ctrl.Name, frm.Name);
                }

                if (ctrl.TypeName.ToUpper() == "SimpleLabelItem".ToUpper())
                {
                    if (ctrl.Name.Length < 5) continue;
                    ctrl.Text = GetNN(dtTmp, ctrl.Name, frm.Name);

                    continue;
                }
                if (Com.Mod.GroupID == 1 || Com.Mod.GroupID == 13)
                {
                    try { ctrl.DoubleClick += delegate (object c, EventArgs b) { ControlGroup_DoubleClick(c, b, frm.Name); }; } catch { }
                }

                if (ctrl.Name.ToString() == "DevExpress.XtraLayout.SimpleLabelItem")
                {
                    var a = (LayoutControlItem)ctrl;
                }

                try
                {

                    if (ctrl is LayoutControlItem)
                    {
                        var a = (LayoutControlItem)ctrl;
                        string sType = "-1";

                        try
                        {
                            sType = a.Control.GetType().Name.ToLower();
                        }
                        catch { sType = "-1"; }

                        if (sType != "-1")
                        {
                            if (sType == "simplebutton" || sType == "checkedit")
                                a.Control.Text = GetNN(dtTmp, a.Control.Name, frm.Name);
                            else
                                ctrl.Text = GetNN(dtTmp, ctrl.Name, frm.Name);
                        }
                        else
                            ctrl.Text = GetNN(dtTmp, ctrl.Name, frm.Name);
                    }
                    else
                        ctrl.Text = GetNN(dtTmp, ctrl.Name, frm.Name);
                }
                catch
                { }

            }


            //List<string> lstControl = new List<string>(new string[] { "LabelControl", "RadioGroup" });
            List<string> lstControl = new List<string>(new string[] { "LabelControl", "SimpleButton", "CheckEdit", "RadioGroup" });

            List<Control> resultControlList = new List<Control>();
            GetControlsLabel(frm, ref resultControlList, lstControl, null);





            foreach (Control ctrl in resultControlList)
            {
                try
                {
                    DoiNN(ctrl, frm.Name, dtTmp);
                }
                catch
                { }
            }
        }

        private void ControlGroup_DoubleClick(object sender, EventArgs e, string sName)
        {
            try
            {
                if (Form.ModifierKeys == Keys.Control)
                {
                    LayoutControlItem Ctl;
                    string sText = "";
                    Ctl = (LayoutControlItem)sender;
                    try
                    {
                        sText = XtraInputBox.Show(Ctl.Text, "Sửa ngôn ngữ", "");
                        if (string.IsNullOrWhiteSpace(sText) )
                            return;
                        else
                            CapNhapNN(sName, Ctl.Name.ToUpper().Replace("ItemFor".ToUpper(), ""), sText, false);

                        sText = " SELECT TOP 1 " + (Com.Mod.iNNgu == 0 ? "VIETNAM" : "ENGLISH") + " FROM LANGUAGES WHERE FORM = '" + sName + "' AND KEYWORD = '" + Ctl.Name.ToUpper().Replace("ItemFor".ToUpper(), "") + "' " ;
                        sText = Convert.ToString(SqlHelper.ExecuteScalar(Com.Mod.CNStr, CommandType.Text, sText));

                        Ctl.Text = sText;
                    }
                    catch
                    {
                        sText = "";
                    }
                }
            }
            catch { }
        }

        public void ThayDoiNN(XtraForm frm, IEnumerable<Control> datalayout1)
        {

            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Mod.CNStr, CommandType.Text, "SELECT KEYWORD , CASE " + Mod.iNNgu + " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'" + frm.Name + "' "));
            frm.Text = GetNN(dtTmp, frm.Name, frm.Name);

            foreach (DataLayoutControl dtlayout in datalayout1)
            {

                dtlayout.AllowCustomization = false;

                if (Com.Mod.UName.ToLower() == "minh.tc" || Com.Mod.UName.ToLower() == "h.tc" || Com.Mod.UName.ToLower() == "admin")
                {
                    frm.KeyPreview = true;

                    try { frm.KeyDown -= new System.Windows.Forms.KeyEventHandler(frm_KeyDown); }
                    catch { }

                    try { frm.KeyDown += new System.Windows.Forms.KeyEventHandler(frm_KeyDown); }
                    catch { }
                }

                foreach (var ctrl in dtlayout.Items.ConvertToTypedList())
                {
                    //if (!ctrl.TextVisible) continue;
                    if (ctrl.Text.ToUpper() == "ROOT".ToUpper()) continue;
                    if (ctrl.Text.Length > 17 && ctrl.Text.Substring(0, 17).ToUpper() == "layoutControlItem".ToUpper()) continue;
                    if (ctrl.Name.ToString() == "DevExpress.XtraLayout.LayoutControlItem")
                    {
                        //var a = (LayoutControlItem)ctrl;
                    }

                    if (ctrl.TypeName.ToUpper() == "EmptySpaceItem".ToUpper()) continue;
                    if (ctrl.TypeName.ToUpper() == "TabbedGroup".ToUpper()) continue;
                    try
                    {

                        if (ctrl is LayoutControlItem)
                        {
                            var a = (LayoutControlItem)ctrl;
                            string sType = "-1";
                            try
                            {
                                sType = a.Control.GetType().Name.ToLower();
                            }
                            catch { sType = "-1"; }

                            if (sType != "-1")
                            {
                                if (sType == "simplebutton" || sType == "checkedit")
                                    a.Control.Text = GetNN(dtTmp, a.Control.Name, frm.Name);
                                else
                                    ctrl.Text = GetNN(dtTmp, ctrl.Name, frm.Name);
                            }
                            else
                                ctrl.Text = GetNN(dtTmp, ctrl.Name, frm.Name);


                        }
                        else
                            ctrl.Text = GetNN(dtTmp, ctrl.Name, frm.Name);
                    }
                    catch
                    { }

                }

            }


            List<string> lstControl = new List<string>(new string[] { "LabelControl", "SimpleButton", "CheckEdit", "RadioGroup", "XtraTabPage" });
            List<Control> resultControlList = new List<Control>();
            GetControlsLabel(frm, ref resultControlList, lstControl, null);





            foreach (Control ctrl in resultControlList)
            {
                try
                {
                    DoiNN(ctrl, frm.Name, dtTmp);
                }
                catch
                { }
            }
        }
        
        public void DoiNN(Control Ctl, string frmName, DataTable dtNgu)
        {
            if (Ctl.Name.Length < 5) return;
            // iFontsize
            // sFontForm
            if (Com.Mod.GroupID == 1 || Com.Mod.GroupID == 13)
            {
                try { Ctl.MouseDoubleClick -= this.Label_MouseDoubleClick; } catch { }
                try { Ctl.MouseDoubleClick += this.Label_MouseDoubleClick; } catch { }
                try { Ctl.DoubleClick += delegate (object c, EventArgs b) { ControlGroup_DoubleClick(c, b, frmName); }; } catch { }
            }

            try
            {
                switch (Ctl.GetType().Name.ToString())
                {
                    case "LookUpEdit":
                        {
                            DevExpress.XtraEditors.LookUpEdit CtlDev;
                            CtlDev = (DevExpress.XtraEditors.LookUpEdit)Ctl;
                            CtlDev.Properties.NullText = "";
                            break;
                        }
                    case "Label":
                    case "RadioButton":
                    case "CheckBox":
                        {

                            Ctl.Text = GetNN(dtNgu, Ctl.Name, frmName);

                            if (Ctl.GetType().Name.ToString() == "RadioButton")
                            {
                                try
                                {
                                    //Ctl.MouseDoubleClick -= this.RadioButton_MouseDoubleClick;
                                }
                                catch
                                {
                                }
                                try
                                {
                                    //Ctl.MouseDoubleClick += this.RadioButton_MouseDoubleClick;
                                }
                                catch
                                {
                                }
                            }

                            if (Ctl.GetType().Name.ToString() == "CheckBox")
                            {
                                try
                                {
                                    //Ctl.MouseDoubleClick -= this.CheckBox_MouseDoubleClick;
                                }
                                catch
                                {
                                }
                                try
                                {
                                    //Ctl.MouseDoubleClick += this.CheckBox_MouseDoubleClick;
                                }
                                catch
                                {
                                }
                            }

                            break;
                        }

                    //case "GroupBox":
                    //    {
                    //        Ctl.Text = GetNN(dtNgu, Ctl.Name, frm.Name);
                    //        if ((Ctl.Name == "grbList"))
                    //        {
                    //            DataTable dtItem = new DataTable();
                    //            try
                    //            {
                    //                dtItem.Load(SqlHelper.ExecuteReader(Mod.CNStr, "Get_lstDanhsachbaocao", Com.Mod.UserName, -1, Com.Mod.TypeLanguage, 1));
                    //            }
                    //            catch (Exception ex)
                    //            {
                    //            }
                    //            foreach (Control ctl1 in Ctl.Controls)
                    //            {
                    //                if ((ctl1.GetType().Name.ToLower() == "navbarcontrol"))
                    //                {
                    //                    foreach (NavBarGroup cl in (NavBarControl)ctl1.Groups)
                    //                        cl.Caption = GetNN(dtNgu, cl.Name, frm.Name);
                    //                    foreach (NavBarItem cl in (NavBarControl)ctl1.Items)
                    //                    {
                    //                        try
                    //                        {
                    //                            cl.Caption = dtItem.Select().Where(x => x("REPORT_NAME").ToString().Trim() == cl.Name.Trim()).Take(1).Single()("TEN_REPORT");
                    //                        }
                    //                        catch (Exception ex)
                    //                        {
                    //                            cl.Caption = GetNN(dtNgu, cl.Name, frm.Name);
                    //                        }
                    //                    }
                    //                    break;
                    //                }
                    //            }
                    //        }

                    //        break;
                    //    }

                    case "TabPage":
                        {
                            Ctl.Text = GetNN(dtNgu, Ctl.Name, frmName);          // Modules.ObjLanguages.GetLanguage(Modules.ModuleName, frm.Name, Ctl.Name, Modules.TypeLanguage)
                            break;
                        }

                    case "LabelControl":
                    case "CheckButton":
                    case "CheckEdit":
                    case "XtraTabPage":
                    case "GroupControl":
                        {
                            if (Ctl.Name.ToUpper().Substring(0, 4) != "NONN" & Ctl.Name.Length > 4)
                                Ctl.Text = GetNN(dtNgu, Ctl.Name, frmName);
                            break;
                        }

                    case "Button":
                        {
                            if (Ctl.Name.ToUpper().Substring(0, 4) != "NONN" & Ctl.Name.Length > 4)
                            {
                                Ctl.Text = GetNN(dtNgu, Ctl.Name, frmName);
                            }

                            break;
                        }

                    case "SimpleButton":
                        {
                            DevExpress.XtraEditors.SimpleButton CtlDev;
                            CtlDev = (DevExpress.XtraEditors.SimpleButton)Ctl;
                            if (Ctl.Name.Length > 4)
                            {
                                Ctl.Text = GetNN(dtNgu, Ctl.Name, frmName);
                            }

                            break;
                        }
                    case "RadioGroup":
                        {
                            DevExpress.XtraEditors.RadioGroup radGroup;
                            radGroup = (DevExpress.XtraEditors.RadioGroup)Ctl;
                            for (int i = 0; i <= radGroup.Properties.Items.Count - 1; i++)
                            {

                                radGroup.Properties.Items[i].Description = GetNN(dtNgu, radGroup.Properties.Items[i].AccessibleName.ToString(), frmName);
                            }
                            try
                            {
                                if (radGroup.SelectedIndex == -1)
                                    radGroup.SelectedIndex = 0;
                            }
                            catch
                            {
                            }

                            break;
                        }

                    case "CheckedListBoxControl":
                        {
                            DevExpress.XtraEditors.CheckedListBoxControl chkGroup;
                            chkGroup = (DevExpress.XtraEditors.CheckedListBoxControl)Ctl;

                            for (int i = 0; i <= chkGroup.Items.Count - 1; i++)
                                chkGroup.Items[i].Description = GetNN(dtNgu, chkGroup.Items[i].Description, frmName);
                            break;
                        }

                    case "XtraTabControl":
                        {
                            DevExpress.XtraTab.XtraTabControl tabControl;
                            tabControl = (DevExpress.XtraTab.XtraTabControl)Ctl;
                            tabControl.SelectedTabPageIndex = 0;

                            for (int i = 0; i <= tabControl.TabPages.Count - 1; i++)
                                tabControl.TabPages[i].Text = GetNN(dtNgu, tabControl.TabPages[i].Name, frmName);
                            break;
                        }
                }
            }
            catch
            {
            }
        }



        public Form GetParentForm(Control parent)
        {
            Form form = parent as Form;
            if (form != null)
                return form;
            if (parent != null)
                return GetParentForm(parent.Parent);
            return null/* TODO Change to default(_) if this is not a reference type */;
        }


        private void Label_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Form.ModifierKeys == Keys.Control & e.Button == MouseButtons.Left)
            {
                LabelControl Ctl;
                string sText = "";
                Ctl = (LabelControl)sender;
                try
                {
                    string sName = GetParentForm(Ctl).Name.ToString(); // DirectCast(Ctl.TopLevelControl, System.Windows.Forms.ContainerControl).ActiveControl.Name.ToString
                    if ("frmReports".ToUpper() == sName.ToUpper())
                    {
                        sName = Ctl.Parent.Parent.ToString().Substring(Ctl.Parent.Parent.ProductName.Length + 1);
                        sName = "SELECT TOP 1 REPORT_NAME FROM dbo.DS_REPORT WHERE NAMES = '" + sName + "' ";
                        try
                        {
                            sName = Convert.ToString(SqlHelper.ExecuteScalar(Mod.CNStr, CommandType.Text, sName));
                        }
                        catch
                        {
                            sName = GetParentForm(Ctl).Name.ToString();
                        }
                    }
                    if (sName.Trim().ToString() == "")
                        sName = GetParentForm(Ctl).Name.ToString();
                    sText = XtraInputBox.Show(Ctl.Text, "Sửa ngôn ngữ", "");
                    if (sText == "")
                        return;
                    else if (sText == "Windows.Forms.DialogResult.Retry")
                    {
                        sText = "";
                        CapNhapNN(sName, Ctl.Name, sText, true);
                    }
                    else
                        CapNhapNN(sName, Ctl.Name, sText, false);
                    sText = " SELECT TOP 1 " + (Com.Mod.iNNgu == 0 ? "VIETNAM" : "ENGLISH") + " FROM LANGUAGES WHERE FORM = '" + sName + "' AND KEYWORD = '" + Ctl.Name + "' AND MS_MODULE = 'ECOMAIN'";
                    sText = Convert.ToString(SqlHelper.ExecuteScalar(Mod.CNStr, CommandType.Text, sText));

                    Ctl.Text = sText;
                }
                catch
                {
                    sText = "";
                }
            }
        }
        private void CapNhapNN(string sForm, string sKeyWord, string sChuoi, bool bReset)
        {
            string sSql;
            if (bReset)
                sSql = "UPDATE LANGUAGES SET " + (Com.Mod.iNNgu == 0 ? "VIETNAM" : "ENGLISH") + " = " + (Com.Mod.iNNgu == 0 ? "VIETNAM_OR" : "ENGLISH_OR") + " WHERE FORM = '" + sForm + "' AND KEYWORD = '" + sKeyWord + "' ";
            else
                sSql = "UPDATE LANGUAGES SET " + (Com.Mod.iNNgu == 0 ? "VIETNAM" : "ENGLISH") + " = N'" + sChuoi + "' WHERE FORM = '" + sForm + "' AND KEYWORD = '" + sKeyWord + "' ";
            SqlHelper.ExecuteNonQuery(Mod.CNStr, CommandType.Text, sSql);
        }


        public string GetNN(DataTable dtNN, string sKeyWord, string sFormName)
        {
            string sNN = "";
            try
            {
                sNN = dtNN.AsEnumerable().Where(x => x["KEYWORD"].Equals(sKeyWord)).FirstOrDefault()[1].ToString().Replace("\\n", "\n");
            }
            catch
            {
                sNN = GetLanguage(sFormName, sKeyWord);
            }
            return sNN;
        }

        public string GetLanguage(string FormName, string Keyword)
        {
            string sStr;
            try
            {
                sStr = Convert.ToString(SqlHelper.ExecuteScalar(Mod.CNStr, "spGetNN", Mod.ModuleName, FormName, Keyword, Mod.iNNgu)).Replace("\\n", "\n");
            }
            catch
            {
                sStr = "?" + Keyword + "?";
            }
            return sStr;
        }

        public string GetLanguage(string FormName, string Keyword, int NNgu)
        {
            string sStr;
            try
            {
                sStr = Convert.ToString(SqlHelper.ExecuteScalar(Mod.CNStr, "spGetNN", Mod.ModuleName, FormName, Keyword, NNgu)).Replace("\\n", "\n");
            }
            catch
            {
                sStr = "?" + Keyword + "?";
            }
            return sStr;
        }

        public string GetNNGrv(DataTable dtNN, string sKeyWord, string sFormName,string sGrvName)
        {
            string sNN = "";
            try
            {
                sNN = dtNN.AsEnumerable().Where(x => x["KEYWORD"].Equals(sKeyWord)).FirstOrDefault()[1].ToString();
            }
            catch
            {
                sNN = GetLangGrv(sFormName, sKeyWord, sGrvName);
            }
            return sNN;
        }

        public string GetLangGrv(string FormName, string Keyword,  string sGrvName)
        {
            string sStr;
            try
            {
                sStr = Convert.ToString(SqlHelper.ExecuteScalar(Mod.CNStr, "spGetNNG", Mod.ModuleName, FormName, Keyword, sGrvName, Mod.iNNgu)).Replace("\\n", "\n");
            }
            catch
            {
                sStr = "?" + Keyword + "?";
            }
            return sStr;
        }

        public void GetControlsCollection(Control root, ref List<Control> AllControls, Func<Control, Control> filter)
        {
            foreach (Control child in root.Controls)
            {
                if (Com.Mod.lstControlName.Any(x => x.ToString() == child.GetType().Name))
                    AllControls.Add(child);
                if (child.Controls.Count > 0)
                    GetControlsCollection(child, ref AllControls, filter);
            }
        }
        public void GetControlsLabel(Control root, ref List<Control> AllControls, List<string> lstControl, Func<Control, Control> filter)
        {

            foreach (Control child in root.Controls)
            {
                if (lstControl.Any(x => x.ToString() == child.GetType().Name))
                    AllControls.Add(child);
                if (child.Controls.Count > 0)
                    GetControlsLabel(child, ref AllControls, lstControl, filter);
            }
        }
        #endregion

        #region kiểm tra null or rỗng

        public bool IsnullorEmpty(object input)
        {
            bool resust = false;
            try
            {
                if (input.ToString() == "" || input.ToString() == "0")
                {
                    resust = true;
                }
            }
            catch (Exception)
            {
                resust = true;
            }
            return resust;
        }


        #endregion

        #region MA HOA

        static string SecurityKey = "vietsoft.com.vn";
        static string chuoi = "_13579_";
        /// <summary>
        /// Encrypt a string using dual encryption method. Return a encrypted cipher Text
        /// </summary>
        /// <param name="toEncrypt">string to be encrypted</param>
        /// <param name="useHashing">use hashing? send to for extra secirity</param>
        /// <returns></returns>
        /// 
        public string Encrypt(string toEncrypt, bool useHashing)
        {
            try
            {
                byte[] keyArray;
                byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(chuoi + toEncrypt + chuoi);

                System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
                // Get the key from config file
                string key = SecurityKey; /*(string)settingsReader.GetValue("SecurityKey", typeof(String));*/
                                          //System.Windows.Forms.MessageBox.Show(key);
                if (useHashing)
                {
                    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    hashmd5.Clear();
                }
                else
                    keyArray = UTF8Encoding.UTF8.GetBytes(key);

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateEncryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                tdes.Clear();
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            catch
            {
                byte[] byteData = Encoding.Unicode.GetBytes("");
                return Convert.ToBase64String(byteData);
            }
        }
        /// <summary>
        /// DeCrypt a string using dual encryption method. Return a DeCrypted clear string
        /// </summary>
        /// <param name="cipherString">encrypted string</param>
        /// <param name="useHashing">Did you use hashing to encrypt this data? pass true is yes</param>
        /// <returns></returns>
        public string Decrypt(string cipherString, bool useHashing)
        {
            try
            {
                byte[] keyArray;
                byte[] toEncryptArray = Convert.FromBase64String(cipherString);

                System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
                //Get your key from config file to open the lock!
                string key = SecurityKey;//(string)settingsReader.GetValue("SecurityKey", typeof(String));

                if (useHashing)
                {
                    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    hashmd5.Clear();
                }
                else
                    keyArray = UTF8Encoding.UTF8.GetBytes(key);

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                tdes.Clear();
                return UTF8Encoding.UTF8.GetString(resultArray).Split(new string[] { chuoi }, StringSplitOptions.None)[1];
            }
            catch
            {
                byte[] byteData = Encoding.Unicode.GetBytes("");
                return Convert.ToBase64String(byteData);
            }
        }


        #endregion

        #region creatbt
        public bool MTableToData(string connectionString, string tableSQLName, DataTable table, string sTaoTable)
        {
            if (connectionString == "")
                connectionString = Com.Mod.CNStr;

            try
            {
                if (sTaoTable == "")
                {
                    if (!MCreateTable(tableSQLName, table, connectionString))
                        return false;
                }
                else
                {
                    Com.Mod.OS.XoaTable(tableSQLName);
                    SqlHelper.ExecuteReader(connectionString, CommandType.Text, sTaoTable);
                }

                using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
                {
                    System.Data.SqlClient.SqlBulkCopy bulkCopy = new System.Data.SqlClient.SqlBulkCopy(connection, System.Data.SqlClient.SqlBulkCopyOptions.TableLock | System.Data.SqlClient.SqlBulkCopyOptions.FireTriggers | System.Data.SqlClient.SqlBulkCopyOptions.UseInternalTransaction, null);

                    bulkCopy.DestinationTableName = tableSQLName;
                    connection.Open();

                    bulkCopy.WriteToServer(table);
                    connection.Close();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool MCreateTable(string tableName, DataTable table, string connectionString)
        {
            try
            {
                if (connectionString == "")
                    connectionString = Com.Mod.CNStr;

                string sql = "CREATE TABLE " + tableName + " (" + "\n";

                // columns
                int i = 1;
                foreach (DataColumn col in table.Columns)
                {
                    sql += "[" + col.ColumnName + "] " + MGetTypeSql(col.DataType, col.MaxLength, 10, 2) + "," + "\n";
                    i += 1;
                }
                sql += ")";

                Com.Mod.OS.XoaTable(tableName);
                SqlHelper.ExecuteReader(connectionString, CommandType.Text, sql);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void XoaTable(string strTableName)
        {
            try
            {
                SqlHelper.ExecuteScalar(Mod.CNStr, CommandType.Text, "DROP TABLE " + strTableName);
            }
            catch
            {
            }
        }

        public string MGetTypeSql(object type, int columnSize, int numericPrecision, int numericScale)
        {
            switch (type.ToString())
            {
                case "System.String":
                    {
                        if ((columnSize >= 2147483646))
                            return "NVARCHAR(MAX)";
                        else
                            return (columnSize == -1) ? "NVARCHAR(MAX)" : "NVARCHAR(" + columnSize.ToString() + ")";
                    }

                case "System.Decimal":
                    {
                        if (numericScale > 0)
                            return "REAL";
                        else if (numericPrecision > 10)
                            return "BIGINT";
                        else
                            return "INT";
                    }

                case "System.Boolean":
                    {
                        return "BIT";
                    }

                case "System.Double":
                    {
                        return "FLOAT";
                    }

                case "System.Single":
                    {
                        return "REAL";
                    }

                case "System.Int64":
                    {
                        return "BIGINT";
                    }

                case "System.Int16":
                    {
                        return "INT";
                    }

                case "System.Int32":
                    {
                        return "INT";
                    }

                case "System.DateTime":
                    {
                        return "DATETIME";
                    }

                case "System.Byte[]":
                    {
                        return "IMAGE";
                    }

                case "System.Drawing.Image":
                    {
                        return "IMAGE";
                    }

                default:
                    {
                        throw new Exception(type.ToString() + " not implemented.");
                    }
            }
        }
        #endregion



        public string MCreateJsonToDataTable(DataTable dt)
        {
            DataSet ds = new DataSet();
            ds.Merge(dt);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                var lst = dt.AsEnumerable()
                        .Select(r => r.Table.Columns.Cast<DataColumn>()
                        .Select(c => new KeyValuePair<string, object>(c.ColumnName, r[c.Ordinal])
                        ).ToDictionary(z => z.Key, z => z.Value)
                        ).ToList();
                return JsonConvert.SerializeObject(lst);
            }
            else
            {
                return null;
            }



        }
        
        #region add combobox search
        public void AddCombSearchLookUpEdit(RepositoryItemSearchLookUpEdit cboSearch, string Value, string Display, GridView grv, DataTable dtTmp, string form)
        {
            cboSearch.NullText = "";
            cboSearch.ValueMember = Value;
            cboSearch.DisplayMember = Display;
            cboSearch.DataSource = dtTmp;
            cboSearch.View.PopulateColumns(cboSearch.DataSource);
            cboSearch.View.Columns[Value].Visible = false;

            Com.Mod.OS.MLoadNNXtraGrid(cboSearch.View, form);
            grv.Columns[Value].ColumnEdit = cboSearch;
        }

        public void AddCombSearchLookUpEdit(RepositoryItemSearchLookUpEdit cboSearch, string Value, string Display, string cot, GridView grv, DataTable dtTmp, string form)
        {
            cboSearch.NullText = "";
            cboSearch.ValueMember = Value;
            cboSearch.DisplayMember = Display;
            cboSearch.DataSource = dtTmp;
            cboSearch.View.PopulateColumns(cboSearch.DataSource);
            cboSearch.View.Columns[Value].Visible = false;

            Com.Mod.OS.MLoadNNXtraGrid(cboSearch.View, form);
            grv.Columns[cot].ColumnEdit = cboSearch;
        }

        public void AddCombXtra(string Value, string Display, GridView grv, string sSql, string form)
        {
            DataTable tempt = new DataTable();
            tempt.Load(SqlHelper.ExecuteReader(Mod.CNStr, sSql, Com.Mod.UName, Com.Mod.iNNgu, 0));
            RepositoryItemSearchLookUpEdit cbo = new RepositoryItemSearchLookUpEdit();
            cbo.NullText = "";
            cbo.ValueMember = Value;
            cbo.DisplayMember = Display;
            cbo.DataSource = tempt;
            cbo.View.PopulateColumns(cbo.DataSource);
            Com.Mod.OS.MLoadNNXtraGrid(cbo.View, form);
            grv.Columns[Value].ColumnEdit = cbo;

        }
        public void AddCombXtra(string Value, string Display, string cot, GridView grv, DataTable dt)
        {
            RepositoryItemSearchLookUpEdit cbo = new RepositoryItemSearchLookUpEdit();
            cbo.NullText = "";
            cbo.ValueMember = Value;
            cbo.DisplayMember = Display;
            cbo.DataSource = dt;
            grv.Columns[cot].ColumnEdit = cbo;

        }
        public void AddCombXtra(string Value, string Display, GridView grv, DataTable dt)
        {
            RepositoryItemSearchLookUpEdit cbo = new RepositoryItemSearchLookUpEdit();
            cbo.NullText = "";
            cbo.ValueMember = Value;
            cbo.DisplayMember = Display;
            cbo.DataSource = dt;
            grv.Columns[Value].ColumnEdit = cbo;

        }

        public void AddCombDateTimeEdit(string col, GridView grv)
        {
            RepositoryItemDateEdit cbo = new RepositoryItemDateEdit();
            cbo.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            cbo.EditMask = "G";
            cbo.DisplayFormat.FormatString = "G";
            cbo.EditFormat.FormatString = "G";
            cbo.CalendarView = CalendarView.TouchUI;

            grv.Columns[col].Width = 150;
            grv.Columns[col].ColumnEdit = cbo;
        }

        public void AddCombXtra(string Value, string Display, string Cot, GridView grv, DataTable tempt, bool Search, string form)
        {
            if (Search == true)
            {
                RepositoryItemSearchLookUpEdit cbo = new RepositoryItemSearchLookUpEdit();
                cbo.NullText = "";
                cbo.ValueMember = Value;
                cbo.DisplayMember = Display;
                cbo.DataSource = tempt;
                grv.Columns[Cot].ColumnEdit = cbo;
                cbo.View.PopulateColumns(cbo.DataSource);
                Com.Mod.OS.MLoadNNXtraGrid(cbo.View, form);
                grv.Columns[Cot].ColumnEdit = cbo;
                cbo.View.Columns[0].Visible = false;


            }
            else
            {
                RepositoryItemLookUpEdit cbo = new RepositoryItemLookUpEdit();
                cbo.NullText = "";
                cbo.ValueMember = Value;
                cbo.DisplayMember = Display;
                cbo.DataSource = tempt;
                cbo.Columns.Clear();
                cbo.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(Display));
                cbo.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                cbo.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                cbo.BestFitMode = BestFitMode.BestFit;
                cbo.SearchMode = SearchMode.AutoComplete;
                grv.Columns[Cot].ColumnEdit = cbo;
                cbo.Columns[Display].Caption = Com.Mod.OS.GetLanguage(form, Display);
            }
        }
        public void AddCombo(string Value, string Display, GridView grv, DataTable tempt)
        {
            try
            {
                RepositoryItemLookUpEdit cbo = new RepositoryItemLookUpEdit();
                cbo.NullText = "";
                cbo.ValueMember = Value;
                cbo.DisplayMember = Display;
                cbo.DataSource = tempt;
                cbo.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                cbo.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                cbo.BestFitMode = BestFitMode.BestFit;
                cbo.SearchMode = SearchMode.AutoComplete;
                grv.Columns[Value].ColumnEdit = cbo;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void AddCombobyTree(string Value, string Display, TreeList tree, DataTable tempt)
        {
            RepositoryItemLookUpEdit cbo = new RepositoryItemLookUpEdit();
            cbo.NullText = "";
            cbo.ValueMember = Value;
            cbo.DisplayMember = Display;
            cbo.DataSource = tempt;
            cbo.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            cbo.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            cbo.BestFitMode = BestFitMode.BestFit;
            cbo.SearchMode = SearchMode.AutoComplete;
            tree.Columns[Value].ColumnEdit = cbo;
        }

        public void AddCombobyTree(RepositoryItemLookUpEdit cbo, string Value, string Display, TreeList tree, DataTable tempt)
        {
            cbo.NullText = "";
            cbo.ValueMember = Value;
            cbo.DisplayMember = Display;
            cbo.DataSource = tempt;
            cbo.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            cbo.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            cbo.BestFitMode = BestFitMode.BestFit;
            cbo.SearchMode = SearchMode.AutoComplete;
            tree.Columns[Value].ColumnEdit = cbo;
        }


        #endregion
        public void MReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }

        public void AddnewRow(GridView view, bool add)
        {
            try
            {
                view.OptionsBehavior.Editable = true;
                if (add == true)
                {
                    view.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                    view.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
                    view.MoveLastVisible();
                }
            }
            catch
            {
            }
        }
        public void AddnewRow(GridView view, bool add, NewItemRowPosition Pos)
        {
            try
            {
                view.OptionsBehavior.Editable = true;
                if (add == true)
                {
                    view.OptionsView.NewItemRowPosition = Pos;
                    view.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
                    view.MoveLastVisible();
                }
            }
            catch
            {
            }
        }
        public void DeleteAddRow(GridView view)
        {
            try
            {
                view.OptionsBehavior.Editable = false;
                view.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            }
            catch
            {
            }
        }
        public bool isEmail(string inputEmail)
        {
            bool resulst = false;
            if (string.IsNullOrEmpty(inputEmail))
            {
                resulst = true;
            }
            else
            {
                string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                      @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                      @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                Regex re = new Regex(strRegex);
                if (re.IsMatch(inputEmail))
                    resulst = true;
                else
                    resulst = false;
            }
            return resulst;
        }

        #region tài liệu
        public void Xoahinh(string strDuongdan)
        {
            if (System.IO.File.Exists(strDuongdan))
            {
                try
                {
                    System.IO.File.Delete(strDuongdan);
                }
                catch
                {
                }
            }
        }

        public void XoaFollder(string strDuongdan)
        {
            DirectoryInfo directory = new DirectoryInfo(strDuongdan);
            if (directory.Exists)
            {
                directory.Delete();
            }
        }

        public bool LuuDuongDan(string strDUONG_DAN, string strHINH, string FormThuMuc)
        {
            String server = Environment.UserName;
            string folderLocation = Com.Mod.sDDTaiLieu + '\\' + FormThuMuc;
            string folderLocationFile = folderLocation + '\\' + strHINH;
            bool exists = System.IO.Directory.Exists(folderLocation);
            if (!exists)
            {
                System.IO.Directory.CreateDirectory(folderLocation);
            }
            if (!File.Exists(folderLocationFile))
            {
                if (System.IO.File.Exists(strDUONG_DAN))
                {
                    System.IO.File.Copy(strDUONG_DAN, folderLocation + '\\' + strHINH, true);
                }
            }
            else
            {
                return false;
            }
            return true;
        }

        public string LayDuoiFile(string strFile)
        {
            string[] FILE_NAMEArr, arr;
            string FILE_NAME = "";

            FILE_NAMEArr = strFile.Split('\\');
            FILE_NAME = FILE_NAMEArr[FILE_NAMEArr.Length - 1];
            arr = FILE_NAME.Split('.');
            return "." + arr[arr.Length - 1];
        }

        public void OpenHinh(string strDuongdan)
        {
            if (strDuongdan.Equals(""))
                return;


            if (System.IO.File.Exists(strDuongdan))
            {
                try
                {
                    System.Diagnostics.Process.Start(strDuongdan);
                }
                catch
                {
                }
            }
        }

        public string CapnhatTL(string strFile, bool locKyTu)
        {
            try
            {
                if (locKyTu == true)
                {
                    strFile = LocKyTuDB(strFile);
                }
                string SERVER_FOLDER_PATH = "";
                string SERVER_PATH = "";
                SERVER_PATH = Com.Mod.sDDTaiLieuCloud;
                if (!System.IO.Directory.Exists(SERVER_PATH))
                {
                    SERVER_PATH = "";
                    return SERVER_PATH;
                }
                if (!SERVER_PATH.EndsWith(@"\"))
                    SERVER_PATH = SERVER_PATH + @"\";
                SERVER_FOLDER_PATH = SERVER_PATH + strFile;
                if (!System.IO.Directory.Exists(SERVER_FOLDER_PATH))
                {
                    System.IO.Directory.CreateDirectory(SERVER_FOLDER_PATH);
                }
                return SERVER_FOLDER_PATH;
            }
            catch { return ""; }
         
        }

        #endregion

        #region lấy table từ grid
        public DataTable ConvertDatatable(GridControl grid)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)grid.DataSource;
            return dt;
        }
        public DataTable ConvertDatatable(GridView view)
        {
            view.PostEditor();
            view.UpdateCurrentRow();
            DataView dt = (DataView)view.DataSource;
            DataTable tempt = dt.ToTable();
            return tempt;
        }

        public bool KiemTrungTrenLuoi(string sKiem, string colums, GridView grvChung)
        {
            try
            {
                //lấy datatalbe hiện tại trên lưới
                DataTable dt = new DataTable();
                dt = Com.Mod.OS.ConvertDatatable(grvChung);
                if (dt.AsEnumerable().Count(x => x[colums].ToString().Trim().Equals(sKiem)) > 1)
                {
                    return false;
                }
                else return true;
            }
            catch
            {
                return false;
            }
        }

        public bool KiemTrungTrenLuoi(string sKiem, string sKiem1, string colums, string colums1, GridView grvChung)
        {
            try
            {
                //lấy datatalbe hiện tại trên lưới
                DataTable dt = new DataTable();
                dt = Com.Mod.OS.ConvertDatatable(grvChung);
                if (dt.AsEnumerable().Count(x => x[colums].ToString().Trim().Equals(sKiem) && x[colums1].ToString().Trim().Equals(sKiem1)) > 1)
                {
                    return false;
                }
                else return true;
            }
            catch
            {
                return false;
            }
        }
        public bool KiemTrungTrenLuoi(string sKiem, string sKiem1, string sKiem2, string colums, string colums1, string colums2, GridView grvChung)
        {
            try
            {
                //lấy datatalbe hiện tại trên lưới
                DataTable dt = new DataTable();
                dt = Com.Mod.OS.ConvertDatatable(grvChung);
                if (dt.AsEnumerable().Count(x => x[colums].ToString().Trim().Equals(sKiem) && x[colums1].ToString().Trim().Equals(sKiem1) && x[colums2].ToString().Trim().Equals(sKiem2)) > 1)
                {
                    return false;
                }
                else return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties

            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in Props)
            {
                dataTable.Columns.Add(prop.Name);
            }

            foreach (T item in items)
            {

                var values = new object[Props.Length];

                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(item, null);

                }
                dataTable.Rows.Add(values);

            }

            return dataTable;

        }

        public DataRow BLMCPC(Int64 idcn, DateTime ngayhd)
        {

            DataTable tempt = new DataTable();
            tempt.Load(SqlHelper.ExecuteReader(Mod.CNStr, CommandType.Text, "SELECT * FROM [funGetLuongKyHopDong](" + idcn + ",'" + ngayhd.ToString("MM/dd/yyyy") + "')"));
            if (tempt.Rows.Count == 0)
                tempt.Rows.Add(idcn, 0, 0, 0);
            return tempt.Rows[0]; ;
        }
        public DataRow TienTroCap(Int64 idcn, DateTime ngaynv, int idldtv)
        {
            //ID_CN	LUONG_TRO_CAP	TIEN_TRO_CAP
            DataTable tempt = new DataTable();
            tempt.Load(SqlHelper.ExecuteReader(Mod.CNStr, CommandType.Text, "SELECT * FROM [dbo].[GetTienTroCap]('" + ngaynv.ToString("MM/dd/yyyy") + "'," + idcn + "," + idldtv + ")"));
            return tempt.Rows[0];
        }

        public DataRow TienPhep(Int64 idcn, DateTime ngaynv)
        {
            //ID_CN	LUONG_TP	SO_NGAY_PHEP	TIEN_PHEP
            DataTable tempt = new DataTable();
            tempt.Load(SqlHelper.ExecuteReader(Mod.CNStr, CommandType.Text, "SELECT * FROM [dbo].[GetTienPhep]('" + ngaynv.ToString("MM/dd/yyyy") + "'," + idcn + ")"));
            return tempt.Rows[0];
        }



        #endregion
        #region Loadcombo phân quyền
        public void LoadCboDonVi(SearchLookUpEdit cboSearch_DV)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Mod.CNStr, "spGetComboDON_VI", Com.Mod.UName, Com.Mod.iNNgu, 1));
                Com.Mod.OS.MLoadSearchLookUpEdit(cboSearch_DV, dt, "ID_DV", "TEN_DV", "frmChung");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }
        public void LoadCboXiNghiep(SearchLookUpEdit cboSearch_DV, SearchLookUpEdit cboSearch_XN)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Mod.CNStr, "spGetComboXI_NGHIEP", cboSearch_DV.EditValue, Com.Mod.UName, Com.Mod.iNNgu, 1));
                Com.Mod.OS.MLoadSearchLookUpEdit(cboSearch_XN, dt, "ID_XN", "TEN_XN", "frmChung");
                cboSearch_XN.EditValue = -1;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }
        public void LoadCboTo(SearchLookUpEdit cboSearch_DV, SearchLookUpEdit cboSearch_XN, SearchLookUpEdit cboSearch_TO)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Mod.CNStr, "spGetComboTO", cboSearch_DV.EditValue, cboSearch_XN.EditValue, Com.Mod.UName, Com.Mod.iNNgu, 1));
                Com.Mod.OS.MLoadSearchLookUpEdit(cboSearch_TO, dt, "ID_TO", "TEN_TO", "frmChung");
                cboSearch_TO.EditValue = -1;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        public void LoadCboDoiTacBanHang(SearchLookUpEdit cboSearch_DV)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Mod.CNStr, "spGetComboDON_VI", Com.Mod.UName, Com.Mod.iNNgu, 1));
                Com.Mod.OS.MLoadSearchLookUpEdit(cboSearch_DV, dt, "ID_DV", "TEN_DV", "frmChung");

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        public void CapNhapUser()
        {
            string MName = "";
            try { MName = Environment.MachineName; } catch { }
            string sSql = "DELETE FROM dbo.LOGIN WHERE USER_LOGIN = '" + Com.Mod.UName + "' ";
            SqlHelper.ExecuteNonQuery(Mod.CNStr, CommandType.Text, sSql);

            sSql = "INSERT dbo.LOGIN(USER_LOGIN, TIME_LOGIN, ID,USER_NAME)	VALUES(N'" + Com.Mod.UName + "',GETDATE(), " + Com.Mod.UserID.ToString() + " , N'" + Com.Mod.OS.Encrypt(LoadIPLocal() + Com.Mod.UName, true) + "' ) ";

            sSql = "INSERT dbo.LOGIN(USER_LOGIN, TIME_LOGIN, ID,[USER_NAME],[M_NAME]) VALUES(N'" + Com.Mod.UName + "',GETDATE(), " + Com.Mod.UserID.ToString() + " , N'" + LoadIPLocal() + "', N'" + MName + "' )";
            SqlHelper.ExecuteNonQuery(Mod.CNStr, CommandType.Text, sSql);

        }

        public String LoadIPLocal()
        {
            try
            {
                string ipAddress = "";
                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                ipAddress = Convert.ToString(ipHostInfo.AddressList.FirstOrDefault(address => address.AddressFamily == AddressFamily.InterNetwork));
                return ipAddress;
            }
            catch { return "1.2.3.4"; }
        }

        #endregion
        #region Định dạng
        public string sDinhDangSoLe(int iSoLe)
        {
            string sChuoi = "#,##0";
            if (iSoLe != 0)
            {
                sChuoi = sChuoi + ".";
                for (int i = 0; i <= iSoLe - 1; i++)
                    sChuoi = sChuoi + "0";
            }
            return sChuoi;
        }

        public string sDinhDangSoLe(int iSoLe, string sChuoi)
        {
            if (iSoLe != 0)
            {
                sChuoi = sChuoi + ".";
                for (int i = 0; i <= iSoLe - 1; i++)
                    sChuoi = sChuoi + "0";
            }
            return sChuoi;
        }
        #endregion

        public void MChooseGrid(bool bChose, string sCot, DevExpress.XtraGrid.Views.Grid.GridView grv)
        {
            try
            {
                int i;
                i = 0;
                for (i = 0; i <= grv.RowCount; i++)
                {
                    grv.SetRowCellValue(i, sCot, bChose);
                    grv.UpdateCurrentRow();
                }
            }
            catch
            {
            }
        }
        

        public SplashScreenManager splashScreenManager1;
        public SplashScreenManager ShowWaitForm(XtraUserControl a)
        {
            try
            {
                splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(a.ParentForm, typeof(frmWaitForm), true, true, true);
            splashScreenManager1.ShowWaitForm();
            Thread.Sleep(1000);
            return splashScreenManager1;
            }
            catch { return null; }
        }

        public SplashScreenManager ShowWaitForm(XtraForm a)
        {
            try
            {
                splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(a, typeof(frmWaitForm), true, true, true);
                splashScreenManager1.ShowWaitForm();
                return splashScreenManager1;
            }
            catch { return null; }
        }
        public void HideWaitForm()
        {
            try
            {
                splashScreenManager1.CloseWaitForm();
            }catch { }
        }

        public string SaveFiles(string MFilter, string sFName)
        {
            try
            {
                SaveFileDialog f = new SaveFileDialog();
                f.Filter = MFilter;
                f.FileName = sFName + " " + DateTime.Now.ToString("yyyyMMdd_HHmmss");
                try
                {
                    DialogResult res = f.ShowDialog();
                    if (res == DialogResult.OK)
                        return f.FileName;
                    return "";
                }
                catch
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
                return "";
            }
        }

        public string SaveFiles(string MFilter)
        {
            try
            {
                SaveFileDialog f = new SaveFileDialog();
                f.Filter = MFilter;
                f.FileName = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                try
                {
                    DialogResult res = f.ShowDialog();
                    if (res == DialogResult.OK)
                        return f.FileName;
                    return "";
                }
                catch
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
                return "";
            }
        }

        public string OpenFiles(string MFilter)
        {
            try
            {
                OpenFileDialog f = new OpenFileDialog();
                f.Filter = MFilter;
                try
                {
                    DialogResult res = f.ShowDialog();
                    if (res == DialogResult.OK)
                        return f.FileName;
                    return "";
                }
                catch
                {
                    return "";
                }
            }
            catch (Exception)
            {
                return "";
            }
        }

        public void MExportGridView(GridView grv)
        {
            DevExpress.XtraPrinting.XlsExportOptionsEx grdSet = new DevExpress.XtraPrinting.XlsExportOptionsEx();
            grdSet.ExportType = DevExpress.Export.ExportType.WYSIWYG;
            grdSet.AllowFixedColumnHeaderPanel = DevExpress.Utils.DefaultBoolean.True;
            grdSet.AllowFixedColumns = DevExpress.Utils.DefaultBoolean.True;
            grdSet.ShowGridLines = true;
            grdSet.TextExportMode = DevExpress.XtraPrinting.TextExportMode.Text;
            grdSet.SheetName = DateTime.Now.ToString("yyyyMMdd");

            string sPath;
            //sPath = Com.Mod.ObjSystems.SaveFiles("Excel (2010)(.xlsx)|*.xlsx|Excel (2003)(.xls)|*.xls|Word (.docx)|*.docx|Richtext File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html|Mht File (.mht)|*.mht");
            sPath = Com.Mod.OS.SaveFiles("Excel Workbook |*.xlsx|Excel 97-2003 Workbook |*.xls|Word Document |*.docx|Rich Text Format |*.rtf|PDF File |*.pdf|Web Page |*.html|Single File Web Page |*.mht");

            if (sPath != "")
            {
                string fileExtenstion = new System.IO.FileInfo(sPath).Extension;
                try
                {
                    switch (fileExtenstion.ToLower())
                    {
                        case ".xls":
                            {
                                grv.ExportToXls(sPath, grdSet);
                                break;
                            }
                        case ".xlsx":
                            {
                                DevExpress.XtraPrinting.XlsxExportOptionsEx grdxLSXSet = new DevExpress.XtraPrinting.XlsxExportOptionsEx();
                                grdxLSXSet.ExportType = DevExpress.Export.ExportType.WYSIWYG;
                                grdxLSXSet.AllowFixedColumnHeaderPanel = DevExpress.Utils.DefaultBoolean.True;
                                grdxLSXSet.AllowFixedColumns = DevExpress.Utils.DefaultBoolean.True;
                                grdxLSXSet.ShowGridLines = true;
                                grdxLSXSet.TextExportMode = DevExpress.XtraPrinting.TextExportMode.Text;
                                grdxLSXSet.SheetName = DateTime.Now.ToString("yyyyMMdd");

                                grv.ExportToXlsx(sPath, grdxLSXSet);
                                break;
                            }
                        case ".rtf":
                            {
                                grv.ExportToRtf(sPath);
                                break;
                            }
                        case ".pdf":
                            {
                                grv.ExportToPdf(sPath);
                                break;
                            }
                        case ".html":
                            {
                                grv.ExportToHtml(sPath);
                                break;
                            }
                        case ".mht":
                            {
                                grv.ExportToMht(sPath);
                                break;
                            }
                        case ".docx":
                            {
                                grv.ExportToDocx(sPath);
                                break;
                            }
                    }


                    System.IO.FileInfo fi = new System.IO.FileInfo(sPath);
                    if (fi.Exists)
                    {
                        System.Diagnostics.Process.Start(sPath);
                    }
                    else
                    {
                        //file doesn't exist
                    }

                }
                catch { }
            }
        }
        public void MExportGrid(DevExpress.XtraGrid.GridControl grd)
        {
            DevExpress.XtraPrinting.XlsExportOptionsEx grdSet = new DevExpress.XtraPrinting.XlsExportOptionsEx();
            grdSet.ExportType = DevExpress.Export.ExportType.WYSIWYG;
            grdSet.AllowFixedColumnHeaderPanel = DevExpress.Utils.DefaultBoolean.True;
            grdSet.AllowFixedColumns = DevExpress.Utils.DefaultBoolean.True;
            grdSet.ShowGridLines = true;
            grdSet.TextExportMode = DevExpress.XtraPrinting.TextExportMode.Text;
            grdSet.SheetName = DateTime.Now.ToString("yyyyMMdd");

            string sPath;
            //sPath = Com.Mod.ObjSystems.SaveFiles("Excel (2010)(.xlsx)|*.xlsx|Excel (2003)(.xls)|*.xls|Word (.docx)|*.docx|Richtext File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html|Mht File (.mht)|*.mht");
            sPath = Com.Mod.OS.SaveFiles("Excel Workbook |*.xlsx|Excel 97-2003 Workbook |*.xls|Word Document |*.docx|Rich Text Format |*.rtf|PDF File |*.pdf|Web Page |*.html|Single File Web Page |*.mht");

            if (sPath != "")
            {
                string fileExtenstion = new System.IO.FileInfo(sPath).Extension;
                try
                {

                    switch (fileExtenstion.ToLower())
                    {
                        case ".xls":
                            {
                                grd.ExportToXls(sPath, grdSet);
                                break;
                            }
                        case ".xlsx":
                            {
                                DevExpress.XtraPrinting.XlsxExportOptionsEx grdxLSXSet = new DevExpress.XtraPrinting.XlsxExportOptionsEx();
                                grdxLSXSet.ExportType = DevExpress.Export.ExportType.WYSIWYG;
                                grdxLSXSet.AllowFixedColumnHeaderPanel = DevExpress.Utils.DefaultBoolean.True;
                                grdxLSXSet.AllowFixedColumns = DevExpress.Utils.DefaultBoolean.True;
                                grdxLSXSet.ShowGridLines = true;
                                grdxLSXSet.TextExportMode = DevExpress.XtraPrinting.TextExportMode.Text;
                                grdxLSXSet.SheetName = DateTime.Now.ToString("yyyyMMdd");

                                grd.ExportToXlsx(sPath, grdxLSXSet);
                                break;
                            }
                        case ".rtf":
                            {
                                grd.ExportToRtf(sPath);
                                break;
                            }
                        case ".pdf":
                            {
                                grd.ExportToPdf(sPath);
                                break;
                            }
                        case ".html":
                            {
                                grd.ExportToHtml(sPath);
                                break;
                            }
                        case ".mht":
                            {
                                grd.ExportToMht(sPath);
                                break;
                            }
                        case ".docx":
                            {
                                grd.ExportToDocx(sPath);
                                break;
                            }
                    }


                    System.IO.FileInfo fi = new System.IO.FileInfo(sPath);
                    if (fi.Exists)
                    {
                        System.Diagnostics.Process.Start(sPath);
                    }
                    else
                    {
                        //file doesn't exist
                    }




                }
                catch { }

            }
        }
        public int CheckPermission(string sForm)
        {
            Com.Mod.iPermission = 1;
            //return 1;


            Com.Mod.iPermission = 0;
            string sSql = " SELECT TOP 1 T1.ID_PERMISSION FROM dbo.NHOM_MENU T1 INNER JOIN dbo.MENU T2 ON T2.ID_MENU = T1.ID_MENU INNER JOIN dbo.USERS T3 ON T3.ID_NHOM = T1.ID_NHOM WHERE	T2.KEY_MENU = N'" + sForm + "' AND T3.USER_NAME = N'" + Com.Mod.UName + "'  UNION SELECT 0 ORDER BY ID_PERMISSION DESC";
            try
            {
                sSql = Convert.ToString(SqlHelper.ExecuteScalar(Mod.CNStr, CommandType.Text, sSql).ToString());

                Com.Mod.iPermission = int.Parse(sSql);
                return Com.Mod.iPermission;
            }
            catch { return Com.Mod.iPermission; }

        }


        #region Tao so phieu
        public string TaoSoPhieu(string sKytu, string sForm, string sTable, string sField, DateTime dNgay)
        {
            string Ma = "";
            try
            {
                Ma = SqlHelper.ExecuteScalar(Mod.CNStr, "MTaoSoPhieu", sKytu, sForm, sTable, sField, dNgay, "").ToString();
            }
            catch //( Exception ex)
            { Ma = ""; }
            return Ma;
        }
        #endregion

        #region Tao barcode
        public string TaoBarcode(string sTable, string sField)
        {
            string Ma = "";
            try
            {
                Ma = SqlHelper.ExecuteScalar(Mod.CNStr, "MTaoBarcode", sTable, sField).ToString();
            }
            catch //( Exception ex)
            { Ma = ""; }
            return Ma;
        }
        #endregion

        public IEnumerable<Control> GetAllConTrol(Control control, IEnumerable<Type> filteringTypes)
        {
            var ctrls = control.Controls.Cast<Control>();

            return ctrls.SelectMany(ctrl => GetAllConTrol(ctrl, filteringTypes))
                        .Concat(ctrls)
                        .Where(ctl => filteringTypes.Any(t => ctl.GetType() == t));
        }

        public void LocationSizeForm(XtraForm frmMain, XtraForm frm)
        {
            
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Size = new Size((frmMain.Width / 2) + (frm.Width / 2), (frmMain.Height / 2) + (frm.Height / 2));
            
        }


        public string MFindData(string sSql)
        {
            try
            {
                sSql = Convert.ToString(SqlHelper.ExecuteScalar(Mod.CNStr, CommandType.Text, sSql));
                return sSql;
            }
            catch { return ""; }
        }
        public string MFindData(string mTable, string mCol, string mFind)
        {
            try
            {
                string sSql = "";
                sSql = "SELECT " + mCol + " FROM " + mTable + " WHERE  " + mCol + " = N'" + mFind + "' ";
                sSql = Convert.ToString(SqlHelper.ExecuteScalar(Mod.CNStr, CommandType.Text, sSql));
                return sSql;
            }
            catch { return ""; }
        }
        public string MFindData(string mTable, string mCol, string mWhere, string mFind)
        {
            try
            {
                string sSql = "";
                sSql = "SELECT " + mCol + " FROM " + mTable + " WHERE  " + mWhere + " = N'" + mFind + "' ";
                sSql = Convert.ToString(SqlHelper.ExecuteScalar(Mod.CNStr, CommandType.Text, sSql));
                return sSql;
            }
            catch { return ""; }
        }

        public void CheckUpdate()
        {
            string sSql = "";
            try
            {
                #region Lay thong tin ver server
                //Com.Mod.sUserSer = Com.Mod.OS.Decrypt(dt.Rows[0]["USER_DD"].ToString(), true);
                //Com.Mod.sPassSer = Com.Mod.OS.Decrypt(dt.Rows[0]["PASS_DD"].ToString(), true);
                //Com.Mod.sPrivate = dt.Rows[0]["TTCT"].ToString();
                //if (Com.Mod.sDDTaiLieu != "")
                //{
                //    Thread t = new Thread(() => {
                //        CheckDDTL();
                //    });
                //    t.Start();
                //}

                //sSql = "SELECT TOP 1 (CONVERT(NVARCHAR,LOAI_CN) + '!' + isnull(LINK1, '-1') + '!' + isnull(LINK2, '-1') + '!' + isnull(LINK3, '-1')) AS CAPNHAT FROM THONG_TIN_CHUNG";

                sSql = "SELECT TOP 1 VER,USER_DD,PASS_DD, (CONVERT(NVARCHAR,LOAI_CN) + '!' + isnull(LINK1, '-1') + '!' + isnull(LINK2, '-1') + '!' + isnull(LINK3, '-1')) AS CAPNHAT FROM dbo.THONG_TIN_CHUNG";
                DataTable dtTmp = new DataTable();

                dtTmp.Load(SqlHelper.ExecuteReader(Com.Mod.CNStr, CommandType.Text, sSql));
                sSql = Convert.ToString(dtTmp.Rows[0][0]);
                string sLinkServer = "-1";
                Com.Mod.sUserSer = Com.Mod.OS.Decrypt(dtTmp.Rows[0]["USER_DD"].ToString(), true);
                Com.Mod.sPassSer = Com.Mod.OS.Decrypt(dtTmp.Rows[0]["PASS_DD"].ToString(), true);
                try
                {
                    sLinkServer = Convert.ToString(dtTmp.Rows[0]["CAPNHAT"].ToString());
                }
                catch { sLinkServer = "-1"; }
                if (sLinkServer != "-1")
                {
                    Thread t = new Thread(() =>
                    {
                        try
                        {
                            CheckConnServer(sLinkServer);
                        }
                        catch { Com.Mod.bDDTL = false; }

                    });
                    t.Start();
                }
                //sSql = Convert.ToString(SqlHelper.ExecuteScalar(Com.Mod.CNStr, System.Data.CommandType.Text, sSql));
                try
                {
                    Com.Mod.sInfoSer = sSql.Substring(0, (sSql.Length - 4));
                    Com.Mod.sInfoSer = Com.Mod.sInfoSer.Substring(6, 2) + "/" + Com.Mod.sInfoSer.Substring(4, 2) + "/" + Com.Mod.sInfoSer.Substring(0, 4) + "." + sSql.Substring(8, sSql.Length - 8);
                }
                catch
                {
                    Com.Mod.sInfoSer = "01/01/2000.0001";
                    sSql = "200001010001";
                }
                #endregion

                #region Lay thong tin ver client
                string sVerClient;
                sVerClient = LayDuLieu(@"Version.txt");
                try
                {
                    Com.Mod.sInfoClient = sVerClient.Substring(0, (sVerClient.Length - 4));
                    Com.Mod.sInfoClient = Com.Mod.sInfoClient.Substring(6, 2) + "/" + Com.Mod.sInfoClient.Substring(4, 2) + "/" + Com.Mod.sInfoClient.Substring(0, 4) + "." + sVerClient.Substring(8, sVerClient.Length - 8);
                }
                catch
                {
                    Com.Mod.sInfoClient = "01/01/2000.0001";
                    sVerClient = "200001010001";
                }
                #endregion
                try { if (double.Parse(sVerClient) == double.Parse(sSql)) return; } catch { return; }
                //sSql = "SELECT TOP 1 (CONVERT(NVARCHAR,LOAI_CN) + '!' + isnull(LINK1, '-1') + '!' + isnull(LINK2, '-1') + '!' + isnull(LINK3, '-1')) AS CAPNHAT FROM THONG_TIN_CHUNG";
                //sLinkServer = Convert.ToString(SqlHelper.ExecuteScalar(Com.Mod.CNStr, System.Data.CommandType.Text, sSql));

                string[] sArr = sLinkServer.Split('!');
                int loai = Convert.ToInt32(sArr[0].ToString());
                String link1 = sArr[1];
                String link2 = sArr[2];
                String link3 = sArr[3];
                //Khong có loai update thi thoát
                if (loai <= -1) return;
                switch (loai)
                {
                    //Loai 2 xai link1,2 : path link tren dropbox 
                    //Loai 1 xai link3: path link tren server
                    case 1:  //Update tren server voi link3
                        {
                            if (string.IsNullOrEmpty(link3)) return;
                            if (!Directory.Exists(link3))
                            {
                                XtraMessageBox.Show("Link update : " + link3 + " không tồn tại.");
                                return;
                            }
                            MUpdate(loai, ".", ".", link3);
                            break;
                        }
                    case 2: // Updatetren dropbox
                        {
                            if (string.IsNullOrEmpty(link1)) return;
                            MUpdate(loai, link1, link2, ".");
                            Com.Mod.sInfoSer = Com.Mod.sInfoClient;
                            break;
                        }
                    default: { break; }
                }
            }
            catch
            { }
        }

        private Boolean CheckConnServer(string sDDServer)
        {
            try
            {
                using (new ConnectToSharedFolder(sDDServer, new System.Net.NetworkCredential(Com.Mod.sUserSer, Com.Mod.sPassSer)))
                {
                    return true;
                }
            }
            catch { return false; }
        }
        private void MUpdate(int loai, String link1, String link2, String link3)
        {
            try
            {
                System.Diagnostics.Process.Start("Update.exe", loai.ToString() + " " + link1 + " " + link2 + " " + link3 + " " + Application.ProductName);
                //https://www.dropbox.com/s/ntwwve7ys4awrkj/Update.zip?dl=0
                //https://www.dropbox.com/s/6gppx79hbcph1qp/Version.txt?dl=0
                //VS.OEE

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }


        public string LayDuLieu(string TenFile)
        {
            StreamReader sr;
            string sText;
            sText = "";
            try
            {
                sText = Application.StartupPath.ToString() + @"\" + TenFile;
                sr = new StreamReader(sText);
                sText = "";
                sText = sr.ReadLine();
                try
                {
                    if (sText == null)
                        sText = "";
                }
                catch
                {
                    sText = "";
                }
                sr.Close();
            }
            catch
            { }
            return sText;
        }




        public DataTable getDataAPI(string path)
        {
            try
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                WebClient client = new WebClient();
                client.Encoding = Encoding.UTF8;
                string response = client.DownloadString(path);

                DataTable dt = new DataTable();
                dt = JsonConvert.DeserializeObject<DataTable>(JsonConvert.DeserializeObject(response).ToString());

                return dt;
            }
            catch
            {
                return null;
            }
        }

        #region Tao Ma Hang
        public string TaoMaHang(int ID_LHH)
        {
            string Ma = "";
            try
            {
                Ma = SqlHelper.ExecuteScalar(Mod.CNStr, "MTaoMaHang", ID_LHH).ToString();

                if (Ma == "-1")
                {
                    XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgDaVuotQuaSoLuongMaHangHoaToiDa"));
                    Ma = "";
                }
            }
            catch //( Exception ex)
            { Ma = ""; }
            return Ma;
        }

        #endregion

        public int GetTrangThai(Int64 iID, string sTable, string sKey, string sColumn = "TRANG_THAI")
        {
            try
            {
                return Convert.ToInt32(SqlHelper.ExecuteScalar(Com.Mod.CNStr, CommandType.Text, "SELECT TOP 1 " + sColumn + " FROM dbo." + sTable + " WHERE " + sKey + " = " + iID));
            }
            catch { return -99; }
        }

        public string GetAPI(string url)
        {
            string response = "";
            try
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                WebClient client = new WebClient();
                client.Encoding = System.Text.UTF8Encoding.UTF8;
                string s = JsonConvert.DeserializeObject(client.DownloadString(Mod.sUrlCheckServer + url)).ToString();
                response = Decrypt(s.ToString(), true);
            }
            catch
            {
                response = "";
            }
            return response;

        }
        public Int16 MCot(string sCot)
        {
            string sStmp = "";
            try
            {
                for (int i = 0; i <= sCot.Length - 1; i++)
                {
                    if (sStmp.Length == 0)
                        sStmp = MTimCot(sCot.Substring(i, 1));
                    else
                        sStmp = sStmp + MTimCot(sCot.Substring(i, 1));
                }
            }
            catch 
            {
            }
            try
            {
                return Int16.Parse(sStmp);
            }
            catch { return 1; }
        }

        private string MTimCot(string sCot)
        {
            string sTmp = "0";
            try
            {
                if (sCot == "!") return "1";
                if (sCot == "@") return "2";
                if (sCot == "#") return "3";
                if (sCot == "$") return "4";
                if (sCot == "%") return "5";
                if (sCot == "^") return "6";
                if (sCot == "&") return "7";
                if (sCot == "*") return "8";
                if (sCot == "(") return "9";
                if (sCot == ")") return "1";
            }
            catch 
            {return "1";}
            return sTmp;
        }

        #region Up tai lieu

        public string LocKyTuDB(string sChuoi)
        {
            if (sChuoi.Length > 0)
                sChuoi = sChuoi.Replace("/", "-");
            if (sChuoi.Length > 0)
                sChuoi = sChuoi.Replace(@"\", "-");
            if (sChuoi.Length > 0)
                sChuoi = sChuoi.Replace("*", "-");
            if (sChuoi.Length > 0)
                sChuoi = sChuoi.Replace("-", "-");
            if (sChuoi.Length > 0)
                sChuoi = sChuoi.Replace(".", "-");
            if (sChuoi.Length > 0)
                sChuoi = sChuoi.Replace("!", "-");
            if (sChuoi.Length > 0)
                sChuoi = sChuoi.Replace("@", "-");
            if (sChuoi.Length > 0)
                sChuoi = sChuoi.Replace("#", "-");
            return sChuoi;
        }
        public string CheckPathServer(string strFile,out string[] sTongFile )
        {
            string SERVER_FOLDER_PATH = Com.Mod.sDDTaiLieu;
            try
            {
                if (System.IO.Directory.Exists(Com.Mod.sDDTaiLieu))
                {
                    if (!Com.Mod.sDDTaiLieu.EndsWith(@"\"))
                        SERVER_FOLDER_PATH = Com.Mod.sDDTaiLieu + @"\";

                    SERVER_FOLDER_PATH = Com.Mod.sDDTaiLieu + @"\" + strFile;
                    if (!System.IO.Directory.Exists(SERVER_FOLDER_PATH))
                    {
                        System.IO.Directory.CreateDirectory(SERVER_FOLDER_PATH);
                    }

                    sTongFile = System.IO.Directory.GetFiles(SERVER_FOLDER_PATH);
                }
                else
                    sTongFile = null;
                return SERVER_FOLDER_PATH;
            }
            catch
            {
                sTongFile = null;
                return Com.Mod.sDDTaiLieu;
            }
        }


        public Boolean DeleteFileToServer(string sPathFile)
        {
            try
            {
                if (File.Exists(sPathFile))
                {
                    // If file found, delete it    
                    File.Delete(sPathFile);
                    return true;
                }
                else return false;
               
            }
            catch (Exception ioExp)
            {
                XtraMessageBox.Show(ioExp.Message);
                return false;
            }


        }


        public Com.Mod.MFileServer CopyFileToServer(string sPathSer,string sFileReplay)
        {
            if(!Com.Mod.bDDTL)
            {
                XtraMessageBox.Show(Com.Mod.OS.GetLanguage("frmChung", "msgKhongLinkDuocServer"));
                return new Mod.MFileServer(null, null);
            }
            List<String> sGoc = new List<String>();
            List<String> sFServer = new List<String>();
            string[] sTongFile;
            sPathServer = Com.Mod.OS.CheckPathServer(sPathSer,out sTongFile);
                       
            if (sPathServer == "" && sPathServer == "-1" && sPathServer == "1") return new Mod.MFileServer(sGoc, sFServer);

            OpenFileDialog ofdfile = new OpenFileDialog();
            ofdfile.Multiselect = true;
            try
            {
                DialogResult res = ofdfile.ShowDialog();
                if (res != DialogResult.OK) return new Mod.MFileServer(sGoc, sFServer);

            }
            catch
            {
                return new Mod.MFileServer(sGoc, sFServer);

            }

            sFileReplay = LocKyTuDB(sFileReplay);
            string TenFile;
            string sFile;
            TenFile = sFile = ofdfile.FileNames[0];
            string sFileGoc = System.IO.Path.GetFileName(ofdfile.FileName);
            int iSTTFile = 1;

            
            //sTongFile = System.IO.Directory.GetFiles(sPathServer);
            List<string> filterKeywords = new List<string>() { sFileReplay };
            //List<string> sRe;
            try
            {
                var result = from p in sTongFile
                             where filterKeywords.Any(val => p.Contains(val))
                             select p;
                iSTTFile = result.ToList().Count + 1;
            }
            catch { }
            foreach (String file in ofdfile.FileNames)
            {
                sFileGoc = file;
                sFile = System.IO.Path.GetExtension(sFileGoc);
                
                TenFile = sFileReplay + "."+ iSTTFile.ToString().PadLeft(3, '0')  + System.IO.Path.GetExtension(sFileGoc);
                TenFile = STTFileCungThuMuc(sPathServer, TenFile, sFileReplay);
                try
                {
                    if (Com.Mod.OS.KiemFileTonTaiServer(sPathServer + "\\" + TenFile) == false)
                        sFile = sPathServer + @"\" + TenFile;
                    else
                    {
                        TenFile = Com.Mod.OS.STTFileCungThuMuc(sPathServer, TenFile, sFileReplay);
                        sFile = sPathServer + @"\" + TenFile;
                    }
                }
                catch { }
                try
                {
                    System.IO.File.Copy(sFileGoc, sFile, true);
                    sGoc.Add(sFileGoc);
                    sFServer.Add(sFile);
                    iSTTFile = iSTTFile + 1;
                }
                catch 
                { }
            }
            return new Mod.MFileServer(sGoc, sFServer);
            
        }

        public bool KiemFileTonTaiServer(string sFile)
        {
            try
            {
                return System.IO.File.Exists(sFile);

                //string SERVER_PATH = "";
                //SERVER_PATH = SqlHelper.ExecuteScalar(Com.Mod.CNStr, CommandType.Text, "SELECT TOP 1 DUONG_DAN_TL FROM dbo.THONG_TIN_CHUNG").ToString();

                //using (new ConnectToSharedFolder(SERVER_PATH, new NetworkCredential(Com.Mod.sUserSer, Com.Mod.sPassSer)))
                //{
                //    return (System.IO.File.Exists(sFile));
                //}
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return false;
            }
        }

        public string STTFileCungThuMuc(string sThuMuc, string sFile,string sFileGoc)
        {
            string TenFile = sFile;
            string DuoiFile;
            try
            {
                DuoiFile = LayDuoiFile(sFile);
            }
            catch 
            {
                DuoiFile = "";
            }


            try
            {
                string[] sTongFile;
                //int i = 1;

                TenFile = sFile;
                try  
                {
                    sTongFile = System.IO.Directory.GetFiles(sThuMuc);  //truong hop thu muc kg có file nao, catch va lay lun gten file do


                    List<string> filterKeywords = new List<string>() { sFileGoc };
                    List<string> sRe;
                    var result = from p in sTongFile
                                 where filterKeywords.Any(val => p.Contains(val))
                                 select p;

                    sRe = result.ToList();
                    TenFile = sFileGoc + "." + (sRe.Count + 1).ToString().PadLeft(3, '0') + System.IO.Path.GetExtension(sFile);
                }
                catch
                {}
            }
            catch //(Exception ex)
            {
                TenFile = "";
            }

            return TenFile;
        }


        public void OpenHinhServer(string strDuongdan)
        {
            if (strDuongdan.Equals(""))
                return;

            try
            {
                string SERVER_PATH = "";
                SERVER_PATH = SqlHelper.ExecuteScalar(Com.Mod.CNStr, CommandType.Text, "SELECT TOP 1 DUONG_DAN_TL FROM dbo.THONG_TIN_CHUNG").ToString();

                using (new ConnectToSharedFolder(SERVER_PATH, new NetworkCredential(Com.Mod.sUserSer, Com.Mod.sPassSer)))
                {
                    if (File.Exists(strDuongdan))
                    {
                        // If file found, delete it    
                        System.Diagnostics.Process.Start(strDuongdan);
                        return;
                    }
                    else return;
                }
            }
            catch (IOException ioExp)
            {
                XtraMessageBox.Show(ioExp.Message);
                return;
            }

            
        }

        #endregion

        public static void SendEmailCC(string address, string subject, string message)
        {
            try
            {

                //DataTable dt = new DataTable();
                //dt.Load(SqlHelper.ExecuteReader(CMMSConnectionString(), CommandType.Text, "SELECT MAIL_FROM,PASS_MAIL,SMTP_MAIL,PORT_MAIL,LINK_WEB FROM dbo.THONG_TIN_CHUNG"));
                //string str = dt.Rows[0]["PASS_MAIL"].ToString();
                //string password = "";
                //const int _CODE_ = 354;
                //for (int i = 0; i < str.Length; i++)
                //{
                //    password += System.Convert.ToChar(((int)System.Convert.ToChar(str.Substring(i, 1)) / 2) - _CODE_).ToString();
                //}
                //string email = dt.Rows[0]["MAIL_FROM"].ToString();
                //var loginInfo = new NetworkCredential(email, password);
                //var msg = new MailMessage();
                //var smtpClient = new SmtpClient(dt.Rows[0]["SMTP_MAIL"].ToString());
                //msg.From = new MailAddress(email, "ANDON -  WAHL");
                //var mail = address.Split(';');
                //foreach (var item in mail)
                //{
                //    if (item.Trim() != "")
                //    {
                //        msg.To.Add(new MailAddress(item));
                //    }
                //}
                //msg.Subject = subject;
                //msg.Body = message;
                //msg.IsBodyHtml = true;
                //msg.SubjectEncoding = Encoding.UTF8;
                //msg.BodyEncoding = Encoding.UTF8;
                ////msg.Priority = MailPriority.High;
                //smtpClient.EnableSsl = true;
                //smtpClient.UseDefaultCredentials = false;
                //smtpClient.Credentials = loginInfo;
                //smtpClient.Send(msg);
            }
            catch
            {

            }
        }


        public static void SendEmailCC(string address, string CC, string subject, string message)
        {
            try
            {

                //DataTable dt = new DataTable();
                //dt.Load(SqlHelper.ExecuteReader(, CommandType.Text, "SELECT MAIL_FROM,PASS_MAIL,SMTP_MAIL,PORT_MAIL,LINK_WEB FROM dbo.THONG_TIN_CHUNG"));
                //string str = dt.Rows[0]["PASS_MAIL"].ToString();
                //string password = "";
                //const int _CODE_ = 354;
                //for (int i = 0; i < str.Length; i++)
                //{
                //    password += System.Convert.ToChar(((int)System.Convert.ToChar(str.Substring(i, 1)) / 2) - _CODE_).ToString();
                //}
                //string email = dt.Rows[0]["MAIL_FROM"].ToString();
                //var loginInfo = new NetworkCredential(email, password);
                //var msg = new MailMessage();
                //var smtpClient = new SmtpClient(dt.Rows[0]["SMTP_MAIL"].ToString());
                //msg.From = new MailAddress(email, "ANDON -  WAHL");
                //var mail = address.Split(';');
                //foreach (var item in mail)
                //{
                //    msg.To.Add(new MailAddress(item));
                //}
                //var mailcc = CC.Split(';');
                //try
                //{
                //    foreach (var item in mailcc)
                //    {
                //        msg.CC.Add(new MailAddress(item));
                //    }
                //}
                //catch
                //{
                //}
                //msg.Subject = subject;
                //msg.Body = message;
                //msg.IsBodyHtml = true;
                //msg.SubjectEncoding = Encoding.UTF8;
                //msg.BodyEncoding = Encoding.UTF8;
                ////msg.Priority = MailPriority.High;
                //smtpClient.EnableSsl = true;
                //smtpClient.UseDefaultCredentials = false;
                //smtpClient.Credentials = loginInfo;
                //smtpClient.Send(msg);
            }
            catch
            {
            }
        }
        #region Copy and Paste
        public string MClipboardData
        {
            get
            {
                IDataObject iData = Clipboard.GetDataObject();
                if (string.IsNullOrEmpty(iData.ToString()))
                {
                    return "";
                }

                if (iData.GetDataPresent(DataFormats.UnicodeText))
                {
                    return (string)iData.GetData(DataFormats.UnicodeText);
                }
                return "";
            }
            set { Clipboard.SetDataObject(value); }
        }

        public void MSetValuePaste(GridView grv, string sRowValue, int iColValue, string sCol, int iRow)
        {
            string sTmp = sRowValue.Split(new char[] { '\r', '\t' })[iColValue];
            float fTmp = 0;
            try { fTmp = float.Parse(sTmp); } catch { fTmp = 0; }
            if (fTmp > 0)
                grv.SetRowCellValue(iRow, sCol, fTmp);
            else
                grv.SetRowCellValue(iRow, sCol, DBNull.Value);

        }
        #endregion
        public string MChechkMail(string MMail) //;
        {
            var mEMail = MMail.Split(';');
            try
            {
                foreach (var item in mEMail)
                {
                    if (item.Trim() != "")
                    {
                        var addr = new System.Net.Mail.MailAddress(item);
                        if (addr.Address != item)
                        {
                            return item.ToString() + " : " + Com.Mod.OS.GetLanguage("frmChung", "sKhongPhaiMail"); 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
            return "";
            
        }

        //Check server demo
        public bool checkVerDemo(Int64 idCustomer, Int64 idContract, int LoaiSP, out DateTime dNgayHH)
        {
            DateTime dNgay = DateTime.Now;
            dNgayHH = dNgay;
            try
            {
                DataTable dt = new DataTable();
                dt = getDataAPI("https://api.vietsoft.com.vn/VS.Api/Support/getLicense?NNgu=0&idCustomer=" + idCustomer + "&idContract=" + idContract + "&ID_LSP=" + LoaiSP + "");
                try
                {
                    dNgayHH = Convert.ToDateTime(dt.Rows[0]["NGAY_DEMO"]);
                }
                catch { }

                if (Convert.ToBoolean(dt.Rows[0]["HH_DEMO"]))
                    return true;
                else
                    return false;
            }
            catch
            {
                return true;
            }
        }

    }

}
