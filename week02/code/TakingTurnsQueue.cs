using System;

public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    /// <summary>
    /// Adds a person to the queue.
    /// </summary>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Logic to get the next person and handle their turns.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        // Extract the person at the front of the queue
        Person person = _people.Dequeue();

        // If the person has infinite turns (0 or less)
        if (person.Turns <= 0)
        {
            _people.Enqueue(person);
        }
        // If the person has multiple turns left
        else if (person.Turns > 1)
        {
            person.Turns -= 1;
            _people.Enqueue(person);
        }

        return person;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}