using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinPicker : MonoBehaviour
{
    private float coins = 0;
    public TMP_Text coinsText;
    // "coll" is refers to an object, that's collider is triggered 
    private void OnTriggerEnter2D(Collider2D coll)
    {
        // If object (that have this script in components) enter in triggered collider
        if(coll.gameObject.tag == "Coin")
        {
            coins++;
            coinsText.text = coins.ToString();
            Destroy(coll.gameObject);
        }

        if(coins == 8)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
