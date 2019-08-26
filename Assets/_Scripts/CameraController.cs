using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [System.Serializable]
    public class CameraSettings {
        public Vector3 offset = new Vector3(0, 0.3f, -2.6f);
        public float damping; 

    }

    [SerializeField] CameraSettings cameraSettings = new CameraSettings();

    Transform cameraLookTarget;
    public Player localPlayer;
    void Awake() {
        GameManager.Instance.OnLocalPlayerJoined += HandleOnLocalPlayerJoined;
    }

    void HandleOnLocalPlayerJoined (Player player)
    {
        localPlayer = player;
        cameraLookTarget = localPlayer.transform.Find("cameraLookTarget");
        if (cameraLookTarget == null)
        {
            print("Target not found, assigning player instead");
            cameraLookTarget = localPlayer.transform;
        }
    }

    void Update()
    {
        Vector3 targetPosition = cameraLookTarget.position +
            localPlayer.transform.forward * cameraSettings.offset.z +
            localPlayer.transform.up * cameraSettings.offset.y +
            localPlayer.transform.right * cameraSettings.offset.x;      
        
        Quaternion targetRotation = Quaternion.LookRotation(cameraLookTarget.position - targetPosition, Vector3.up);

        transform.position = Vector3.Lerp(transform.position, targetPosition, cameraSettings.damping * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, cameraSettings.damping * Time.deltaTime);
    }

}
