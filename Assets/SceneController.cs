using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private int AmountOfScenes = 4;
    public void LoadNextScene()
    {
        if(SceneManager.GetActiveScene().buildIndex != AmountOfScenes-1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if(SceneManager.GetActiveScene().buildIndex == AmountOfScenes -1)
        {
            SceneManager.LoadScene(0);
        }
    }
    public void RestartLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnTriggerEnter(Collider other)
    {
        LoadNextScene();
    }
}
