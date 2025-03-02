using MelonLoader;
using DiscordRichPresense;
using HarmonyLib;
using UnityEngine;
using Il2Cpp;

namespace PvZ_Fusion_DRPC
{
    public class Main : MelonMod
    {
        private const string DiscordAppID = "1343265059207381142";
        public static readonly DiscordRpc.RichPresence Presence = new DiscordRpc.RichPresence();
        public override void OnApplicationStart()
        {
            var handlers = new DiscordRpc.EventHandlers();
            DiscordRpc.Initialize(DiscordAppID, ref handlers, false, string.Empty);
            Presence.state = string.Empty;
            Presence.details = string.Empty;
            Presence.startTimestamp = default(long);
            Presence.largeImageKey = "lanpiaopiao";
            DiscordRpc.UpdatePresence(Presence);
        }
        public override void OnUpdate()
        {
            string dState = string.Empty;
            switch (GameAPP.theGameStatus) {
                case (int)GameStatus.InGame:
                    dState = "Fusing and fighting off the zombies";
                    Presence.state = dState;
                    Presence.startTimestamp = default(long);
                    MelonLogger.Msg(LevelName2.Instance);
                    break;
                case (int)GameStatus.Pause:
                    dState = "Fusing and fighting off the zombies";
                    Presence.state = dState;
                    break;
                case (int)GameStatus.InInterlude:
                    dState = "Choosing my seeds...";
                    Presence.state = dState;
                    Presence.startTimestamp = default(long);
                    break;
                case (int)GameStatus.Selecting:
                    dState = "Choosing my seeds...";
                    Presence.state = dState;
                    break;
                case (int)GameStatus.Almanac:
                    dState = "Reading the Almanac";
                    Presence.state = dState;
                    Presence.startTimestamp = default(long);
                    break;
                default: 
                    dState = string.Empty;
                    Presence.state = dState;
                    Presence.startTimestamp = default(long);
                    break;
            }
            DiscordRpc.UpdatePresence(Presence);
            DiscordRpc.RunCallbacks();
        }

        public override void OnApplicationQuit()
        {
            DiscordRpc.Shutdown();
        }

    }
}