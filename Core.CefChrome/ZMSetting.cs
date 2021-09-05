using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CefChrome
{
    public class ZMSetting
    {

       
        public int DefaultInverstMoney { get; set; } = 10;

        public InverstMode inverstMode { get; set; } = InverstMode.Xian;


        public GnameSettig Zhuang { get; set; }

        public GnameSettig Xian { get; set; }

        public GnameSettig He { get; set; }

        public GnameSettig OK { get; set; }

        public GnameSettig One { get; set; }

        public GnameSettig Ten { get; set; }

        public GnameSettig fifty { get; set; }

        public GnameSettig hundred { get; set; }

        public int Add { get; set; } = 1;

        public int Min { get; set; } = 10;

        public IMode Imode { get; set; } = IMode.Await;

        public WRandom wRandom { get; set; } = WRandom.Random;
    }

    public enum WRandom
    {

        Random,
        Random095,
        Win,
        Lost
    }

    public enum IMode
    {
        Await,
        Add 
    }
}
