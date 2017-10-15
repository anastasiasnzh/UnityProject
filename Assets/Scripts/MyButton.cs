using System.Collections;
using UnityEngine.Events;
using UnityEngine;
public class MyButton : MonoBehaviour
{
    public UnityEvent signalOnClick = new UnityEvent();
    public void _onClick()
    {
        //Debug.Log("MyButton.onClick");
        this.signalOnClick.Invoke();
    }
}