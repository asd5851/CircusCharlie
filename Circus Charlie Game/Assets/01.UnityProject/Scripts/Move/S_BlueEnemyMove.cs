using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_BlueEnemyMove : MonoBehaviour
{
    Rigidbody2D rigid;
    private const int ENEMY_SPEED = 10;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
         rigid.velocity = new Vector2(-1*ENEMY_SPEED, rigid.velocity.y);
    }
}
