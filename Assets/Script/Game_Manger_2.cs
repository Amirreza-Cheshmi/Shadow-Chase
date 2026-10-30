using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Game_Manger_2 : MonoBehaviour
{
    public CanvasGroup exitpanel;

    private void Start()
    {
        exitpanel.alpha = 0;
        exitpanel.interactable = false;
        exitpanel.blocksRaycasts = false;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GsmePlay");
        Debug.Log("StartGame");
    }

    public void showpanel()
    {
        exitpanel.alpha = 1;
        exitpanel.interactable = true;
        exitpanel.blocksRaycasts = true;
    }

    public void closepanel()
    {
        exitpanel.alpha = 0;
        exitpanel.interactable = false;
        exitpanel.blocksRaycasts = false;
    }

    public void QuitGame()
    {
        // در حالت Build شده برنامه را می‌بندد
        Application.Quit();

        // در حالت ادیتور یونیتی فقط این خط برای تست
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Debug.Log("QuitGame");
    }

}
