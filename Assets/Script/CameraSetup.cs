using UnityEngine;

public class CameraSetup : MonoBehaviour
{
    public Transform obj1; // �lk obje
    public Transform obj2; // �kinci obje
    public float cameraDistance = 10f; // Kameran�n objelerden uzakl���
    public Vector3 cameraRotation = new Vector3(30f, 0f, 0f); // Kameran�n ba�lang��taki d�ng� a��s�

    private Vector3 offset;  // Kameran�n ba�lang��taki pozisyonunu tutmak i�in
    private bool isDragging = false; // Kameray� s�r�klerken kontrol
    private Vector3 lastMousePosition;

    void Start()
    {
        // Kameray� objelerin ortas�nda konumland�r
        Vector3 middlePosition = (obj1.position + obj2.position) / 2f;

        // Kameray� objelerin biraz gerisinde yerle�tir (cameraDistance ile uzakl�k ayarlan�r)
        transform.position = middlePosition - transform.forward * cameraDistance;

        // Kameray� belirli bir a��yla d�nd�r
        transform.rotation = Quaternion.Euler(cameraRotation);

        // Kameran�n objelere bakmas�n� sa�la
        transform.LookAt(middlePosition);
    }

    void Update()
    {
        // Fare sa� t�kland���nda kameray� hareket ettirme i�lemi
        if (Input.GetMouseButtonDown(1)) // Sa� t�klama ile hareketi ba�lat
        {
            isDragging = true;
            lastMousePosition = Input.mousePosition; // Fare t�klama konumunu kaydet
        }

        if (Input.GetMouseButtonUp(1)) // Sa� t�klama b�rak�ld���nda hareketi durdur
        {
            isDragging = false;
        }

        if (isDragging)
        {
            // Fare hareketini kullanarak kameray� d�nd�rme
            Vector3 delta = Input.mousePosition - lastMousePosition;
            delta = new Vector3(delta.x, delta.y, 0) * 0.1f; // Hareket h�z�n� ayarl�yoruz
            transform.RotateAround(obj1.position, Vector3.up, delta.x); // X ekseninde d�nd�rme
            transform.RotateAround(obj1.position, transform.right, -delta.y); // Y ekseninde d�nd�rme

            // Fareyi takip etmek i�in son pozisyonu g�ncelle
            lastMousePosition = Input.mousePosition;
        }

        // Kameray� objelerin ortas�nda tutma (her zaman merkezde)
        Vector3 middlePosition = (obj1.position + obj2.position) / 2f;
        transform.position = middlePosition - transform.forward * cameraDistance;
        transform.LookAt(middlePosition);
    }
}
