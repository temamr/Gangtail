using UnityEngine;
using Zenject;

public class GeneralInstaller : MonoInstaller
{
    [SerializeField] private DialoguesInstaller dialoguesInstaller;

    public override void InstallBindings()
    {
        BindDialogueInstaller();
    }

    public void BindDialogueInstaller()
    {
        Container.Bind<DialoguesInstaller>().FromInstance(dialoguesInstaller).AsSingle();
    }
}
