using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public float moveSpeed = 5f; // Geschwindigkeit der Kamerabewegung
    public float edgeSize = 10f; // Abstand in Pixeln, ab dem die Maus am Bildschirmrand die Kamera bewegt

    // Begrenzungen für die Kamera
    public float minX = -10f;
    public float maxX = 10f;
    public float minY = -5f;
    public float maxY = 5f;

    private void Update()
    {
        Vector3 cameraPosition = transform.position;

        if (Input.mousePosition.x <= edgeSize && cameraPosition.x > minX)
        {
            cameraPosition.x -= moveSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.x >= Screen.width - edgeSize && cameraPosition.x < maxX)
        {
            cameraPosition.x += moveSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.y <= edgeSize && cameraPosition.y > minY)
        {
            cameraPosition.y -= moveSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.y >= Screen.height - edgeSize && cameraPosition.y < maxY)
        {
            cameraPosition.y += moveSpeed * Time.deltaTime;
        }

        transform.position = cameraPosition;
    }

    // Gizmo für den Bereich der Kamera anzeigen
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green; // Farbe des Gizmos
        Vector3 topLeft = new Vector3(minX, maxY, transform.position.z);
        Vector3 topRight = new Vector3(maxX, maxY, transform.position.z);
        Vector3 bottomLeft = new Vector3(minX, minY, transform.position.z);
        Vector3 bottomRight = new Vector3(maxX, minY, transform.position.z);

        // Zeichne Rechteck um den Bereich
        Gizmos.DrawLine(topLeft, topRight);
        Gizmos.DrawLine(topRight, bottomRight);
        Gizmos.DrawLine(bottomRight, bottomLeft);
        Gizmos.DrawLine(bottomLeft, topLeft);
    }
}
