﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;




public class PlayerController : NetworkBehaviour
{
    //public GameObject playerCamera;
    [SerializeField] private float speed;

    Animator animator;
    const float k_Half = 0.5f;


    public bool isIt = false;
    public Canvas itUI;


    private void Start()
    {
        //if (isLocalPlayer)
        //{
        //    playerCamera.SetActive(true);
        //}

        //else
        //{
        //    playerCamera.SetActive(false);
        //}

        //TEST


        Debug.Log(GameHandler.isSomeoneIt);

        if(GameHandler.returnIt() == false)
        {
            GameHandler.isSomeoneIt = true;
        }

        Debug.Log(GameHandler.isSomeoneIt);



        //END TEST

        if (isLocalPlayer)
        {
            animator = GetComponent<Animator>();
        }
    }

    private void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        Move();
        MakeIt();
        
    }

    void Move()
    {
        float vertMove = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        float horzMove = Input.GetAxis("Horizontal") * Time.deltaTime * speed;

        transform.Translate(horzMove, 0, vertMove);
    }

    void MakeIt()
    {
        if(isIt == false)
        {
            if (isLocalPlayer)
            {
                isIt = true;
            }
        }

        if(isIt == true)
        {
            itUI.gameObject.SetActive(true);
        }
    }




}




//private ThirdPersonCharacter player; //player reference
//private Transform playerCam;
//private Vector3 camForwardDir; //forward camera direction
//private Vector3 move;
//private bool jump;

//// Use this for initialization
//void Start()
//{
//    if (Camera.main != null)
//    {
//        playerCam = Camera.main.transform;
//    }
//    else
//    {
//        Debug.LogWarning(
//                "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
//        // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
//    }
//    player = GetComponent<ThirdPersonCharacter>();
//}


//// Update is called once per frame
//void Update()
//{
//    if (!jump)
//    {
//        jump = CrossPlatformInputManager.GetButtonDown("Jump");
//    }
//}

//private void FixedUpdate()
//{
//    float horz = CrossPlatformInputManager.GetAxis("Horizontal");
//    float vert = CrossPlatformInputManager.GetAxis("Vertical");
//    bool crouch = Input.GetKey(KeyCode.C);


//    if(playerCam != null)
//    {
//        camForwardDir = Vector3.Scale(playerCam.forward, new Vector3(1, 0, 1)).normalized;
//        move = vert * camForwardDir + horz * playerCam.right;
//    }
//    else
//    {
//        move = vert * Vector3.forward + horz * Vector3.right;
//    }

//    if (Input.GetKey(KeyCode.LeftShift))
//    {
//        move *= 0.5f;
//    }

//    //Character.Move(move, crouch, jump);
//    player.Move(move, crouch, jump);
//    jump = false;
//}
