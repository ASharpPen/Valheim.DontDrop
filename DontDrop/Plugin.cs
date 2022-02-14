using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace DontDrop;

[BepInPlugin(Id, Name, Version)]
public class Plugin : BaseUnityPlugin
{
    public const string Id = "asharppen.valheim.dontdrop";
    public const string Name = "Dont Drop";
    public const string Version = "1.0.0";

    internal static ManualLogSource Log;

    void Awake()
    {
        Log = Logger;

        new Harmony(Id).PatchAll();
    }
}

[HarmonyPatch(typeof(CharacterDrop))]
public static class DropItemsOverride
{
    [HarmonyPatch("DropItems")]
    [HarmonyPrefix]
    private static bool StopIt()
    {
        Plugin.Log.LogInfo($"No drops! Stop it!");

        return false;
    }
}
