using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Transform mainCamera;
    private Vector3 objectRot = new Vector3(10f, 0, 0); // 카메라 목표 각도, 플레이어 움직임에 영향 x

    private Vector3 curPos; // current camera position
    private Vector3 playerPos; // current player position
    private Vector3 objectPos;
    public float lerpTime = 0.1f;

    void Awake()
    {
        mainCamera = gameObject.transform;
        mainCamera.eulerAngles = objectRot;
    }

    void LateUpdate()
    {
        curPos = mainCamera.position;
        playerPos = player.transform.position;

        objectPos = new Vector3(playerPos.x, playerPos.y + 2, playerPos.z - 6);
        mainCamera.transform.position = Vector3.Lerp(curPos, objectPos, lerpTime);
    }
}
