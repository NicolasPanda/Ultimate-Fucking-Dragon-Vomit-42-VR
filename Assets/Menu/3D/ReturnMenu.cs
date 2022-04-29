using UnityEngine;
using UnityEngine.SceneManagement;
using UnityTimer;

public class ReturnMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Timer.Register(5, () => SceneManager.LoadScene(0));
    }
    
}
