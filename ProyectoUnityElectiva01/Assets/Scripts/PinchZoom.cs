using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

[RequireComponent(typeof(Camera))]

public class PinchZoom : MonoBehaviour
{
    public float zoomSpeed = 0.15f; // Speed of zooming
    public float fovMin = 30f;
    public float fovMax = 75f;
    public float orthoMin = 3f;
    public float orthMax = 20f;

    private Camera cam;
    private float? lastDistance;

    void OnEnable()
    {
        cam = GetComponent<Camera>();

        EnhancedTouchSupport.Enable();
    }

    void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }
    
    void Update()
    {
        var touches = Touch.activeTouches;
        // Obtenemos todos los toques activos en la pantalla

        if (touches.Count < 2)
        {
            // Si hay menos de dos dedos, reseteamos la distancia previa y salimos
            lastDistance = null;
            return;
        }

        // Si hay al menos dos dedos, tomamos las posiciones de los dos primeros
        Vector2 p0 = touches[0].screenPosition;
        Vector2 p1 = touches[1].screenPosition;

        float currentDistance = Vector2.Distance(p0, p1);
        // Calculamos la distancia actual entre los dedos

        if (lastDistance.HasValue)
        {
            float delta = currentDistance - lastDistance.Value;
            // Calculamos cuanto cambio la distancia desde el ultimo frame
            // Positivo si los dedos se separan, negativo si se acercan

            float zoomAmount = -delta * zoomSpeed * Time.deltaTime;
            // Ajustamos el signo para que pellizcar signifique acercar

            if (cam.orthographic)
            {
                // si la camara es ortografica 2D, modificamos el tamaño ortografico
                cam.orthographicSize = Mathf.Clamp(
                    cam.orthographicSize + zoomAmount, orthoMin, orthMax
                );
            }
            else
            {
                // Si la camara es de perspectiva 3D, modificamos el field of view
                cam.fieldOfView = Mathf.Clamp(
                    cam.fieldOfView + zoomAmount * 10f, fovMin, fovMax
                );
            }
        }

        // Guardamos la distancia actual como referencia para el proximo frame
        lastDistance = currentDistance;
    }
}
