using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
   //! 타이틀 화면으로 넘어간다.
    public void GoTitleScene()
    {
        GFunc.LoadScene("01.TitleScene");
    }
    public void GoGameOverScene()
    {
        GFunc.LoadScene("05.GameOverScene");
    }
}
