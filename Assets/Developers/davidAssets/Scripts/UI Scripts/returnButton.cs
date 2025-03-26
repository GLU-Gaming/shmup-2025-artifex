using UnityEngine;
using UnityEngine.SceneManagement;

public class returnButton : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void StartSceneSkip()
    {
        SceneManager.LoadScene("startScene");
    }
}
