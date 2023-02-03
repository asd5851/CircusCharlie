using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_BlueEnemyMove : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    bool isJump = false;
    private float delay_cur = 0;
    private float delay_max = 3;
    private const int ENEMY_SPEED = 10;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        Jump();
        rigid.velocity = new Vector2(-1*ENEMY_SPEED, rigid.velocity.y);
        if(transform.position.x < 0)
        {
            ObjectPoolingBlueEnemy.ReturnObject(gameObject);
        }
    }
    void Jump()
    {
        int enemyJump = default;
        enemyJump =  Random.RandomRange(0,4);
        delay_cur = delay_cur + Time.deltaTime;
        if(delay_max > delay_cur)
        {
            return;
        }
        delay_cur = 0;
        if(enemyJump == 1 && !isJump)
        {
            rigid.AddForce(Vector2.up * 7, ForceMode2D.Impulse);
            anim.SetBool("isJumping",true);
            isJump = true;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        
        if(other.gameObject.tag == "Platform")
        {
            anim.SetBool("isJumping",false);
            isJump = false;
        }
    }
}
