using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class camera : MonoBehaviour
{
    private Transform cameraTransform;
    public Transform player;

    void Start()
    {
        cameraTransform = GetComponent<Transform>();
    }
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, -10f);
        
    }
}
