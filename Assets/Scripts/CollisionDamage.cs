using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;

/*Adding to enemy a system, where we are configure
hitting damage size and tag of objacts, 
that will take the damage*/
public class CollisionDamage : MonoBehaviour
{
    public int collisionDamage = 10;
    // Tag of object that will take the damage
    public string collisionTag;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == collisionTag)
        {
            Health health = coll.gameObject.GetComponent<Health>();
            health.TakeHit(collisionDamage);
        }
    }
}
