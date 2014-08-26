using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Social.App.Web.Models.Company
{
    public class YouTubeVideo
    {
        public Int32 HeightPX { get; set; }
        public Int32 WidthPX { get; set; }
        public String SourceURL { get; set; }
        public String Header { get; set; }
        public String Description { get; set;}
    }
}