using CommandSystem;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using MEC;
using RemoteAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = System.Random;

namespace SurfaceBoom
{
    public class warhead
    {

        public IEnumerator<float> OutSideBoom()
        {
            while (Round.InProgress)
            {
                var player = Player.List.Where(x => x.IsAlive);
                foreach (var p in player)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        Random random = new Random();
                        float randomNumber = (float)(random.NextDouble() * 3 + 1);
                        float roundedNumber = (float)Math.Round(randomNumber, 2);

                        ExplosiveGrenade granade = (ExplosiveGrenade)Item.Create(ItemType.GrenadeHE);

                        granade.FuseTime = roundedNumber;
                        granade.SpawnActive(p.Position + Vector3.up);

                        Timing.WaitForSeconds(2);
                        granade.FuseTime = roundedNumber;
                        granade.SpawnActive(p.Position + Vector3.up);
                    }
                }
                yield return Timing.WaitForSeconds(1);
            }
            yield return Timing.WaitForSeconds(0.7f);

            if (Round.InProgress == false)
            {
                Cassie.Message("<color=red>地上の爆破シーケンスが終了しました。</color>");
            }
        }
    }
}
