using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class ModalPanel : MonoBehaviour
{

    public Text question;
    public Image iconImage;
    public Button yesButton;
    public Button noButton;
    public Button cancelButton;
    public GameObject modalPanelObject;

    private static ModalPanel modalPanel;

    public static ModalPanel Instance()
    {
        if (!modalPanel)
        {
            modalPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
            if (!modalPanel)
                Debug.LogError("There needs to be one active ModalPanel script on a GameObject in your scene.");
        }

        return modalPanel;
    }

    // Yes/No/Cancel: A string, a Yes event, a No event and Cancel event
    public void Choice(string question, UnityAction yesEvent, UnityAction noEvent, UnityAction cancelEvent)
    {
        modalPanelObject.SetActive(true);

        yesButton.onClick.RemoveAllListeners();
        yesButton.onClick.AddListener(yesEvent);
        yesButton.onClick.AddListener(ClosePanel);

        noButton.onClick.RemoveAllListeners();
        noButton.onClick.AddListener(noEvent);
        noButton.onClick.AddListener(ClosePanel);

        cancelButton.onClick.RemoveAllListeners();
        cancelButton.onClick.AddListener(cancelEvent);
        cancelButton.onClick.AddListener(ClosePanel);

        this.question.text = question;

        this.iconImage.gameObject.SetActive(false);
        yesButton.gameObject.SetActive(true);
        noButton.gameObject.SetActive(true);
        cancelButton.gameObject.SetActive(true);
    }

    public void ChoiceImage()
    {

    }

    void ClosePanel()
    {
        modalPanelObject.SetActive(false);
    }
}

/*
 TEST MODAL PANEL
    using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

//  This script will be updated in Part 2 of this 2 part series.
public class TestModalWindow : MonoBehaviour {
    private ModalPanel modalPanel;
    private DisplayManager displayManager;

    private UnityAction myYesAction;
    private UnityAction myNoAction;
    private UnityAction myCancelAction;

    void Awake () {
        modalPanel = ModalPanel.Instance ();
        displayManager = DisplayManager.Instance ();

        myYesAction = new UnityAction (TestYesFunction);
        myNoAction = new UnityAction (TestNoFunction);
        myCancelAction = new UnityAction (TestCancelFunction);
    }

    //  Send to the Modal Panel to set up the Buttons and Functions to call
    public void TestYNC () {
        modalPanel.Choice ("Do you want to spawn this sphere?", TestYesFunction, TestNoFunction, TestCancelFunction);
//      modalPanel.Choice ("Would you like a poke in the eye?\nHow about with a sharp stick?", myYesAction, myNoAction, myCancelAction);
    }

    //  These are wrapped into UnityActions
    void TestYesFunction () {
        displayManager.DisplayMessage ("Heck yeah! Yup!");
    }

    void TestNoFunction () {
        displayManager.DisplayMessage ("No way, José!");
    }

    void TestCancelFunction () {
        displayManager.DisplayMessage ("I give up!");
    }
} 

     */
