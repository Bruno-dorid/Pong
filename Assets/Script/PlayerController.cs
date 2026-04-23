using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Sistema de movimentação
    public InputActionReference moveAction;

    //velocidade da raquete
    public float moveSpeed = 5f;

    //Limite de movimentação da raquete
    private float limity = 3f;
    private float myY;


    private void Start()
    {
        myY = transform.position.y;
    }
    private void OnEnable()
    {
        moveAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
    }


    private void Update()

    {

        //Lê o valor do input
        Vector2 moveInput = moveAction.action.ReadValue<Vector2>();
        //Calcula a nova posição da raquete
        myY += moveInput.y * moveSpeed * Time.deltaTime;
        //Limite a posição da raquete dentro dos limites definidos
        myY = Mathf.Clamp(myY, -limity, limity);
       

        Vector3 pos = transform.position;
        pos.y = myY;
        transform.position = pos;   
    }



}
