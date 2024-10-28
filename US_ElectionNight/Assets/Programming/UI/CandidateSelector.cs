using UnityEngine;
using UnityEngine.EventSystems;

public class CandidateSelector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public float hoverScaleFactor = 1.1f;
    public float selectedScaleFactor = 1.2f;
    public float wobbleIntensity = 5f;
    public float wobbleSpeed = 2f;

    private Vector3 originalScale;
    private Quaternion originalRotation;
    private static CandidateSelector selectedCandidate;
    private bool isSelected = false;

    private SinglePlayChooseCandidateButtonManager buttonManager;
    private GameManager gameManager;

    private void Start()
    {
        originalScale = transform.localScale;
        originalRotation = transform.rotation;

        // Referenzen auf ButtonManager und GameManager
        buttonManager = FindObjectOfType<SinglePlayChooseCandidateButtonManager>();
        gameManager = GameManager.Instance;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isSelected)
        {
            transform.localScale = originalScale * hoverScaleFactor;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isSelected)
        {
            transform.localScale = originalScale;
            transform.rotation = originalRotation;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (selectedCandidate != null && selectedCandidate != this)
        {
            selectedCandidate.Deselect();
        }

        isSelected = true;
        transform.localScale = originalScale * selectedScaleFactor;
        selectedCandidate = this;

        // Aktiviere den Next-Button und speichere die Kandidatenauswahl
        buttonManager.SetNextButtonActive(true);
        gameManager.SetSelectedCandidate(gameObject.name); // Kandidatenname an GameManager übergeben
    }

    // Deselect-Methode zum Zurücksetzen der Größe und Rotation
    public void Deselect()
    {
        isSelected = false;
        transform.localScale = originalScale;
        transform.rotation = originalRotation;
    }

    private void Update()
    {
        // Falls ausgewählt, führe Wabbel-Effekt aus
        if (isSelected)
        {
            float wobbleAngle = Mathf.Sin(Time.time * wobbleSpeed) * wobbleIntensity;
            transform.rotation = Quaternion.Euler(0, 0, wobbleAngle);
        }
    }
}
