using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour
{
    public float moveSpeed = 5f; // Vitesse de déplacement du lerp
    private Coroutine moveCoroutine;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }


    public void MoveCameraToTarget(Transform target)
    {
        // Arrêter la coroutine existante si elle est en cours
        if (moveCoroutine != null)
            StopCoroutine(moveCoroutine);

        // Lancer une nouvelle coroutine pour déplacer la caméra vers la position cible
        moveCoroutine = StartCoroutine(MoveCoroutine(target));
    }

    private IEnumerator MoveCoroutine(Transform target)
    {
        // Calculer la distance entre la caméra et la position cible
        float distance = Vector3.Distance(transform.position, target.position);

        // Tant que la distance est supérieure à une petite valeur (pour éviter les problèmes de flottement),
        // continuer à déplacer la caméra vers la position cible
        while (distance > 0.01f)
        {
            // Calculer la nouvelle position de la caméra en utilisant lerp
            Vector3 newPosition = Vector3.Lerp(transform.position, target.position, moveSpeed * Time.deltaTime);

            // Calculer la nouvelle rotation de la caméra en utilisant lerp
            Quaternion newRotation = Quaternion.Slerp(transform.rotation, target.rotation, moveSpeed * Time.deltaTime);

            // Déplacer la caméra vers la nouvelle position
            transform.position = newPosition;

            // Faire tourner la caméra vers la nouvelle rotation
            transform.rotation = newRotation;

            // Mettre à jour la distance
            distance = Vector3.Distance(transform.position, target.position);

            // Attendre la prochaine frame
            yield return null;
        }
    }
}
