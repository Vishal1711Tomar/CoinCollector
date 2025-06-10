using UnityEngine;
using UnityEngine.UI;

public class BoxController : MonoBehaviour
{
    public Image hiddenImage;
    private Sprite coinSprite, explosionSprite;
    private bool isCoin;
    private bool isRevealed = false;

    public void Setup(Sprite coin, Sprite explosion, bool coinBox)
    {
        coinSprite = coin;
        explosionSprite = explosion;
        isCoin = coinBox;
        hiddenImage.sprite = isCoin ? coinSprite : explosionSprite;
        hiddenImage.gameObject.SetActive(false);

        Debug.Log("Sprite assigned to hiddenImage: " + hiddenImage.sprite?.name);
    }


    public void OnClick()
    {
        if (isRevealed) return;
        isRevealed = true;
        hiddenImage.gameObject.SetActive(true);

        GridManager.Instance.OnBoxClicked(isCoin);
    }

}
