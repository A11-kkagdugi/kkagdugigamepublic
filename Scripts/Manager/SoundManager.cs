using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource bgmSource;

    public bool isSoundOn = true; // 사운드 On/Off 상태 저장
    private float volumeLevel = 0.5f; // 음향 크기 저장

    private void Awake()
    {
        // 싱글톤 패턴 적용
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        // bgmSource에 대한 참조 설정
        bgmSource = GetComponent<AudioSource>();

        // 초기 음향 설정
        bgmSource.volume = volumeLevel;
        bgmSource.Play();
    }

    public void PlayBGM(AudioClip bgmClip)
    {
        bgmSource.clip = bgmClip;
        bgmSource.Play();
    }


    public void StopBGM()
    {
        bgmSource.Stop();
    }

    // 사운드 On/Off 토글
    public void ToggleSound()
    {
        isSoundOn = !isSoundOn;
        if (isSoundOn)
        {
            bgmSource.Play(); // 배경 음악 재생
        }
        else
        {
            bgmSource.Pause(); // 배경 음악 일시정지
        }
    }


    public void SetVolume(float volume)
    {
        volumeLevel = volume;
        AudioSource bgmSource = GetComponent<AudioSource>();
        bgmSource.volume = volumeLevel;
    }


    public float GetVolume()
    {
        return volumeLevel;
    }
}