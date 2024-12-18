using UnityEngine;
using UnityEngine.UI; // UI elemanlarý için

public class GameController : MonoBehaviour
{
    public GameObject obj1; // Birinci obje
    public GameObject obj2; // Ýkinci obje
    public Text gameStatusText; // Oyun durumunu gösterecek metin
    public float thresholdDistance = 0.7f; // Objelerin birbirine yaklaþmasý için mesafe eþiði

    void Start()
    {
        // Baþlangýçta oyun tamamlandý yazýsýný boþ yap
        gameStatusText.text = "";
    }

    void Update()
    {
        // Objeler yan yana gelirse
        if (Vector3.Distance(obj1.transform.position, obj2.transform.position) < thresholdDistance)
        {
            gameStatusText.text = "Oyun Tamamlandý!"; // Oyun tamamlandý yazýsýný göster

            // Objelerin hareket etmesini engellemek
            obj1.GetComponent<ObjectDrag>().enabled = false;
            obj2.GetComponent<ObjectDrag>().enabled = false;

            // Ekrana týklandýðýnda oyunu yeniden baþlat
            if (Input.GetMouseButtonDown(0))
            {
                RestartGame();
            }
        }
    }

    void RestartGame()
    {
        // Objeleri baþlatma pozisyonlarýna geri koy
        obj1.transform.position = new Vector3(-2, 0, 0);
        obj2.transform.position = new Vector3(2, 0, 0);

        // Oyun durumunu sýfýrla
        gameStatusText.text = ""; // Oyun tekrar baþlatýldýðýnda yazýyý temizle
        obj1.GetComponent<ObjectDrag>().enabled = true;
        obj2.GetComponent<ObjectDrag>().enabled = true;
    }
}
