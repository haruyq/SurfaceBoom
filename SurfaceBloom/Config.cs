using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled;
using Exiled.API.Interfaces;

namespace SurfaceBloomConfig
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public int Time { get; set; } = 120;
        public bool Debug { get; set; }
    }
}
