using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MinigameSelection : MonoBehaviour
{
    public TextMeshProUGUI inputText;
    public GameObject carOne, carTwo, carThree;

    private string _playerName;
    private GameObject _selectedCar;

    private void Update()
    {
        _playerName = inputText.text;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit mouseHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out mouseHit))
            {
                _selectedCar = mouseHit.collider.gameObject;                                
            }
        }     
    }

    private void OnDisable()
    {
        PlayerPrefs.SetString("playerName", _playerName);
        PlayerPrefs.SetString("selectedCar", _selectedCar.ToString());
    }
}
