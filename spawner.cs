using UnityEngine;

public class spawner : MonoBehaviour
{
    // Tham chiếu đến prefab mà bạn muốn spawn
    public GameObject prefab;

    // Bán kính của hình tròn
    public float radius = 5f;

    // Thời gian delay giữa các lần spawn
    public float spawnInterval = 1000f;

    // Số lượng prefab cần spawn mỗi lần
    public int spawnCount = 1;

    void Start()
    {
        // Bắt đầu quá trình spawn
        InvokeRepeating("SpawnPrefabsInCircle", 0f, spawnInterval);
    }

    void SpawnPrefabsInCircle()
    {
        // Lặp lại quá trình spawn một số lượng prefab (spawnCount)
        for (int i = 0; i < spawnCount; i++)
        {
            // Tính toán góc ngẫu nhiên trong phạm vi từ 0 đến 360 độ
            float angle = Random.Range(0f, 360f);

            // Chuyển đổi góc từ độ sang radian
            float angleRad = angle * Mathf.Deg2Rad;

            // Tính toán vị trí spawn theo hình tròn
            float x = Mathf.Cos(angleRad) * radius;
            float z = Mathf.Sin(angleRad) * radius;

            // Tọa độ spawn trong không gian 3D
            Vector3 spawnPosition = new Vector3(x, 0f, z) + transform.position; // Thêm transform.position để spawn quanh vị trí của object gốc

            // Spawn prefab tại vị trí đã tính toán
            Instantiate(prefab, spawnPosition, Quaternion.identity);
        }
    }

    // Hiển thị hình tròn trong Scene view bằng Gizmos
    private void OnDrawGizmos()
    {
        // Đặt màu của Gizmos (ví dụ: màu xanh lá)
        Gizmos.color = Color.green;

        // Vẽ một hình tròn với bán kính đã chỉ định
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}