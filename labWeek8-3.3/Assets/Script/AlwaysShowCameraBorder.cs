
using UnityEngine;

[ExecuteInEditMode]
public class AlwaysShowCameraBorder : MonoBehaviour
{
    private Camera cam;

    void OnDrawGizmos()
    {
        if (cam == null) cam = GetComponent<Camera>();
        if (cam == null) return;

        // Lấy ma trận gốc của hệ tọa độ hiện tại
        Matrix4x4 tempMatrix = Gizmos.matrix;
        
        // Đổi màu đường viền (mặc định là màu trắng giống Unity)
        Gizmos.color = Color.white;
        
        // Thiết lập ma trận vẽ theo tọa độ của Camera
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);

        if (cam.orthographic)
        {
            // Vẽ border cho Camera 2D (Orthographic)
            float spread = cam.farClipPlane - cam.nearClipPlane;
            float center = (cam.farClipPlane + cam.nearClipPlane) * 0.5f;
            Gizmos.DrawWireCube(new Vector3(0, 0, center), new Vector3(cam.orthographicSize * 2 * cam.aspect, cam.orthographicSize * 2, spread));
        }
        else
        {
            // Vẽ border cho Camera 3D (Perspective)
            Gizmos.DrawFrustum(Vector3.zero, cam.fieldOfView, cam.farClipPlane, cam.nearClipPlane, cam.aspect);
        }

        // Trả lại ma trận cũ để không ảnh hưởng gizmo khác
        Gizmos.matrix = tempMatrix;
    }
}
