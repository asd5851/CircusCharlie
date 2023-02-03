using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CameraMove : MonoBehaviour
{
    public GameObject player;
    private void Start()
    {
       // player = GameObject.FindGameObjectWithTag ("Player");
    }

    void Update()
    {   // 카메라의 위치를 플레이어로 고정시킨다.
        transform.position = new Vector3(player.transform.position.x, 0, transform.position.z);
    }
}
