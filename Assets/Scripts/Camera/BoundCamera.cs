using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class BoundCamera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera xcamera;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            xcamera.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            xcamera.gameObject.SetActive(false);
        }
    }
}
