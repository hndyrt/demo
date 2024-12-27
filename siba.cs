using UnityEngine;

public class siba : MonoBehaviour
{
    // Kiểm tra đối tượng có tag là "Player"
    public string targetTag = "Player";  // Tag của đối tượng muốn tương tác (thường là "Player")

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra nếu đối tượng chạm vào có tag là Player
        if (collision.CompareTag(targetTag))
        {
            // Phá hủy đối tượng này (self)
            Destroy(gameObject);
            Debug.Log("Đã phá hủy đối tượng!");
        }
    }
}