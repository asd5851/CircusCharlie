using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_LionController : MonoBehaviour
{
    // Start is called before the first frame update
    
    S_PlayerController player;
    Animator anim;
    void Start()
    {
        // 부모 오브젝트의 컴포넌트 찾기
        player = gameObject.GetComponentInParent<S_PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Platform")
        {
            player.isjump = false;
        }
    }
}
