using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZaloDotNetSDK;
using System.Net.Http;
using System.Threading.Tasks;



namespace DXApplication1
{
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        //var zaloClient = new ZaloClient("4358550663764184453", "hnrI5iCDB1HKU1HfYdMW");

        
        

        public XtraForm1()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //ZaloAppInfo appInfo = new ZaloAppInfo(4358550663764184453, "hnrI5iCDB1HKU1HfYdMW","");
            //ZaloAppClient appClient = new ZaloAppClient(appInfo);
            ////ZaloAppClient zaloClient = new ZaloAppClient("4358550663764184453", "hnrI5iCDB1HKU1HfYdMW");
            ///

            UpdateTokenAsync();
        }

        private void XtraForm1_Load(object sender, EventArgs e)
        {
            
        }



        private async Task UpdateTokenAsync()
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://oauth.zaloapp.com/v4/oa/access_token");
            request.Headers.Add("secret_key", "B3T08H17cKg18KuOO2Yi");
            var collection = new List<KeyValuePair<string, string>>();
            collection.Add(new KeyValuePair<string, string>("app_id", "454664131441536871"));
            collection.Add(new KeyValuePair<string, string>("refresh_token", "hRloFIJKiHxpXRqEJToJThl5gZm6cevhryUv0GJQjnMyXkG1MjxZBVEypaSzdVq1XSdIMLQiypQfZCCf4TEIEFQ3aYTEq_L8kV3D3m2Yu5NP-k0ND-hMAvw4f71kdUCpaPsh7XpIqXJ8tAfP4pJbET0JdbvfSCz7ZIt3L3nztGZYHfP2AL69bZC0xDJE4UhOlG21-6zfjF-tGCI437ITtzDDs9Pd3v3SspV6gX8AXi_aCPQzNbacFRxnH5gXz1e"));
            collection.Add(new KeyValuePair<string, string>("grant_type", "refresh_token"));

           
            var content = new FormUrlEncodedContent(collection);
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();

        }

    }
}