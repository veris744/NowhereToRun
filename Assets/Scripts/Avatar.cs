using UnityEngine;

public class Avatar : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = 
            UnityEngine.Quaternion.Euler(0, player.transform.localEulerAngles.y, 0);
        transform.position = player.transform.position;
    }
}
