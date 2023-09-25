using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputActionProperty _movementAction;

    [Header("Config")] [SerializeField] private float _speed;

    private Vector3 _vectorMove;
    private void Update()
    {
        GetInput();

        Debug.Log($"Vector: {_movementAction.action.ReadValue<Vector2>()}");

        var position = transform.position;
        position += _vectorMove * _speed;
        transform.position = position;
    }

    private void GetInput()
    {
        _vectorMove = _movementAction.action.ReadValue<Vector2>();
        //_vectorMove.x = vectorMove.x;
        //_vectorMove.z = vectorMove.y;
    }
}
