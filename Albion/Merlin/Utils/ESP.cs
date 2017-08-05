using Alucard.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Alucard.Utils
{
    class ESP : MonoBehaviour
    {
        protected LocalPlayerCharacterView localPlayer;

        public static bool ValidateMob(MobView mob)
        {
            if (mob.IsDead())
                return false;

            return true;
        }

        /// <summary>
        /// Called when this instance is enabled.
        /// </summary>
        void OnEnable()
        {
        }

        void Update()
        {

        }

        void OnGUI()
        {
            localPlayer = UpdateObjects.localPlayer;
            try
            {
                if (Config.Resources.Enabled)
                {
                    resourceEsp();
                }
                else
                {
                    if (UpdateObjects.resources != null)
                    {
                        Core.UnloadResources();
                        UpdateObjects.resources = null;
                    }
                }
                if (Config.Players.Enabled)
                {
                    playerEsp();
                }
                else
                {
                    if (UpdateObjects.resources != null)
                    {
                        Core.UnloadPlayers();
                        UpdateObjects.players = null;
                    }
                }
            }
            catch { }
        }

        private void resourceEsp() {
            Vector3 myPos = Camera.main.WorldToScreenPoint(localPlayer.transform.position);

            foreach (HarvestableObjectView go in UpdateObjects.resources)
            {
                Vector3 pos = Camera.main.WorldToScreenPoint(go.transform.position);
                pos.y = Screen.height - (pos.y + 1f);
                // Rendering.DrawString(new Vector2(pos.x, pos.y), go.name, Color.white);
                Rendering.DrawBox(pos, new Vector2(100, 100), 2f, Color.blue, true);
                Color textColor = Color.white;
                Color lineColor = Color.cyan;
                // tiers
                if (go.name.Contains(Config.ObjectNames.Rock.T5)) {
                    // Dark Cyan, TODO: move me to config
                    //lineColor = new Color32(0, 63, 63, 255);
                    lineColor = Color.green;
                }
                if (go.name.Contains(Config.ObjectNames.Rock.T4))
                {
                    lineColor = Color.blue;
                }
                if (go.GetCurrentCharges() <= 0)
                {
                    lineColor = Color.grey;
                    textColor = Color.red;
                }
                Rendering.DrawString(pos, go.GetCurrentCharges().ToString(), textColor, true, 16);

                if (Vector3.Distance(go.transform.position, localPlayer.transform.position) < Config.Resources.MaxLineDistance
                    && ((Config.Resources.DrawDepleted && go.GetCurrentCharges() <= 0) 
                    || go.GetCurrentCharges() >= 1))
                { 
                        Rendering.DrawLine(go.gameObject, go.transform.position, localPlayer.transform.position, lineColor);
                }
                else {
                    LineRenderer l = go.gameObject.GetComponent<LineRenderer>();
                    if (l != null)
                        UnityEngine.Object.Destroy(l);
                }
            }
        }

        private void playerEsp()
        {
            // show player count
            Rendering.DrawString(new Vector2(Screen.width - 150, Screen.height - 320), "count: " + (UpdateObjects.players.Count() - 1), Color.white, true, 20);
            // player esp
            foreach (PlayerCharacterView player in UpdateObjects.players)
            {
                if (player == localPlayer) continue;
                Vector3 pos = Camera.main.WorldToScreenPoint(player.transform.position);
                pos.y = Screen.height - (pos.y + 1f);
                if (player.getAliance() != Core.myAlliance)
                {
                    Rendering.DrawLine(player.gameObject, player.transform.position, localPlayer.transform.position, Color.red);
                    Rendering.DrawBox(pos, new Vector2(100, 100), 2f, Color.red, true);
                }
                else {
                    if (Config.Players.DrawFriendly)
                    {
                        Rendering.DrawLine(player.gameObject, player.transform.position, localPlayer.transform.position, Color.yellow);
                    }
                    /* else {
                        LineRenderer l = player.gameObject.GetComponent<LineRenderer>();
                        if (l)
                        {
                            UnityEngine.Object.Destroy(l);
                        }
                    }*/
                }
            }
        }
    }
}
