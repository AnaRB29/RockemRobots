using UnityEngine;
using UnityEngine.Events;

namespace Dante.Code.Damagable
{
    [RequireComponent(typeof(Collider))]
    public class Damagable : MonoBehaviour
    {
        [SerializeField] private UnityEvent OnDamageTake;
        
        public void TakeDamage()
        {
            Debug.Log("Tome Daño");
            OnDamageTake.Invoke();
        }
    }
}