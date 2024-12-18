using UnityEngine;

public class HideHalfObject : MonoBehaviour
{
    public bool hideLeft; // Sol tarafý gizle
    private Renderer objRenderer;

    void Start()
    {
        objRenderer = GetComponent<Renderer>();

        // Eðer Renderer bileþeni yoksa, hata mesajý veririz
        if (objRenderer == null)
        {
            Debug.LogError("Renderer bileþeni bulunamadý!");
            return;
        }

        // Sol veya sað tarafý gizlemek için objeyi kes
        ClipObject();
    }

    void ClipObject()
    {
        // Objeyi sol veya sað yarý olarak gizlemek
        if (hideLeft)
        {
            objRenderer.material.SetFloat("_Clip", -1); // Sol tarafý gizle
        }
        else
        {
            objRenderer.material.SetFloat("_Clip", 1); // Sað tarafý gizle
        }
    }
}
