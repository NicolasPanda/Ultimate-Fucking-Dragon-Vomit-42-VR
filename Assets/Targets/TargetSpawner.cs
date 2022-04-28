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
            var state = _entries[GameManager.instance.Laps];
            if (state != TargetState.None)
            {
                var instance = Instantiate(PF_Taget, transform);
                instance.gameObject.GetComponent<TargetDamagable>().BaseTargetState = state;
            }
        }
    }
}
