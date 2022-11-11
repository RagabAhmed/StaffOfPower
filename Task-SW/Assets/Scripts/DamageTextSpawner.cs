using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTextSpawner : MonoBehaviour
{
    [SerializeField] DamageText damageTextPrefabs=null;


    public void Spawn(float damageAmount)
    {
        DamageText instance=Instantiate<DamageText>(damageTextPrefabs, transform);
        instance.SetValue(damageAmount);
    }

}
