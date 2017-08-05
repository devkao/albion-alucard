using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Alucard.Utils
{
    class Config
    {
        public static Rect espWindow = new Rect(50f, 150f, 235f, 275f);
        public static Rect debugWindow = new Rect(50f, 450f, 235f, 275f);

        internal static class Resources
        {
            public static Boolean Enabled = true;
            public static Boolean DrawDepleted = true;
            public static float MaxLineDistance = 60;
        }

        internal static class Players
        {
            public static Boolean Enabled = true;
            public static Boolean DrawFriendly = true;
        }

        internal static class ObjectNames
        {
            internal static class Rock {
                public static String T4 = "T4_ROCK";
                public static String T5 = "T5_ROCK";
                public static String T6 = "T6_ROCK";
            }
        }
    }
}
