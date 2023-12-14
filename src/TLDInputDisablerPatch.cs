using MelonLoader;
using UnityEngine;
using Il2Cpp;
using UnityExplorer.UI;

namespace UnityEplorer
{
    [HarmonyLib.HarmonyPatch(typeof(InputManager), "ProcessInput", new Type[] { typeof(MonoBehaviour) })]
    public class gameInputDisablerPatch
    {
        public static bool Prefix(ref InputManager __instance, ref MonoBehaviour context)
        {
            return !UIManager.ShowMenu;
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(InputManager), "GetCameraMovementMouse", new Type[] { typeof(MonoBehaviour) })]
    public class gameMouseInputDisablerPatch2
    {
        public static void Postfix(ref InputManager __instance, ref MonoBehaviour context, ref Vector2 __result)
        {
            if (UIManager.ShowMenu)
            {
                __result = Vector2.zero;
            }
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(InputManager), "GetPlayerMovement", new Type[] { typeof(MonoBehaviour) })]
    public class gameMovementInputDisablerPatch2
    {
        public static void Postfix(ref InputManager __instance, ref MonoBehaviour context, ref Vector2 __result)
        {
            if (UIManager.ShowMenu)
            {
                __result = Vector2.zero;
            }
        }
    }
}
