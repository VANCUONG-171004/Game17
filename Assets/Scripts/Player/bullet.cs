using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private float bulletSpeed = 4.5f;

    private void Update() {
        transform.position += transform.right * Time.deltaTime * bulletSpeed;
    }
}
