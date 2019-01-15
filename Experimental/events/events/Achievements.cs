using System;

public class Achievements
{
	public Achievements()
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
