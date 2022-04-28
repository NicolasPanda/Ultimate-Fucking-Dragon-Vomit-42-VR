using System;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityTimer;

public class TargetDamagable : MonoBehaviour, IEntity
{

    [Header("Base")]
    [SerializeField] private Transform spawnPoint;

    [SerializeField] private GameObject targetGreen;
    [SerializeField] private GameObject targetYellow;
    [SerializeField] private GameObject targetRed;

    [SerializeField] private float targetTime;
    
    [Header("feedback")]
    
    [SerializeField] private MMF_Player breakFeedback;
    [SerializeField] private MMF_Player spawnFeedback;

    private GameObject _currentTarget;

    private TargetState _baseTargetState;

    private Timer _targetTime;

    public TargetState BaseTargetState  {
        get => _baseTargetState;
        set
        {
            _baseTargetState = value;
            RenderTargetModel(value);
        }
    }

    private void Start()
    {
        spawnFeedback.PlayFeedbacks();
        _targetTime = Timer.Register(targetTime, TimeEnd);
    }


    public void DamageEntity()
    {
        switch (BaseTargetState)
        {
            case TargetState.Red:
                GameManager.instance.AddPoint(20);
                breakFeedback.PlayFeedbacks();
                BaseTargetState = TargetState.Yellow;
                break;
            case TargetState.Yellow:
                GameManager.instance.AddPoint(20);
                breakFeedback.PlayFeedbacks();
                BaseTargetState = TargetState.Green;
                break;
            case TargetState.Green:
                GameManager.instance.AddPoint(20);
                KillEntity();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void KillEntity()
    {
        _targetTime.Cancel();
        breakFeedback.PlayFeedbacks();
        _currentTarget.SetActive(false);
        gameObject.GetComponent<SphereCollider>().enabled = false;
        Timer.Register(0.88f, () => Destroy(gameObject));
        
    }

    private void TimeEnd()
    {
        GameManager.instance.DamagePlayer(1);
        KillEntity();
    }

    private void RenderTargetModel(TargetState newState)
    {
        switch (newState)
        {
            case TargetState.Red:
                if (_currentTarget != null)
                {
                    Destroy(_currentTarget);
                }
                _currentTarget = Instantiate(targetRed, spawnPoint);
                break;
            case TargetState.Yellow:
                if (_currentTarget != null)
                {
                    Destroy(_currentTarget);
                }
                _currentTarget = Instantiate(targetYellow, spawnPoint);
                break;
            case TargetState.Green:
                if (_currentTarget != null)
                {
                    Destroy(_currentTarget);
                }
                _currentTarget = Instantiate(targetGreen, spawnPoint);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }
}

public enum TargetState {
    None,
    Red,
    Yellow,
    Green
}
