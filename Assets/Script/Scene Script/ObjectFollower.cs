using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    //public static ObjectFollower Instance { get; private set; }
    public Transform target;
    public Vector3 offset;
    //[Range(1, 10)]
    //public float smoothFactor;
    public Vector3 minVal, maxVal;

    //private void Awake()
    //{
    //    if (Instance == null)
    //    {
    //        Instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }
    //}
    private void FixedUpdate()
    {
        //transform.position = target.position + offset;
        Follow();
    }
    void Follow()
    {

        Vector3 targetPosition = target.position + offset;
        Vector3 boundPos = new Vector3(Mathf.Clamp(targetPosition.x, minVal.x, maxVal.x),
                                       Mathf.Clamp(targetPosition.y, minVal.y, maxVal.y),
                                       Mathf.Clamp(targetPosition.z, minVal.z, maxVal.z));
        //Vector3 smoothPosition = Vector3.Lerp(transform.position, boundPos, smoothFactor*Time.fixedDeltaTime);
        transform.position = boundPos;
    }
}
