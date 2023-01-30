using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;

/*   Method of oobject that taking damage
     and lose health*/
    public void TakeHit(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //Destroy(gameObject);
        }
    }

    // Method, that don't let the size of health grow.
    public void SetHealth(int bonusHealth)
    {
        health += bonusHealth;

        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }

}
