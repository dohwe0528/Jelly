using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KakaoMSG
{

    public class UserConfig
    {
        [JsonProperty]
        public double WodTime { get; set; }

        [JsonProperty]
        public double MsdTime { get; set; }

        [JsonProperty]
        public double IsdTime { get; set; }

        [JsonProperty]
        public long ImgSize { get; set; }

        [JsonProperty]
        public string UserID { get; set; }

        [JsonProperty]
        public string KakaoName { get; set; }

        public UserConfig()
        {
            WodTime = 1000;
            MsdTime = 1000;
            IsdTime = 1000;
            ImgSize = 200 * 1024;
        }

        public void SetUserCofing(string wod, string msd, string imgsize, string userid, string isd)
        {
            WodTime = double.Parse(wod) * 1000;
            MsdTime = double.Parse(msd) * 1000;
            IsdTime = double.Parse(isd) * 1000;
            ImgSize = long.Parse(imgsize);
            UserID = userid;

        }
        public void SetUserCofing(string wod, string msd, string imgsize, string isd)
        {
            WodTime = double.Parse(wod) * 1000;
            MsdTime = double.Parse(msd) * 1000;
            IsdTime = double.Parse(isd) * 1000;
            ImgSize = long.Parse(imgsize) ;
        }
        public void SetUserCofing(double wod, double msd, long imgsize, double isd)
        {
            WodTime = wod;
            MsdTime = msd;
            IsdTime = isd;
            ImgSize = imgsize;
        }
        public void SetUserCofing(double wod, double msd, long imgsize, string userid, double isd)
        {
            WodTime = wod;
            MsdTime = msd;
            IsdTime = isd;
            ImgSize = imgsize;
            UserID = userid;
        }

        public double getWodTime()
        {
            return WodTime;
        }

        public double getMsdTime()
        {
            return MsdTime;
        }

        public double getIsdTime()
        {
            return IsdTime;
        }

        public long getImgSize()
        {
            return ImgSize;
        }

        public string getUserID()
        {
            return UserID;
        }

        public void setWodTime(long wt)
        {
            WodTime = wt;
        }

        public void setMsdTime(long mt)
        {
            MsdTime = mt;
        }

        public void setIsdTime(long it)
        {
            IsdTime = it;
        }
    }

    public class Version
    {
        public string current_version { get; set; }
    }

}
