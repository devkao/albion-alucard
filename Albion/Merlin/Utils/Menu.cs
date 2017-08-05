using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Alucard.Utils
{
    public class Menu : MonoBehaviour
    {
        public static bool showMenus = false;

        void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Delete))
            {
                showMenus = !showMenus;
            }
        }

        void OnGUI() {
            if (showMenus) {
                Config.espWindow = GUI.Window(0, Config.espWindow, new GUI.WindowFunction(Menu.ESPWindow), "ESP");
                Config.debugWindow = GUI.Window(1, Config.debugWindow, new GUI.WindowFunction(Menu.DebugWindow), "Debug");
            }
        }

        //public static void AddDebugGui()
        //{
        //    WorldObjectDebugGui gui = (WorldObjectDebugGui)Core._coreObject.gameObject.AddComponent(typeof(WorldObjectDebugGui));
        //    gui.Name = "Debug GUI";
        //    gui.AddValue("PlayerCount", () => UpdateObjects.players.Length.ToString());
        //}

        public static void DebugWindow(int i)
        {
            // DUMP GameObjects
            if (GUI.Button(new Rect(10f, 25f, 200f, 20f), "Dump objects")) {
                GameObject[] objs = FindObjectsOfType<GameObject>();
                List<String> names = new List<String>();
                Debug.Log("=======================");
                foreach (GameObject go in objs) {
                    //if (go.name.Contains("FOREST")) continue;
                    if (!names.Contains(go.name))
                    {
                        names.Add(go.name);
                        Debug.Log(go.name);
                    }                    
                }
            }

            if (GUI.Button(new Rect(10f, 50f, 200f, 20f), "Clear"))
            {
                Core.UnloadPlayers();
                Core.UnloadResources();
            }

            if (GUI.Button(new Rect(10f, 75f, 200f, 20f), "Log"))
            {
                Debug.Log("====== Player ======");
                Debug.Log("jh(): " + UpdateObjects.localPlayer.PlayerCharacter.jh());
                Debug.Log("jn(): " + UpdateObjects.localPlayer.PlayerCharacter.jn());
                Debug.Log("uy(): " + UpdateObjects.localPlayer.PlayerCharacter.u0());
                Debug.Log("uz(): " + UpdateObjects.localPlayer.PlayerCharacter.uz());
            }

            if (GUI.Button(new Rect(10f, 240f, 200f, 20f), "UNLOAD"))
            {
                Core.Unload();
            }

            // Draggable
            GUI.DragWindow();
        }

        public static void ESPWindow(int i)
        {
            // ENABLE - PLAYERS
            Config.Players.Enabled = GUI.Toggle(new Rect(10f, 25f, 200f, 20f), Config.Players.Enabled, "Players ESP");

            // ENABLE - RESOURCES
            Config.Resources.Enabled = GUI.Toggle(new Rect(10f, 50f, 200f, 20f), Config.Resources.Enabled, "Resources ESP");

            // RESOURCE DRAW DISTANCE
            GUI.Label(new Rect(10f, 75f, 200f, 20f), string.Format("RSS Line Draw Distance: {0}", Config.Resources.MaxLineDistance));
            Config.Resources.MaxLineDistance = GUI.HorizontalSlider(new Rect(10f, 100f, 200f, 20f), Config.Resources.MaxLineDistance, 0f, 200f);
            
            Config.Players.DrawFriendly = GUI.Toggle(new Rect(10f, 125f, 200f, 20f), Config.Players.DrawFriendly, "Draw friendly");
            Config.Resources.DrawDepleted = GUI.Toggle(new Rect(10f, 150f, 200f, 20f), Config.Resources.DrawDepleted, "Draw depleted resources");

            // Draggable
            GUI.DragWindow();
        }
    }
}
