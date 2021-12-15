using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDController : MonoBehaviour
{
    [Header("HUD")]
    public TextMeshProUGUI coinText;
    public List<Image> healthImages;
    public List<Image> keyImages;

    public Sprite collectedKeyImage;
    public Sprite emptyLifeImage;


    [Header("End Door")]
    public GameObject door;
    public Sprite lockedDoor;
    public Sprite unlockedDoor;

    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }


    void UpdateUI()
    {
        coinText.text = player.GetCoins().ToString();

        int keyIndex = player.GetKey();
        int lifeIndex = player.GetLives();

        Debug.Log("Key index" + keyIndex);
        Debug.Log("Key index" + lifeIndex);

        if (keyIndex <= keyImages.Count)
        {
            keyImages[keyIndex].sprite = collectedKeyImage;
        }

        if (lifeIndex <= healthImages.Count)
        {
            healthImages[lifeIndex].sprite = emptyLifeImage;
        }
    }
}
