using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class iEnemy : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        LimitByCamera();
        Animate();
    }

    public abstract void Move();
    public void LimitByCamera()
    {
        float height = GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize;
<<<<<<< HEAD
        Vector3 pos = transform.position;
        float max = height - transform.localScale.y / 2;
        if (pos.y > max)
            pos.y = max;
        else if (pos.y < -max)
            pos.y = -max;
        transform.position = pos;
=======
>>>>>>> 43b6eb4026b20e000cd7146ea8d0a90595e9a0db
    }
    public abstract void Animate();

    public void OnDestroy()
    {
        AnimateDeath();
        Debug.Log("Destroy");
    }

    public abstract void AnimateDeath();

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Kolizja "+gameObject.tag);
        if(collision.gameObject.tag == "Poo")
            Destroy(gameObject);
    }
}
