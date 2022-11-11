using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharController : MonoBehaviour
{
    public GameObject[] weps;
    int currentwep = 0;
    int nrWeapons;
    public ParticleSystem[] part;
    CharacterController charControl;
    public float speed =5f;
    public float rotateSpeed = 3f;
    Animator animator;
    public static float xMove, zMove;
    [SerializeField] float health=100;
     bool isDead = false;
    [SerializeField] SwitchStaffEvent switchstaff;


    [System.Serializable]
    public class SwitchStaffEvent : UnityEvent<int>
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        charControl = GetComponent<CharacterController>();
        nrWeapons = weps.Length;
        weps[currentwep].SetActive(true);
        Actaura(currentwep);
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if (health == 0) return;
        ChangeStaff();
        Moving();
        rotation();

    }

    private void ChangeStaff()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Deactaura(currentwep);
            weps[currentwep].SetActive(false);
            currentwep++;
            if (currentwep >= nrWeapons)
            {
                currentwep = 0;
            }
            Actaura(currentwep);
            SwitchWeapon(currentwep);
            switchstaff.Invoke(1);
        }
    }

    private void rotation()
    {
        xMove = Input.GetAxis("Horizontal");
        zMove = Input.GetAxis("Vertical");
        if (xMove > 0)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), rotateSpeed * Time.deltaTime);
        else if (xMove < 0)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), rotateSpeed * Time.deltaTime);
        if (zMove > 0)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), rotateSpeed * Time.deltaTime);
        else if (zMove < 0)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), rotateSpeed * Time.deltaTime);
    }

    private void Moving()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if(move == Vector3.zero)
        {
            animator.SetFloat("Speed", 0);
        }
        else if (speed==8)
        {
            animator.SetFloat("Speed", 0.88f);
        }
        else
        {
            animator.SetFloat("Speed", 0.5f);
        }
        charControl.Move(move*speed * Time.deltaTime );
    }

    private void Actaura(int currentwep)
    {
        part[currentwep].Play();

    }
    private void Deactaura(int currentwep)
    {
        part[currentwep].Stop();

    }

    private void SwitchWeapon(int currentwep)
    {
        weps[currentwep].SetActive(true);
    }

    public void IncreaseSpeed()
    {
        speed = 8;
        
    }
    public void DecreaseSpeed()
    {
        speed = 3;
    }
    public void Heal(int amount)
        {
        health = Math.Min(health + amount, 100);
        }
    public void TakeDamage(float damage)
    {
        health = Math.Max(0, health - damage);
        if (health == 0)
        {
            Die();
        }
    }
    public float GetHealth()
    {
        return health;
    }
    private void Die()
    {
        if (isDead) return;
        isDead = true;
        animator.SetBool("Dead", true);

    }
    public bool IsDead()
    {
        return isDead;
    }
    public int GetCurrWeap()
    {
        return currentwep;
    }
}
