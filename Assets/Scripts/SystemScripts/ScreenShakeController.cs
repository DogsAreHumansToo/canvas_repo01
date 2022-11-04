using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShakeController : MonoBehaviour
{

    public IEnumerator Shake (float duration, float magnitude)
    {
        Vector3 originalPosition = transform.localPosition;

        float elapsed = 0.0f;
        while(elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            elapsed += Time.deltaTime;

            transform.localPosition = new Vector3(x + originalPosition.x, y + originalPosition.y, originalPosition.z);

            yield return null;
        }

        //transform.localPosition = x;
    }

}
//private ScreenShakeController cameraShake;
// cameraShake = FindObjectOfType<ScreenShakeController>();
//StartCoroutine(cameraShake.Shake(.04f, .04f));




