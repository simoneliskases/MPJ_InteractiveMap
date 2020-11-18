using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InvokeMenu : MonoBehaviour
{
    public BaseScene sceneManager;

    public enum CurrentState
    {
        Main,
        RestrictedSettings,
        MinigameBase,
        MinigameSettings,
        MinigameSelection,
        SliderBase,
        PlayMinigame,
        PlaySlider,
    }
    [SerializeReference]
    private CurrentState state;

    public void StateInput(InvokeMenu currState)
    {
        switch (currState.state)
        {
            case CurrentState.Main:
                ChangeState(sceneManager.main);
                break;
            case CurrentState.RestrictedSettings:
                ChangeState(sceneManager.restrictedSettings);
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
                StartCoroutine(LoadAsynchronously(1));
                ChangeState(sceneManager.loadingScreen);
                break;
            case CurrentState.PlaySlider:
                StartCoroutine(LoadAsynchronously(2));
                ChangeState(sceneManager.loadingScreen);
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

    private IEnumerator LoadAsynchronously(int _sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(_sceneIndex);

        while (!operation.isDone)
        {
            float _progress = Mathf.Clamp01(operation.progress / 0.9f);
            sceneManager.loadingSlider.value = _progress;

            yield return null;
        }
    }
}
