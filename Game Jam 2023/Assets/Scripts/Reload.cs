using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reload : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider slider;
    //public Gradient gradient;
    //public Image fill;

    public void SetMaxShots(int bullets)
    {
        slider.maxValue = bullets;
        slider.value = bullets;

        //fill.color = gradient.Evaluate(1f);

    }
    public void SetShots(int bullets)
    {
        slider.value = bullets;

        //fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
