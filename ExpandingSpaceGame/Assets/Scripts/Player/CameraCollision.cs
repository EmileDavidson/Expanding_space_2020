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

    [Range(0.1f, 1)]
    public float smoothFactor = 0.5f;

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
        //desiredCameraPos is de position die de camera moet aanhouden wanneer mogelijk
        Vector3 desiredCameraPos = transform.parent.TransformPoint(dollyDir * maxDistance);
        RaycastHit hit;
        //wanneer we iets anders raken moeten we de position van de camera naar vorenschuiven zodat we niet door het object heen gaan
        if (Physics.Linecast(transform.parent.position, desiredCameraPos, out hit))
        {
            //mocht het geraakte item een meshrenderen hebben (dus dat er ook echt wat word laten zien) dan kan hij door zo niet hoeven we ook
            //de camera niet aantepassen want hij gaat niet door een "object die je kan zien" heen
            if (hit.transform.gameObject.GetComponent<MeshRenderer>())
            {
                distance = Mathf.Clamp(hit.distance * 0.8f, minDistance, maxDistance);
                {
                    transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDir * distance, Time.deltaTime * smooth);
                }
            }
            else
            {
                //zet de camera terug naar zijn maxdistance en smooth dat uit
                distance = maxDistance;
                transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDir * distance, Time.deltaTime * smooth);
            }
        }
        else
        {
            //zet de camera terug naar zijn maxdistance en smooth dat uit
            distance = maxDistance;
            transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDir * distance, Time.deltaTime * smooth);
        }

    }
}