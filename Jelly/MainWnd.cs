using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KakaoMSG
{

    public partial class MainWnd : Form
    {
        static HttpClient client = new HttpClient();

        public class Friend
        {
            public string name { get; set; }
        }

        public class Group
        {
            public string name { get; set; }
        }

        public class SendHistory
        {
            public string send_dt { get; set; }
            public int count { get; set; }
        }

        public class GFriend
        {
            public string name { get; set; }
            public List<Friend>  friends { get; set; }
        }

        public MainWnd(int[] version)
        {
            InitializeComponent();
            //client.BaseAddress = new Uri("http://222.122.203.68/");
            this.Text = "Jelly ( " + version[0] + "." + version[1] + "." + version[2] + " )" ;
 
        }

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string IpClassName, string IpWindowName);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hWnd1, IntPtr hWnd2, string Ipsz1, string Ipsz2);

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hwnd, int wMsg, int wParam, int IParam);

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hwnd, int wMsg, int wParam, string IParam);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        public static extern IntPtr PostMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern void keybd_event(uint vk, uint scan, uint flags, uint extraInfo);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern Int32 GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("user32.dll")]
        public static extern IntPtr SetFocus(IntPtr handle);

        const int WM_KEYDOWN = 0x100;
        const int WM_KEYUP = 0x101;
        const int WM_CLOSE = 0x0010;
        const int WM_QUIT = 0x12;
        const int WM_SYSCOMMAND = 0x0112;
        const int WM_SETTEXT = 0x000c;

        const int SC_CLOSE = 0xf060;

        const int VK_HOME = 0x24;
        const int VK_DOWN = 0x28;
        const int VK_END = 0x23;
        const int VK_ENTER = 0x0d;
        const int VK_CONTROL = 0x11;
        const int VK_T = 0x54;
        const int VK_F = 0x46;
        const int VK_ESC = 0x1b;

        const int LB_GETCOUNT = 0x018B;
        const int LB_SETCURSEL = 0x0186;
        const int LB_GETTEXTLEN = 0x018A;
        const int LB_GETTEXT = 0x0189;
        const int LB_GETITEMDATA = 0x0199;
        const int WM_LBUTTONDBLCLK = 0x0203;
        const int LB_FINDSTRING = 0x018F;
        const int LB_FINDSTRINGEXACT = 0x01A2;

        string imgAttacheName = "";

        public static string UserID = "";

        static IntPtr nhwnd = IntPtr.Zero;

        public UserConfig userConfig = new UserConfig();

        JsonSerializerOptions jsonoption = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            WriteIndented = true
        };

        private void btnFindFriend_Click(object sender, EventArgs e)
        {
            CloseMSGWindow();

            uint pid;
            
            if(nhwnd == IntPtr.Zero)
            {
                nhwnd = SearchKakoWindow();
            }

            if (nhwnd != IntPtr.Zero)
            {
                GetWindowThreadProcessId(nhwnd, out pid);


                IntPtr chw = FindWindowEx(nhwnd, IntPtr.Zero, "EVA_ChildWindow", null);
                
                IntPtr ew = SearchWindowHandle(chw, "EVA_Window", "ContactList");
                
                IntPtr lstWH = SearchWindowHandle(ew, "EVA_VH_ListControl_Dblclk", "ContactList");

                  if (lstWH != IntPtr.Zero)
                {
                    StringBuilder sbWinText = new StringBuilder(260);
                    //GetWindowText( lstWH, sbWinText, 260);
                    //listBox1.Items.Add(sbWinText.ToString());
                    friendList.Items.Clear();
                    IntPtr prv_friend_id = IntPtr.Zero;
                    IntPtr cur_friend_id = IntPtr.Zero;
                    String cur_friend = "";

                    bool is_FW_Find = true;

                    SendKeyDown(lstWH, VK_HOME);
                    //SendKeyDown(lstWH, VK_DOWN);
                    //SendKeyDown(lstWH, VK_DOWN);
                    //SendKeyDown(lstWH, VK_DOWN);
                    //SendKeyDown(lstWH, VK_DOWN);

                    while (is_FW_Find)
                    {
                        SendKeyDown(lstWH, VK_DOWN);
                        SendKeyDown(lstWH, VK_ENTER);

                        //IntPtr topwh = GetForegroundWindow();

                        IntPtr temp = IntPtr.Zero;
                        bool isGo = true;
                        IntPtr topwh = IntPtr.Zero;

                        while (isGo)
                        {
                            topwh = FindWindowEx(IntPtr.Zero, temp, "#32770", null);
                            if (topwh != IntPtr.Zero)
                            {
                                uint cpid;
                                GetWindowThreadProcessId(topwh, out cpid);

                                if (cpid == pid)
                                {
                                    isGo = false;
                                }
                                else
                                {
                                    temp = topwh;
                                }
                            }
                            else
                            {
                                isGo = false;
                            }
                        }


                        if (topwh != IntPtr.Zero)
                        {
                            GetWindowText(topwh, sbWinText, 260);
                            cur_friend = sbWinText.ToString().Trim();
                            cur_friend_id = topwh;
                            //listBox1.Items.Add(sbWinText.ToString());
                            //#32770 (대화 상자)
                            if (cur_friend.Length > 0)
                            {
                                if (prv_friend_id != cur_friend_id)
                                {
                                    friendList.Items.Add(cur_friend);
                                    if (prv_friend_id != IntPtr.Zero)
                                    {
                                        SendMessage(prv_friend_id, WM_SYSCOMMAND, SC_CLOSE, 0);
                                        Delay(200);
                                    }
                                    friendList.SelectedIndex = friendList.Items.Count - 1;
                                    prv_friend_id = cur_friend_id;
                                }
                                else
                                {
                                    is_FW_Find = false;
                                }

                            }
                        }

                    }
                    if (prv_friend_id != IntPtr.Zero)
                    {
                        SendMessage(prv_friend_id, WM_SYSCOMMAND, SC_CLOSE, 0);
                        Delay(200);
                    }

                }
                else
                {
                    MessageBox.Show("카카오톡 실행 상태를 확인 하세요.");
                }

            } 
            else
            {
                MessageBox.Show("카카오톡 실행 상태를 확인 하세요.");
            }

        }


        private Boolean SearchMyName()
        {
            Boolean isOK = true;
            CloseMSGWindow();

            if (nhwnd == IntPtr.Zero)
            {
                nhwnd = SearchKakoWindow();
            }

            uint pid;

            if (nhwnd != IntPtr.Zero)
            {
                GetWindowThreadProcessId(nhwnd, out pid);

                IntPtr chw = SearchWindowHandle(nhwnd, "EVA_ChildWindow", "OnlineMainView");

                IntPtr ew = SearchWindowHandle(chw, "EVA_Window", "ContactList");

                SendMessage(ew, 0x0018, 0x001, 0);

                bool isFind = true;
                IntPtr preWH = IntPtr.Zero;
                IntPtr lstWH = IntPtr.Zero;

                while (isFind)
                {
                    IntPtr ev_list = FindWindowEx(ew, preWH, "EVA_VH_ListControl_Dblclk", null);
                    if (ev_list != IntPtr.Zero)
                    {
                        preWH = ev_list;

                        StringBuilder sbWinText = new StringBuilder(260);
                        GetWindowText(ev_list, sbWinText, 260);

                        if (sbWinText.ToString().Contains("ContactList"))
                        {
                            lstWH = ev_list;
                            isFind = false;
                        }
                    }
                    else
                    {
                        isFind = false;
                    }
                }

                if (lstWH != IntPtr.Zero)
                {
                    StringBuilder sbWinText = new StringBuilder(260);

                    IntPtr prv_friend_id = IntPtr.Zero;
                    IntPtr cur_friend_id = IntPtr.Zero;

                    SendKeyDown(lstWH, VK_HOME);
                    SendKeyDown(lstWH, VK_ENTER);

                    IntPtr temp = IntPtr.Zero;
                    bool isGo = true;
                    IntPtr topwh = IntPtr.Zero;
                    IntPtr Kakao_MSG_window_handle = IntPtr.Zero;

                    while (isGo)
                    {
                        topwh = FindWindowEx(IntPtr.Zero, temp, "#32770", null);
                        if (topwh != IntPtr.Zero)
                        {
                            uint cpid;
                            GetWindowThreadProcessId(topwh, out cpid);

                            if (cpid == pid)
                            {
                                isGo = false;
                                Kakao_MSG_window_handle = topwh;
                            }
                            else
                            {
                                temp = topwh;
                            }
                        }
                        else
                        {
                            isGo = false;
                        }
                    }

                    if (Kakao_MSG_window_handle != IntPtr.Zero)
                    {
                        GetWindowText(Kakao_MSG_window_handle, sbWinText, 260);
                        this.Text = this.Text + " - " + sbWinText.ToString();
                        userConfig.KakaoName = sbWinText.ToString();
                        SendMessage(Kakao_MSG_window_handle, WM_SYSCOMMAND, SC_CLOSE, 0);

                    }

                }
                else
                {
                    MessageBox.Show("카카오톡 실행 상태를 확인 하세요.");
                    isOK = false;
                }

            }
            else
            {
                MessageBox.Show("카카오톡 실행 상태를 확인 하세요.");
                isOK = false;
            }

            return isOK;

        }

        public IntPtr SearchWindowHandle(IntPtr parentWH, string ctrlName, string wndName)
        {

            bool isFind = true;
            IntPtr preWH = IntPtr.Zero;
            IntPtr targetWH = IntPtr.Zero;

            while (isFind)
            {
                IntPtr ev_list = FindWindowEx(parentWH, preWH, ctrlName, null);
                if (ev_list != IntPtr.Zero)
                {
                    preWH = ev_list;

                    StringBuilder sbWinText = new StringBuilder(260);
                    GetWindowText(ev_list, sbWinText, 260);

                    if (sbWinText.ToString().Contains(wndName))
                    {
                        targetWH = ev_list;
                        isFind = false;
                    }

                    //listBox1.Items.Add(sbWinText.ToString());
                }
                else
                {
                    isFind = false;
                }
            }
            return targetWH;
        }


        public bool isKakaoRoomWindow(IntPtr wh)
        {

            return false;
        }

        public void SendKeyDown(IntPtr wh, int key)
        {
            PostMessage(wh, WM_KEYDOWN, key, 0);
            PostMessage(wh, WM_KEYUP, key, 0);
            Delay(200);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadDBData();
        }

        void LoadDBData()
        {

            string uc_str = LoadUserConfig().GetAwaiter().GetResult();
            JsonDocument jdoc = JsonDocument.Parse(uc_str);
            foreach (JsonElement element in jdoc.RootElement.EnumerateArray())
            {
                userConfig.SetUserCofing(long.Parse(element.GetProperty("wodtime").GetString()), long.Parse(element.GetProperty("msdtime").GetString()), long.Parse(element.GetProperty("imgsize").GetString()) , UserID,long.Parse(element.GetProperty("isdtime").GetString()));
            }

            string jsonstr = LoadFriend().GetAwaiter().GetResult();

            friendList.Items.Clear();

            jdoc = JsonDocument.Parse(jsonstr);

            foreach (JsonElement element in jdoc.RootElement.EnumerateArray())
            {
                string name = element.GetProperty("name").GetString();
                friendList.Items.Add(name);
            }

            jsonstr = LoadGroup().GetAwaiter().GetResult();

            GList.Items.Clear();

            jdoc = JsonDocument.Parse(jsonstr);

            foreach (JsonElement element in jdoc.RootElement.EnumerateArray())
            {
                string name = element.GetProperty("name").GetString();
                GList.Items.Add(name);
            }

            GFList.Items.Clear();

            jsonstr = LoadSendHistory().GetAwaiter().GetResult();

            SendList.Items.Clear();

            jdoc = JsonDocument.Parse(jsonstr);

            foreach (JsonElement element in jdoc.RootElement.EnumerateArray())
            {
                string SendDt = element.GetProperty("send_dt").GetString();
                string cnt = element.GetProperty("send_count").GetString();
                SendList.Items.Add(SendDt.Substring(0, 13) + "시 : " + cnt + "건 전송 완료");
            }
            
        }

        public void Delay(int ms)
        {
            DateTime dt = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, ms);
            DateTime dta = dt.Add(duration);
            while (dta >= dt)
            {
                System.Windows.Forms.Application.DoEvents();
                dt = DateTime.Now;
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GRList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            /*
            if (e.NewValue == CheckState.Checked && GRList.CheckedItems.Count > 0)
            {
                GRList.ItemCheck -= GRList_ItemCheck;
                GRList.SetItemChecked(GRList.CheckedIndices[0], false);
                GRList.ItemCheck += GRList_ItemCheck;
            }
            
            */
            //Console.WriteLine("" + friendList.Items.Count);
        }

        private void GList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked && GList.CheckedItems.Count > 0)
            {
                GList.ItemCheck -= GList_ItemCheck;
                GList.SetItemChecked(GList.CheckedIndices[0], false);
                GList.ItemCheck += GList_ItemCheck;
            }

        }

        private void btnFLsave_Click(object sender, EventArgs e)
        {
            // 저장.
 
            SaveFriends();

        }

        void SaveFriends()
        {
            List<Friend> fl = new List<Friend>();

            foreach (string data in friendList.Items)
            {
                Friend _fl = new Friend();
                _fl.name = data;

                fl.Add(_fl);
            }

            string jsonstr = JsonSerializer.Serialize(fl, jsonoption);


            var httpreqmsg = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://222.122.203.68/api/friendsave"),
                Headers =
                {
                    {  HttpRequestHeader.Accept.ToString(), "application/json" },
                    {  "userid", UserID }
                },
                Content = new StringContent(jsonstr, Encoding.UTF8, "application/json")
            };

            var response = client.SendAsync(httpreqmsg).Result;
            //response.EnsureSuccessStatusCode();
            //Console.WriteLine(response);
            //return response.Content.ToString();
        }

        async Task<string> LoadFriend()
        {
            var jsonstring = await client.GetStringAsync("http://222.122.203.68/api/friendlist/" + UserID).ConfigureAwait(false);

            
            return jsonstring;
        }

        async Task<string> LoadGroup()
        {
            var jsonstring = await client.GetStringAsync("http://222.122.203.68/api/grouplist/" + UserID).ConfigureAwait(false);


            return jsonstring;
        }

        async Task<string> LoadSendHistory()
        {
            var jsonstring = await client.GetStringAsync("http://222.122.203.68/api/history/" + UserID).ConfigureAwait(false);


            return jsonstring;
        }


        async Task<string> LoadGroupFriend(string group)
        {
            var jsonstring = await client.GetStringAsync("http://222.122.203.68/api/groupfriendlist?userid=" + UserID + "&group=" + group).ConfigureAwait(false);


            return jsonstring;
        }

        async Task<string> LoadUserConfig()
        {
            var jsonstring = await client.GetStringAsync("http://222.122.203.68/api/userconfig/" + UserID ).ConfigureAwait(false);

            return jsonstring;
        }


        private void chkFLall_CheckedChanged(object sender, EventArgs e)
        {
            for(int i=0; i<friendList.Items.Count; i++)
            {
                friendList.SetItemChecked(i, chkFLall.Checked);
            }
        }

        private void chkGFLall_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < GFList.Items.Count; i++)
            {
                GFList.SetItemChecked(i, chkGFLall.Checked);
            }
        }

        private void btnFLremove_Click(object sender, EventArgs e)
        {
            for (int i = friendList.Items.Count; i > 0; i--)
            {
                if(friendList.GetItemChecked(i-1))
                {
                    friendList.Items.RemoveAt(i-1);
                }
            }

        }

        private void btnFLadd_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("친구이름을 입력하세요.", "친구추가", "친구이름");
            if(!friendList.Items.Contains(input))
            {
                friendList.Items.Add(input);
            }
            
        }

        void SaveGroupFriends()
        {
            string group = "";
            GFriend gf = new GFriend();

            foreach (string data in GList.CheckedItems)
            {
                group = data;
            }

            List<Friend> fl = new List<Friend>();

            foreach (string data in GFList.Items)
            {
                Friend _fl = new Friend();
                _fl.name = data;

                fl.Add(_fl);
            }

            gf.name = group;
            gf.friends = fl;

            string jsonstr = JsonSerializer.Serialize(gf, jsonoption);

            var httpreqmsg = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://222.122.203.68/api/groupfriendsave"),
                Headers =
                {
                    {  HttpRequestHeader.Accept.ToString(), "application/json" },
                    {  "userid", UserID },
                },
                Content = new StringContent(jsonstr, Encoding.UTF8, "application/json")
            };

            var response = client.SendAsync(httpreqmsg).Result;
            //response.EnsureSuccessStatusCode();
           // Console.WriteLine(response);
            //return response.Content.ToString();
        }
        void SaveGroup()
        {
            List<Group> gl = new List<Group>();

            foreach (string data in GList.Items)
            {
                Group _gl = new Group();
                _gl.name = data;

                gl.Add(_gl);
            }

            string jsonstr = JsonSerializer.Serialize(gl, jsonoption);


            var httpreqmsg = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://222.122.203.68/api/groupsave"),
                Headers =
                {
                    {  HttpRequestHeader.Accept.ToString(), "application/json" },
                    {  "userid", UserID }
                },
                Content = new StringContent(jsonstr, Encoding.UTF8, "application/json")
            };

            var response = client.SendAsync(httpreqmsg).Result; 
        }

        private void btnGFminus_Click(object sender, EventArgs e)
        {
            for(var i= GFList.Items.Count -1; i>=0; i--)
            {
                if(GFList.GetItemChecked(i))
                {
                    GFList.Items.Remove(GFList.Items[i]);
                }
            }

            SaveGroupFriends();
        }

        private void btnGFadd_Click(object sender, EventArgs e)
        {
            if (GList.CheckedItems.Count == 1)
            {
                if (friendList.CheckedItems.Count > 0)
                {
                    foreach (string data in friendList.CheckedItems)
                    {
                        if (!GFList.Items.Contains(data))
                        {
                            GFList.Items.Add(data);
                        }
                    }

                    SaveGroupFriends();

                }
                else
                {
                    MessageBox.Show("카카오 친구를 선택 하세요.");
                }
            }
            else
            {
                MessageBox.Show("그룹을 선택 하세요.");
            }
        }

        private void GList_SelectedValueChanged(object sender, EventArgs e)
        {


            GFList.Items.Clear();

            string group = (string)GList.SelectedItem;

            string jsonstr = LoadGroupFriend(group).GetAwaiter().GetResult();

            GFriend gf = Newtonsoft.Json.JsonConvert.DeserializeObject<GFriend>(jsonstr);

            foreach(Friend data in gf.friends)
            {
                GFList.Items.Add(data.name);
            }
        }

        private void btnGLadd_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("그룹명을 입력하세요.", "그룹추가", "그룹명");
            if(!GList.Items.Contains(input))
            {
                GList.Items.Add(input);
            }
            SaveGroup();
        }

        private void btnGLdel_Click(object sender, EventArgs e)
        {
            for (int i = GList.Items.Count; i > 0; i--)
            {
                if (GList.GetItemChecked(i - 1))
                {
                    GList.Items.RemoveAt(i - 1);
                }
            }

            SaveGroup();
        }

        public void EventMethod(string str)
        {
            UserID = str;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            nhwnd = SearchKakoWindow();
            if (nhwnd == IntPtr.Zero)
            {
                MessageBox.Show("카카오톡 실행 상태를 확인 하세요.");
                Application.Exit();
            }
            else
            {
                if (SearchMyName())
                {

                    LoginWnd _login = new LoginWnd(userConfig.KakaoName);

                    _login.ChildFormEvent += EventMethod;

                    DialogResult _result = _login.ShowDialog();

                    if (_result != DialogResult.OK)
                    {
                        MessageBox.Show("정상적으로 로그인 되지 않았습니다.");
                        Application.Exit();
                    }

                    LoadDBData();
                } else
                {
                    Application.Exit();
                }
            }

        }
 

        public IntPtr SearchKakoWindow()
        {
            IntPtr kakaoWH = FindWindow(null, "카카오톡");

            return kakaoWH;
        }

        private void btnKakaoMe_Click(object sender, EventArgs e)
        {
            CloseMSGWindow();

            if (nhwnd == IntPtr.Zero)
            {
                nhwnd = SearchKakoWindow();
            }

            uint pid;

            if (nhwnd != IntPtr.Zero)
            {
                GetWindowThreadProcessId(nhwnd, out pid);

                IntPtr chw = SearchWindowHandle(nhwnd, "EVA_ChildWindow", "OnlineMainView");

                IntPtr ew = SearchWindowHandle(chw, "EVA_Window", "ContactList");

                SendMessage(ew, 0x0018, 0x001, 0);

                bool isFind = true;
                IntPtr preWH = IntPtr.Zero;
                IntPtr lstWH = IntPtr.Zero;

                while (isFind)
                {
                    IntPtr ev_list = FindWindowEx(ew, preWH, "EVA_VH_ListControl_Dblclk", null);
                    if (ev_list != IntPtr.Zero)
                    {
                        preWH = ev_list;

                        StringBuilder sbWinText = new StringBuilder(260);
                        GetWindowText(ev_list, sbWinText, 260);

                        if (sbWinText.ToString().Contains("ContactList"))
                        {
                            lstWH = ev_list;
                            isFind = false;
                        }
                    }
                    else
                    {
                        isFind = false;
                    }
                }

                if (lstWH != IntPtr.Zero)
                {
                    StringBuilder sbWinText = new StringBuilder(260);

                    IntPtr prv_friend_id = IntPtr.Zero;
                    IntPtr cur_friend_id = IntPtr.Zero;
                    
                    SendKeyDown(lstWH, VK_HOME);
                    SendKeyDown(lstWH, VK_ENTER);

                    IntPtr temp = IntPtr.Zero;
                    bool isGo = true;
                    IntPtr topwh = IntPtr.Zero;
                    IntPtr Kakao_MSG_window_handle = IntPtr.Zero;

                    while (isGo)
                    {
                        topwh = FindWindowEx(IntPtr.Zero, temp, "#32770", null);
                        if (topwh != IntPtr.Zero)
                        {
                            uint cpid;
                            GetWindowThreadProcessId(topwh, out cpid);

                            if (cpid == pid)
                            {
                                isGo = false;
                                Kakao_MSG_window_handle = topwh;
                            }
                            else
                            {
                                temp = topwh;
                            }
                        }
                        else
                        {
                            isGo = false;
                        }
                    }

                    if(Kakao_MSG_window_handle != IntPtr.Zero)
                    {
                        if(rbImgFirst.Checked)
                        {
                            SendKakaoIMG(Kakao_MSG_window_handle);
                            Delay(500);
                            SendKakaoMSG(Kakao_MSG_window_handle);
                        }
                        else
                        {
                            SendKakaoMSG(Kakao_MSG_window_handle);
                            SendKakaoIMG(Kakao_MSG_window_handle);
                        }
                        
                    }

                }
                else
                {
                    MessageBox.Show("카카오톡 실행 상태를 확인 하세요.");
                }

            }
            else
            {
                MessageBox.Show("카카오톡 실행 상태를 확인 하세요.");
            }

        }

        public void SendKakaoMSG(IntPtr wndID )
        {
            if (txtMsgbox.Text.Length > 0)
            {
                IntPtr editHandle = FindWindowEx(wndID, IntPtr.Zero, "RICHEDIT50W", null);
                SendMessage(editHandle, WM_SETTEXT, 0, txtMsgbox.Text);
                SendKeyDown(editHandle, VK_ENTER);
            }
        }

        public void SendKakaoIMG(IntPtr wndID)
        {
            const int WM_COMMAND = 0x111;
            const int wParam = 0x1807b;

            int isdtime = Convert.ToInt32(userConfig.getIsdTime());

            if(isdtime < 100 )
            {
                isdtime = 100;
                userConfig.setIsdTime(100);
            }

            for(int i = 0; i < lstImageView.Items.Count; i++)
            {
                var fileInfo = new FileInfo(lstImageView.Items[i].Text);
                imgAttacheName = fileInfo.FullName;
                if (imgAttacheName.Length > 0)
                {
                    SendMessage(wndID, WM_COMMAND, wParam, 0);
                    Delay(500);

                    IntPtr IMG_Dialog_WH = FindWindow("#32770", "열기");
                    IntPtr Temp_WH = FindWindowEx(IMG_Dialog_WH, IntPtr.Zero, "ComboBoxEx32", null);
                    Temp_WH = FindWindowEx(Temp_WH, IntPtr.Zero, "ComboBox", null);
                    Temp_WH = FindWindowEx(Temp_WH, IntPtr.Zero, "Edit", null);

                    SendMessage(Temp_WH, WM_SETTEXT, 0, imgAttacheName);
                    SendKeyDown(Temp_WH, VK_ENTER);
                }
                Delay(isdtime); 
            }
        }

        public void CloseMSGWindow()
        {
            IntPtr nhwnd = FindWindow(null, "카카오톡");
            uint pid;

            if (nhwnd != IntPtr.Zero)
            {
                GetWindowThreadProcessId(nhwnd, out pid);

                IntPtr temp = IntPtr.Zero;
                bool isGo = true;
                IntPtr topwh = IntPtr.Zero;

                //List<IntPtr> wdList = new List<IntPtr>();

                while (isGo)
                {
                    topwh = FindWindowEx(IntPtr.Zero, temp, "#32770", null);

                    if (topwh != IntPtr.Zero)
                    {
                        uint cpid;
                        GetWindowThreadProcessId(topwh, out cpid);

                        if (cpid == pid)
                        {
                            SendMessage(topwh, WM_SYSCOMMAND, SC_CLOSE, 0);
                            Delay(200);
                        } else
                        {
                            temp = topwh;
                        }
                    }
                    else
                    {
                        isGo = false;
                    }
                }
            }
        }

        private void txtMsgbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnImgAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Image Files(*.jpg;*.png)|*.jpg;*.png";
            fd.Multiselect = true;
            fd.ReadOnlyChecked = true;
            fd.ShowDialog();
            int idx = 1;
            foreach (string filepath in fd.FileNames)
            {
                if (filepath.Length > 0)
                {
                    String fileName = ".\\img\\" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "_" + idx;

                    DirectoryInfo di = new DirectoryInfo("img");
                    if (di.Exists == false)
                    {
                        di.Create();
                    }

                    Bitmap sendImg = LoadBitmap(filepath);
                    SaveJPGImage(sendImg, fileName, (long)1024 * userConfig.ImgSize);

                    Image image1 = null;

                    using (FileStream stream = new FileStream(fileName + "_F.jpg", FileMode.Open))
                    {
                        image1 = System.Drawing.Image.FromStream(stream);
                    }

                    var imgsize = GetFileSize(fileName + "_F.jpg") / 1024;
                    //labImageSize.Text = String.Format("{0:n0}", imgsize) + " KB";

                    ImageList.Images.Add(fileName, image1);

                    lstImageView.LargeImageList = ImageList;
                    lstImageView.SmallImageList = ImageList;

                    ListViewItem lvitemp = new ListViewItem(fileName + "_F.jpg");
                    lvitemp.SubItems.Add("" + imgsize + " KB");
                    lvitemp.SubItems.Add("" + imgsize + " KB");
                    lvitemp.ImageIndex = ImageList.Images.IndexOfKey(fileName);
                    lstImageView.Items.Add(lvitemp);

                    //picAttacheImg.Image = image1;

                    //var fileInfo = new FileInfo(fileName + "_F.jpg");

                    //imgAttacheName = fileInfo.FullName; // fileName + "_F.jpg";
                }
                idx++;
            }
        }

        public static Bitmap LoadBitmap(string filePath) 
        {
            Bitmap targetBitmap; 
            using (Bitmap sourceBitmap = new Bitmap(filePath)) 
            { 
                targetBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height); 
                using (Graphics targetGraphics = Graphics.FromImage(targetBitmap)) 
                {
                    Rectangle rectangle = new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height);
                    targetGraphics.DrawImage(sourceBitmap, rectangle, rectangle, GraphicsUnit.Pixel);
                } 
            }
            return targetBitmap; 
        }

        public static long GetFileSize(string filePath) 
        { 
            return new FileInfo(filePath).Length; 
        }

        public static void SaveJPGImage(Image image, string filePath, int level, bool final) 
        {
            Image Target = image;

            EncoderParameters encoderParameters = new EncoderParameters(1); 
            encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, level); 
            ImageCodecInfo imageCodecInfo = GetImageCodecInfo("image/jpeg"); 
            
            if(final)
            {
                FileStream imgStream = new FileStream(filePath, FileMode.CreateNew);
                Target.Save(imgStream, imageCodecInfo, encoderParameters);
                imgStream.Close();
                
            } else
            {
                File.Delete(filePath);
                Target.Save(filePath, imageCodecInfo, encoderParameters);
            }
           
        }

        private static ImageCodecInfo GetImageCodecInfo(string mimeType) 
        { 
            ImageCodecInfo[] imageCodecInfoArray = ImageCodecInfo.GetImageEncoders(); 
            for (int i = 0; i <= imageCodecInfoArray.Length; i++) 
            { 
                if (imageCodecInfoArray[i].MimeType == mimeType) 
                { 
                    return imageCodecInfoArray[i]; 
                } 
            } 
            
            return null; 
        }

        public static int SaveJPGImage(Image image, string filePath, long maximumFileSize)
        { 
            const int DELTA = 5; 
            int lessLevel = DELTA; 
            int greaterlevel = (100 / DELTA) * DELTA + DELTA;
            
            for(;;) 
            { 
                int testLevel = (lessLevel + greaterlevel) / 2; 
                testLevel = (testLevel / DELTA) * DELTA; 
                if(testLevel == lessLevel) 
                { 
                    break; 
                } 
                SaveJPGImage(image, filePath + "_T.jpg", testLevel, false); 
                if(GetFileSize(filePath + "_T.jpg") > maximumFileSize) 
                { 
                    greaterlevel = testLevel; 
                } 
                else 
                { 
                    lessLevel = testLevel; 
                } 
            }
            File.Delete(filePath + "_T.jpg");
            SaveJPGImage(image, filePath + "_F.jpg", lessLevel, true); 
            
            return lessLevel; 
        }

        private void btnImgRemove_Click(object sender, EventArgs e)
        {
            for(int i=lstImageView.Items.Count-1; i>=0; i--)
            {
                if(lstImageView.Items[i].Selected)
                {
                    try
                    {
                        File.Delete(lstImageView.Items[i].Text);
                    } catch
                    {
                    }
                    
                    lstImageView.Items.RemoveAt(i);
                }
            }

        }

        private void Control_F(IntPtr wh)
        {
            keybd_event((byte)Keys.ControlKey, 0, 0x00, 0);
            SendKeyDown(wh, VK_F);
            keybd_event((byte)Keys.ControlKey, 0, 0x02, 0);
        }

        private void btnKakaoAll_Click(object sender, EventArgs e)
        {
            CloseMSGWindow();

            if (nhwnd == IntPtr.Zero)
            {
                nhwnd = SearchKakoWindow();
            }

            uint pid;

            if (nhwnd != IntPtr.Zero)
            {
                GetWindowThreadProcessId(nhwnd, out pid);


                IntPtr chw = SearchWindowHandle(nhwnd, "EVA_ChildWindow", "OnlineMainView");

                IntPtr ew = SearchWindowHandle(chw, "EVA_Window", "ContactList");

                SetFocus(ew);

                int wodtime = Convert.ToInt32(userConfig.getWodTime());
                int msdtime = Convert.ToInt32(userConfig.getMsdTime());

                if (wodtime <= 100)
                {
                    wodtime = 100;
                    userConfig.setWodTime(100);
                }

                if (msdtime <= 100)
                {
                    msdtime = 100;
                    userConfig.setMsdTime( 100 );
                }


                if (ew != IntPtr.Zero)
                {
                    ProgressWnd prg = new ProgressWnd();
                    int total = GFList.CheckedItems.Count;
                    int cnt = 0;
                    
                    //SendList.Items.Clear();

                    foreach (string data in GFList.CheckedItems)
                    {
                        //SendKeyDown(ew, VK_ESC);

                        Control_F(ew);

                        IntPtr searchEdith = SearchWindowHandle(ew, "Edit", "");

                        if (searchEdith != IntPtr.Zero)
                        {
                            SendMessage(searchEdith, WM_SETTEXT, 0, data);

                            Delay(100);

                            IntPtr resultWH = SearchWindowHandle(ew, "EVA_VH_ListControl_Dblclk", "SearchListCtrl");

                            if(resultWH != IntPtr.Zero)
                            {
                                SendKeyDown(resultWH, VK_HOME);
                                SendKeyDown(resultWH, VK_ENTER);

                                
                                Delay( wodtime );

                                IntPtr sendWH = SearchWindowHandle(IntPtr.Zero, "#32770", data);

                                if(sendWH != IntPtr.Zero)
                                {
                                    if (rbImgFirst.Checked)
                                    {
                                        SendKakaoIMG(sendWH);
                                        Delay(500);
                                        SendKakaoMSG(sendWH);
                                    }
                                    else
                                    {
                                        SendKakaoMSG(sendWH);
                                        SendKakaoIMG(sendWH);
                                    }

                                    SendMessage(sendWH, WM_SYSCOMMAND, SC_CLOSE, 0);
                                    Delay(200);

                                }
                            }
                            //SendKeyDown(searchEdith, VK_ENTER);

                        }

                        cnt++;
                        prg.setProgressCnt(cnt, total);
                        
                        prg.Show();

                        Delay(msdtime);
 
                    }

                    prg.Close();

                    var SendDt = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
                    SendList.Items.Add(SendDt.Substring(0,13) + "시 : " + cnt + "건 전송 완료");
                    SaveSendHistory(SendDt, cnt);

                    MessageBox.Show(SendDt.Substring(0, 13) + "시 : " + cnt + "건 전송 완료");

                }
                else
                {
                    MessageBox.Show("카카오톡 실행 상태를 확인 하세요.");
                }


            }
            else
            {
                MessageBox.Show("카카오톡 실행 상태를 확인 하세요.");
            }

        }

        void SaveSendHistory(string dt, int count)
        {

            string jsonstr = "{\"send_dt\":\"" + dt + "\",\"count\":" + count + "}";

            var httpreqmsg = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://222.122.203.68/api/historysave"),
                Headers =
                {
                    {  HttpRequestHeader.Accept.ToString(), "application/json" },
                    {  "userid", UserID }
                },
                Content = new StringContent(jsonstr, Encoding.UTF8, "application/json")
            };

            var response = client.SendAsync(httpreqmsg).Result;
        }

        public IntPtr SearchFriendWH(IntPtr kakao_wh, string friend_name)
        {
            IntPtr wh = IntPtr.Zero;

            

            return wh;
        }

        public void UC_EventMethod(UserConfig _uc)
        {
            userConfig = _uc;
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            ConfigWnd _uc = new ConfigWnd();

            _uc.ChildFormEvent += UC_EventMethod;

            _uc.setUserConfig(userConfig);

            DialogResult _result = _uc.ShowDialog();
            
        }

        private void btnGLsave_Click(object sender, EventArgs e)
        {
            SaveGroupFriends();
        }

        private void btnImgUp_Click(object sender, EventArgs e)
        {
            if(lstImageView.SelectedItems.Count != 1)
            {
                MessageBox.Show("하나의 이미지만 선택 하세요.");
            } else
            {
                var selIdx = lstImageView.SelectedIndices[0];

                if (selIdx > 0)
                {
                    ListViewItem temp = lstImageView.Items[selIdx];
                    lstImageView.Items.RemoveAt(selIdx);
                    lstImageView.Items.Insert(selIdx - 1, temp);
                    ListViewReorder();
                } 
            }
        }

        private void ListViewReorder()
        {
            ListView temp = new ListView();
            foreach(ListViewItem item in lstImageView.Items)
            {
                temp.Items.Add(item.Clone() as ListViewItem);
            }

            lstImageView.Items.Clear();

            foreach (ListViewItem item in temp.Items)
            {
                lstImageView.Items.Add(item.Clone() as ListViewItem);
            }
        }

        private void btnImgDown_Click(object sender, EventArgs e)
        {
            if (lstImageView.SelectedItems.Count != 1)
            {
                MessageBox.Show("하나의 이미지만 선택 하세요.");
            }
            else
            {
                var selIdx = lstImageView.SelectedIndices[0];

                if (selIdx < lstImageView.Items.Count -1)
                {
                    ListViewItem temp = lstImageView.Items[selIdx];
                    lstImageView.Items.RemoveAt(selIdx);
                    lstImageView.Items.Insert(selIdx + 1, temp);
                    ListViewReorder();
                }
            }
        }

        private void setupTimer_Tick(object sender, EventArgs e)
        {
            btnConfig.Visible = true;
        }

        private void MainWnd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                //setupTimer.Enabled = true;
            }
            
        }

        private void MainWnd_KeyUp(object sender, KeyEventArgs e)
        {
            setupTimer.Enabled = false;
        }
    }
}
