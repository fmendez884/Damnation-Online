using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class MyNetworkManager : NetworkManager
{
    public bool autoConnect = true;

    public override void Start()
    {
#if UNITY_SERVER
        base.Start(); // Call base.Start() only in server builds
        Debug.Log($"===* Server Build *===");
#else
        if (!Application.isBatchMode && autoConnect) { //Headless build
            Debug.Log ($"=== Client Build ===");
            this.networkAddress = "server.damnation.app";
            this.StartClient();
        }
#endif
    }

    public override void OnClientConnect()
    {
        NetworkConnection conn = NetworkClient.connection;
        Debug.Log("OnClientConnect is called");
        base.OnClientConnect();
        
        Debug.Log("I connected to a server.");
        Debug.Log($"Number of players: {numPlayers}");
    }

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);
        Debug.Log("A player was added. " + $"Number of players: {numPlayers}");
    }
}