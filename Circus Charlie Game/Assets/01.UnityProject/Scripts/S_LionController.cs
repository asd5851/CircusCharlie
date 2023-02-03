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
        // 부모 오브젝트의 컴포넌트 찾기 (플레이어의 오브젝트의 스크립트를 찾는다.)
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
            // 플레이어 오브젝트의 스크립트의 isjump를 false로 변경한다.
            player.isjump = false;
        }
    }
}
