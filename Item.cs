using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Item : MonoBehaviour
{
    public string itemName; // Tên vật phẩm

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log($"Player picked up: {itemName}");
            Destroy(gameObject); // Xóa vật phẩm sau khi nhặt
        }
    }
}
