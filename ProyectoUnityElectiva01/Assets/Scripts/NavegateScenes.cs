using UnityEngine;
using UnityEngine.SceneManagement;
public class NavegateScenes : MonoBehaviour
{
    //Función para cargar escenas
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    //Función para cerrar aplicación
    public void QuitScene()
    {
        Application.Quit();
    }
}
