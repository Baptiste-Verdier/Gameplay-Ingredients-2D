using UnityEngine.SceneManagement;
using UnityEngine;

public class ObjectInterractions : MonoBehaviour
{
    private GameObject bridge;
    private GameObject lever;
    private GameObject endFlag;
    public Sprite fixedHandle;
    public Sprite turnedHandle;

    private bool handleFixed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W)  && handleFixed == false && PlayerInventory.Instance.IsInInventory("LEVERHANDLE") == true)
        { 
            FixingHandle();
            PlayerInventory.Instance.RemoveItemFromInventory("LEVERHANDLE");
        }
      else if (Input.GetKeyDown(KeyCode.W) && handleFixed == true)
        {
            LoweringBridge();
            lever.GetComponent<SpriteRenderer>().sprite = turnedHandle;
            InteractionUI.Instance.HideInteraction();
        }
    }

    private bool FixingHandle() 
    {
        lever = GameObject.Find("Switch Broken");
        lever.GetComponent<SpriteRenderer>().sprite = fixedHandle;
        return handleFixed = true;
    }

    private void LoweringBridge()
    {
             bridge = GameObject.Find("Bridge");
            bridge.GetComponent<Animator>().SetTrigger("Down");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
      if ( collision.CompareTag("Lever"))
        {
          
            if (PlayerInventory.Instance.IsInInventory("LEVERHANDLE") == true)
            {
                InteractionUI.Instance.ShowInteraction("Press Z to INTERACT");
            }
            else if (handleFixed == false) 
            {
                InteractionUI.Instance.ShowInteraction("This lever is BROKEN");
            }
        }
        if (collision.CompareTag("EndFlag"))
        {
            
            if (PlayerInventory.Instance.IsInInventory("REDGEM") == true)
            {
                int currentScene = PlayerLife.currentScene;
                SceneManager.LoadScene(currentScene) ;

            }
            else 
            {
                InteractionUI.Instance.ShowInteraction("I need the gem");
            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Lever") || collision.CompareTag("EndFlag"))
        {
            InteractionUI.Instance.HideInteraction();
        }
    }

}
