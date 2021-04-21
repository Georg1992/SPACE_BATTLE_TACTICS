using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CharList : MonoBehaviour
{
private int modelIndex; //model index


private GameObject [] charList; //array of models


private readonly string SelectedCharacter;
private void Start() {
    
charList = new GameObject[transform.childCount];
for(int modelIndex = 0; modelIndex<transform.childCount; modelIndex++){
charList[modelIndex]= transform.GetChild(modelIndex).gameObject;

PlayerPrefs.SetInt(SelectedCharacter,modelIndex);
}

foreach(GameObject go in charList)
go.SetActive(false);

if(charList[0]){
    charList[0].SetActive(true);
    

   
}
}


public void ToggleLeft()
{
    //toggle off the current model
    charList[modelIndex].SetActive(false);
    modelIndex--;
    if (modelIndex<0){
    modelIndex = charList.Length - 1;
    }
    PlayerPrefs.SetInt(SelectedCharacter,modelIndex);
    Debug.Log(modelIndex);
    charList[modelIndex].SetActive(true);
    
    

}

public void ToggleRight()
{
    //toggle off the current model
    charList[modelIndex].SetActive(false);
    modelIndex++;
    if (modelIndex==charList.Length)
    {modelIndex = 0;}
    PlayerPrefs.SetInt(SelectedCharacter, modelIndex);

    charList[modelIndex].SetActive(true);
    

    

}
public void ConfirmButton(){
    PlayerPrefs.SetInt(SelectedCharacter, modelIndex);
    SceneManager.LoadScene("Battle");
    
    
    
    }

}
