using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFacing : MonoBehaviour
{
    private GameObject _playerRef;
    private void Awake()
    {
        _playerRef = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        gameObject.transform.LookAt(_playerRef.transform);
    }
}
