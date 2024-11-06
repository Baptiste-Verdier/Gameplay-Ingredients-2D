using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionUI : MonoBehaviour
{
    public static InteractionUI Instance;
    TextMeshProUGUI interactionText;
    // Start is called before the first frame update
    void Awake()
    {
        interactionText = GetComponent<TextMeshProUGUI>();
        Instance = this;
    
    }

    public void ShowInteraction(string text)
    {
        interactionText.text = text;
        interactionText.gameObject.SetActive(true);
    }

    public void HideInteraction() 
    {
        interactionText.gameObject.SetActive(false);
    }
}
