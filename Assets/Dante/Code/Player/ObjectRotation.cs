using UnityEngine;
using Dante.Variable;
using UnityEngine.Serialization;

public class ObjectRotation : MonoBehaviour
{
    [SerializeField] private MouseInput mouseInput;
    [SerializeField] private VectorAxis axisToRotate;
    [SerializeField] private VectorAxis axisToDelta;

    [Space, SerializeField] private bool useClamp = false;
    [SerializeField] private bool invertRotation;
    [SerializeField] private float minAngle, maxAngle;

    private Vector3 _oldPosition = Vector3.zero;
    private float _currentAngle;

    private void Update()
    {
        var deltaPos = (_oldPosition - mouseInput.Position);

        var delta = CalculateDelta(deltaPos); 
        var axis = CalculateAxis();
        var rot = CalculateRotation(delta, axis);
        
        transform.localRotation = rot;

        _oldPosition = mouseInput.Position;
    }
    
    private Quaternion CalculateRotation(float delta, Vector3 axis)
    {
        _currentAngle += invertRotation ? -delta : delta;
        if(useClamp)
            _currentAngle = Mathf.Clamp(_currentAngle, minAngle, maxAngle);
        
        var rot = Quaternion.AngleAxis(_currentAngle, axis);
        return rot;
    }

    private Vector3 CalculateAxis()
    {
        Vector3 axis = Vector3.zero;
        switch (axisToRotate)
        {
            case VectorAxis.X:
                axis = Vector3.right;
                break;
            case VectorAxis.Y:
                axis = Vector3.up;
                break;
            case VectorAxis.Z:
                axis = Vector3.forward;
                break;
        }

        return axis;
    }

    private float CalculateDelta(Vector3 deltaPos)
    {
        float delta = 0;
        switch (axisToDelta)
        {
            case VectorAxis.X:
                delta = deltaPos.x;
                break;
            case VectorAxis.Y:
                delta = deltaPos.y;
                break;
        }

        return delta;
    }
}
