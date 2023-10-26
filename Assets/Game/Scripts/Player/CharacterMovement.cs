using System.Collections;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float _speed = 15f;
    public float maxSpeed = 50;
    public float targetSpeed;
    public float acceleration = 1f;

    private Rigidbody m_Rigidbody;
    private InputActions inputActions;

    private void Awake()
    {
        inputActions = new InputActions();
        inputActions.Enable();
    }
    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        targetSpeed = _speed;
        StartCoroutine(IncreaseSpeedOverTime());
    }

    private void Update()
    {
        MoveHorizontal();
    }

    private void MoveHorizontal()
    {
       
        var moveInput = inputActions.Game.Move.ReadValue<Vector3>();
        
        Vector3 moveDirection = new Vector3(moveInput.x, 0, 1f).normalized;
        m_Rigidbody.velocity = moveDirection * targetSpeed;
    }

    private IEnumerator IncreaseSpeedOverTime()
    {
        while (targetSpeed < maxSpeed)
        {
            yield return new WaitForSeconds(2);
            targetSpeed += acceleration; 
        }
    }
}
