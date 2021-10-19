using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leukocyte : GeneralEnemy
{
    public int damage;
    void Update()
    {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("in");
        if(collision.gameObject.tag == "Player")
            CauseDamage(damage);
    }
}
