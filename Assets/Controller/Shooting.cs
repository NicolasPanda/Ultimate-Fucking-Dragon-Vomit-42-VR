using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    
    [SerializeField] private InputActionReference shootInputActionReference;
    private InputAction _shootInput;


    private void Start()
    {
        _shootInput = shootInputActionReference.action;
        _shootInput.started += ctx => Shoot();
    }

    // Update is called once per frame
    void Update()
    {
    }


    private void Shoot()
    {
        Debug.Log("shoot");
        RaycastHit hit;
            Debug.DrawRay(transform.position, transform.forward * 100f, Color.green);
        if (Physics.Raycast(transform.position, transform.forward, out hit, 100f))
        {
            Debug.Log(hit);
            if (hit.transform.CompareTag("Target"))
            {
                Debug.Log("tuch");
                Destroy(hit.transform.gameObject);
            }
        }
    }
}
