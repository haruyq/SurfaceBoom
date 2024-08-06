using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurfaceBoomEventHandler;
using SurfaceBoomConfig;
using Exiled;
using Exiled.API.Features;
using Exiled.Events;
using Config = SurfaceBoomConfig.Config;

namespace SurfaceBloom
{
    public class main : Plugin<Config>
    {
        private SurfaceBoomEventHandler.EventHandler events;

        public override void OnEnabled()
        {
            base.OnEnabled();
            Log.Info("Pluginが有効になりました。");
            events = new SurfaceBoomEventHandler.EventHandler();
            events.RegisterEvents();
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
            Log.Error("Pluginが無効になりました。");
            events = new SurfaceBoomEventHandler.EventHandler();
            events.UnregisterEvents();
        }

    }
}