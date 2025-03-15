using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject _canvasGameObject;

    private bool isPaused = false;
    private GameObject panelButtons;

    public void OpenPanel (GameObject panelGameObject)
    {
        Instantiate(panelGameObject, _canvasGameObject.transform);
    }



    public void PauseGame(GameObject pauseMenu)
    {
        if (isPaused == false)
        {
            // in case we want to open the settings menu when the player pauses the game
            pauseMenu.SetActive(true);

            // disable the interactivity of all buttons
            //...

            // slow down time
            Time.timeScale = 0;

            // set the bool so that game knows if its paused or not
            isPaused = true;


        }
        else if (isPaused == true)
        {
            pauseMenu.SetActive(false);

            Time.timeScale = 1;

            isPaused = false;
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
