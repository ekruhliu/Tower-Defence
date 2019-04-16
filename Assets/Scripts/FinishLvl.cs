using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishLvl : MonoBehaviour
{
    [SerializeField] private Text ScoreL;
    [SerializeField] private Text GradeL;

    [SerializeField] private Text ScoreC;
    [SerializeField] private Text GradeC;
    
    [SerializeField] private GameObject Complete;
    [SerializeField] private GameObject Lose;
    
    [SerializeField] private string activeScene;
    
    void Start()
    {
        Complete.SetActive(false);
        Lose.SetActive(false);
    }

    void Update()
    {
        activeScene = SceneManager.GetActiveScene().name;
        if (gameManager.gm.playerHp <= 0)
        {
            gameManager.gm.gameOver();
            ScoreL.text = gameManager.gm.score.ToString();
            GradeL.text = "F";
            Lose.SetActive(true);
        }

        if (gameManager.gm.playerHp > 0 && gameManager.gm.endgame)
        {
            string rang = String.Empty;
            if ((gameManager.gm.playerHp == gameManager.gm.playerMaxHp) && gameManager.gm.score > 40000)
                rang = "SSS";
            else if (gameManager.gm.playerHp == gameManager.gm.playerMaxHp)
                rang = "S";
            else if ((gameManager.gm.playerHp < gameManager.gm.playerMaxHp) && (gameManager.gm.playerHp >= (gameManager.gm.playerMaxHp / 2)))
                rang = "A";
            else if ((gameManager.gm.playerHp) > 0 && (gameManager.gm.playerHp < (gameManager.gm.playerMaxHp / 2)))
                rang = "B";
            gameManager.gm.gameOver();
            ScoreC.text = gameManager.gm.score.ToString();
            GradeC.text = rang;
            Complete.SetActive(true);
        }
    }

    public void Retry() { Application.LoadLevel(activeScene); }

    public void NextLvl()
    {
        if (activeScene.Equals("ex01"))
            Application.LoadLevel("ex02");
        if (activeScene.Equals("ex02"))
            Application.LoadLevel("ex03");
        if (activeScene.Equals("ex03"))
            Application.LoadLevel("ex00");
    }
}
