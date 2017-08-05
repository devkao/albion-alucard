using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Reflection;

using UnityEngine;

using Alucard.Utils;

namespace Alucard
{
    public class Core
    {
	    public static GameObject _coreObject;

		public static LineRenderer LineRenderer { get; set; }

        public static string myAlliance = "CHANGE_ME";

		public static void Load()
		{
            _coreObject = new GameObject();
            _coreObject.AddComponent<UpdateObjects>();
            _coreObject.AddComponent<Menu>();
            _coreObject.AddComponent<Utils.Console>();
            // _coreObject.AddComponent<VersionView>();

            var esp = _coreObject.AddComponent<ESP>();
            esp.enabled = true;

            // var gatherer = _coreObject.AddComponent<Gatherer>();

            UnityEngine.Object.DontDestroyOnLoad(_coreObject);
        
            // Activate(gatherer);
        }

        public static void Unload()
		{
			UnityEngine.Object.Destroy(_coreObject);

            // destroy line renderers
            UnloadResources();
            UnloadPlayers();

            UnityEngine.Object.Destroy(UpdateObjects.localPlayer.GetComponent<LineRenderer>());

            _coreObject = null;
		}

        public static void UnloadResources() {
            foreach (HarvestableObjectView go in UpdateObjects.resources)
            {
                UnityEngine.Object.Destroy(go.gameObject.GetComponent<LineRenderer>());
            }
        }

        public static void UnloadPlayers()
        {
            foreach (PlayerCharacterView go in UpdateObjects.players)
            {
                UnityEngine.Object.Destroy(go.gameObject.GetComponent<LineRenderer>());
            }
        }
        
		private class VersionView : MonoBehaviour
	    {
		    private Rect _displayRectangle;
	        private Version _version;

		    void Start()
		    {
			    _displayRectangle = new Rect((Screen.width / 2) - 100, 10, 100, 20);
			    _version = Assembly.Load("Alucard").GetName().Version;
		    }

			void OnGUI()
			{
				GUI.Label(_displayRectangle, "LOADED " + _version.ToString());
			}
		}
    }
}
