using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pumpkin : MonoBehaviour
{
    public int value; // Giá trị của pumpkin
    public AudioClip collectSound; // Tham chiếu đến âm thanh khi thu thập
    private AudioSource audioSource; // Component AudioSource

    // Start được gọi một lần trước lần cập nhật đầu tiên
    void Start()
    {
        // Lấy component AudioSource gắn trên đối tượng này
        audioSource = GetComponent<AudioSource>();

        // Kiểm tra xem AudioSource có tồn tại không
        if (audioSource == null)
        {
            Debug.LogError("HÂN NGU");
        }

        // Kiểm tra xem âm thanh có được gán không
        if (collectSound == null)
        {
            Debug.LogError("Không có âm thanh collectSound được gán trong Inspector.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra nếu đối tượng va chạm là player
        if (other.gameObject.CompareTag("Player"))
        {
            // Kiểm tra và phát âm thanh nếu tất cả các điều kiện thỏa mãn
            if (audioSource != null && collectSound != null)
            {
                audioSource.PlayOneShot(collectSound); // Phát âm thanh một lần
            }

            // Hủy đối tượng pumpkin này
            Destroy(gameObject);

            // Cập nhật điểm
            PumkinCounter.instance.IncreasePumkin(value);
        }
    }
}