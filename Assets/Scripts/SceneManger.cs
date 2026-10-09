using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManger : MonoBehaviour
{
    [SerializeField]
    private string sceneName;
    
    public void StartMatch()
    {
        SceneManager.LoadScene(sceneName);
    }
}
