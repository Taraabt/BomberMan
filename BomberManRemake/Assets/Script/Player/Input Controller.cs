using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public Input input;
    Vector2 move;
    [SerializeField] float moveTime;
    [SerializeField] Bomb bomb;
    bool canMove = true;
    bool isBlocked => Player.instance.checkObject;
    public static InputController instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
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
        input.Player.Bomb.performed += Launch;
    }

    private void MovePerformed(InputAction.CallbackContext value)
    {
        move = value.ReadValue<Vector2>();
        move = new Vector2(Mathf.Round(move.x), Mathf.Round(move.y));
        Debug.Log(move);
        Player.instance.CheckMove(move);
        if (isBlocked==false)
        {
            transform.position += new Vector3(Mathf.Round(move.x), 0, Mathf.Round(move.y));
        }
    }
    private void MoveCanceled(InputAction.CallbackContext value)
    {
        move = Vector2.zero;
    }


    IEnumerator Move()
    {
        canMove = false;
        yield return new WaitForSeconds(moveTime);
        Player.instance.CheckMove(move);
        if (isBlocked == false)
        {
            transform.position += new Vector3(Mathf.Round(move.x), 0, Mathf.Round(move.y));
        }
        canMove = true;
    }

    private void FixedUpdate()
    {
        if (input.Player.Movement.IsPressed() && canMove)
        {
            StartCoroutine(Move());
        }
    }

    private void Launch(InputAction.CallbackContext value)
    {
        Vector3 target = new Vector3(transform.position.x,bomb.transform.position.y,transform.position.z);
        if(!Player.instance.spawnBomb) 
            Instantiate(bomb, target, Quaternion.identity);
    }



}
