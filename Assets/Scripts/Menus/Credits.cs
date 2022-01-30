using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);//charge le menu après la fin des crédits
    }
}
