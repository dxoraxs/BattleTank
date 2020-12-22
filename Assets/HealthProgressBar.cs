using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthProgressBar : UpdateProgressBar
{
    [SerializeField] private Text counter;
    
    protected override void Start()
    {
        ResizeFillImage();
        EventManager.OnUpdatePlayerHealth += (f, i) =>
        {
            ChangeSizeFillImage(1 - f);
            counter.text = i.ToString();
        };
    }
}
