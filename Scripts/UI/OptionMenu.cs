using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    public Button soundButton;
    public Button volumeButton;
    public GameObject soundPanel;
    public GameObject volumePanel;
    public Button optionExitBtn;
    public Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        volumeButton.onClick.AddListener(OpenVolumePanel);
        volumeSlider.onValueChanged.AddListener(SetVolume);
        volumeSlider.value = SoundManager.instance.GetVolume();
        soundPanel.SetActive(false);
        volumePanel.SetActive(false);
    }

    // 사운드 버튼 클릭 시 사운드 패널 열기
    public void OpenSoundPanel()
    {
        soundPanel.SetActive(true);
    }

    // 볼륨 조절 패널 열기
    public void OpenVolumePanel()
    {
        volumePanel.SetActive(true);
    }

    // 볼륨 조절
    private void SetVolume(float volume)
    {
        SoundManager.instance.SetVolume(volume);
    }

    // 볼륨 패널 닫기
    public void CloseVolumePanel()
    {
        volumePanel.SetActive(false);
    }
}