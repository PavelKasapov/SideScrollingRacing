using Zenject;

public class GameInstaller : MonoInstaller
{
    public RoadManager road;
    public CarController car;
    public GameStateManager gameStateManager;

    public override void InstallBindings()
    {
        Container.Bind<RoadManager>().FromInstance(road).AsSingle();
        Container.Bind<RoadShapeFactory>().AsSingle();
        Container.Bind<CarController>().FromInstance(car).AsSingle();
        Container.Bind<GameStateManager>().FromInstance(gameStateManager).AsSingle();
        Container.Bind<RoadSectionGenerationService>().AsSingle();
    }
}