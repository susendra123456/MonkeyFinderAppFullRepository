﻿using Adventures.Common.Events;
using Adventures.Common.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MonkeyFinder.ViewModel;

public partial class BaseViewModel : ObservableObject, IMvpViewModel
{
    public IMvpPresenter Presenter { get; set; }

    public Guid Id { get; set; } = Guid.NewGuid();

    public BaseViewModel() { }

    [ICommand]
    async Task ButtonClickHandler(object sender)
    {
        var buttonArgs = new ButtonEventArgs
        {
            ViewModel = this
        };
        await Presenter?.ButtonClickHandler(sender, buttonArgs);
    }
}