using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using UnityEngine;

namespace Alucard
{
    public static class LocalPlayerCharacterViewExtensions
    {
        private static MethodInfo _startCastInternalTarget;
        private static MethodInfo _startCastInternalPosition;
        private static MethodInfo _doActionStaticObjectInteraction;

        static LocalPlayerCharacterViewExtensions()
        {
            var inputHandlerType = typeof(LocalInputHandler);

            _startCastInternalTarget = inputHandlerType.GetMethod("StartCastInternal", BindingFlags.NonPublic | BindingFlags.Instance,
                                            Type.DefaultBinder, new Type[] { typeof(byte), typeof(FightingObjectView) }, null);

            _startCastInternalPosition = inputHandlerType.GetMethod("StartCastInternal", BindingFlags.NonPublic | BindingFlags.Instance,
                                            Type.DefaultBinder, new Type[] { typeof(byte), typeof(ahl) }, null);

            _doActionStaticObjectInteraction = inputHandlerType.GetMethod("DoActionStaticObjectInteraction", BindingFlags.NonPublic | BindingFlags.Instance);
        }
    
        public static void SetSelectedObject(this LocalPlayerCharacterView instance, SimulationObjectView simulation)
        {
            if (simulation == default(SimulationObjectView))
                instance.InputHandler.SetSelectedObjectId(-1L);
            else
                instance.InputHandler.SetSelectedObjectId(simulation.Id);
        }

        public static void AttackSelectedObject(this LocalPlayerCharacterView instance)
        {
            instance.InputHandler.AttackCurrentTarget();
        }      

        public static void Interact(this LocalPlayerCharacterView instance, WorldObjectView target)
        {
            _doActionStaticObjectInteraction.Invoke(instance.InputHandler, new object[] { target, String.Empty });
        }

        public static float GetMaxLoad(this LocalPlayerCharacterView instance)
        {
            return instance.LocalPlayerCharacter.wf();
        }

    }
}