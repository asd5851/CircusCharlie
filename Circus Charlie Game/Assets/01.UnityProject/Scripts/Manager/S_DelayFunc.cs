using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_DelayFunc : MonoBehaviour
{
    float delay_cur = 0;
    public float delay_max = default;
    public void Delay()
    {
        delay_cur = delay_cur + Time.deltaTime;
        if(delay_max > delay_cur)
        {
            return;
        }
        delay_cur = 0;
    }
}
