using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    Enemy target;
    RectTransform rect;
    Slider slider;

    void Start()
    {
        rect = this.gameObject.GetComponent<RectTransform>();
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        if(target != null)
        {
            rect.transform.position = Camera.main.WorldToScreenPoint(this.target.transform.position) - Vector3.up * 20;
            slider.value = target.getHpRatio();
            if(slider.value == 0 ) {
                this.gameObject.SetActive(false);
            }
        }
    }

    public void init(Enemy enemy)
    {
        this.transform.parent = GameObject.Find("Canvas").transform;
        this.target = enemy;
    }
}
