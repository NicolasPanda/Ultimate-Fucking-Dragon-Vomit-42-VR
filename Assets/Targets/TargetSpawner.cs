using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{

    [SerializeField] private GameObject PF_Taget;
    
    [SerializeField] private List<TargetState> _entries = new List<TargetState>();
    
    
    void OnTriggerEnter(Collider hitInfo)
    {
        if (hitInfo.transform.CompareTag("Target"))
        {
            var instance = Instantiate(PF_Taget, transform);
            var state = _entries[GameManager.Instance.laps];
            if (state != TargetState.None)
            {
                instance.gameObject.GetComponent<TargetDamagable>().BaseTargetState = state;
            }
        }
    }
}
