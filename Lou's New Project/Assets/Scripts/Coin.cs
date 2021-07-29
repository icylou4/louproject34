using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    GameManager gameManager;
    CoinManager coinManager;
    public int value;
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        coinManager = gameManager.coinManager;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") 
        {
            GainCoin();
        }
    }
    void GainCoin()
    {
        coinManager.GainCoins(value);
        Destroy(gameObject);
    }
}
