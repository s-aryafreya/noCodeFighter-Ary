using UnityEngine;

public class Enemy : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        //transform.Translate - movement without physics direction, time, speed
        //all floats need f by it if its the number
        transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * 3f);

        //when the bullet is high enough, destroy it
        //if statementes check things - if are true, the code in the block works, if false, the code in the block is ignored
        if (transform.position.y < -6.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
