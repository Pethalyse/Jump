using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleGestion : MonoBehaviour
{

    //Health
    private int maxHealth = 3;
    [SerializeField] private int currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth == 0)
        {
            death();
        }
        
    }

    private void death()
    {
        Debug.Log("MORT");
    }

    public int getCurrentHealth() { return currentHealth; }
    public void decrCurrentHealth() { currentHealth--; }
    public void incrCurrentHealth() { currentHealth++; }
}
