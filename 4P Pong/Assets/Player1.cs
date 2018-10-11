using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{
    public float speed = 10.0f;
    public GameObject ballPrefab;

	// Use this for initialization
	void Start ()
    {
        if (isLocalPlayer)
        {
            if (isServer)
            {
                gameObject.transform.position = new Vector3(-6.5f, 0.0f, 0.0f);
                gameObject.name = "LeftPlayer";
            }
            else
            {
                gameObject.transform.position = new Vector3(6.5f, 0.0f, 0.0f);
                gameObject.name = "RightPlayer";
            }
        }
        else
        {
            if (isServer)
            { 
                gameObject.transform.position = new Vector3(6.5f, 0.0f, 0.0f);
                gameObject.name = "RightPlayer";
            }
            else
            {
                gameObject.transform.position = new Vector3(-6.5f, 0.0f, 0.0f);
                gameObject.name = "LeftPlayer";
            }
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!isLocalPlayer)
            return;

        float v = Input.GetAxisRaw("Vertical");
        GetComponent<Rigidbody>().velocity = new Vector3(0, v, 0) * speed;

        if (Input.GetKeyDown(KeyCode.Space) && !FunctionManager.ballInst)
        {
            CmdSpawnBall();
        }
    }

    [Command]
    void CmdSpawnBall()
    {
        GameObject Ball = Instantiate(ballPrefab, transform.position,
            new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

        NetworkServer.Spawn(Ball);
    }

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
    }
}
