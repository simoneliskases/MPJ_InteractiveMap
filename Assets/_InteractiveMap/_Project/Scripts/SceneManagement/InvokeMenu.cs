﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InvokeMenu : MonoBehaviour
{
    public BaseScene sceneManager;

    public enum CurrentState
    {
        Main,
        MinigameBase,
        MinigameSettings,
        MinigameSelection,
        SliderBase,
        PlayMinigame,
        PlaySlider,
    }
    [SerializeReference]
    private CurrentState state;

    private void OnEnable()
    {
        sceneManager.tempLayer = sceneManager.main;
    }

    public void StateInput(InvokeMenu currState)
    {
        switch (currState.state)
        {
            case CurrentState.Main:
                ChangeState(sceneManager.main);
                break;
            case CurrentState.MinigameBase:
                ChangeState(sceneManager.minigameBase);
                break;
            case CurrentState.MinigameSettings:
                ChangeState(sceneManager.minigameSettings);
                break;
            case CurrentState.MinigameSelection:
                ChangeState(sceneManager.minigameSelection);
                break;
            case CurrentState.SliderBase:
                ChangeState(sceneManager.sliderBase);
                break;
            case CurrentState.PlayMinigame:
                SceneManager.LoadScene(1);
                break;
            case CurrentState.PlaySlider:
                //SceneManager.LoadScene(2);
                break;
        }
    }

    private void ChangeState(GameObject layer)
    {
        if (sceneManager.tempLayer != null)
        {
            sceneManager.tempLayer.SetActive(false);
        }

        layer.SetActive(true);
        sceneManager.tempLayer = layer;
    }
}
