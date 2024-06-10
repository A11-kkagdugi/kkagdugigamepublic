using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class MainMenuUI : MonoBehaviour
{
    public GameObject OptionUI;
    public GameObject SoundPanel;
    public GameObject VolumePanel;
    public Button soundButton;
    public Button volumeButton;
    public Slider volumeSlider;


    void Start()
    {
        OptionUI.SetActive(false);
        SoundPanel.SetActive(false);
        VolumePanel.SetActive(false);
    }

 
    public void OpenChallengePanel()
    {
        AchievementManager.Instance.ShowChallengeUI();
    }

    public void CloseChallengePanel() 
    {
        AchievementManager.Instance.HideChallengeUI();
    }

    public void OpenOptions()
    {
        OptionUI.SetActive(true);
    }


    public void CloseOptions()
    {
        OptionUI.SetActive(false);
    }

    public void OpenSoundPanel()
    {
        SoundPanel.SetActive(true);
    }

    public void CloseSoundPanel()
    {
        SoundPanel.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    // 온 버튼 클릭 시 음악 재생
    public void OnButtonClicked()
    {
        SoundManager.instance.bgmSource.Play();
        SoundManager.instance.isSoundOn = true;
    }


    // 오프 버튼 클릭 시 음악 일시정지
    public void OffButtonClicked()
    {
        SoundManager.instance.bgmSource.Pause();
        SoundManager.instance.isSoundOn = false;
    }


    public void OpenVolumePanel()
    {
        VolumePanel.SetActive(true);
    }


    public void CloseVolumePanel()
    {
        VolumePanel.SetActive(false);
    }


    public void SetVolume(float volume)
    {
        SoundManager.instance.SetVolume(volume);
    }
}