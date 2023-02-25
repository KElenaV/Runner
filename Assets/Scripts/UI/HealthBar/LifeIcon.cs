using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class LifeIcon : MonoBehaviour
{
    [SerializeField] private float _fillDuration;
    
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.fillAmount = 1;
        
        Fill();
    }

    public void Fill()
    {
        StartCoroutine(Filling(0, 1, _fillDuration, CompletelyFill));
    }

    public void Empty()
    {
        StartCoroutine(Filling(1, 0, _fillDuration, CompletelyEmpty));
    }

    public IEnumerator Filling(float startValue, float endValue, float duration, UnityAction<float> fillingEnded)
    {
        float elapsedTime = 0;

        while (elapsedTime <= duration)
        {
            float interpolation = elapsedTime / duration;
            
            _image.fillAmount = Mathf.Lerp(startValue, endValue, interpolation);

            elapsedTime += Time.deltaTime;
            yield return null;
        } 
        
        fillingEnded?.Invoke(endValue);
    }

    private void CompletelyFill(float endValue)
    {
        _image.fillAmount = endValue;
    }
    
    private void CompletelyEmpty(float endValue)
    {
        _image.fillAmount = endValue;
        Destroy(gameObject);
    }
}
