using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public int moveSpeed;
    public int rotationSpeed;
    public int maxDistance;

    private Transform myTransform;

    public void Awake()
    {
        myTransform = transform;
    }

    // Use this for initialization
    public void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        target = go.transform;
        maxDistance = 2;
    }

    // Update is called once per frame
    public void Update()
    {
        Debug.DrawLine(target.position, myTransform.position, Color.yellow);

        AdjustTransform();
    }

    private void AdjustTransform()
    {
        myTransform.rotation = ComputeRotation(myTransform, target, rotationSpeed * Time.deltaTime);

        if (Vector3.Distance(target.position, myTransform.position) > maxDistance)
        {
            myTransform.position = ComputePosition(myTransform, moveSpeed*Time.deltaTime);
        }
    }

    private static Quaternion ComputeRotation(Transform ownTransform, Transform targetTransform, float speed)
    {
        var targetRotation = Quaternion.LookRotation(targetTransform.position - ownTransform.position);
        return Quaternion.Slerp(ownTransform.rotation, targetRotation, speed);
    }

    private static Vector3 ComputePosition(Transform ownTransform, float speed)
    {
        return ownTransform.position + ownTransform.forward * speed;
    }
}
