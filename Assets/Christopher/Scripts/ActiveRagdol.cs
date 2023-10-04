using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveRagdol : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [Header("Ragdoll Parts")]
    [SerializeField] private Rigidbody[] ragdollRigidbodies;
    [SerializeField] private Collider[] ragdollColliders;

    [SerializeField] private bool enableRagdoll = false; // Control global del Ragdoll

    private void Start()
    {
        // Configura el estado inicial
        SetEnabled(enableRagdoll);
    }

    private void SetEnabled(bool enabled)
    {
        foreach (Rigidbody rb in ragdollRigidbodies)
        {
            rb.isKinematic = !enabled; // Activa o desactiva la física
        }

        foreach (Collider collider in ragdollColliders)
        {
            collider.enabled = enabled; // Activa o desactiva los colliders
        }

        animator.enabled = !enabled; // Activa o desactiva la animación
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            enableRagdoll = true; // Activa el Ragdoll globalmente
            SetEnabled(enableRagdoll);

            // También puedes agregar una función para hacer que el personaje se "caiga" si es necesario.
            // Por ejemplo, si tienes un personaje en pie en un inicio, puedes hacer que se incline hacia adelante.
            // Puedes ajustar esta parte según las necesidades de tu personaje y escenario.
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            enableRagdoll = false; // Desactiva el Ragdoll globalmente
            SetEnabled(enableRagdoll);
        }
    }
}