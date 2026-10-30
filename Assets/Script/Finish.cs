using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class Finish : MonoBehaviour
{
    public CanvasGroup GameoverPanel;
    public CanvasGroup pausePanel;
    public CanvasGroup victorypanel;
    public TextMeshProUGUI score;
    public TextMeshProUGUI score_panel;

    private void Start()
    {
        victorypanel.alpha = 0;
        victorypanel.interactable = false;
        victorypanel.blocksRaycasts = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameoverPanel.alpha = 0;
        GameoverPanel.interactable = false;
        GameoverPanel.blocksRaycasts = false;

        pausePanel.alpha = 0;
        pausePanel.interactable = false;
        pausePanel.blocksRaycasts = false;

        Time.timeScale = 0;
        victorypanel.alpha = 1;
        victorypanel.interactable = true;
        victorypanel.blocksRaycasts = true;

        score_panel.text = score.text;
    }

    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(1);
    }
}
