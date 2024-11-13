using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Lớp PlayerScript thừa kế từ MonoBehaviour, là thành phần gắn vào đối tượng người chơi trong Unity
public class PlayerScript : MonoBehaviour
{
    [Header("Player Movement")] // Tạo tiêu đề trong Inspector cho phần điều khiển di chuyển
    public float playerSpeed = 1.9f; // Tốc độ di chuyển của người chơi

    [Header("Player Animator and Gravity")] // Tạo tiêu đề trong Inspector cho phần Animator và Gravity
    public CharacterController cC; // Tham chiếu đến thành phần CharacterController, giúp xử lý di chuyển và va chạm
    
    [Header("Player Jumping and velocity")] // Tạo tiêu đề trong Inspector cho phần Nhảy và Vận tốc
    public float turnCalmTime = 0.1f; // Thời gian xoay mượt mà, giúp kiểm soát độ trễ khi xoay nhân vật
    float turnCalmVelocity; // Biến lưu trữ tốc độ góc hiện tại, dùng cho xoay mượt mà

    // Phương thức Update, chạy mỗi khung hình (frame) để kiểm tra và cập nhật các thao tác của người chơi
    private void Update()
    {
        playerMove(); // Gọi phương thức playerMove() để xử lý di chuyển của người chơi
    }

    // Phương thức xử lý di chuyển của người chơi
    void playerMove()
    {
        // Lấy giá trị đầu vào từ các trục "Horizontal" và "Vertical" (tương ứng với các phím mũi tên hoặc WASD)
        float horizontalAxis = Input.GetAxisRaw("Horizontal");
        float verticalAxis = Input.GetAxisRaw("Vertical");

        // Tạo vector hướng di chuyển dựa trên đầu vào từ các trục, sau đó chuẩn hóa (normalize) vector
        Vector3 direction = new Vector3(horizontalAxis, 0f, verticalAxis).normalized;

        // Kiểm tra nếu độ lớn của vector hướng lớn hơn 0.1f để ngăn nhân vật di chuyển khi đầu vào rất nhỏ
        if (direction.magnitude > 0.1f)
        {
            // Tính góc mục tiêu dựa trên hướng di chuyển và chuyển đổi từ radian sang độ
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            // Xoay nhân vật một cách mượt mà từ góc hiện tại đến góc mục tiêu với độ trễ là turnCalmTime
          //  float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnCalmVelocity, turnCalmTime);

            // Cập nhật góc xoay của nhân vật theo góc mượt mà đã tính toán
          //  transform.rotation = Quaternion.Euler(0, angle, 0f);
            transform.rotation = Quaternion.Euler(0, targetAngle, 0f);
            // Di chuyển nhân vật theo hướng đã chuẩn hóa, với tốc độ playerSpeed và đảm bảo tính độc lập với khung hình
            cC.Move(direction.normalized * playerSpeed * Time.deltaTime);
        }
    }
}
