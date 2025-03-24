using UnityEngine;
using UnityEngine.SceneManagement;

public class playButton : MonoBehaviour
{
    void Start()
    {
        
    }
 
    void Update()
    {

    }

    public void StartNextScene()
    {
        SceneManager.LoadScene("mainScene");
    }

}
