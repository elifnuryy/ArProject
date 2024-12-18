using UnityEngine;

public class CameraSetup : MonoBehaviour
{
    public Transform obj1; // Ýlk obje
    public Transform obj2; // Ýkinci obje
    public float cameraDistance = 10f; // Kameranýn objelerden uzaklýðý
    public Vector3 cameraRotation = new Vector3(30f, 0f, 0f); // Kameranýn baþlangýçtaki döngü açýsý

    private Vector3 offset;  // Kameranýn baþlangýçtaki pozisyonunu tutmak için
    private bool isDragging = false; // Kamerayý sürüklerken kontrol
    private Vector3 lastMousePosition;

    void Start()
    {
        // Kamerayý objelerin ortasýnda konumlandýr
        Vector3 middlePosition = (obj1.position + obj2.position) / 2f;

        // Kamerayý objelerin biraz gerisinde yerleþtir (cameraDistance ile uzaklýk ayarlanýr)
        transform.position = middlePosition - transform.forward * cameraDistance;

        // Kamerayý belirli bir açýyla döndür
        transform.rotation = Quaternion.Euler(cameraRotation);

        // Kameranýn objelere bakmasýný saðla
        transform.LookAt(middlePosition);
    }

    void Update()
    {
        // Fare sað týklandýðýnda kamerayý hareket ettirme iþlemi
        if (Input.GetMouseButtonDown(1)) // Sað týklama ile hareketi baþlat
        {
            isDragging = true;
            lastMousePosition = Input.mousePosition; // Fare týklama konumunu kaydet
        }

        if (Input.GetMouseButtonUp(1)) // Sað týklama býrakýldýðýnda hareketi durdur
        {
            isDragging = false;
        }

        if (isDragging)
        {
            // Fare hareketini kullanarak kamerayý döndürme
            Vector3 delta = Input.mousePosition - lastMousePosition;
            delta = new Vector3(delta.x, delta.y, 0) * 0.1f; // Hareket hýzýný ayarlýyoruz
            transform.RotateAround(obj1.position, Vector3.up, delta.x); // X ekseninde döndürme
            transform.RotateAround(obj1.position, transform.right, -delta.y); // Y ekseninde döndürme

            // Fareyi takip etmek için son pozisyonu güncelle
            lastMousePosition = Input.mousePosition;
        }

        // Kamerayý objelerin ortasýnda tutma (her zaman merkezde)
        Vector3 middlePosition = (obj1.position + obj2.position) / 2f;
        transform.position = middlePosition - transform.forward * cameraDistance;
        transform.LookAt(middlePosition);
    }
}
