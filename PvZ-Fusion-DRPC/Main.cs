using MelonLoader;
using DiscordRichPresense;

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
            DiscordRpc.RunCallbacks();
        }

        public override void OnApplicationQuit()
        {
            DiscordRpc.Shutdown();
        }

    }
}