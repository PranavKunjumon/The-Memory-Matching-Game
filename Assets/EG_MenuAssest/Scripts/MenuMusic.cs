using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public Toggle musicToggle;
    public AudioSource musicAudioSource;

    private void Start()
    {
        // Kayýtlý müzik durumunu yükle
        if (PlayerPrefs.HasKey("MusicState"))
        {
            int musicState = PlayerPrefs.GetInt("MusicState");
            musicToggle.isOn = musicState == 1 ? true : false;
            UpdateMusicState(musicToggle.isOn);
        }

        // Toggle'ýn durumu deðiþtiðinde çalýþacak fonksiyonu atayýn
        musicToggle.onValueChanged.AddListener(OnMusicToggleChanged);
    }

    private void OnMusicToggleChanged(bool isOn)
    {
        UpdateMusicState(isOn);

        // Müzik durumunu kaydet
        PlayerPrefs.SetInt("MusicState", isOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void UpdateMusicState(bool isMusicOn)
    {
        if (isMusicOn)
        {
            musicAudioSource.Play();
        }
        else
        {
            musicAudioSource.Stop();
        }
    }
}

