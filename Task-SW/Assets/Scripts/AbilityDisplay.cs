using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AbilityDisplay : MonoBehaviour
{
    CharController weapon;

    private void Awake()
    {
        weapon = GameObject.FindGameObjectWithTag("Player").GetComponent<CharController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int currweap = weapon.GetCurrWeap();
        if (currweap == 0)
        {
            GetComponent<TextMeshProUGUI>().text ="Arcane";
            GetComponent<TextMeshProUGUI>().color = new Color(0.01757743f, 0.368203f, 0.745283f, 1);
        }
        if (currweap == 1)
        {
            GetComponent<TextMeshProUGUI>().text = "Agilty";
            GetComponent<TextMeshProUGUI>().color = new Color(0.4811321f, 0, 0.3694519f, 1);
        }
        if (currweap == 2)
        {
            GetComponent<TextMeshProUGUI>().text = "Nurture";
            GetComponent<TextMeshProUGUI>().color = new Color(0.06051977f, 0.754717f, 0.09216618f, 1);
        }
    }
}
