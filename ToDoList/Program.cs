﻿using System.ComponentModel.Design;
using ToDoList;

class Program
{
    public static void Main()
    {
        var user = new User();
        while (!user.IsAuthenticated)
        {
            user.ShowLoginPromt();
            user.AuthenticateUser();
        }

        Pages.ShowMainMenu(user);
    }
}