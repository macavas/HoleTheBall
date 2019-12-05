
using UnityEngine;

public class Wall : MonoBehaviour
{
    public Animation wallAnim;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            wallAnim.Play();
        }
    }
}
