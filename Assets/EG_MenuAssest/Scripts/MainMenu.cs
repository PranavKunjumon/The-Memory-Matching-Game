using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject SettingsPanel;
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    void Start()
    {
        SettingsPanel.SetActive(false); // Paneli baþlangýçta devre dýþý býrak
    }

    public void OpenSettingsPanel()
    {
        SettingsPanel.SetActive(true);
    }
    public void CloseSettingsPanel()
    {
        SettingsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit(); // Oyunu kapat
    }

    public void Setaudio(float value)
    {
        AudioListener.volume = value;
    }
}
