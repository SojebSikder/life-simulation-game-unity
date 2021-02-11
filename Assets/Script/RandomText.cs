using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomText
{
    public static string gender = null;
    public static int genderInt;
   public static string NameText()
    {
        string txt = null;

        int number = Random.Range(1, 11);

        switch (number)
        {
            case 1:
                txt = "Sojeb Sikder";
                gender = "Male";
                genderInt = 1;
                break;
            case 2:
                txt = "Mr Joe";
                gender = "Male";
                genderInt = 1;
                break;
            case 3:
                txt = "Devid Smith";
                gender = "Male";
                genderInt = 1;
                break;
            case 4:
                txt = "Harun Islam";
                gender = "Male";
                genderInt = 1;
                break;
            case 5:
                txt = "Ibrahim Hossain";
                gender = "Male";
                genderInt = 1;
                break;
            case 6:
                txt = "Alan Joe";
                gender = "Male";
                genderInt = 1;
                break;
            case 7:
                txt = "Aysha Alisha";
                gender = "Female";
                genderInt = 2;
                break;
            case 8:
                txt = "Nancy Lance";
                gender = "Female";
                genderInt = 2;
                break;
            case 9:
                txt = "Khadija Islam";
                gender = "Female";
                genderInt = 2;
                break;
            case 10:
                txt = "Farjana Rahman";
                gender = "Female";
                genderInt = 2;
                break;
            case 11:
                txt = "Jeasika Sikder";
                gender = "Female";
                genderInt = 2;
                break;
        }

        return txt;
    }

   public static string ConversationText()
    {
        string txt = null;
        int number = Random.Range(1, 6);

        switch (number)
        {
            case 1:
                txt = "hello word";
                break;
            case 2:
                txt = "what is your name";
                break;
            case 3:
                txt = "whats about you";
                break;
            case 4:
                txt = "do you want a work";
                break;
            case 5:
                txt = "whats happen here";
                break;
            case 6:
                txt = "name";
                break;
        }

        return txt;
    }
}
