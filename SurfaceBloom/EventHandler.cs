using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Features;
using Exiled;
using Exiled.Events.Handlers;
using SurfaceBloomConfig;
using MEC;
using SurfaceBloom;
using UnityEngine;


namespace SurfaceBloomEventHandler
{
    public class EventHandler
    {
        public static bool IsEventEnabled { get; set; } = false;

        public void RegisterEvents()
        {
            Exiled.Events.Handlers.Warhead.Detonated += OnDetonated;
        }
        public void UnregisterEvents()
        {
            Exiled.Events.Handlers.Warhead.Detonated -= OnDetonated;
        }

        private static Config config = new Config();

        private int currentRoundId = 0;
        public void OnDetonated()
        {
            int roundIdAtDetonation = currentRoundId;

            Log.Info("[Warhead] トリガーされました");

            int time = config.Time;

            if (Round.InProgress)
            {
                int time1 = time - 13;
                Timing.CallDelayed(time1, () =>
                {
                    if (Round.InProgress && roundIdAtDetonation == currentRoundId)
                    {
                        Exiled.API.Features.Cassie.MessageTranslated(
                        message: "pitch_0.15 .g4 pitch_0.2 jam_099_2 .g1 pitch_0.15 .g4 pitch_0.25 jam_099_2 .g1 pitch_0.15 .g4 pitch_0.25 jam_099_2 .g1 pitch_0.6 . .g4 . .g4 . .g4",
                        translation: "<color=red><< 警告地上爆破シーケンスが開始されます。 >></color>");
                        Exiled.API.Features.Map.Broadcast(5, message:"<size=75%><color=red><< 警告。地上爆破シーケンスが開始されます。 >></color></size>");
                    }
                });

                Timing.CallDelayed(time, () =>
                {
                    if (Round.InProgress && roundIdAtDetonation == currentRoundId)
                    {
                        warhead warhead = new warhead();
                        Timing.RunCoroutine(warhead.OutSideBoom());
                    }
                });
            }
            else
            {
                Log.Info("[Warhead] ラウンドが進行中ではないため、トリガーは破棄されました。");
            }
        }
    }
}
