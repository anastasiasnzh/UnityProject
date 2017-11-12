using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpBase : MonoBehaviour {

    public MyButton closeButton;
    public MyButton backgroundButton;
    public TweenAlpha backgroundAnimation;
    public TweenPosition popupAnimation;

    public void close()
    {
        Time.timeScale = 1;
        NGUITools.Destroy(this.gameObject);
    }

    private void Start()
    {
        closeButton.signalOnClick.AddListener(this.close);
        backgroundButton.signalOnClick.AddListener(this.close);

        backgroundAnimation.PlayForward();

        Time.timeScale = 0;
    }
}
