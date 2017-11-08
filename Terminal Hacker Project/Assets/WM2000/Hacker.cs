using System;
using UnityEngine;

public class Hacker : MonoBehaviour
{
	string[] level1Passwords = { "books", "aisle", "self", "password", "font", "borrow" };
	string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };

	private string password;
	int level;
	enum Screen { MainScreen, Password, Win };
	Screen currentScreen;

	void Start()
	{
		ShowMainMenu();
	}

	void ShowMainMenu()
	{
		currentScreen = Screen.MainScreen;
		Terminal.ClearScreen();

		Terminal.WriteLine("Hello Dave...");
		Terminal.WriteLine("What would you like to hack into?\n");

		Terminal.WriteLine("Press 1 for the local library.");
		Terminal.WriteLine("Press 2 for the police station.");
		Terminal.WriteLine("Press 3 for NASA.\n");

		Terminal.WriteLine("Enter your selection:");
	}

	void OnUserInput(string input)
	{
		if (input == "menu")
		{
			ShowMainMenu();
		}
		else if (currentScreen == Screen.MainScreen)
		{
			RunMainMenu(input);
		}
		else if (currentScreen == Screen.Password)
		{
			CheckPassword(input);
		}
	}

	void RunMainMenu(string input)
	{
		bool isValidLevelNumber = (input == "1" || input == "2");

		if (isValidLevelNumber)
		{
			level = int.Parse(input);
			StartGame();
		}
		else if (input == "007")
		{
			Terminal.WriteLine("Please select a level Mr Bond!");
		}
		else
		{
			Terminal.WriteLine("Please choose a valid level");
		}
	}

	void StartGame()
	{
		currentScreen = Screen.Password;
		Terminal.ClearScreen();
		switch (level)
		{
			case 1:
				password = level1Passwords[0];
				break;
			case 2:
				password = level2Passwords[3];
				break;
			default:
				Debug.LogError("Invalid Level number");
				break;
		}
		Terminal.WriteLine("Please enter password: ");
	}

	void CheckPassword(string input)
	{
		if (input == password)
		{
			Terminal.WriteLine("Password Accepted!");
		}
		else
		{
			Terminal.WriteLine("Incorrect password");
		}
	}
}