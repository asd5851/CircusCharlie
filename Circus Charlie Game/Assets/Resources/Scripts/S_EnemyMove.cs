using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_EnemyMove : MonoBehaviour
{
    Rigidbody2D rigid;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
         rigid.velocity = new Vector2(-1, rigid.velocity.y);
    }
}
