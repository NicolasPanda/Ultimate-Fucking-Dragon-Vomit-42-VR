using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    
    [SerializeField] private InputActionReference shootInputActionReference;
    private InputAction _shootInput;


    private void Start()
    {
        _shootInput = shootInputActionReference.action;
        _shootInput.started += ctx => Shoot();
    }

    private void Shoot()
    {
        Debug.Log("shoot");
        RaycastHit hit;
        var t = transform;
        Debug.DrawRay(t.position, t.forward * 500f, Color.green);
        
        //For creating line renderer object
        var lineRenderer = new GameObject("Line").AddComponent<LineRenderer>();
        lineRenderer.startColor = Color.blue;
        lineRenderer.endColor = Color.blue;
        lineRenderer.startWidth = 0.01f;
        lineRenderer.endWidth = 0.01f;
        lineRenderer.positionCount = 2;
        lineRenderer.useWorldSpace = false;    
                
//For drawing line in the world space, provide the x,y,z values
        lineRenderer.SetPosition(0, transform.position); //x,y and z position of the starting point of the line
        lineRenderer.SetPosition(1, transform.forward * 500f); //x,y and z position of the end point of the line
        
        if (Physics.Raycast(t.position, t.forward, out hit, 500f))
        {
            var entity = (IEntity) hit.collider.gameObject.GetComponent<IEntity>();
            if (entity != null)
            {
                entity.DamageEntity();
            }
        }
    }
}
