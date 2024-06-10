using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager Instance;

    public GameObject AchievementUI;
    public TextMeshProUGUI AchievementText;
    public GameObject ChallengeUI;
    public TextMeshProUGUI ChallengeStatusText;

    private bool _hasPaused = false;
    private bool _challengeCompleted = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        AchievementUI.SetActive(false);
        ChallengeUI.SetActive(false);

        // 게임 시작 시 저장된 업적 및 챌린지 상태를 불러옵니다.
        LoadAchievements();
    }

    // 게임 시작 시 저장된 업적 및 챌린지 상태를 불러오는 메서드
    private void LoadAchievements()
    {
        _hasPaused = PlayerPrefs.GetInt("HasPaused", 0) == 1;
        _challengeCompleted = PlayerPrefs.GetInt("ChallengeCompleted", 0) == 1;

        // 업적 및 챌린지 상태에 따라 UI를 업데이트합니다.
        RefreshChallengeStatus();
    }

    // 일시정지 업적 달성 처리
    public void PauseAchieved()
    {
        if (!_hasPaused)
        {
            _hasPaused = true;
            SaveAchievements();
        }
    }

    // 챌린지 완료 처리
    public void ChallengeCompleted()
    {
        _challengeCompleted = true;
        SaveAchievements();
    }

    // 업적 및 챌린지 상태를 저장하는 메서드
    private void SaveAchievements()
    {
        PlayerPrefs.SetInt("HasPaused", _hasPaused ? 1 : 0);
        PlayerPrefs.SetInt("ChallengeCompleted", _challengeCompleted ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void PauseAchievedUI()
    {
        if (!_hasPaused)
        {
            _hasPaused = true;
            StartCoroutine(ShowAchievementMessage("시공간을 지배하는 자"));
            RefreshChallengeStatus();
        }
    }

    private IEnumerator ShowAchievementMessage(string achievement)
    {
        AchievementText.text = achievement;
        AchievementUI.SetActive(true);
        // 1초 후에 알림을 비활성화합니다.
        yield return new WaitForSecondsRealtime(1f);
        AchievementUI.SetActive(false);
    }

    public void ShowChallengeUI() // OpenChallengeUI에서 ShowChallengeUI로 변경
    {
        ChallengeUI.SetActive(true);
    }

    public void HideChallengeUI() // CloseChallengeUI에서 HideChallengeUI로 변경
    {
        ChallengeUI.SetActive(false);
    }

    private void RefreshChallengeStatus()
    {
        if (_hasPaused)
        {
            ChallengeStatusText.text = "시공간을 지배하는 자: 달성";
        }
        else
        {
            ChallengeStatusText.text = "시공간을 지배하는 자: 미달성";
        }
    }
}
