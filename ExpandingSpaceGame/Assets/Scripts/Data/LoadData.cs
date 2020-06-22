using UnityEngine;

public class LoadData : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        StaticData.setup();
        Destroy(this.gameObject);
    }
}