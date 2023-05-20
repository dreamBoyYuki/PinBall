using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    //表示する得点
    private int totalScore;

    //タグの文字列を定数化
    private const string S_STAR_TAG  = "SmallStarTag";
    private const string L_STAR_TAG  = "LargeStarTag";
    private const string S_CLOUD_TAG = "SmallCloudTag";
    private const string L_CLOUD_TAG = "LargeCloudTag";
    
    //各ターゲットの得点
    enum SCORE
    {
        S_STAR  = 1,
        L_STAR  = 5,
        S_CLOUD = 10,
        L_CLOUD = 20
    }

    // Start is called before the first frame update
    void Start()
    {
        totalScore = 0;
        scoreText.text = "SCORE:" + totalScore.ToString("000");
    }


    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case S_STAR_TAG:
                totalScore += (int)SCORE.S_STAR;
                break;
            case L_STAR_TAG:
                totalScore += (int)SCORE.L_STAR;
                break;
            case S_CLOUD_TAG:
                totalScore += (int)SCORE.S_CLOUD;
                break;
            case L_CLOUD_TAG:
                totalScore += (int)SCORE.L_CLOUD;
                break;
        }

        scoreText.text = "SCORE:" + totalScore.ToString("000");
    }
}
