using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public GameObject startPoint;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<RoadManager>().FromComponentInHierarchy().AsSingle();
        Container.BindFactory<string, Vehicle, Vehicle.Factory>().FromFactory<PrefabResourceFactory<Vehicle>>();
        Container.BindInstance<GameObject>(startPoint).WithId("startPoint");
        Container.Bind<RoadSectionGeneratorService>().AsSingle();
        Container.Bind<NewGameService>().AsSingle();
    }
}