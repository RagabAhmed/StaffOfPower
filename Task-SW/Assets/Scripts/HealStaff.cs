using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealStaff : MonoBehaviour
{
    public GameObject charc;
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
        if (gameObject.activeSelf == true)
        {
            charc.GetComponent<CharController>().DecreaseSpeed();
        }
        timer += Time.deltaTime;
        if (timer > tickingTime)
        {
            charc.GetComponent<CharController>().Heal(2);
            timer = 0;
        }
    }
}
