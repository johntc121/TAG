using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerInfo : NetworkBehaviour {

    public GameObject gameManager;
   // public GameHandler gameHandler;
    public bool isIt = false;

    public Canvas isItUI;

    //player is/isnt it
    //health
    //name
    //energy
    

	// Use this for initialization
	void Start () {
        GameHandler.AddPlayer();

        if(GameHandler.ReturnIt() == false)
        {
            GameHandler.SetIt();
            isIt = true;

        }

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GameHandler.ReturnIt());
        SetUI();

    }

    void SetUI()
    {
        if (isLocalPlayer && isIt == true) 
        {
            isItUI.gameObject.SetActive(true);
        }
    }
}
