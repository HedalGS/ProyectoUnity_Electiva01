using UnityEngine;
using TMPro;

public class InteractWithTouch : MonoBehaviour
{

    public TextMeshProUGUI phaseDisplayText;
    private Touch myTouch;
    private float timeEnded;
    private float displayTime = 5f;

    // Update is called once per frame
    void Update()
    {
        //touchCount contiene la cantidad de touch detectados
        if (Input.touchCount > 0)
        {
            //GetTouch contiene un arreglo con los touch detectados
            myTouch = Input.GetTouch(0);
            //Todos los touch tienen una fase (phase)
            phaseDisplayText.SetText(myTouch.phase.ToString());

            if (myTouch.phase == TouchPhase.Ended)
            {
                timeEnded = Time.time;
            }
        }
        else if (Time.time - timeEnded > displayTime)
        {
            phaseDisplayText.SetText("");
        }
    }
}
