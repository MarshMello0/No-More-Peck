using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Harmony;
using System.Reflection;

public class NoMorePeck : Mod
{
    private void Start()
    {
        RConsole.Log("No More Peck: Loaded!");
    }

    [HarmonyPatch(typeof(Seagull))]
    [HarmonyPatch("SwitchState")]
    class Patch_Seagull_SwitchState
    {
        static void Prefix(ref SeagullState newState)
        {
            if (newState == SeagullState.Peck)
            {
                newState = SeagullState.FlyAway;
                RConsole.Log("No More Peck: Seagull is flying off now");
            }
        }
    }

    public NoMorePeck() : base("No More Peck", "Stops the seagull from pecking.", "1.0", "1.01B")
    {
        var harmony = HarmonyInstance.Create("com.raft.mod.tutorial");
        harmony.PatchAll(Assembly.GetExecutingAssembly());
    }
}