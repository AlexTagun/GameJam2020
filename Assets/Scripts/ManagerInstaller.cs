using UnityEngine;
using Zenject;

public class ManagerInstaller : MonoInstaller {
    public override void InstallBindings() {
        Container.Bind<EventManager>().AsSingle();
        Container.Bind<TemperatureManager>().AsSingle();
    }
}
