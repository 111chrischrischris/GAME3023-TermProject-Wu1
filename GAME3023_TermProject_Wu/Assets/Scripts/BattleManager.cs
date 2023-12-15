using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class BattleManager : MonoBehaviour
{

    public BattleMenu currentMenu;

    [Header("Selection")]
    public GameObject SelectionMenu;
    public GameObject selectionInfo;
    public TextMeshProUGUI selectionInfoText;
    public TextMeshProUGUI fight;
    private string fightT;
    public TextMeshProUGUI bag;
    private string bagT;
    public TextMeshProUGUI pokemon;
    private string pokemonT;
    public TextMeshProUGUI run;
    private string runT;

    [Space(10)]
    [Header("Moves")]
    public GameObject movesMenu;
    public GameObject movesDetails;
    public TextMeshProUGUI PP;
    public TextMeshProUGUI pType;
    public TextMeshProUGUI moveO;
    private string moveOT;
    public TextMeshProUGUI moveT;
    private string moveTT;
    public TextMeshProUGUI moveTH;
    private string moveTHT;
    public TextMeshProUGUI movef;
    private string movefT;

    [Header("Info")]
    public GameObject InfoMenu;
    public TextMeshProUGUI InfoText;

    [Header("Misc")]
    public int currentSelection;
    // Start is called before the first frame update
    void Start()
    {
        fightT = fight.text;
        bagT = bag.text;
        pokemonT = pokemon.text;
        runT = run.text;
        moveOT = moveO.text;
        moveTT = moveT.text;
        moveTHT = moveTH.text;
        movefT = movef.text;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(currentSelection < 4)
            {
                currentSelection++;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(currentSelection > 0)
            {
                currentSelection--;
            }
        }
        if (currentSelection == 0)
            currentSelection = 1;

        switch(currentMenu)
        {
            case BattleMenu.Fight:
                switch (currentSelection)
                {
                    case 1:
                        moveO.text = "> " + moveOT;
                        moveT.text = moveTT;
                        moveTH.text = moveTHT;
                        movef.text = movefT;
                        break;
                    case 2:
                        moveO.text = moveOT;
                        moveT.text = "> " + moveTT;
                        moveTH.text = moveTHT;
                        movef.text = movefT;
                        break;
                    case 3:
                        moveO.text = moveOT;
                        moveT.text = moveTT;
                        moveTH.text = "> " + moveTHT;
                        movef.text = movefT;
                        break;
                    case 4:
                        moveO.text = moveOT;
                        moveT.text = moveTT;
                        moveTH.text = moveTHT;
                        movef.text = "> " + movefT;
                        break;
                }
                break;
            case BattleMenu.Selection:
                switch (currentSelection)
                {
                    case 1:
                        fight.text = "> " + fightT;
                        bag.text = bagT;
                        pokemon.text = pokemonT;
                        run.text = runT;
                        break;
                    case 2:
                        fight.text = fightT;
                        bag.text = "> " + bagT;
                        pokemon.text = pokemonT;
                        run.text = runT;
                        break;
                    case 3:
                        fight.text = fightT;
                        bag.text = bagT;
                        pokemon.text = "> " + pokemonT;
                        run.text = runT;
                        break;
                    case 4:
                        fight.text = fightT;
                        bag.text = bagT;
                        pokemon.text = pokemonT;
                        run.text = "> " + runT;
                        break;
                }
                break;
        }


    }

    public void ChangeMenu(BattleMenu m)
    {
        currentMenu = m;
        currentSelection = 0;
        switch(m)
        {
            case BattleMenu.Selection:
                SelectionMenu.gameObject.SetActive(true);
                selectionInfo.gameObject.SetActive(true);
                movesMenu.gameObject.SetActive(false);
                movesDetails.gameObject.SetActive(false);
                InfoMenu.gameObject.SetActive(false);
                break;
            case BattleMenu.Fight:
                SelectionMenu.gameObject.SetActive(false);
                selectionInfo.gameObject.SetActive(false);
                movesMenu.gameObject.SetActive(true);
                movesDetails.gameObject.SetActive(true);
                InfoMenu.gameObject.SetActive(false);
                break;
            case BattleMenu.Info:
                SelectionMenu.gameObject.SetActive(false);
                selectionInfo.gameObject.SetActive(false);
                movesMenu.gameObject.SetActive(false);
                movesDetails.gameObject.SetActive(false);
                InfoMenu.gameObject.SetActive(true);
                break;

        }
    }
}

public enum BattleMenu
{
    Selection,
    Pokemon,
    Bag,
    Fight,
    Info
}
