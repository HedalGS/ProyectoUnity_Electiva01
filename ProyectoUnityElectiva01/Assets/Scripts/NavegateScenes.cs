using UnityEngine;
using UnityEngine.SceneManagement;
public class NavegateScenes : MonoBehaviour
{
    //Funci�n para cargar escenas
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    //Funci�n para cerrar aplicaci�n
    public void QuitScene()
    {
        Application.Quit();
    }
}
