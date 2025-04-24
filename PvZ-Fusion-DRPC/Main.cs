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
            switch (GameAPP.theGameStatus) {
                case GameStatus.InGame:
                    Presence.state = "Fusing and fighting off the zombies";
                    Presence.startTimestamp = default(long);
                    break;
                case GameStatus.Pause:
                    Presence.state = "Fusing and fighting off the zombies";
                    break;
                case GameStatus.Selecting:
                    Presence.state = "Choosing my seeds...";
                    Presence.startTimestamp = default(long);
                    break;
                case GameStatus.Almanac:
                    Presence.state = "Reading the Almanac";
                    Presence.startTimestamp = default(long);
                    break;
                default: 
                    Presence.state = string.Empty;
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