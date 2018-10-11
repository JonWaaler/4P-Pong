using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Ball : NetworkBehaviour
{
    public float speed = 10.0f;

    FunctionManager manager;

	// Use this for initialization
	void Start ()
    {
        manager = GameObject.Find("FunctionManager")
            .GetComponent<FunctionManager>();

        FunctionManager.ballInst = true;

        // Start on the left side
        if (gameObject.transform.position.x < 0)
        {
            gameObject.transform.position = gameObject.transform.position + new Vector3(0.5f, 0.0f, 0.0f);

            GetComponent<Rigidbody>().velocity = Vector3.right * speed;
        }
        // Start on the right side
        else
        {
            gameObject.transform.position = gameObject.transform.position + new Vector3(-0.5f, 0.0f, 0.0f);

            GetComponent<Rigidbody>().velocity = Vector3.left * speed;
        }
	}

    float hitFactor(Vector3 ballPosition, Vector3 racketPosition, float racketHeight)
    {
        return (ballPosition.y - racketPosition.y) / racketHeight;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "LeftPlayer")
        {
            float y = hitFactor(transform.position,
                            col.transform.position,
                            col.collider.bounds.size.y);
            Vector3 dir = new Vector3(1, y, 0) * speed;

            GetComponent<Rigidbody>().velocity = dir;
        }
        else if (col.gameObject.name == "RightPlayer")
        {
            float y = hitFactor(transform.position,
                            col.transform.position,
                            col.collider.bounds.size.y);
            Vector3 dir = new Vector3(-1, y, 0) * speed;

            GetComponent<Rigidbody>().velocity = dir;
        }
        else if (col.gameObject.name == "LeftGoal")
        {
            manager.CmdGoal(true, gameObject);
        }
        else if (col.gameObject.name == "RightGoal")
        {
            manager.CmdGoal(false, gameObject);
        }
    }

    void OnDestroy()
    {
        if (gameObject.transform.position.x < 0)
        {
            GameObject.Find("RightScore").GetComponent<Text>().text
                = manager.rightScore.ToString();
        }
        else if (gameObject.transform.position.x > 0)
        {
            GameObject.Find("LeftScore").GetComponent<Text>().text
                = manager.leftScore.ToString();
        }
        FunctionManager.ballInst = false;
    }
}
