using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiController : MonoBehaviour
{
    GameObject player;
    [SerializeField] float speed = 0.1f;
    Animator animator;
    float timer = 0;
    float timeBetweenAttacks = 2;
    [SerializeField]float damage;
    [SerializeField] float attackRange;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Health>().IsDead()) return;
        Attack();

    }


    private void Attack()
    {
        transform.LookAt(player.transform);
        float dist = Vector3.Distance(player.transform.position, transform.position);
        timer += Time.deltaTime;
        if (dist > attackRange)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        else if (timer > timeBetweenAttacks)
        {
            animator.SetBool("Attack", true);
            player.GetComponent<CharController>().TakeDamage(damage);
            timer = 0;
        }
    }
    void OnDestroy()
    {
        if (GameObject.FindGameObjectWithTag("WaveSpawner") != null)
        {
            GameObject.FindGameObjectWithTag("WaveSpawner").GetComponent<WaveSpawner>().spawnedEnemies.Remove(gameObject);
        }

    }
}
