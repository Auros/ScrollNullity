using HarmonyLib;
using System.Linq;
using System.Reflection.Emit;
using System.Collections.Generic;

namespace ScrollNullity
{
    [HarmonyPatch(typeof(OpenVRHelper), "Update")]
    internal class OpenVR_ScrollInvokerNuker
    {
        internal static List<OpCode> _openVRScrollIL = new List<OpCode>
        {
            OpCodes.Ldloc_S,
            OpCodes.Call,
            OpCodes.Ldloca_S,
            OpCodes.Call,
            OpCodes.Ldc_I4
        };

        internal static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var codes = instructions.ToList();
            for (int i = 0; i < codes.Count; i++)
            {
                if (Plugin.OpCodeSequence(codes, _openVRScrollIL, i))
                {
                    codes.RemoveAt(i);
                    codes.Insert(i, new CodeInstruction(OpCodes.Ldc_R4, 100f));
                    break;
                }
            }
            return codes.AsEnumerable();
        }
    }
}
