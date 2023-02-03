using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ObstacleMove : MonoBehaviour
{
    GameObject item ;
    private const int OBSTACLE_SPEED = 2;
    void Start()
    { 
       SetItem();
    }
    
    //! 장애물에 아이템을 붙인다.
    void SetItem()
    {
        item = gameObject.FindChildObj("Item");
       int a = Random.Range(0,3);
        if(a==0){
           item.SetActive(false); 
        }
    }       // SetItem

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-Time.deltaTime*OBSTACLE_SPEED,0,0);
        if(transform.position.x < 0)
        {
            ObjectPooling.ReturnObject(gameObject);
        }
    }       // Update
}
