using UnityEngine;
using UnityEngine.UI;  // Cần thêm để thao tác với UI

public class Tuto : MonoBehaviour
{
    public GameObject tutorialPanel;  // Tham chiếu đến Panel hướng dẫn
    public Button startButton;        // Tham chiếu đến nút Start

    void Start()
    {
        // Đảm bảo rằng khi game bắt đầu, hướng dẫn được hiển thị
        tutorialPanel.SetActive(true);  // Hiển thị hướng dẫn

        // Đăng ký sự kiện cho nút Start
        startButton.onClick.AddListener(HideTutorial);
    }

    // Hàm ẩn hướng dẫn khi người chơi nhấn nút Start
    void HideTutorial()
    {
        tutorialPanel.SetActive(false);  // Ẩn hướng dẫn
    }
}