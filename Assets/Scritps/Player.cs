using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;



public class Player : NetworkBehaviour {


    public GameObject playerCamera;

    public float verticalInput;
    public float horizontalInput;

    public GameController gameController;

    private void Start()
    {
        gameController = GetComponent<GameController>();

        if (isLocalPlayer)
        {
            playerCamera.SetActive(true);
        }

        else
        {
            playerCamera.SetActive(false);
        }
    }

    private void Update()
    {
        if (isLocalPlayer)
        {
            Move();
        }

        
    }

    void Move()
    {
        verticalInput = Input.GetAxisRaw("Vertical") * Time.deltaTime * 3f;
        horizontalInput = Input.GetAxisRaw("Horizontal") * Time.deltaTime * 3f;


    }


}
