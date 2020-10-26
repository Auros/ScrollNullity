using IPA;
using HarmonyLib;
using System.Reflection;
using System.Reflection.Emit;
using System.Collections.Generic;
using IPALogger = IPA.Logging.Logger;

namespace ScrollNullity
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        internal static IPALogger Log { get; private set; }

        private readonly Harmony _harmony;


        [Init]
        public Plugin(IPALogger logger)
        {
            Log = logger;
            _harmony = new Harmony("dev.auros.scrollnullity");
        }

        [OnEnable]
        public void OnEnable()
        {
            _harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        [OnDisable]
        public void OnDisable()
        {
            _harmony.UnpatchAll("dev.auros.scrollnullity");
        }

        internal static bool OpCodeSequence(List<CodeInstruction> codes, List<OpCode> toCheck, int startIndex)
        {
            for (int i = 0; i < toCheck.Count; i++)
            {
                if (codes[startIndex + i].opcode != toCheck[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}