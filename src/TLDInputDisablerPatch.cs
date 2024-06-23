using MelonLoader;
using UnityEngine;
using Il2Cpp;
using UnityExplorer.UI;

namespace UnityEplorer
{
    [HarmonyLib.HarmonyPatch(typeof(InterfaceManager), "ShouldEnableMousePointer")]
    public class CursorPatch
    {
        public static void Postfix(InterfaceManager __instance, ref bool __result)
        {
            if (TLDInputDisabler.isLocked)
            {
                __result = true;
            }
        }
    }
}
