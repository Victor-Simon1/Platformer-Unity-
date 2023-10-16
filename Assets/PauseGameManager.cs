using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PauseGameManager : MonoBehaviour
{
    public PauseGameManager instance;

    public GameObject pauseUI;
    private bool isPause;
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Plusieur PauseManager");
            return;
        }
        instance = this;
        isPause = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PauseGame(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            if(isPause)
            {
                pauseUI.SetActive(false);
                Time.timeScale = 1f;
                isPause = false;
            }   
            else
            {
                pauseUI.SetActive(true);
                Time.timeScale = 0f;
                isPause = true;
            }
            
        }
    }
    
}