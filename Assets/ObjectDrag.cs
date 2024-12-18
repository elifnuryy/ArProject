using UnityEngine;

public class ObjectDrag : MonoBehaviour
{
    private Vector3 offset; // Objeye bas�ld���nda offset de�erini saklamak i�in
    private Vector3 dragPosition; // Objeyi fareyle ta��d�ktan sonra kal�c� pozisyonu tutmak i�in

    void OnMouseDown()
    {
        // Objeye t�klama oldu�unda, offset de�eri hesaplan�r
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
    }

    void OnMouseDrag()
    {
        // Fareyi hareket ettirirken objeyi hareket ettir
        Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(newPosition) + offset;

        // X eksenindeki hareketi koru, Y ve Z eksenini sabit tut
        transform.position = new Vector3(worldPosition.x, transform.position.y, transform.position.z);

        // Objeyi hareket ettik�e, ge�ici pozisyonu kaydet
        dragPosition = transform.position;
    }

    void OnMouseUp()
    {
        // Fare b�rak�ld���nda, objenin yeni pozisyonu kal�c� olur
        // Eski pozisyona d�nmez, yeni pozisyonda kal�r
    }
}
