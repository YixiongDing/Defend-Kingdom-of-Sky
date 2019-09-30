using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove : MonoBehaviour
{
    Vector3 velocity = Vector3.zero;//velocity
    public float speed = 5;
    //public Vector3 moveSpeed;
    //public float radius;
    Vector3 target;
    //GameObject centerSpider = GameObject.Find("spider_01");
    //float distance = 1f;
    //float dx;
    //float dz;
    // Start is called before the first frame update
    void Start()
    {
        //dx = centerSpider.transform.position.x - transform.position.x;
        //dz = centerSpider.transform.position.z - transform.position.z;
        //distance = Mathf.Sqrt(dx * dx + dz * dz);
    }

    // Update is called once per frame
    
    private void Update()
    {
        //dx = centerSpider.transform.position.x - transform.position.x;
        //dz = centerSpider.transform.position.z - transform.position.z;
        //distance = Mathf.Sqrt(dx * dx + dz * dz);

        if (Random.value < 0.01f)
            target = transform.position + Quaternion.Euler(0, Random.value * 360, 0) * Vector3.right * 10;//random target
        //else if (distance > 1f)
        //    target = centerSpider.transform.position;
        Vector3 direct = target - transform.position;
        direct.y = 0;//cant rotate to y axis
        if (direct.sqrMagnitude > 1)
        {
            transform.rotation = Quaternion.LookRotation(direct);
            velocity = direct.normalized * speed / 3;
        }



        velocity -= GetComponent<Rigidbody>().velocity;
        velocity.y = 0;

        //
        if (velocity.sqrMagnitude > speed * speed)
            velocity = velocity.normalized * speed;

        GetComponent<Rigidbody>().AddForce(velocity, ForceMode.VelocityChange);
        velocity = Vector3.zero;

        //RaycastHit2D rf = Physics2D.Raycast(transform.position, velocity, velocity.magnitude * Time.deltaTime + radius, LayerMask.GetMask("Ground"));
        //if (rf)
        //{

        //    transform.position = new Vector3(rf.point.x, rf.point.y, transform.position.z) - radius * moveSpeed.normalized;
        //    velocity = Vector3.zero;
        //}
        //else
        //{
        //    transform.position += velocity * Time.deltaTime;
        //}
    }
}
