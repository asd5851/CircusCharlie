using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class S_PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigid= default;
    Animator anim= default;
    Image img= default;
    CircleCollider2D capsule_pl= default;
    BoxCollider2D lion = default;
    S_BallController ball = default;
    public float maxSpeed;
    public float jumpPower;
    public bool isjump = false;
    private bool lionCheck = false;

    // Mobile Key Var
    public bool inputLeft = false;
    public bool inputRight = false;
    public bool inputJump = false;
    bool checkBall = false;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        img = GetComponent<Image>();
        capsule_pl = GetComponent<CircleCollider2D>();
        if(gameObject.FindChildObj("PlayerLion"))
        {
            lionCheck = true;
            lion = gameObject.FindChildObj("PlayerLion").GetComponent<BoxCollider2D>();
        }
        else{
            lionCheck = false;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    //! 플레이어의 점프를 담당하는 함수
    public void Move()
    {
        if((inputJump  || Input.GetButtonDown("Jump")) && !isjump)
        {

            isjump = true;
            checkBall = true;
            rigid.AddForce(Vector2.up*jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJumping",true);
        }       // if : 점프키를 눌렀을 경우
        //Stop Speed
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }
        if (Input.GetButton("Horizontal"))
        {

        }
    }
    void FixedUpdate()
    {
        if(!isjump)
        {

            //Mobile
            if(inputLeft)
            {
                rigid.AddForce(Vector2.right * -1, ForceMode2D.Impulse);
            }
            if(inputRight)
            {
                rigid.AddForce(Vector2.right * 1, ForceMode2D.Impulse);
            }
            //PC
            float h = Input.GetAxisRaw("Horizontal");
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
        }       // if : 점프상태가 아닐떄 좌우이동가능
        
        else{
            /*Do Nothing*/
        }       // if : 점프상태 일떄 좌우이동 불가능
        
        
    }
    //! 플레이어가 충돌했을때
    void OnCollisionEnter2D(Collision2D collision){
        
        if(collision.gameObject.tag == "Enemy"){
            anim.SetTrigger("isDead");
           OnDamaged(collision.transform.position);
        }   // if : 적에 닿으면 죽는다.
        else if(collision.gameObject.tag == "Obstacle"){        
            anim.SetTrigger("isDead");
            OnDamaged(collision.transform.position);
        }   // if : 장애물에 닿으면 죽는다.
        else if(collision.gameObject.tag == "Item")
        {
            // 스코어 증가
        }
        else if(collision.gameObject.tag == "Platform")
        {
            isjump = false;
            anim.SetBool("isJumping",false);
        }   // if : 플랫폼에 닿아야 점프가 가능하다.
        else if(collision.gameObject.tag == "Finish")
        {
            gameObject.layer = 11;
            anim.SetTrigger("isFinish");
            Invoke("NextStage",4f);
        }   // if : 마지막 지점에 닿으면 다음스테이지로 넘어간다.
        else if(collision.gameObject.tag == "Ball") //&& checkBall == false)
        {
            Debug.Log("붙엇니?");
            isjump = false;
            float x = collision.gameObject.GetComponent<RectTransform>().anchoredPosition.x;
            float y = collision.gameObject.GetComponent<RectTransform>().anchoredPosition.y;
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(x,y+100);
            collision.gameObject.transform.SetParent(gameObject.transform);
            //checkBall = true;
           

        }
    }

    //! 다음스테이지로 넘어간다.
    void NextStage()
    {
        GameManager.instance.NextStage();
    }

    //! 장애물이나 적에게 닿았을 경우
    void OnDamaged(Vector2 targetPos){
        // Change Layer (Immortal Active)
        gameObject.layer = 11;
        // ReactForce
        int dirc = transform.position.x - targetPos.x > 0 ? 1:-1;
        rigid.AddForce(new Vector2(dirc,1)*10,ForceMode2D.Impulse); // 위로 튀어오른다.
        capsule_pl.enabled = false; // 플레이어의 콜라이더 해제
        if(lionCheck)
            lion.enabled = false;
        Die();
    }
    
    //! 플레이어가 죽었을 경우 게임매니저의 PlayerDie호출
    void Die()
    {
        GameManager.instance.PlayerDie();
    }

}
