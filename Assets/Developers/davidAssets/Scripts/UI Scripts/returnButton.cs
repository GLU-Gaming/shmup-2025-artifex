using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;

public class returnButton : MonoBehaviour
{
    public GetValueEnd getValue;
    public playButton PlayButton;

    public int SceneCount = 0;
    void Start()
    {
        getValue = FindFirstObjectByType<GetValueEnd>();
        PlayButton = FindFirstObjectByType<playButton>();

    }

    
    void Update()
    {
        
    }

    public void StartSceneSkip()
    {
        SceneCount = 1;
        getValue.LoadSceneAndKeepValue();
        SceneManager.LoadScene("startScene");
        
    }
}
