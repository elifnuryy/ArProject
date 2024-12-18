using UnityEngine;

public class HideHalfObject : MonoBehaviour
{
    public bool hideLeft; // Sol taraf� gizle
    private Renderer objRenderer;

    void Start()
    {
        objRenderer = GetComponent<Renderer>();

        // E�er Renderer bile�eni yoksa, hata mesaj� veririz
        if (objRenderer == null)
        {
            Debug.LogError("Renderer bile�eni bulunamad�!");
            return;
        }

        // Sol veya sa� taraf� gizlemek i�in objeyi kes
        ClipObject();
    }

    void ClipObject()
    {
        // Objeyi sol veya sa� yar� olarak gizlemek
        if (hideLeft)
        {
            objRenderer.material.SetFloat("_Clip", -1); // Sol taraf� gizle
        }
        else
        {
            objRenderer.material.SetFloat("_Clip", 1); // Sa� taraf� gizle
        }
    }
}
