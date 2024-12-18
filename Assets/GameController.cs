using UnityEngine;
using UnityEngine.UI; // UI elemanlar� i�in

public class GameController : MonoBehaviour
{
    public GameObject obj1; // Birinci obje
    public GameObject obj2; // �kinci obje
    public Text gameStatusText; // Oyun durumunu g�sterecek metin
    public float thresholdDistance = 0.7f; // Objelerin birbirine yakla�mas� i�in mesafe e�i�i

    void Start()
    {
        // Ba�lang��ta oyun tamamland� yaz�s�n� bo� yap
        gameStatusText.text = "";
    }

    void Update()
    {
        // Objeler yan yana gelirse
        if (Vector3.Distance(obj1.transform.position, obj2.transform.position) < thresholdDistance)
        {
            gameStatusText.text = "Oyun Tamamland�!"; // Oyun tamamland� yaz�s�n� g�ster

            // Objelerin hareket etmesini engellemek
            obj1.GetComponent<ObjectDrag>().enabled = false;
            obj2.GetComponent<ObjectDrag>().enabled = false;

            // Ekrana t�kland���nda oyunu yeniden ba�lat
            if (Input.GetMouseButtonDown(0))
            {
                RestartGame();
            }
        }
    }

    void RestartGame()
    {
        // Objeleri ba�latma pozisyonlar�na geri koy
        obj1.transform.position = new Vector3(-2, 0, 0);
        obj2.transform.position = new Vector3(2, 0, 0);

        // Oyun durumunu s�f�rla
        gameStatusText.text = ""; // Oyun tekrar ba�lat�ld���nda yaz�y� temizle
        obj1.GetComponent<ObjectDrag>().enabled = true;
        obj2.GetComponent<ObjectDrag>().enabled = true;
    }
}
