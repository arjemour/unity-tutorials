using UnityEngine;

public class Pin : MonoBehaviour
{
    public float StandingThreshold = 5;
    public float DistanceToRaise = 40;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public bool IsStanding()
    {
        Vector3 rotation = transform.rotation.eulerAngles;
        float tiltInX = Mathf.Abs(rotation.x);
        float tiltInZ = Mathf.Abs(rotation.z);

        if (tiltInX < StandingThreshold && tiltInZ < StandingThreshold)
        {
            return true;
        }

        return false;
    }

    public void Raise()
    {
        if (IsStanding())
        {
            transform.Translate(new Vector3(0, DistanceToRaise, 0));
            GetComponent<Rigidbody>().useGravity = false;
            transform.rotation = Quaternion.Euler(Vector3.zero);
        }
                
    }

    public void Lower()
    {
        if (IsStanding())
        {
            transform.Translate(new Vector3(0, -DistanceToRaise, 0));
            GetComponent<Rigidbody>().useGravity = false;
        }
    }
}