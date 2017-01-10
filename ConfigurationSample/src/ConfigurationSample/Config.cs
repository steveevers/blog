using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationSample
{
    public class Config {
        public int MyNumberSetting
        {
            get { return MyNumber; }
            set { MyNumber = value; }
        }

        public string MyTextSetting
        {
            get { return MyText; }
            set { MyText = value; }
        }

        public static int MyNumber { get; private set; }
        public static string MyText { get; private set; }
    }
}
