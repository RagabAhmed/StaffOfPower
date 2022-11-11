using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerStaff : MonoBehaviour
{
    public GameObject charc;
    [SerializeField] float attackRange = 4.7f;
    [SerializeField] float tickingTime = 1f;
    float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (charc.GetComponent<CharController>().IsDead()) return;
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemy == null) return;
        timer += Time.deltaTime;
        if (timer > tickingTime)
        {
            for (int i = 0; i < enemy.Length; i++)
            {
                float distance = Vector3.Distance(enemy[i].transform.position, transform.position);
          
                if (distance < attackRange)
                {
                    enemy[i].GetComponent<Health>().TakeDamage(10);
                    timer = 0;
                }
            }
        }
        if (gameObject.activeSelf == true)
        {
            charc.GetComponent<CharController>().DecreaseSpeed();
        }
    }
}
