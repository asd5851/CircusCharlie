using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Btn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnStage1Button()
    {
        GFunc.LoadScene("02.PlayScene1");
    }
    public void OnStage2Button()
    {
        GFunc.LoadScene("03.PlayScene2");
    }
}
