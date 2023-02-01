using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class S_PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigid;
    Animator anim;
    Image img;
    public float maxSpeed;
    public float jumpPower;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJumping",true);
        }
        //Stop Speed
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }
        if (Input.GetButton("Horizontal"))
        {
            //img.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }
    }
    void FixedUpdate()
    {
         float h = Input.GetAxisRaw("Horizontal");
        //rigid.velocity = new Vector2(h*v_Speed,transform.position);
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        // x축의 속도가 maxspeed보다 빠르다면
        if (rigid.velocity.x > maxSpeed)
        { //Right Max Speed
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if (rigid.velocity.x < maxSpeed * (-1))
        {//Left Max Speed
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        }
        Debug.DrawRay(rigid.position, Vector2.down, new Color(0,1,0));
        
    }
    //! 플레이어가 충돌했을때
    void OnCollisionEnter2D(Collision2D collision){
        
        if(collision.gameObject.tag == "Enemy"){
            Debug.Log($"맞앗니? : {rigid.velocity.y}");
            
            if(rigid.velocity.y <= 0)
            {
                Debug.Log("들어왓니?");
                OnDamaged(collision.transform.position);
                // if(transform.position.y > collision.transform.position.y)
                // {
                //     // Attack

                // }
                // else{
                //     Debug.Log("들어왓니?");
                // }
                
            }
        }
        else if(collision.gameObject.tag == "Obstacle"){
            rigid.AddForce(Vector2.up*5,ForceMode2D.Impulse);
            
            anim.SetTrigger("isDead");
            //OnDamaged(collision.transform.position);
        }
        else if(collision.gameObject.tag == "Item")
        {
            // 스코어 증가
        }
        else if(collision.gameObject.tag == "Platform")
        {
            anim.SetBool("isJumping",false);
        }
    }
    
    void OnDamaged(Vector2 targetPos){
        // Change Layer (Immortal Active)
        
        gameObject.layer = 11;

        // View Alpha
        img.color = new Color(1,1,1,0.4f);
        // ReactForce
        int dirc = transform.position.x - targetPos.x > 0 ? 1:-1;
        rigid.AddForce(new Vector2(dirc,1)*7,ForceMode2D.Impulse);
        //anim.SetTrigger("doDamaged");
        Invoke("OffDamaged",1);
    }
    void OffDamaged(){
        gameObject.layer = 10;
        img.color = new Color(1,1,1,1);
    }
}
