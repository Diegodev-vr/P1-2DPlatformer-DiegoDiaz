using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    ///// render mode i choose is screen space overlay, so the canvas will be rendered on top of everything else in the scene
    ///// reference to the main menu panel and settings panel
     [SerializeField] private GameObject MenuPanel;
    [SerializeField] private GameObject MainMenuButtons;
    [SerializeField] private GameObject MainMenuAnimation;
    [SerializeField] private GameObject MainMenuTittle;
    [SerializeField] private GameObject ControlsPanel;
    [SerializeField] private GameObject HudPanel;
    [SerializeField] private GameObject Player;

    void Awake() 
    {
        ///// make sure the settings panel is hidden and the main menu panel is shown at the start of the game
        //// also add error handling in case the references are not set in the inspector
        if (ControlsPanel != null)
        {
            ControlsPanel.SetActive(false);
        } else
        {
            Debug.LogError("ControlsPanel reference is not set in the inspector.");
        }

         if (MainMenuButtons != null)
        {
            MainMenuButtons.SetActive(false);
        } else
        {
            Debug.LogError("MainMenuButtons reference is not set in the inspector.");
        }
    }

    ///// these functions will be called by the buttons in the UI, so they need to be public
    public void onStartClicked()
    {    
        ///// load the first level of the game, make sure to add the level to the build settings
        /////UnityEngine.SceneManagement.SceneManager.LoadScene("LEVEL_01");    
    
        ///// hide the main menu panel and show the player and the HUD panel 
        MenuPanel.SetActive(false);
        HudPanel.SetActive(true);
        MainMenuButtons.SetActive(false);
        Player.SetActive(true);
    }
    public void onControlsClicked()
    {
        ///// toggle the active state of the settings panel and main menu panel
        bool isControlsActive = ControlsPanel.activeSelf;
        ControlsPanel.SetActive(!isControlsActive);

        bool isMainMenuActive = MainMenuButtons.activeSelf;
        MainMenuButtons.SetActive(!isMainMenuActive);

        bool isAnimationsActive = MainMenuAnimation.activeSelf;
        MainMenuAnimation.SetActive(!isAnimationsActive);

        bool isTittleActive = MainMenuTittle.activeSelf;
        MainMenuTittle.SetActive(!isTittleActive);
    }
    public void onExitClicked()
    {
        ///// quit the application, this will not work in the editor but will work in a built version of the game
        Application.Quit();
    }
}