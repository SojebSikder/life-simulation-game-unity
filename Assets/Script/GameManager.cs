using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    //user information
    public string UserName;
    public string UserTitle;
    public string UserGender;
    //end user information


   public int Week;
   public float Money;
   public int Points;
   public int Level;
   public int Health;
   public int Food;

    float FoodCostValue;

    //Part-Time Jobs
    public string PartTimeJob;
    public float Salary;

    float texMoney;
    float overflowMoney;
    float finalMoney;
    //end oart-time job

    //Freelancing Variable
    float tutor;
    //end for Freelancing Variable

    int MaxHealth = 100;
    int MaxFood = 100;
    int MinHealth = 0;
    int MinFood = 0;

    //Education Variable
    [Header("Education Variable")]
   public bool IsUniversityAdmited;
   public bool IsCollegeAdmited;
   public bool IsUniversityGraduated;
   public bool IsCollegeGraduated;
   public string UniversitySubject;

   public int CollegePeriod;
   public int UniversityPeriod;

    public Button CollegeButton,UniversityButton;

    //end for Education Variable


    public Text DayText;
    public Text MoneyText;
    public Text PointsText;
    public Text LevelText;
    public Text FoodText;
    public Text HealthText;

    //end week box
    public Text totalMoney;
    public Text incomeText;
    public Text foodCost;
    public Text EndWeektitle;
    public Slider healthSlider;
    public Slider foodSlider;
    //end week end

    //user information
    [Header("User information")]
    public Text UserNameText;
    public Text UserTitleText;
    public Text GenderSelection;
    public Dropdown GenderDropDownMenu, UniversitySubjectDropDownMenu;
    public GameObject UserInfoPanel;
    //end user info

    //For user panel
    [Header("User Panel Info")]
    public Text UserNamePanel,GenderPanel,Age,Occupation,Maritial_Status;

    //End that


    //for custombox
    [Header("CustomBox")]
    public Text CustomTitle;
    public Text CustomMsg;
    //for freelance custombox
    [Header("Freelance Custom Box")]
    public Text FreelanceCustomTitle;
    public Text FreelanceCustomMsg;
    //end custombox

    [Header("Job")]
    public GameObject partTimejob;
    //Finance
    [Header("User Finance")]
    public GameObject UserFinanceWindow;
    public Text UserFinNameText,BankBlText,incomeFinText,texRateText,overflowText,assetsText;

    //dialouge box
    [Header("Academy Papers")]
    public GameObject CustomBoxDi, window, settingWindow, endWeekWindow, academicWindow, Freelance_job_Window, Freelance_CustomBox_Window, jobs_window;
    public GameObject seftyGlass,UserInfoBox,education_page,Education_promt;

    [Header("Academic Status")]
    public GameObject academicInfo, jobInfo,part_timeInfo;
    public Text academicTitle, academicSlogan;

    public Button academy,job,part_time;
    public Text partTimeJobStatusText;
    public InputField UserNameField;
    public Text messageField;


  

    //Declare class

    
    public void AddToHealth(int value)
    {
        Health += value;
    }
    public void AddToFood(int value)
    {
        Food += value;
    }
    public bool BuyItem(int value)
    {
        if (Money + value < 0)
        {
            CustomBox("Can't buy", "Not Enough Money");
            //CustomBox("Can't buy", RandomText());
            return false;
        }
        Money += value;

        return true;
    }

    public bool AddToMoney(int value)
    {
        Money += value;

        return true;
    }

    public bool AddToSalaryMoney(int value)
    {
        Salary += value;

        return true;
    }



     

    // Start is called before the first frame update
    void Start()
    {

        UserName = RandomText.NameText();
        UserGender = RandomText.gender;

         Week    = 1;
         Money  = 500;
         Points = 50;
         Food = MaxFood;
         Health = MaxHealth;
         Level  = 1;
         //Salary = 270;
         
        //freelancing variable
         tutor = 15;
        //end for freelancing variable

         healthSlider.maxValue = MaxHealth;
         foodSlider.maxValue   = MaxFood;


       //Education Variable intilize
            IsUniversityAdmited = false;
               IsCollegeAdmited = false;
          IsUniversityGraduated = false;
             IsCollegeGraduated = false;

              CollegePeriod =0;
              UniversityPeriod=0;
        //end for education variable

         UpdateUI();

         LoadGame();
         setupAcademy();

         if (UserName == "")
         {
             UserInfoBox.SetActive(true);
         }
        UpdateUI();

         
    }

    // Update is called once per frame
    void Update()
    {
        
        SaveGame();
    }


    //...................Earning..Code.............here.....
    public void ClickEarn()
    {

        texMoney = ((Salary*25)/100)*12;

        overflowMoney = (Salary/5)*12;

        finalMoney = (Salary*12)-texMoney-overflowMoney;

        Money = Money + finalMoney;

        Week = Week + 1;
        Food = Food - 5;
        Health = Health - 5;
        FoodCostValue = 0;

        setupEducation();
        
        UpdateUI();
    }
    //...............end..earning..code......here..........

    public void EatFood(int x)
    {
        if(Money > x)
        {   
            Money = Money - x;
            Food = Food + (x/3);
            Health = Health + (x/2);       
        }
        else
        {
            CustomBox("Oh Sorry!","Not Enough Money");
        }

        FoodCostValue = FoodCostValue + x;
        UpdateUI();
        closeFoodPanel();
    
    }

    public void CustomBox(string title, string msg)
    {
        CustomTitle.text = title;
        CustomMsg.text = msg;

        showSeftyGlass();
        CustomBoxDi.SetActive(true);
    }

   void showSeftyGlass()
    {
        seftyGlass.SetActive(true);

        UpdateUI();
    }

    void hideSeftyGlass()
    {
        seftyGlass.SetActive(false);

        UpdateUI();
    }

    public void Freelance_CustomBox(string title, string msg)
    {
        FreelanceCustomTitle.text = title;
        FreelanceCustomMsg.text = msg;

        Freelance_CustomBox_Window.SetActive(true);
        showSeftyGlass();
    }

    
    public void setgetText()
    {
        UserName = UserNameField.text;
        int val = GenderDropDownMenu.value;
        switch(val)
        {
            case 1:
                UserGender = "Male";
                break;
            case 2:
                UserGender = "Female";
                break;
        }
         
        Close_User_Info_Box();

        UpdateUI();
    }

    //For University Subject
    public string setgetUniversitySubject()
    {
        string UniversitySubjectChoice = null;
        int val = UniversitySubjectDropDownMenu.value;
        switch (val)
        {
            case 0:
                UniversitySubjectChoice = "Computer Science";
                break;
            case 1:
                UniversitySubjectChoice = "Physics";
                break;
            case 2:
                UniversitySubjectChoice = "Rocket Science";
                break;
            case 3:
                UniversitySubjectChoice = "Medical Science";
                break;
            case 4:
                UniversitySubjectChoice = "Chemistry";
                break;
            case 5:
                UniversitySubjectChoice = "Engineer";
                break;
            case 6:
                UniversitySubjectChoice = "Psycology";
                break;
            case 7:
                UniversitySubjectChoice = "Detective";
                break;
        }

        return UniversitySubjectChoice;

    }
    //end that

   public void UpdateUI()
    {
        UserNameField.text = UserName;
         
        if (UserName == null)
        {
            Show_User_Info_Box();
            setgetText();
        }

        if (UserTitle == "")
        {
            UserTitle = "Unemployed";
            UserTitleText.text = UserTitle;
            UpdateUI();
        }
         
        setupHungry();

        //user info
        
        UserNameText.text =UserName;
        UserTitleText.text = UserTitle;
        GenderSelection.text = UserGender;
        //end
        DayText.text = "Year : " + Week;
        MoneyText.text = "$" + Money;
        PointsText.text = "" + Points;
        LevelText.text = "" + Level;

        FoodText.text = "Food : " + Food;
        HealthText.text = "Health : " + Health;

        healthSlider.value = Health;
        foodSlider.value = Food;
        


        //end week data
       if(IsCollegeAdmited == true){

           EndWeektitle.text = "Year #"+Week+" College: "+CollegePeriod;

           academicInfo.SetActive(true);
           academicTitle.text = "College";
           academicSlogan.text = "Click to see options";

           UserTitle = "College";

       }else if(IsUniversityAdmited == true){

           EndWeektitle.text = "Year #"+Week+" University: "+UniversityPeriod;

           academicInfo.SetActive(true);
           academicTitle.text = "University";
           academicSlogan.text = "Click to see options";

           UserTitle = "University("+UniversitySubject+")";
       }
       else{
           EndWeektitle.text = "Year #"+Week;

           academicTitle.text = "No event";
           academicSlogan.text = "";

           academicInfo.SetActive(false);
       }

        
        
        totalMoney.text = "Total - $"+Money;
        incomeText.text = "Income - $"+finalMoney;
        foodCost.text = "   Food - $"+FoodCostValue;
        //end week end

      if(PartTimeJob == ""){
           part_timeInfo.SetActive(false);
       }
       else
       {
           part_timeInfo.SetActive(true);
           partTimeJobStatusText.text = PartTimeJob;    
       }

      
       

       //User Panel
       UserNamePanel.text = UserName;
       GenderPanel.text = UserGender;
       //Age.text = Age; 
       Occupation.text = UserTitle;
       //Maritial_Status = ;

       //End that
      
        CheckHungry();
        setupFinance();
        

    }

    //Additional function

   void setupFinance()
   {

       UserFinNameText.text = UserName;
       BankBlText.text = "$" + Money;
       incomeFinText.text ="$"+ Salary;
       texRateText.text = "$"+ texMoney;
       overflowText.text = "$" + overflowMoney;
       assetsText.text = "$" + Money;
       
   }



    public void randomName(){
        UserNameField.text = RandomText.NameText();
        GenderDropDownMenu.value = RandomText.genderInt;
    }


    public void ShowUserInfoPanel()
    {
        UserInfoPanel.SetActive(true);

        showSeftyGlass();
    }

    public void HideUserInfoPanlel()
    {
        UserInfoPanel.SetActive(false);

        hideSeftyGlass();
    }


    //End for additional function
  

    void setupAcademy()
    {
        academy.enabled = false;
        job.enabled = false ;
        part_time.enabled = false;

        jobInfo.SetActive(false);
        part_timeInfo.SetActive(false);
        
    }

    public void setupHungry()
    {

        if (Health > MaxHealth)
            Health = MaxHealth;

        if (Food > MaxFood)
            Food = MaxFood;
    }
    public void CheckHungry()
    {
        if (Food <= 0)
        {
            Food = MinFood;
            Health = Health - 10;
        }

        if (Health <= 0)
        {
            Health = MinHealth;
            Died();
        }
    }

    void Died()
    {
        SaveSystem.ClearGame();
        CustomBox("Game Over!","You Died");
        SceneManager.LoadScene("MainMenu");

    }

    //Apply Education Function Code

    void setupEducation()
    {
        //setup college
        if (IsCollegeAdmited == true)
        {
            CollegePeriod = CollegePeriod - 1;
        }
        if (IsCollegeAdmited == true && CollegePeriod == 0)
        {
            IsCollegeAdmited = false;
            IsCollegeGraduated = true;

            CustomBox("Horray!","You Completed College :)");

        } // end code for college

        //setup university
        if (IsUniversityAdmited == true)
        {
            UniversityPeriod = UniversityPeriod - 1;
        }
        if (IsUniversityAdmited == true && UniversityPeriod == 0)
        {
            IsUniversityAdmited = false;
            IsUniversityGraduated = true;

            CustomBox("New Journey", "Your " + UniversitySubject + " Degree Completed");

        } //end code for university

        UpdateUI();
    }
    public void ApplyUniversiy()
    {
        if(IsCollegeGraduated==true)
        {
            IsUniversityAdmited = true;
            UniversityButton.enabled = false;
            UniversityPeriod = 4;

            UniversitySubject = setgetUniversitySubject();

            CustomBox("Scholar", "You apply to university in "+UniversitySubject +" have been approved. This will cost $4,00,000");
           // Money = Money - 400000;
            CustomBox("Scholar", "You are now enrolled in University");

            Close_Education_Promt();
            Close_Education_Page();
            closeAcademicdWeekWindow();
        }
        else
        {
            CustomBox("Sorry","You should get admit at College first");
        }
    }

    public void ApplyCollege()
    {
        if(IsCollegeAdmited == false)
        {
            IsCollegeAdmited = true;
            CollegeButton.enabled = false;
            CollegePeriod = 2;
            CustomBox("Scholar","You are now enrolled in community college");

            Close_Education_Page();
            closeAcademicdWeekWindow();
        }
        else
        {
            CustomBox("Scholar", "You already studied in community college");
        }
    

    }

