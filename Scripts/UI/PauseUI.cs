using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    public Button PauseUIBtn;
    public Button PlayBtn;
    public Button OptionBtn;
    public Button MainBtn;

    public GameObject Pause;
    public GameObject OptionUI;

    private string currentSceneName;

    void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        PauseUIBtn.onClick.AddListener(ActivatePauseUI);
        PlayBtn.onClick.AddListener(Continue);
        OptionBtn.onClick.AddListener(OpenOptions);
        MainBtn.onClick.AddListener(GoToMainMenu);
        OptionUI.SetActive(false);
    }

    // ���� ����ϱ�
    private void Continue()
    {
        Time.timeScale = 1f;
        Pause.SetActive(false);
    }

    // �Ͻ����� UI Ȱ��ȭ, ���� �Ͻ�����
    public void ActivatePauseUI()
    {
        Pause.SetActive(true);
        Time.timeScale = 0f;
        AchievementManager.Instance.PauseAchievedUI(); // ������ �κ�
    }

    // �ɼ� â ����
    public void OpenOptions()
    {
        Pause.SetActive(false);// PauseUI ��Ȱ��ȭ
        OptionUI.SetActive(true);
        Time.timeScale = 0f; // �Ͻ����� ���� ����
    }

    // �ɼ� â �ݱ�
    public void CloseOptions()
    {
        OptionUI.SetActive(false);
        if (currentSceneName != "MainScene")
        {
            Pause.SetActive(true);
            Time.timeScale = 0f;
        }
    }


    // ���� �޴��� �̵�
    private void GoToMainMenu()
    {
        Time.timeScale = 1f; // �Ͻ����� ����
        SceneManager.LoadScene("MainScene");
    }
}
