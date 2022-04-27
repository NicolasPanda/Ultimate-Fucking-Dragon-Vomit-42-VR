using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityTimer;

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
        var t = transform;
        Debug.DrawRay(t.position, t.forward * 500f, Color.green);
        
        
        var hits  = Physics.RaycastAll(transform.position, transform.forward, 500.0F);

        //For creating line renderer object
        var lineRenderer = new GameObject("Line").AddComponent<LineRenderer>();
        lineRenderer.startColor = Color.white;
        lineRenderer.endColor = Color.white;
        lineRenderer.startWidth = 0.01f;
        lineRenderer.endWidth = 0.01f;
        lineRenderer.positionCount = 2;
        Material whiteDiffuseMat = new Material(Shader.Find("Unlit/Texture"));
        lineRenderer.material = whiteDiffuseMat;
        lineRenderer.useWorldSpace = true;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position + (transform.forward * 500f));

        Timer.Register(0.004f, () =>
        {
            Destroy(lineRenderer);
        });

        foreach (var hit in hits)
        {
            Debug.Log(hit.transform.name);
            var entity = (IEntity) hit.collider.gameObject.GetComponent<IEntity>();
            if (entity != null)
            {
                entity.DamageEntity();
            }

        }
    }
}
