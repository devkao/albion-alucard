using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Alucard
{
    public static class HarvestableObjectViewExtensions
    {
        static HarvestableObjectViewExtensions()
        {

        }       

        public static int GetCurrentCharges(this HarvestableObjectView instance)
        {
            return (int)instance.HarvestableObject.sn();
        }

        public static long GetMaxCharges(this HarvestableObjectView instance)
        {
            return instance.HarvestableObject.sj();
        }
    }
}