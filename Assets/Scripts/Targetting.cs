using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class Targetting : MonoBehaviour
{
    public List<Transform> targets;
    private List<Transform>.Enumerator targetsEnumerator;
    public Transform selectedTarget;

    private Transform myTransform;

    // Use this for initialization
    public void Start ()
	{
	    targets = GameObject.FindGameObjectsWithTag("Enemy").Select(enemy => enemy.transform).ToList();
        targetsEnumerator = targets.GetEnumerator();
        selectedTarget = null;

        myTransform = transform;
	}

    private float DistanceTo(Transform t)
    {
        return Vector3.Distance(t.position, myTransform.position);
    }

    private void TargetEnemy()
    {
        if (selectedTarget == null)
        {
            targets.Sort((t1, t2) => DistanceTo(t1).CompareTo(DistanceTo(t2)));
            targetsEnumerator = targets.GetEnumerator();
        }

        if (!targetsEnumerator.MoveNext())
        {
            targetsEnumerator = targets.GetEnumerator();
            targetsEnumerator.MoveNext();
        }

         SelectTarget(targetsEnumerator.Current);
    }

    private void SelectTarget(Transform target)
    {
        selectedTarget = target;
        selectedTarget.GetComponent<Renderer>().material.color = Color.red;
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TargetEnemy();
        }
    }
}
