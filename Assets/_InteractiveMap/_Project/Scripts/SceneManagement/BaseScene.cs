using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
