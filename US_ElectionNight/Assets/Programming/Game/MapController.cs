using UnityEngine;
using System.Collections.Generic;

public class MapController : MonoBehaviour
{
    public Camera mainCamera;
    public float zoomedInSize = 3f;
    public float defaultCameraSize = 5f;
    public float zoomSpeed = 5f;
    public float moveSpeed = 5f;
    public Color dimColor = Color.gray;
    public Color highlightColor = Color.white;

    private GameObject selectedState;
    private Vector3 defaultCameraPosition;
    private Dictionary<GameObject, Color> originalColors = new Dictionary<GameObject, Color>();
    private bool isReturningToDefault = false;

    private void Start()
    {
        // Stelle sicher, dass die Kamera sofort in der Standardposition startet
        defaultCameraPosition = new Vector3(0, 0, -10); // Passe diese Werte ggf. an deine gewünschte Startposition an
        mainCamera.transform.position = defaultCameraPosition;
        mainCamera.orthographicSize = defaultCameraSize;

        // Ursprüngliche Farben der Staaten speichern
        foreach (Transform state in transform)
        {
            SpriteRenderer renderer = state.GetComponent<SpriteRenderer>();
            if (renderer != null)
            {
                originalColors[state.gameObject] = renderer.color;
            }
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isReturningToDefault)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            if (hit.collider != null && originalColors.ContainsKey(hit.collider.gameObject))
            {
                // Ein neuer Staat wird ausgewählt, auch wenn bereits ein anderer Staat ausgewählt ist
                SelectState(hit.collider.gameObject);
            }
            else if (hit.collider == null && selectedState != null)
            {
                // Klick auf eine freie Fläche
                DeselectState();
            }
        }

        // Kamera sanft zur Zielposition bewegen
        if (selectedState != null)
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, new Vector3(selectedState.transform.position.x, selectedState.transform.position.y, mainCamera.transform.position.z), Time.deltaTime * moveSpeed);
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, zoomedInSize, Time.deltaTime * zoomSpeed);
        }
        else if (isReturningToDefault)
        {
            // Kamera zur Standardposition zurückkehren
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, defaultCameraPosition, Time.deltaTime * moveSpeed);
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, defaultCameraSize, Time.deltaTime * zoomSpeed);

            // Wenn die Kamera die Standardposition erreicht hat, schalte die Steuerung wieder frei
            if (Vector3.Distance(mainCamera.transform.position, defaultCameraPosition) < 0.1f && Mathf.Abs(mainCamera.orthographicSize - defaultCameraSize) < 0.1f)
            {
                isReturningToDefault = false;
            }
        }
    }

    private void SelectState(GameObject state)
    {
        // Setze den neuen ausgewählten Staat
        selectedState = state;
        isReturningToDefault = false; // Wir sind im Auswahlmodus, daher die Rückkehr zur Standardposition beenden

        // Alle anderen Staaten abdunkeln
        foreach (Transform otherState in transform)
        {
            SpriteRenderer renderer = otherState.GetComponent<SpriteRenderer>();
            if (renderer != null)
            {
                renderer.color = (otherState.gameObject == selectedState) ? highlightColor : dimColor;
            }
        }
    }

    private void DeselectState()
    {
        selectedState = null;
        isReturningToDefault = true; // Kamera zurück in die Default-Position bringen

        // Alle Staaten auf ihre Originalfarben zurücksetzen
        foreach (Transform state in transform)
        {
            SpriteRenderer renderer = state.GetComponent<SpriteRenderer>();
            if (renderer != null && originalColors.ContainsKey(state.gameObject))
            {
                renderer.color = originalColors[state.gameObject];
            }
        }
    }
}
