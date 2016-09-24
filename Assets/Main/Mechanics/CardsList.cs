﻿public class CardsList
{
    private CardsList() { }

    public const string Arthuria = "Arthuria";
    public const string Gilgamesh = "Gilgamesh";
    public const string Scatach = "Scatach";
    public const string Alex = "Alex";
    public const string Waver = "Waver";
    public const string Emiya = "Emiya";
    public const string Kintoki = "Kintoki";
    public const string Janne = "Janne";
    public const string JanneAlt = "JanneAlt";


    public enum Cards :byte
    {
        Arthuria = 1,
        Gilgamesh = 2,
        Scatach = 3,
        Alex = 4,
        Waver = 5,
        Emiya = 6,
        Kintoki = 7,
        Janne = 8,
        JanneAlt = 9
    }
    public enum Move : byte
    {
        Attack = 0,
        Skill1 =1,
        Skill2 =2,
        Skill3 =3,
        Ult =4
    }

}
