﻿using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using PaintingGroupWebApp.Data;
using PaintingGroupWebApp.Interfaces;
using PaintingGroupWebApp.Models;
using PaintingGroupWebApp.ViewModels;

namespace PaintingGroupWebApp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardRespository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPhotoService _photoService;

        public DashboardController(IDashboardRepository dashboardRespository, IHttpContextAccessor httpContextAccessor, IPhotoService photoService)
        {
            _dashboardRespository = dashboardRespository;
            _httpContextAccessor = httpContextAccessor;
            _photoService = photoService;
        }
        private void MapUserEdit(AppUser user, EditUserDashboardViewModel editVM, ImageUploadResult photoResult)
        {
            user.Id = editVM.Id;
            user.FavouriteStyle = editVM.FavouriteStyle;
            user.FavouriteMedium = editVM.FavouriteMedium;
            user.ProfileImageUrl = photoResult.Url.ToString();
            user.City = editVM.City;
            user.County = editVM.County;
        }
        public async Task<IActionResult> Index()
        {
            var userRaces = await _dashboardRespository.GetAllUserMeetings();
            var userClubs = await _dashboardRespository.GetAllUserClubs();
            var dashboardViewModel = new DashboardViewModel()
            {
                Meetings = userRaces,
                Clubs = userClubs
            };
            return View(dashboardViewModel);
        }
        public async Task<IActionResult> EditUserProfile()
        {
            var curUserId = _httpContextAccessor.HttpContext.User.GetUserId();
            var user = await _dashboardRespository.GetUserById(curUserId);
            if (user == null) return View("Error");
            var editUserViewModel = new EditUserDashboardViewModel()
            {
                Id = curUserId,
                FavouriteStyle = user.FavouriteStyle,
                FavouriteMedium = user.FavouriteMedium,
                ProfileImageUrl = user.ProfileImageUrl,
                City = user.City,
                County = user.County
            };
            return View(editUserViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditUserProfile(EditUserDashboardViewModel editVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit profile");
                return View("EditUserProfile", editVM);
            }

            AppUser user = await _dashboardRespository.GetByIdNoTracking(editVM.Id);

            if (user.ProfileImageUrl == "" || user.ProfileImageUrl == null)
            {

                var photoResult = await _photoService.AddPhotoAsync(editVM.Image);

                MapUserEdit(user, editVM, photoResult);

                _dashboardRespository.Update(user);

                return RedirectToAction("Index");
            }
            else
            {
                try
                {
                    await _photoService.DeletePhotoAsync(user.ProfileImageUrl);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Could not delete photo");
                    return View(editVM);
                }
                var photoResult = await _photoService.AddPhotoAsync(editVM.Image);

                MapUserEdit(user, editVM, photoResult);

                _dashboardRespository.Update(user);

                return RedirectToAction("Index");
            }
        }
    }
}
