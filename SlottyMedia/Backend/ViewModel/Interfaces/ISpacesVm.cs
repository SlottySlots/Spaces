using System.Collections.ObjectModel;
using Microsoft.IdentityModel.Tokens;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;
using SlottyMedia.Backend.Dtos; 
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.ViewModel.Interfaces;

public interface ISpacesVm
{
    List<ForumDto> Forums { get; }
    Task LoadForums();
}