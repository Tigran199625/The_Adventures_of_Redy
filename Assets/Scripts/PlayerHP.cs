using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public Text hpText;
    public GameObject player;

    private float playerHealth;
    // Update is called once per frame
    void Update()
    {
        playerHealth = player.GetComponent<Health>().health;
        hpText.text = playerHealth.ToString();
    }
}
