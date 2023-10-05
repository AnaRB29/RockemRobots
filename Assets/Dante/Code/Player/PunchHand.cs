using System.Collections;
using System.Collections.Generic;
using Dante.Code.Damagable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class PunchHand : MonoBehaviour
{
    private enum MouseClick
    {
        Left = 0,
        Right = 1
    }
    
    [Header("Mouse Input")]
    [SerializeField] private MouseClick mouseButton;

    [Space, SerializeField, Min(0.001f)] private float speed = 1;
    
    private bool _isPressing;

    [Header("Physics Config")]
    [Space, SerializeField] private LayerMask _maskOfPunch;

    [SerializeField] private float hitRadius;

    [SerializeField] private Transform target, foldTarget, unfoldTarget;

    [Space, SerializeField] private UnityEvent onPunched;

    private Collider[] _colliders = new Collider[5];

    void Update()
    {
        if (!Input.GetMouseButtonDown((int)mouseButton)) return;
        HandlePunch();
    }
    
    private void HandlePunch()
    {
        if (_punchCoroutine != null) return;
        _punchCoroutine = StartCoroutine(PunchCoroutine());
    }
    
    private IEnumerator MoveToPosCoroutine(Transform targetToMove)
    {
        while (target.position != targetToMove.position)
        {
            target.position = Vector3.MoveTowards(target.position, targetToMove.position, speed * Time.deltaTime);
            yield return null;
        }
    }

    private Coroutine _punchCoroutine = null;
    private IEnumerator PunchCoroutine()
    {
        yield return StartCoroutine(MoveToPosCoroutine(unfoldTarget));
        Debug.Log("Bajo la mano");
        
        var touched = Physics.OverlapSphereNonAlloc(unfoldTarget.position, hitRadius, _colliders, _maskOfPunch);
        
        if (touched > 0)
        {
            for (int i = 0; i < _colliders.Length; i++)
            {
                //Try Make Punch
                if (!_colliders[i].TryGetComponent<Damagable>(out var damagable)) continue;
                damagable.TakeDamage();
            }
            onPunched.Invoke();
        }

        yield return StartCoroutine(MoveToPosCoroutine(foldTarget));
        Debug.Log(("Volvio a su normalidad"));
        
        _punchCoroutine = null;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(unfoldTarget.position, hitRadius);
    }
}