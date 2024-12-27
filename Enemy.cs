using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Tốc độ di chuyển của enemy
    public float moveSpeed = 5f;

    // Vị trí bắt đầu và kết thúc của enemy
    public Vector3 startPoint;
    public Vector3 endPoint;

    // Biến để kiểm tra hướng di chuyển (true = đi đến endPoint, false = quay lại startPoint)
    private bool movingToEnd = true;

    void Start()
    {
        // Đặt vị trí bắt đầu là vị trí hiện tại của enemy
        startPoint = transform.position;
        endPoint = startPoint + new Vector3(10f, 0f, 0f); // Di chuyển theo trục X, ví dụ 10 đơn vị
    }

    void Update()
    {
        // Di chuyển enemy giữa startPoint và endPoint
        if (movingToEnd)
        {
            // Di chuyển về phía endPoint
            transform.position = Vector3.MoveTowards(transform.position, endPoint, moveSpeed * Time.deltaTime);

            // Quay mặt enemy sang phải khi di chuyển sang phải
            if (transform.position.x > startPoint.x)
            {
                Flip(true); // Quay mặt sang phải khi đi sang phải
            }

            // Kiểm tra xem enemy đã đến endPoint chưa
            if (transform.position == endPoint)
            {
                movingToEnd = false; // Đổi hướng di chuyển
            }
        }
        else
        {
            // Di chuyển về phía startPoint
            transform.position = Vector3.MoveTowards(transform.position, startPoint, moveSpeed * Time.deltaTime);

            // Quay mặt enemy sang trái khi di chuyển sang trái
            if (transform.position.x < endPoint.x)
            {
                Flip(false); // Quay mặt sang trái khi đi sang trái
            }

            // Kiểm tra xem enemy đã đến startPoint chưa
            if (transform.position == startPoint)
            {
                movingToEnd = true; // Đổi hướng di chuyển
            }
        }
    }

    // Hàm đảo ngược hướng của enemy
    void Flip(bool faceRight)
    {
        // Đảo chiều quay của enemy (trái/phải) bằng cách thay đổi giá trị localScale.x
        Vector3 theScale = transform.localScale;
        theScale.x = faceRight ? Mathf.Abs(theScale.x) : -Mathf.Abs(theScale.x); // Nếu đi sang phải (faceRight = true) thì set x > 0, nếu không thì set x < 0
        transform.localScale = theScale;
    }
}