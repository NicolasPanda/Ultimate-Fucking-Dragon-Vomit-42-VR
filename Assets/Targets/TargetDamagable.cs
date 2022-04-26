using System;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class TargetDamagable : MonoBehaviour, IEntity
{

    [SerializeField] private TargetState targetState;

    public bool isActive = false;

    private void Start()
    {
        RenderTargetModel(TargetState.Hide);
    }
    
    
    public void DamageEntity()
    {
        if (!isActive) return;
        
        switch (targetState)
        {
            case TargetState.Red:
                //TODO : score
                targetState = TargetState.Yellow;
                RenderTargetModel(TargetState.Yellow);
                break;
            case TargetState.Yellow:
                //TODO : score
                targetState = TargetState.Green;
                RenderTargetModel(TargetState.Green);
                break;
            case TargetState.Green:
                //TODO : score
                KillEntity();
                break;
            case TargetState.Hide:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void ActivateTarget()
    {
        isActive = true;
        RenderTargetModel(targetState);
    }

    public void KillEntity()
    {
        Destroy(gameObject);
    }

    private void RenderTargetModel(TargetState newState)
    {
        
    }
}

enum TargetState {
    Hide,
    Red,
    Yellow,
    Green
}
