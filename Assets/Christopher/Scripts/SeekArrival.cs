using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekArrival : MonoBehaviour

{
    public Transform target;
    public float speed = 5.0f;
    public float rotationSpeed = 5.0f; // Nueva variable para la velocidad de rotación
    public float stoppingDistance = 1.0f;

    private void Update()
    {
        if (target == null)
        {
            Debug.LogError("No se ha asignado un objetivo.");
            return;
        }

        // Calcula la dirección hacia el objetivo
        Vector3 direction = (target.position - transform.position).normalized;

        // Calcula la rotación hacia la dirección del objetivo
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Aplica la rotación gradualmente
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Calcula la distancia al objetivo
        float distance = Vector3.Distance(transform.position, target.position);

        // Si estamos lo suficientemente cerca del objetivo, reduce la velocidad para la llegada suave
        if (distance <= stoppingDistance)
        {
            float arrivalSpeed = Mathf.Lerp(0, speed, distance / stoppingDistance);
            transform.position += transform.forward * arrivalSpeed * Time.deltaTime;
        }
        else
        {
            // Si estamos lejos del objetivo, aplica velocidad máxima
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}