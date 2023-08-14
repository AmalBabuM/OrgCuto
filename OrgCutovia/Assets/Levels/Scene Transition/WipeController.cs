using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WipeController : MonoBehaviour
{
    private Animator _animator;
    private Image _image;
    private readonly int _circleSizeId = Shader.PropertyToID("_Circle_Size");
    bool _isIn=false;

    public float circleSize = 0;
    private void OnEnable()
    {
        _animator = gameObject.GetComponent<Animator>();
        _image = gameObject.GetComponent<Image>();
    }

    private void Update()
    {
        _image.materialForRendering.SetFloat("_Circle_Size", circleSize);
    }

    public void AnimatorIn()
    {
        _animator.SetTrigger("In");
        _isIn=true;
    }
    public void AnimatorOut()
    {
        _animator.SetTrigger("Out");
        _isIn = false;
    }
}
