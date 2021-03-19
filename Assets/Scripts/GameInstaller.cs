using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public RoadManager road;
    public VehicleController vehicle;
    public GameStateManager gameStateManager;
    public GameObject startPoint;

    public override void InstallBindings()
    {
        Container.Bind<RoadManager>().FromInstance(road).AsSingle();
        Container.Bind<RoadShapeFactory>().AsSingle();
        Container.Bind<VehicleController>().FromComponentInNewPrefabResource("Prefabs/Vehicle").AsSingle();
        Container.BindInstance<GameObject>(startPoint).WithId("startPoint");
        Container.Bind<GameStateManager>().FromInstance(gameStateManager).AsSingle();
        Container.Bind<RoadSectionGenerationService>().AsSingle();
    }
}