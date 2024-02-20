using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    private Camera playerCamera;
    private RaycastHit hit;
    public Move moveScript;
    public moveCamera cameraScript;
    public Transform transformTarget;
    private Transform cameraOriginalTransform;

    void Start()
    {
        playerCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !moveScript.puzzleMode)
        {
            // Récupérer les coordonnées du centre de l'écran
            float centerX = Screen.width / 2f;
            float centerY = Screen.height / 2f;

            // Créer un rayon depuis le centre de l'écran en direction de la caméra
            Ray ray = playerCamera.ScreenPointToRay(new Vector3(centerX, centerY, 0f));

            // Vérifier si le rayon touche un objet
            if (Physics.Raycast(ray, out hit))
            {
                // Vérifier si l'objet touché est un objet que le joueur vise
                if (hit.collider.gameObject.name == "Cube")
                {
                    if (hit.distance <= 3)
                    {
                        cameraOriginalTransform = playerCamera.transform;
                        moveScript.puzzleMode = true;
                        cameraScript.MoveCameraToTarget(transformTarget);
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape)) // touche à modifier plus tard éventuellement
        {
            if (moveScript.puzzleMode)
            {
                cameraScript.MoveCameraToTarget(cameraOriginalTransform);

                //playerCamera.transform.position = cameraOriginalTransform.position;
                moveScript.puzzleMode = false;
                //playerCamera.transform.rotation = cameraOriginalTransform.rotation;
            }
        }
    }
}
