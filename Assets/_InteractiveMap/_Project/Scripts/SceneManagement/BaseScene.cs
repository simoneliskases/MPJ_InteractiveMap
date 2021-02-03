using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseScene : MonoBehaviour
{
    public GameObject layerBase;
    [HideInInspector]
    public GameObject tempLayer;

    [Header("Main Scene")]
    public GameObject main;

    [Header("Minigame")]
    public GameObject minigameBase;
    public GameObject minigameSettings;
    public GameObject minigameSelection;

    [Header("Time Slider")]
    public GameObject sliderBase;

    [Header("Loading Screen")]
    public GameObject loadingScreen;
    public Slider loadingSlider;

    private void OnEnable()
    {
        tempLayer = main;
    }
}
