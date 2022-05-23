using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace KakaoMSG
{
    public partial class ConfigWnd : Form
    {
        public ConfigWnd()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.None;
        }
        static HttpClient client = new HttpClient();
        public delegate void ChildFormSendDataHandler(UserConfig _uc);
        public event ChildFormSendDataHandler ChildFormEvent;
        UserConfig userConfig;

        JsonSerializerOptions jsonoption = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            WriteIndented = true
        };

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveConfig();
        }


        void SaveConfig()
        {

            //UserConfig _uc = new UserConfig();
            userConfig.SetUserCofing(txtWOD.Text, txtMSD.Text, txtImgSize.Text, txtISD.Text);

            string jsonstr = JsonSerializer.Serialize(userConfig, jsonoption);


            var httpreqmsg = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://222.122.203.68/api/configsave"),
                Headers =
                {
                    {  HttpRequestHeader.Accept.ToString(), "application/json" },
                    {  "userid", userConfig.getUserID() }
                },
                Content = new StringContent(jsonstr, Encoding.UTF8, "application/json")
            };

            var response = client.SendAsync(httpreqmsg).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                this.DialogResult = DialogResult.OK;
                this.ChildFormEvent(userConfig);
                this.Close();
            }
        }

        public void setUserConfig(UserConfig _uc)
        {
            txtWOD.Text = (_uc.getWodTime() / 1000).ToString();
            txtMSD.Text = (_uc.getMsdTime() / 1000).ToString();
            txtImgSize.Text = (_uc.getImgSize() ).ToString();
            txtISD.Text = (_uc.getIsdTime() / 1000).ToString();
            userConfig = _uc;
        }
    }
}
