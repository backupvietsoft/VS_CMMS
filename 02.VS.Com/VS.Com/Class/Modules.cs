
using System;
using System.Collections.Generic;

using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Net;
using System.Threading;

namespace Com
{

    public class Mod
    {
        private static string _ModuleName;
        private static string myHost = System.Net.Dns.GetHostName();
        
        public static List<string> lstControlName
        {
            get
            {
                return _lstControlName;
            }
            set
            {
                _lstControlName = value;
            }
        }
        private static List<string> _lstControlName = new List<string>(new string[] { "LookUpEdit", "RadioButton", "CheckBox", "GroupBox", "TabPage", "LabelControl", "CheckButton", "CheckEdit", "XtraTabPage", "GroupControl", "Button", "SimpleButton", "RadioGroup", "CheckedListBoxControl", "XtraTabControl", "GridControl", "DataGridView", "DataGridViewNew", "DataGridViewEditor", "NavBarControl", "navBarControl", "BarManager", "TextEdit", "tablePanel", "navigationFrame", "navigationPage", "LayoutControlGroup", "TabbedControlGroup" });

        //dinh nghia size Form Toan Cuc
        private static System.Drawing.Size _Size2P3;
        public static System.Drawing.Size Size2P3
        {
            get
            {
                return _Size2P3;
            }
            set
            {
                _Size2P3 = value;
            }
        }
        //System.IO.MemoryStream mem;
        //dinh file logo cong ty
        private static System.IO.MemoryStream _mLogoCty;
        public static System.IO.MemoryStream mLogoCty
        {
            get
            {
                return _mLogoCty;
            }
            set
            {
                _mLogoCty = value;
            }
        }
        //dinh nghia location Form Toan Cuc
        private static System.Drawing.Point _Point1P3;
        public static System.Drawing.Point Point1P3
        {
            get
            {
                return _Point1P3;
            }
            set
            {
                _Point1P3 = value;
            }
        }

        //dinh nghia size Form Toan Cuc
        private static System.Drawing.Size _Size1P2;
        public static System.Drawing.Size Size1P2
        {
            get
            {
                return _Size1P2;
            }
            set
            {
                _Size1P2 = value;
            }
        }

        //dinh nghia location Form Toan Cuc
        private static System.Drawing.Point _Point1P2;
        public static System.Drawing.Point Point1P2
        {
            get
            {
                return _Point1P2;
            }
            set
            {
                _Point1P2 = value;
            }
        }
        private static string _sUrlCheckServer;
        public static string sUrlCheckServer
        {
            get
            {
                return _sUrlCheckServer;
            }
            set
            {
                _sUrlCheckServer = value;
            }
        }

        //Kiểm tra server demo
        private static string _iCheckDemo;
        public static string iCheckDemo
        {
            get
            {
                return _iCheckDemo;
            }
            set
            {
                _iCheckDemo = value;
            }
        }

        private static string _dCheckDemoDate;
        public static string dCheckDemoDate
        {
            get
            {
                return _dCheckDemoDate;
            }
            set
            {
                _dCheckDemoDate = value;
            }
        }
        //--------------------

        private static Boolean _bDDTL;
        public static Boolean bDDTL
        {
            get
            {
                return _bDDTL;
            }
            set
            {
                _bDDTL = value;
            }
        }
        //dinh nghia ID cho cac form danh muc khi tra ve
        private static string _sId;
        public static string sId
        {
            get
            {
                return _sId;
            }
            set
            {
                _sId = value;
            }
        }

        private static string _sLoad;
        public static string sLoad
        {
            get
            {
                return _sLoad;
            }
            set
            {
                _sLoad = value;
            }
        }


        private static string _sFontSys;
        public static string sFontSys
        {
            get
            {
                return _sFontSys;
            }
            set
            {
                _sFontSys = value;
            }
        }

        private static DateTime _DemoDate;
        public static DateTime DemoDate
        {
            get
            {
                return _DemoDate;
            }
            set
            {
                _DemoDate = value;
            }
        }
        private static bool _LicDemo;
        public static bool LicDemo
        {
            get
            {
                return _LicDemo;
            }
            set
            {
                _LicDemo = value;
            }
        }

        private static bool _LicServer;
        public static bool LicServer
        {
            get
            {
                return _LicServer;
            }
            set
            {
                _LicServer = value;
            }
        }

        private static string _sDDTaiLieu;
        public static string sDDTaiLieu
        {
            get
            {
                return _sDDTaiLieu;
            }
            set
            {
                _sDDTaiLieu = value;
            }
        }

