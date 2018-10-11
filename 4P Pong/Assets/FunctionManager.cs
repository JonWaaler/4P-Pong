using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class FunctionManager : NetworkBehaviour
{
    [SyncVar]
    public int leftScore = 0;

    [SyncVar]
    public int rightScore = 0;

    public static bool ballInst = false;

    public void CmdGoal(bool left, GameObject ball)
    {
        if (!isServer)
            return;

        if (left)
        {
            rightScore++;
            GameObject.Find("RightScore").GetComponent<Text>().text
                = rightScore.ToString();
            Destroy(ball);
        }
        else
        {
            leftScore++;
            GameObject.Find("LeftScore").GetComponent<Text>().text
                = leftScore.ToString();
            Destroy(ball);
        }
        ballInst = false;
    }
}
