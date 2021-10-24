using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 
public class BasePlayer: MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 0;

    [SerializeField]
    private int attackPower = 0;

    [SerializeField]
    private float movementSpeed = 0;

    [SerializeField]
    private int damagedReduction = 0;

    private int currentHealth;

    private int currentAttack, currentSpeed, currentDamagedReduction; //"current" stat will be useful when we want to modify properties temporaily

    private bool canAttack1, canAttack2, canSkill1, canSkill2, canUlt;
    
    private float attack1CD, attack2CD, skill1CD, skill2CD;

    private float attack1Timer, attack2Timer, skill1Timer, skill2Timer;//When timer >= CD, then the action can be performed

    private int ultEnergy, ultCap;//kill enemy adding energy. When energy reach cap, ult can be used.

    //==========private method that no need to be overrided by son class==========
    private void Update() 
    {
        UpdatingCoolDownWithTimer(Time.deltaTime);

        Moving(Time.deltaTime);
        
        if(Input.GetButtonDown("Attack1") && canAttack1)
        {
            MainAttack1();
        }
        if(Input.GetButtonDown("Attack2") && canAttack2)
        {
            MainAttack2();
        }
        if(Input.GetButtonDown("Skill1") && canSkill1)
        {
            CastSkill1();
        }
        if(Input.GetButtonDown("Skill2") && canSkill2)
        {
            CastSkill2();
        }
        if(Input.GetButtonDown("Ult") && canUlt)
        {
            CastUlt();
        }
    }
    private void Moving(float dt)//Moving player
    {
        float verticalTranslation = Input.GetAxisRaw("Vertical") * movementSpeed * dt;
        float HorizontalTranslation = Input.GetAxisRaw("Horizontal") * movementSpeed * dt;
        transform.Translate(HorizontalTranslation, verticalTranslation, 0);
    }
    private void UpdatingCoolDownWithTimer(float dt)
    {
        if(attack1Timer < attack1CD)attack1Timer += dt;
        else if(!canAttack1) canAttack1 = true;

        if(attack2Timer < attack2CD)attack2Timer += dt;
        else if(!canAttack2) canAttack2 = true;

        if(skill1Timer < skill1CD)skill1Timer += dt;
        else if(!canSkill1) canSkill1 = true;

        if(skill2Timer < skill2CD)skill2Timer += dt;
        else if(!canSkill2) canSkill2 = true;
    }
    
    // ==========private function that is to be overrided in son class==========
    private void Start() 
    {
        attack1CD = attack2CD = skill1CD = skill2CD = 1f;
        attack1Timer = attack2Timer = skill1Timer = skill2Timer = 0f;
        canAttack1 = canAttack2 = canSkill1 = canSkill2 = false;
    }
    private void MainAttack1()
    {
        Debug.Log("Attack1");
        attack1Timer = 0f;
        canAttack1 = false;
    }
    private void MainAttack2()
    {
        Debug.Log("Attack2");
    }
    private void CastSkill1()
    {
        Debug.Log("Skill1");
    }
    private void CastSkill2()
    {
        Debug.Log("Skill2");
    }
    private void CastUlt()
    {
        Debug.Log("Ult");
    }
    private void ReceivingItem(int id)//get item drop by enemy. usually are stat buff
    {

    }

    //==========public function==========
    public void ModifyHealth(int value)//change health to given value
    {
        currentHealth = value;
    }
    public void BeingDamaged(int damaged)//sub current health with given damaged value
    {
        ModifyHealth(currentHealth - damaged);
    }
    public int GetHealth()
    {
        return currentHealth;
    }
    
}

