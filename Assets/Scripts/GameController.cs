using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    int coins = 0;
    public int currentLevelNu = 0;
    public GameLevel[] levelsArray= new GameLevel[2];

    public static GameController current;



    // Use this for initialization
    void Awake()
    {
        current = this;
    }

    public void setCurrentLevel(int newLevelNu)
    {
        currentLevelNu = newLevelNu;
        Debug.Log(newLevelNu);
    }
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
