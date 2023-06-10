using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Reflection;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using ZaloDotNetSDK;
using ZaloDotNetSDK.entities;
using ZaloDotNetSDK.utils;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using DevExpress.Internal.WinApi.Windows.UI.Notifications;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Net.Http;
using DevExpress.XtraPrinting;


namespace VS.CMMS
{
    public partial class frmTestZalo : DevExpress.XtraEditors.XtraForm
    {
        ZaloClient client = new ZaloClient("qN0sOjRbDWlTVJ1cq-0u3zLyEcxU_rnRZHyXOEJgJasFFX10WUHbDCeA0mE2dsGN_dSd9fMLHXhZNKCRhxu6DlqYNIkQs5e4y48XQ-ALTmUHUpKRpEDB3QafAmt9u68mW2G_E_YwHZsmRpHH-uzgEBL31IJTltCyq4jnF8Ua6rJmLabFkgf9B-vpAJgrhMeJ-rK22F6NSHIHVNDwvBCPQxr6HLh9ZKLMcKisOl2VMGp-MGSJZRbu3ifoB3xOcNzUYrKwREUPHXYIMKyiwB8CF81vJphHcJSst5199Swd33UYM5qixxGu8PbGInRvcnSxYbfM8FQnA1keVrntfP1L7grV0tTJFwqmMThpDGe");

        public frmTestZalo()
        {
            InitializeComponent();
        }

        private void frmTestZalo_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private async Task UpdateTokenAsync()
        {

            try
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

                var jsonResponse = JObject.Parse(responseContent);
                var refresh_token = (string)jsonResponse["refresh_token"];
                var access_token = (string)jsonResponse["access_token"];
                var expires_in = (string)jsonResponse["expires_in"];

                txtAccess_token.Text = access_token;
                txtRefresh_token.Text = refresh_token;
                txtTime.Text = expires_in;
            }catch(Exception ex) { }
        }

        private void LoadData()
        {
            try
            {

                JObject listDS = client.getListFollower(0, 50);
                DataTable dt = new DataTable();
                dt.Columns.Add("ID_USER_ZALO");
                dt.Columns.Add("USER_APP");
                dt.Columns.Add("USER_NAME_ZALO");
                JArray followers = (JArray)listDS.SelectToken("data.followers");
                foreach (var follower in followers)
                {
                    DataRow dr = dt.NewRow();
                    JObject UserProfile = client.getProfileOfFollower(follower["user_id"].ToString());
                    if (UserProfile["message"].ToString() == "Success")
                    {
                        dr["ID_USER_ZALO"] = UserProfile["data"]["user_id"].ToString();
                        dr["USER_APP"] = UserProfile["data"]["user_id_by_app"].ToString();
                        dr["USER_NAME_ZALO"] = UserProfile["data"]["display_name"].ToString();
                        dt.Rows.Add(dr);
                    }
                }
                Com.Mod.OS.MLoadXtraGrid(grdZalo, grvZalo, dt, false, false, false, false);
            }
            catch (Exception ex) { }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            try
            {
                string a = grvZalo.GetFocusedRowCellValue("ID_USER_ZALO").ToString();
                ///////client.sendTextMessageToUserId(a, txtZalo.Text);
                //// client.sendImageMessageToMessageIdByUrl(a, "sendImageMessageToMessageIdByUrl" , "https://vietsoft.com.vn/wp-content/uploads/2019/09/cropped-Logo-Vietsoft-2022-150x105.png");
                ///

                client.sendTextMessageToUserId(a, txtZalo.Text);
            }
            catch (Exception ex) { }
        }

        private void btnRefresh_token_Click(object sender, EventArgs e)
        {
            UpdateTokenAsync();
        }
    }
}