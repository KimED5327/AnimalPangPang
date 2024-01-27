using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance;


    public static ScoreManager Instance
    {
        get
        {
            return instance;
        }
    }


    [SerializeField] private Button btn_Stop;
    [SerializeField] private TextMeshProUGUI txt_Score;


    private int curScore;


    private void Awake()
    {
        instance = this;
        Init();
    }


    public void Init()
    {
        curScore = 0;
        txt_Score.text = $"0";

        btn_Stop.onClick.AddListener(() => Time.timeScale = Time.timeScale <= 0 ? 1 : 0);
    }


    public void IncreaseScore(int level)
    {
        int addScore = level * 10;
        curScore += addScore;


        txt_Score.text = $"{curScore:#,##0}";
    }

}
