using UnityEngine;

public sealed class SceneController : MonoBehaviour
{
    public void QuitTheGame()
    {
        Application.Quit();
        Debug.Log("Quit the game");
    }
}
