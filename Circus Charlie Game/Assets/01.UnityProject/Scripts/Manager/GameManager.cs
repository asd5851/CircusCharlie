using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

            curScore = 0;
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

    //! 시간초가 지날때 마다 스코어를 +1 해준다.
    public void AddScore()
    {
        if(isGameOver == true){return;}
        curScore += Time.deltaTime;
        scoreTxtObj.SetTmpText($"Score : {Mathf.FloorToInt(curScore)}");
        TotalscoreTxtObj.SetTmpText($"TotalScore : {Mathf.FloorToInt(GScoreFunc.totalScore)+Mathf.FloorToInt(curScore)}");
    }

    //! 스테이지를 넘어간다.
    public void NextStage()
    {
        if(isGameOver)
            return;
        // 현재 스테이지 점수를 토탈 점수에 더하고 현재 점수를 초기화
        GScoreFunc.totalScore = curScore;
        GScoreFunc.stageNumber++;
        curScore = 0;
        GFunc.LoadScene("0"+(GScoreFunc.stageNumber+1)+".PlayScene"+GScoreFunc.stageNumber);
    }

    //! 스테이지를 체크해서 스테이지 텍스트를 업데이트해준다.
    private void StageCheck()
    {
        if(SceneManager.GetActiveScene().name == "02.PlayScene1")
        {
            stageTxtObj.SetTmpText($"Stage - 1");
            GScoreFunc.stageNumber = 1;

        }
        else if(SceneManager.GetActiveScene().name == "03.PlayScene2")
        {
            stageTxtObj.SetTmpText($"Stage - 2");
            GScoreFunc.stageNumber = 2;
        }
    }

    //! 플레이어가 죽었을 경우 게임오버 씬을 불러온다..
    public void PlayerDie()
    {
        isGameOver = true;
        GScoreFunc.totalScore = 0;
        GScoreFunc.stageNumber = 1;
        Invoke("GameOver",2f);
        //gameOverUi.SetActive(true);
    }
    private void GameOver()
    {
        GFunc.LoadScene("05.GameOverScene");
    }
    void Start()
    {
        StageCheck();
    }
    
    
    void Update()
    {
        AddScore();      
    }
}
