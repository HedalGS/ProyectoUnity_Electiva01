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
}
