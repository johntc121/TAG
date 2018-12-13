﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;




public class PlayerController : NetworkBehaviour
{
    //public GameObject playerCamera;
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] public float fallMultipler = 2.5f;
    [SerializeField] public float lowJumpMltp = 2f;

    private Rigidbody rb;


    private Animator animator;
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

        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();




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

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        //bJump();
        
    }

    void Move()
    {
        

        float vertMove = Input.GetAxis("Vertical");
        float horzMove = Input.GetAxis("Horizontal");

        if(vertMove > 0)
        {
            animator.SetFloat("Speed", speed);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }

        transform.Translate(horzMove * Time.deltaTime * speed, 0, vertMove * Time.deltaTime * speed);

    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpPower);
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

    void bJump()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultipler - 1) * Time.deltaTime;
        }
        else if(rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMltp - 1) * Time.deltaTime;
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
