using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public string LevelName;

    public void OnLevelButtonCLick()
    {
        SceneManager.LoadScene(LevelName);
    }

    public void LoadLastLevelPlayed()
    {
        Debug.Log("Doing Stuff");
        if (GameManager.Instance.lastLevelPlayed != "" && GameManager.Instance.lastLevelPlayed != "Menue")
        {
            SceneManager.LoadScene(GameManager.Instance.lastLevelPlayed);
            Debug.Log("Loading Level: " + GameManager.Instance.lastLevelPlayed);
        }
    }
}
