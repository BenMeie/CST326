using UnityEngine;

public class Barricade : MonoBehaviour
{
    public int damage = 0;

    private SpriteRenderer SpriteRenderer;
    private Sprite[] sprites;
    
    private void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>("Textures/barrier");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        damage++;
        Destroy(col.gameObject);
        if (damage >= 5)
        {
            Destroy(gameObject);
        }
        else
        {
            SpriteRenderer.sprite = sprites[damage];
        }
    }
}
