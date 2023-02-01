using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ObstacleMove : MonoBehaviour
{
    private float height = default;
    void Awake()
    {
    }
    void Start()
    {
       
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
