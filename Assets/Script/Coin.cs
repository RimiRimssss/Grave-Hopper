using UnityEngine;

public class Coin : MonoBehaviour
{
    public int score;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(false);
            GameManager.instance.AddScore(score);
        }
    }
}