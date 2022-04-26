using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{

    [SerializeField] private GameObject PF_Taget;
    
    [SerializeField] private List<TargetState> _entries = new List<TargetState>();
    
    
    void OnTriggerEnter(Collider hitInfo)
    {
        Debug.Log("enter");
        var instance = Instantiate(PF_Taget, transform);
        
        var state = _entries[GameManager.Instance.laps];
        
        instance.gameObject.GetComponent<TargetDamagable>().BaseTargetState = state;
    }
}
