using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _lerpValue;
    private void LateUpdate()
    {
        Vector3 desPos = _target.position + _offset;
        transform.position = Vector3.Lerp(transform.position, desPos, _lerpValue * Time.deltaTime);
    }
}
