using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenShake : MonoBehaviour
{
    Vector3 cameraPosition;
    public float shakeStrength, shakeDuration;
    public Camera gameCamera;

    public void Shake()
    {
        cameraPosition = gameCamera.transform.position;
        InvokeRepeating("ShakeStart", 0, 0.05f);
        Invoke("ShakeStop", shakeDuration);
    }

    private void ShakeStart()
    {
        float cameraShakePosX = Random.Range(-1, 2) * shakeStrength;
        float cameraShakePosY = Random.Range(-1, 2) * shakeStrength;

        Vector3 cameraShakePosition = gameCamera.transform.position;
        cameraShakePosition.x += cameraShakePosX;
        cameraShakePosition.y += cameraShakePosY;
        gameCamera.transform.position = cameraShakePosition;
    }

    private void ShakeStop()
    {
        CancelInvoke("ShakeStart");
        gameCamera.transform.position = cameraPosition;
    }

}
