using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class MyNetworkManager : NetworkManager
{
    public bool autoConnect = true;
    public override void Start()
    {
        base.Start();
        if (!Application.isBatchMode && autoConnect) { //Headless build
                Debug.Log ($"=== Client Build ===");
                this.networkAddress = "server.damnation.app";
                this.StartClient ();
            } else {
                Debug.Log ($"=== Server Build ===");
            }

    }
    // public override void OnClientConnect(NetworkConnection conn)
    // {
    //     Debug.Log("OnClientConnect is called");
    //     base.OnClientConnect(conn);
        
    //     Debug.Log("I connected to a server.");
    //     Debug.Log($"Number of players: {numPlayers}");
    // }

    // public override void OnServerAddPlayer(NetworkConnection conn)
    // {
    //     base.OnServerAddPlayer(conn);
        
    //     MyNetworkPlayer player = conn.identity.GetComponent<MyNetworkPlayer>();
        
    //     player.SetDisplayName($"Player {numPlayers}");
        
    //     Color randomColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    //     player.SetDisplayColor(randomColor);
        
    //     Debug.Log("A player was added. " + $"Number of players: {numPlayers}");
    // }
}