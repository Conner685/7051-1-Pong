using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManger : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private Toggle aiToggle;
    
    public void StartMatch()
    {
        int isAi = (aiToggle != null && aiToggle.isOn) ? 1 : 0;
        PlayerPrefs.SetInt("PlayAgainstAI", isAi);
        SceneManager.LoadScene(sceneName);
    }
}
