using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Move Input")]
    [SerializeField] private AxisReference horizontalMove;
    [SerializeField] private AxisReference verticalMove;

    [Header("Config")] [SerializeField] private float _speed;

    private Vector3 _vectorMove = Vector3.zero;
    private void Update()
    {
        GetInput();

        Debug.Log($"Vector: {_vectorMove.ToString()}");

        var position = transform.position;
        position += _speed * Time.deltaTime * _vectorMove;
        transform.position = position;
    }

    private void GetInput()
    {
        _vectorMove.x = horizontalMove.Value;
        _vectorMove.z = verticalMove.Value;
    }
}
