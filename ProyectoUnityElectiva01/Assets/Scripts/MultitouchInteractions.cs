using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InteractWithMultiTouch : MonoBehaviour
{
    public TextMeshProUGUI infoDisplayText;
    private int maxTapCount;
    private string multiTouchInfo;
    private Touch myTouch;

    private void Start()
    {
        maxTapCount = 0;

    }

    void Update()
    {
        multiTouchInfo = string.Format("Número de dedos: {0}\n\n", maxTapCount);
        //Si recibe inputs, entonces muestra la información de los Touch
        if (Input.touchCount > 0)
        {
            //Recorrer todos los touch recibidos
            for (int i = 0; i < Input.touchCount; i++)
            {
                myTouch = Input.GetTouch(i);
                string infoTouch = ("Touch: " + i.ToString() + " Coordenadas: " + myTouch.position.x + " - " + myTouch.position.y + "\n");
                multiTouchInfo += infoTouch;

                maxTapCount = Input.touchCount;
                infoDisplayText.SetText(multiTouchInfo);
            }
        }
        //Si no recibe inputs, no hay dedos en la pantalla
        else
        {
            infoDisplayText.SetText("No hay dedos en la pantalla");
        }
    }
}
