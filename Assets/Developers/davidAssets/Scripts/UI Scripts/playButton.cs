using UnityEngine;
using UnityEngine.SceneManagement;

public class playButton : MonoBehaviour
{
    public GetValueStart getValue;
    public GetValueEnd EndGetValue;

    public int HighScore = 0;

    public returnButton ReturnButton;

    public int SceneCounter = 1;

    private int ResetCounter;

    public SaveHighScore Highscore;

    // [Serializefiedaihd] private string Scene;
    void Start()
    {
        getValue = FindFirstObjectByType<GetValueStart>();
        EndGetValue = FindAnyObjectByType<GetValueEnd>();
        ReturnButton = FindAnyObjectByType<returnButton>();
        Highscore = FindAnyObjectByType<SaveHighScore>();

    }
 
    void Update()
    {
        if(SceneCounter > 1)
        {
            if (Highscore.SceneCount > 1)   
            {
                Highscore.SceneCount = 1;
            }
        }
        
    }

    public void StartNextScene()
    {

        if (SceneCounter == 0)
        {
            SceneCounter = 1;
            getValue.LoadSceneAndKeepValue();
            SceneManager.LoadScene("mainScene");
            
        }
        else if (SceneCounter == 1)
        {

            EndGetValue.LoadSceneAndKeepValue();
            SceneManager.LoadScene("mainScene");
        }
        
        // scenemanager.loadscene(Scene)
    }

}
