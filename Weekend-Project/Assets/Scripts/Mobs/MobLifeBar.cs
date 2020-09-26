using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobLifeBar : MonoBehaviour
{
    public Slider lifebar;

    private MobController mobController;

    // Start is called before the first frame update
    void Start()
    {
        mobController = gameObject.GetComponentInParent<MobController>();
        lifebar.maxValue = mobController.HP;
        lifebar.value = mobController.HP;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = Camera.main.WorldToScreenPoint(this.transform.position);
        lifebar.transform.position = position;
    }
}
