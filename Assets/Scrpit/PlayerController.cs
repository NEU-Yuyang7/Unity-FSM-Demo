using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;


    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        Vector3 dir = new Vector3(h, 0f, v);

        if(dir.magnitude > 1f)
            dir = dir.normalized;

        transform.Translate(dir*moveSpeed*Time.deltaTime, Space.World);
    }
}
