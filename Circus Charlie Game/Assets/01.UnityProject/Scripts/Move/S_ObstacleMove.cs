using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ObstacleMove : MonoBehaviour
{
    private float height = default;
    
    GameObject item ;
    void Start()
    {
       item = gameObject.FindChildObj("Item");
       int a = Random.Range(0,3);
        Debug.Log($"a = {a}");
        if(a==0){
           item.SetActive(false); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(-Time.deltaTime*2,0,0);
        if(transform.position.x < 0)
        {
            ObjectPooling.ReturnObject(gameObject);
        }
    }
}
