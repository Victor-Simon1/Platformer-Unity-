using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogTrigger : MonoBehaviour
{

    public Dialog dialog;
    private bool isInRange;

    private TextMeshProUGUI interactUI;

    private void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<TextMeshProUGUI>();
    }
    // Update is called once per frame
    void Update()
    {
        if(isInRange && PlayerController.instance.input.Player.TalkToVillager.IsPressed())
            TriggerDialog();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            isInRange = true;
            interactUI.enabled = true; 
        }

    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            isInRange = false;
            interactUI.enabled = false; 
        }
    }

    void TriggerDialog()
    {
        interactUI.enabled = false;
        DialogManager.instance.StartDialog(dialog);
    }
}
