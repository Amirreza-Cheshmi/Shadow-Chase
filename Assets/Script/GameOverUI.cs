using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverUI : MonoBehaviour
{
    public CanvasGroup gameOverPanel;
    public CanvasGroup pausePanel;
    public Animator playerAnimator;
    public string gameOverAnimName = "Hand";
    public string mainMenuScene = "Menu";

    public void ShowGameOver()
    {
        StartCoroutine(ShowAfterAnimation());
    }

    private IEnumerator ShowAfterAnimation()
    {
        yield return new WaitUntil(() =>
            playerAnimator.GetCurrentAnimatorStateInfo(0).IsName(gameOverAnimName) &&
            playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f
        );

        pausePanel.alpha = 0;
        pausePanel.interactable = false;
        pausePanel.blocksRaycasts = false;

        gameOverPanel.alpha = 1;
        gameOverPanel.interactable = true;
        gameOverPanel.blocksRaycasts = true;
        Time.timeScale = 0f;
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuScene);
    }
}
