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
            // R�cup�rer les coordonn�es du centre de l'�cran
            float centerX = Screen.width / 2f;
            float centerY = Screen.height / 2f;

            // Cr�er un rayon depuis le centre de l'�cran en direction de la cam�ra
            Ray ray = playerCamera.ScreenPointToRay(new Vector3(centerX, centerY, 0f));

            // V�rifier si le rayon touche un objet
            if (Physics.Raycast(ray, out hit))
            {
                // V�rifier si l'objet touch� est un objet que le joueur vise
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

        if (Input.GetKeyDown(KeyCode.Escape)) // touche � modifier plus tard �ventuellement
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
