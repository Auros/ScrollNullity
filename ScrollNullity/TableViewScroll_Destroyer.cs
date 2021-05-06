using HMUI;
using HarmonyLib;

namespace ScrollNullity
{
    [HarmonyPatch(typeof(TableViewScroller), "HandleJoystickWasNotCenteredThisFrame")]
    internal class TableViewScroll_Destroyer
    {
        internal static bool Prefix()
        {
            return false;
        }
    }

    [HarmonyPatch(typeof(TableViewScroller), "HandleJoystickWasCenteredThisFrame")]
    internal class TableViewScroll_DestroyerButCooler
    {
        internal static bool Prefix()
        {
            return false;
        }
    }
}