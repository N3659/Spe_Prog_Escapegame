using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour
{
    public float moveSpeed = 5f; // Vitesse de d�placement du lerp
    private Coroutine moveCoroutine;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }


    public void MoveCameraToTarget(Transform target)
    {
        // Arr�ter la coroutine existante si elle est en cours
        if (moveCoroutine != null)
            StopCoroutine(moveCoroutine);

        // Lancer une nouvelle coroutine pour d�placer la cam�ra vers la position cible
        moveCoroutine = StartCoroutine(MoveCoroutine(target));
    }

    private IEnumerator MoveCoroutine(Transform target)
    {
        // Calculer la distance entre la cam�ra et la position cible
        float distance = Vector3.Distance(transform.position, target.position);

        // Tant que la distance est sup�rieure � une petite valeur (pour �viter les probl�mes de flottement),
        // continuer � d�placer la cam�ra vers la position cible
        while (distance > 0.01f)
        {
            // Calculer la nouvelle position de la cam�ra en utilisant lerp
            Vector3 newPosition = Vector3.Lerp(transform.position, target.position, moveSpeed * Time.deltaTime);

            // Calculer la nouvelle rotation de la cam�ra en utilisant lerp
            Quaternion newRotation = Quaternion.Slerp(transform.rotation, target.rotation, moveSpeed * Time.deltaTime);

            // D�placer la cam�ra vers la nouvelle position
            transform.position = newPosition;

            // Faire tourner la cam�ra vers la nouvelle rotation
            transform.rotation = newRotation;

            // Mettre � jour la distance
            distance = Vector3.Distance(transform.position, target.position);

            // Attendre la prochaine frame
            yield return null;
        }
    }
}
