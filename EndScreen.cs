using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    public Score score;

    public Health health;

    public FrutSpawner FrutSpawner;

    public GameObject GameEndScreen;
    public GameObject GameScreen;


    private void Start()
    {
        SwitchScreen(true);
    }

    public void GameOver()
    {
        FrutSpawner.Activate(false);

        SwitchScreen(false);

    }

    public void RestartGame()
    {
        score.ResetScore();
        health.ResetHeals();
        FrutSpawner.Activate(true);
        SwitchScreen(true);
    }

    private void SwitchScreen(bool isGame)
    {
        GameScreen.SetActive(isGame);
        GameEndScreen.SetActive(!isGame);
    }
}
