using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameHandler : NetworkBehaviour{


    private static bool isSomeoneIt = false;

    private static float playerCount = 0;

    


    private void Start()
    {
        playerCount = 0;
        isSomeoneIt = false;
    }


    public static bool ReturnIt()
    {
        return isSomeoneIt;
    }

    public static void SetIt()
    {
        isSomeoneIt = true;
    }

    public static float NumPlayers()
    {
    
        return playerCount;
    }

    public static void AddPlayer()
    {
        playerCount++;
    }
}
