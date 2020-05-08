using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    public float minDistance = 1.0f;
    public float maxDistance = 4.0f;
    public float smooth = 10.0f;
    public Vector3 dollyDir;
    public Vector3 dollyDirAdjusted;
    public float distance;
    public float transparantieDistance = 2f;

    public GameObject character;

    // Start is called before the first frame update
    private void Start()
    {
        dollyDir = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 desiredCameraPos = transform.parent.TransformPoint(dollyDir * maxDistance);
        RaycastHit hit;
        if (Physics.Linecast(transform.parent.position, desiredCameraPos, out hit))
        {
            distance = Mathf.Clamp(hit.distance * 0.9f, minDistance, maxDistance);
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDir * distance, Time.deltaTime * smooth);
            }
        }
        else
        {
            distance = maxDistance;
            transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDir * distance, Time.deltaTime * smooth);
        }

        /*
         kijk naar de distance van de wanneer de distance te erg word hide ik de speler zodat
         je niet alleen de achterkant van de speler ziet maar dus door de speler heen kan kijken
         */
        if (distance <= transparantieDistance)
        {
            character.SetActive(false);
        }
        else
        {
            character.SetActive(true);
        }
    }
}