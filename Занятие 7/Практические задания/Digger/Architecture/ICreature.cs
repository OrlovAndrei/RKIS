namespace Digger.Architecture;

public interface ICreature
{
	string GetImageFileName();
	int GetDrawingPriority();
	CreatureCommand Act(int x, int y);
	bool DeadInConflict(ICreature conflictedObject);
}