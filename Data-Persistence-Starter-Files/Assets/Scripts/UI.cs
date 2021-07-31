using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UI : MonoBehaviour
{
    public InputField playerName;
    public PlayerData playerData;
    public Text Scores;
    bool once = true;
    private void Awake()
    {
        playerData = FindObjectOfType<PlayerData>();
        if( playerData == null)
        {
            SceneManager.sceneLoaded += GetPlayerData;
            SceneManager.LoadScene("playerData", LoadSceneMode.Additive);
        }
            

    }
    private void Update()
    {
        if (playerData == null)
        {
            playerData = FindObjectOfType<PlayerData>();
        }
        else
        {
            if(once)
            {
                if (playerName.text == "")
                {
                    playerName.text = playerData.player;
                    Scores.text = playerData.GetScores();
                }
                once = false;
            }
        }
    }

    private void GetPlayerData(Scene arg0, LoadSceneMode arg1)
    {
        SceneManager.sceneLoaded -= GetPlayerData;
        playerData = FindObjectOfType<PlayerData>();
    }

    public void Submit()
    {
        playerData.player = playerName.text;
        SceneManager.LoadScene("main", LoadSceneMode.Single);
    }
    public void Quit()
    {
        Application.Quit();
    }

    
}
