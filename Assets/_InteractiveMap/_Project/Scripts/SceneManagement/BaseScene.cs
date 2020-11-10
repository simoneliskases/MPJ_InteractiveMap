using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseScene : MonoBehaviour
{
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
        Main,
        MinigameBase,
        MinigameSettings,
        MinigameSelection,
        SliderBase,
    }
    private CurrentState _state;

    private string _minigameTag;

    private void Start()
    {
        //minigameBase.gameObject.tag = _minigameTag;
        //minigameSettings.gameObject.tag = _minigameTag;
        //minigameSelection.gameObject.tag = _minigameTag;
    }

    public void PlayMinigame()
    {
        SceneManager.LoadScene(1);        
    }

    public void PlaySlider()
    {
        //Load Time Slider
    }

    public void Selection()
    {
        _state = CurrentState.MinigameSelection;
    }

    public void CloseSelection()
    {
        _state = CurrentState.MinigameBase;
    }

    public void Settings()
    {
        minigameSettings.SetActive(true);
        minigameBase.SetActive(false);        
        _state = CurrentState.MinigameSettings;
    }
    
    public void CloseSettings()
    {
        minigameBase.SetActive(true);
        minigameSettings.SetActive(false);
        _state = CurrentState.MinigameSettings;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (_state)
            {
                case CurrentState.MinigameBase:
                    //something
                    break;
                case CurrentState.MinigameSettings:
                    CloseSettings();
                    break;
                case CurrentState.MinigameSelection:
                    CloseSelection();
                    break;
            }
        }
    }
}
