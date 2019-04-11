using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeManager : MonoBehaviour
{
    public static Cube chosenOne;

    [SerializeField] private List<Cube> cubes = new List<Cube>();
    [SerializeField] private GameObject victoryText, defeatText;
    [SerializeField] private GameObject questionText;
    [SerializeField] private Text rightAnswersText, wrongAnswersText;
    [SerializeField] private GameObject answerPanel, scorePanel;

    private List<float> positions = new List<float>();

    private int currentGame;
    private int rightAnswers, wrongAnswers;

    
    void Start()
    {
        positions.Add(-2);
        positions.Add(0);
        positions.Add(2);

        NewGame();
    }


    // Method to check if the player clicked on the right cube
    public void CheckCube(bool victory)
    {
        Debug.Log("check cube");
        answerPanel.SetActive(true);
        if (victory)
        {
            defeatText.SetActive(false);
            victoryText.SetActive(true);
            rightAnswers++;
        }
        else
        {
            victoryText.SetActive(false);
            defeatText.SetActive(true);
            wrongAnswers++;
        }
    }


    #region Initialization
    public void NextQuestion()
    {
        answerPanel.SetActive(false);
        if (currentGame >= 5)
        {
            // Display score
            questionText.SetActive(false);
            scorePanel.SetActive(true);
            rightAnswersText.text = "Right answers: " + rightAnswers;
            wrongAnswersText.text = "Wrong answers: " + wrongAnswers;
        }
        else
        {
            shuffleCubes();
            chooseCube();
            currentGame++;
        }
    }

    // Method to shuffle the three cubes randomly
    private void shuffleCubes()
    {
        List<float> tempPosList = new List<float>(positions);
        int i = 0;

        foreach (Cube cube in cubes)
        {
            int randomPosition = Random.Range(0, tempPosList.Count);
            cube.transform.position = new Vector3(tempPosList[randomPosition], 0.5f, 0f);
            tempPosList.Remove(tempPosList[randomPosition]);
            i++;
        }
    }

    // Method to change the question
    private void chooseCube()
    {
        chosenOne = cubes[Random.Range(0, cubes.Count)];

        if (chosenOne.name == "RedCube")
        {
            questionText.GetComponent<Text>().text = "Where is the red cube?";
        }
        else if (chosenOne.name == "GreenCube")
        {
            questionText.GetComponent<Text>().text = "Where is the green cube?";
        }
        else if (chosenOne.name == "BlueCube")
        {
            questionText.GetComponent<Text>().text = "Where is the blue cube?";
        }

        questionText.SetActive(true);
    }
    #endregion

    public void NewGame()
    {
        currentGame = 0;

        answerPanel.SetActive(false);
        victoryText.SetActive(false);
        defeatText.SetActive(false);
        questionText.SetActive(false);
        scorePanel.SetActive(false);

        currentGame = 0;
        rightAnswers = 0;
        wrongAnswers = 0;

        NextQuestion();
    }
}
