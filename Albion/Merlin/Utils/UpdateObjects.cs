using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace Alucard.Utils
{
    public class UpdateObjects : MonoBehaviour
    {
        public static HarvestableObjectView[] resources;
        public static LocalPlayerCharacterView localPlayer;
        public static PlayerCharacterView[] players;

        IEnumerator Start()
        {
            // coroutines
            yield return StartCoroutine(this.updateObjects());
        }

        private IEnumerator updateObjects()
        {
            while (true)
            {
                try
                {
                    localPlayer = FindObjectOfType<LocalPlayerCharacterView>();
                }
                catch { }

                yield return new WaitForSeconds(0.2f);

                if (Config.Players.Enabled)
                {
                    try
                    {
                        players = FindObjectsOfType<PlayerCharacterView>();
                    }
                    catch { }
                    yield return new WaitForSeconds(1f);
                }

                if (Config.Resources.Enabled)
                {
                    try
                    {
                        resources = FindObjectsOfType<HarvestableObjectView>().Where(
                            go => 
                                go.name.Contains(Config.ObjectNames.Rock.T5) ||
                                go.name.Contains(Config.ObjectNames.Rock.T6)
                        ).ToArray();
                    }
                    catch { }
                    yield return new WaitForSeconds(1f);
                }
            }
        }
    }
}
