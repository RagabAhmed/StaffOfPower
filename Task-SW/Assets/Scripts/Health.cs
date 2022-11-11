using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField]float health = 100f;
    Animator animator;
    bool isDead = false;
    [SerializeField] UnityEvent takeDamage;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool IsDead()
    {
        return isDead;
    }
    public void TakeDamage(float damage)
    {
        health = Mathf.Max(health - damage,0);
        if (health == 0)
        {
            Die();
        }
        else
        {
            takeDamage.Invoke();
        }
    }
    private void Die()
    {
        if (isDead) return;
        isDead = true;
        animator.SetBool("Dead", true);
        //Destroy(this.gameObject);
        
    }
    public float GetHealth()
    {
        return health;
    }
    public float GetFraction()
    {
        return health / 100;
    }

}
