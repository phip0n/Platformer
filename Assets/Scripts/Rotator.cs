using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Rotator : MonoBehaviour
{
    protected Rigidbody2D _rigidBody;
    private Vector3 _scale;

    private void Awake()
    {
        _scale = transform.localScale;
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        if (_rigidBody.velocity.x != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(_rigidBody.velocity.x) * _scale.x, _scale.y, _scale.z);
        }
    }
}
