using System;
using MoreMountains.Feedbacks;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private MMF_Player loseLifeFeedback;

    private void Start()
    {
        GameManager.instance.EventDamagePlayer += PlayerGetDamage;
    }

    private void PlayerGetDamage(int value)
    {
        loseLifeFeedback.PlayFeedbacks();
    }
}
