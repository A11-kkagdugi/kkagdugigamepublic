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

    // 게임 계속하기
    private void Continue()
    {
        Time.timeScale = 1f;
        Pause.SetActive(false);
    }

    // 일시정지 UI 활성화, 게임 일시정지
    public void ActivatePauseUI()
    {
        Pause.SetActive(true);
        Time.timeScale = 0f;
        AchievementManager.Instance.PauseAchievedUI(); // 수정된 부분
    }

    // 옵션 창 열기
    public void OpenOptions()
    {
        Pause.SetActive(false);// PauseUI 비활성화
        OptionUI.SetActive(true);
        Time.timeScale = 0f; // 일시정지 상태 유지
    }

    // 옵션 창 닫기
    public void CloseOptions()
    {
        OptionUI.SetActive(false);
        if (currentSceneName != "MainScene")
        {
            Pause.SetActive(true);
            Time.timeScale = 0f;
        }
    }


    // 메인 메뉴로 이동
    private void GoToMainMenu()
    {
        Time.timeScale = 1f; // 일시정지 해제
        SceneManager.LoadScene("MainScene");
    }
}
