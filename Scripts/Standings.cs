using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Standings : MonoBehaviour
{
    public static Standings Instance;

    private string cpu1Name;
    private string cpu2Name;
    private string cpu3Name;
    private float cpu1Time;
    private float cpu2Time;
    private float cpu3Time;

    private string firstPlaceName;
    public TextMeshProUGUI firstPlaceNameText;
    private string secondPlaceName;
    public TextMeshProUGUI secondPlaceNameText;
    private string thirdPlaceName;
    public TextMeshProUGUI thirdPlaceNameText;

    private float firstPlaceTime;
    public TextMeshProUGUI firstPlaceTimeText;
    private float secondPlaceTime;
    public TextMeshProUGUI secondPlaceTimeText;
    private float thirdPlaceTime;
    public TextMeshProUGUI thirdPlaceTimeText;
    
    public TextMeshProUGUI playerLoseText;

    private string[] firstName = {"Beth", "Jason", "Kim", "Fred", "Mary",
                                  "Jesus", "Anthony", "Sarah", "Jen", "Eddie"};
    
    private string[] lastName = { "Kindlow", "Jaxson", "Fredricks", "Williams", "Hernandez",
                                  "Stone", "Roberts", "Pillfort", "Bedinger", "Hampton" };

    private float playerTime;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        playerLoseText.gameObject.SetActive(false);
    }

    public void PopulateWinners()
    {
        playerTime = GameController.Instance.GetFinalTime();

        //build while loop to cancel duplicate names


        cpu1Name = firstName[Random.Range(0, firstName.Length)] + " " + lastName[Random.Range(0, lastName.Length)];
        cpu1Time = Random.Range(60, 90);
        int minutes1 = Mathf.FloorToInt(cpu1Time / 60F);
        int seconds1 = Mathf.FloorToInt(cpu1Time % 60F);

        cpu2Name = firstName[Random.Range(0, firstName.Length)] + " " + lastName[Random.Range(0, lastName.Length)];
        cpu2Time = Random.Range(91, 120);
        int minutes2 = Mathf.FloorToInt(cpu2Time / 60F);
        int seconds2 = Mathf.FloorToInt(cpu2Time % 60F);

        cpu3Name = firstName[Random.Range(0, firstName.Length)] + " " + lastName[Random.Range(0, lastName.Length)];
        cpu3Time = Random.Range(121, 150);
        int minutes3 = Mathf.FloorToInt(cpu3Time / 60F);
        int seconds3 = Mathf.FloorToInt(cpu3Time % 60F);

        Debug.Log(cpu1Name + " " + minutes1.ToString("00") + ":" + seconds1.ToString("00"));
        Debug.Log(cpu2Name + " " + minutes2.ToString("00") + ":" + seconds2.ToString("00"));
        Debug.Log(cpu3Name + " " + minutes3.ToString("00") + ":" + seconds3.ToString("00"));

        if(playerTime <= cpu1Time)
        {
            playerLoseText.gameObject.SetActive(true);
            playerLoseText.gameObject.SetActive(true);
            playerLoseText.text = "Congratulations, you are the winner on this episode of dont eat it. You move on to the next round. We will let you know when the next event will air.";
            firstPlaceName = "Player 1";
            firstPlaceTime = playerTime;
            
            secondPlaceName = cpu1Name;
            secondPlaceTime = cpu1Time;

            thirdPlaceName = cpu2Name;
            thirdPlaceTime = cpu2Time;

        }
        else if (playerTime >= cpu1Time && playerTime <= cpu2Time )
        {
            playerLoseText.gameObject.SetActive(true);
            playerLoseText.text = "So close to the top. Keep trying and make your way to the number 1 spot!";
            firstPlaceName = cpu1Name;
            firstPlaceTime = cpu1Time;

            secondPlaceName = "Player 1";
            secondPlaceTime = playerTime;

            thirdPlaceName = cpu2Name;
            thirdPlaceTime = cpu2Time;
        }
        else if (playerTime >=cpu2Time && playerTime <= cpu3Time)
        {
            playerLoseText.gameObject.SetActive(true);
            playerLoseText.text = "So close to the top. Keep trying and make your way to the number 1 spot!";
            firstPlaceName = cpu1Name;
            firstPlaceTime = cpu1Time;

            secondPlaceName = cpu2Name;
            secondPlaceTime = cpu2Time;

            thirdPlaceName = "Player 1";
            thirdPlaceTime = playerTime;
        }
        else
        {
            float playerM = Mathf.FloorToInt(playerTime / 60F);
            float playerS = Mathf.FloorToInt(playerTime % 60F);
            playerLoseText.gameObject.SetActive(true);
            playerLoseText.text = "Sorry But Your Time Of " + playerM.ToString("00") + ":" + playerS.ToString("00") + " Wasn't Fast Enough To Place In The Top 3.\nTry Again To See If You Can Do It!";

            firstPlaceName = cpu1Name;
            firstPlaceTime = cpu1Time;

            secondPlaceName = cpu2Name;
            secondPlaceTime = cpu2Time;

            thirdPlaceName = cpu3Name;
            thirdPlaceTime = cpu3Time;
        }


        //names
        firstPlaceNameText.text = firstPlaceName;
        secondPlaceNameText.text = secondPlaceName;
        thirdPlaceNameText.text = thirdPlaceName;
        //times
        float firstTimeMins = Mathf.FloorToInt(firstPlaceTime / 60F); 
        float firstTimeSec = Mathf.FloorToInt(firstPlaceTime % 60F); 
        firstPlaceTimeText.text = firstTimeMins.ToString("00") + ":" + firstTimeSec.ToString("00");
        
        float secondTimeMins = Mathf.FloorToInt(secondPlaceTime / 60F);
        float secondTimeSec = Mathf.FloorToInt(secondPlaceTime % 60F);
        secondPlaceTimeText.text = secondTimeMins.ToString("00") + ":" + secondTimeSec.ToString("00");

        float thirdTimeMins = Mathf.FloorToInt(thirdPlaceTime / 60F);
        float thirdTimeSec = Mathf.FloorToInt(thirdPlaceTime % 60F);
        thirdPlaceTimeText.text = thirdTimeMins.ToString("00") + ":" + thirdTimeSec.ToString("00");
    }

}
