using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GunVisual : MonoBehaviour
{
    public void Hide()
    {
        transform.DOScale(0, 1).OnComplete(() => gameObject.SetActive(false));
        transform.DOLocalRotate(Vector3.forward * -180, 1, RotateMode.FastBeyond360);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        transform.localRotation = Quaternion.Euler(Vector3.forward * 180);
        transform.localScale = Vector3.zero;
        transform.DOScale(1, 1);
        transform.DOLocalRotate(Vector3.zero, 1, RotateMode.FastBeyond360);
    }
}
