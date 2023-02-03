using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_BallController : MonoBehaviour
{
    S_BallController ballController = default;
    GameObject gameObjs;
    // Start is called before the first frame update
    void Start()
    {
        ballController = GetComponent<S_BallController>();
        gameObjs = GFunc.GetRootObj("GameObjs");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            // float x = other.gameObject.GetComponent<RectTransform>().anchoredPosition.x;
            // float y = other.gameObject.GetComponent<RectTransform>().anchoredPosition.y;
            // gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(x,y-100);
        }
    }
}
