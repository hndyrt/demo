using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class door : MonoBehaviour
{
    [Header("Chest Settings")]
    public Animator doorani; // Animator cho rương
    public AudioClip opendoor;

    private bool isOpened = false; // Kiểm tra trạng thái rương

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isOpened)
        {
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        isOpened = true;

        // Phát hiệu ứng mở rương
        if (doorani != null)
        {
            doorani.SetTrigger("Open");
        }

        // Phát âm thanh
        if (opendoor != null)
        {
            AudioSource.PlayClipAtPoint(opendoor, transform.position);
        }
        }
    
}
