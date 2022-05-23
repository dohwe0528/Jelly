using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KakaoMSG
{
    public partial class ProgressWnd : Form
    {
        public ProgressWnd()
        {
            InitializeComponent();
        }

        public void setProgressCnt(int _cnt, int _total)
        {
            //prgCnt.
            sendCnt.Text = " " + _cnt + " / " + _total + " ";
            prgCnt.Value = (int) (((float)_cnt / (float)_total ) * 100);
            prgCnt.Update();
        }
    }
}
