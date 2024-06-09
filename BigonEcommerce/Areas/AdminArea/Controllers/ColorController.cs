using BigonEcommerce.Data.DataAcces;
using Business.Models.ColorsModules.Commands.ColorEditCommand;
using Business.Models.ColorsModules.Commands.ColorRemoveCommand;
using Business.Models.ColorsModules.Commands.ColorssAddCommand;
using Business.Models.ColorsModules.Queries.ColorGet;
using Business.Models.ColorsModules.Queries.ColorsGetAll;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigonEcommerce.Areas.AdminArea.Controllers
{
    [Area(nameof(AdminArea))]

    public class ColorController : Controller
    {

        private readonly IMediator _mediator;

        public ColorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(ColorsGetAllRequest request)
        {
            var response = await _mediator.Send(request);
            return View(response);
        }

        public async Task<IActionResult> Details(ColorsGetByIdRequest request)
        {
            var response = await _mediator.Send(request);
            return View(response);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ColorAddRequest color)
        {
            try
            {
                await _mediator.Send(color);
                
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                return BadRequest("An error occurred while creating the color: " + ex.Message);
            }
        }


        public async Task<IActionResult> Edit(ColorsGetByIdRequest request)
        {
            var response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ColorEditRequest request)
        {
            if (request.Id == null) return NotFound();

            try
            {
                await _mediator.Send(request);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        [HttpPost]
        public async Task<IActionResult> Remove(ColorRemoveRequest request)
        {
            try
            {
                var response = await _mediator.Send(request); 
                //if (deletedColor is null)
                //{
                //    return Json(new
                //    {
                //        error = true,
                //        message = "Data is not available"
                //    });
                //}

                return PartialView("_Body", response);
            }
            catch
            {
                return View();
            }
        }
    }
}
