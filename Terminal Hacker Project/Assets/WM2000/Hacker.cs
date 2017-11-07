using UnityEngine;

public class Hacker : MonoBehaviour
{
	public string greeting = "Hello Dave...";

	// Use this for initialization
	void Start()
	{
		ShowMainMenu();
	}

	// Update is called once per frame
	void Update()
	{

	}

	void ShowMainMenu()
	{
		Terminal.ClearScreen();

		Terminal.WriteLine(greeting);
		Terminal.WriteLine("What would you like to hack into?\n");

		Terminal.WriteLine("Press 1 for the local library.");
		Terminal.WriteLine("Press 2 for the police station.");
		Terminal.WriteLine("Press 3 for NASA.\n");

		Terminal.WriteLine("Enter your selection:");
	}
}
