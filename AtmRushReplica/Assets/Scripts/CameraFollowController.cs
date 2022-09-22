using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    [SerializeField] private Transform robotTransform;
    [SerializeField] private float _lerpTime;
    private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - robotTransform.transform.position;
    }

    private void LateUpdate()
    {
        Vector3 _newPos = Vector3.Lerp(transform.position, robotTransform.position + _offset, _lerpTime * Time.deltaTime);
        transform.position = _newPos;
    }
}
