using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapsCounter : MonoBehaviour
{
    void OnTriggerEnter(Collider hitInfo)
    {
        if (hitInfo.transform.CompareTag("Target"))
        {
            GameManager.instance.AddLaps();
            Debug.Log(GameManager.instance.Laps);
        }
    }
}
