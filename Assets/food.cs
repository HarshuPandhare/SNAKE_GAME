using UnityEngine;

public class food : MonoBehaviour
{
    
    public BoxCollider2D _gridArea;
    private void Start()
    {
        Randomize_Position();
    }

    public void Randomize_Position()
    {
        Bounds bound = this._gridArea.bounds;
        float x  = Mathf.Round(Random.Range(bound.min.x, bound.max.x));
        float y = Mathf.Round(Random.Range(bound.min.y, bound.max.y));
        this.transform.position = new Vector3(x, y, 0.0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.tag == "Player")
        {
           
            Randomize_Position();
        }
    }
}
