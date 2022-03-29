using JET.Utility.Modding;
using JET.Utility.Patching;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace JET_PowerSwitches
{
    public class Main : JetMod
    {
        protected override void Initialize(IReadOnlyDictionary<Type, JetMod> dependencies, string gameVersion)
        {
            // we start from here
            Debug.Log("JET_PowerSwitches Init!");
            InitPatch();
        }

        void InitPatch()
        {
            HarmonyPatch.Patch<Patch>(); // patching the LaserBeam class
        }
        string Author = "TheMaoci";
    }
}
