using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tewr.Blazor.FileReader;
using System.IO;
using JolijoberProject.Main.Repository.Interfaces;
using System.Security.Claims;
using JolijoberProject.Main.Repository.DataTransferObjects;

namespace Jolijober.Views.Pages
{
    public partial class MyProfile
    {
        [Inject]
        AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        private IFileReaderService fileReaderService { get; set; }

        [Inject]
        private  IIdentityRepository identityRepository { get; set; }

        public ProfileDto ProfileDto { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadData();


        }
        private async Task LoadData()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            ProfileDto= await identityRepository.GetProfile(authState.User.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}
