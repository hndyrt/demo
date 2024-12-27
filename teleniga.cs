using UnityEngine;
using System.Collections;

public class Teleniga : MonoBehaviour
{
    [Header("Vị trí Dịch Chuyển")]
    public Transform teleportDestination; // Vị trí đích để dịch chuyển nhân vật.

    [Header("Tag để Phát Hiện")]
    public string targetTag = "Player"; // Tag của đối tượng cần dịch chuyển (thường là "Player").

    [Header("Hiệu Ứng Dịch Chuyển")]
    public GameObject teleportEffect; // Hiệu ứng khi dịch chuyển (tùy chọn).
    public AudioClip teleportSound; // Âm thanh khi dịch chuyển (tùy chọn).
    public float effectDuration = 1f; // Thời gian tồn tại của hiệu ứng (tùy chọn).

    [Header("Delay Trước Khi Dịch Chuyển")]
    public float teleportDelay = 1f; // Thời gian hoãn trước khi dịch chuyển.

    [Header("Thời Gian Cần Để Dịch Chuyển")]
    public float requiredTimeInTrigger = 5f; // Thời gian yêu cầu để đứng trong vùng trigger (5 giây).

    private float timeInTrigger = 0f; // Thời gian hiện tại mà đối tượng đã ở trong trigger.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra nếu đối tượng chạm có tag phù hợp
        if (collision.CompareTag(targetTag))
        {
            // Đặt lại thời gian khi người chơi vào trigger
            timeInTrigger = 0f;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // Kiểm tra nếu đối tượng có tag phù hợp và đã ở trong trigger đủ lâu
        if (collision.CompareTag(targetTag))
        {
            // Tăng thời gian đã ở trong trigger
            timeInTrigger += Time.deltaTime;

            // Nếu đã đứng đủ lâu (5 giây), bắt đầu dịch chuyển
            if (timeInTrigger >= requiredTimeInTrigger)
            {
                StartCoroutine(TeleportAfterDelay(collision));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Nếu đối tượng ra khỏi trigger, reset lại thời gian
        if (collision.CompareTag(targetTag))
        {
            timeInTrigger = 0f;
        }
    }

    private IEnumerator TeleportAfterDelay(Collider2D collision)
    {
        // Hoãn hành động trong khoảng thời gian teleportDelay
        yield return new WaitForSeconds(teleportDelay);

        // Dịch chuyển đối tượng tới vị trí đích
        Vector3 originalPosition = collision.transform.position;
        collision.transform.position = teleportDestination.position;

        // (Tùy chọn) Hiển thị hiệu ứng hoặc âm thanh khi dịch chuyển
        if (teleportEffect != null)
        {
            // Tạo hiệu ứng tại vị trí teleport
            GameObject effect = Instantiate(teleportEffect, originalPosition, Quaternion.identity);
            Destroy(effect, effectDuration); // Xóa hiệu ứng sau khi xong
        }

        if (teleportSound != null)
        {
            // Phát âm thanh khi dịch chuyển
            AudioSource.PlayClipAtPoint(teleportSound, originalPosition);
        }

        Debug.Log("Đã dịch chuyển từ: " + originalPosition + " đến: " + teleportDestination.position);
    }
}