using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class player : NetworkBehaviour {

    public float Speed = 10F;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (isLocalPlayer)
        {
            int x, y;
            x = 0;y = 0;

            Rigidbody rb = GetComponent<Rigidbody>();

            if (Input.GetKey(KeyCode.W))
            {
                y = 1;
            }
            if (Input.GetKey(KeyCode.A))
            {
                x = -1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                y = -1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                x = 1;
            }

            //print("X: " + x + "    Y: " + y);
            rb.velocity = new Vector3(x * Time.deltaTime * Speed, y * Time.deltaTime * Speed, 0);
        }
	}
}
