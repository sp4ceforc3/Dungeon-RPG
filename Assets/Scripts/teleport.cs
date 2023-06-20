using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    [SerializeField] Vector3 teleportPos;

    private void OnTriggerEnter2D(Collider2D other) {
        other.gameObject.transform.position = teleportPos;
    }
}
