using UnityEngine;
using UnityEngine.UI;
using TMPro;  // <-- IMPORTANT

public class PopUpManager : MonoBehaviour
{
    public TMP_Text popupTextUI;     // Reference your TMP text in the Inspector
    public Image popupImageUI;       // Same for the image

    public void ChangePopUp(string newText, Sprite newImage)
    {
        popupTextUI.text = newText;
        popupImageUI.sprite = newImage;
    }
}
