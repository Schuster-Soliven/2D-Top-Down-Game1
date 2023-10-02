using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuzzleCollector : MonoBehaviour
{
    public static PuzzleCollector instance;

    public TMP_Text pieceText;
    public int currentPieces = 0;
    
    void Awake() {
        instance = this;
    }
    void Start() {
        pieceText.text = "Pieces Collected: " + currentPieces.ToString();
    } 

    public void IncreasePiece (int v) {
        currentPieces += v;
        pieceText.text = "Pieces Collected: " + currentPieces.ToString();
    } 
}