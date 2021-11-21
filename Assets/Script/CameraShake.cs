using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public bool isShaking;
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0.0f;
        isShaking = true;

        while( elapsed < duration )
        {
            float x = Random.Range(-0.1f, 0.1f) * magnitude;
            float y = Random.Range(1.7f, 1.9f) * magnitude;// player身高1.8

            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
        isShaking = false;
    }
}
