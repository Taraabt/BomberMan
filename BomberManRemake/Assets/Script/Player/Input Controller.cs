using UnityEngine;
using UnityEngine.InputSystem;


public class InputController : MonoBehaviour
{
    Input input;
    Vector2 move;
    Rigidbody rb;
    [SerializeField] Bomb bomb;
    [SerializeField] float speed;


    private void Awake()
    {
        rb= GetComponent<Rigidbody>();
        input = new Input();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += MovePerformed;
        input.Player.Movement.canceled += MoveCanceled;
        input.Player.Bomb.performed += Launch;
    }
    private void OnDisable()
    {
        input.Disable();
        input.Player.Movement.performed -= MovePerformed;
        input.Player.Movement.canceled -= MoveCanceled;
        input.Player.Bomb.performed -= Launch;
    }

    private void MovePerformed(InputAction.CallbackContext value)
    {
        move = value.ReadValue<Vector2>();
        rb.velocity = new Vector3(move.x, 0, move.y) * speed;
    }
    private void MoveCanceled(InputAction.CallbackContext value)
    {
        Vector3 pos = transform.position;
        transform.position = new Vector3(Mathf.Round(pos.x), pos.y, Mathf.Round(pos.z));
        rb.velocity = Vector2.zero;
    }

    private void Launch(InputAction.CallbackContext value)
    {
        Instantiate(bomb,transform.position,Quaternion.identity);
    }



}
