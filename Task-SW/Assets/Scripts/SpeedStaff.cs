using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedStaff : MonoBehaviour
{
    public CharController charc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf == true)
        {
            charc.GetComponent<CharController>().IncreaseSpeed();
        }
    }
}
