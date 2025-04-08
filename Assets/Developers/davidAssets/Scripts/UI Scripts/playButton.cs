using UnityEngine;
using UnityEngine.SceneManagement;

public class playButton : MonoBehaviour
{
    public GetValueStart getValue;
    public GetValueEnd EndGetValue;

    public int HighScore = 0;

    public returnButton ReturnButton;

    public int SceneCounter;

    void Start()
    {
        getValue = FindFirstObjectByType<GetValueStart>();
        EndGetValue = FindAnyObjectByType<GetValueEnd>();
        ReturnButton = FindAnyObjectByType<returnButton>();
    }
 
    void Update()
    {
        
    }

    public void StartNextScene()
    {
        

        if(SceneCounter == 0)
        {
            EndGetValue.LoadSceneAndKeepValue();
            SceneManager.LoadScene("mainScene");
        }
        if (SceneCounter == 1) 
        {
            getValue.LoadSceneAndKeepValue();
            SceneManager.LoadScene("mainScene");
        }
        
    }

}
