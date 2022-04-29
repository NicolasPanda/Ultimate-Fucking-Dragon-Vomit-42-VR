using UnityEngine;

public class TargetHeal : MonoBehaviour, IEntity
{
    [SerializeField] private GameObject renderTarget;
    private bool _isActive = true;
    
    void Start()
    {
        GameManager.instance.EventLapsAdd += Respawn;
    }

    private void Respawn(int value)
    {
        if (!_isActive)
        {
            _isActive = true;
            gameObject.GetComponent<SphereCollider>().enabled = true;
            renderTarget.SetActive(true);
        }
    }
    
    public void DamageEntity()
    {
        _isActive = false;
        gameObject.GetComponent<SphereCollider>().enabled = false;
        renderTarget.SetActive(false);
        GameManager.instance.AddHealth(1);
    }

    public void KillEntity() { }
}
