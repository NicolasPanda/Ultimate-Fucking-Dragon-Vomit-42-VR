using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButton : MonoBehaviour
{
    [SerializeField] private int _sceneIndex;
    
    public void SwitchScene()
    {
        SceneManager.LoadScene(_sceneIndex);
    }
}
