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
    [SerializeField] private float lineWidth = 0.01f;
    [SerializeField] private Color lineColor = Color.cyan;
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
        
        animator.Play("A_GunShoot", -1, 0);
        
        var t = transform;
        var f = t.forward;
        var p = t.position;
        Debug.DrawRay(p, f * 500f, Color.green);


        var hits  = Physics.RaycastAll(transform.position, f, 500.0F);

        //For creating line renderer object
        var lineRenderer = new GameObject("Line").AddComponent<LineRenderer>();
        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.positionCount = 2;
        Material whiteDiffuseMat = new Material(Shader.Find("Unlit/Texture"))
        {
            color = lineColor
        };
        lineRenderer.material = whiteDiffuseMat;
        lineRenderer.useWorldSpace = true;
        lineRenderer.SetPosition(0, p + (f * lineOffset));
        lineRenderer.SetPosition(1, p + (f * 500f));

        Timer.Register(0.004f, () =>
        {
            Destroy(lineRenderer.gameObject);
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
