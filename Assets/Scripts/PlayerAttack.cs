using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject target;
    
    // Use this for initialization
    public void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            Attack();
        }
    }

    private void Attack()
    {
        var distance = Vector3.Distance(target.transform.position, transform.position);

        Debug.Log(distance);
        if (distance < 2.5f)
        {
            target.GetComponent<EnemyHealth>().AdjustCurrentHealth(-10);
        }
    }
}
