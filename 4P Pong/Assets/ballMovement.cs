using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ballMovement : MonoBehaviour {
    public bool throwBall = false;
    public float speed;
    private Vector3 dir = Vector3.right;
    public GameObject UI_WinPanel;
    public Text UI_WinText;
	// Use this for initialization
	void Start () {
        dir *= speed;
        //GetComponent<Rigidbody>().velocity =(Vector3.right * speed);
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKeyDown(KeyCode.Space))
        //    throwBall = true;

        //if (throwBall)
        //{
        //    gameObject.GetComponent<Rigidbody>().AddForce((Vector3.right * Time.deltaTime * 100000));
        //    throwBall = false;
        //}
        //print("VEL: " + GetComponent<Rigidbody>().velocity);
    }
    public void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            float y = hitFactor(transform.position,
                                    col.transform.position,
                                    col.collider.bounds.size.y);
            float x = hitFactor(transform.position,
                                    col.transform.position,
                                    col.collider.bounds.size.x);
            dir = new Vector3(x, y, 0) * speed;

            GetComponent<Rigidbody>().velocity = dir;

        }
        if(col.gameObject.name == "Goal_Left")
        {
            //print("LEFT");
            //
            //Rigidbody rb = GetComponent<Rigidbody>();
            //dir = new Vector3(dir.x * -1, dir.y, 0);
            //GetComponent<Rigidbody>().velocity = dir;
            UI_WinPanel.SetActive(true);
            UI_WinText.text = "Left Player LOST";
        }
        if (col.gameObject.name == "Goal_Right")
        {
            //print("________BEGINNING_________");
            //print("RIGHT");
            //Rigidbody rb = GetComponent<Rigidbody>();
            //dir = new Vector3(dir.x * -1, dir.y, 0);
            //GetComponent<Rigidbody>().velocity = dir;
            UI_WinPanel.SetActive(true);
            UI_WinText.text = "RIght Player LOST";
        }
        if (col.gameObject.name == "Goal_Top")
        {
            //print("TOP");
            //
            //Rigidbody rb = GetComponent<Rigidbody>();
            //dir = new Vector3(dir.x, dir.y * -1, 0);
            //GetComponent<Rigidbody>().velocity = dir;
            UI_WinPanel.SetActive(true);
            UI_WinText.text = "Top Player LOST";
        }
        if (col.gameObject.name == "Goal_Bottom")
        {
            //print("BOTTOM");
            //
            //Rigidbody rb = GetComponent<Rigidbody>();
            //dir = new Vector3(dir.x, dir.y * -1, 0);
            //GetComponent<Rigidbody>().velocity = dir;
            UI_WinPanel.SetActive(true);
            UI_WinText.text = "Bottom Player LOST";
        }

    }
    float hitFactor(Vector3 ballPosition, Vector3 racketPosition, float racketHeight)
    {
        return (ballPosition.y - racketPosition.y) / racketHeight;
    }
}
