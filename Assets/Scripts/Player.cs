using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    
    
    [Header("Movimiento")]
    [SerializeField] float moveSpeed = 0.01f;

    [Header("L�mites de movimiento")]
    [SerializeField] float minX = -2f; // L�mite izquierdo
    [SerializeField] float maxX = 2f;  // L�mite derecho
    [SerializeField] float minZ = -1.7f; // L�mite trasero
    [SerializeField] float maxZ = 0.54f;  // L�mite delantero

    [Header("Alaveo visual")]
    [SerializeField] float tiltAmount = 30f;   // grados m�x de inclinaci�n
    [SerializeField] float tiltSmooth = 10f;   // rapidez de transici�n

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



