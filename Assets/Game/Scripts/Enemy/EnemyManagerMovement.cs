using UnityEngine;

public class EnemyManagerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 6f;
    private Rigidbody m_Rigidbody;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Aplica uma força para mover o objeto para frente no eixo Z
        m_Rigidbody.AddForce(transform.forward * _speed);
    }
}
