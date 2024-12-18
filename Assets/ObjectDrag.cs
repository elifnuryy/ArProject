using UnityEngine;

public class ObjectDrag : MonoBehaviour
{
    private Vector3 offset; // Objeye basýldýðýnda offset deðerini saklamak için
    private Vector3 dragPosition; // Objeyi fareyle taþýdýktan sonra kalýcý pozisyonu tutmak için

    void OnMouseDown()
    {
        // Objeye týklama olduðunda, offset deðeri hesaplanýr
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
    }

    void OnMouseDrag()
    {
        // Fareyi hareket ettirirken objeyi hareket ettir
        Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(newPosition) + offset;

        // X eksenindeki hareketi koru, Y ve Z eksenini sabit tut
        transform.position = new Vector3(worldPosition.x, transform.position.y, transform.position.z);

        // Objeyi hareket ettikçe, geçici pozisyonu kaydet
        dragPosition = transform.position;
    }

    void OnMouseUp()
    {
        // Fare býrakýldýðýnda, objenin yeni pozisyonu kalýcý olur
        // Eski pozisyona dönmez, yeni pozisyonda kalýr
    }
}
