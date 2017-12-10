using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPopUp : MonoBehaviour
{

    public MyButton closeButton;
    public MyButton backgroundButton;
    public TweenAlpha backgroundAnimation;
    public TweenPosition popupAnimation;
    public MyButton soundButton;
    public MyButton musicButton;
    bool soundOn;
    bool musicOn;

    public void close()
    {
        Time.timeScale = 1;
        NGUITools.Destroy(this.gameObject);
    }

    private void Start()
    {
        closeButton.signalOnClick.AddListener(this.close);
        backgroundButton.signalOnClick.AddListener(this.close);
        soundButton.signalOnClick.AddListener(this.sound);
        musicButton.signalOnClick.AddListener(this.music);
        backgroundAnimation.PlayForward();
        if(PlayerPrefs.GetInt("sound", 1) == 1)
        {
            soundOn = true;
        }
        if (PlayerPrefs.GetInt("music", 1) == 1)
        {
            musicOn = true;
        }
        Time.timeScale = 0;
    }

    public void sound()
    {
        soundOn = !soundOn;
        SoundManager.Instance.setSoundOn(soundOn);
    }

    public void music()
    {
        musicOn = !musicOn;
        LevelController.current.setMusicOn(musicOn);
    }

    public void setFruitsCount(int total, int collected)
    {

    }

   
}
