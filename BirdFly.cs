using UnityEngine;

public class BirdFly : MonoBehaviour
{
    public float speed = 2f; // Tốc độ di chuyển của con chim
    public float areaWidth = 10f; // Phạm vi di chuyển theo chiều ngang
    public float areaHeight = 5f; // Phạm vi di chuyển theo chiều dọc
    public float changeDirectionTime = 3f; // Thời gian trước khi thay đổi hướng
    private Vector2 targetPosition; // Vị trí mục tiêu ngẫu nhiên tiếp theo
    private float timer; // Bộ đếm thời gian cho việc thay đổi hướng

    private Animator animator; // Tham chiếu đến Animator

    void Start()
    {
        animator = GetComponent<Animator>(); // Lấy component Animator
        SetNewTargetPosition(); // Khởi tạo một vị trí mục tiêu ngẫu nhiên
    }

    void Update()
    {
        // Di chuyển con chim theo vị trí mục tiêu
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Kiểm tra xem đã đến lúc thay đổi hướng chưa
        timer += Time.deltaTime;
        if (timer >= changeDirectionTime || (Vector2)transform.position == targetPosition)
        {
            SetNewTargetPosition(); // Thiết lập vị trí mục tiêu mới
            timer = 0;

            // Kích hoạt animation "flap" nếu có
          
        }

        // Lật sprite dựa trên hướng di chuyển
        FlipSprite();
    }

    // Thiết lập một vị trí ngẫu nhiên trong phạm vi đã chỉ định
    private void SetNewTargetPosition()
    {
        float randomX = Random.Range(-areaWidth / 2, areaWidth / 2);
        float randomY = Random.Range(-areaHeight / 2, areaHeight / 2);
        targetPosition = new Vector2(randomX, randomY) + (Vector2)transform.position;
    }

    // Lật sprite để khớp với hướng di chuyển
    private void FlipSprite()
    {
        Vector3 scale = transform.localScale;
        if (targetPosition.x > transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x); // Quay mặt sang phải
        }
        else if (targetPosition.x < transform.position.x)
        {
            scale.x = -Mathf.Abs(scale.x); // Quay mặt sang trái
        }
        transform.localScale = scale;
    }

    // Tùy chọn: Vẽ vùng di chuyển trong Scene view
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(areaWidth, areaHeight, 0));
    }
}