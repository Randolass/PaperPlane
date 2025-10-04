using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    
    
    [Header("Movimiento")]
    [SerializeField] float moveSpeed = 0.01f;

    [Header("Límites de movimiento")]
    [SerializeField] float minX = -2f; // Límite izquierdo
    [SerializeField] float maxX = 2f;  // Límite derecho
    [SerializeField] float minZ = -1.7f; // Límite trasero
    [SerializeField] float maxZ = 0.54f;  // Límite delantero

    [Header("Alaveo visual")]
    [SerializeField] float tiltAmount = 30f;   // grados máx de inclinación
    [SerializeField] float tiltSmooth = 10f;   // rapidez de transición

        Vector2 moveInput;             // valor del Input System (-1..1, -1..1)
    
    Transform theTransform;

    private void Start()
    {
        theTransform = GetComponent<Transform>();
    }

    void Update()
    {
        MoveAround();
        Tilt();
    }

    private void Tilt()
    {
        float targetRoll = -moveInput.x * tiltAmount;
        Quaternion targetRot = Quaternion.Euler(0f, 0f, targetRoll);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, tiltSmooth * Time.deltaTime);
    }

    private void MoveAround()
    {
        Vector3 move = new Vector3(moveInput.x, 0f, moveInput.y);
        //transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);
        Vector3 newPosition = transform.position + move * moveSpeed * Time.deltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);

        transform.position = newPosition;
    }

    // Callback generado por el Input System (Action "Move")
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    
}



