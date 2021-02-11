using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int Week;
    public float Money;
    public int Points;
    public int Level;
    public int Health;
    public int Food;


    //user information
    public string UserName;
    public string UserTitle;
    public string UserGender;
    //end user information


   //Education info
   public bool IsUniversityAdmited;
   public bool IsCollegeAdmited;
   public bool IsUniversityGraduated;
   public bool IsCollegeGraduated;
   public string UniversitySubject;

   public int CollegePeriod;
   public int UniversityPeriod;
   //end for education info

   //Part-Time Job
   public string PartTimeJob;
   public float Salary;
   //end part-time job


    public GameData (GameManager gameManager)
    {
        Week   = gameManager.Week;
        Money  = gameManager.Money;
        Points = gameManager.Points;
        Level  = gameManager.Level;
        Health = gameManager.Health;
        Food   = gameManager.Food;

        //user info
        UserName   = gameManager.UserName;
        UserTitle  = gameManager.UserTitle;
        UserGender = gameManager.UserGender;
        //end user

        //Education info
        IsUniversityAdmited   = gameManager.IsUniversityAdmited;
        IsCollegeAdmited      = gameManager.IsCollegeAdmited;
        IsUniversityGraduated = gameManager.IsUniversityGraduated;
        IsCollegeGraduated    = gameManager.IsCollegeGraduated;

        CollegePeriod    = gameManager.CollegePeriod;
        UniversityPeriod = gameManager.UniversityPeriod;

        UniversitySubject = gameManager.UniversitySubject;
       //End Education Info

        //Part-Time Jobs
        PartTimeJob = gameManager.PartTimeJob;
        Salary      = gameManager.Salary;
        //end part-time job
        
    }
 
}
