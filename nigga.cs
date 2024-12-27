using UnityEngine;
using UnityEngine.SceneManagement; // Để quản lý Scene

public class nigga : MonoBehaviour
{
    [Header("Total Pumpkins to Collect")]
    public int totalPumpkins = 10; // Số lượng bí ngô cần thu thập

    private int collectedPumpkins = 0; // Biến đếm số bí ngô đã nhặt

    // Xử lý khi va chạm với bí ngô
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pumpkin"))
        {
            collectedPumpkins++; // Tăng số lượng bí ngô đã nhặt
            Destroy(collision.gameObject); // Xóa bí ngô khỏi cảnh

            Debug.Log("Pumpkins Collected: " + collectedPumpkins);

            // Nếu đủ số lượng bí ngô, chuyển scene
            if (collectedPumpkins >= totalPumpkins)
            {
                LoadNextScene(); // Gọi hàm chuyển scene
            }
        }
    }

    // Hàm chuyển sang Scene khác
    private void LoadNextScene()
    {
        Debug.Log("Loading Next Scene...");
        SceneManager.LoadScene("GameCompleted"); // Thay "GameCompleted" bằng tên Scene tiếp theo
    }
}