        private static string _sDDTaiLieuCloud;
        public static string sDDTaiLieuCloud
        {
            get
            {
                return _sDDTaiLieuCloud;
            }
            set
            {
                _sDDTaiLieuCloud = value;
            }
        }

        //dinh nghia cau store dung cho toan bo danh muc
        private static string _sPS;
        public static string sPS
        {
            get
            {
                return _sPS;
            }
            set
            {
                _sPS = value;
            }
        }
        private static Int64 _iCongNhan;
        public static Int64 iCongNhan
        {
            get
            {
                return _iCongNhan;
            }
            set
            {
                _iCongNhan = value;
            }
        }

        //dinh nghia phan quyen       //1 Full ,2Read Only,3No access
        //dtTempt.Rows.Add(1, "Full access");
        //dtTempt.Rows.Add(2, "Read Only");
        private static int _iPermission;
        public static int iPermission
        {
            get
            {
                return _iPermission;
            }
            set
            {
                _iPermission = value;
            }
        }

        private static string _sExcelTemp;
        public static string sExcelTemp
        {
            get
            {
                return _sExcelTemp;
            }
            set
            {
                _sExcelTemp = value;
            }
        }


        public static string ModuleName
        {
            get
            {
                return _ModuleName;
            }
            set
            {
                _ModuleName = value;
            }
        }

        private static string _UserName = string.Empty;
        public static string UName
        {
            get
            {
                return _UserName;
            }
            set
            {
                _UserName = value;
            }
        }

        private static int _TypeLanguage = 0;
        public static int iNNgu
        {
            get
            {
                return _TypeLanguage;
            }
            set
            {
                _TypeLanguage = value;
            }
        }


        private static OSystems _OSys = new OSystems();
        public static OSystems OS
        {
            get
            {
                return _OSys;
            }
            set
            {
                _OSys = value;
            }
        }
        private static MExcel _MExcel = new MExcel();
        public static MExcel MExcel
        {
            get
            {
                return _MExcel;
            }
            set
            {
                _MExcel = value;
            }
        }
        private static int _iRun;
        public static int iRun
        {
            get
            {
                return _iRun;
            }
            set
            {
                _iRun = value;
            }
        }


        private static int _iLic =-1;
        public static int iLic
        {
            get
            {
                return _iLic;
            }
            set
            {
                _iLic = value;
            }
        }
        
        
        // Xac dinh thong tin cong ty
        private static string _sPrivate;
        public static string sPrivate
        {
            get
            {
                return _sPrivate.ToUpper();
            }
            set
            {
                _sPrivate = value.ToUpper();
            }
        }

