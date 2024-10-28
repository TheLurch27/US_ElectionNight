using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonScaler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalScale;
    public float hoverScaleFactor = 1.1f;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse entered the button");
        transform.localScale = originalScale * hoverScaleFactor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse exited the button");
        transform.localScale = originalScale;
    }
}
