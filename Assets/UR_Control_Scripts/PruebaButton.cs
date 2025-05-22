using System.Text;
// -------------------- Unity -------------------- //
using UnityEngine.EventSystems;
using UnityEngine;

using TMPro;

public class PruebaButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    // -------------------- UTF8Encoding -------------------- //
    private UTF8Encoding utf8 = new UTF8Encoding();

    public TextMeshPro BanderaRandom;

    // -------------------- Button -> Pressed -------------------- //
    public void OnPointerDown(PointerEventData eventData)
    {
        BanderaRandom.color = new Color32(135, 255, 0, 50);
    }

    // -------------------- Button -> Un-Pressed -------------------- //
    public void OnPointerUp(PointerEventData eventData)
    {
        BanderaRandom.color = new Color32(255, 0, 48, 50);
    }
}
