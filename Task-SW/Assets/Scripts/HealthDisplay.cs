using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    CharController health;


    private void Awake()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<CharController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = health.GetHealth() +"%";
    }
}
