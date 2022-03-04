using UnityEngine;

public class Avatar : MonoBehaviour
{
    public GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = UnityEngine.Quaternion.Euler(0, camera.transform.localEulerAngles.y, 0);
        transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y - 7, camera.transform.position.z - 0.31f);
    }
}
