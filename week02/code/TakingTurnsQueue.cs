public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        // 1. Dequeue the person at the front
        var person = _people.Dequeue();

        // 2. Check if they should be put back in line
        // Infinite turns (0 or less)
        if (person.Turns <= 0)
        {
            _people.Enqueue(person);
        }
        // Finite turns: only re-enqueue if they have more than 1 turn remaining
        else if (person.Turns > 1)
        {
            person.Turns--;
            _people.Enqueue(person);
        }
        // If turns == 1, we don't re-enqueue them; they are finished.

        // 3. Return the person who just took their turn
        return person;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}