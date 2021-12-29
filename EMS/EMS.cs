using CitizenFX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EMS
{
    public class EMS : BaseScript
    {
        private bool performingCPR = false;
        public EMS()
        {

            EventHandlers["ems:forcerespawn"] += new Action<dynamic>((dynamic res) => {
                if (LocalPlayer.IsDead)
                {
                    Exports["spawnmanager"].setAutoSpawn(true);
                    Exports["spawnmanager"].forceRespawn();
                }
            });

            EventHandlers["ems:revive"] += new Action<dynamic>((dynamic res) => {
                Revive();
            });

            EventHandlers["ems:die"] += new Action<dynamic>((dynamic res) => {
                LocalPlayer.Character.Kill();
            });

            EventHandlers["ems:performcpr"] += new Action<int>((int numcompressions) => {
                if (!performingCPR)
                {
                    CPR(numcompressions);
                }
                else
                {
                    performingCPR = false;
                }
            });

            EventHandlers["playerSpawned"] += new Action<dynamic>((dynamic res) => {
                Exports["spawnmanager"].setAutoSpawn(false);
            });
        }

        private async Task Revive()
        {
            if (LocalPlayer.IsDead)
            {
                Vehicle veh = null;
                if (LocalPlayer.Character.IsSittingInVehicle())
                {
                    veh = LocalPlayer.Character.CurrentVehicle;
                    LocalPlayer.Character.Task.WarpOutOfVehicle(LocalPlayer.Character.CurrentVehicle);              
                }

                LocalPlayer.Character.Resurrect();
                LocalPlayer.Character.IsCollisionEnabled = true;
                LocalPlayer.Character.Health = LocalPlayer.Character.MaxHealth;
                LocalPlayer.Character.Task.ClearAllImmediately();

                if (veh.Exists())
                {
                    for (int i = -1; i < 4; i++)
                    {
                        if (veh.IsSeatFree((VehicleSeat)i))
                        {
                            LocalPlayer.Character.SetIntoVehicle(veh, (VehicleSeat)i);
                            break;
                        }
                    }
                    
                }
            }
        }

        private async Task CPR(int numcompressions)
        {
            performingCPR = true;
            for (int i = 0; i < numcompressions; i++)
            {
                LocalPlayer.Character.Task.PlayAnimation("mini@cpr@char_a@cpr_str", "cpr_pumpchest", 4.0f, -8, -1, AnimationFlags.None, 0);
                await Delay(700);
                if (!performingCPR) { break; }
            }

            LocalPlayer.Character.Task.PlayAnimation("amb@medic@standing@tendtodead@exit", "exit", 4.0f, -2.0f, -1, AnimationFlags.AllowRotation, 0);
            await Delay(3500);
            LocalPlayer.Character.Task.ClearAll();
            performingCPR = false;           
        }
    }
}
