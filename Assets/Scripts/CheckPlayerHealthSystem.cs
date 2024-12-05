
using Entitas;

public class CheckPlayerHealthSystem : IExecuteSystem {
    private readonly GameContext _context;

    public CheckPlayerHealthSystem(Contexts contexts) {
        _context = contexts.game;
    }

    public void Execute() {
        var entity = _context.GetGroup(GameMatcher.PlayerHealth).GetSingleEntity();

        if (entity.isPlayerDamaged) {
            entity.ReplacePlayerHealth(Mathf.Max(entity.playerHealth.Value - 10f, 0f));
            entity.isPlayerDamaged = false;
        }

        if (entity.isPlayerHealed) {
            entity.ReplacePlayerHealth(Mathf.Min(entity.playerHealth.Value + 10f, 100f));
            entity.isPlayerHealed = false;
        }
    }
}
