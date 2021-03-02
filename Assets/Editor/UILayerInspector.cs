using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.EditorCoroutines.Editor;
using UnityEditor;

[CustomEditor(typeof(BaseScene))]
public class UILayerInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (!Application.isPlaying)
        {
            BaseScene baseScene = (BaseScene)target;
            switch (baseScene.displayState)
            {
                case BaseScene.DisplayState.Main:
                    EditorCoroutineUtility.StartCoroutine(ChangeState(baseScene.main), this);
                    break;
                case BaseScene.DisplayState.MinigameBase:
                    EditorCoroutineUtility.StartCoroutine(ChangeState(baseScene.minigameBase), this);
                    break;
                case BaseScene.DisplayState.MinigameSettings:
                    EditorCoroutineUtility.StartCoroutine(ChangeState(baseScene.minigameSettings), this);
                    break;
                case BaseScene.DisplayState.MinigameSelection:
                    EditorCoroutineUtility.StartCoroutine(ChangeState(baseScene.minigameSelection), this);
                    break;
                case BaseScene.DisplayState.SliderBase:
                    EditorCoroutineUtility.StartCoroutine(ChangeState(baseScene.sliderBase), this);
                    break;
            }
        }
    }

    private IEnumerator ChangeState(GameObject layer)
    {
        yield return null;
        BaseScene baseScene = (BaseScene)target;

        baseScene.tempLayer.SetActive(false);
        layer.SetActive(true);
        baseScene.tempLayer = layer;
    }
}
