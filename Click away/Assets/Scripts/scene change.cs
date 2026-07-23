using UnityEngine;

public class SceneChange : MonoBehaviour
{
    public void ChangeScene(int sceneNumber)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneNumber);
    }
}
