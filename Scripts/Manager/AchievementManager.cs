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

        // ���� ���� �� ����� ���� �� ç���� ���¸� �ҷ��ɴϴ�.
        LoadAchievements();
    }

    // ���� ���� �� ����� ���� �� ç���� ���¸� �ҷ����� �޼���
    private void LoadAchievements()
    {
        _hasPaused = PlayerPrefs.GetInt("HasPaused", 0) == 1;
        _challengeCompleted = PlayerPrefs.GetInt("ChallengeCompleted", 0) == 1;

        // ���� �� ç���� ���¿� ���� UI�� ������Ʈ�մϴ�.
        RefreshChallengeStatus();
    }

    // �Ͻ����� ���� �޼� ó��
    public void PauseAchieved()
    {
        if (!_hasPaused)
        {
            _hasPaused = true;
            SaveAchievements();
        }
    }

    // ç���� �Ϸ� ó��
    public void ChallengeCompleted()
    {
        _challengeCompleted = true;
        SaveAchievements();
    }

    // ���� �� ç���� ���¸� �����ϴ� �޼���
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
            StartCoroutine(ShowAchievementMessage("�ð����� �����ϴ� ��"));
            RefreshChallengeStatus();
        }
    }

    private IEnumerator ShowAchievementMessage(string achievement)
    {
        AchievementText.text = achievement;
        AchievementUI.SetActive(true);
        // 1�� �Ŀ� �˸��� ��Ȱ��ȭ�մϴ�.
        yield return new WaitForSecondsRealtime(1f);
        AchievementUI.SetActive(false);
    }

    public void ShowChallengeUI() // OpenChallengeUI���� ShowChallengeUI�� ����
    {
        ChallengeUI.SetActive(true);
    }

    public void HideChallengeUI() // CloseChallengeUI���� HideChallengeUI�� ����
    {
        ChallengeUI.SetActive(false);
    }

    private void RefreshChallengeStatus()
    {
        if (_hasPaused)
        {
            ChallengeStatusText.text = "�ð����� �����ϴ� ��: �޼�";
        }
        else
        {
            ChallengeStatusText.text = "�ð����� �����ϴ� ��: �̴޼�";
        }
    }
}
