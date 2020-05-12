using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [SerializeField]
    private Transform normaleTrans;

    public Transform playerTransform;

    private Vector3 _cameraOffset;

    [Range(0.01f, 1.0f)]
    public float smoothFactor = 0.5f;

    // Start is called before the first frame update
    private void Start()
    {
        normaleTrans = this.transform;
        _cameraOffset = transform.position - playerTransform.position;
    }

    // LateUpdate is called after update methods
    private void Update()
    {
        Vector3 newPos = playerTransform.position + _cameraOffset;
        newPos.z = this.normaleTrans.position.z;
        newPos.y = this.normaleTrans.position.y;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);
    }
}