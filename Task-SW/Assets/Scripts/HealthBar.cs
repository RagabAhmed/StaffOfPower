using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Health healthComp;
    [SerializeField] RectTransform foreground;

    // Update is called once per frame
    void Update()
    {
        foreground.localScale = new Vector3(healthComp.GetFraction(), 1, 1);
    }
}
