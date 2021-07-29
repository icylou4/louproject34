using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int coins;
    public Text coinText;
    void Start()
    {
        coinText.text = ""+coins;
        coins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GainCoins(int amount)
    {
        coins+=amount;
        print(coins);
        coinText.text=""+coins;
    }
}
