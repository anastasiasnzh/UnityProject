using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsPanel : MonoBehaviour {
    public UILabel coinsLabel;
    int coins_quantity;

    // Use this for initialization
    void Start () {
        coinsLabel.text = coins_quantity.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
