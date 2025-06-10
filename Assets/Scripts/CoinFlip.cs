using UnityEngine;

public class CoinFlip : MonoBehaviour
{
    public Sprite coinFront;
    public Sprite coinBack;
    public Sprite coinSide;

    private SpriteRenderer spriteRenderer;
    private bool isFront = true;

    public float flipSpeed = 0.5f; 
    private float timer;

    private bool isFlipping = false;
    public float sideDisplayTime = 0.1f; 

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = coinFront;
    }

    void Update()
    {
        if (isFlipping) return;

        timer += Time.deltaTime;
        if (timer >= flipSpeed)
        {
            StartCoroutine(FlipAnimation());
            timer = 0f;
        }
    }

    System.Collections.IEnumerator FlipAnimation()
    {
        isFlipping = true;
        spriteRenderer.sprite = coinSide;
        yield return new WaitForSeconds(sideDisplayTime);
        isFront = !isFront;
        spriteRenderer.sprite = isFront ? coinFront : coinBack;

        isFlipping = false;
    }
}
