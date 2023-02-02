using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = default;
    private GameObject scoreTxtObj = default;
    private GameObject TotalscoreTxtObj = default;
    private GameObject stageTxtObj = default;
    private GameObject gameOverUi = default;
    private const string UI_OBJS = "UiObjs";
    private const string SCORE_TEXT_OBJ = "ScoreTxt";
    private const string TOTAL_SCORE_TEXT_OBJ = "TotalScoreTxt";

    private const string STAGE_TEXT_OBJ = "StageTxt";
    private const string GAME_OVER_UI_OBJ = "GameOverUI";
    static float totalScore = default;
    static int curLevel = 1;
    private float curScore = default;
    public bool isGameOver = false;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;

            // Init
            isGameOver = false;
            GameObject uiObjs_ = GFunc.GetRootObj(UI_OBJS);
            scoreTxtObj = uiObjs_.FindChildObj(SCORE_TEXT_OBJ);
            stageTxtObj = uiObjs_.FindChildObj(STAGE_TEXT_OBJ);
            gameOverUi = uiObjs_.FindChildObj(GAME_OVER_UI_OBJ);
            TotalscoreTxtObj = uiObjs_.FindChildObj(TOTAL_SCORE_TEXT_OBJ);

            Debug.Log($"스코어 오브젝트 찾기 : {scoreTxtObj}");
            //Debug.Log($"스테이지 오브젝트 찾기 : {stageTxtObj}");


            curScore = 0;
            totalScore = 0;
        }   // if : 게임 매니저가 존재하지 않는 경우 변수에 할당 및 초기화
        else
        {
            GFunc.LogWarning("[System] GameManager : Duplicated object warning");
            Destroy(instance);
        }
    }

    //! 아이템을 습득하면 스코어가 오른다.
    public void GetScore()
    {
        if(isGameOver == true){return;}
        curScore += 100;
    }
    public void AddScore()
    {
        if(isGameOver == true){return;}
        curScore += Time.deltaTime;
        totalScore = curScore;
        Debug.Log($"{scoreTxtObj}");
        scoreTxtObj.SetTmpText($"Score : {Mathf.FloorToInt(curScore)}");
        TotalscoreTxtObj.SetTmpText($"TotalScore : {Mathf.FloorToInt(totalScore)}");
    }

    //! 스테이지를 넘어간다.
    public void NextStage()
    {
        if(isGameOver)
            return;
        // 현재 스테이지 점수를 토탈 점수에 더하고 현재 점수를 초기화
        curLevel += 1;
        totalScore = curScore;
        curScore = 0;
        GFunc.LoadScene("03.PlayScene2");
    }
    //! 타이틀 화면으로 넘어간다.
    public void GoTitleScene()
    {
        GFunc.LoadScene("01.TitleScene");
    }

    public void PlayerDie()
    {
        isGameOver = true;
        gameOverUi.SetActive(true);
    }
    void Start()
    {
        Debug.Log($"스테이지 오브젝트 찾기 : {stageTxtObj}");
        stageTxtObj.SetTmpText($"Stage - {curLevel}");
    }
    
    
    void Update()
    {
        AddScore();
        
    }
}
