using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Targetting : MonoBehaviour
{
    public List<Transform> targets;
    public Transform selectedTarget;

    // Use this for initialization
    public void Start ()
	{
	    targets = GameObject.FindGameObjectsWithTag("Enemy").Select(enemy => enemy.transform).ToList();
        selectedTarget = null;

	}

    private void TargetEnemy()
    {
        selectedTarget = targets.First();
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
