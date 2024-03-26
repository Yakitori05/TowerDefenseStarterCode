using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HighScoreMenu : MonoBehaviour
{
    public Label[] highScoreLabels; // Declare as an array of UnityEngine.UIElements.Label
    private UnityEngine.UIElements.Button StartNewGame;
    private VisualElement root;

    // Start is called before the first frame update
    void Start()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        // Query for individual labels
        highScoreLabels = new Label[5];
        for (int i = 0; i < highScoreLabels.Length; i++)
        {
            highScoreLabels[i] = root.Query<Label>($"highScoreTexts{i}").First();
            if (highScoreLabels[i] == null)
            {
                Debug.LogError($"Label highScoreTexts{i} not found!");
            }
        }

        StartNewGame = root.Query<UnityEngine.UIElements.Button>("StartNewGame").First();
        if (StartNewGame != null)
        {
            StartNewGame.clicked += StartNewGamee;
        }
        else
        {
            Debug.LogError("StartNewGame button not found!");
        }

        // In de Start-methode van HighScoreMenu of wanneer je de UI wilt bijwerken met de nieuwste high scores
        UpdateHighScoreUI(HighScoreManager.Instance.GetHighScores());
    }


    // Function to update UI with current high scores
    public void UpdateHighScoreUI(List<HighScore> highScores)
    {
        // Loop door de highScores-lijst
        for (int i = 0; i < highScoreLabels.Length; i++)
        {
            Debug.Log("UpdateHighScoreUI");
            // Controleer of het huidige index binnen het bereik van highScores ligt
            if (i < highScores.Count)
            {
                Debug.Log("5555UpdateHighScoreUI");
                // Weergeef de naam en de score van de speler in de Label
                highScoreLabels[i].text = $"{highScores[i].PlayerName}: {highScores[i].Score} Credits";
            }
            else
            {
                Debug.Log("888855UpdateHighScoreUI");

                // Leeg de Label als er geen high score is
                highScoreLabels[i].text = "";
            }
        }
    }


    // Function to start a new game
    public void StartNewGamee()
    {
        SceneManager.LoadScene("IntroScene"); // Load intro scene
    }
}