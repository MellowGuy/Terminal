using UnityEngine;

public class Hacker : MonoBehaviour
{
	//Game configuration
	const string menuHint = "You may type menu at any time.";
	string[] level1Passwords = { "books", "aisle", "shelf", "password", "font", "borrow" };
	string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
	string[] level3Passwords = { "starfield", "telescope", "environment", "exploration", "astronauts" };

	private string password;
	int level;
	enum Screen { MainScreen, Password, Win };
	Screen currentScreen;

	void Start()
	{
		ShowMainMenu();
	}

	//Displays main menu texts
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

	//Takes user input, can go to menu at any time, 
	void OnUserInput(string input)
	{
		if (input == "menu")
		{
			ShowMainMenu();
		}
		else if (input == "exit" || input == "close")
		{
			Application.Quit();
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

	//Checks if given level entry is valid
	void RunMainMenu(string input)
	{
		bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");

		if (isValidLevelNumber)
		{
			level = int.Parse(input);
			AskForPassword();
		}
		else if (input == "007")
		{
			Terminal.WriteLine("Please select a level Mr Bond!");
		}
		else
		{
			Terminal.WriteLine("Please choose a valid level");
			Terminal.WriteLine(menuHint);
		}
	}

	//Changes to password screen, asks for password giving hint via anagram
	void AskForPassword()
	{
		currentScreen = Screen.Password;
		Terminal.ClearScreen();
		SetRandomPassword();
		Terminal.WriteLine("Enter password, hint: " + password.Anagram());
	}

	//Sets password to random item in password arrays
	void SetRandomPassword()
	{
		switch (level)
		{
			case 1:
				password = level1Passwords[Random.Range(0, level1Passwords.Length)];
				break;
			case 2:
				password = level2Passwords[Random.Range(0, level2Passwords.Length)];
				break;
			case 3:
				password = level3Passwords[Random.Range(0, level3Passwords.Length)];
				break;
			default:
				Debug.LogError("Invalid Level number");
				Terminal.WriteLine(menuHint);
				break;
		}
	}

	//Checks given password
	void CheckPassword(string input)
	{
		if (input == password)
		{
			DisplayWinScreen();
		}
		else
		{
			Terminal.WriteLine("Incorrect password");
			AskForPassword();
		}
	}

	//Switches to win screen,
	void DisplayWinScreen()
	{
		currentScreen = Screen.Win;
		Terminal.ClearScreen();
		ShowLevelReward();
	}

	//Displays when password is correct.
	void ShowLevelReward()
	{
		switch (level)
		{
			case 1:
				Terminal.WriteLine("Have a book");
				Terminal.WriteLine(@"
                           _______
                          /      /,
                         / Book //
                        /______//
                       (______(/
				 ");
				break;
			case 2:
				Terminal.WriteLine("Have a Gun");
				Terminal.WriteLine(@"
					___________,
				 \-'       _____|     
				  )   _ __/
				 / `./_/
				|   |      
				|   \         
				`---'
				");
				break;
			case 3:
				Terminal.WriteLine("Rocket launched!");
				Terminal.WriteLine(@"
				/ \    | |
			   |--o|===|-|
			   |---|   |d|
			  /     \  |w|
			 |       |=| |
			 |_______| |_|
			  |@| |@|  | |
				");
				break;
			default:
				break;
		}
	}
}