using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class Parallax : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _xPosition;
    private RawImage _image;

    private void Start()
    {
        _image = GetComponent<RawImage>();
        _xPosition = _image.uvRect.x;
    }

    private void Update()
    {
        _xPosition += _speed * Time.deltaTime;

        _xPosition = _xPosition > 1 ? 0 : _xPosition;
        
        _image.uvRect = new Rect(_xPosition, _image.uvRect.y, _image.uvRect.width, _image.uvRect.height);
    }
}
