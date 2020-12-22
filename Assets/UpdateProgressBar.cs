using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UpdateProgressBar : MonoBehaviour
{
    [SerializeField] protected RectTransform fillImage;

    protected virtual void Start()
    {
        EventManager.OnUpdatePlayerReload += ChangeSizeFillImage;
        ResizeFillImage();
    }

    protected void ResizeFillImage()
    {
        fillImage.localScale = Vector3.one;
    }

    protected void ChangeSizeFillImage(float value)
    {
        fillImage.transform.localScale = Vector3.one - Vector3.up * value;
    }
}
