using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ObstacleSpawn : MonoBehaviour
{
    //public GameObject player;
    float delay_cur = 0;
    float delay_max = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Delay();
        
    }
    void Delay()
    {
        delay_cur = delay_cur + Time.deltaTime;
        if(delay_max > delay_cur)
        {
            return;
        }
        delay_cur = 0;
        var obstacleA = ObjectPooling.GetObject();
        obstacleA.transform.position = transform.position;
    }
}
