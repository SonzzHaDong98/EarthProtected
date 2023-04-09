using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float startingHealth;
    public float currentHealth { get; private set; }  
    private bool dead;
    GameManager gm;

    private void Awake()
    {
        currentHealth = startingHealth;
        gm = FindObjectOfType<GameManager>();
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if(currentHealth <= 0 )
        {
            gm.SetGameOverState(true);
            Destroy(gameObject);
        }
    }   
}
