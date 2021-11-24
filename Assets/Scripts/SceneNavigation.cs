/*
 * Program Header: Scene Navigation 
 * Robert Wymer - 101070567
 * Last Date Modified - Nov 22, 2021
 * Version 1.0
 * 
 * Basic Scene Navigation for Start Scene, Instruction Scenes, Game Scene and End Scene
 *
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigation : MonoBehaviour
{
    

    public void StartScene_StartButtonPressed()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void StartScene_InstructionButtonPressed()
    {
        SceneManager.LoadScene("InstructionScene");
    }

   

    public void GameScene_NextButtonPressed()
    {
        SceneManager.LoadScene("EndScene");
    }

    public void EndScene_PlayAgainButtonPressed()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void EndScene_MainMenuButtonPressed()
    {
        SceneManager.LoadScene("StartScene");
    }

    //Instruction Scene 1
    public void InstructionScene_BackButtonPressed()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void InstructionScene_NextButtonPressed()
    {
        SceneManager.LoadScene("InstructionScene2");
    }



    //Instruction Scene 2
    public void InstructionScene2_BackButtonPressed()
    {
        SceneManager.LoadScene("InstructionScene");
    }

    public void InstructionScene2_NextButtonPressed()
    {
        SceneManager.LoadScene("InstructionScene3");
    }

    //Instruction Scene 3
    public void InstructionScene3_BackButtonPressed()
    {
        SceneManager.LoadScene("InstructionScene2");
    }

    public void InstructionScene3_NextButtonPressed()
    {
        SceneManager.LoadScene("InstructionScene4");
    }

    //Instruction Scene 4
    public void InstructionScene4_BackButtonPressed()
    {
        SceneManager.LoadScene("InstructionScene3");
    }

    public void InstructionScene4_NextButtonPressed()
    {
        SceneManager.LoadScene("StartScene");
    }


}