        private static int _UserID;
        public static int UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                _UserID = value;
            }
        }

        private static int _GroupID;
        public static int GroupID
        {
            get
            {
                return _GroupID;
            }
            set
            {
                _GroupID = value;
            }
        }

        private static int _iSoLeSL;
        public static int iSoLeSL
        {
            get
            {
                return _iSoLeSL;
            }
            set
            {
                _iSoLeSL = value;
            }
        }

        private static int _iSoLeDG;
        public static int iSoLeDG
        {
            get
            {
                return _iSoLeDG;
            }
            set
            {
                _iSoLeDG = value;
            }
        }

        private static int _iSoLeTT;
        public static int iSoLeTT
        {
            get
            {
                return _iSoLeTT;
            }
            set
            {
                _iSoLeTT = value;
            }
        }

        private static int _iSoLeCP;
        public static int iSoLeCP
        {
            get
            {
                return _iSoLeCP;
            }
            set
            {
                _iSoLeCP = value;
            }
        }

        private static int _iLamTron;
        public static int iLamTron
        {
            get
            {
                return _iLamTron;
            }
            set
            {
                _iLamTron = value;
            }
        }


        private static int _iSLVAT;
        public static int iSLVAT
        {
            get
            {
                return _iSLVAT;
            }
            set
            {
                _iSLVAT = value;
            }
        }


        private static int _iSLPTram;
        public static int iSLPTram
        {
            get
            {
                return _iSLPTram;
            }
            set
            {
                _iSLPTram = value;
            }
        }

        private static int _iSLTyGia;
        public static int iSLTyGia
        {
            get
            {
                return _iSLTyGia;
            }
            set
            {
                _iSLTyGia = value;
            }
        }

        private static int _iSLDinhMuc;
        public static int iSLDinhMuc
        {
            get
            {
                return _iSLDinhMuc;
            }
            set
            {
                _iSLDinhMuc = value;
            }
        }



        private static string _sSLVAT;

        public static string sSLVAT
        {
            get
            {
                return _sSLVAT;
            }
            set
            {
                _sSLVAT = value;
            }
        }


        private static string _sSoLeSL;

        public static string sSoLeSL
        {
            get
            {
                return _sSoLeSL;
            }
            set
            {
                _sSoLeSL = value;
            }
        }

        private static string _sSoLeDG;
        public static string sSoLeDG
        {
            get
            {
                return _sSoLeDG;
            }
            set
            {
                _sSoLeDG = value;
            }
        }

        private static string _sSoLeTT;
        public static string sSoLeTT
        {
            get
            {
                return _sSoLeTT;
            }
            set
            {
                _sSoLeTT = value;
            }
        }

        private static string _sSoLeTyGia;
        public static string sSoLeTyGia
        {
            get
            {
                return _sSoLeTyGia;
            }
            set
            {
                _sSoLeTyGia = value;
            }
        }

        private static string _sSLDinhMuc;
        public static string sSLDinhMuc
        {
            get
            {
                return _sSLDinhMuc;
            }
            set
            {
                _sSLDinhMuc = value;
            }
        }


        private static string _sSLPTram;
        public static string sSLPTram
        {
            get
            {
                return _sSLPTram;
            }
            set
            {
                _sSLPTram = value;
            }
        }



        private static string _sTenNhanVienMD;
        public static string sTenNhanVienMD
        {
            get
            {
                return _sTenNhanVienMD;
            }
            set
            {
                _sTenNhanVienMD = value;
            }
        }

        private static string _sMaNhanVienMD;
        public static string sMaNhanVienMD
        {
            get
            {
                return _sMaNhanVienMD;
            }
            set
            {
                _sMaNhanVienMD = value;
            }
        }

        private static string _sInfoSer;
        public static string sInfoSer
        {
            get
            {
                return _sInfoSer;
            }
            set
            {
                _sInfoSer = value;
            }
        }

        private static string _sInfoClient;
        public static string sInfoClient
        {
            get
            {
                return _sInfoClient;
            }
            set
            {
                _sInfoClient = value;
            }
        }

        //private static Data _Data = new Data();
        //public static Data Data
        //{
        //    get
        //    {
        //        return _Data;
        //    }
        //    set
        //    {
        //        _Data = value;
        //    }
        //}



        private static string _sTenCTy;
        public static string sTenCTy
        {
            get
            {
                return _sTenCTy;
            }
            set
            {
                _sTenCTy = value;
            }
        }




        private static string _sDiaChi;
        public static string sDiaChi
        {
            get
            {
                return _sDiaChi;
            }
            set
            {
                _sDiaChi = value;
            }
        }


        private static string _sDienThoai;
        public static string sDienThoai
        {
            get
            {
                return _sDienThoai;
            }
            set
            {
                _sDienThoai = value;
            }
        }


        private static string _sFax;
        public static string sFax
        {
            get
            {
                return _sFax;
            }
            set
            {
                _sFax = value;
            }
        }



        private static string _sMail;
        public static string sMail
        {
            get
            {
                return _sMail;
            }
            set
            {
                _sMail = value;
            }
        }

        private static int _iLCTT;
        public static int iLCTT
        {
            get
            {
                return _iLCTT;
            }
            set
            {
                _iLCTT = value;
            }
        }


        private static string _sTenLCTT;
        public static string sTenLCTT
        {
            get
            {
                return _sTenLCTT;
            }
            set
            {
                _sTenLCTT = value;
            }
        }

        private static string _sUserSer;
        public static string sUserSer
        {
            get
            {
                return _sUserSer;
            }
            set
            {
                _sUserSer = value;
            }
        }

        private static string _sPassSer;
        public static string sPassSer
        {
            get
            {
                return _sPassSer;
            }
            set
            {
                _sPassSer = value;
            }
        }


        private static int _iSysTT;
        public static int iSysTT
        {
            get
            {
                return _iSysTT;
            }
            set
            {
                _iSysTT = value;
            }
        }

        private static string _sTenSysTT;
        public static string sTenSysTT
        {
            get
            {
                return _sTenSysTT;
            }
            set
            {
                _sTenSysTT = value;
            }
        }


        private static float _LogoLeft;
        public static float LogoLeft
        {
            get
            {
                return _LogoLeft;
            }
            set
            {
                _LogoLeft = value;
            }
        }

        private static float _LogoTop;
        public static float LogoTop
        {
            get
            {
                return _LogoTop;
            }
            set
            {
                _LogoTop = value;
            }
        }

        private static float _LogoWidth;
        public static float LogoWidth
        {
            get
            {
                return _LogoWidth;
            }
            set
            {
                _LogoWidth = value;
            }
        }

        private static float _LogoHeight;
        public static float LogoHeight
        {
            get
            {
                return _LogoHeight;
            }
            set
            {
                _LogoHeight = value;
            }
        }

        #region  Connect




        private static string _Server;
        public static string Server
        {
            get
            {
                return _Server;
            }
            set
            {
                _Server = value;
            }
        }

        private static string _Database;
        public static string Database
        {
            get
            {
                return _Database;
            }
            set
            {
                _Database = value;
            }
        }


        private static int _iSoLeDGSC;
        public static int iSoLeDGSC
        {
            get
            {
                return _iSoLeDGSC;
            }
            set
            {
                _iSoLeDGSC = value;
            }
        }

        private static string _sSoLeTTSC;
        public static string sSoLeTTSC
        {
            get
            {
                return _sSoLeTTSC;
            }
            set
            {
                _sSoLeTTSC = value;
            }
        }


        private static int _iSoLeTTSC;
        public static int iSoLeTTSC
        {
            get
            {
                return _iSoLeTTSC;
            }
            set
            {
                _iSoLeTTSC = value;
            }
        }


        private static string _sSoLeDGSC;
        public static string sSoLeDGSC
        {
            get
            {
                return _sSoLeDGSC;
            }
            set
            {
                _sSoLeDGSC = value;
            }
        }



        private static float _VATMD = 10;
        public static float VATMD
        {
            get
            {
                return _VATMD;
            }
            set
            {
                _VATMD = value;
            }
        }
        

        private static string _Username;
        public static string UserDB
        {
            get
            {
                return _Username;
            }
            set
            {
                _Username = value;
            }
        }

        private static string _Password;
        public static string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }

        public static string CNStr
        {
            get
            {
                return "Server=" + _Server + ";database=" + _Database + ";uid=" + _Username + ";pwd=" + _Password + ";Connect Timeout=9999;";
            }
        }

        public class MFileServer
        {
            public MFileServer(List<string> sFileGoc, List<string> sFileServer)
            {
                this.sfilegoc = sFileGoc;
                this.sfileserver = sFileServer;
                //this.snamefile = sFileServer;
            }


            public List<string> sfilegoc;
            public List<string> sfileserver;
            //public List<string> snamefile;
        }

        #endregion


    }