// End for Apply Education Function Code

    //Controlling Panel

    public void showUserFinance()
    {
        showSeftyGlass();
        UserFinanceWindow.SetActive(true);
    }
    public void closeUserFinance()
    {
        hideSeftyGlass();
        UserFinanceWindow.SetActive(false);
    }


   public void showPartTimeJob(){
       partTimejob.SetActive(true);
   }
   public void closePartTimeJob()
   {
       partTimejob.SetActive(false);
   }

    public void hideCustomBox()
    {
        hideSeftyGlass();
        CustomBoxDi.SetActive(false);
    }

    public void hide_Freelance_CustomBox()
    {
        hideSeftyGlass();
        Freelance_CustomBox_Window.SetActive(false);
        Close_Freelance_job_Window();
        closeAcademicdWeekWindow();
        
    }
   public void closeFoodPanel()
    {
        hideSeftyGlass();
        window.SetActive(false);
    }
   public void showFoodPanel()
   {
       showSeftyGlass();
       window.SetActive(true);
   }

   public void closeSettingPanel()
   {
       settingWindow.SetActive(false);
   }
   public void showSettingPanel()
   {
       settingWindow.SetActive(true);
   }

   public void closeendWeekWindow()
   {
       hideSeftyGlass();
       endWeekWindow.SetActive(false);
   }
   public void showendWeekWindow()
   {
       showSeftyGlass();
       endWeekWindow.SetActive(true);
       Handheld.Vibrate();
   }

   public void closeAcademicdWeekWindow()
   {
       academicWindow.SetActive(false);
   }
   public void showAcademicWeekWindow()
   {
       academicWindow.SetActive(true);
   }

   public void Show_job_Window()
   {
       jobs_window.SetActive(true);
       
   }
   public void Close_job_Window()
   {
       jobs_window.SetActive(false);
   }

    public void Show_Freelance_job_Window()
   {
       Freelance_job_Window.SetActive(true);
   }
    public void Close_Freelance_job_Window()
    {
        Freelance_job_Window.SetActive(false);
    }

    public void Show_User_Info_Box()
    {
        showSeftyGlass();
        UserInfoBox.SetActive(true);
    }

    public void Close_User_Info_Box()
    {
        hideSeftyGlass();
        UserInfoBox.SetActive(false);
    }

    public void Show_Education_Page()
    {
        education_page.SetActive(true);
    }

    public void Close_Education_Page()
    {
        education_page.SetActive(false);
    }

    public void Show_Education_Promt()
    {
        Education_promt.SetActive(true); 
        
    }

    public void Close_Education_Promt()
    {
        Education_promt.SetActive(false);
    }

    //End Panel

    public void freelance_tutor(float tutorMoney)
    {
        tutorMoney = tutor;
        Money = Money + (tutorMoney * 7);
        UpdateUI();

        Close_Freelance_job_Window();
        closeAcademicdWeekWindow();
        Freelance_CustomBox("You have earned!", "Earning: " + tutorMoney * 7 + "\n" + "Hours: 7\n" + "Hourly Rate: " + tutorMoney);

    }   
    //FREELANCE JOBS CODE




    //System Function
    public void SaveGame()
   {
       SaveSystem.SaveGame(this);
   }

    public void LoadGame()              //Load First all the variable (Important)
    {
       GameData data = SaveSystem.LoadGame();

       Week   = data.Week;
       Money  = data.Money;
       Points = data.Points;
       Level  = data.Level;
       Health = data.Health;
       Food   = data.Food;

        //user info
       UserName   = data.UserName;
       UserTitle  = data.UserTitle;
       UserGender = data.UserGender;
        //end for info

       //Education Info
       IsUniversityAdmited   = data.IsUniversityAdmited;
       IsCollegeAdmited      = data.IsCollegeAdmited;
       IsUniversityGraduated = data.IsUniversityGraduated;
       IsCollegeGraduated    = data.IsCollegeGraduated;

       CollegePeriod    = data.CollegePeriod;
       UniversityPeriod = data.UniversityPeriod;

       UniversitySubject = data.UniversitySubject;
       //End for Education info

       //Part-Time Jobs
       PartTimeJob = data.PartTimeJob;
       Salary      = data.Salary;
       //end oart-time job
        

         UpdateUI();       
    }
    //End for LoadGame()


  
}
