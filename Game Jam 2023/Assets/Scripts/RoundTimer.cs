using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoundTimer : MonoBehaviour
{
    public float currentTime = 0f;
    public TextMeshProUGUI roundTimeText;
    SettingsMenu settingsMenu;

    public void Start()
    {
        settingsMenu = FindFirstObjectByType<SettingsMenu>();
        Debug.Log(settingsMenu.startingTime);
        currentTime = settingsMenu.startingTime;
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        roundTimeText.text = currentTime.ToString("0");

        if(currentTime <= 0)
        {
            currentTime = 0;
            SceneManager.LoadScene(5);
        }
    }
}
