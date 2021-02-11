using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public GameManager _GameManager;
    public int AddToFood;
    public int AddToHealth;
    public int AddToMoney;
    public bool Purchased;
    public string ItemDescription;

    //temporary used
    private string RequirementString;


    public List<Item> Requirements;
 


    // Start is called before the first frame update
    void Start()
    {
        _GameManager = GameObject.Find("Main Camera").GetComponent<GameManager>();
    }

    public bool CheckRequirements()
    {
        bool PassedRequirements = true;
        RequirementString = "Requirements: ";
        string comma = "";
        foreach (Item CurrentItem in Requirements)
        {
            if (!CurrentItem.Purchased)
            {
                PassedRequirements = false;
                RequirementString += comma + CurrentItem.ItemDescription;
                comma = ", ";
            }
        }
        return PassedRequirements;
    }

   public void ProcessItem()
    {
       if(!CheckRequirements())
       {
            _GameManager.CustomBox("You Can't buy","You don't meet all the requirements. " + RequirementString);
            return;
       }
       else
       {

       }

        if (_GameManager.BuyItem(AddToMoney))
        {
            _GameManager.AddToHealth(AddToHealth);
            _GameManager.AddToFood(AddToFood);
            Purchased = true;
            _GameManager.UpdateUI();
        }


    }
   
}
