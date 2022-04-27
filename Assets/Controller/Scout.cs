using System;
using PathCreation;
using UnityEngine;

public class Scout : MonoBehaviour
{
    [Header("Path setting")]
    [SerializeField] private PathCreator pathCreator;
    [SerializeField] private EndOfPathInstruction endOfPathInstruction;
    [SerializeField] private float speed = 5;
    [SerializeField] private float offsetToPlayer = 5;
    
    private float _distanceTravelled;

    private void Start()
    {
        _distanceTravelled += offsetToPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        if (pathCreator != null)
        {
            _distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(_distanceTravelled, endOfPathInstruction);
            transform.rotation = pathCreator.path.GetRotationAtDistance(_distanceTravelled, endOfPathInstruction);
        }
    }
}