using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobItem : MonoBehaviour
{

    public GameManager _GameManager;

    public int AddToMoney;
    public bool Applied;
    //public string ItemDescription;
    public Text ItemDescription;

    //temporary used
    private string RequirementString;


    public List<JobItem> Requirements;
 


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
        foreach (JobItem CurrentItem in Requirements)
        {
            if (!CurrentItem.Applied)
            {
                PassedRequirements = false;
                RequirementString += comma + CurrentItem.ItemDescription.text;
                comma = ", ";
            }
        }
        return PassedRequirements;
    }

   public void ProcessItem()
    {
       if(!CheckRequirements())
       {
            _GameManager.CustomBox("You Can't apply","You don't meet all the requirements. " + RequirementString);
            return;
       }

       if (_GameManager.IsUniversityGraduated){

           if (_GameManager.AddToSalaryMoney(AddToMoney))
           {

               _GameManager.PartTimeJob = ItemDescription.text;
               _GameManager.Salary = AddToMoney;
               _GameManager.UserTitle = ItemDescription.text;
               Applied = true;
               _GameManager.UpdateUI();

               _GameManager.Freelance_CustomBox("You have earned!", "Congratulations. You get a job. Monthly Salary: " + AddToMoney);
           }

       }
       else
       {
           _GameManager.CustomBox("You Can't apply", "You don't have University Degree. ");
       }
   }


}
   
