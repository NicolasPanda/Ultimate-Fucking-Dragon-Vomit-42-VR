using UnityEngine;
using UnityEngine.SceneManagement;
using UnityTimer;

public class LVL2CutNextScene : MonoBehaviour
{
    private void Start()
    {
        Timer.Register(90f, () => SceneManager.LoadScene(1));
    }
}
