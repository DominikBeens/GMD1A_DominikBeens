using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Fade")]
    public Image fadeOverlay;

    [Header("Trigger")]
    public GameObject triggerPanel;
    public Text triggerPanelText;

    [Header("Load Bar")]
    public GameObject loadbarPanel;
    public Image loadbarFill;

    [Header("Dialogue")]
    public GameObject dialogueTextObject;
    public Text dialogueText;

    [Header("Conversation")]
    public GameObject phonePanel;
    public GameObject scrollView;
    public Text conversationText;
    public GameObject conversationButtons;
    public GameObject conversationButtonA;
    public GameObject conversationButtonB;
    public GameObject quitConversationButton;

    public Text optionAText;
    public Text optionBText;

    [Header("Player Stats")]
    public GameObject playerStatsPanel;
    public Image healthFill;
    public Image waterFill;
    public Image hungerFill;

    [Header("Death Menu")]
    public GameObject restartButton;
    public GameObject quitButton;
    public Text restartGameButtonText;
    public Text quitButtonText;
    public GameObject gameOverTextObject;
    public Text gameOverText;

    [Header("Quest")]
    public GameObject questDescPanel;
    public Image questDescPanelImage;
    public Text questDesc;

    [Header("Ingame Menu")]
    public GameObject resumeButton;
    public Text resumeButtonText;
    public GameObject quitGameButton;
    public Text quitGameButtonText;
    public GameObject gamePausedTextObject;
    public Text gamePausedText;

    [Header("Closet")]
    public GameObject closetInterface;
    public GameObject layoutGroup;
    public GameObject medkitButton;
    public GameObject waterbottleButton;

    [Header("Fishing")]
    public GameObject fishingLoadbarPanel;
    public Image fishingLoadbarFill;
    public GameObject caughtFishPanel;
    public Text caughtText;
    public Image caughtImage;

    [Header("Binoculars")]
    public GameObject binocularsOverlay;
}
