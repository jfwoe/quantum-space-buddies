using HarmonyLib;
using Steamworks;

namespace QSB.Patches;

public sealed class KcpSteamworksPatch : QSBPatch
{
	public override QSBPatchTypes Type => QSBPatchTypes.OnModStart;

	[HarmonyPatch(typeof(SteamUtils), nameof(SteamUtils.IsSteamRunningOnSteamDeck))]
	[HarmonyPrefix]
	private static bool SkipSteamDeckCheckForKcp(ref bool __result)
	{
		if (!QSBCore.UseKcpTransport)
		{
			return true;
		}

		__result = false;
		return false;
	}
}
