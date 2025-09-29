using UnityEngine;
using UnityEngine.InputSystem;

public class CapsuleMove : MonoBehaviour
{
    [Header("Accion Move (Vector2) desde el .inputactions")]
    public InputActionReference moveAction;
    // Referencia a la accion Move que se configuro en el asset de input actions
    // Devuelve un vector2 con la direccion (-1..1 en x e y)

    [Header("Movimiento")]
    public float speed = 3.5f;
    // Velocidad de movimiento del objeto

    public bool moveInCameraPlane = true;
    // Si es true, el movimiento se calcula relativo a la camara principal (util para juegos en 3ra persona)

    void OnEnable()
    {
        // Cuando el objetivo se activa, habilitamos la accion para que empiece a recibir valores
        if (moveAction != null) moveAction.action.Enable();
    }

    void OnDisable()
    {
        // Cuando el objetivo se desactiva, deshabilitamos la accion para que empiece a recibir valores
        if (moveAction != null) moveAction.action.Disable();
    }

    // Update is called once per frame
    [Header("Rotación")]
    public float rotationSpeed = 100f; // Velocidad de rotación en grados por segundo

    void Update()
    {
        // Este metodo se llama cada frame
        if (moveAction == null) return; // Si no hay accion asignada, salimos

        Vector2 input = moveAction.action.ReadValue<Vector2>();
        // Leemos el valor de la accion move (ejes X e Y del joystick o stick virtual)

        // Manejo del movimiento horizontal (traslación en X)
        if (Mathf.Abs(input.x) > 0.1f) // Pequeño umbral para evitar movimientos no intencionales
        {
            // Movimiento horizontal
            Vector3 movement = new Vector3(input.x, 0, 0);
            transform.Translate(movement * speed * Time.deltaTime, Space.World);
        }

        // Manejo del movimiento vertical (rotación en X)
        if (Mathf.Abs(input.y) > 0.1f) // Pequeño umbral para evitar rotaciones no intencionales
        {
            // Rotación en el eje X
            float rotationAmount = input.y * rotationSpeed * Time.deltaTime;
            transform.Rotate(rotationAmount, 0, 0);
        }
    }
}
