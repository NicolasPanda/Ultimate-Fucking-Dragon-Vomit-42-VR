using System;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityTimer;

public class Shooting : MonoBehaviour
{
    [SerializeField] private MMF_Player shootFeedback;

    [SerializeField] private Animator animator;

    [SerializeField] private InputActionReference shootInputActionReference;

    [SerializeField] private float lineOffset = 5;
    private InputAction _shootInput;
    private static readonly int ShootIndex = Animator.StringToHash("Shoot");


    private void Start()
    {
        _shootInput = shootInputActionReference.action;
        _shootInput.started += ctx => Shoot();
    }

    private void Shoot()
    {
        Debug.Log("shoot");
        
        shootFeedback.PlayFeedbacks();
        
        animator.SetBool(ShootIndex, true);
        
        var t = transform;
        var f = t.forward;
        var p = t.position;
        Debug.DrawRay(p, f * 500f, Color.green);


        var hits  = Physics.RaycastAll(transform.position, f, 500.0F);

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
        lineRenderer.SetPosition(0, p + (f * lineOffset));
        lineRenderer.SetPosition(1, p + (f * 500f));

        Timer.Register(0.004f, () =>
        {
            Destroy(lineRenderer.gameObject);
            animator.SetBool(ShootIndex, false);
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
