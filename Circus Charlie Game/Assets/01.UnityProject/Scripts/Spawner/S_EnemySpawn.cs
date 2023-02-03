using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_EnemySpawn : MonoBehaviour
{
    // Start is called before the first frame update
    float delay_cur = 0;
    float delay_max = 3;
    private const int PLAYER_DISTANCE = 20;
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.SetLocalPos(player.transform.position.x+PLAYER_DISTANCE,
        player.transform.position.y,0);
        Delay();
    }

    //! 적을 스폰하는 시간을 설정한 후 일반적, 강한적을 랜덤으로 생성한다.
     void Delay()
    {
        int randomMonkey = Random.RandomRange(0,3);
        delay_cur = delay_cur + Time.deltaTime;
        if(delay_max > delay_cur)
        {
            return;
        }
        delay_cur = 0;
        if(randomMonkey < 2)
        {
            var enemyMonkey = ObjectPoolingEnemy.GetObject();
            enemyMonkey.transform.position = transform.position;
        }
        else
        {
            var enemyMonkey = ObjectPoolingBlueEnemy.GetObject();
            enemyMonkey.transform.position = transform.position;
        }
        
    }
}
