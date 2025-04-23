using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [TextArea] public string popUpText;
    public Sprite popUpImage;
    public string popUpManagerObjectName = "PopUpChanger";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PopUpManager manager = GameObject.Find(popUpManagerObjectName)?.GetComponent<PopUpManager>();
            if (manager != null)
            {
                manager.ChangePopUp(popUpText, popUpImage);
            }
            else
            {
                Debug.LogWarning("PopUpManager not found in scene!");
            }
        }
    }
}
