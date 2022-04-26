using System;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class TargetDamagable : MonoBehaviour, IEntity
{

    [SerializeField] private TargetState targetState;

    private void Start()
    {
        RenderTargetModel(targetState);
    }
    
    
    public void DamageEntity()
    {
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
            default:
                throw new ArgumentOutOfRangeException();
        }
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
    Red,
    Yellow,
    Green
}
