using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject _canvasGameObject;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private GameObject _buttonParent;

    private bool isPaused = false;
    private GameObject panelButtons;

    public void OpenPanel (GameObject panelGameObject)
    {
        panelGameObject.SetActive(true);
    }

    public void TempAddScoreButton()
    {
        _scoreManager.AddScore(10f);
    }

    public void PauseGame(GameObject pauseMenu)
    {
        if (isPaused == false)
        {
            // in case we want to open the settings menu when the player pauses the game
            pauseMenu.SetActive(true);

            // slow down time
            Time.timeScale = 0;

            // set the bool so that game knows if its paused or not
            isPaused = true;

            // disable the interactivity of all panel buttons
            var objs = GameObject.FindGameObjectsWithTag("PanelButton");
            Button[] buttons = new Button[objs.Length];
            for (var i = 0; i < objs.Length; i++)
            {
                buttons[i] = objs[i].GetComponent<Button>();
                buttons[i].interactable = false;
            }

            // close all panels
            GameObject[] panels = GameObject.FindGameObjectsWithTag("Panel");
            for (var i = 0; i < objs.Length; i++)
            {
                panels[i].SetActive(false);
            }

        }
        else if (isPaused == true)
        {
            pauseMenu.SetActive(false);

            Time.timeScale = 1;

            isPaused = false;

            var objs = GameObject.FindGameObjectsWithTag("PanelButton");
            Button[] buttons = new Button[objs.Length];
            for (var i = 0; i < objs.Length; i++)
            {
                buttons[i] = objs[i].GetComponent<Button>();
                buttons[i].interactable = true;
            }

            GameObject[] panels = GameObject.FindGameObjectsWithTag("Panel");
        }

    }

    public void playGame()
    {
        //SceneManager.LoadScene(WhateverTheSceneIsCalled);
    }

    public void exitGame()
    {
        Application.Quit();
    }



}
