using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHurt : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBarSlide bar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        bar.MaxSetHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Damage(5);
    }
    private void Damage(int hurt)    
    {
        if(!(currentHealth - hurt < 0) )
            currentHealth -= hurt;

        bar.SetHealth(currentHealth);
    }
}
