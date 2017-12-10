using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPopUp : MonoBehaviour
{
    public MyButton closeButton;
    public MyButton backgroundButton;
    public TweenAlpha backgroundAnimation;
    public TweenPosition popupAnimation;
    public MyButton replayLevel;
    public MyButton arrow;

    public void close()
    {
        Time.timeScale = 1;
        NGUITools.Destroy(this.gameObject);
    }

    private void Start()
    {
        closeButton.signalOnClick.AddListener(this.close);
        backgroundButton.signalOnClick.AddListener(this.close);
        replayLevel.signalOnClick.AddListener(this.replay);
        arrow.signalOnClick.AddListener(this.menu);
        backgroundAnimation.PlayForward();

        Time.timeScale = 0;
    }

    public void replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        NGUITools.Destroy(this.gameObject);
    }

    public void menu()
    {
        SceneManager.LoadScene("MainMenu");
        NGUITools.Destroy(this.gameObject);
    }
}
