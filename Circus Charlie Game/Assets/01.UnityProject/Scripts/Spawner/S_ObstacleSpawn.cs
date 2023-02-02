using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ObstacleSpawn : MonoBehaviour
{
    //public GameObject player;
    private float delay_cur = 0;
    private float delay_max = 6;
    public GameObject player;
    private const int PLAYER_DISTANCE = 20;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.SetLocalPos(player.transform.position.x+PLAYER_DISTANCE,2,0);
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
