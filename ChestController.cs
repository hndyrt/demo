using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChestController2D : MonoBehaviour
{
    [Header("Chest Settings")]
     public int value;
    public Animator chestAnimator; // Animator cho rương
    public GameObject itemPrefab; // Prefab của vật phẩm
    public Transform spawnPoint; // Vị trí rơi vật phẩm
    public AudioClip openChestSound; // Âm thanh mở rương
    public string itemName = "Pumkin"; // Tên vật phẩm

    private bool isOpened = false; // Kiểm tra trạng thái rương

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isOpened)
        {
            OpenChest();
        }
    }

    void OpenChest()
    {
        isOpened = true;

        // Phát hiệu ứng mở rương
        if (chestAnimator != null)
        {
            chestAnimator.SetTrigger("Open");
        }

        // Phát âm thanh
        if (openChestSound != null)
        {
            AudioSource.PlayClipAtPoint(openChestSound, transform.position);
        }

        // Spawn vật phẩm
        if (itemPrefab != null && spawnPoint != null)
        {
             GameObject spawnedItem = Instantiate(itemPrefab, spawnPoint.position, Quaternion.identity);
            Debug.Log($"Player received: {itemName}");
    
            PumkinCounter.instance.IncreasePumkin(value);
        }
        
    }
}
