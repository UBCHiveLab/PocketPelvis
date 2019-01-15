using System;

public class UserInterface
{
	public UserInterface()
	{
	}

    void Start()
    {
        FindObjectOfType<Player>().deathEvent += OnPlayerDeath;
    }

    public void OnPlayerDeath()
    {
        FindObjectOfType<Player>().deathEvent -= OnPlayerDeath;
    }
}
