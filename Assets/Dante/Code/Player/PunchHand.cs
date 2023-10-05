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
        _isPressing = Input.GetMouseButton((int)mouseButton);

        var currentTarget = _isPressing ? unfoldTarget : foldTarget;
        target.position = Vector3.MoveTowards(target.position, currentTarget.position, speed * Time.deltaTime);

        if (target.position.sqrMagnitude >= unfoldTarget.position.sqrMagnitude - Mathf.Epsilon * 10)
            HandlePunch();
    }

    private void HandlePunch()
    {
        if (_punchCoroutine != null) return;
        _punchCoroutine = StartCoroutine(PunchCoroutine());
    }

    private Coroutine _punchCoroutine = null;
    private IEnumerator PunchCoroutine()
    {
        Physics.OverlapSphereNonAlloc(unfoldTarget.position, hitRadius, _colliders, _maskOfPunch);
        for (int i = 0; i < _colliders.Length; i++)
        {
            //Try Make Punch
            if(!_colliders[i].TryGetComponent<Damagable>(out var damagable)) continue;
            damagable.TakeDamage();
        }

        onPunched.Invoke();
        yield return new WaitWhile(() => _isPressing);
        _punchCoroutine = null;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(unfoldTarget.position, hitRadius);
    }
}