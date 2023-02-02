using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonManager : MonoBehaviour
{
    GameObject player;
    S_PlayerController playerScript;
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<S_PlayerController>();
        Debug.Log(playerScript.inputJump);
    }
    public void LeftDown()
    {
        Debug.Log("왼쪽누름");
        playerScript.inputLeft = true;
    }
    public void LeftUp()
    {
        Debug.Log("왼쪽뗌");
        playerScript.inputLeft = false;
    }
    public void RightDown()
    {
        playerScript.inputRight = true;
    }
    public void RightUp()
    {
       playerScript.inputRight = false;
    }
    public void JumpClick()
    {
        Debug.Log("점프누름");
       playerScript.inputJump = true;
       playerScript.Move();
    }
}
