using Comfort.Common;
using EFT;
using EFT.Interactive;
using JET.Utility.Patching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JET_PowerSwitches
{
    class Patch : GenericPatch<Patch>
    {
        public Patch() : base(postfix: nameof(PatchPostfix)) { }
        protected override MethodBase GetTargetMethod()
        {
            return typeof(GameWorld).GetMethod("OnGameStarted", BindingFlags.Public | BindingFlags.Instance);
        }
        public static void PatchPostfix()
        {
            var WorldInteractiveObjectList = LocationScene.GetAllObjects<WorldInteractiveObject>(false).Cast<WorldInteractiveObject>().ToList();
            var SwitchList = WorldInteractiveObjectList.Where(wio => wio is Switch).Cast<Switch>().ToList();
            Debug.LogError($"WorldInteractiveObjectList: {WorldInteractiveObjectList.Count}");
            Debug.LogError($"SwitchList: {SwitchList.Count}");
            foreach (var Switch in SwitchList) 
            {
                Debug.LogError($"Switch: {Switch.Id} | {Switch.name}");
                // Interchange Power Station
                if (Switch.Id == "Shopping_Mall_DesignStuff_00055" && Switch.name == "reserve_electric_switcher_lever")
                {
                    InvokeOpen(Switch);
                }

                // Interchange Secret Container
                if (Switch.Id == "Shopping_Mall_DesignStuff_00061" && Switch.Id == "reserve_electric_switcher_lever")
                {
                    InvokeOpen(Switch);
                }

                // Customs Power Switch
                if (Switch.Id == "custom_DesignStuff_00034" && Switch.name == "reserve_electric_switcher_lever")
                {
                    InvokeOpen(Switch);
                }

                // Reserve D2 Switch
                if (Switch.Id == "autoId_00000_D2_LEVER" && Switch.name == "reserve_electric_switcher_lever")
                {
                    InvokeOpen(Switch);
                }
            }

        }
        private static void InvokeOpen(Switch _switch)
        {
            typeof(Switch).GetMethod("Open", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(_switch, new object[] { });
        }
    }
}
