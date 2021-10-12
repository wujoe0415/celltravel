using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public interface CausingDamage<T>
{
    void CauseDamage(T damageTaken);
}*/

public class GeneralEnemy : MonoBehaviour/*, CausingDamage<int>*/
{
    public HealthBarSlide bar;
    public void DealDamage(int damageTaken)
    {
        if (!(GetHurt.currentHealth - damageTaken < 0))
            GetHurt.currentHealth -= damageTaken;

        bar.SetHealth(GetHurt.currentHealth);
    }

    public void CauseDamage(int damage)
    {
        DealDamage(damage);
    }

    public void LateUpdate()
    {
        bar.SetHealth(GetHurt.currentHealth);
    }
}
