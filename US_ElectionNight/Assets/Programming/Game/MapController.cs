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
        // Setze die Startposition und -größe direkt in der Kamera
        defaultCameraPosition = new Vector3(0, 0, -10); // Passe dies an die gewünschte Standardansicht an
        defaultCameraSize = 5f; // Setze diesen Wert auf die gewünschte Zoomgröße

        mainCamera.transform.position = defaultCameraPosition;
        mainCamera.orthographicSize = defaultCameraSize;

        // Alle Staaten speichern und die ursprüngliche Farbe festhalten
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
                SelectState(hit.collider.gameObject);
            }
            else if (hit.collider == null && selectedState != null)
            {
                DeselectState();
            }
        }

        if (selectedState != null)
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, new Vector3(selectedState.transform.position.x, selectedState.transform.position.y, mainCamera.transform.position.z), Time.deltaTime * moveSpeed);
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, zoomedInSize, Time.deltaTime * zoomSpeed);
        }
        else if (isReturningToDefault)
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, defaultCameraPosition, Time.deltaTime * moveSpeed);
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, defaultCameraSize, Time.deltaTime * zoomSpeed);

            if (Vector3.Distance(mainCamera.transform.position, defaultCameraPosition) < 0.1f && Mathf.Abs(mainCamera.orthographicSize - defaultCameraSize) < 0.1f)
            {
                isReturningToDefault = false;
            }
        }
    }

    private void SelectState(GameObject state)
    {
        selectedState = state;
        isReturningToDefault = false;

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
        isReturningToDefault = true;

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
