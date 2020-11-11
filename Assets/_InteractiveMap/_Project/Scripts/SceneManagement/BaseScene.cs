using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScene : MonoBehaviour
{
    public GameObject layerBase;

    [Header("Main Scene")]
    public GameObject main;

    [Header("Minigame")]
    public GameObject minigameBase;
    public GameObject minigameSettings;
    public GameObject minigameSelection;

    [Header("Time Slider")]
    public GameObject sliderBase;

    public enum CurrentState    
    {
        MinigameBase,
        MinigameSettings,
        MinigameSelection,
        SliderBase,
    }

    public void StateInput(CurrentState state)
    {
        switch (state)
        {
            case CurrentState.MinigameBase:
                ChangeState(minigameBase);
                break;
            case CurrentState.MinigameSettings:
                ChangeState(minigameSettings);
                break;
            case CurrentState.MinigameSelection:
                ChangeState(minigameSettings);
                break;
            case CurrentState.SliderBase:
                ChangeState(sliderBase);
                break;
        }
    }

    private void ChangeState(GameObject layer)
    {
        foreach(Transform child in layerBase.transform)
        {
            if(child == layer)
            {
                layer.SetActive(true);
            }
            else if(layer != null)
            {
                layer.SetActive(false);
            }
        }
    }
}
