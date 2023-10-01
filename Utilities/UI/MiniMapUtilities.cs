using MultiplayerARPG;
using System;
using UnityEngine;
using UnityEngine.UI;

public class MiniMapUtilities : MonoBehaviour
{
    public Text textServerTimestamp;

    // During the update upate a time text ui object with ServerTimestamp in "hh:mm tt" format to show "08:00 A.M." etc
    private void Update()
    {
        if (BaseGameNetworkManager.Singleton.IsClientConnected ||
                BaseGameNetworkManager.Singleton.IsServer)
        {
            if (textServerTimestamp)
                textServerTimestamp.text = GetTimeStampText(BaseGameNetworkManager.Singleton.ServerTimestamp);
            return;
        }
    }

    private string GetTimeStampText(long serverTime)
    {
        try
        {
            DateTime date = DateTimeOffset.FromUnixTimeMilliseconds(serverTime).UtcDateTime;
            return date.ToString("hh:mm tt");
        }
        catch
        {
            return "N/A";
        }
    }
}