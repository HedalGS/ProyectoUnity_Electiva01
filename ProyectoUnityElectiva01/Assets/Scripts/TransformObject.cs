using UnityEngine;


public class TransformObject : MonoBehaviour
{
    public GameObject myObject;

    //Funciones de Rotate
    public void RotateLeft()
    {
        myObject.transform.Rotate(0.0f, 10.0f, 0.0f, Space.Self);
    }
    public void RotateRight()
    {
        myObject.transform.Rotate(0.0f, -10.0f, 0.0f, Space.Self);
    }

    //Funciones de Scale
    public void Scale(float magnitud)
    {
        Vector3 changerscale = new Vector3(magnitud, magnitud, magnitud);
        myObject.transform.localScale += changerscale;
    }

    // Funciones de Translate
    public void TranslateUp()
    {
        myObject.transform.Translate(Vector3.up * Time.deltaTime * 10, Space.World);
    }

    public void TranslateDown()
    {
        myObject.transform.Translate(Vector3.down * Time.deltaTime * 10, Space.World);
    }

    public void TranslateLeft()
    {
        myObject.transform.Translate(Vector3.left * Time.deltaTime * 10, Space.World);
    }
    
    public void TranslateRight()
    {
        myObject.transform.Translate(Vector3.right * Time.deltaTime * 10, Space.World);
    }
}
