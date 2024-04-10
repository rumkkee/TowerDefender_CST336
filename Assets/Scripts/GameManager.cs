using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;

    public GameObject gameOverUI;
    public Cinemachine.CinemachineVirtualCamera gameOverCam;

    private void Start()
    {
        GameIsOver = false;
    }

    private void Update()
    {
        if (GameIsOver) { return; }

        /*if (Input.GetKeyDown("e"))
        {
            PlayerStats.lives = 0;
            EndGame();
        }*/

        if(PlayerStats.lives <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
        gameOverCam.Priority += 2;
        //Debug.Log("Game Over!");
    }
}