public class ConnectToSharedFolder : IDisposable
    {
        readonly string _networkName;
        public ConnectToSharedFolder(string networkName, NetworkCredential credentials)
        {
            Com.Mod.bDDTL = true;
            try
            {
                _networkName = networkName;
                var netResource = new NetResource
                {
                    Scope = ResourceScope.GlobalNetwork,
                    ResourceType = ResourceType.Disk,
                    DisplayType = ResourceDisplaytype.Share,
                    RemoteName = networkName
                };

                var userName = string.IsNullOrEmpty(credentials.Domain)
                    ? credentials.UserName
                    : string.Format(@"{0}\{1}", credentials.Domain, credentials.UserName);
                var result = 1;
                Thread thread = new Thread(() =>
                {
                    result = WNetAddConnection2(
                   netResource,
                   credentials.Password,
                   userName,
                   0);
                }, 2000);
                thread.Start();
                Thread.Sleep(2000);
                
                if (result != 0 && result != 1219)
                {
                    //throw new Win32Exception(result, "Error connecting to remote share");
                    Com.Mod.bDDTL = false;
                }
            }
            catch { Com.Mod.bDDTL = false; }
        }
        /// <summary>
        /// //chu y
        /// </summary>
        ConnectToSharedFolder()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            WNetCancelConnection2(_networkName, 0, true);
        }

        [DllImport("mpr.dll")]
        private static extern int WNetAddConnection2(NetResource netResource,
            string password, string username, int flags);

        [DllImport("mpr.dll")]
        private static extern int WNetCancelConnection2(string name, int flags,
            bool force);

        [StructLayout(LayoutKind.Sequential)]
        public class NetResource
        {
            public ResourceScope Scope;
            public ResourceType ResourceType;
            public ResourceDisplaytype DisplayType;
            public int Usage;
            public string LocalName;
            public string RemoteName;
            public string Comment;
            public string Provider;
        }

        public enum ResourceScope : int
        {
            Connected = 1,
            GlobalNetwork,
            Remembered,
            Recent,
            Context
        };

        public enum ResourceType : int
        {
            Any = 0,
            Disk = 1,
            Print = 2,
            Reserved = 8,
        }

        public enum ResourceDisplaytype : int
        {
            Generic = 0x0,
            Domain = 0x01,
            Server = 0x02,
            Share = 0x03,
            File = 0x04,
            Group = 0x05,
            Network = 0x06,
            Root = 0x07,
            Shareadmin = 0x08,
            Directory = 0x09,
            Tree = 0x0a,
            Ndscontainer = 0x0b
        }
    }




}
