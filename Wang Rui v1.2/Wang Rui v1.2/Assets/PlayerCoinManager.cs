using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCoinManager : MonoBehaviour {

    public Text coinText;
    private int coinCount;
    public int coins;

	// Use this for initialization
	void Start () {
        coinCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void AddCoin(int coinsToAdd)
    {
        coinCount += coinsToAdd;
        coins = coinCount;
        coinText.text = coinCount.ToString();
    }
}
