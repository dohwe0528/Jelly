using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Windows.Forms;

namespace KakaoMSG
{
    public partial class LoginWnd : Form
    {
        static HttpClient client = new HttpClient();
        string kakaoname;
        public class Login
        {
            public string? userid { get; set; }
            public string? password { get; set; }

            public string? kakaoname { get; set; }
        }

        public class LoginResult
        {
            public string? code { get; set; }
            public string? msg { get; set; }
        }

        public delegate void ChildFormSendDataHandler(string msg);
        public event ChildFormSendDataHandler ChildFormEvent;

        public LoginWnd(string _kakaoname)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.None;
            kakaoname = _kakaoname;
#if DEBUG
            txtUserid.Text = "herossg";
            txtPassword.Text = "123455";
#endif
        }

        JsonSerializerOptions jsonoption = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            WriteIndented = true
        };

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginProc();
        }

        private void LoginProc()
        {
            Login _login = new Login();
            _login.userid = txtUserid.Text;
            _login.password = txtPassword.Text;
            _login.kakaoname = kakaoname;

            string jsonstr = JsonSerializer.Serialize(_login, jsonoption);

            var httpreqmsg = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://222.122.203.68/api/loginapi"),
                Headers =
                {
                    {  HttpRequestHeader.Accept.ToString(), "application/json" },
                },
                Content = new StringContent(jsonstr, Encoding.UTF8, "application/json")
            };

            var response = client.SendAsync(httpreqmsg).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                HttpContent content = response.Content;
                LoginResult json = JsonSerializer.Deserialize<LoginResult>(content.ReadAsStringAsync().Result);
                if (json.code == "OK")
                {
                    this.DialogResult = DialogResult.OK;
                    this.ChildFormEvent(txtUserid.Text);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(json.msg);
                }
            }
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Return)
            {
                LoginProc();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                LoginProc();
            }
        }

        private void LoginWnd_Load(object sender, EventArgs e)
        {

        }
    }
}
