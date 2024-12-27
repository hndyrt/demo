using UnityEngine;

public class music : MonoBehaviour
{
    [Header("Âm Thanh Nền")]
    public AudioClip backgroundMusic; // Âm thanh nền cho màn chơi.
    public bool loopBackgroundMusic = true; // Chế độ lặp lại âm thanh nền.

    private AudioSource audioSource;

    void Start()
    {
        // Lấy AudioSource gắn vào Camera
        audioSource = GetComponent<AudioSource>();

        // Kiểm tra xem có AudioSource chưa, nếu chưa thì tạo mới
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Nếu âm thanh nền được gán và chưa được phát, thì phát âm thanh
        if (backgroundMusic != null && !audioSource.isPlaying)
        {
            audioSource.clip = backgroundMusic;
            audioSource.loop = loopBackgroundMusic; // Lặp lại âm thanh nếu cần
            audioSource.Play();
        }
    }

    void Update()
    {
        // Đảm bảo rằng AudioSource di chuyển cùng với Camera
        if (audioSource != null)
        {
            // Đặt lại vị trí của AudioSource để nó luôn ở cùng vị trí với Camera
            audioSource.transform.position = Camera.main.transform.position;
        }
    }
}