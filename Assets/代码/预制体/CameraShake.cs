using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{
    private Transform  cameraTransform;
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input .GetKey(KeyCode.L))
        {
            DOTween.To(() => cameraTransform.position, x => cameraTransform.position = x, cameraTransform.position* 2, 2);
        }
    }
}
