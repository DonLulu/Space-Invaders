using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager: MonoBehaviour
{
    public Player player;
    public GameObject menu;
    private bool hasGameStarted;

    public bool HasGameStarted
    {
        get => hasGameStarted;
        set => hasGameStarted = value;
    }

    private void Update()
    {
        if (player.GameOver)
        {
            menu.SetActive(true);
            player.GameOver = false;
        }
    }

    public void StartButtonPressed()
    {
        menu.SetActive(false);
        hasGameStarted = true;
        player.gameObject.SetActive(true);
        player.scoreInt = 0;
        
    }
}
