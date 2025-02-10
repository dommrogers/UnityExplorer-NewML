using MelonLoader;
using UnityEngine;
using Il2Cpp;
using UnityExplorer.UI;

namespace UnityEplorer
{ 
    public static class TLDInputDisabler
    {
        private static PlayerControlMode previousControlMode;
        public static bool isLocked = false;

        private static void SavePosition()
        {
            if(GameManager.GetPlayerManagerComponent() != null)
            {
                previousControlMode = GameManager.GetPlayerManagerComponent().GetControlMode();
            }            
        }

        private static void LoadPosition()
        {
            if (GameManager.GetPlayerManagerComponent() != null)
            {
                GameManager.GetPlayerManagerComponent().SetControlMode(previousControlMode);
            }
        }

        public static void ToggleLock()
        {
            LockPosition(!isLocked);
        }

        public static void LockPosition(bool locked)
        {
            if (GameManager.GetPlayerManagerComponent() != null)
            {
                if (locked)
                {
                    SavePosition();
                    GameManager.GetPlayerManagerComponent().SetControlMode(PlayerControlMode.Locked);
                    isLocked = true;
                }
                else
                {
                    isLocked = false;
                    LoadPosition();
                }
            }            
        }
    }
}
