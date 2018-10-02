using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CameraController : MonoBehaviour {

    [SerializeField] float mouseSensitivity;
    public GameObject player;

    private Vector2 mouseLook;

    private Vector2 camDir;


	// Use this for initialization
	void Start () {
        
        Cursor.lockState = CursorLockMode.Locked;
        if (gameObject.transform.parent.gameObject.GetComponent<NetworkIdentity>().isLocalPlayer)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }

    }
	
	// Update is called once per frame
	void Update () {

        mouseLook.y = Mathf.Clamp(mouseLook.y, -90, 90);

        camDir = new Vector2(Input.GetAxisRaw("Mouse X") * mouseSensitivity, Input.GetAxisRaw("Mouse Y") * mouseSensitivity);
        mouseLook += camDir;

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);

        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }


	}
}
